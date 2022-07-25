<%@ Control language="vb" CodeBehind="~/admin/Skins/skin.vb" AutoEventWireup="false" Explicit="True" Inherits="DotNetNuke.UI.Skins.Skin" %>
<%@ Register TagPrefix="dnn" TagName="CURRENTDATE" Src="~/Admin/Skins/CurrentDate.ascx" %>
<%@ Register TagPrefix="dnn" TagName="STYLES" Src="~/Admin/Skins/Styles.ascx" %>
<%@ Register TagPrefix="dnn" TagName="Meta" Src="~/Admin/Skins/Meta.ascx" %>
<%@ Register TagPrefix="dnn" TagName="LANGUAGE" Src="~/Admin/Skins/Language.ascx" %>
<%@ Register TagPrefix="dnn" TagName="LOGO" Src="~/Admin/Skins/Logo.ascx" %>
<%@ Register TagPrefix="dnn" TagName="MENU" src="~/DesktopModules/DDRMenu/Menu.ascx" %>
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
<!--[if lt IE 9]>
<script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
<![endif]-->

<dnn:jQuery runat="server" jQueryUI="true" DnnjQueryPlugins="true" jQueryHoverIntent="true"></dnn:jQuery>
<dnn:STYLES runat="server" ID="StylesIE8" Name="IE8Minus" StyleSheet="css/ie8style.css" Condition="IE 8" UseSkinPath="true" />
<dnn:Meta runat="server" Name="viewport" Content="width=device-width, minimum-scale=1.0, maximum-scale=2.0" />
<div id="ControlPanelWrapper">
  <dnn:CONTROLPANEL runat="server" id="cp" IsDockable="True" />
</div>
<div class="skin_wrapper ph_spring">
  <!--start skin header-->
  <header class="pattern_header">
    <div class="skin_width clearafter">
      <div class="logo_style">
        <dnn:LOGO runat="server" id="dnnLOGO" />
      </div>
      <div class="headerpane_style">
        <div runat="server" id="HeaderPane" class="headerpane"></div>
      </div>
    </div>
  </header>
  <!--end skin header-->
  <!--start skin menu-->
  <section id="skin_menu">
    <div class="menu_bar clearafter">
      <div class="skin_width">
        <div id="Search">
          <dnn:SEARCH runat="server" id="dnnSEARCH" cssClass="searchcss" showWeb="false" showSite="false" UseDropdownlist="false" />
        </div>
        <!--mobile menu button-->
        <div class="mobile_nav"><a href="#" class="menuclick"><img alt="Menu" class="click_img" src="<%=SkinPath %>images/blank.gif" /></a></div>
        <nav class="menu_box">
          <dnn:MENU MenuStyle="StandardMenu" runat="server"> </dnn:MENU>
        </nav>
      </div>
      <div class="menu_shadow"><img src="<%= SkinPath %>images/menu_shadow.png" alt="menu shadow" /></div>
    </div>
  </section>
  <!--end skin menu-->
  <!--start page name-->
  <section class="page_name">
    <div class="skin_width pagename_style">
      <h1><%=PortalSettings.ActiveTab.TabName %></h1>
      <div class="breadcrumb_style">
        <dnn:BREADCRUMB runat="server" id="dnnBREADCRUMB" Separator="&nbsp;&nbsp;/&nbsp;&nbsp;" cssclass="Breadcrumb" RootLevel="0" />
      </div>
    </div>
  </section>
  <!-- end page name -->
  <!--start main area-->
  <div class="skin_main">
    <section class="content_whitebg">
      <div class="skin_width">
        <div class="skin_content">
          <div class="row dnnpane">
            <div runat="server" id="ContentPane" class="content_grid12 col-sm-12"></div>
          </div>
          <div class="row dnnpane">
            <div runat="server" id="OneGrid4A" class="one_grid4a col-sm-4"></div>
            <div runat="server" id="OneGrid4B" class="one_grid4b col-sm-4"></div>
            <div runat="server" id="OneGrid4C" class="one_grid4c col-sm-4"></div>
          </div>
          <div class="row dnnpane">
            <div runat="server" id="TwoGrid3A" class="two_grid3a col-sm-3"></div>
            <div runat="server" id="TwoGrid3B" class="two_grid3b col-sm-3"></div>
            <div runat="server" id="TwoGrid3C" class="two_grid3c col-sm-3"></div>
            <div runat="server" id="TwoGrid3D" class="two_grid3d col-sm-3"></div>
          </div>
          <div class="row dnnpane">
            <div runat="server" id="ThreeGrid12" class="three_grid12 col-sm-12"></div>
          </div>
          <div class="row dnnpane">
            <div runat="server" id="FourGrid8" class="four_grid8 col-sm-8"></div>
            <div runat="server" id="FourGrid4" class="four_grid4 col-sm-4"></div>
          </div>
          <div class="row dnnpane">
            <div runat="server" id="FiveGrid4" class="five_grid4 col-sm-4"></div>
            <div runat="server" id="FiveGrid8" class="five_grid8 col-sm-8"></div>
          </div>
          <div class="row dnnpane">
            <div runat="server" id="SixGrid6A" class="six_grid6a col-sm-6"></div>
            <div runat="server" id="SixGrid6B" class="six_grid6b col-sm-6"></div>
          </div>
          <div class="row dnnpane">
            <div runat="server" id="SevenGrid9" class="seven_grid9 col-sm-9"></div>
            <div runat="server" id="SevenGrid3" class="seven_grid3 col-sm-3"></div>
          </div>
          <div class="row dnnpane">
            <div runat="server" id="EightGrid3" class="eight_grid3 col-sm-3"></div>
            <div runat="server" id="EightGrid9" class="eight_grid9 col-sm-9"></div>
          </div>
          <div class="row dnnpane">
            <div runat="server" id="NineGrid3A" class="nine_grid3a col-sm-3"></div>
            <div runat="server" id="NineGrid3B" class="nine_grid3b col-sm-3"></div>
            <div runat="server" id="NineGrid3C" class="nine_grid3c col-sm-3"></div>
            <div runat="server" id="NineGrid3D" class="nine_grid3d col-sm-3"></div>
          </div>
          <div class="row dnnpane">
            <div runat="server" id="TenGrid12" class="ten_grid12 col-sm-12"></div>
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
  <a href="#top" id="top-link" title="Top"> </a> </div>
<!--#include file="commonparts/StyleCustom.ascx"-->
<!--#include file="commonparts/AddScripts.ascx"-->
<dnn:DnnCssInclude runat="server" FilePath="commonparts/PatternHeader.css" PathNameAlias="SkinPath" />
