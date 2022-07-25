<%@ Control language="vb" AutoEventWireup="false" Explicit="True" Inherits="DotNetNuke.UI.Containers.Container" %>
<%@ Register TagPrefix="dnn" TagName="ICON" Src="~/Admin/Containers/Icon.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TITLE" Src="~/Admin/Containers/Title.ascx" %>

<div class="RoyalBlue_ch1_style">
  <div class="RoyalBlue_ch1_top clearafter">
    <div class="c_icon">
      <dnn:ICON runat="server" id="dnnICON" />
    </div>
    <h2 class="c_title">
      <dnn:TITLE runat="server" id="dnnTITLE"  CssClass="c_title_white" />
    </h2>
  </div>
  <div class="c_content_style">
    <div id="ContentPane" runat="server" class="RoyalBlue_ch1_content"></div>
  </div>
</div>
