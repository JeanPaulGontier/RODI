<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Archi Visu.ascx.cs" Inherits="DesktopModules_AIS_Admin_Archi_Visu_Archi_Visu" %>



<asp:Panel ID="pnl_display" runat="server">
    <h1><asp:Label ID="lbl_section" runat="server"></asp:Label></h1>
    <div class="row">
        <div class="col-sm-4">
            <asp:RadioButtonList ID="rbl_rotaryYear" runat="server" RepeatDirection="Horizontal" ></asp:RadioButtonList>
        </div>
        <div class="col-sm-6">
            <asp:Button ID="btn_changeDate" runat="server" CssClass="btn btn-default" Text="Changer l'année" OnClick="btn_changeDate_Click" />
        </div>
        <div class="col-sm-2">
            <asp:Button ID="btn_modif" runat="server" CssClass="btn btn-primary right" OnClick="btn_modif_Click" Text="Modifier/Ajouter des membres" />
        </div>
    </div>

    <asp:DataList runat="server" ID="dataList_members" OnItemDataBound="dataList_members_ItemDataBound" Width="100%" RepeatLayout="Flow" CssClass="MiniTrombi row" ItemStyle-CssClass="col-sm-3">
        <ItemTemplate>
			<div class="panel panel-default">
				<div class="panel-body">
					<asp:Image ID="Image1" runat="server" />
					<div>
						<asp:Label ID="lbl_Fonction" runat="server" />
						<p><strong><asp:Label ID="LBL_Nom" Text='<%# Bind("name") %>' runat="server"></asp:Label> <asp:Label ID="LBL_NomFamille" Text='<%# Bind("surname") %>' runat="server"></asp:Label></strong></p>
						<p><asp:Label ID="LBL_Libelle" Text='<%# Bind("job") %>' runat="server"></asp:Label></p>
						<p><asp:Label ID="LBL_Club" Text='<%# Bind("club") %>' runat="server"></asp:Label></p>
						<p><small><asp:Label ID="lbl_description" Text='<%# Bind("description") %>' runat="server" ></asp:Label></small></p>
						<p><asp:HyperLink ID="HL_Contact" runat="server">Le contacter</asp:HyperLink></p>
					</div>
				</div>
			</div>
        </ItemTemplate>
    </asp:DataList>
    
</asp:Panel>

<asp:Panel ID="pnl_grid" Visible="false" runat="server">

    <asp:GridView ID="gvw_archi" CssClass="table table-stripped" runat="server" AutoGenerateColumns="false" OnRowCommand="gvw_archi_RowCommand">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lbl_rang" runat="server" Text='<%# Bind("rank") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nom">
                <ItemTemplate>
                    <asp:Label ID="lbl_prenom" runat="server" Text='<%# Bind("name") %>'></asp:Label> &nbsp <asp:Label ID="lbl_nom" runat="server" Text='<%# Bind("surname") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fonction">
                <ItemTemplate>
                    <asp:Label ID="lbl_fonction" runat="server" Text='<%# Bind("job") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lbt_edit" CssClass="btn btn-primary" CommandName="Editer" CommandArgument='<%# Bind("id") %>' runat="server"><span class="fa fa-pencil"></span></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lbt_delete" CssClass="btn btn-danger" OnClientClick="Javascript: return confirm('Voulez-vous vraiment supprimer ce membre de la liste ?');" CommandName="Deleter" CommandArgument='<%# Bind("id") %>' runat="server"><span class="fa fa-trash-o"></span></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Panel runat="server" ID="pnl_buttons">
        <div class="row">
        <asp:Button runat="server" ID="btn_back" OnClick="btn_back_Click" CssClass="btn btn-default right" Visible="true" Text="Retour" />
        <asp:Button runat="server" ID="btn_addDRYA" OnClick="btn_addDRYA_Click" CssClass="btn btn-primary right" Visible="true" Text="Ajouter un membre" />
    </div>
    </asp:Panel>
    

    <asp:Panel ID="pnl_edit" runat="server" Visible="false">
        <asp:HiddenField ID="hfd_id" runat="server" />
        <div class="row">
            <div class="col-sm-3">
                <strong>Nom</strong> : 
            </div>
            <div class="col-sm-9">
                <asp:Label runat="server" ID="lbl_nomEdit"></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-3">
                <strong>Fonction</strong> :
            </div>
            <div class="col-sm-9">
                <asp:DropDownList runat="server" ID="ddl_fonction"></asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-3">
                <strong>Description</strong> : 
            </div>
            <div class="col-sm-9">
                <asp:TextBox runat="server" ID="tbx_desc" TextMode="MultiLine" Width="400" Height="200"></asp:TextBox>
            </div>
        </div>
        
        
        
        <asp:LinkButton runat="server" ID="lbt_cancel" CssClass="btn btn-default" OnClick="lbt_cancel_Click">Annuler</asp:LinkButton>
        <asp:LinkButton runat="server" ID="lbt_apply" CssClass="btn btn-primary" OnClick="lbt_apply_Click">Appliquer les modifications</asp:LinkButton>
    </asp:Panel>

    <br />
    <asp:Panel ID="pnl_add" runat="server" Visible="false">
        <div class="row">
            <div class="col-sm-3">
                <p><strong>Rechercher</strong> : </p>
            </div>
            <div class="col-sm-3">
                <asp:TextBox ID="tbx_search" runat="server"></asp:TextBox>
            </div>
            <div class="col-sm-6">
                <asp:Button ID="btn_search" runat="server" OnClick="btn_search_Click" Text="Rechercher" CssClass="btn btn-default right" />
            </div>
        </div>
        <div class="row">
            <div class="col-sm-3">
                <p><strong>Nom</strong> : </p>
            </div>
            <div class="col-sm-5">
                <asp:DropDownList ID="ddl_name" runat="server" Visible="false"></asp:DropDownList>
            </div>
        </div>
        <br />
        <asp:Panel ID="pnl_postSearch" Visible="false" runat="server">
            <div class="row">
                <div class="col-sm-3">
                    <strong>Fonction</strong> :
                </div>
                <div class="col-sm-9">
                    <asp:DropDownList runat="server" ID="ddl_fonction2"></asp:DropDownList>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-sm-3">
                    <strong>Description</strong> : 
                </div>
                <div class="col-sm-9">
                    <asp:TextBox runat="server" ID="tbx_desc2" TextMode="MultiLine" Width="400" Height="200"></asp:TextBox>
                </div>
            </div>
             <div class="row">
                <div class="col-sm-3">
                    <strong>Rang</strong> : 
                </div>
                <div class="col-sm-9">
                    <asp:TextBox runat="server" ID="tbx_rank" ></asp:TextBox>
                </div>
            </div>
            
            <asp:Button runat="server" ID="btn_add" OnClick="btn_add_Click" CssClass="btn btn-primary right" Text="Ajouter" />
        </asp:Panel>
        <asp:Button runat="server" ID="btn_back2" OnClick="btn_back2_Click" CssClass="btn btn-default right" Text="Retour" />
    </asp:Panel>

</asp:Panel>

