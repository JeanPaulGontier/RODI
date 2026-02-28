<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ClubLogo.ascx.cs" Inherits="AIS_ClubLogo" %>
<%if (club!=null && club.GetLogo()!="") {%>
<img alt="Rotary Club <%=club.name %>" src="<%=club.GetLogo() %>" />
<% } else {  %>
<img alt="Rotary District <%= AIS.Const.DISTRICT_ID %>" src="<%=SkinPath %>images/rotary-district<%= AIS.Const.DISTRICT_ID %>.png" />
<% } %>