<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Bureau.ascx.cs" Inherits="DesktopModules_AIS_Club_Bureau_Control" %>

<asp:Literal runat="server" ID="L_Text"></asp:Literal>
<script runat="server">
    protected override void OnInit(EventArgs e)
    {
        if(UserController.Instance.GetCurrentUserInfo().UserID>-1)
        {
            ServicesFramework.Instance.RequestAjaxScriptSupport();
            ServicesFramework.Instance.RequestAjaxAntiForgerySupport();
        }       
    }
</script>