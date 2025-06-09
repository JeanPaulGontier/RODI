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
    <div class="bannerpane" id="BannerPane" runat="server"></div>

    <section class="bg-secondary pb-2">
      <div class="content-wrapper">
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
    </section>

    <section class="content_graybg">
      <div class="content-wrapper">
          <div class="row dnnpane">
            <div runat="server" id="GrayGrid6A" class="graygrid6a col-sm-6"></div>
            <div runat="server" id="GrayGrid6B" class="graygrid6b col-sm-6"></div>
          </div>
          <div class="row dnnpane">
            <div runat="server" id="GrayGrid12" class="graygrid12 col-sm-12"></div>
          </div>
      </div>
    </section>

    <section>
      <div class="skin-wrapper">
          <div class="row dnnpane">
            <div runat="server" id="MiddlePane" class="middlepane col-sm-12"></div>
          </div>
          <div class="row dnnpane">
            <div runat="server" id="MiddleGrid6A" class="middlegrid6a col-sm-6"></div>
            <div runat="server" id="MiddleGrid6B" class="middlegrid6b col-sm-6"></div>
          </div>
      </div>
    </section>

    <section class="fixed_bg">
      <div class="skin-wrapper">
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
    </section>

    <section>
      <div class="skin-wrapper">
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
    </section>

    <section class="content_colorbg">
      <div class="skin-wrapper">
          <div class="row dnnpane">
            <div runat="server" id="BottomColorPane" class="bottomcolorpane col-sm-12"></div>
        </div>
      </div>
    </section>

    <section class="content_graybg">
      <div class="skin-wrapper">
          <div class="row dnnpane">
            <div runat="server" id="BottomGrayPane" class="bottomgraypane col-sm-12"></div>
          </div>
      </div>
    </section>















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
