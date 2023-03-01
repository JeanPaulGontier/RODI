<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Control.ascx.cs" Inherits="DesktopModules_AIS_PDF_Slideshow_Control" %>
<script type="text/javascript" src="/DesktopModules/AIS/PDF SlideShow/turnjs4/extras/modernizr.2.5.3.min.js"></script>
<asp:Panel runat="server" CssClass="alert alert-danger" ID="P_Error" Visible="false"><asp:Literal runat="server" ID="L_Error"></asp:Literal></asp:Panel>
<div class="flipbook-viewport">
	<div class="container" >
		<div class="flipbook" style="background-color:gray">	
<%
    if(Images!=null)
    {
        for(int i=0;i<Images.Count;i++)
        {
%>
            <div style="background-image:url(<%= Request.RawUrl+"?image=" +i %>)"></div>
<%
        }
    }
%>
        </div>
	</div>
</div>
<script type="text/javascript">

    function loadApp() {

        // Create the flipbook

        $('.flipbook').turn({
            // Width

            width: <%=Width*2%>,

            // Height

            height: <%=Height %>,

            // Elevation

            elevation: 50,

            // Enable gradients

            gradients: true,

            // Auto center this flipbook

            autoCenter: false

        });
    }

    // Load the HTML4 version if there's not CSS transform

    yepnope({
        test: Modernizr.csstransforms,
        yep: ['/DesktopModules/AIS/PDF SlideShow/turnjs4/lib/turn.js'],
        nope: ['/DesktopModules/AIS/PDF SlideShow/turnjs4/lib/turn.html4.min.js'],
        both: ['/DesktopModules/AIS/PDF SlideShow/turnjs4/smaples/magazine/css/basic.css'],
        complete: loadApp
    });

</script>