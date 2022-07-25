<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2016                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Architecture.ascx.cs" Inherits="DesktopModules_AIS_Admin_DRYA_DRYA" %>


    <asp:Label ID="test" runat="server" />

<asp:Panel ID="pnl_domaine" runat="server" CssClass="left">
    

</asp:Panel>

<asp:Panel ID="pnl_contenu" CssClass="right" runat="server">
    <h1><asp:Label ID="lbl_titreDL" runat="server" /></h1>
<asp:RadioButtonList ID="rbl_anneeRot" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rbl_anneeRot_SelectedIndexChanged" AutoPostBack="true">
    <asp:ListItem ID="rbt_anneeCourante" runat="server" Selected="True" />
    <asp:ListItem ID="rbt_anneePlusUn" runat="server" />
    <asp:ListItem ID="rbt_anneePlusDeux" runat="server" />
</asp:RadioButtonList>

<asp:Label id="lbl_anneeRot" runat="server" Visible="false" />

     <asp:Button ID="btn_ajoutModifMember" Text="Ajouter/Modifier des membres" runat="server" CssClass="spacing bottom right" OnClick="btn_modifier_Click"/>
    <br />
    <br />
    <br />
    <br />
    <asp:Label ID="lbl_cache" runat="server" Visible="false"/>
    
    <asp:DataList ID="dl_gouv" Visible="false" ItemStyle-Width="50%" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" OnItemDataBound="dl_gouv_ItemDataBound">
        <ItemTemplate>
            <div class="UneColonne Marron Trombi">
                <h2><p><span><asp:Label ID="lbl_Fonction" runat="server" ForeColor="white" /></span></p></h2>
                <div class="DNNModuleContent ModAISMemberC">
                    <p><span><asp:Image ID="Image1" runat="server" /></span></p>
                    <p><span><strong><asp:Label ID="LBL_Nom" runat="server"></asp:Label></strong></span></p>
                    <p><span><asp:Label ID="LBL_Libelle" runat="server"></asp:Label></span></p>
                    <p><span><asp:Label ID="lbl_description" runat="server" ></asp:Label></span></p>
                    <p><span><asp:Label ID="LBL_Club" runat="server"></asp:Label></span></p>
                    <p><span><asp:HyperLink ID="HL_Contact" runat="server">Le contacter</asp:HyperLink></span></p>
                </div>
            </div>
        </ItemTemplate>       
    </asp:DataList>

    <asp:DataList ID="dl_bureau" Visible="false" ItemStyle-Width="33%" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" OnItemDataBound="dl_bureau_ItemDataBound">
        <ItemTemplate>
            <div class="UneColonne Marron Trombi">
                <h2><p><span><asp:Label ID="lbl_Fonction" ForeColor="White" runat="server" /></span></p></h2>
                <div class="DNNModuleContent ModAISMemberC">
                    <p><span><asp:Image ID="Image1" runat="server" /></span></p>
                    <p><span><strong><asp:Label ID="LBL_Nom" runat="server"></asp:Label></strong></span></p>
                    <p><span><asp:Label ID="LBL_Libelle" runat="server"></asp:Label></span></p>
                    
                    <p><span><asp:Label ID="lbl_description" runat="server" ></asp:Label></span></p>
                    <p><span><asp:Label ID="LBL_Club" runat="server"></asp:Label></span></p>
                    <p><span><asp:HyperLink ID="HL_Contact" runat="server">Le contacter</asp:HyperLink></span></p>
                </div>
            </div>
        </ItemTemplate>
    </asp:DataList>

    <asp:DataList ID="dl_fondation" Visible="false" runat="server" ItemStyle-Width="33%" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" RepeatColumns="2" RepeatDirection="Horizontal" OnItemDataBound="dl_fondation_ItemDataBound">
        <ItemTemplate>
            <div class="UneColonne Marron Trombi">
                <h2><p><span><asp:Label ID="lbl_Fonction" ForeColor="White" runat="server" /></span></p></h2>
                <div class="DNNModuleContent ModAISMemberC">
                    <p><span><asp:Image ID="Image1" runat="server" /></span></p>
                    <p><span><strong><asp:Label ID="LBL_Nom" runat="server"></asp:Label></strong></span></p>
                    <p><span><asp:Label ID="LBL_Libelle" runat="server"></asp:Label></span></p>
                    <p><span><asp:Label ID="lbl_description" runat="server" ></asp:Label></span></p>
                    <p><span><asp:Label ID="LBL_Club" runat="server"></asp:Label></span></p>
                    <p><span><asp:HyperLink ID="HL_Contact" runat="server">Le contacter</asp:HyperLink></span></p>
                </div>
            </div>
        </ItemTemplate>
    </asp:DataList>

    <asp:DataList ID="dl_amMonaco" Visible="false" runat="server" ItemStyle-Width="33%" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" RepeatColumns="2" RepeatDirection="Horizontal" OnItemDataBound="dl_amMonaco_ItemDataBound">
        <ItemTemplate>
            <div class="UneColonne Marron Trombi">
                <h2><p><span><asp:Label ID="lbl_Fonction" ForeColor="White" runat="server" /></span></p></h2>
                <div class="DNNModuleContent ModAISMemberC">
                    <p><span><asp:Image ID="Image1" runat="server" /></span></p>
                    <p><span><strong><asp:Label ID="LBL_Nom" runat="server"></asp:Label></strong></span></p>
                    <p><span><asp:Label ID="LBL_Libelle" runat="server"></asp:Label></span></p>
                    <p><span><asp:Label ID="lbl_description" runat="server" ></asp:Label></span></p>
                    <p><span><asp:Label ID="LBL_Club" runat="server"></asp:Label></span></p>
                    <p><span><asp:HyperLink ID="HL_Contact" runat="server">Le contacter</asp:HyperLink></span></p>
                </div>
            </div>
        </ItemTemplate>
        
    </asp:DataList>

    <asp:DataList ID="dl_Corse" Visible="false" runat="server" ItemStyle-Width="33%" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" RepeatColumns="2" RepeatDirection="Horizontal" OnItemDataBound="dl_Corse_ItemDataBound">
        <ItemTemplate>
            <div class="UneColonne Marron Trombi">
                <h2><p><span><asp:Label ID="lbl_Fonction" ForeColor="White" runat="server" /></span></p></h2>
                <div class="DNNModuleContent ModAISMemberC">
                    <p><span><asp:Image ID="Image1" runat="server" /></span></p>
                    <p><span><strong><asp:Label ID="LBL_Nom" runat="server"></asp:Label></strong></span></p>
                    <p><span><asp:Label ID="LBL_Libelle" runat="server"></asp:Label></span></p>
                    <p><span><asp:Label ID="lbl_description" runat="server" ></asp:Label></span></p>
                    <p><span><asp:Label ID="LBL_Club" runat="server"></asp:Label></span></p>
                    <p><span><asp:HyperLink ID="HL_Contact" runat="server">Le contacter</asp:HyperLink></span></p>
                </div>
            </div>
        </ItemTemplate>
    </asp:DataList>

    <asp:DataList ID="dl_Var" Visible="false" runat="server" ItemStyle-Width="33%" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" RepeatColumns="2" RepeatDirection="Horizontal"  OnItemDataBound="dl_Var_ItemDataBound">
        <ItemTemplate>
            <div class="UneColonne Marron Trombi">
                <h2><p><span><asp:Label ID="lbl_Fonction" ForeColor="White" runat="server" /></span></p></h2>
                <div class="DNNModuleContent ModAISMemberC">
                    <p><span><asp:Image ID="Image1" runat="server" /></span></p>
                    <p><span><strong><asp:Label ID="LBL_Nom" runat="server"></asp:Label></strong></span></p>
                    <p><span><asp:Label ID="LBL_Libelle" runat="server"></asp:Label></span></p>
                    <p><span><asp:Label ID="lbl_description" runat="server" ></asp:Label></span></p>
                    <p><span><asp:Label ID="LBL_Club" runat="server"></asp:Label></span></p>
                    <p><span><asp:HyperLink ID="HL_Contact" runat="server">Le contacter</asp:HyperLink></span></p>
                </div>
            </div>
        </ItemTemplate>
    </asp:DataList>

    <asp:Panel ID="pnl_commission" runat="server" >
        <asp:Image Visible="false" ID="img_commision" runat="server" ImageUrl="/portals/0/District/Images/2014-2015/Commission1-b.jpg" />
        <asp:Button ID="btn_commissionAjout" runat="server" OnClick="btn_commissionAjout_Click" Text="Ajouter / Modifier commission" />
    </asp:Panel>
    

    <h1> <asp:Label ID="lbl_pres" Text="Les présidents des clubs" runat="server" Visible="false"/></h1>
    <asp:DataList ID="dl_presidents" Visible="false" runat="server" ItemStyle-Width="33%" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" RepeatColumns="2" RepeatDirection="Horizontal" OnItemDataBound="dl_presidents_ItemDataBound">
        <ItemTemplate>
            <p><asp:Image ID="Image1" runat="server" /></p>
            <p><strong><asp:Label ID="LBL_Nom" runat="server"></asp:Label></strong></p>
            <p><asp:Label ID="LBL_Libelle" runat="server"></asp:Label></p>
            <p><u><asp:Label ID="lbl_Fonction" runat="server" /></u></p>
            <p><span><asp:Label ID="lbl_description" runat="server" ></asp:Label></span></p>
            <p><asp:Label ID="LBL_Club" runat="server"></asp:Label></p>
            <p><asp:HyperLink ID="HL_Contact" runat="server">Le contacter</asp:HyperLink></p>
        </ItemTemplate>
    </asp:DataList>

    <asp:Label ID="lbl_dlVide" Text="Aucune entrée pour cette année rotarienne" runat="server" Visible="false"/>   
