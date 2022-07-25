<%@ Control language="vb" AutoEventWireup="false" Explicit="True" Inherits="DotNetNuke.UI.Containers.Container" %>
<script type="text/javascript" src="<%= TemplateSourceDirectory %>/js/greensock.js"></script>
<script type="text/javascript" src="<%= TemplateSourceDirectory %>/js/layerslider.kreaturamedia.jquery.js"></script>
<script type="text/javascript" src="<%= TemplateSourceDirectory %>/js/layerslider.transitions.js"></script>
<link href="<%= TemplateSourceDirectory %>/layerslider/layerslider.css" type="text/css" rel="stylesheet" />

<div class="layerslider_container">
  <div id="ContentPane" runat="server"></div>
</div>
<script type="text/javascript">
//For LayerSlider:
jQuery(document).ready(function() {
    $("#layerslider").layerSlider({
		responsive: false,
		responsiveUnder: 1600,
		layersContainer: 1600,
		skin: 'fullwidth',
		skinsPath: '/Portals/_default/Containers/Spring-RoyalBlue/layerslider/skins/',
		thumbnailNavigation : 'none',
		navButtons: false,
		navStartStop: false
	});
}); 

//For LayerSlider2:
jQuery(document).ready(function() {
    $("#layerslider2").layerSlider({
		skin: 'fullwidth',
		skinsPath: '/Portals/_default/Containers/Spring-RoyalBlue/layerslider/skins/',
		thumbnailNavigation : 'none',
		navButtons: false,
		navStartStop: false
	});
}); 
</script>