<!--***********************************************************************-->
<!-- RODI - https://rodi-platform.org/                                     -->
<!-- Copyright (c) 2012-2018                                               -->
<!-- by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--***********************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Settings.ascx.cs" Inherits="DesktopModules_AIS_Ticketing_Settings" %>

<h2 class="dnnformsectionhead">Administratif</h2>

<div class="form-group">
    <asp:Label runat="server" Text="Billeterie ouverte : " CssClass="control-label col-sm-3"></asp:Label>
    <div class="col-sm-9">
        <asp:RadioButtonList runat="server" ID="RB_Opened" RepeatDirection="Horizontal" CssClass="radio-inline" RepeatLayout="Flow">
            <asp:ListItem Text="Oui" Value="YES"></asp:ListItem>
            <asp:ListItem Text="Non" Value="NO"></asp:ListItem>
        </asp:RadioButtonList>
    </div>
</div>
<div class="pe-spacer size20"></div>
<div class="form-group">
    <asp:Label runat="server" Text="Nom de l'évènement : " CssClass="control-label col-sm-3"></asp:Label>
    <div class="col-sm-9">
        <asp:TextBox runat="server" ID="TXT_NAME" class="form-control"></asp:TextBox>
    </div>
</div>
<div class="form-group">
    <asp:Label runat="server" Text="Description : " CssClass="control-label col-sm-3"  />
    <div class="col-sm-9">
        <asp:TextBox runat="server" ID="TXT_DESCRIPTION" class="form-control" TextMode="MultiLine"></asp:TextBox>
    </div>
</div>
<div class="form-group">
    <asp:Label runat="server" Text="Date de début : " CssClass="control-label col-sm-3" />
    <div class="col-sm-9">
        <asp:TextBox runat="server" ID="TXT_EVENTSTARTDATE" class="form-control" Width="200"></asp:TextBox>
    </div>
</div>
<div class="form-group">
    <asp:Label runat="server" Text="Date de fin : " CssClass="control-label col-sm-3" />
    <div class="col-sm-9">
        <asp:TextBox runat="server" ID="TXT_EVENTENDDATE" class="form-control" Width="200"></asp:TextBox>
    </div>
</div>
<div class="pe-spacer size20"></div>
<div class="form-group">
    <asp:Label runat="server" Text="Label du commentaire : " CssClass="control-label col-sm-3" />
    <div class="col-sm-9">
        <asp:TextBox runat="server" ID="TXT_LABEL_COMMENT" class="form-control"></asp:TextBox>
    </div>
</div>
<div class="form-group">
    <asp:Label runat="server" Text="Adresse Evènement : " CssClass="control-label col-sm-3" />
    <div class="col-sm-9">
        <asp:TextBox runat="server" ID="TXT_ADDRESS" class="form-control"></asp:TextBox>
    </div>
</div>
<div class="pe-spacer size20"></div>
<div class="form-group">
    <asp:Label runat="server" Text="Position GPS : " CssClass="control-label col-sm-3" />
    <div class="col-sm-9">        
        <div class="form-group">
            <asp:Label runat="server" Text="Latitude :" CssClass="control-label col-sm-3" />
            <div class="col-sm-9">
                <asp:TextBox runat="server" ID="TXT_LATITUDE" class="form-control" Width="100"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" Text="Longitude :" CssClass="control-label col-sm-3" />
            <div class="col-sm-9">
                <asp:TextBox runat="server" ID="TXT_LONGITUDE" class="form-control" Width="100"></asp:TextBox>
            </div>
        </div>
    </div>
</div>
<div class="form-group">
    <asp:Label runat="server" Text="Email Billetterie : " CssClass="control-label col-sm-3" />
    <div class="col-sm-9">
        <asp:TextBox runat="server" ID="TXT_EMAIL" class="form-control" TextMode="Email"></asp:TextBox>
    </div>
</div>
<div class="pe-spacer size20"></div>
<div class="form-group">
    <asp:Label runat="server" Text="Contact visible du public : " CssClass="control-label col-sm-3" />
    <div class="col-sm-9">
        <div class="form-group">
            <asp:Label runat="server" Text="Nom :" CssClass="control-label col-sm-3" />
            <div class="col-sm-9">
                <asp:TextBox runat="server" ID="TXT_CONTACT_NAME" class="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" Text="Téléphone :" CssClass="control-label col-sm-3" />
            <div class="col-sm-9">
                <asp:TextBox runat="server" ID="TXT_CONTACT_PHONE" class="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" Text="Email :" CssClass="control-label col-sm-3" />
            <div class="col-sm-9">
                <asp:TextBox runat="server" ID="TXT_CONTACT_EMAIL" class="form-control" TextMode="Email"></asp:TextBox>
            </div>
        </div>
    </div>
