<!--start skin header-->
<header class="Public pattern_header Club">
  <div class="skin_width clearafter">
    <div class="logo_style">
      <img alt="Rotary" src="<%=SkinPath %>images/rotary-logo-text.svg"  />
      <h1><ais1:NAME runat="server" ></ais1:NAME></h1>
    </div>
    <!--start user icons-->
    <div class="icons_menu clearafter">

        <%If Not Request.IsAuthenticated Then%>
            <div class="icon_user text-right">    
                <a href="connexion?returnurl=accueil" class="btn-connexion" title="connexion">connexion</a>
                <div class="user_style">
                    <a href="https://www.rotary.org/" class="Breadcrumb HeadUser">Le Rotary International</a> | 
                    <a href="<%= System.Configuration.ConfigurationManager.AppSettings("DistrictUrl") %>" class="Breadcrumb HeadUser">Le District <%= System.Configuration.ConfigurationManager.AppSettings("DistrictId") %></a>
                </div>
            </div>
        <% End If%>

        <%If Request.IsAuthenticated Then%>
            <div class="icon_user text-right connected">
                <div id="Login">
                    <a href="https://www.rotary.org/" class="Breadcrumb HeadUser">Le Rotary International</a> | 
                    <a href="<%= System.Configuration.ConfigurationManager.AppSettings("DistrictUrl") %>" class="Breadcrumb HeadUser">Le District <%= System.Configuration.ConfigurationManager.AppSettings("DistrictId") %></a>
                </div>
                <span class="HeadUser"><% Response.Write("Bienvenue " + Entities.Users.UserController.GetCurrentUserInfo.DisplayName) %></span> | 
                <a href="<%= System.Configuration.ConfigurationManager.AppSettings("DistrictUrl") %>/Espace-Membre/Mon-profil" title="Mon profil" class="HeadUser btn-profil">Mon profil</a> | 
                <a href="<%= System.Configuration.ConfigurationManager.AppSettings("DistrictUrl") %>/Espace-Membre" title="Mon profil" class="HeadUser btn-profil">Espace Membre</a> | 
                <dnn:login runat="server" id="LOGIN1" cssclass="HeadUser btn-logoff" />
                
            </div>
        <% End If%>

    </div>
    <!--end user icons-->
    <div class="headerpane_style">
      <div runat="server" id="HeaderPane" class="headerpane"></div>
    </div>
  </div>
</header>
<!--end skin header-->
<!--start skin menu-->
<section id="skin_menu">
  <div class="menu_bar clearafter">
    <div class="Public Club">
      <!--mobile menu button-->
    <script type="text/javascript">   
        $(document).ready(
            function () {
              //  $('.MenuMob').css({ opacity: 0.0, visibility: "hidden" })
                $('.MenuMob').click(function () {
                    $('.MNV1').animate({ left: '-800px' });

                    $('.MenuMob').css({ opacity: 0.6, visibility: "visible" }).animate({ opacity: 0 }, 200, function () {
                        $('.MenuMob').css('visibility', 'hidden');
                    });
                });
                $('#MENUTOGGLE').click(function () {
                    if ($('.MNV1').css("left").valueOf() == "-800px") {
                        $('.MNV1').css('opacity', '1.0');

                        
                        $('.MenuMob').css({ opacity: 0.0, visibility: "visible" }).animate({ opacity: 0.6 },200, 'linear');
                        $('.MNV1').animate({ left: '0' },500, 'linear');
                        $('.more-links').animate({ left: '0' },500, 'linear');
                        
                    
                    }
                    else {
                        $('.MNV1').animate({ left: '-800' },500, 'linear');
                        $('.more-links').animate({ left: '-800' },500, 'linear');
                        $('.MenuMob').css({ opacity: 0.6, visibility: "visible" }).animate({ opacity: 0 }, 200, 'linear', function () {
                            $('.MenuMob').css('visibility', 'hidden');                        
                        });
                }
            })
        })
    </script>

      <div class="mobile_nav">
            <nav class="mobile_display">
                <a href="#" class="menuclick" id="MENUTOGGLE" ><img alt="Menu" class="click_img" src="<%=SkinPath %>images/burger-menu.svg"  /></a>
                <div class="MenuMob"></div>
                <div ID="MENUMOB" class="Menu">
					<ais:MENU runat="server"  RootTabID="602"  />
					<div class="more-links">
						<a href="https://www.rotary.org/" class="Breadcrumb HeadUser">Le Rotary International</a> | 
						<a href="<%= System.Configuration.ConfigurationManager.AppSettings("DistrictUrl") %>" class="Breadcrumb HeadUser">Le District <%= System.Configuration.ConfigurationManager.AppSettings("DistrictId") %></a>
					</div>
                </div>
            </nav>
      </div>
        <nav class="Menu skin_width pc_display">
          <ais:MENU runat="server" ID="MENU1" RootTabID="602" />
      </nav>
    </div>
  </div>
</section>
<!--end skin menu-->
