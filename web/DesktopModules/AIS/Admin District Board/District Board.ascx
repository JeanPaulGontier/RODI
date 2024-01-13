<%@ Control Language="C#" AutoEventWireup="true" CodeFile="District Board.ascx.cs" Inherits="DesktopModules_AIS_Admin_District_Board_District_Board" %>

<asp:UpdatePanel runat="server">
    <ContentTemplate>

<asp:Panel ID="pnl_display" runat="server">
    <div class="panel-body">
        <div class="col-sm-3">
            <asp:DropDownList AutoPostBack="true" OnSelectedIndexChanged="ddl_section_SelectedIndexChanged" CssClass="form-control" ID="ddl_section"  runat="server"></asp:DropDownList>
        </div>
        <div class="col-sm-6">
            <span>Année rotarienne : <asp:RadioButtonList AutoPostBack="true" RepeatLayout="Flow" OnSelectedIndexChanged="rbl_rotaryYear_SelectedIndexChanged" ID="rbl_rotaryYear" runat="server" RepeatDirection="Horizontal" ></asp:RadioButtonList></span>
        </div>
        <div class="col-sm-3">
            
                <script>
                    function uploadForImport() {
                        if (document.getElementById('<%=FL_Import.ClientID%>').files.length > 0) {
                            theForm.submit();
                        }
                    }
                </script>
                <asp:FileUpload runat="server" id="FL_Import" style="display:none" AllowMultiple="false" onchange="uploadForImport()" />
                <p><button type="button" class="btn btn-xs btn-default" Text="Importer en Excel" onclick="document.getElementById('<%=FL_Import.ClientID%>').click()">Importer en Excel</button> &nbsp;     
                <asp:Button ID="BT_Export_XLS" runat="server" CssClass="btn btn-xs btn-default" Text="Exporter en Excel" OnClick="BT_Export_XLS_Click" /></p>
                <p><asp:Button ID="BT_Affectations_Roles" runat="server" CssClass="btn btn-xs btn-default" OnClick="BT_Affectations_Roles_Click" /></p>
            
        </div>
    </div>
    <asp:Panel runat="server" ID="P_Import" Visible="false"><asp:Literal runat="server" ID="TXT_Import"></asp:Literal></asp:Panel>
    
    <div class="alert alert-info text-center"><em>Si un rôle technique portant le même nom que la section existe, alors tous les membre de la section sont attribués à ce rôle lors de l'ajout ou du changement d'un membre, ou lors de l'import du fichier Excel (le rôle est attribué pour l'année rotarienne en cours)<br />Dans le fichier d'import, le nim est utilisé pour trouver le membre, dans le cas ou le nim est vide, la recherche est faite sur le prénom et le nom</em></div>
    
    <div class="panel-body">
        <asp:Label ID="lbl_noMember" runat="server">Il n'y a aucun membre dans cette section...</asp:Label>
        <div class="row">
            
            <div class="col-sm-12">
                <asp:Button ID="btn_modif" runat="server" CssClass="btn btn-primary right" OnClick="btn_modif_Click" Text="Modifier/Ajouter des membres" />
            </div>
        
        </div>

        <asp:DataList runat="server" ID="dataList_members" RepeatLayout="Flow" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="33%" Width="100%" ItemStyle-VerticalAlign="Top" RepeatColumns="3" RepeatDirection="Horizontal" OnItemDataBound="dataList_members_ItemDataBound">
            <ItemTemplate>
                 <div class="row" style="margin-left:10px; margin-right:10px; padding-left:10px; padding-right:10px;">
                    <h2><p><span><asp:Label ID="lbl_Fonction" ForeColor="White" runat="server" /></span></p></h2>
                    <div>
                        <p><span><asp:Image ID="Image1" runat="server" CssClass="img-ronde" /></span></p>
                        <p><span><strong><asp:Label ID="LBL_Nom" Text='<%# Bind("name") %>' runat="server"></asp:Label></strong></span>&nbsp<span><strong><asp:Label ID="LBL_NomFamille" Text='<%# Bind("surname") %>' runat="server"></asp:Label></strong></span></p>
                        <p><span><asp:Label ID="LBL_Libelle" Text='<%# Bind("job") %>' runat="server"></asp:Label></span></p>                                                
                        <p><span><asp:Label ID="lbl_description" Text='<%# Bind("description") %>' runat="server" ></asp:Label></span></p>
                        <p><span><asp:Label ID="LBL_Club" Text='<%# Bind("club") %>' runat="server"></asp:Label></span></p>
                        <p><span><asp:HyperLink ID="HL_Contact" runat="server">Le contacter</asp:HyperLink></span></p>
                    </div>
                </div>
            </ItemTemplate>
        </asp:DataList>
    </div>