</div>
    
<h2 class="dnnformsectionhead">Méthodes de paiement</h2>

<div class="form-group">
    <asp:Label runat="server" Text="Activer STRIPE : " CssClass="control-label col-sm-4" />
    <div class="col-sm-8">
            <asp:RadioButtonList runat="server" ID="RB_STRIPEACTIVATED" RepeatDirection="Horizontal">
                <asp:ListItem Text="Oui" Value="YES"></asp:ListItem>
                <asp:ListItem Text="Non" Value="NO"></asp:ListItem>
            </asp:RadioButtonList>
    </div>
</div>
<div class="pe-spacer size20"></div>
<div class="form-group">
    <asp:Label runat="server" Text="Clé publique Stripe : " CssClass="control-label col-sm-4" />
    <div class="col-sm-8">
        <asp:TextBox runat="server" ID="TXT_STRIPE_PUBLIC_KEY" class="form-control"></asp:TextBox>
    </div>
</div>
<div class="form-group">
    <asp:Label runat="server" Text="Clé secrète Stripe : " CssClass="control-label col-sm-4" />
    <div class="col-sm-8">
        <asp:TextBox runat="server" ID="TXT_STRIPE_PRIVATE_KEY" class="form-control"></asp:TextBox>
    </div>
</div>
<div class="form-group">
    <asp:Label runat="server" Text="Stripe URL IPN : " CssClass="control-label col-sm-4" />
    <div class="col-sm-8">
        <asp:TextBox runat="server" ID="TXT_STRIPEIPNURL" class="form-control"></asp:TextBox>
    </div>
</div>
<div class="form-group">
    <asp:Label runat="server" Text="Stripe URL Logo : " CssClass="control-label col-sm-4" />
    <div class="col-sm-8">
        <asp:TextBox runat="server" ID="TXT_STRIPELOGOURL" class="form-control"></asp:TextBox>
    </div>
</div>
<div class="pe-spacer size20"></div>
<div class="form-group">
    <asp:Label runat="server" Text="Activer Paypal : " CssClass="control-label col-sm-4" />
    <div class="col-sm-8">
        <asp:RadioButtonList runat="server" ID="RB_PAYPALACTIVATED" RepeatDirection="Horizontal">
            <asp:ListItem Text="Oui" Value="YES"></asp:ListItem>
            <asp:ListItem Text="Non" Value="NO"></asp:ListItem>
        </asp:RadioButtonList>
    </div>
</div>
<div class="pe-spacer size20"></div>
<div class="form-group">
    <asp:Label runat="server" Text="Compte Paypal : " CssClass="control-label col-sm-4" />
    <div class="col-sm-8">
        <asp:TextBox runat="server" ID="TXT_PAYPALEMAIL" class="form-control" ></asp:TextBox>
    </div>
</div>
<div class="form-group">
    <asp:Label runat="server" Text="Paypal URL IPN : " CssClass="control-label col-sm-4" />
    <div class="col-sm-8">        
        <asp:TextBox runat="server" ID="TXT_PAYPALIPNURL" class="form-control"></asp:TextBox>
    </div>
</div>
<div class="pe-spacer size20"></div>
<div class="form-group">
    <asp:Label runat="server" Text="Activer paiement par virement : " CssClass="control-label col-sm-4" />
    <div class="col-sm-8">
        <asp:RadioButtonList runat="server" ID="RB_BANKTRANSFERTACTIVATED" RepeatDirection="Horizontal">
            <asp:ListItem Text="Oui" Value="YES"></asp:ListItem>
            <asp:ListItem Text="Non" Value="NO"></asp:ListItem>
        </asp:RadioButtonList>
    </div>
</div>
<div class="pe-spacer size20"></div>
<div class="form-group">
    <asp:Label runat="server" Text="IBAN compte pour virement : " CssClass="control-label col-sm-4" />
    <div class="col-sm-8">
        <asp:TextBox runat="server" ID="TXT_BANK_TRANSFERT_IBAN" class="form-control"></asp:TextBox>
    </div>
</div>
<div class="form-group">
    <asp:Label runat="server" Text="Texte paiement par virement : " CssClass="control-label col-sm-4" />
    <div class="col-sm-8">
        <asp:TextBox runat="server" ID="TXT_BANK_TRANSFERT_TEXT" class="form-control" TextMode="MultiLine"></asp:TextBox>
    </div>
