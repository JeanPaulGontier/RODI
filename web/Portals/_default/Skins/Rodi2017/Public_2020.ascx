<%@ Control language="vb" CodeBehind="~/admin/Skins/skin.vb" AutoEventWireup="false" Explicit="True" Inherits="DotNetNuke.UI.Skins.Skin" %>
<%@ Register TagPrefix="dnn" TagName="CURRENTDATE" Src="~/Admin/Skins/CurrentDate.ascx" %>
<%@ Register TagPrefix="dnn" TagName="STYLES" Src="~/Admin/Skins/Styles.ascx" %>
<%@ Register TagPrefix="dnn" TagName="Meta" Src="~/Admin/Skins/Meta.ascx" %>
<%@ Register TagPrefix="dnn" TagName="LANGUAGE" Src="~/Admin/Skins/Language.ascx" %>
<%@ Register TagPrefix="dnn" TagName="LOGO" Src="~/Admin/Skins/Logo.ascx" %>
<%@ Register TagPrefix="dnn" TagName="SEARCH" Src="~/Admin/Skins/Search.ascx" %>
<%@ Register TagPrefix="dnn" TagName="USER" Src="~/Admin/Skins/User.ascx" %>
<%@ Register TagPrefix="dnn" TagName="LOGIN" Src="~/Admin/Skins/Login.ascx" %>
<%@ Register TagPrefix="dnn" TagName="COPYRIGHT" Src="~/Admin/Skins/Copyright.ascx" %>
<%@ Register TagPrefix="dnn" TagName="PRIVACY" Src="~/Admin/Skins/Privacy.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TERMS" Src="~/Admin/Skins/Terms.ascx" %>
<%@ Register TagPrefix="dnn" TagName="BREADCRUMB" Src="~/Admin/Skins/BreadCrumb.ascx" %>
<%@ Register TagPrefix="dnn" TagName="LINKS" Src="~/Admin/Skins/Links.ascx" %>
<%@ Register TagPrefix="dnn" TagName="CONTROLPANEL" Src="~/Admin/Skins/controlpanel.ascx" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.Client.ClientResourceManagement" Assembly="DotNetNuke.Web.Client" %>
<%@ Register TagPrefix="dnn" TagName="jQuery" src="~/Admin/Skins/jQuery.ascx" %>
<%@ Register TagPrefix="ais" TagName="MENU" Src="~/AIS/Menu.ascx" %>

<link href="https://fonts.googleapis.com/css?family=Open+Sans:400,700,800" rel="stylesheet">

<dnn:jQuery runat="server" jQueryUI="true" DnnjQueryPlugins="true" jQueryHoverIntent="true"></dnn:jQuery>
<dnn:Meta runat="server" Name="viewport" Content="width=device-width, minimum-scale=1.0, maximum-scale=2.0" />
<div id="ControlPanelWrapper">
  <dnn:CONTROLPANEL runat="server" id="cp" IsDockable="True" />
