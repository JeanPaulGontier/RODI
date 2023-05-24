<%@ Control language="vb" AutoEventWireup="false" Explicit="True" Inherits="DotNetNuke.UI.Containers.Container" %>
<%@ Register TagPrefix="dnn" TagName="ICON" Src="~/Admin/Containers/Icon.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TITLE" Src="~/Admin/Containers/Title.ascx" %>
<%@ Register TagPrefix="dnn" TagName="ACTIONBUTTON" Src="~/Admin/Containers/ActionButton.ascx" %>

<div class="RoyalBlue_hb2_style">
  <div class="RoyalBlue_hb2_top clearafter">
    <div class="c_icon">
      <dnn:ICON runat="server" id="dnnICON" />
    </div>
    <h2 class="c_title">
      <dnn:TITLE runat="server" id="dnnTITLE"  CssClass="c_title_white" />
    </h2>
  </div>
  <div class="c_content_style">
    <div id="ContentPane" runat="server" class="RoyalBlue_hb2_content"></div>
  </div>
  <div class="RoyalBlue_shadow_l">
    <div class="RoyalBlue_shadow_r">
      <div class="RoyalBlue_shadow_c"></div>
    </div>
  </div>
</div>