</asp:Panel>

<asp:Panel ID="pnl_modif" CssClass="right" runat="server" Visible="false">
    
    <asp:GridView CssClass="tableDefault spacingTop" OnRowCommand="gvw_modification_RowCommand" ID="gvw_modification" runat="server" AllowPaging="false" AutoGenerateColumns="false" OnRowDataBound="gvw_modification_RowDataBound">

        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lbl_rang" runat="server" Text='<%#Eval ("rank") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nom">
                <ItemTemplate>
                    <asp:Label ID="lbl_nomGrid" runat="server" />
                    <asp:HiddenField ID="hfd_nimGrid" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fonction">
                <ItemTemplate>
                    <asp:Label ID="lbl_fonctGrid" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button id="btn_modifier" CommandArgument='<%#Eval("name") + " " + Eval ("surname") %>' Text="Modifier" runat="server" CommandName='<%#Eval ("id") %>' OnClick="btn_modifier_Click1"/>
                    <asp:Button ID="btn_supprimer" runat="server" Text="Supprimer" OnClick="btn_supprimer_Click" CommandName='<%#Eval ("id") %>' CommandArgument='<%#Eval("name")+ " " + Eval("surname")  %>'/>
                </ItemTemplate>
            </asp:TemplateField> 

        </Columns>

        <EmptyDataTemplate>Aucune donnée saisie</EmptyDataTemplate>
    </asp:GridView>
    <asp:Button ID="btn_ajouter" runat="server" Text="Ajouter un membre" CssClass="right" OnClick="btn_ajouter_Click" />
    <br />
    <br />
    <br />
    <asp:Button ID="btn_redirect" CssClass="right" runat="server" Text="Modifier l'arborescence" OnClick="btn_redirect_Click" Visible="true" />
    <br />
    <br />
    <br />

    <asp:Panel ID="pnl_ddl" runat="server" Visible="false">
        <asp:Label runat="server" ID="lbl_nomDDL" Width="100" Text="Nom : " />
        <asp:HiddenField ID="hfd_nim" runat="server" />
        <asp:HiddenField ID="hfd_id" runat="server" />
        <a name="ancre_supp" ></a>
        <b><asp:Label ID="lbl_supp" runat="server" Text ="Voulez-vous supprimer cet utilisateur? " Visible="false" /></b>
        <asp:Label ID="lbl_nomModif" runat="server" />
        <asp:TextBox ID="tbx_search" runat="server" Visible="false" />
        <asp:Button ID="btn_search" runat="server" Text="Rechercher" OnClick="btn_search_Click" Visible="false"/>
        <asp:DropDownList ID="ddl_ajoutNom" Width="150" runat="server" Visible="false"/>
       
        <asp:DropDownList ID="ddl_nim" runat="server" Visible="false" />
        <asp:Label ID="lbl_fonctionModif" runat="server" Text="Fonction : " Visible="false"/>
        <asp:DropDownList runat="server" ID="ddl_fonctModif" Visible="false" />
        <br />
        <asp:Label ID="lbl_desc" Width="100" runat="server" Text="Description : " Visible="false" />
        <asp:TextBox TextMode="MultiLine" ID="tbx_desc" runat="server" Width="300" Height="100" Visible="false" />
        <asp:Label runat="server" ID="lbl_rangModif" Visible="false" Text="Rang : "/>
        <asp:TextBox runat="server" ID="tbx_rangModif" Visible="false" Width="50" />
         <asp:Label ID="lbl_vide" runat="server" Visible="false" Text="Aucun membre correspondant" />
        <br />
        <asp:Button ID="btn_Valider" runat="server" Text="Modifier" OnClick="btn_Valider_Click" CssClass="right" Visible="false" />
        <asp:Button ID="btn_annuler" runat="server" Text="Annuler" OnClick="btn_annuler_Click" CssClass="right" Visible="false" />
        
        <br />
        
    </asp:Panel>


    <br />
    <br />
    <br />
    

    <asp:Button ID="btn_retour" Text="Retour" CssClass="right" runat="server" OnClick="btn_retour_Click" />


