<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NotificationIcon.ascx.cs" Inherits="NotificationIcon" %>
<script>
    var <%=PanelClientID%>Visible = false;
    function toggle<%=PanelClientID%>() {
        if (<%=PanelClientID%>Visible) {
            $("#<%=PanelClientID%>").fadeOut();
            <%=PanelClientID%>Visible = false;
        }
        else {
            $("#<%=PanelClientID%>").fadeIn();
            <%=PanelClientID%>Visible = true;
        }
            
    }
</script>
<%if (IsMobile) { %>    
    <%if (NotificationHelper.HaveUnopenedNotifications(PortalSettings.Current.UserId))  {  %>
        <a href="#" onclick="toggle<%=PanelClientID%>()" title="Notifications" class="relative p-1"><i class="fa fa-xl fa-bell"></i><span class="badge"></span></a>
    <%} else { %>
     <a href="#" onclick="toggle<%=PanelClientID%>()" title="Notifications" class="relative p-1"><i class="fa fa-xl fa-bell"></i></a>
    <%} %>
<%} else {  %>
    <%if (NotificationHelper.HaveUnopenedNotifications(PortalSettings.Current.UserId))  {  %>
    <a href="#" onclick="toggle<%=PanelClientID%>()" title="Notifications" class="relative"><i class="fa fa-bell"></i><span class="badge"></span></a>
    <%} else { %>
     <a href="#" onclick="toggle<%=PanelClientID%>()" title="Notifications" class="relative"><i class="fa fa-bell"></i></a>
    <%} %>
<% } %>