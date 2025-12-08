<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Control.ascx.cs" Inherits="DesktopModules_AIS_Club_AAR_Control" %>
  <asp:Label ID="lbl_choisirClub" runat="server" Text="Veuillez choisir un club..." />
<asp:Panel runat="server" ID="P_Principal">
    <asp:Label runat="server" ID="LBL_AR" Text="Année Rotarienne : "></asp:Label>
    <asp:RadioButtonList runat="server" ID="RB_AR" AutoPostBack="true" OnSelectedIndexChanged="RB_AR_SelectedIndexChanged" RepeatDirection="Horizontal"></asp:RadioButtonList>
    <asp:Panel ID="PanelErreur" runat="server" CssClass="panel panel-danger" Visible="false"><div class="panel-heading"><asp:Label ID="lbl_erreur" runat="server" Text="" /></div></asp:Panel>
    <asp:Panel ID="Panel1" runat="server">
    </asp:Panel>
    <asp:Button ID="BT_Valider" runat="server" Text="Valider" CssClass="btn btn-primary right" OnClientClick="javascript: return confirm('Valider les changements ?');" OnClick="BT_Valider_Click" />
    <asp:HiddenField ID="HF_Cric" runat="server" /><script type="text/javascript">function AfficheValider() { obj=document.getElementById("<%=BT_Valider.ClientID%>").style;obj.visibility='visible';}</script>
    <br />
    <asp:Panel runat="server" ID="P_Legende">
        <em>* affectations qui permettent d'administrer le club</em>
    </asp:Panel>

    <asp:Label ID="TXT_Result" runat="server"></asp:Label>
    <div class="pe-spacer size10"></div>
    <asp:Panel runat="server" ID="P_PersonnalisationInfos" CssClass="alert alert-warning">
        <p>Administrateur(s) du club :</p>
        <asp:Label runat="server" ID="L_Administrators"></asp:Label>
    </asp:Panel>
    <asp:Button ID="BT_Personnalisation" runat="server" Text="Personnaliser l'administration" OnClick="BT_Personnalisation_Click" CssClass="btn btn-default" />
    
</asp:Panel>
<asp:Panel runat="server" ID="P_Personnalisation">
      <asp:Button runat="server" ID="BT_Annuler_Affectes" CssClass="btn btn-default" Text="Retour" OnClick="BT_Annuler_Affectes_Click" />
    <h3>Affections personnalisées des administrateurs du club</h3>
    <div class="row">
        <div class="col-sm-6">
            <asp:DropDownList runat="server" ID="DDL_Membres" OnSelectedIndexChanged="DDL_Membres_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
        </div>
        
        <div class="col-sm-6">
            <asp:Button runat="server" ID="BT_Add" Text="+" OnClick="BT_Add_Click" ToolTip="Ajouter" CssClass="btn btn-primary"/>
        </div>
    </div>
    
    
    <h4>Liste des administrateurs :</h4>
    
    <asp:DataList runat="server" ID="L_Affectes" RepeatLayout="Flow" ItemStyle-Height="2em" OnItemDataBound="L_Affectes_ItemDataBound" OnItemCommand="bt_delete_Click" >     
        <ItemTemplate>
            <asp:Label ID="lbl" runat="server"></asp:Label> <asp:LinkButton runat="server" ID="bt_delete" CommandName="deletemember" ToolTip="Retirer"><i class="fa fa-trash-o text-danger"></i></asp:LinkButton>
        </ItemTemplate>     
      
    </asp:DataList>
    <asp:Label runat="server" ID="L_empty">Veuillez ajouter un membre...</asp:Label>
    <div class="pe-spacer size20"></div>
      
    <div>
        <div class="col-sm-6">
            <asp:Button runat="server" ID="BT_Valider_Affectes" CssClass="btn btn-primary" Text="Valider" OnClick="BT_Valider_Affectes_Click" />

        </div>
        <div class="col-sm-6 text-right">
            <asp:Button runat="server" ID="BT_Supprimer_Personnalisation" CssClass="btn btn-danger" Text="Supprimer la personnalisation" OnClick="BT_Supprimer_Personnalisation_Click" />
        </div>
    </div>
    
</asp:Panel>