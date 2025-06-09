<%@ Control Language="C#" AutoEventWireup="false" Inherits="DotNetNuke.UI.Skins.Skin" %>
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
<%@ Register TagPrefix="dnn" TagName="LOGIN" Src="~/Admin/Skins/Login.ascx" %>
<%@ Register TagPrefix="ais" TagName="MENU" Src="~/Portals/_default/Skins/Rodi2025/Controls/Menu.ascx" %>

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
              //  $('.menu-mob').css({ opacity: 0.0, visibility: "hidden" })
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
                      $('#MENUMOB').animate({
                          left: (document.getElementsByClassName('personabar-visible').length > 0) ? '80px' : '0px'
                      }, 500, 'linear');

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

  <header class="header-membre">
        <a href="#" class="menuclick" id="MENUTOGGLE" >
            <img alt="Menu" src="<%=SkinPath %>images/burger-menu-blanc.svg"  />
        </a>
        <a href="/" class="logo-style">
            <img alt="Rotary District 1730" src="<%=SkinPath %>images/rotary-district<%= AIS.Const.DISTRICT_ID %>-blanc.png" />
        </a>
        <div class="text-center" style="flex-grow:1;">
            <div class="titres-membre">
                <p>Espace Membre</p>
            </div>
            <%if (AIS.Functions.CurrentCric > 0) { %>
            <p><%= AIS.Functions.CurrentClub.name %></p>
            <% } %>
        </div>
  </header>

    <div class="menu-mob"></div>
    <div ID="MENUMOB" class="menu-membre">
        <div class="icons-menu">
        <%if(!Request.IsAuthenticated) {%>
                <div class="text-right">
                    <div class="titres-membre">
                        <p>Espace Membre</p>
                        <%if (AIS.Functions.CurrentCric > 0) {%>
                        <p><%= AIS.Functions.CurrentClub.name %></p>
                        <% } %>
                    </div>
                    <div>
                        <a href="https://www.rotary.org/">Rotary International</a> | 
                        <a href="https://www.rotary.org/fr/search/club-finder">Recherche de club</a>
                    </div>
                </div>
            <% } %>

            <%if (Request.IsAuthenticated) {%>
                <div class="text-center">
                    <a href="https://www.rotary.org/">Rotary International</a> | 
                    <a href="https://www.rotary.org/fr/search/club-finder">Localiser un Rotary Club</a>

                    <div class="user-head">
                        <span><%= "Bienvenue " + PortalSettings.UserInfo.DisplayName %></span> | 
                        <a href="/Espace-Membre/Mon-profil" title="Mon profil"><i class="fa-regular fa-circle-user"></i> Mon profil</a> | 
                        <a href="/logoff" title="Déconnexion">Déconnexion <i class="fa-solid fa-power-off"></i></a>
                    </div> 
                </div>
            <% } %>
            </div>
        <ais:MENU runat="server" RootTabID='<%# AIS.Const.MENU_MEMBER_ROOT_TABID %>'  />
    </div>
</div>

<div class="pc-display membre">
    <header class="header-membre">
      <div class="content-wrapper">
        <a href="/" class="logo-style">
            <img alt="Rotary District <%= System.Configuration.ConfigurationManager.AppSettings["DistrictId"] %>" src="<%=SkinPath %>images/rotary-district<%= AIS.Const.DISTRICT_ID %>-blanc.png" />
            <span></span>
        </a>
    
        <div class="icons-menu text-right">
            <%if(!Request.IsAuthenticated) {%>
                <div class="titres-membre">
                    <p>Espace Membre</p>
                    <%if (AIS.Functions.CurrentCric > 0) { %>
                    <p><%= AIS.Functions.CurrentClub.name %></p>
                    <% } %>
                </div>
                <div>
                    <a href="https://www.rotary.org/">Rotary International</a> | 
                    <a href="https://www.rotary.org/fr/search/club-finder">Recherche de club</a>
                </div>
            <% } %>

            <%if (Request.IsAuthenticated) {%>
                    <div id="Login">
                        <div class="titres-membre">
                            <p>Espace Membre</p>
                            <%if (AIS.Functions.CurrentCric > 0) { %>
                            <p><%= AIS.Functions.CurrentClub.name %></p>
                            <% } %>
                        </div>
                        <a href="https://www.rotary.org/">Rotary International</a> | 
                        <a href="https://www.rotary.org/fr/search/club-finder">Localiser un Rotary Club</a>
                    </div>
                    <div class="user-head">
                        <span><%= "Bienvenue " + PortalSettings.UserInfo.DisplayName %></span> | 
                        <a href="/Espace-Membre/Mon-profil" title="Mon profil"><i class="fa-regular fa-circle-user"></i> Mon profil</a> | 
                        <a href="/logoff" title="Déconnexion">Déconnexion <i class="fa-solid fa-power-off"></i></a>
                    </div>            
            <% } %>
            </div>
        </div>
    </header>

    <section>
      <div class="menubar-membre">
        <nav class="menu content-wrapper">
            <ais:MENU runat="server" ID="MENU1" RootTabID='<%# AIS.Const.MENU_MEMBER_ROOT_TABID %>' />
        </nav>
      </div>
    </section>
</div>


<div class="content content-membre">
  <section runat="server" id="BannerPane" class="content-pane"></section>

  <section class="bg-secondary">
    <div runat="server" id="ContentPane" class="content-wrapper"></div>
    <div class="grid content-wrapper">
      <div class="col-sm-6" runat="server" id="GreyRow2A"></div>
      <div class="col-sm-6" runat="server" id="GreyRow2B"></div>
    </div>
  </section>

  <section runat="server" id="WhiteRow1" class="content-wrapper"></section>

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
</div>


<a onclick="window.scroll({top:0,left:0,behavior:'smooth'})" id="top-link" title="Top"> </a>