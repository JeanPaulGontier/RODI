using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Users;
using DotNetNuke.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using DotNetNuke.Web.Razor.Helpers;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Entities.Tabs;
using System.Collections;
using DotNetNuke.Services.Localization;
using DotNetNuke.Entities.Portals;

/// <summary>
/// Description résumée de BlockContent
/// </summary>
public partial class BlockContent :  DotNetNuke.Web.Razor.RazorModuleBase
{
  

    protected override void OnInit(EventArgs e)
    {
        string s = "" + this.ModuleContext.Settings["blockcontentsuffix"];
        
        if (s == "")
        {
            s = ""+this.ModuleContext.ModuleId;

            DotNetNuke.Entities.Modules.ModuleController obj = new DotNetNuke.Entities.Modules.ModuleController();
            obj.UpdateModuleSetting(this.ModuleContext.ModuleId, "blockcontentsuffix", s);
        }
        else if (s != "" + this.ModuleContext.ModuleId)
        {
            string item = ""+Yemon.dnn.Helpers.GetItem("blockscontent:" + s);
            s = "" + this.ModuleContext.ModuleId;

            Yemon.dnn.Helpers.SetItem("blockscontent:" + s, item, "" + UserController.Instance.GetCurrentUserInfo().UserID, keephistory: false);

            DotNetNuke.Entities.Modules.ModuleController obj = new DotNetNuke.Entities.Modules.ModuleController();
            obj.UpdateModuleSetting(this.ModuleContext.ModuleId, "blockcontentsuffix", s);
        }

        if (UserController.Instance.GetCurrentUserInfo().UserID > -1)
        {
            ServicesFramework.Instance.RequestAjaxScriptSupport();
            ServicesFramework.Instance.RequestAjaxAntiForgerySupport();
        }
        
    }
}