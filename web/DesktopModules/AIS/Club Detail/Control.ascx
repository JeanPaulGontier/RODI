<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2016                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Control.ascx.cs" Inherits="DesktopModules_AIS_Club_Detail_Control" %>

<script src="/AIS/TextEditor/ckeditor/ckeditor.js"></script>

<style>
    .videoContainer 
    {
    position: relative;
    width: 100%;
    height: 0;
    padding-bottom: 56.25%;
    }
    .video
    {
    position: absolute;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    }
</style>


<div>

	<asp:Label runat="server" ID="LBL_adresse_1"  /><br />
	<asp:Label runat="server" ID="LBL_adresse_2"  /><br />
	<asp:Label runat="server" ID="LBL_adresse_3"  /><br />
	<span><asp:Label runat="server" ID="LBL_cp"         /> <asp:Label runat="server" ID="LBL_ville"      /></span><br />

	<div><asp:Label runat="server" ID="LBL_reunions"   /></div>
	<asp:Label runat="server" ID="LBL_telephone"  /><br />
	<asp:Label runat="server" ID="LBL_fax"        /><br />
	<div><asp:HyperLink ID="HL_email" runat="server">
		<img src="<%= PortalSettings.ActiveTab.SkinPath %>images/mail.png" title="Envoyer un message au club" /></asp:HyperLink>
	<asp:HyperLink ID="HL_web" runat="server" Target="_blank" ToolTip="Consulter le site du club">
		<img src="<%= PortalSettings.ActiveTab.SkinPath %>images/web.png" title="Consulter le site du club" /></asp:HyperLink>
        </div>
    <div>&nbsp;</div>
	<div><asp:Label  runat="server"  ID="LBL_texte"      /></div>
</div>

<div class="UneColonne">
	<asp:Image runat="server" CssClass="Fanion" ID="IMG_fanion"     />
</div>

<asp:Panel runat="server" ID="pnl_bloc">
    

<asp:Repeater runat="server" ID="repeat_bloc" OnItemDataBound="repeat_bloc_ItemDataBound" OnItemCommand="repeat_bloc_ItemCommand"    >

    <ItemTemplate>

        <asp:Panel ID="pnl_display" runat="server">
            
            <asp:Image runat="server" CssClass="Block" ID="img_toDisplay" ImageUrl='<%# Bind("photo") %>' />
            <h1><asp:Label ID="lbl_title" Text='<%# Bind("title")%>' runat="server"></asp:Label></h1>
            <asp:Panel ID="pnl_contentToDisplay" runat="server" CssClass="Block">
                <p><asp:Label ID="lbl_content" runat="server" Text='<%# Bind("content") %>'></asp:Label></p>
            </asp:Panel>
            <div class="clear"></div>
        </asp:Panel>

        <div class="row">
            <div class="col-sm-4">
                <asp:LinkButton ID="btn_editBloc" runat="server" CssClass="btn btn-primary"><span class="fa fa-pencil"></span></asp:LinkButton>
            </div>
            <div class="col-sm-4">
                <asp:LinkButton ID="lbt_up" CssClass="btn btn-default" CommandArgument='<%# Bind("id") %>' runat="server"><span class="fa fa-arrow-up"></span></asp:LinkButton>
                <asp:LinkButton ID="lbt_down" CssClass="btn btn-default" CommandArgument='<%# Bind("id") %>' runat="server"><span class="fa fa-arrow-down"></span></asp:LinkButton>
            </div>
            <div class="col-sm-4">
                <!-- Button trigger modal -->
                <asp:LinkButton runat="server" CssClass="btn btn-danger" CommandArgument='<%# Bind("id") %>' ID="btn_delete" OnClientClick="Javascript: return confirm('Voulez-vous vraiment supprimer ce bloc ?');" ><span class="fa fa-trash-o"></span></asp:LinkButton>
            </div>
        </div>
    </ItemTemplate>

</asp:Repeater>
    <br />

<asp:Button runat="server" CssClass="btn btn-primary" Text="Ajouter un nouveau bloc" ID="btn_addBloc" OnClick="btn_addBloc_Click" />

    <%--<asp:Panel runat="server" ID="pnl_content">
        <asp:Panel ID="Panel1" runat="server">
		    <asp:HyperLink ID="HL_Detail" runat="server">
			    <div class="LimitedHeight"><asp:Image ID="Image1" runat="server" /></div>
			    <h1><asp:Label ID="Titre1" runat="server" Text='<%# Bind("title") %>' /></h1>
		    </asp:HyperLink>
		    <asp:Panel runat="server" CssClass="Block" ID="Panel2">
           
			    <asp:Label ID="Date1" runat="server" Text='<%# Bind("dt","{0:dd MMM yyyy}") %>' CssClass="Date" Visible="false" />
			    <p><asp:Label ID="Texte1" runat="server" Text='<%# Bind("text") %>' /></p>
			    
		    </asp:Panel>
            <asp:HyperLink ID="HL_Detail1" CssClass="right" runat="server">Lire la suite...</asp:HyperLink>
        </asp:Panel>
    </asp:Panel>
    <br />--%>
    
    
    

    <asp:Panel ID="pnl_add" runat="server" Visible="false">
        <h1>Édition de la présentation</h1>
        <asp:RadioButtonList ID="rbl_type" runat="server">
            <asp:ListItem Text="Texte seulement" Selected="True" Value="NoPhoto"></asp:ListItem>
            <asp:ListItem Text="Image à gauche + texte" Value="PhotoLeft"></asp:ListItem>
            <asp:ListItem Text="Image à droite + texte" Value="PhotoRight"></asp:ListItem>
            <asp:ListItem Text="Image au-dessus du texte" Value="PhotoTop"></asp:ListItem>
            <asp:ListItem Text="Vidéo" Value="Video"></asp:ListItem>
        </asp:RadioButtonList>
        <asp:Button ID="btn_type" CssClass="btn btn-primary" runat="server" Text="Changer le type" OnClick="btn_type_Click"/>
        <br />
        <asp:Label Text="Titre : " runat="server"></asp:Label>
        <asp:TextBox ID="tbx_titre" Width="100%" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lbl_contenu" Text="Contenu : " runat="server"></asp:Label>
        <asp:TextBox ID="tbx_contenu" Visible="true" TextMode="MultiLine" Width="600" Height="300" runat="server" ></asp:TextBox>
        <script> CKEDITOR.replace('<%=tbx_contenu.ClientID%>', {
                uiColor: '#CCEAEE'
            });  </script>
        <asp:Panel ID="pnl_image" runat="server" Visible="false">
            <asp:FileUpload ID="ful_image" runat="server" />
            <asp:Button ID="btn_image" runat="server" CssClass="btn btn-primary" Text="Charger l'image" OnClick="btn_image_Click" />
            <asp:Image ID="img" runat="server" />
            <asp:HiddenField ID="hfd_image" runat="server" />
        </asp:Panel>
        <asp:Panel ID="pnl_video" runat="server" Visible="false">
            <asp:Label runat="server">URL de la vidéo : </asp:Label>
            <asp:TextBox ID="tbx_url" Width="100%" runat="server"></asp:TextBox>
        </asp:Panel>

        <br />
        <asp:Button ID="btn_validate" runat="server" CssClass="btn btn-primary" OnClick="btn_validate_Click" Text="Valider le bloc" />
        <asp:Button ID="btn_cancel" runat="server" CssClass="btn btn-primary" OnClick="btn_cancel_Click" Text="Annuler" />



    </asp:Panel>
</asp:Panel>





