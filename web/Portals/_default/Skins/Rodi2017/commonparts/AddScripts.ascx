<script type="text/javascript" src="/Resources/Shared/Scripts/jquery/jquery.hoverIntent.min.js"></script>
<script type="text/javascript" src="<%= TemplateSourceDirectory %>/StandardMenu/StandardMenu.js"></script>
<script type="text/javascript" src="<%= TemplateSourceDirectory %>/bootstrap/js/bootstrap.js"></script>
<script type="text/javascript" src="<%= TemplateSourceDirectory %>/js/jquery.fancybox.min.js"></script>
<script type="text/javascript" src="<%= TemplateSourceDirectory %>/js/jquery.easing.1.3.min.js"></script>
<script type="text/javascript" src="<%= TemplateSourceDirectory %>/js/jquery.trans-banner.min.js"></script>
<script type="text/javascript" src="<%= TemplateSourceDirectory %>/js/jquery.unoslider.js"></script>
<script type="text/javascript" src="<%= TemplateSourceDirectory %>/js/jquery.flexslider.min.js"></script>
<script type="text/javascript" src="<%= TemplateSourceDirectory %>/js/jquery.carouFredSel-6.2.1-packed.js"></script>
<script type="text/javascript" src="<%= TemplateSourceDirectory %>/js/jquery.touchSwipe.min.js"></script>
<script type="text/javascript" src="<%= TemplateSourceDirectory %>/js/jquery.accordion.js"></script>
<script type="text/javascript" src="<%= TemplateSourceDirectory %>/js/jquery.quovolver.js"></script>
<script type="text/javascript" src="<%= TemplateSourceDirectory %>/js/jquery.isotope.min.js"></script>
<script type="text/javascript" src="<%= TemplateSourceDirectory %>/js/digital_animate.js"></script>
<script type="text/javascript" src="<%= TemplateSourceDirectory %>/js/jquery.plugins.js"></script>
<!--[if !IE]><!-->
<script type="text/javascript" src="<%= TemplateSourceDirectory %>/js/jquery.piechart.js"></script>
<!--<![endif]-->
<!--[if gte IE 9]>
<script type="text/javascript" src="<%= TemplateSourceDirectory %>/js/jquery.piechart.js"></script>
<![endif]-->
<%If not IsUserAdmin() Then%>
<!--[if !IE]><!-->
<script type="text/javascript" src="<%= TemplateSourceDirectory %>/js/jquery-scrolltofixed-min.js"></script>
<script type="text/javascript">
//Header Fixed
jQuery(document).ready(function() {
	if ($(window).width() >= 1140){
	 $("#skin_menu").scrollToFixed();
	 $("#white_header").scrollToFixed();
	 $("#color_header").scrollToFixed();
	};
});
</script>
<!--<![endif]-->
<% End If%>
<script runat="server">
    Public Function IsUserAdmin() As Boolean
        Dim uinfo As DotNetNuke.Entities.Users.UserInfo = DotNetNuke.Entities.Users.UserController.GetCurrentUserInfo()
        If uinfo.UserID <> -1 Then
            If uinfo.IsInRole(DotNetNuke.Entities.Portals.PortalSettings.Current.AdministratorRoleName) Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function
</script>
<!--[if IE 9]>
<script type="text/javascript">
//Disable Animation:
jQuery(document).ready(function() {
	 $(".animation").css({"opacity": "1"});
});
</script>
<![endif]-->
<script type="text/javascript" src="<%= TemplateSourceDirectory %>/js/custom.js"></script>
