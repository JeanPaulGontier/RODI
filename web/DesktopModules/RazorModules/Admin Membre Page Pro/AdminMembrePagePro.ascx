<%@ Control AutoEventWireup="false" Language="C#" Inherits="DotNetNuke.Web.Razor.RazorModuleBase" %>
<script runat="server">
    protected override void OnInit(EventArgs e)
    {
            ServicesFramework.Instance.RequestAjaxScriptSupport();
            ServicesFramework.Instance.RequestAjaxAntiForgerySupport();
    }
</script>