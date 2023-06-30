<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Gestion Club.ascx.cs" Inherits="DesktopModules_AIS_Admin_Gestion_Club_Gestion_Club" %>
<script src="/AIS/TextEditor/ckeditor/ckeditor.js"></script>

<asp:Panel ID="pnl_display" runat="server">
    <asp:Label ID="lbl_nb" runat="server"></asp:Label>

    <asp:Button ID="btn_add" runat="server" CssClass="btn btn-primary right" Text="Ajouter un club" OnClick="btn_add_Click" />
      <div class="pe-spacer size10"></div>
    <asp:GridView ID="gvw_clubs" CssClass="table table-striped"  GridLines="None"  OnRowCommand="gvw_clubs_RowCommand" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:TemplateField HeaderText="Nom du club">
                <ItemTemplate>
                    <asp:Label ID="lbl_clubName" runat="server" Text='<%# Bind("name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Type">
                <ItemTemplate>
                    <asp:Label ID="lbl_club_type" runat="server" Text='<%# (""+Eval("club_type")).ToUpper() %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Rôle groupe">
                <ItemTemplate>
                    <asp:Label ID="lbl_role" runat="server" Text='<%# GetRoleName(""+Eval("roles")) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Présentation">
                <ItemTemplate>
                    <asp:Label ID="lbl_seo_mode" runat="server" Text='<%# GetPresentation(""+Eval("seo_mode")) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lbt_edit" runat="server" CommandArgument='<%# Bind("cric") %>' CssClass="btn btn-primary"><span class="fa fa-pencil"></span></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <%--<asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lbt_delete" runat="server" CommandArgument='<%# Bind("cric") %>' CssClass="btn btn-danger"><span class="fa fa-trash-o"></span></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>--%>
        </Columns>
    </asp:GridView>

</asp:Panel>

