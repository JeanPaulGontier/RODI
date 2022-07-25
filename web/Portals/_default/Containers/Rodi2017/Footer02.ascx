<%@ Control language="vb" AutoEventWireup="false" Explicit="True" Inherits="DotNetNuke.UI.Containers.Container" %>
<%@ Register TagPrefix="dnn" TagName="ACTIONS" Src="~/Admin/Containers/SolPartActions.ascx" %>
<%@ Register TagPrefix="dnn" TagName="ICON" Src="~/Admin/Containers/Icon.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TITLE" Src="~/Admin/Containers/Title.ascx" %>
<%@ Register TagPrefix="dnn" TagName="VISIBILITY" Src="~/Admin/Containers/Visibility.ascx" %>
<%@ Register TagPrefix="dnn" TagName="ACTIONBUTTON" Src="~/Admin/Containers/ActionButton.ascx" %>

<div class="Footer02_style">
  <div class="Footer02_top_bg clearafter">
    <div class="c_icon">
      <dnn:ICON runat="server" id="dnnICON" />
    </div>
    <h2 class="c_title">
      <dnn:TITLE runat="server" id="dnnTITLE"  CssClass="c_title_black" />
    </h2>
  </div>
    <div class="Footer02_border"><div class="Footer02_top_border"></div></div>
  <div class="c_content_style">
    <div id="ContentPane" runat="server" class="Footer02_content"></div>
  </div>
</div>
