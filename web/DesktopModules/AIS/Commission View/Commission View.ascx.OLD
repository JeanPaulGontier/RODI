<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2016                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Commission View.ascx.cs" Inherits="DesktopModules_AIS_Commission_View_Commission_View" %>

<asp:Panel ID="pnl_admin" runat="server" CssClass="panel panel-default panel-body row">
    <asp:Button ID="btn_edit" runat="server" Text="Modifier une commission" OnClick="btn_edit_Click" CssClass="btn btn-primary right" />
</asp:Panel>


<asp:Panel ID="pnl_com" runat="server" >
    <asp:Panel CssClass="text-center panel panel-body" runat="server">
        Année rotarienne : <asp:DropDownList ID="ddl_rotary_year" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_rotary_year_SelectedIndexChanged"></asp:DropDownList>    
        <h3><asp:Label ID="lbl_noCommissions" runat="server" Text="Aucune commission à afficher" Visible="false"></asp:Label></h3>
    </asp:Panel>
    
    
    
</asp:Panel>

<asp:Panel ID="pnl_edit" runat="server" Visible="false" CssClass="panel panel-default panel-body row">
    <asp:Panel ID="Panel1" runat="server">
        <p>Sélectionnez une commission à modifier : <asp:DropDownList ID="ddl_commission" runat="server"></asp:DropDownList> &nbsp <asp:Button ID="btn_commission" CssClass="btn btn-primary" runat="server" Text="Valider" OnClick="btn_commission_Click" /></p>
        <br />

        <asp:GridView ID="gvw_com" AutoGenerateColumns="false" GridLines="None" OnRowCommand="gvw_com_RowCommand" CssClass="table table-stripped" runat="server">
            <Columns>
                <asp:TemplateField HeaderText ="Fonction">
                    <ItemTemplate>
                        <asp:Label ID="lbl_job" runat="server" Text='<%# Bind("job") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText ="Nom du membre">
                    <ItemTemplate>
                        <asp:Label ID="lbl_member" runat="server" Text='<%# Bind("memberName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="btn_editCom" CssClass="btn btn-primary" CommandName="GEdit" CommandArgument='<%# Bind("id") %>'><span class="fa fa-pencil"></span></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="btn_deleteCom" CssClass="btn btn-danger" OnClientClick="Javascript: return confirm('Voulez-vous vraiment supprimer ce membre de la commission ?');" CommandName="GDelete" CommandArgument='<%# Bind("id") %>' ><span class="fa fa-trash-o"></span></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <asp:Button ID="btn_add" runat="server" CssClass="btn btn-primary" OnClick="btn_add_Click" Visible="false" Text="Ajouter un nouveau membre à cette commission" />

    </asp:Panel>
    
    

    <asp:Panel ID="pnl_add" runat="server" Visible="false">
        <h1>Ajout d'un nouveau membre</h1>
        <div class="row">
            <div class="col-sm-2">
                <p>Fonction : </p>
            </div>
            <div class="col-sm-10">
                <asp:TextBox ID="tbx_job" Width="300" runat="server"></asp:TextBox>
            </div>
        </div>
        <asp:Panel ID="pnl_search" CssClass="row" runat="server">
            <div class="col-sm-2">
                <p>Nom du membre : </p>
            </div>
            <div class="col-sm-10">
                <asp:TextBox ID="tbx_membre" Width="300" runat="server"></asp:TextBox>
            </div>
        </asp:Panel>
        <asp:HiddenField ID="hfd_id" runat="server" />
        <asp:Button ID="btn_validate" runat="server" Text="Valider" OnClick="btn_validate_Click" CssClass="btn btn-primary" />
    </asp:Panel>
    <asp:LinkButton ID="btn_back" runat="server" CssClass="btn btn-default right" Text="Retour" OnClick="btn_back_Click"></asp:LinkButton>
</asp:Panel>