<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2016                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Settings.ascx.cs" Inherits="DesktopModules_AIS_Office_Club_Settings" %>

Site de  : <asp:RadioButtonList runat="server" ID="rbl_site" RepeatDirection="Horizontal"><asp:ListItem Text="District" Value="d"></asp:ListItem> <asp:ListItem Text="Club" Value ="c"></asp:ListItem> </asp:RadioButtonList>