</asp:Panel>

<asp:Panel ID="pnl_grid" CssClass="panel-body" Visible="false" runat="server">

    <asp:HiddenField ID="hfd_count" runat="server" />

    <asp:Panel runat="server" ID="pnl_buttons" CssClass="row" >
        <div class="col-sm-2">
            <asp:Button runat="server" ID="btn_back" OnClick="btn_back_Click" CssClass="btn btn-default left" Visible="true" Text="Retour" />
        </div>
        <div class="col-sm-7 text-center">
            <asp:Label runat="server" ID="lbl_section" CssClass="lead"></asp:Label>
        </div>
        <div class="col-sm-3">
            <asp:Button runat="server" ID="btn_addDRYA" OnClick="btn_addDRYA_Click" CssClass="btn btn-primary right" Visible="true" Text="Ajouter un membre" />
        </div>
    
    </asp:Panel>
    <div class="pe-spacer size10"></div>
    <asp:GridView ID="gvw_archi" CssClass="table table-striped" GridLines="None" runat="server" AutoGenerateColumns="false" OnRowCommand="gvw_archi_RowCommand">
        <Columns>
            <asp:TemplateField  ItemStyle-Width="10%">
                <ItemTemplate>
                    <asp:Label ID="lbl_rang" runat="server" Text='<%# Bind("rank") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField  ItemStyle-Width="30%" HeaderText="Nom">
                <ItemTemplate>
                    <asp:Label ID="lbl_prenom" runat="server" Text='<%# Bind("name") %>'></asp:Label> &nbsp <asp:Label ID="lbl_nom" runat="server" Text='<%# Bind("surname") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width="20%" HeaderText="Fonction">
                <ItemTemplate>
                    <asp:Label ID="lbl_fonction" runat="server" Text='<%# Bind("job") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width="20%" HeaderText="Rôle">
                <ItemTemplate>
                    <asp:Label ID="lbl_role" runat="server" Text='<%# Bind("role") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width="10%">
                <ItemTemplate>
                    <asp:LinkButton ID="lbt_up" CssClass="btn btn-default" CommandName="Up" CommandArgument='<%# Bind("id") %>' Visible='<%# int.Parse(""+Eval("rank"))>1 %>' runat="server"><span class="fa fa-arrow-up"></span></asp:LinkButton>
                    <asp:LinkButton ID="lbt_down" CssClass="btn btn-default" CommandName="Down" CommandArgument='<%# Bind("id") %>' Visible='<%# Container.DataItemIndex<int.Parse(hfd_count.Value)-1 %>'  runat="server"><span class="fa fa-arrow-down"></span></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width="5%">
                <ItemTemplate>
                    <asp:LinkButton ID="lbt_edit" CssClass="btn btn-primary" CommandName="Editer" CommandArgument='<%# Bind("id") %>' runat="server"><span class="fa fa-pencil"></span></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width="5%">
                <ItemTemplate>
                    <asp:LinkButton ID="lbt_delete" CssClass="btn btn-danger" OnClientClick="Javascript: return confirm('Voulez-vous vraiment supprimer ce membre de la liste ?');" CommandName="Delete" CommandArgument='<%# Bind("id") %>' runat="server"><span class="fa fa-trash-o"></span></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    
    

    <asp:Panel ID="pnl_edit" runat="server" Visible="false">
        <asp:HiddenField ID="hfd_id" runat="server" />
        <div class="row">
            <div class="col-sm-3">
                <strong>Nom</strong> : 
            </div>
            <div class="col-sm-9">
                <asp:TextBox runat="server" ID="lbl_nomEdit"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-3">
                <strong>Fonction rotarienne</strong> :
            </div>
            <div class="col-sm-9">
                 <asp:TextBox runat="server" ID="tbx_job" Width="100%"></asp:TextBox>
            </div>
        </div>
         <div class="row">
             <div class="col-sm-3">
                 <strong>Rôle technique</strong> :
             </div>
             <div class="col-sm-9">
                  <asp:TextBox runat="server" ID="tbx_role" Width="100%" ></asp:TextBox>
                 <asp:HiddenField runat="server" ID="tbx_previousrole" />
             </div>
         </div>
        <div class="row">
             
            <div class="col-sm-12 alert alert-info"><em>Le rôle technique est optionnel et permet d'attribuer le rôle du cms au membre (le rôle est attribué pour l'année rotarienne en cours)<br />Les rôles système et spécifiques au fonctionnement de RODI ne peuvent pas être attribués automatiquement.</em></div>
        </div>
        <div class="row">
            <div class="col-sm-3">
                <strong>Description</strong> : 
            </div>
            <div class="col-sm-9">
                <asp:TextBox runat="server" ID="tbx_desc" TextMode="MultiLine" Width="100%" Height="200"></asp:TextBox>
            </div>
        </div>
        
        
        <div class="row">
            <div class="col-md-11">
                <asp:Button runat="server" ID="lbt_apply" CssClass="btn btn-primary right" OnClick="lbt_apply_Click" Text="Appliquer les modifications"></asp:Button>
            </div>
            <div class="col-md-1">
                <asp:Button runat="server" ID="lbt_cancel" CssClass="btn btn-default" OnClick="lbt_cancel_Click" Text="Annuler"></asp:Button>
            </div>
        </div>
        
        
        

    </asp:Panel>

    <br />
    <asp:Panel ID="pnl_add" runat="server" Visible="false">
        <div class="row">
            <div class="col-sm-2">
                <p><strong>Membre</strong> : </p>
            </div>
            <div class="col-sm-6">
                <asp:TextBox ID="tbx_search" runat="server" Width="100%"></asp:TextBox>
            </div>
            <div class="col-sm-4">
                <asp:Button ID="btn_search" runat="server" OnClick="btn_search_Click" Text="Chercher" CssClass="btn btn-default" />
            </div>
        </div>
        <div class="row">
            <div class="col-sm-2">
                <p><strong><asp:Label id="lblNom" runat="server" Visible="false">Nom : </asp:Label></strong></p>
            </div>
            <div class="col-sm-10">
                <asp:DropDownList ID="ddl_name" runat="server" Visible="false" Width="100%"></asp:DropDownList>
            </div>
        </div>
        <br />
        <asp:Panel ID="pnl_postSearch" Visible="false" runat="server">
            <div class="row">
                <div class="col-sm-2">
                    <strong>Fonction</strong> :
                </div>
                <div class="col-sm-10">
                    <asp:TextBox ID="tbx_job2" runat="server" Width="100%"></asp:TextBox>
                </div>
            </div>
             <div class="row">
                 <div class="col-sm-2">
                     <strong>Rôle</strong> :
                 </div>
                 <div class="col-sm-10">
                     <asp:TextBox ID="tbx_role2" runat="server" Width="100%"></asp:TextBox>
                 </div>
             </div>
            <br />
            <div class="row">
                <div class="col-sm-2">
                    <strong>Description</strong> : 
                </div>
                <div class="col-sm-10">
                    <asp:TextBox runat="server" ID="tbx_desc2" TextMode="MultiLine" Width="100%" Height="200"></asp:TextBox>
                </div>
            </div>
             <div class="row" style="display:none">
                <div class="col-sm-2">
                    <strong>Rang</strong> : 
                </div>
                <div class="col-sm-10">
                    <asp:TextBox runat="server" ID="tbx_rank" ></asp:TextBox>
                </div>
            </div>
            
            
            
        </asp:Panel>

        <div class="row">
            <div class="col-md-11">
                <asp:Button runat="server" ID="btn_add" OnClick="btn_add_Click" CssClass="btn btn-primary right" Text="Ajouter" Visible="false" />
            </div>
            <div class="col-md-1">
                <asp:Button runat="server" ID="btn_back2" OnClick="btn_back2_Click" CssClass="btn btn-default right" Text="Annuler" />
            </div>
        </div>
        
        
    </asp:Panel>

</asp:Panel>







</ContentTemplate>
</asp:UpdatePanel>