</div>
<div class="pe-spacer size20"></div>
<div class="form-group">
    <asp:Label runat="server" Text="Activer paiement par chèque : " CssClass="control-label col-sm-4" />
    <div class="col-sm-8">
        <asp:RadioButtonList runat="server" ID="RB_BANKCHEQUEACTIVATED" RepeatDirection="Horizontal">
            <asp:ListItem Text="Oui" Value="YES"></asp:ListItem>
            <asp:ListItem Text="Non" Value="NO"></asp:ListItem>
        </asp:RadioButtonList>
    </div>
</div>
<div class="pe-spacer size20"></div>
<div class="form-group">
    <asp:Label runat="server" Text="Ordre paiement par chèque : " CssClass="control-label col-sm-4" />
    <div class="col-sm-8">
        <asp:TextBox runat="server" ID="TXT_BANK_CHEQUE_DEST" class="form-control"></asp:TextBox>
    </div>
</div>
<div class="form-group">
    <asp:Label runat="server" Text="Texte paiement par chèque : " CssClass="control-label col-sm-4" />
    <div class="col-sm-8">
        <asp:TextBox runat="server" ID="TXT_BANK_CHEQUE_TEXT" TextMode="MultiLine" class="form-control"></asp:TextBox>
    </div>
</div>

<h2 class="dnnformsectionhead">Technique</h2>

