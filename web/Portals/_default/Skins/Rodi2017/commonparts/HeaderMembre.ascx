<!--start skin header-->
<header class="pattern_header Membre">
  <div class="clearafter">
    <div class="logo_style">
        <a href="/">
            <div><img alt="Rotary District <%= System.Configuration.ConfigurationManager.AppSettings("DistrictId") %>" src="<%=SkinPath %>images/rotary-blanc.svg" />
            <span class="districtNum">District <%= System.Configuration.ConfigurationManager.AppSettings("DistrictId")%></span></div>
            <div><span>Espace Membre</span>
            <%If AIS.Functions.CurrentCric > 0 Then %>
            <span><%= AIS.Functions.CurrentClub.name %></span>
            <%End If %></div>
        </a>
    </div>
    <!--start user icons-->
    <div class="icons_menu clearafter">
        <%If Not Request.IsAuthenticated Then%>
            <div class="icon_user membre text-right">
                <div class="user_style">
                    <a href="https://www.rotary.org/" class="HeadUser">Rotary International</a> | 
                    <a href="https://www.rotary.org/fr/search/club-finder" class="HeadUser Localiser">Recherche de club</a>
                </div>
            </div>
        <% End If%>

        <%If Request.IsAuthenticated Then%>
            <div class="icon_user membre connected text-right">
                <div id="Login">
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
    <!--end user icons-->
    <div class="headerpane_style">
      <div runat="server" id="HeaderPane" class="headerpane"></div>
  </div>
</header>
<!--end skin header-->
<!--start skin menu-->
<section id="skin_menu_membre">
  <div class="menu_bar_membre clearafter">
    <div class="Membre">
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
                        $('.MNV1').animate({
                            left: (document.getElementsByClassName('personabar-visible').length>0)?'80px':'0px' },500, 'linear');
                        
                    }
                    else {
                        $('.MNV1').animate({ left: '-800' }, 500, 'linear');
                    
                        $('.MenuMob').css({ opacity: 0.6, visibility: "visible" }).animate({ opacity: 0 }, 200, 'linear', function () {
                            $('.MenuMob').css('visibility', 'hidden');                        
                        });
                }
            })
        })
        </script>
      <div class="mobile_nav">
            <nav class="mobile_display">
                <a href="#" class="menuclick" id="MENUTOGGLE" ><img alt="Menu" class="click_img" src="<%=SkinPath %>images/burger-menu-blanc.svg"  /></a>
                <div class="MenuMob"></div>
                <div ID="MENUMOB" class="Menu">
                     <ais:MENU runat="server"  />
                </div>
            </nav>
      </div>
      <nav class="Menu">
          <ais:MENU runat="server" ID="MENU1" RootTabID="114" />
      </nav>
    </div>
  </div>
</section>
<!--end skin menu-->
