<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Control.ascx.cs" Inherits="DesktopModules_AIS_Agenda_Gouverneur_Control" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.Client.ClientResourceManagement" Assembly="DotNetNuke.Web.Client" %>
<div>
    <table style="100%" class="table table-striped" ng-show="agenda">
        <% foreach (var e in events) { %>
        <tr>
            <td><%=e.title%></td>
            <td><%=e.dt%></td>
            <td><%=e.hr%></td>           
        </tr>
        <%} %>
    </table>
</div>