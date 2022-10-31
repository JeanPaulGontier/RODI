<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Control.ascx.cs" Inherits="DesktopModules_AIS_Ticketing_Control" %>
<%@ Reference Control="~/DesktopModules/AIS/Ticketing/People.ascx"  %>
<script src="https://polyfill.io/v3/polyfill.min.js?version=3.52.1&features=fetch"></script>
<script src="https://js.stripe.com/v3/"></script>

<div id="billetterie"></div>
<asp:UpdatePanel runat="server" ID="UpdatePanel1">
    <ContentTemplate>
        <asp:Panel runat="server" ID="P_Message" Visible="false"><asp:Label runat="server" ID="L_Message"></asp:Label></asp:Panel>
        <asp:Label runat="server" ID="L_Name" Visible="false"></asp:Label>
        <asp:Label runat="server" ID="L_Description" Visible="false"></asp:Label>
        <asp:HiddenField runat="server" ID="H_Step" />
        <asp:HiddenField runat="server" ID="TXT_GUID" />
        <asp:Panel runat="server" ID="PAdminExport" Visible="false">
            <asp:Button runat="server" ID="BT_Export_Attendees" OnClick="BT_Export_Attendees_Click" Text="Exporter la liste des participants" CssClass="btn btn-default" />
            <asp:Button runat="server" ID="BT_Export_Reservations"  OnClick="BT_Export_Reservations_Click" Text="Exporter la liste des réservations" CssClass="btn btn-default" />
        </asp:Panel>
        <asp:Panel runat="server" ID="PAdmin" Visible="false">
            <asp:Button runat="server" ID="BT_Export_Orders_Paid" OnClick="BT_Export_Orders_Paid_Click" Text="Exporter les commandes Payées" CssClass="btn btn-default" />
            <asp:Button runat="server" ID="BT_Export_Orders_Unpaid" OnClick="BT_Export_Orders_Unpaid_Click" Text="Exporter les commandes non Payées" CssClass="btn btn-default" />
            <asp:Button runat="server" ID="BT_Export_Orders_Refunded" OnClick="BT_Export_Orders_Refunded_Click" Text="Exporter les commandes remboursées" CssClass="btn btn-default" />
            <asp:Button runat="server" ID="BT_Export_Vouchers" OnClick="BT_Export_Vouchers_Click" Text="Exporter les invitations" CssClass="btn btn-default" />
            <div><h2>Gestion des commandes</h2></div>
            <div>Référence commande : <asp:TextBox runat="server" ID="TXT_Reference" ></asp:TextBox></div>
            <div><asp:Button runat="server" Text="Recherche par référence" ID="BT_SearchByRef" OnClick="BT_SearchByRef_Click" CssClass="btn btn-default" /></div>
            <asp:Panel runat="server" ID="P_Order" Visible="false">
                <asp:HiddenField ID="H_Order_Reference" runat="server" />
                <asp:Literal runat="server" ID="L_Order_Detail">

                </asp:Literal>
                <div>N° Transaction, N° Chèque ou Date de virement : <asp:TextBox runat="server" ID="TXT_Order_Transaction_ID"></asp:TextBox></div>
                <div><asp:RadioButtonList runat="server" ID="RB_Order_Payment"><asp:ListItem Text="Oui" Value="YES"></asp:ListItem><asp:ListItem Text="Non" Value="NO"></asp:ListItem><asp:ListItem Text="Rembourssée" Value="REFUNDED"></asp:ListItem></asp:RadioButtonList></div>
                <div><asp:Button runat="server" ID="BT_ManualPayment" Text="Valider le paiement manuellement" OnClick="BT_ManualPayment_Click" CssClass="btn btn-default" /><div class="text-right"><asp:Button runat="server" ID="BT_ManualDelete" Text="Effacer la commande" OnClick="BT_ManualDelete_Click" CssClass="btn btn-default" OnClientClick="return confirm('Effacer cette commande ?')" /></div></div>
            </asp:Panel>
            <asp:Panel runat="server" ID="P_SuperAdmin" Visible="false">
                <asp:Button runat="server" ID="BT_PaypalIPNCheck" Visible="false" OnClick="BT_PaypalIPNCheck_Click" Text="Rapprochement Paypal" CssClass="btn btn-default" />
                <asp:Button runat="server" ID="BT_Emails" Visible="false" Text="Envoi des emails invitation"  OnClick="BT_Emails_Click" CssClass="btn btn-default"/>
                <asp:Panel runat="server" Visible="false"><asp:TextBox runat="server" ID="L_Emails" TextMode="MultiLine" Width="100%"></asp:TextBox></asp:Panel>
            </asp:Panel>
            <div class="pe-spacer size30"></div>
        </asp:Panel>
        <asp:Panel runat="server" ID="P0">
            <div class="pe-spacer size30">La billetterie est fermée</div>
        </asp:Panel>
        <asp:Panel runat="server" ID="P1">
            <div class="small btn-group btn-group-justified">
                <span class="btn btn-info">1. Panier</span>                       
                <span class="btn btn-default">2. Coordonnées</span>                   
                <span class="btn btn-default">3. Validation</span>                    
                <span class="btn btn-default">4. Confirmation</span>                                    
            </div>
            <div class="pe-spacer size30"></div>
            <asp:DataList runat="server" ID="L_Basket" OnItemDataBound="L_Basket_ItemDataBound" Width="100%">
                <HeaderTemplate>
                    <div class="form-group row">
                        <div class="col-sm-8">
                            <strong><asp:Label runat="server" Text="Libellé"></asp:Label></strong>
                        </div>
                        <div class="col-sm-2 text-center">
                            <strong><asp:Label runat="server" Text="Prix"></asp:Label></strong>
                        </div>
                        <div class="col-sm-2 text-center">
                            <strong><asp:Label runat="server" Text="Qté"></asp:Label></strong>
                        </div>
                    </div>
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="form-group row">
                        <div class="col-sm-8">
                            <asp:HiddenField runat="server" ID="H_GUID" />
                            <asp:Label runat="server" ID="L_Libelle"></asp:Label><br />
                            <em><asp:Label runat="server" ID="L_Description" CssClass="small"></asp:Label></em>
                        </div>
                        <div class="col-sm-2 text-center">
                            <asp:Label runat="server" ID="L_Price"></asp:Label>
                            <asp:HiddenField runat="server" ID="L_PriceValue"></asp:HiddenField>
                        </div>
                        <div class="col-sm-2 text-center">
                            <asp:DropDownList runat="server" CssClass="form-control" ID="DL_NB" AutoPostBack="true" OnSelectedIndexChanged="DL_NB_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
            <div class="row form-group">
                <div class="col-sm-8"></div>
                <div class="col-sm-2 text-center">Total :</div>
                <div class="col-sm-2 text-center"><strong><asp:Label runat="server" ID="L_Total"></asp:Label></strong></div>
            </div>
                
            <div class="text-right"><asp:Button runat="server" Text="Réserver" ID="BT_Book" OnClick="BT_Book_Click" Visible="false" CssClass="btn btn-success text-uppercase" /></div>
            
        </asp:Panel>

        <asp:Panel runat="server" ID="P2" CssClass="form-horizontal">
            <div class="small btn-group btn-group-justified">
                <span class="btn btn-default">1. Panier</span>                       
                <span class="btn btn-info">2. Coordonnées</span>                   
                <span class="btn btn-default">3. Validation</span>                    
                <span class="btn btn-default">4. Confirmation</span>                                    
            </div>
            <div class="pe-spacer size30"></div>

            <h3><asp:Label runat="server" Text="Vos informations"/></h3>
          
            <div class="form-group">
                <asp:Label runat="server" Text="Prénom :" CssClass="control-label col-sm-3"></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox runat="server" ID="TXT_Customerfirstname" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="TXT_Customerfirstname" Text="Veuillez compléter" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>                    
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" Text="Nom :" CssClass="control-label col-sm-3"></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox runat="server" ID="TXT_Customerlastname" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="TXT_Customerlastname" Text="Veuillez compléter" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>                    
                </div>
            </div>
             <div class="form-group">
                <asp:Label runat="server" Text="Club :" CssClass="control-label col-sm-3"></asp:Label>
                <div class="col-sm-9">
                    <asp:DropDownList runat="server" ID="DL_ClubName" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" Text="Mél : " CssClass="control-label col-sm-3"></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox runat="server" ID="TXT_Customeremail" CssClass="form-control"></asp:TextBox>            
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="TXT_Customeremail" Text="Veuillez compléter" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>                    
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" Text="Tél. : " CssClass="control-label col-sm-3"></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox runat="server" ID="TXT_Customerphone" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="TXT_Customerphone" Text="Veuillez compléter" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>                    
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" Text="Commentaire : " CssClass="control-label col-sm-3"></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox runat="server" ID="TXT_Comment" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                    <asp:Label runat="server" ID="L_Comment"></asp:Label>      
                </div>
            </div>
            <asp:Panel runat="server" ID="P_People">

            </asp:Panel>
            <asp:DataList runat="server" ID="L_People" OnItemDataBound="L_People_ItemDataBound" Width="100%">
                <ItemTemplate>
                    <h3><asp:Label runat="server"  ID="L_Name"/></h3>
                    <asp:HiddenField runat="server" ID="H_GUID" />
                    <div class="form-group">
                        <asp:Label runat="server" Text="Prénom :" CssClass="control-label col-sm-3"></asp:Label>
                        <div class="col-sm-9">
                            <asp:TextBox runat="server" ID="TXT_Firstname" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="TXT_Firstname" Text="Veuillez compléter" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>                    
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" Text="Nom :" CssClass="control-label col-sm-3"></asp:Label>
                        <div class="col-sm-9">
                            <asp:TextBox runat="server" ID="TXT_Lastname" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="TXT_Lastname" Text="Veuillez compléter" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>                                        
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" Text="Mél : " CssClass="control-label col-sm-3"></asp:Label>
                        <div class="col-sm-9">
                            <asp:TextBox runat="server" ID="TXT_Email" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="TXT_Email" Text="Veuillez compléter" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <asp:Panel CssClass="form-group" runat="server" ID="P_Fields">

                    </asp:Panel>
                </ItemTemplate>
            </asp:DataList>
            <div class="row">
                <div class="col-sm-6 text-left"><asp:Button runat="server" CausesValidation="false" Text="Retour" ID="BT_ReturnBasket" OnClick="BT_ReturnBasket_Click" CssClass="btn btn-default text-uppercase" /></div>
                <div class="col-sm-6 text-right"><asp:Button runat="server" Text="Valider" ID="BT_ValidatePeople" OnClick="BT_ValidatePeople_Click" CssClass="btn btn-success text-uppercase" /></div>
            </div>
        </asp:Panel>

        <asp:Panel runat="server" ID="P3">
            <div class="small btn-group btn-group-justified">
                <span class="btn btn-default">1. Panier</span>                       
                <span class="btn btn-default">2. Coordonnées</span>                   
                <span class="btn btn-info">3. Validation</span>                    
                <span class="btn btn-default">4. Confirmation</span>                                    
            </div>

            <div class="pe-spacer size30"></div>
            <asp:Panel runat="server" ID="P3_Cheque">
                <div class="text-center">
                    <asp:Button runat="server" Text="Je souhaite payer par chèque" CssClass="btn btn-default" ID="BT_BANKCHEQUE" OnClick="BT_BANKCHEQUE_Click" />
                </div>
                <div class="pe-spacer size30"></div>
            </asp:Panel>

            <asp:Panel runat="server" ID="P3_Transfert">
                <div class="text-center">
                     <asp:Button runat="server" Text="Je souhaite payer par virement" CssClass="btn btn-default" ID="BT_BANKTRANSFERT" OnClick="BT_BANKTRANSFERT_Click" />
                </div>
                <div class="pe-spacer size30"></div>
            </asp:Panel>

            <asp:Panel runat="server" ID="P3_Paypal">
                <div class="text-center">
                    <asp:Button runat="server" Text="Je souhaite payer avec mon compte Paypal ou ma carte bancaire" CssClass="btn btn-default" ID="BT_PAYPAL" OnClick="BT_PAYPAL_Click" />
                </div>
                <div class="pe-spacer size30"></div>
                <div class="text-center">
                    <img src="https://www.paypalobjects.com/webstatic/en_US/i/buttons/cc-badges-ppmcvdam.png" alt="Paiement sécurisé Paypal">
                </div>
                <div class="pe-spacer size30"></div>

            </asp:Panel>

            <asp:Panel runat="server" ID="P3_Stripe">
                <div class="text-center">
                    <asp:Button runat="server" Text="Je souhaite payer avec ma carte bancaire" CssClass="btn btn-default" ID="BT_STRIPE" OnClick="BT_STRIPE_Click" />
                </div>
              
                <div class="pe-spacer size30"></div>

            </asp:Panel>

            

            <asp:HiddenField runat="server" ID="HF_PAYMENTMETHOD" />
            <div class="row">
                <div class="col-sm-6 text-left"><asp:Button runat="server" Text="Retour" ID="BT_ReturnPeople" OnClick="BT_ReturnPeople_Click" CssClass="btn btn-default text-uppercase" /></div>
                <div class="col-sm-6 text-right"><asp:Button runat="server" Text="Payer" ID="BT_Pay" OnClick="BT_Pay_Click" CssClass="btn btn-success text-uppercase" /></div>
            </div>
        </asp:Panel>

        <asp:Panel runat="server" ID="P4">
            <div class="small btn-group btn-group-justified">
                <span class="btn btn-default">1. Panier</span>                       
                <span class="btn btn-default">2. Coordonnées</span>                   
                <span class="btn btn-default">3. Validation</span>                    
                <span class="btn btn-info">4. Confirmation</span>                                    
            </div>
             <div class="pe-spacer size30"></div>
           <div class="text-center">Commande N° <strong><asp:Label runat="server" ID="LBLOrderReference"></asp:Label></strong></div>
             <div class="pe-spacer size30"></div>
           <div class="text-center">
                <pre><asp:Label runat="server" ID="LBLReponse"></asp:Label></pre>
            </div>
            <div class="pe-spacer size30"></div>
            <div class="text-center">
                <asp:Label runat="server" ID="LBLReponse2"></asp:Label>
            </div> 
            <div class="pe-spacer size30"></div>
            <div class="text-center">
                <asp:HyperLink runat="server" ID="BT_ShowReceipt" Text="Voir votre recu" CssClass="btn btn-success" Target="_blank" Visible="false"></asp:HyperLink>
                &nbsp;
                <asp:HyperLink runat="server" ID="BT_ShowTickets" Text="Voir vos tickets" CssClass="btn btn-success" Target="_blank" Visible="false"></asp:HyperLink>
            </div>

            <div class="pe-spacer size30"></div>
            <asp:Literal runat="server" ID="LT_STRIPE" Visible="false"></asp:Literal>
        </asp:Panel>
       
        </ContentTemplate>
</asp:UpdatePanel>
<div><em><small>Billetterie propulsée par <a href="https://rodi-platform.org">RODI-Platform.org</a></small></em></div>