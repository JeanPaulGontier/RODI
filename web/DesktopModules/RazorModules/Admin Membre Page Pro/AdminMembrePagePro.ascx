<%@ Control AutoEventWireup="false" Language="C#" Inherits="DotNetNuke.Web.Razor.RazorModuleBase" %>
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