</asp:Panel>

<asp:Panel ID="pnl_comModif" runat="server" Visible="false">
    <asp:DropDownList ID="ddl_commission" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddl_commission_SelectedIndexChanged" />
    <h2><asp:Label ID="lbl_titreCom" runat="server" Visible="false" /></h2>
    <asp:TextBox ID="tbx_newCom" runat="server" Visible="false" />
    <asp:TextBox ID="tbx_newFonct" runat="server" Visible="false" />
    <asp:TextBox ID="tbx_newMember" runat="server" Visible="false" />
    <asp:TextBox ID="tbx_modifFonc" runat="server" Visible="false" />
    <asp:TextBox ID="tbx_modifMember" runat="server" Visible="false" />
    <asp:TextBox ID="tbx_modifNomCom" runat="server" Visible="false" />
    <asp:Label ID="lbl_erreurCom" runat="server" Visible="false"/>
    <asp:Label ID="lbl_validationAjout" runat="server" Visible="false" />
    
    
    <asp:Gridview ID="gvw_commission" runat="server" AutoGenerateColumns="false" OnRowCommand="gvw_commission_RowCommand">

        <Columns>
            <asp:TemplateField HeaderText="Fonction">
                <ItemTemplate>
                    <asp:Label ID="tbx_fonction" AutoPostBack="true" Text='<%#Eval ("job") %>' Width="200" runat="server"></asp:Label>
                </ItemTemplate>
             </asp:TemplateField>

            <asp:TemplateField HeaderText="Nom du membre">
                <ItemTemplate>
                    <asp:Label ID="tbx_nomMember" AutoPostBack="true" Text='<%#Eval ("memberName") %>' Width="250" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField >
                <ItemTemplate>
                    <asp:Button ID="btn_modifCom" runat="server" OnClick="btn_modifCom_Click" Text="Modifier" CommandArgument='<%#Eval ("job") + "_" + Eval("memberName")%>' CommandName='<%#Eval ("id") %>' />
                    <asp:Button ID="btn_supprLigneCom" runat="server" OnClick="btn_supprLigneCom_Click" Text="Supprimer" CommandName='<%#Eval ("id") %>' CommandArgument='<%#Eval ("job") + "_" + Eval("memberName")%>'/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:Gridview>

    
    <asp:Button ID="btn_ajoutNewCom" runat="server" Text="Ajouter une nouvelle commission" OnClick="btn_ajoutNewCom_Click" Visible="false"/>
    <asp:Button ID="btn_ajoutLigne" runat="server" Text="Ajouter une ligne" OnClick="btn_ajoutLigne_Click" Visible="false"/>
    <br />
    <asp:Button ID="btn_modifNomCom" runat="server" Text="Modifier le nom de cette commission" OnClick="btn_modifNomCom_Click" Visible="false" />
    <b><asp:Label ID="lbl_confirmSupp" Text="Êtes-vous sûr de supprimer cette ligne : " runat="server" Visible="false" /></b>
    <asp:Label ID="lbl_membreFonction" runat="server" Visible="false" />
    <asp:Button ID="btn_suppCom" runat="server" Text="Supprimer cette commission" Visible="false" OnClick="btn_suppCom_Click" />
    <asp:Button ID="btn_validerCom" runat="server" Text="Valider" OnClick="btn_validerCom_Click" Visible="false"/>
    <asp:Button ID="btn_retourCom" runat="server" Text="Retour" OnClick="btn_retourCom_Click" />

    <asp:HiddenField ID="hfd_idCom" runat="server" />

</asp:Panel>