<table style="width:90%">
    <tr>
        <td><asp:Label runat="server" Text="GUID Billeterie"></asp:Label></td>
        <td style="width:60%"><asp:TextBox runat="server" ID="TXT_GUID" Width="100%"></asp:TextBox></td>
    </tr>
    <tr>
        <td><asp:Label runat="server" Text="Rôle Administrateur Billetterie : " /></td>
        <td><asp:TextBox runat="server" ID="TXT_ADMINROLE" Width="100%"></asp:TextBox></td>
    </tr>
    <tr>
        <td><asp:Label runat="server" Text="Rôle Lecture seule Billetterie : " /></td>
        <td><asp:TextBox runat="server" ID="TXT_READONLYROLE" Width="100%"></asp:TextBox></td>
    </tr>
    <tr>
        <td><asp:Label runat="server" Text="URL Billetterie : " ToolTip="En général la même que la page de la billetterie" ID="Label2" /></td>
        <td><asp:TextBox runat="server" ID="TXT_EVENTURL" Width="100%"></asp:TextBox></td>
    </tr>
    <tr>
        <td><asp:Label runat="server" Text="URL Visionneuse Ticket : " ToolTip="En général la même que la page de la billetterie" ID="Label3" /></td>
        <td><asp:TextBox runat="server" ID="TXT_TICKETURL" Width="100%"></asp:TextBox></td>
    </tr>
     <tr>
        <td><asp:Label runat="server" Text="URL Visionneuse Reçu : " ToolTip="En général la même que la page de la billetterie" ID="Label1" /></td>
        <td><asp:TextBox runat="server" ID="TXT_RECEIPTURL" Width="100%"></asp:TextBox></td>
    </tr>
    <tr>
        <td colspan="2"><h2>Champs supplémentaires</h2></td>
    </tr>  
     <tr>
        <td colspan="2">
            <asp:DataGrid CssClass="table table-bordered table-hover" runat="server" ID="G_Fields" AutoGenerateColumns="false" OnEditCommand="G_Fields_EditCommand" OnUpdateCommand="G_Fields_UpdateCommand" OnDeleteCommand="G_Fields_DeleteCommand">
                <Columns>
                    <asp:BoundColumn DataField="label" HeaderText="Label"></asp:BoundColumn>
                    <asp:TemplateColumn HeaderText="Type">
                        <EditItemTemplate>
                            <asp:DropDownList runat="server" ID="type" >
                                <asp:ListItem Value="TEXT">Texte</asp:ListItem>
                                <asp:ListItem Value="RADIO">Bouton radio</asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label runat="server"  Text='<%# DataBinder.Eval(Container.DataItem, "type") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="Obligatoire">
                        <EditItemTemplate>
                            <asp:DropDownList runat="server" ID="mandatory" >
                                <asp:ListItem Value="YES">Oui</asp:ListItem>
                                <asp:ListItem Value="NO">Non</asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label runat="server"  Text='<%# ((bool)DataBinder.Eval(Container.DataItem, "mandatory")==true?"Oui":"Non")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:BoundColumn DataField="value" HeaderText="Valeurs"></asp:BoundColumn>
                    <asp:BoundColumn DataField="comment" HeaderText="Commentaire"></asp:BoundColumn>
                    <asp:EditCommandColumn ButtonType="LinkButton"    
                       EditText="Modifier"
                       CancelText="Annuler"
                       UpdateText="Valider" />
                    <asp:ButtonColumn 
                         
                       ButtonType="LinkButton" 
                       Text="Delete" 
                       CommandName="Delete"/>  
                </Columns>
            </asp:DataGrid>
            <asp:Button CssClass="btn" runat="server" ID="BT_Add_Field" Text="Ajouter un champ" OnClick="BT_Add_Field_Click" />
        </td>
    </tr>

    <tr>
        <td colspan="2"><h2>Options</h2></td>
    </tr>  
    <tr>
        <td colspan="2">
            
            <asp:DataGrid CssClass="table table-bordered table-hover" runat="server" ID="G_Options" AutoGenerateColumns="false" OnEditCommand="G_Options_EditCommand" OnUpdateCommand="G_Options_UpdateCommand" OnDeleteCommand="G_Options_DeleteCommand" Width="90%">
                <Columns>
                    <asp:TemplateColumn HeaderText="Libellé / Description" ItemStyle-Width="300">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "name") %>' Width="300"></asp:Label><br />
                            <em><asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "description") %>' Width="300"></asp:Label></em>
                        </ItemTemplate> 
                        <EditItemTemplate>
                            <asp:TextBox runat="server" ID="name" Text='<%# DataBinder.Eval(Container.DataItem, "name") %>'></asp:TextBox><br />
                            <em><asp:TextBox runat="server" ID="description" Text='<%# DataBinder.Eval(Container.DataItem, "description") %>'></asp:TextBox></em>
                        </EditItemTemplate>
                    </asp:TemplateColumn>
                   
                    <asp:BoundColumn DataField="price" HeaderText="Prix" ItemStyle-Width="50"></asp:BoundColumn>
                    <asp:BoundColumn DataField="startsaledate" HeaderText="Début vente" ItemStyle-Width="100"></asp:BoundColumn>
                    <asp:BoundColumn DataField="endsaledate" HeaderText="Fin vente" ItemStyle-Width="100"></asp:BoundColumn>
                    <asp:BoundColumn DataField="maxqty" HeaderText="Qté Max" ItemStyle-Width="50"></asp:BoundColumn>
                    <asp:TemplateColumn HeaderText="Actif" ItemStyle-Width="50">
                        <EditItemTemplate>
                            <asp:DropDownList runat="server" ID="enabled" >
                                <asp:ListItem Value="YES">Oui</asp:ListItem>
                                <asp:ListItem Value="NO">Non</asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label runat="server"  Text='<%# ((bool)DataBinder.Eval(Container.DataItem, "enabled")==true?"Oui":"Non")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:EditCommandColumn ButtonType="LinkButton"
                        
                       EditText="Modifier"
                        
                                      CancelText="Annuler"
                                      UpdateText="Valider" />
                    <asp:ButtonColumn 
                         
                         ButtonType="LinkButton" 
                         Text="Delete" 
                         CommandName="Delete"/>  
                </Columns>
            </asp:DataGrid>
            <asp:Button runat="server" CssClass="btn" ID="BT_Add_Option" Text="Ajouter une option" OnClick="BT_Add_Option_Click" />
        </td>
    </tr>

    <tr>
        <td colspan="2"><h2>Configuration</h2></td>
    </tr>  
    <tr>
        <td><asp:Label runat="server" Text="Configuration actuelle"></asp:Label></td>
        <td><asp:TextBox runat="server" ID="TXT_TICKETING" TextMode="MultiLine" ></asp:TextBox></td>
    </tr>
    <tr>
        <td><asp:Label runat="server" Text="Importer configuration XML"></asp:Label></td>
        <td><asp:TextBox runat="server" ID="TXT_IMPORT" TextMode="MultiLine" ValidateRequestMode="Disabled" ></asp:TextBox></td>
    </tr>
    <tr>
        <td><asp:Button runat="server" CssClass="btn" Text="Importer la configation" ID="BT_Import" OnClick="BT_Import_Click" OnClientClick="return confirm('Importer la configuration XML ?');" /></td>
        <td><asp:Button runat="server" CssClass="btn" Text="Paramètres par défaut" ID="BT_Default" OnClick="BT_Default_Click" OnClientClick="return confirm('Restaurer les paramètres par défaut ?');"></asp:Button></td>
    </tr>
 </table>