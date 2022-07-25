<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2016                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Admin Arborescence.ascx.cs" Inherits="DesktopModules_AIS_Admin_Arborescence_Admin_Arborescence" %>



<div>
<asp:Panel ID="pnl_arbo" runat="server" CssClass="right" Visible="false">

    <br />
    <br />
    <br />
    <br />
    <br />
    
    <asp:ImageButton ID="ibt_bottom" runat="server" ImageUrl="~/images/bottom-icn.png" CssClass="right" OnClick="ibt_bottom_Click" />
    <asp:ImageButton ID="ibt_top" runat="server" ImageUrl="~/images/top-icn.png" CssClass="right" OnClick="ibt_top_Click" />
    <asp:ImageButton ID="ibt_down" runat="server" ImageUrl="~/images/down-icn.png" CssClass="right" OnClick="ibt_down_Click" />
    <asp:ImageButton ID="ibt_up" runat="server" ImageUrl="~/images/up-icn.png" CssClass="right" OnClick="ibt_up_Click" />
    <br />
    <b><asp:Label ID="lbl_nom" runat="server" Text="Nom : " Width="50"/></b>
    <asp:Label ID="tbx_nom" runat="server" />
    <br />
    <b><asp:Label ID="lbl_nim" runat="server" Text="Nim : " Width="50"/></b>
    <asp:Label ID="tbx_nim" runat="server" />   
    <br />
    <b><asp:Label ID="lbl_pos" runat="server" Text="Position : " /></b>
    <asp:Label ID="lbl_position" runat="server" /> 
    <asp:Label ID="lbl_section" runat="server" Visible="false" />
    <br />
    <br />
    <b><asp:Label ID="lbl_erreur" runat="server" Visible="false" Text="Impossible d'effectuer cette action" /></b>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <asp:Button ID="btn_terminer" Text="Retour" runat="server" OnClick="btn_terminer_Click" />
        
</asp:Panel>
</div>



<div>
<asp:Panel ID="pnl_dataList" runat="server" CssClass="right">
    <h2><asp:Label ID="lbl_titre" runat="server" /></h2>
<asp:RadioButtonList ID="rbl_anneeRot" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rbl_anneeRot_SelectedIndexChanged" AutoPostBack="true">
    <asp:ListItem ID="rbt_anneeCourante" runat="server" Selected="True" />
    <asp:ListItem ID="rbt_anneePlusUn" runat="server" />
    <asp:ListItem ID="rbt_anneePlusDeux" runat="server" />
