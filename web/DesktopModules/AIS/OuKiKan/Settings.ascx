<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Settings.ascx.cs" Inherits="DesktopModules_AIS_Admin_News_Liste_Settings" %>
<%@ Register TagPrefix="dnn" TagName="TextEditor" Src="~/controls/TextEditor.ascx" %>
<div class="mspsContent dnnClear">
<h3 class="dnnFormSectionHead">Texte message de 1ere notification :</h3>
    <dnn:texteditor id="txtNotif1" runat="server" width="100%" height="300px" />
<h3 class="dnnFormSectionHead">Texte message de 2e notification :</h3>
    <dnn:TextEditor ID="txtNotif2" runat="server" Width="100%" Height="300px" />

<label>Champs utilisables dans les textes : </label>
<ul>
    <li>#meeting.dtstart#</li>
    <li>#meeting.dtend#</li>
    <li>#meeting.dtendactive#</li>
    <li>#meeting.name#</li>
    <li>#meeting.link#</li>
</ul>
</div>
