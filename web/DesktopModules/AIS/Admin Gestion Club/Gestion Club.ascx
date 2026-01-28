<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Gestion Club.ascx.cs" Inherits="DesktopModules_AIS_Admin_Gestion_Club_Gestion_Club" %>
<script src="/AIS/TextEditor/ckeditor/ckeditor.js"></script>
 <style>
    input[type=file]::-webkit-file-upload-button {
        color: #ffffff;
        border: none;
        cursor: pointer;            
        background-image: linear-gradient(to right,#428bca,#428bca);
        border-color: #357edb;
        border-radius: 4px;
           
        font-size: 12px;
        padding: 6px 12px;
        user-select: none;
        white-space: nowrap;
    }
</style>
<asp:Panel ID="pnl_display" runat="server">
    <asp:Label ID="lbl_nb" runat="server"></asp:Label>

    <asp:Button ID="btn_add" runat="server" CssClass="btn btn-primary right" Text="Ajouter un club" OnClick="btn_add_Click" />
      <div class="pe-spacer size10"></div>
    <asp:GridView ID="gvw_clubs" CssClass="table table-striped"  GridLines="None"  OnRowCommand="gvw_clubs_RowCommand" runat="server" AutoGenerateColumns="false">
        <Columns>
             <asp:TemplateField HeaderText="">
                <ItemTemplate>
                 <%# DataBinder.Eval(Container.DataItem, "IsSatellite").Equals(true)?"<img src='"+ PortalSettings.ActiveTab.SkinPath +"images/satellite.png' Width=16 title='Club satellite du club "+ClubParent(Container.DataItem)+"' />":"" %>
                </ItemTemplate>
            </asp:TemplateField>
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
                    <asp:HyperLink ID="lbl_seo_mode" runat="server" Text='<%# GetPresentation(""+Eval("seo_mode")) %>' NavigateUrl='<%# "/"+Eval("seo") %>' Target="_blank" ToolTip="Voir le site"></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Synchro RI">
                <ItemTemplate>
                    <asp:Label ID="lbl_synchro_ri" runat="server" Text='<%# GetSynchroRI(Container) %>'></asp:Label>
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

    <asp:Panel runat="server" ID="P_satellite" Visible="false">
        <div class="alert alert-info">
            <asp:Label runat="server" ID="P_satellite_lalel"></asp:Label>
        </div>
    </asp:Panel>
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
             <strong>Latitude : </strong>
         </div>
         <div class="col-sm-8">
             <asp:TextBox ID="tbx_latitude" Width="500" runat="server" ></asp:TextBox>
         </div>
     </div>
      <div class="row">
         <div class="col-sm-4">
             <strong>Longitude : </strong>
         </div>
         <div class="col-sm-8">
             <asp:TextBox ID="tbx_longitude" Width="500" runat="server"></asp:TextBox>
         </div>
     </div>
      <div class="row">
        <div class="col-sm-4">
    
        </div>
        <div class="col-sm-8">
            <asp:LinkButton runat="server" ID="bt_autolocate" Text="Déterminer à partir de l'adresse" OnClick="bt_autolocate_Click"></asp:LinkButton>
        </div>
    </div>
     <div class="pe-spacer size40"></div>
    <hr />
    <div class="row">
        <div class="col-sm-4">
            <strong>Fanion : </strong>
        </div>
        <div class="col-sm-4">      
            <asp:Image ID="img_fanion" runat="server" />
            <asp:FileUpload ID="ful_img" runat="server" onchange="OnClientPhotoUploaded2(this, this.files[0])" accept=".png, .jpeg, .jpg"/>
            <div style="display: none">
                <asp:Button ID="btn_img" runat="server" OnClick="btn_img_Click" Text="Modifier le fanion" CssClass="btn btn-primary" />
                <script>function OnClientPhotoUploaded2(sender, args) { var bt = document.getElementById('<%=btn_img.ClientID %>'); bt.click(); }</script>
            </div>
            <asp:HiddenField ID="hfd_filename" runat="server" />
            <div class="pe-spacer size10"></div>
            <asp:Button runat="server"  CssClass="btn btn-xs btn-danger" ID="BT_Effacer_Fanion" Text="Supprimer le fanion" CausesValidation="false" OnClick="BT_Effacer_Fanion_Click" />
      
      </div>
      <div class="col-sm-4">
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
      <legend><h3>Synchronisation Rotary International > RODI</h3></legend>
        <asp:Panel runat="server" ID="p_synchro_ri_parent">
            <div class="alert alert-info">
               <strong>La synchronisation du club est gérée pas le club parent</strong>
           </div>
        </asp:Panel>
       <asp:Panel runat="server" ID="p_synchro_ri_na">
           <div class="alert alert-warning">
              <strong>La synchronisation du club n'a pas été autorisée sur my Rotary</strong>
          </div>
       </asp:Panel>
       <asp:Panel runat="server" ID="p_synchro_ri" class="row">
           <div class="col-sm-4">
               <strong>Synchronisation : </strong>
           </div>
           <div class="col-sm-8">
               <asp:RadioButtonList runat="server" ID="RB_synchroRI" RepeatDirection="Vertical">
                  <asp:ListItem Text="Non" Value=""></asp:ListItem>
                  <asp:ListItem Text="Analyse" Value="analyse"></asp:ListItem>
                  <asp:ListItem Text="Automatique" Value="auto"></asp:ListItem>
              </asp:RadioButtonList>
           </div>
       </asp:Panel>
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
                <asp:ListItem Text="Site district" Value="m"></asp:ListItem>
                <asp:ListItem Text="Site district avec nom de domaine" Value="d" Enabled="false"></asp:ListItem>
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
                  <em class="text-warning">ATTENTION : pour activer le site district avec nom de domaine contactez le support technique (<a href="<%=AIS.Const.RODI_SUPPORT_EMAIL %>"><%=AIS.Const.RODI_SUPPORT_EMAIL %></a>)</em>     
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
