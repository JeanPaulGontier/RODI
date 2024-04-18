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
<%@ Register TagPrefix="ais" TagName="RODIVERSION" Src="~/AIS/RodiVersion.ascx" %>


<dnn:jQuery runat="server" jQueryUI="true" DnnjQueryPlugins="true" jQueryHoverIntent="true"></dnn:jQuery>
<dnn:Meta runat="server" Name="viewport" Content="width=device-width, minimum-scale=1.0, maximum-scale=2.0" />
<div id="ControlPanelWrapper">
  <dnn:CONTROLPANEL runat="server" id="cp" IsDockable="True" />
</div>
<div class="skin_wrapper ph_spring">
  <!--#include file="commonparts/HeaderMembre.ascx"-->
  <!--start skin banner-->
  <section class="skin_banner">
    <div class="bannerpane" id="BannerPane" runat="server"></div>
  </section>
  <!--end skin banner-->
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
    <section class="content_graybg">
      <div class="skin_width">
        <div class="skin_main_padding">
          <div class="row dnnpane">
            <div runat="server" id="GrayGrid6A" class="graygrid6a col-sm-6"></div>
            <div runat="server" id="GrayGrid6B" class="graygrid6b col-sm-6"></div>
          </div>
          <div class="row dnnpane">
            <div runat="server" id="GrayGrid12" class="graygrid12 col-sm-12"></div>
          </div>
        </div>
      </div>
    </section>
    <section class="content_whitebg">
      <div class="skin_width">
        <div class="skin_main_padding">
          <div class="row dnnpane">
            <div runat="server" id="MiddlePane" class="middlepane col-sm-12"></div>
          </div>
          <div class="row dnnpane">
            <div runat="server" id="MiddleGrid6A" class="middlegrid6a col-sm-6"></div>
            <div runat="server" id="MiddleGrid6B" class="middlegrid6b col-sm-6"></div>
          </div>
        </div>
      </div>
    </section>
    <section class="fixed_bg">
      <div class="skin_width">
        <div class="skin_main_padding">
          <div class="row dnnpane">
            <div runat="server" id="FixedBG3A" class="fixedbg3a col-sm-3"></div>
            <div runat="server" id="FixedBG3B" class="fixedbg3b col-sm-3"></div>
            <div runat="server" id="FixedBG3C" class="fixedbg3c col-sm-3"></div>
            <div runat="server" id="FixedBG3D" class="fixedbg3d col-sm-3"></div>
          </div>
          <div class="row dnnpane">
            <div runat="server" id="FixedBG12" class="fixedbg12 col-sm-12"></div>
          </div>
        </div>
      </div>
    </section>
    <section class="content_whitebg">
      <div class="skin_width">
        <div class="skin_main_padding">
          <div class="row dnnpane">
            <div runat="server" id="BottomGrid12A" class="bottomGrid12a col-sm-12"></div>
          </div>
          <div class="row dnnpane">
            <div runat="server" id="BottomGrid6A" class="bottomGrid6a col-sm-6"></div>
            <div runat="server" id="BottomGrid6B" class="bottomGrid6b col-sm-6"></div>
          </div>
          <div class="row dnnpane">
            <div runat="server" id="BottomGrid4A" class="bottomGrid4a col-sm-4"></div>
            <div runat="server" id="BottomGrid4B" class="bottomGrid4b col-sm-4"></div>
            <div runat="server" id="BottomGrid4C" class="bottomGrid4c col-sm-4"></div>
          </div>
          <div class="row dnnpane">
            <div runat="server" id="BottomGrid12B" class="bottomGrid12b col-sm-12"></div>
          </div>
        </div>
      </div>
    </section>
    <section class="content_colorbg">
      <div class="skin_width">
        <div class="skin_main_padding">
          <div class="row dnnpane">
            <div runat="server" id="BottomColorPane" class="bottomcolorpane col-sm-12"></div>
          </div>
        </div>
      </div>
    </section>
    <section class="content_graybg">
      <div class="skin_width">
        <div class="skin_main_padding">
          <div class="row dnnpane">
            <div runat="server" id="BottomGrayPane" class="bottomgraypane col-sm-12"></div>
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
          <dnn:COPYRIGHT runat="server" id="dnnCOPYRIGHT" cssclass="Footer" /> | <a class="Footer" title="Voir la liste des mises à jour RODI, Le développement de RODI est continu, la fréquence des mises à jour est de 1 à 2 par mois, le n° de version affichée correspond à celle installée ici, vous pouvez participer aux améliorations, rubrique contact sur le site RODI Platform" href="https://raw.githubusercontent.com/JeanPaulGontier/RODI/main/UPDATE.md" target="_blank">Mises à jour</a> | <span class="Footer"><ais:RODIVERSION runat="server" /></span>
        </div>
         <div class="footer_right">
          <p><dnn:PRIVACY runat="server" id="dnnPRIVACY" cssclass="Footer" />
          |
          <dnn:TERMS runat="server" id="dnnTERMS" cssclass="Footer" /></p>
          <p><span class="Footer">La plateforme RODI est conforme au RGPD depuis sa mise en place le 25 mai 2018.</span></p>
        </div>
      </div>
    </div>    
  </footer>
  <!--end footer-->
  <a onclick="window.scroll({top:0,left:0,behavior:'smooth'})" id="top-link" title="Top"> </a> </div>
<!--#include file="commonparts/StyleCustom.ascx"-->
<!--#include file="commonparts/AddScripts.ascx"-->
<dnn:DnnCssInclude runat="server" FilePath="commonparts/PatternHeader.css" PathNameAlias="SkinPath" />
