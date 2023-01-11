
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
                        $('#MENUMOB').animate({ left: (document.getElementsByClassName('personabar-visible').length > 0) ? '80px' : '0px' }, 500, 'linear');
                        $('.more-links').animate({ left: (document.getElementsByClassName('personabar-visible').length > 0) ? '80px' : '0px' }, 500, 'linear');


                    }
                    else {
                        $('#MENUMOB').animate({ left: '-800' }, 500, 'linear');
                        $('.more-links').animate({ left: '-800' }, 500, 'linear');
                        $('.MenuMob').css({ opacity: 0.6, visibility: "visible" }).animate({ opacity: 0 }, 200, 'linear', function () {
                            $('.MenuMob').css('visibility', 'hidden');
                        });
                    }
                })
            })
    </script>

    <header class="Public pattern_header">
        <div class="skin_width">
            <a href="#" class="menuclick" id="MENUTOGGLE" >
                <img alt="Menu" src="<%=SkinPath %>images/burger-menu.svg"  />
            </a>
            <a href="/" class="logo_style">
                <img alt="Rotary District <%= System.Configuration.ConfigurationManager.AppSettings("DistrictId") %>" src="<%=SkinPath %>images/rotary-district<%= AIS.Const.DISTRICT_ID %>.png" />
            </a>
            <h1><ais1:NAME runat="server" ></ais1:NAME></h1>
        </div>
    </header>

    <section class="skin_menu">
      <div class="menu_bar">
        <div class="Public Club">
          <div class="mobile_nav">
                <nav>
                    <div class="MenuMob"></div>
                    <div ID="MENUMOB" class="Menu">
                        <div class="icons_menu">
                            <%If Not Request.IsAuthenticated Then%>
                                <div class="icon_user text-center">
						            <a href="https://www.rotary.org/" class="Breadcrumb HeadUser">Le Rotary International</a> | 
						            <a href="<%= System.Configuration.ConfigurationManager.AppSettings("DistrictUrl") %>" class="Breadcrumb HeadUser">Le District <%= System.Configuration.ConfigurationManager.AppSettings("DistrictId") %></a>
                                    <div class="relative">
                                        <a href="/Espace-Membre" class="btn-connexion" title="connexion">connexion</a>
                                    </div>
                                </div>
                            <% End If%>

                            <%If Request.IsAuthenticated Then%>
                                <div class="icon_user connected text-center">
						            <a href="https://www.rotary.org/" class="Breadcrumb HeadUser">Le Rotary International</a> | 
						            <a href="<%= System.Configuration.ConfigurationManager.AppSettings("DistrictUrl") %>" class="Breadcrumb HeadUser">Le District <%= System.Configuration.ConfigurationManager.AppSettings("DistrictId") %></a>
                                    <p class="HeadUser text-center"><% Response.Write("Bienvenue " + Entities.Users.UserController.GetCurrentUserInfo.DisplayName) %></p>
                                    <div class="relative">
                                        <a href="/Espace-Membre/Mon-profil" title="Mon profil" class="HeadUser btn-profil">Mon profil</a> | 
                                        <a href="/Espace-Membre" title="Mon profil" class="HeadUser btn-profil">Espace Membre</a> | 
                                        <dnn:login runat="server" id="LOGIN2" cssclass="HeadUser btn-logoff" />  
                                    </div>
                                </div>
                            <% End If%>
                        </div>
					    <ais:MENU runat="server"  RootTabID='<%# AIS.Const.MENU_CLUB_ROOT_TABID %>' />
                    </div>
                </nav>
          </div>
        </div>
      </div>
    </section>
</div>



<div class="pc_display">
    <header class="Public pattern_header">
        <div class="skin_width">
            <a href="/" class="logo_style">
                <img alt="Rotary District <%= System.Configuration.ConfigurationManager.AppSettings("DistrictId") %>" src="<%=SkinPath %>images/rotary-district<%= AIS.Const.DISTRICT_ID %>.png" />
            </a>
            <div class="icons_menu">
                <%If Not Request.IsAuthenticated Then%>

                    <div class="icon_user text-right">
                        <h1><ais1:NAME runat="server" ></ais1:NAME></h1>
                        <a href="/Espace-Membre" class="btn-connexion" title="connexion">connexion</a>
                        <div class="user_style">
                            <a href="https://www.rotary.org/" class="Breadcrumb HeadUser">Le Rotary International</a> | 
						    <a href="<%= System.Configuration.ConfigurationManager.AppSettings("DistrictUrl") %>" class="Breadcrumb HeadUser">Le District <%= System.Configuration.ConfigurationManager.AppSettings("DistrictId") %></a>
                        </div>
                    </div>
                <% End If%>

                <%If Request.IsAuthenticated Then%>
                    <div class="icon_user text-right connected">
                        <div id="Login">
                            <h1><ais1:NAME runat="server" ></ais1:NAME></h1>
                            <a href="https://www.rotary.org/" class="Breadcrumb HeadUser">Le Rotary International</a> | 
						    <a href="<%= System.Configuration.ConfigurationManager.AppSettings("DistrictUrl") %>" class="Breadcrumb HeadUser">Le District <%= System.Configuration.ConfigurationManager.AppSettings("DistrictId") %></a>
                        </div>
                        <span class="HeadUser"><% Response.Write("Bienvenue " + Entities.Users.UserController.GetCurrentUserInfo.DisplayName) %></span> | 
                        <a href="/Espace-Membre/Mon-profil" title="Mon profil" class="HeadUser btn-profil">Mon profil</a> | 
                        <a href="/Espace-Membre" title="Mon profil" class="HeadUser btn-profil">Espace Membre</a> | 
                        <dnn:login runat="server" id="LOGIN3" cssclass="HeadUser btn-logoff" />              
                    </div>
                <% End If%>
            </div>
        </div>
    </header>

    <section class="skin_menu">
        <div class="menu_bar">
            <div class="Public Club">
                <nav class="Menu skin_width">
                    <ais:MENU runat="server" ID="MENU1" RootTabID='<%# AIS.Const.MENU_CLUB_ROOT_TABID %>' />
                </nav>
            </div>
        </div>
    </section>
</div>