</div>
<div class="skin_wrapper ph_spring">
  <!--#include file="commonparts/PatternHeader.ascx"-->
  <!--start skin banner-->
  <section class="skin_banner">
    <div class="bannerpane" id="BannerPane" runat="server"></div>
  </section>
  <!--end skin banner-->
  <!--start main area-->
  <div class="skin_main home_2020">
    <section class="content_whitebg">
        <div class="skin_content">
          <div class="skin_width">
              <div class="row dnnpane">
                <div runat="server" id="ContentPane" class="content_grid12 col-sm-12"></div>
              </div>
              <div class="row dnnpane">
                <div runat="server" id="OneGrid6A" class="one_grid6a col-sm-6"></div>
                <div runat="server" id="OneGrid6B" class="one_grid6b col-sm-6"></div>
              </div>
              <div class="row dnnpane">
                <div runat="server" id="TwoGrid6A" class="two_grid6a col-sm-6"></div>
                <div class="two_grid6a col-sm-6 no-padding">
                    <div runat="server" id="TwoGrid12A" class="two_grid12A col-sm-12"></div>
                    <div runat="server" id="TwoGridI6A" class="two_gridi6a col-sm-6"></div>
                    <div runat="server" id="TwoGridI6B" class="two_gridi6b col-sm-6"></div>
                </div>
              </div>
          </div>
          <div class="row dnnpane parallax letter">
            <div class="skin_width">
		  	    <div runat="server" id="FourGrid12" class="four_grid12 col-sm-12"></div>
            </div>
          </div>
          <div class="skin_width">
              <div class="row dnnpane">
                <div class="five_grid6a col-sm-6 no-padding">
                    <div runat="server" id="FiveGrid12A" class="five_grid12 col-sm-12"></div>
                    <div runat="server" id="FiveGrid6A" class="five_grid6 col-sm-6"></div>
                    <div runat="server" id="FiveGrid6B" class="five_grid6 col-sm-6"></div>
                </div>
                <div class="five_grid6a col-sm-6 no-padding">
                    <div runat="server" id="FiveGrid6C" class="five_grid6 col-sm-6"></div>
                    <div runat="server" id="FiveGrid6D" class="five_grid6 col-sm-6"></div>
                </div>
              </div>
              <div class="row dnnpane">
                <div runat="server" id="SixGrid6A" class="six_grid6a col-sm-6"></div>
                <div runat="server" id="SixGrid6B" class="six_grid6b col-sm-6"></div>
              </div>
          </div>
          <div class="row dnnpane parallax formation">
            <div class="skin_width">
		  	    <div runat="server" id="SevenGrid12" class="seven_grid9 col-sm-12"></div>
            </div>
          </div>
          <div class="row dnnpane section_formation" style="display: none">
            <div class="skin_width">
                <div runat="server" id="EightGrid3A" class="eight_grid3 col-sm-3"></div>
                <div runat="server" id="EightGrid3B" class="eight_grid3 col-sm-3"></div>
                <div runat="server" id="EightGrid3C" class="eight_grid3 col-sm-3"></div>
                <div runat="server" id="EightGrid3D" class="eight_grid3 col-sm-3"></div>
			</div>
          </div>
          <div class="skin_width">
              <div class="row dnnpane">
                <div runat="server" id="NineGrid6A" class="nine_grid6A col-sm-6"></div>
                <div runat="server" id="NineGrid6B" class="nine_grid6b col-sm-6"></div>
              </div>
              <div class="row dnnpane">
                <div runat="server" id="TenGrid12A" class="ten_grid12 col-sm-12"></div>
                <div runat="server" id="TenGrid6A" class="ten_grid12 col-sm-6"></div>
                <div runat="server" id="TenGrid6B" class="ten_grid12 col-sm-6"></div>
              </div>
              <div class="row dnnpane">
                <div runat="server" id="ElevenGrid12A" class="eleven_grid6 col-sm-12"></div>
                <div runat="server" id="ElevenGrid6A" class="eleven_grid6 col-sm-6"></div>
                <div runat="server" id="ElevenGrid6B" class="eleven_grid6 col-sm-6"></div>
              </div>
              <div class="row dnnpane">
                <div runat="server" id="TwelveGrid12" class="ten_grid12 col-sm-12"></div>
              </div>
              <div class="row dnnpane">
                <div runat="server" id="ThirteenGrid6A" class="eleven_grid6 col-sm-6"></div>
                <div runat="server" id="ThirteenGrid6B" class="eleven_grid6 col-sm-6"></div>
             </div>
         </div>
        </div>
    </section>
  </div>
  <!--end main area-->
  <!--start footer top-->
  <section class="footer_top">
    <div class="skin_width">
      <div class="footerpane_style">
        <div class="row dnnpane">
          <div runat="server" id="FooterGrid3A" class="footer_grid3a col-sm-3"></div>
          <div runat="server" id="FooterGrid3B" class="footer_grid3b col-sm-3"></div>
          <div runat="server" id="FooterGrid3C" class="footer_grid3c col-sm-3"></div>
          <div runat="server" id="FooterGrid3D" class="footer_grid3d col-sm-3"></div>
        </div>
        <div class="row dnnpane">
          <div runat="server" id="FooterGrid12" class="footergrid12 col-sm-12"></div>
        </div>
      </div>
    </div>
  </section>
  <!--end footer top-->
  <!--start footer-->
  <footer class="skin_footer">
    <div class="skin_width">
      <div class="copyright_bar clearafter">
        <div class="footer_left">
          <dnn:COPYRIGHT runat="server" id="dnnCOPYRIGHT" cssclass="Footer" />
        </div>
        <div class="footer_right">
          <dnn:PRIVACY runat="server" id="dnnPRIVACY" cssclass="Footer" />
          |
          <dnn:TERMS runat="server" id="dnnTERMS" cssclass="Footer" />
        </div>
      </div>
    </div>
  </footer>
  <!--end footer-->
<a onclick="window.scroll({top:0,left:0,behavior:'smooth'})" id="top-link" title="Top"> </a> </div>
</div>
<!--#include file="commonparts/StyleCustom.ascx"-->
<!--#include file="commonparts/AddScripts.ascx"-->
<dnn:DnnCssInclude runat="server" FilePath="commonparts/PatternHeader.css" PathNameAlias="SkinPath" />
