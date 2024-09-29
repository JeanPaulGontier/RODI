using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Yemon.dnn;
using AIS;
using System.Data.SqlClient;
using DotNetNuke.Framework;
using Functions = AIS.Functions;

public partial class DesktopModules_AIS_OuKiKan_Control : YemonPortalModuleBase
{
    public bool editable
    {
        get
        {
            return UserInfo.IsSuperUser ||
                   UserInfo.IsInRole(Const.ADMIN_ROLE) ||
                   UserInfo.IsInRole(Const.ROLE_ADMIN_CLUB) ||
                   UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT) ||
                   AIS.DataMapping.isADG(AIS.Functions.GetCurrentMember().id);

        }
    }
    public int cric
    {
        get
        {
            return Functions.CurrentCric;

        }
    }


    public string mode
    {
        get
        {
            return "club";// + Settings["mode"];

        }
    }

    public string context
    {
        get
        {
            if (ContextGuid.Value != "")
            {

            }
            else
            {
                ContextGuid.Value = Guid.NewGuid().ToString();
                Application[ContextGuid.Value + ":mode"] = mode;
                Application[ContextGuid.Value + ":cric"] = Functions.CurrentCric;

            }
            return ContextGuid.Value;
        }
    }

    public List<Contact.List> recipients
    {
        get
        {
            ContactsHelper contactsHelper = new ContactsHelper();

            return contactsHelper.GetContactsLists(cric);
        }
    }
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        ServicesFramework.Instance.RequestAjaxScriptSupport();
        ServicesFramework.Instance.RequestAjaxAntiForgerySupport();
    }

    public int currentcric
    {
        get
        {
            return AIS.Functions.CurrentCric;
        }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {

    }
}