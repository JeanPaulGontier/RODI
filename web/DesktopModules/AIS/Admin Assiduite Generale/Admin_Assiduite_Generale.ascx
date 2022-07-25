<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2016                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Admin_Assiduite_Generale.ascx.cs" Inherits="DesktopModules_AIS_Admin_General_Attendance_Admin_General_Attendance" %>


        
<asp:Panel ID="pnl_Reglages" runat="server">

    <asp:Label ID="lbl_mois" runat="server" Text="Choisir un mois : " />
    <asp:DropDownList ID="ddl_mois" runat="server" AutoPostBack="false" />
    <asp:Label ID="lbl_annee" runat="server" Text="et une année : " />
    <asp:TextBox ID="tbx_annee" runat="server" AutoPostBack="false" />
    <asp:RangeValidator ID="rvr_annee" runat="server" ControlToValidate="tbx_annee" ErrorMessage="Entrez une année entre 1990 et 2100" MinimumValue=1990 MaximumValue=2100 Type="Integer" ValidationGroup="vsy_date"/>
    <asp:ValidationSummary ID="vsy_date" runat="server" DisplayMode="BulletList"/>
    <asp:Button CssClass="btn btn-primary right" ID="btn_valider" runat="server" OnClick="btn_valider_Click" Text="Valider" ValidationGroup="vsy_date" CausesValidation="true" />
</asp:Panel>
<div class="pe-spacer size20"></div>
 <asp:Panel ID="pnl_grid" runat="server" >

      <asp:Label ID="test" runat="server"/>

     
    <asp:GridView id="gvw_assiduite" runat="server" EnableSortingAndPagingCallbacks="false" CssClass="table table-striped"
         AllowSorting="true"
         AllowPaging="false"
         AutoGenerateColumns="false"
         DataKeyNames="id"
         AutoGenerateSelectButton="false"
         OnRowDataBound="gvw_assiduite_RowDataBound">

        <Columns>
            <asp:TemplateField HeaderText="Club">
                <ItemTemplate>
                    <asp:Label ID="lbl_club" runat="server" Text='<%#Eval ("name") %>'/>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Effectif à cette date">
                <ItemStyle Width="100"  />
                <ItemTemplate>
                    <asp:Label ID="lbl_effectif" runat="server" Text='<%#Eval ("nbm") %>' width="50" CssClass="right"/>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Variation">
                <ItemTemplate>
                    <asp:Label ID="lbl_variation" runat="server" Text='<%#Eval ("varEff") %>' CssClass="right"/>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <ItemStyle Width="100"  />
                <ItemTemplate>
                    <asp:Label ID="lbl_moyenne" runat="server" Text='<%#Eval ("purcent") %>' Width="50" CssClass="right"/>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Variation Assiduité" >
                <ItemStyle Width="20" />
                <ItemTemplate>
                    <asp:Label ID="lbl_varAss" runat="server" Text='<%#Eval ("purcentPastYear") %>' />
                    <asp:Image ID="img_hausse" runat="server" ImageUrl="~/DesktopModules/Admin/Tabs/images/Icon_Up.png" Visible="false"/>
                    <asp:Image ID="img_baisse" runat="server" ImageUrl="~/DesktopModules/Admin/Tabs/images/Icon_Down.png" Visible="false"/>
                    <asp:Label ID="lbl_stagn" runat="server" Text="=" Visible="false"/>
                </ItemTemplate>
            </asp:TemplateField> 
        </Columns>
        
        
        
        <EmptyDataTemplate>Aucune assiduité saisie à cette date</EmptyDataTemplate>

    </asp:GridView>
    <asp:HiddenField ID="hfImageData" runat="server" />

     <asp:Label ID="lbl_hidden" runat="server" Visible="false"/>
     <asp:Label ID="lbl_assMoyenne" runat="server" Visible="false"/>
</asp:Panel>

<asp:Panel ID="pnl_export" runat="server">
    
    <br />
    <asp:CheckBox ID="cbx_tailleImg" runat="server" Text="Modifier la hauteur" OnCheckedChanged="cbx_tailleImg_CheckedChanged" AutoPostBack="true" />
    <br />
    <asp:Label Text="Largeur de l'image : " runat="server" />
    <asp:TextBox ID="tbx_tailleImg" Text="700" AutoPostBack="false" runat="server" OnTextChanged="tbx_tailleImg_TextChanged" />
    <asp:Label ID="lbl_tailleImg" runat="server" Visible="false" />
    <asp:RangeValidator ID="rvr_tailleImg" Display="none" runat="server" ValidationGroup="vgp_tailleImg" ControlToValidate="tbx_tailleImg" ErrorMessage="Entrez une largeur entière comprise entre 200 et 2000" MinimumValue=200 MaximumValue=2000 Type="Integer" />
    <asp:RequiredFieldValidator ID="rfv_tailleImg" Display="None" ControlToValidate="tbx_tailleImg" ValidationGroup="vgp_tailleImg" runat="server" ErrorMessage="Veuillez entrer une largeur d'image" />
    <asp:Label ID="lbl_erreurTailleImg" runat="server" Visible="false" />
    <br />
    <asp:Label Text="Hauteur de l'image : " runat="server" />
    <asp:Label ID="lbl_hautImg" runat="server" />
    <asp:TextBox ID="tbx_hautImg" runat="server" AutoPostBack="false" OnTextChanged="tbx_hautImg_TextChanged" Visible="false"/>
<%--    <asp:RangeValidator ID="rvr_hautImg" runat="server" Display="None" ValidationGroup="vgp_tailleImg" ControlToValidate="tbx_hautImg" ErrorMessage="Entrez une hauteur entière entre 100 et 1000" MinimumValue="100" MaximumValue="1000" Type="Integer" />--%>
    <asp:RequiredFieldValidator ID="rfv_hautImg" runat="server" Display="None" ValidationGroup="vgp_tailleImg" ControlToValidate="tbx_hautImg" ErrorMessage="Veuillez entrer une hauteur" />
    <asp:ValidationSummary ID="vsy_hautImg" ValidationGroup="vgp_tailleImg" runat="server" DisplayMode="SingleParagraph" /> 
    <br />
    <asp:Button ID="btnExport" ValidationGroup="vgp_tailleImg" CausesValidation="true" CssClass="btn btn-primary right" Text="Export to Image" runat="server" UseSubmitBehavior="true" OnClick="ExportToImage" />
    <br />
    <br />
    <br />
    <asp:Button ID="btn_export_excel" Text="Exporter en Excel" runat="server" OnClick="btn_export_excel_Click" CssClass="btn btn-primary right"/>
</asp:Panel>

<asp:GridView ID="GridViewExport" runat="server" AutoGenerateColumns="False" Visible="false" >
<Columns>
     <asp:BoundField DataField="nom" HeaderText="Nom" />
    <asp:BoundField DataField="nbm" HeaderText="Nombre de membres" />
    <asp:BoundField DataField="varEff" HeaderText="Var. effectif" />
    <asp:BoundField DataField="purcent" HeaderText="Pourcentage d'assiduité" /> 
    <asp:BoundField DataField="varAss" HeaderText="Var. assiduité" /> 
</Columns>    
</asp:GridView>