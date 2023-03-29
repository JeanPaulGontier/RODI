<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Control.ascx.cs" Inherits="DesktopModules_AIS_Club_Detail_Control" %>
<div class="row">  <div class="col-sm-2">
	    <asp:Image runat="server" width="100%" ID="IMG_fanion"/>
    </div>
    <div class="col-sm-4">
	    <div>
            <asp:Label runat="server" ID="LBL_adresse_1"/>
	    </div>
        <div>
	        <asp:Label runat="server" ID="LBL_adresse_2"/>
        </div>
        <div>
            <asp:Label runat="server" ID="LBL_adresse_3"/>
        </div>
        <div>
            <asp:Label runat="server" ID="LBL_cp"/> <asp:Label runat="server" ID="LBL_ville"/>
        </div>

       <div class="pe-spacer size20"></div>

        <div>
    	    <asp:Label runat="server" ID="LBL_telephone"/>
        </div>
        <div>
    	    <asp:Label runat="server" ID="LBL_fax"/>
        </div>

        <div class="pe-spacer size20"></div>

	    <div>
            <asp:HyperLink ID="HL_email" runat="server" CssClass="btn btn-primary">
		        <%--<img src="<%= PortalSettings.ActiveTab.SkinPath %>images/mail.png" title="Envoyer un message au club" />--%>
                Envoyer un message
            </asp:HyperLink>
	        <asp:HyperLink ID="HL_web" runat="server" Target="_blank" ToolTip="Consulter le site du club">
		        <img src="<%= PortalSettings.ActiveTab.SkinPath %>images/web.png" title="Consulter le site du club" />
	        </asp:HyperLink>
        </div>
    </div>

    <div class="col-sm-6">
	    <div>
            <asp:Label runat="server" ID="LBL_reunions"/>
	    </div>
    </div>

  
</div>
<div>
    <asp:Label runat="server" ID="LBL_texte" style="padding-top:20px;display:block;" />
</div>
