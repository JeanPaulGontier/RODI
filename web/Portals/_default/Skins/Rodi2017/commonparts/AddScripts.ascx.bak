<script type="text/javascript" src="/Resources/Shared/Scripts/jquery/jquery.hoverIntent.min.js"></script>
<script type="text/javascript" src="<%= TemplateSourceDirectory %>/StandardMenu/StandardMenu.js"></script>
<script type="text/javascript" src="<%= TemplateSourceDirectory %>/bootstrap/js/bootstrap.min.js"></script>
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