<asp:Panel ID="pnl_edit" runat="server" Visible="false">
    
      <div class="row">
        <div class="col-sm-4">
            <strong>Type club :</strong>
        </div>
        <div class="col-sm-8">
           <asp:RadioButtonList runat="server" ID="RB_Type_Club" RepeatDirection="Horizontal">
               <asp:ListItem Text="Rotary" Value="rotary"></asp:ListItem>
               <asp:ListItem Text="Rotaract" Value="rotaract"></asp:ListItem>
               <asp:ListItem Text="Interact" Value="interact"></asp:ListItem>
           </asp:RadioButtonList>
        </div>
    </div>  
    
    <div class="row">
        <div class="col-sm-4">
            <strong>CRIC :</strong>
        </div>
        <div class="col-sm-8">
            <asp:HiddenField ID="hf_last_cric" runat="server" />
            <asp:TextBox ID="hfd_cric" Width="500" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="hfd_cric" Text="Veuillez compléter" ForeColor="Red" Display="Dynamic">*</asp:RequiredFieldValidator>                    
        </div>
    </div>

    <div class="row">
        <div class="col-sm-4">
            <strong>Nom :</strong>
        </div>
        <div class="col-sm-8">
            <asp:TextBox ID="tbx_name" Width="500" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="tbx_name" Text="Veuillez compléter" ForeColor="Red" Display="Dynamic">*</asp:RequiredFieldValidator>                    
        </div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <strong>SEO :</strong>
        </div>
        <div class="col-sm-8">
            <asp:TextBox ID="tbx_seo" Width="500" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="tbx_name" Text="Veuillez compléter" ForeColor="Red" Display="Dynamic">*</asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <strong>Adresse 1 :</strong>
        </div>
        <div class="col-sm-8">
            <asp:TextBox ID="tbx_adr1" Width="500" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <strong>Adresse 2 :</strong>
        </div>
        <div class="col-sm-8">
            <asp:TextBox ID="tbx_adr2" Width="500" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <strong>Adresse 3 :</strong>
        </div>
        <div class="col-sm-8">
            <asp:TextBox ID="tbx_adr3" Width="500" runat="server"></asp:TextBox>
        </div>
    </div><div class="row">
        <div class="col-sm-4">
            <strong>Code postal : </strong>
        </div>
        <div class="col-sm-8">
            <asp:TextBox ID="tbx_zip" Width="500" runat="server"></asp:TextBox>
        </div>
    </div><div class="row">
        <div class="col-sm-4">
            <strong>Ville : </strong>
        </div>
        <div class="col-sm-8">
            <asp:TextBox ID="tbx_town" Width="500" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <strong>Fanion : </strong>
        </div>
        <div class="col-sm-8">
            <asp:HiddenField ID="hfd_filename" runat="server" />
            <asp:Image ID="img_fanion" runat="server" />
            <asp:FileUpload ID="ful_img" runat="server" />
            <asp:Button ID="btn_img" runat="server" OnClick="btn_img_Click" Text="Modifier le fanion" CssClass="btn btn-primary" />
        </div>
    </div>
   <div class="pe-spacer size10"></div>
    <div class="row">
        <div class="col-sm-4">
            <strong>Téléphone : </strong>
        </div>
        <div class="col-sm-8">
            <asp:TextBox ID="tbx_tel" Width="500" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <strong>Fax : </strong>
        </div>
        <div class="col-sm-8">
            <asp:TextBox ID="tbx_fax" Width="500" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <strong>Email : </strong>
        </div>
        <div class="col-sm-8">
            <asp:TextBox ID="tbx_email" Width="500" runat="server"></asp:TextBox>
        </div>
    </div>
     <div class="pe-spacer size10"></div>
    <div class="row">
        <div class="col-sm-4">
            <strong>Rôle de groupe de clubs : </strong>
        </div>
        <div class="col-sm-8">
             <asp:DropDownList runat="server" ID="DDL_Role" Width="500" CssClass="form-control"></asp:DropDownList>
        </div>
    </div>
    <div class="pe-spacer size10"></div>
    <div class="row">
        <div class="col-sm-4">
            <strong>Site web externe : </strong>
            <em>(incluant https://)</em>
        </div>
        <div class="col-sm-8">
            <asp:TextBox ID="tbx_web" Width="500" runat="server"></asp:TextBox>
        </div>
    </div>
     <div class="pe-spacer size10"></div>
    <fieldset>
        <legend><h3>Cotisation de district</h3></legend>
        <div class="row">
            <div class="col-sm-4">
                <strong>Méthode de paiement : </strong>
            </div>
            <div class="col-sm-8">
                  <asp:RadioButtonList ID="rbl_type" RepeatDirection="Horizontal" runat="server">
                      <asp:ListItem Text="Chèque" Value="Chèque"></asp:ListItem>
                      <asp:ListItem Text="Virement" Value="Virement"></asp:ListItem>
                      <asp:ListItem Text="Prélèvement" Value="Prélèvement"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
        </div>
         <div class="row">
            <div class="col-sm-4">
                <strong>Nb membres gratuits : </strong>
            </div>
            <div class="col-sm-8">
                <asp:TextBox ID="tbx_nb_free_of_charge" CssClass="form-control" TextMode="Number" Width="100" inputmode="decimal" min="0" step="0.01" runat="server"></asp:TextBox>
            </div>
        </div>
    </fieldset>
      <div class="pe-spacer size40"></div>
    <hr />
    <fieldset>
        <legend>Présentation du club sur le district :</legend>
   
    <div class="row">
        <div class="col-sm-4">
        </div>
        <div class="col-sm-8">
            <asp:RadioButtonList runat="server" ID="SEO_MODE" RepeatDirection="Vertical">
                <asp:ListItem Text="Carte de visite" Value=""></asp:ListItem>
                <asp:ListItem Text="Site" Value="m"></asp:ListItem>
                <asp:ListItem Text="Site avec domaine" Value="d"></asp:ListItem>
            </asp:RadioButtonList>
        </div>
    </div> 
    <div class="row">
        <div class="col-sm-4">  
        </div>
        <div class="col-sm-8">
            <asp:TextBox ID="tbx_domaine" Width="500" runat="server" placeholder="Saisir le nom de domaine du site"></asp:TextBox>
        </div>
    </div>
        <div class="row">
            <div class="col-sm-4">  
        </div>
              <div class="col-sm-8">
                         <em class="text-info">ATTENTION : le site avec domaine sur le district nécessite un paramétrage technique, contactez le webmaster pour en savoir plus</em>
     
                  </div>
            </div>
    <h3>Informations pour la carte de visite</h3>
    <div class="row">
        <div class="col-sm-4">
            <strong>Texte de présentation : </strong>
        </div>
        <div class="col-sm-8">
            <asp:TextBox ID="tbx_text" TextMode="MultiLine" Width="500" Height="300" runat="server"></asp:TextBox>
        </div>
        <script> CKEDITOR.replace('<%=tbx_text.ClientID%>', {
            uiColor: '#CCEAEE'
        });  </script>
    </div>
    <div class="pe-spacer size10"></div>
      <div class="row">
        <div class="col-sm-4">
            <strong>Réunions : </strong>
        </div>
        <div class="col-sm-8">
            <asp:TextBox ID="tbx_meetings" TextMode="MultiLine" Width="500" Height="300" runat="server"></asp:TextBox>
        </div>
        <script> CKEDITOR.replace('<%=tbx_meetings.ClientID%>', {
                uiColor: '#CCEAEE'
            });  </script>
    </div>
    
    <div class="pe-spacer size10"></div>
    <div class="row">
        <div class="col-sm-4">
            <strong>Adresse de réunion 1 : </strong>
        </div>
        <div class="col-sm-8">
            <asp:TextBox ID="tbx_meetAdr1" Width="500" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <strong>Adresse de réunion 2 : </strong>
        </div>
        <div class="col-sm-8">
            <asp:TextBox ID="tbx_meetAdr2" Width="500" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <strong>Ville de réunion : </strong>
        </div>
        <div class="col-sm-8">
            <asp:TextBox ID="tbx_meetTown" Width="500" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <strong>Code postal de réunion : </strong>
        </div>
        <div class="col-sm-8">
            <asp:TextBox ID="tbx_meetZip" Width="500" runat="server"></asp:TextBox>
        </div>
    </div>
    </fieldset>

   
    
    <div class="pe-spacer size40"></div>
    <div class="row">
        <div class="col-sm-4">
            <asp:Button ID="btn_delete" runat="server" OnClientClick="Javascript: return confirm('Voulez-vous vraiment supprimer ce club ?');" Text="Supprimer le club" Visible="false" CssClass="btn btn-danger" OnClick="btn_delete_Click" />
        </div>
        <div class="col-sm-8">
            <asp:Button ID="btn_addClub" runat="server" Text="Ajouter ou mettre à jour le club" CssClass="btn btn-primary" OnClick="btn_addClub_Click" />
            <asp:Button ID="btn_back" runat="server" Text="Retour" CssClass="btn btn-default" OnClick="btn_back_Click" />
        </div>
    </div>
    
</asp:Panel>