</asp:RadioButtonList>
    <asp:Label ID="test" runat="server" />

    <asp:DataList runat="server" Visible="false" ID="dl_gouv" OnSelectedIndexChanged="dl_gouv_SelectedIndexChanged" OnItemCommand="dl_gouv_ItemCommand" OnItemDataBound="dl_gouv_ItemDataBound" >
        <SelectedItemTemplate>

            <b><asp:Label ID="lbl_nom" runat="server" Text='<%#Eval ("prenom") + " " + Eval("nom") %>' Width="250"/></b>
            <asp:Label ID="lbl_sectionDL" runat="server" Text='<%#Eval ("section") %>' Visible="false" />
            <asp:Button ID="btn_modifier" runat="server" Text="Modifier" OnClick="btn_modifier_Click" CommandName="unselect" CommandArgument='<%#Eval ("nim") %>' />

        </SelectedItemTemplate>
        
        <ItemTemplate>

            <asp:Label ID="lbl_nom" runat="server" Text='<%#Eval ("prenom") + " " + Eval("nom") %>' Width="250"/>
            <asp:Label ID="lbl_sectionDL" runat="server" Text='<%#Eval ("section") %>' Visible="false" />
            <asp:Button ID="btn_modifier" runat="server" Text="Modifier" OnClick="btn_modifier_Click" CommandName="select" CommandArgument='<%#Eval ("nim") %>' />
            
            
        </ItemTemplate>

    </asp:DataList>
    <a name="Fonda" ></a>
    <asp:DataList runat="server" ID="dl_fondation" OnSelectedIndexChanged="dl_fondation_SelectedIndexChanged" OnItemDataBound="dl_fondation_ItemDataBound" Visible="false" OnItemCommand="dl_fondation_ItemCommand">
        
        <SelectedItemTemplate>

            <b><asp:Label ID="lbl_nom" runat="server" Text='<%#Eval ("prenom") + " " + Eval("nom") %>' Width="250"/></b>
            <asp:Label ID="lbl_sectionDL" runat="server" Text='<%#Eval ("section") %>' Visible="false" />
            <asp:Button ID="btn_modifier" runat="server" Text="Modifier" OnClick="btn_modifier_Click" CommandName="unselect" CommandArgument='<%#Eval ("nim") %>' />

        </SelectedItemTemplate>
        
        <ItemTemplate>

            <asp:Label ID="lbl_nom" runat="server" Text='<%#Eval ("prenom") + " " + Eval("nom") %>' Width="250"/>
            <asp:Label ID="lbl_sectionDL" runat="server" Text='<%#Eval ("section") %>' Visible="false" />
            <asp:Button ID="btn_modifier" runat="server" Text="Modifier" OnClick="btn_modifier_Click" CommandName="select" CommandArgument='<%#Eval ("nim") %>' />
            
            
        </ItemTemplate>


    </asp:DataList>
    <a name="Bur" ></a>
    <asp:DataList runat="server" ID="dl_bureau" OnItemDataBound="dl_bureau_ItemDataBound" OnSelectedIndexChanged="dl_bureau_SelectedIndexChanged" Visible="false" OnItemCommand="dl_bureau_ItemCommand">
        
        <SelectedItemTemplate>

            <b><asp:Label ID="lbl_nom" runat="server" Text='<%#Eval ("prenom") + " " + Eval("nom") %>' Width="250"/></b>
            <asp:Label ID="lbl_sectionDL" runat="server" Text='<%#Eval ("section") %>' Visible="false" />
            <asp:Button ID="btn_modifier" runat="server" Text="Modifier" OnClick="btn_modifier_Click" CommandName="unselect" CommandArgument='<%#Eval ("nim") %>' />

        </SelectedItemTemplate>
        
        <ItemTemplate>

            <asp:Label ID="lbl_nom" runat="server" Text='<%#Eval ("prenom") + " " + Eval("nom") %>' Width="250"/>
            <asp:Label ID="lbl_sectionDL" runat="server" Text='<%#Eval ("section") %>' Visible="false" />
            <asp:Button ID="btn_modifier" runat="server" Text="Modifier" OnClick="btn_modifier_Click" CommandName="select" CommandArgument='<%#Eval ("nim") %>' />
            
            
        </ItemTemplate>


    </asp:DataList>

    <asp:DataList runat="server" ID="dl_presidents" OnItemDataBound="dl_presidents_ItemDataBound" OnSelectedIndexChanged="dl_presidents_SelectedIndexChanged" Visible="false" OnItemCommand="dl_presidents_ItemCommand" >
        
        <SelectedItemTemplate>

            <b><asp:Label ID="lbl_nom" runat="server" Text='<%#Eval ("prenom") + " " + Eval("nom") %>' Width="250"/></b>
            <asp:Label ID="lbl_sectionDL" runat="server" Text='<%#Eval ("section") %>' Visible="false" />
            <asp:Button ID="btn_modifier" runat="server" Text="Modifier" OnClick="btn_modifier_Click" CommandName="unselect" CommandArgument='<%#Eval ("nim") %>' />

        </SelectedItemTemplate>
        
        <ItemTemplate>

            <asp:Label ID="lbl_nom" runat="server" Text='<%#Eval ("prenom") + " " + Eval("nom") %>' Width="250"/>
            <asp:Label ID="lbl_sectionDL" runat="server" Text='<%#Eval ("section") %>' Visible="false" />
            <asp:Button ID="btn_modifier" runat="server" Text="Modifier" OnClick="btn_modifier_Click" CommandName="select" CommandArgument='<%#Eval ("nim") %>' />
            
            
        </ItemTemplate>


    </asp:DataList>

    <asp:DataList runat="server" ID="dl_amMonaco" OnItemDataBound="dl_amMonaco_ItemDataBound" Visible="false" OnSelectedIndexChanged="dl_amMonaco_SelectedIndexChanged" OnItemCommand="dl_amMonaco_ItemCommand">
        
        <SelectedItemTemplate>

            <b><asp:Label ID="lbl_nom" runat="server" Text='<%#Eval ("prenom") + " " + Eval("nom") %>' Width="250"/></b>
            <asp:Label ID="lbl_sectionDL" runat="server" Text='<%#Eval ("section") %>' Visible="false" />
            <asp:Button ID="btn_modifier" runat="server" Text="Modifier" OnClick="btn_modifier_Click" CommandName="unselect" CommandArgument='<%#Eval ("nim") %>' />

        </SelectedItemTemplate>
        
        <ItemTemplate>

            <asp:Label ID="lbl_nom" runat="server" Text='<%#Eval ("prenom") + " " + Eval("nom") %>' Width="250"/>
            <asp:Label ID="lbl_sectionDL" runat="server" Text='<%#Eval ("section") %>' Visible="false" />
            <asp:Button ID="btn_modifier" runat="server" Text="Modifier" OnClick="btn_modifier_Click" CommandName="select" CommandArgument='<%#Eval ("nim") %>' />
            
            
        </ItemTemplate>


    </asp:DataList>

    <asp:DataList runat="server" ID="dl_Corse" OnItemDataBound="dl_Corse_ItemDataBound" Visible="false" OnSelectedIndexChanged="dl_Corse_SelectedIndexChanged" OnItemCommand="dl_Corse_ItemCommand" >
        
        <SelectedItemTemplate>

            <b><asp:Label ID="lbl_nom" runat="server" Text='<%#Eval ("prenom") + " " + Eval("nom") %>' Width="250"/></b>
            <asp:Label ID="lbl_sectionDL" runat="server" Text='<%#Eval ("section") %>' Visible="false" />
            <asp:Button ID="btn_modifier" runat="server" Text="Modifier" OnClick="btn_modifier_Click" CommandName="unselect" CommandArgument='<%#Eval ("nim") %>' />

        </SelectedItemTemplate>
        
        <ItemTemplate>

            <asp:Label ID="lbl_nom" runat="server" Text='<%#Eval ("prenom") + " " + Eval("nom") %>' Width="250"/>
            <asp:Label ID="lbl_sectionDL" runat="server" Text='<%#Eval ("section") %>' Visible="false" />
            <asp:Button ID="btn_modifier" runat="server" Text="Modifier" OnClick="btn_modifier_Click" CommandName="select" CommandArgument='<%#Eval ("nim") %>' />
            
            
        </ItemTemplate>


    </asp:DataList>

    <asp:DataList runat="server" ID="dl_Var" OnItemDataBound="dl_Var_ItemDataBound" Visible="false" OnSelectedIndexChanged="dl_Var_SelectedIndexChanged" OnItemCommand="dl_Var_ItemCommand" >
        
        <SelectedItemTemplate>

            <b><asp:Label ID="lbl_nom" runat="server" Text='<%#Eval ("prenom") + " " + Eval("nom") %>' Width="250"/></b>
            <asp:Label ID="lbl_sectionDL" runat="server" Text='<%#Eval ("section") %>' Visible="false" />
            <asp:Button ID="btn_modifier" runat="server" Text="Modifier" OnClick="btn_modifier_Click" CommandName="unselect" CommandArgument='<%#Eval ("nim") %>' />

        </SelectedItemTemplate>
        
        <ItemTemplate>

            <asp:Label ID="lbl_nom" runat="server" Text='<%#Eval ("prenom") + " " + Eval("nom") %>' Width="250"/>
            <asp:Label ID="lbl_sectionDL" runat="server" Text='<%#Eval ("section") %>' Visible="false" />
            <asp:Button ID="btn_modifier" runat="server" Text="Modifier" OnClick="btn_modifier_Click" CommandName="select" CommandArgument='<%#Eval ("nim") %>' />
            
            
        </ItemTemplate>


    </asp:DataList>
    <br />
    <br />
    <asp:Button ID="btn_redirect" CssClass="right" runat="server" Text="Retourner à la visualisation des affectations" OnClick="btn_redirect_Click" />
    <asp:HiddenField ID="hfd_positionDL" runat="server" />
</asp:Panel>

<asp:Panel ID="pnl_onglet" runat="server" >

</asp:Panel>


</div>
