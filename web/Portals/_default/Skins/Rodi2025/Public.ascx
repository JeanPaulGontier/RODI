<%@ Control Language="vb" AutoEventWireup="false" Explicit="True" Inherits="DotNetNuke.UI.Skins.Skin" %>
<%@ Register TagPrefix="dnn" TagName="STYLES" Src="~/Admin/Skins/Styles.ascx" %>
<%@ Register TagPrefix="dnn" TagName="Meta" Src="~/Admin/Skins/Meta.ascx" %>
<%@ Register TagPrefix="dnn" TagName="USER" Src="~/Admin/Skins/User.ascx" %>
<%@ Register TagPrefix="dnn" TagName="LOGO" Src="~/Admin/Skins/Logo.ascx" %>
<%@ Register TagPrefix="dnn" TagName="COPYRIGHT" Src="~/Admin/Skins/Copyright.ascx" %>
<%@ Register TagPrefix="dnn" TagName="PRIVACY" Src="~/Admin/Skins/Privacy.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TERMS" Src="~/Admin/Skins/Terms.ascx" %>
<%@ Register TagPrefix="dnn" TagName="CONTROLPANEL" Src="~/Admin/Skins/controlpanel.ascx" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.Client.ClientResourceManagement" Assembly="DotNetNuke.Web.Client" %>
<%@ Register TagPrefix="dnn" TagName="jQuery" src="~/Admin/Skins/jQuery.ascx" %>
<%@ Register TagPrefix="ais" TagName="MENU" Src="~/Portals/_default/Skins/Rodi2025/Controls/Menu.ascx" %>
<ais:MENU runat="server" ID="Menu2025"/>
<link href="https://fonts.googleapis.com/css?family=Open+Sans:400,700,800" rel="stylesheet">

<dnn:jQuery runat="server" jQueryUI="true" DnnjQueryPlugins="true" jQueryHoverIntent="true"></dnn:jQuery>
<dnn:Meta runat="server" Name="viewport" Content="width=device-width, minimum-scale=1.0, maximum-scale=2.0" />
<div id="ControlPanelWrapper">
  <dnn:CONTROLPANEL runat="server" id="cp" IsDockable="True" />
</div>

<div class="mobile-display">
  <script type="text/javascript">   
    $(document).ready(
        function () {
            $('.menu-mob').click(function () {
                $('#MENUMOB').animate({ left: '-800px' });

                $('.menu-mob').css({ opacity: 0.6, visibility: "visible" }).animate({ opacity: 0 }, 200, function () {
                    $('.menu-mob').css('visibility', 'hidden');
                });
            });
            $('#MENUTOGGLE').click(function () {
                if ($('#MENUMOB').css("left").valueOf() == "-800px") {
                    $('#MENUMOB').css('opacity', '1.0');
                    $('.menu-mob').css({ opacity: 0.0, visibility: "visible" }).animate({ opacity: 0.6 }, 200, 'linear');
                    $('#MENUMOB').animate({ left: (document.getElementsByClassName('personabar-visible').length > 0) ? '80px' : '0px' }, 500, 'linear');
                }
                else {
                    $('#MENUMOB').animate({ left: '-800' }, 500, 'linear');
                    $('.menu-mob').css({ opacity: 0.6, visibility: "visible" }).animate({ opacity: 0 }, 200, 'linear', function () {
                        $('.menu-mob').css('visibility', 'hidden');
                    });
                }
            })
        })
  </script>

  <header>
    <a href="#" class="menu-click" id="MENUTOGGLE" >
        <img alt="Menu" src="<%=SkinPath %>images/burger-menu.svg" />
    </a>
    <dnn:LOGO runat="server" ID="dnnLOGO" CssClass="logo-style"/>
  </header>

  <div class="menu-mob"></div>
  <div ID="MENUMOB">
    <div class="head-menu-m">
      <%If Not Request.IsAuthenticated Then%>
        <a href="/Espace-Membre" class="user-m" title="connexion"><i class="fa-solid fa-right-from-bracket"></i> Connexion</a>
      <% End If%>

      <%If Request.IsAuthenticated Then%>
          <span class="user-m"><% Response.Write("Bienvenue " + Entities.Users.UserController.Instance.GetCurrentUserInfo().DisplayName) %></span>
          <div class="info-text">
            <a href="/Espace-Membre/Mon-profil" title="Mon profil" class="ais-info-link"><i class="fa-regular fa-circle-user"></i> Mon profil</a> | 
            <a href="/Espace-Membre" title="Espace membres" class="ais-info-link"><i class="fa-solid fa-people-group"></i> Espace Membre</a> | 
            <a href="/logoff" title="Déconnexion" class="ais-info-link">Déconnexion <i class="fa-solid fa-power-off"></i></a> 
          </div>
      <% End If%>
    </div>
    <ais:MENU runat="server"/>
  </div>
</div>

<div class="pc-display header">
  <header class="content-wrapper">
    <div class="mini-menu">
      <%If Not Request.IsAuthenticated Then%>
        <a href="/Espace-Membre" class="btn-connexion" title="connexion">connexion</a>
        <!-- <div class="ais-text-right">
          <a href="https://www.rotary.org/" class="ais-light-link">Le Rotary International</a> | 
          <a href="https://www.rotary.org/fr/search/club-finder" class="ais-light-link">Recherche de club</a>
        </div> -->
      <% End If%>

      <%If Request.IsAuthenticated Then%>
          <span class="user-m"><% Response.Write("Bienvenue " + Entities.Users.UserController.Instance.GetCurrentUserInfo().DisplayName) %></span> | 
          <a href="/Espace-Membre/Mon-profil" title="Mon profil"><i class="fa-regular fa-circle-user"></i> Mon profil</a> | 
          <a href="/Espace-Membre" title="Espace membres"><i class="fa-solid fa-people-group"></i> Espace Membre</a> |
          <a href="/logoff" title="Déconnexion">Déconnexion <i class="fa-solid fa-power-off"></i></a>
      <% End If%>
    </div>

    <dnn:LOGO runat="server" ID="LOGO1" CssClass="logo-style"/>

    <div class="menu-bar">
      <div class="content-wrapper"><ais:MENU runat="server" ID="MENU1"/></div>
    </div>
  </header>
</div>


<section runat="server" id="ContentPane" class="content-pane"></section>


<footer>
  <section class="content-wrapper">
    <div>
      <dnn:COPYRIGHT runat="server" id="dnnCOPYRIGHT"/>
      <img src="Portals/_default/Skins/Rodi2025/images/rotary-official-licencee-ft.png" />
    </div>
    
    <div>
      <p><dnn:PRIVACY runat="server" id="dnnPRIVACY"/> | <dnn:TERMS runat="server" id="dnnTERMS"/></p>
      <p>La plateforme RODI est conforme au RGPD depuis sa mise en place le 25 mai 2018.</p>
    </div>
  </section>
</footer>

<a onclick="window.scroll({top:0,left:0,behavior:'smooth'})" id="top-link" title="Top"> </a>

