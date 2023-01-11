<div class="mobile_display">
    <script type="text/javascript">
        $(document).ready(
            function () {
                //  $('.MenuMob').css({ opacity: 0.0, visibility: "hidden" })
                $('.MenuMob').click(function () {
                    $('#MENUMOB').animate({ left: '-800px' });

                    $('.MenuMob').css({ opacity: 0.6, visibility: "visible" }).animate({ opacity: 0 }, 200, function () {
                        $('.MenuMob').css('visibility', 'hidden');
                    });
                });
                $('#MENUTOGGLE').click(function () {
                    if ($('#MENUMOB').css("left").valueOf() == "-800px") {
                        $('#MENUMOB').css('opacity', '1.0');

                        $('.MenuMob').css({ opacity: 0.0, visibility: "visible" }).animate({ opacity: 0.6 }, 200, 'linear');
                        $('#MENUMOB').animate({
                            left: (document.getElementsByClassName('personabar-visible').length > 0) ? '80px' : '0px'
                        }, 500, 'linear');

                    }
                    else {
                        $('#MENUMOB').animate({ left: '-800' }, 500, 'linear');

                        $('.MenuMob').css({ opacity: 0.6, visibility: "visible" }).animate({ opacity: 0 }, 200, 'linear', function () {
                            $('.MenuMob').css('visibility', 'hidden');
                        });
                    }
                })
            })
    </script>

    <header class="pattern_header Membre">
        <div class="skin_width">
            <a href="#" class="menuclick" id="MENUTOGGLE" >
                <img alt="Menu" src="<%=SkinPath %>images/burger-menu-blanc.svg"  />
            </a>
            <a href="/" class="logo_style">
                <img alt="Rotary District <%= System.Configuration.ConfigurationManager.AppSettings("DistrictId") %>" src="<%=SkinPath %>images/rotary-district<%= AIS.Const.DISTRICT_ID %>-blanc.png" />
            </a>
            <div class="text-center" style="flex-grow:1;">
                <h4>Espace Membre</h4>
                <%If AIS.Functions.CurrentCric > 0 Then %>
                <p><%= AIS.Functions.CurrentClub.name %></p>
                <%End If %>
            </div>
        </div>
    </header>

    <section class="skin_menu">
        <div class="menu_bar_membre">
            <div class="Membre">
                <div class="mobile_nav">
                    <nav>
                        <div class="MenuMob"></div>
                        <div ID="MENUMOB" class="Menu">
                             <div class="icons_menu">
                                <%If Not Request.IsAuthenticated Then%>
                                    <div class="icon_user membre text-right">
                                        <div class="titres_membre">
                                            <p>Espace Membre</p>
                                            <%If AIS.Functions.CurrentCric > 0 Then %>
                                            <p><%= AIS.Functions.CurrentClub.name %></p>
                                            <%End If %>
                                        </div>
                                        <div class="user_style">
                                            <a href="https://www.rotary.org/" class="HeadUser">Rotary International</a> | 
                                            <a href="https://www.rotary.org/fr/search/club-finder" class="HeadUser Localiser">Recherche de club</a>
                                        </div>
                                    </div>
                                <% End If%>

                                <%If Request.IsAuthenticated Then%>
                                    <div class="icon_user membre connected text-center">
                                        <a href="https://www.rotary.org/" class="HeadUser Breadcrumb">Rotary International</a> | 
                                        <a href="https://www.rotary.org/fr/search/club-finder" class="HeadUser Breadcrumb">Localiser un Rotary Club</a>
                                        <p class="HeadUser"><% Response.Write("Bienvenue " + Entities.Users.UserController.GetCurrentUserInfo.DisplayName) %></p>
                                        <div class="relative">
                                            <a href="/Espace-Membre/Mon-profil" title="Mon profil" class="HeadUser btn-profil">Mon profil</a> | 
                                            <dnn:LOGIN runat="server" id="LOGIN2" cssclass="HeadUser btn-logoff"/>  
                                        </div>
                                    </div>
                                <% End If%>
                                </div>
                            <ais:MENU runat="server" RootTabID='<%# AIS.Const.MENU_MEMBER_ROOT_TABID %>'  />
                        </div>
                    </nav>
                </div>
            </div>
        </div>
    </section>

</div>



<div class="pc_display">
    <header class="pattern_header Membre">
      <div class="skin_width">
        <a href="/" class="logo_style">
            <img alt="Rotary District <%= System.Configuration.ConfigurationManager.AppSettings("DistrictId") %>" src="<%=SkinPath %>images/rotary-district<%= AIS.Const.DISTRICT_ID %>-blanc.png" />
            <span></span>
        </a>
    
        <div class="icons_menu">
            <%If Not Request.IsAuthenticated Then%>
                <div class="icon_user membre text-right">
                    <div class="titres_membre">
                        <p>Espace Membre</p>
                        <%If AIS.Functions.CurrentCric > 0 Then %>
                        <p><%= AIS.Functions.CurrentClub.name %></p>
                        <%End If %>
                    </div>
                    <div class="user_style">
                        <a href="https://www.rotary.org/" class="HeadUser">Rotary International</a> | 
                        <a href="https://www.rotary.org/fr/search/club-finder" class="HeadUser Localiser">Recherche de club</a>
                    </div>
                </div>
            <% End If%>

            <%If Request.IsAuthenticated Then%>
                <div class="icon_user membre connected text-right">
                    <div id="Login">
                        <div class="titres_membre">
                            <p>Espace Membre</p>
                            <%If AIS.Functions.CurrentCric > 0 Then %>
                            <p><%= AIS.Functions.CurrentClub.name %></p>
                            <%End If %>
                        </div>
                        <a href="https://www.rotary.org/" class="HeadUser Breadcrumb">Rotary International</a> | 
                        <a href="https://www.rotary.org/fr/search/club-finder" class="HeadUser Breadcrumb">Localiser un Rotary Club</a>
                    </div>
                    <span class="HeadUser"><% Response.Write("Bienvenue " + Entities.Users.UserController.GetCurrentUserInfo.DisplayName) %></span> | 
                    <a href="/Espace-Membre/Mon-profil" title="Mon profil" class="HeadUser btn-profil">Mon profil</a> | 
                    <dnn:LOGIN runat="server" id="LOGIN1" cssclass="HeadUser btn-logoff"/>            
                </div>
            <% End If%>
            </div>
        </div>
    </header>


    <section>
      <div class="menu_bar_membre">
        <div class="Membre">
          <nav class="Menu skin_width">
              <ais:MENU runat="server" ID="MENU1" RootTabID='<%# AIS.Const.MENU_MEMBER_ROOT_TABID %>' />
          </nav>
        </div>
      </div>
    </section>
    
</div>