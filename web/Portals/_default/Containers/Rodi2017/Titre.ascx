<%@ Control language="vb" AutoEventWireup="false" Explicit="True" Inherits="DotNetNuke.UI.Containers.Container" %>
<%@ Register TagPrefix="dnn" TagName="ICON" Src="~/Admin/Containers/Icon.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TITLE" Src="~/Admin/Containers/Title.ascx" %>

<div class="RoyalBlue_ct2_style">
  <div class="RoyalBlue_ct2_top clearafter">
    <div class="c_icon">
      <dnn:ICON runat="server" id="dnnICON" />
    </div>
    <div class="c_title">
      <dnn:TITLE runat="server" id="dnnTITLE"  CssClass="c_title_RoyalBlue" />
    </div>
  </div>
  <div class="c_content_style">
    <div id="ContentPane" runat="server" class="RoyalBlue_ct2_content"></div>
  </div>
</div>