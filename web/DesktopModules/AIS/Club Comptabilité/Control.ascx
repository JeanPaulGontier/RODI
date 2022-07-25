<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2016                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true"  CodeFile="Control.ascx.cs" Inherits="DesktopModules_AIS_Club_Comptabilite_Control" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Panel ID="Panel1" runat="server">
    <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped"  AllowSorting="True"  GridLines="None" AllowPaging="True" PageSize="50" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand" AutoGenerateColumns="False" OnSorting="GridView1_Sorting">
    <Columns>
        <asp:BoundField DataField="dt" HeaderText="Date" SortExpression="dt" DataFormatString="{0:d}" />
        <asp:BoundField DataField="title" HeaderText="Titre"  SortExpression="title" />
        <asp:ButtonField ButtonType="Link" runat="server" Text="Détail" CommandName="detail" />
    </Columns>    
   <PagerSettings Mode="NumericFirstLast" Position="Bottom" /> 
</asp:GridView>
<asp:HiddenField ID="tri" Value="dt" runat="server"/><asp:HiddenField ID="sens" Value="DESC" runat="server"/>
<asp:HiddenField ID="HF_Cric" runat="server" />
</asp:Panel>
<asp:Panel ID="Panel2" runat="server" Visible="false">
<asp:HiddenField runat="server" ID="HF_id" />

<div class="Marron">
	<h2><span class="Head">Détail du règlement</span></h2>
</div>
    <asp:HiddenField runat="server" ID="Cloture" />
<div>
	<span>Date : </span>	
	<asp:Label  runat="server" ID="TXT_Dt"></asp:Label>
</div>
<div>   
    <span>Règlement : </span>
    <asp:Label  runat="server" ID="TXT_Titre"></asp:Label>        	
</div>   
<div>
	<span>Description : </span>
</div>
<div>
    <asp:Label  runat="server" ID="TXT_Editor"></asp:Label>        	
</div>
<div>
    <span>Type de règlement :</span>
    <asp:HiddenField  runat="server" ID="HF_Type_Payment"></asp:HiddenField>    
    <asp:Label  runat="server" ID="TXT_Payment"></asp:Label>                
</div>
<asp:Panel runat="server" ID="P_Montant1" Visible="false">        
    <asp:Label runat="server" ID="LBL_libelle1"></asp:Label>
    <asp:Label runat="server" ID="TXT_montant1"></asp:Label>            
</asp:Panel>
<asp:Panel runat="server" ID="P_Montant2" Visible="false">
    <asp:Label runat="server" ID="LBL_libelle2"></asp:Label>
    <asp:Label runat="server" ID="TXT_montant2"></asp:Label>                        
</asp:Panel>        
<div>
<asp:Panel runat="server" ID="P_Cloture" class="txtCloture" >
    <span style="color:red; text-align:center">
    Les inscriptions sont clôturées...
    </span>
</asp:Panel>
<asp:Panel runat="server" ID="P_Boutons" class="txtCenter">
    <asp:Button runat="server" ID="BT_Nouvelle_Order" CssClass="btn btn-primary" Text="Passer une commande" OnClick="BT_Nouvelle_Order_Click" CausesValidation="false" />&nbsp;<asp:Button runat="server" ID="BT_Annuler" Text="Retour" CssClass="btn btn-primary" OnClick="BT_Annuler_Click" CausesValidation="false" />
</asp:Panel>

<div>Liste des commandes :</div>
<asp:Panel ID="Panel5" runat="server" Visible="false">
    <div class="txtCenter"><p><asp:Label runat="server" Text="Votre commande a été validée, avec comme numéro : "></asp:Label><asp:Label runat="server" ID="LBL_Numero_Order"></asp:Label></p></div>
    <div class="txtCenter"><p><asp:LinkButton ID="BT_Payment_Order" runat="server" Text="Procéder au règlement de la commande"></asp:LinkButton></p></div>    
</asp:Panel>


<asp:GridView ID="GridView2" runat="server" Width="100%" CssClass="table table-stripped spacingTop" AllowSorting="True" GridLines="None" AutoGenerateColumns="False" OnSorting="GridView2_Sorting"  OnRowDataBound="GridView2_RowDataBound">
<Columns>
    <asp:BoundField DataField="dt" HeaderText="Date" SortExpression="dt" DataFormatString="{0:d}"  ItemStyle-Width="100" />
    <asp:BoundField DataField="id" HeaderText="N°" SortExpression="id" ItemStyle-Width="50"  />
    <asp:BoundField DataField="amount" HeaderText="Montant" SortExpression="amount" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:n}" ItemStyle-Width="50" />
    <asp:BoundField DataField="rule" HeaderText="Réglée" SortExpression="rule"  ItemStyle-Width="100"/>
    <asp:TemplateField ItemStyle-Width="200">
        <ItemTemplate >
            <asp:HyperLink runat="server" ID="HL_Paiement" Text="Payer maintenant"></asp:HyperLink>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:BoundField DataField="rule_par" HeaderText="Par"  />
    <asp:TemplateField>
        <ItemTemplate>
            <asp:HyperLink runat="server" ID="HL_Detail" Text="Détail" Target="_blank"></asp:HyperLink>
        </ItemTemplate>
    </asp:TemplateField>
</Columns>    
    <EmptyDataTemplate>
        <div>Vous n'avez passé aucune commande pour le moment ...</div>
    </EmptyDataTemplate>
   <PagerSettings Mode="NumericFirstLast" Position="Bottom" /> 
</asp:GridView>


    <asp:HiddenField ID="tri2" Value="club" runat="server"/><asp:HiddenField ID="sens2" Value="ASC" runat="server"/>
</div>

</asp:Panel>
<asp:Panel ID="Panel3" runat="server" Visible="false">
    <h1><asp:Label ID="Label1" runat="server" Text ="Nouvelle commande"></asp:Label></h1><br />
    
    <asp:Label runat="server" Text="Liste des membres du club :"></asp:Label>
    <asp:Panel runat="server" ID="P_Members">

    </asp:Panel>
    <div class="txtCenter"><asp:Button runat="server" ID="BT_Verifier" Text="Vérifier la commande" OnClick="BT_Verifier_Click" />&nbsp;<asp:Button runat="server" ID="BT_Annuler_Order" Text="Annuler" OnClick="BT_Annuler_Order_Click" /></div>
    <script type="text/javascript">function AC(cb, p) { var objcb = document.getElementById(cb); var obj = document.getElementById(p); if (objcb.checked) obj.setAttribute("class", "commande_invite_visible"); else obj.setAttribute("class", "commande_invite_invisible"); }</script>
</asp:Panel> 
<asp:Panel ID="Panel4" runat="server" Visible="false">
    <h1><asp:Label ID="Label2" runat="server" Text ="Nouvelle commande"></asp:Label></h1><br />
    
    <asp:Label ID="Label3" runat="server" Text="Vérification de la commande"></asp:Label><br />
    <p>
    <asp:Literal runat="server" ID="LIT_Order"></asp:Literal>
    </p>
    <div class="txtCenter"><asp:Label runat="server" ID="TXT_Result" Visible="false"></asp:Label></div>
    <div class="txtCenter"><asp:Button runat="server" ID="BT_Valider" Text="Valider la commande" OnClientClick="javascript: return confirm('Valider la commande ?');" OnClick="BT_Valider_Click" />&nbsp;<asp:Button runat="server" ID="BT_Retour_Order" Text="Retour" OnClick="BT_Retour_Order_Click" /></div>   
</asp:Panel> 
