
#region Copyrights

// RODI - https://rodi-platform.org/                                    
// Copyright(c) 2012-2018                                               
// by : Jean-Paul GONTIER(Rotary Club Sophia Antipolis - District 1730)
//
//GNU LESSER GENERAL PUBLIC LICENSE
//Version 3, 29 June 2007 Copyright (C) 2007
//Free Software Foundation, Inc. <http://fsf.org/> Everyone is permitted to copy and distribute verbatim copies of this license document, but changing it is not allowed.
//This version of the GNU Lesser General Public License incorporates the terms and conditions of version 3 of the GNU General Public License, supplemented by the additional permissions listed below.

//0. Additional Definitions.

//As used herein, "this License" refers to version 3 of the GNU Lesser General Public License, and the "GNU GPL" refers to version 3 of the GNU General Public License.
//"The Library" refers to a covered work governed by this License, other than an Application or a Combined Work as defined below.
//An "Application" is any work that makes use of an interface provided by the Library, but which is not otherwise based on the Library.Defining a subclass of a class defined by the Library is deemed a mode of using an interface provided by the Library.
//A "Combined Work" is a work produced by combining or linking an Application with the Library. The particular version of the Library with which the Combined Work was made is also called the "Linked Version".
//The "Minimal Corresponding Source" for a Combined Work means the Corresponding Source for the Combined Work, excluding any source code for portions of the Combined Work that, considered in isolation, are based on the Application, and not on the Linked Version.
//The "Corresponding Application Code" for a Combined Work means the object code and/or source code for the Application, including any data and utility programs needed for reproducing the Combined Work from the Application, but excluding the System Libraries of the Combined Work.

//1. Exception to Section 3 of the GNU GPL.

//You may convey a covered work under sections 3 and 4 of this License without being bound by section 3 of the GNU GPL.

//2. Conveying Modified Versions.

//If you modify a copy of the Library, and, in your modifications, a facility refers to a function or data to be supplied by an Application that uses the facility (other than as an argument passed when the facility is invoked), then you may convey a copy of the modified version:
//a) under this License, provided that you make a good faith effort to ensure that, in the event an Application does not supply the function or data, the facility still operates, and performs whatever part of its purpose remains meaningful, or
//b) under the GNU GPL, with none of the additional permissions of this License applicable to that copy.

//3. Object Code Incorporating Material from Library Header Files.

//The object code form of an Application may incorporate material from a header file that is part of the Library. You may convey such object code under terms of your choice, provided that, if the incorporated material is not limited to numerical parameters, data structure layouts and accessors, or small macros, inline functions and templates(ten or fewer lines in length), you do both of the following:
//a) Give prominent notice with each copy of the object code that the Library is used in it and that the Library and its use are covered by this License.
//b) Accompany the object code with a copy of the GNU GPL and this license document.

//4. Combined Works.

//You may convey a Combined Work under terms of your choice that, taken together, effectively do not restrict modification of the portions of the Library contained in the Combined Work and reverse engineering for debugging such modifications, if you also do each of the following:
//a) Give prominent notice with each copy of the Combined Work that the Library is used in it and that the Library and its use are covered by this License.
//b) Accompany the Combined Work with a copy of the GNU GPL and this license document.
//c) For a Combined Work that displays copyright notices during execution, include the copyright notice for the Library among these notices, as well as a reference directing the user to the copies of the GNU GPL and this license document.
//d) Do one of the following:
//0) Convey the Minimal Corresponding Source under the terms of this License, and the Corresponding Application Code in a form suitable for, and under terms that permit, the user to recombine or relink the Application with a modified version of the Linked Version to produce a modified Combined Work, in the manner specified by section 6 of the GNU GPL for conveying Corresponding Source.
//1) Use a suitable shared library mechanism for linking with the Library. A suitable mechanism is one that (a) uses at run time a copy of the Library already present on the user's computer system, and (b) will operate properly with a modified version of the Library that is interface-compatible with the Linked Version.
//e) Provide Installation Information, but only if you would otherwise be required to provide such information under section 6 of the GNU GPL, and only to the extent that such information is necessary to install and execute a modified version of the Combined Work produced by recombining or relinking the Application with a modified version of the Linked Version. (If you use option 4d0, the Installation Information must accompany the Minimal Corresponding Source and Corresponding Application Code. If you use option 4d1, you must provide the Installation Information in the manner specified by section 6 of the GNU GPL for conveying Corresponding Source.)

//5. Combined Libraries.

//You may place library facilities that are a work based on the Library side by side in a single library together with other library facilities that are not Applications and are not covered by this License, and convey such a combined library under terms of your choice, if you do both of the following:
//a) Accompany the combined library with a copy of the same work based on the Library, uncombined with any other library facilities, conveyed under the terms of this License.
//b) Give prominent notice with the combined library that part of it is a work based on the Library, and explaining where to find the accompanying uncombined form of the same work.

//6. Revised Versions of the GNU Lesser General Public License.

//The Free Software Foundation may publish revised and/or new versions of the GNU Lesser General Public License from time to time. Such new versions will be similar in spirit to the present version, but may differ in detail to address new problems or concerns.
//Each version is given a distinguishing version number. If the Library as you received it specifies that a certain numbered version of the GNU Lesser General Public License "or any later version" applies to it, you have the option of following the terms and conditions either of that published version or of any later version published by the Free Software Foundation. If the Library as you received it does not specify a version number of the GNU Lesser General Public License, you may choose any version of the GNU Lesser General Public License ever published by the Free Software Foundation.
//If the Library as you received it specifies that a proxy can decide whether future versions of the GNU Lesser General Public License shall apply, that proxy's public statement of acceptance of any version is permanent authorization for you to choose that version for the Library.

#endregion Copyrights


using AIS;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Web.Client.ClientResourceManagement;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DesktopModules_AIS_Ticketing_Settings : ModuleSettingsBase
{
    Ticketing ticketing;

    //protected override void OnInit(EventArgs e)
    //{
    //    ClientResourceManager.RegisterStyleSheet(Parent.Page, "https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css");

    //    ClientResourceManager.RegisterScript(Parent.Page, "https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js");
    //    base.OnInit(e);
    //}
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
            return;

        if (!Settings.Contains("guid"))
        {
            Default_Settings();           
        }

        Init_Fields();


    }
    void Default_Settings()
    {
        ModuleController objModules = new ModuleController();
        objModules.UpdateModuleSetting(ModuleId, "guid", Guid.NewGuid().ToString());
        Ticketing ticketing = new Ticketing();
        for(int i=1;i<=20;i++)
        {
            Ticketing.Option opt = new Ticketing.Option();
            opt.name = "Option " + i;
            opt.description = "Description " + i;
            opt.guid = Guid.NewGuid().ToString();
            opt.endsaledate = DateTime.Now.AddDays(10);
            opt.startsaledate = DateTime.Now;
            opt.price = 123;
            opt.enabled = false;
            ticketing.options.Add(opt);
        }
        ticketing.name = "Ma billeterie";
        ticketing.description = "Description de la billeterie";


        string ts = Functions.Serialize(ticketing);
        objModules.UpdateModuleSetting(ModuleId, "ticketing", ts);
    }

    void Init_Fields()
    {
        try { 
            TXT_GUID.Text = "" + Settings["guid"];
            if (Settings.Contains("ticketing"))
            {
                TXT_TICKETING.Text = "" + Settings["ticketing"];
        
                string ts = "" + Settings["ticketing"];
                ticketing = (Ticketing)Functions.Deserialize(ts, typeof(Ticketing));

                #region administrative fields
                TXT_DESCRIPTION.Text = ticketing.description;
                TXT_NAME.Text = ticketing.name;
                TXT_EVENTSTARTDATE.Text = ticketing.eventstartdate.ToString();
                TXT_EVENTENDDATE.Text = ticketing.eventenddate.ToString();
                if(ticketing.opened)
                    RB_Opened.SelectedValue = "YES";
                else
                    RB_Opened.SelectedValue = "NO";
                TXT_ADDRESS.Text = ticketing.address;
                TXT_LATITUDE.Text = ""+ticketing.latitude;
                TXT_LONGITUDE.Text = ""+ticketing.longitude;
                TXT_EMAIL.Text = ticketing.email;
                TXT_CONTACT_NAME.Text = ticketing.contactname;
                TXT_CONTACT_PHONE.Text = ticketing.contactphone;
                TXT_CONTACT_EMAIL.Text = ticketing.contactemail;
                TXT_LABEL_COMMENT.Text = ticketing.labelcomment;

                #endregion

                #region technical fields
                TXT_ADMINROLE.Text = ticketing.adminrole;
                TXT_READONLYROLE.Text = ticketing.readonlyrole;
                TXT_EVENTURL.Text = ticketing.eventurl;
                TXT_TICKETURL.Text = ticketing.ticketurl;
                TXT_RECEIPTURL.Text = ticketing.receipturl;
                #endregion

                #region payment methods
                TXT_STRIPE_PUBLIC_KEY.Text = ticketing.stripepublickey;
                TXT_STRIPE_PRIVATE_KEY.Text = ticketing.stripeprivatekey;
                TXT_STRIPEIPNURL.Text = ticketing.stripeipnurl;
                TXT_STRIPELOGOURL.Text = ticketing.stripelogourl;
                if (ticketing.stripeactivated)
                    RB_STRIPEACTIVATED.SelectedValue = "YES";
                else
                    RB_STRIPEACTIVATED.SelectedValue = "NO";


                TXT_PAYPALEMAIL.Text = ticketing.paypalemail;
                TXT_PAYPALIPNURL.Text = ticketing.paypalipnurl;
                if (ticketing.paypalactivated)
                    RB_PAYPALACTIVATED.SelectedValue = "YES";
                else
                    RB_PAYPALACTIVATED.SelectedValue = "NO";


                TXT_BANK_TRANSFERT_IBAN.Text = ticketing.banktransfertiban;
                TXT_BANK_TRANSFERT_TEXT.Text = ticketing.banktransferttext;
                if (ticketing.banktransfertactivated)
                    RB_BANKTRANSFERTACTIVATED.SelectedValue = "YES";
                else
                    RB_BANKTRANSFERTACTIVATED.SelectedValue = "NO";


                TXT_BANK_CHEQUE_DEST.Text = ticketing.bankchequedest;
                TXT_BANK_CHEQUE_TEXT.Text = ticketing.bankchequetext;
                if (ticketing.bankchequeactivated)
                    RB_BANKCHEQUEACTIVATED.SelectedValue = "YES";
                else
                    RB_BANKCHEQUEACTIVATED.SelectedValue = "NO";

                ViewState["options"] = ticketing.options;
                OptionsDataBind();

                ViewState["fields"] = ticketing.fields;
                FieldsDataBind();

                #endregion
            }
        }
        catch(Exception ee)
        {
            Functions.Error(ee);
        }
    }

    public override void UpdateSettings()
    {
        base.UpdateSettings();

        ModuleController objModules = new ModuleController();

        string ts = "" + Settings["ticketing"];
        ticketing = (Ticketing)Functions.Deserialize(ts, typeof(Ticketing));

        #region administrative fields
        ticketing.description = TXT_DESCRIPTION.Text;
        ticketing.name = TXT_NAME.Text;
        ticketing.opened = RB_Opened.SelectedValue == "YES";
        DateTime.TryParse("" + TXT_EVENTSTARTDATE.Text, out ticketing.eventstartdate);
        DateTime.TryParse("" + TXT_EVENTENDDATE.Text, out ticketing.eventenddate);
        ticketing.address = TXT_ADDRESS.Text;
        ticketing.latitude = 0;
        double.TryParse("" + TXT_LATITUDE.Text, out ticketing.latitude);
        ticketing.longitude = 0;
        double.TryParse("" + TXT_LONGITUDE.Text, out ticketing.longitude);
        ticketing.email = TXT_EMAIL.Text;
        ticketing.contactname = TXT_CONTACT_NAME.Text;
        ticketing.contactphone = TXT_CONTACT_PHONE.Text;
        ticketing.contactemail = TXT_CONTACT_EMAIL.Text;
        ticketing.labelcomment = TXT_LABEL_COMMENT.Text;
        #endregion

        #region technical fields
        ticketing.adminrole = TXT_ADMINROLE.Text;
        ticketing.readonlyrole = TXT_READONLYROLE.Text;
        ticketing.eventurl = TXT_EVENTURL.Text;
        ticketing.ticketurl = TXT_TICKETURL.Text;
        ticketing.receipturl = TXT_RECEIPTURL.Text;
        #endregion

        #region payment methods
        ticketing.stripepublickey = TXT_STRIPE_PUBLIC_KEY.Text;
        ticketing.stripeprivatekey = TXT_STRIPE_PRIVATE_KEY.Text;
        ticketing.stripeipnurl = TXT_STRIPEIPNURL.Text;
        ticketing.stripelogourl = TXT_STRIPELOGOURL.Text;
        ticketing.stripeactivated = RB_STRIPEACTIVATED.SelectedValue == "YES";

        ticketing.paypalemail = TXT_PAYPALEMAIL.Text;
        ticketing.paypalipnurl = TXT_PAYPALIPNURL.Text;
        ticketing.paypalactivated = RB_PAYPALACTIVATED.SelectedValue == "YES";

        ticketing.banktransfertiban = TXT_BANK_TRANSFERT_IBAN.Text;
        ticketing.banktransferttext = TXT_BANK_TRANSFERT_TEXT.Text;
        ticketing.banktransfertactivated = RB_BANKTRANSFERTACTIVATED.SelectedValue == "YES";

        ticketing.bankchequedest = TXT_BANK_CHEQUE_DEST.Text;
        ticketing.bankchequetext = TXT_BANK_CHEQUE_TEXT.Text;
        ticketing.bankchequeactivated = RB_BANKCHEQUEACTIVATED.SelectedValue == "YES";

        ticketing.options = (List<Ticketing.Option>)ViewState["options"];
        ticketing.fields = (List<Ticketing.Field>)ViewState["fields"];
        #endregion

        TXT_TICKETING.Text = Functions.Serialize(ticketing);
        objModules.UpdateModuleSetting(ModuleId, "ticketing", TXT_TICKETING.Text);


        Store_To_DB(ticketing.guid, ticketing.name, TXT_TICKETING.Text);


    }

    protected void BT_Default_Click(object sender, EventArgs e)
    {
        Default_Settings();
        Init_Fields();
    }

    protected void BT_Import_Click(object sender, EventArgs e)
    {
        try
        {
            string ts = "" + TXT_IMPORT.Text;
            if (ts.Trim().Equals(""))
                return;
            Ticketing ticketimport = (Ticketing)Functions.Deserialize(ts, typeof(Ticketing));

            
            ModuleController objModules = new ModuleController();
            objModules.UpdateModuleSetting(ModuleId, "guid", ticketimport.guid);
            TXT_TICKETING.Text = Functions.Serialize(ticketimport);
            objModules.UpdateModuleSetting(ModuleId, "ticketing", TXT_TICKETING.Text);

            Store_To_DB(ticketimport.guid, ticketimport.name, TXT_TICKETING.Text);

            Init_Fields();
        }
        catch(Exception ee)
        {
            Functions.Error(ee);
        }
    }

    void Store_To_DB(string guid,string name, string parms)
    {
        SqlConnection conn = new SqlConnection(Config.GetConnectionString());
        SqlCommand sql;
        SqlTransaction trans;
        try
        {
            conn.Open();
            trans = conn.BeginTransaction();
            sql = new SqlCommand("DELETE ais_ticketing WHERE guid='_"+guid+"'", conn, trans);
           
            sql.ExecuteNonQuery();

            sql = new SqlCommand("UPDATE ais_ticketing SET guid='_'++guid, dt=getdate() WHERE guid=@guid", conn,trans);
            sql.Parameters.AddWithValue("guid", guid);
            sql.ExecuteNonQuery();

            sql = new SqlCommand("INSERT INTO ais_ticketing (guid,dt,name,parms) VALUES (@guid,getdate(),@name,@parms)", conn, trans);
            sql.Parameters.AddWithValue("guid", guid);
            sql.Parameters.AddWithValue("name", name);
            sql.Parameters.AddWithValue("parms", parms);
            sql.ExecuteNonQuery();

            trans.Commit();

        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
        finally
        {
            conn.Close();
        }
    }

 
    void OptionsDataBind()
    {
        G_Options.DataSource = ViewState["options"];
        G_Options.DataBind();
    }

    protected void G_Options_EditCommand(object source, DataGridCommandEventArgs e)
    {
        G_Options.EditItemIndex = e.Item.ItemIndex;
        OptionsDataBind();
    }
    protected void G_Options_UpdateCommand(object source, DataGridCommandEventArgs e)
    {
        try
        {
            List<Ticketing.Option> options = (List<Ticketing.Option>)ViewState["options"];
            TextBox name = e.Item.FindControl("name") as TextBox;
            TextBox description = e.Item.FindControl("description") as TextBox;
            TextBox price = e.Item.Cells[1].Controls[0] as TextBox;
            TextBox startsaledate = e.Item.Cells[2].Controls[0] as TextBox;
            TextBox endsaledate = e.Item.Cells[3].Controls[0] as TextBox;
            TextBox maxqty = e.Item.Cells[4].Controls[0] as TextBox;

            options[e.Item.ItemIndex].name = name.Text;
            options[e.Item.ItemIndex].description = description.Text;

            double p;
            double.TryParse("" + price.Text, out p);
            options[e.Item.ItemIndex].price = p;

            DateTime d;
            DateTime.TryParse("" + startsaledate.Text, out d);
            options[e.Item.ItemIndex].startsaledate = d;

            DateTime.TryParse("" + endsaledate.Text, out d);
            options[e.Item.ItemIndex].endsaledate = d;

            double m;
            double.TryParse("" + maxqty.Text, out m);
            options[e.Item.ItemIndex].maxqty = m;

            DropDownList dl = e.Item.FindControl("enabled") as DropDownList;
            options[e.Item.ItemIndex].enabled = dl.SelectedValue.Equals("YES");

            G_Options.EditItemIndex = -1;
            OptionsDataBind();
        }
        catch (Exception ee)
        {
        }


    }
    protected void BT_Add_Option_Click(object sender, EventArgs e)
    {
        List<Ticketing.Option> options = (List<Ticketing.Option>)ViewState["options"];
        Ticketing.Option option = new Ticketing.Option();
        options.Add(option);
        OptionsDataBind();

    }
    protected void G_Options_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        List<Ticketing.Option> options = (List<Ticketing.Option>)ViewState["options"];
        options.RemoveAt(e.Item.ItemIndex);
        OptionsDataBind();
    }



    void FieldsDataBind()
    {
        G_Fields.DataSource = ViewState["fields"];
        G_Fields.DataBind();
    }

    protected void G_Fields_EditCommand(object source, DataGridCommandEventArgs e)
    {
        G_Fields.EditItemIndex = e.Item.ItemIndex;
        FieldsDataBind();
    }

    protected void G_Fields_UpdateCommand(object source, DataGridCommandEventArgs e)
    {
        try
        {
            List<Ticketing.Field> fields = (List<Ticketing.Field>)ViewState["fields"];

            TextBox label = e.Item.Cells[0].Controls[0] as TextBox;
            TextBox value = e.Item.Cells[3].Controls[0] as TextBox;
            TextBox comment = e.Item.Cells[4].Controls[0] as TextBox;

            fields[e.Item.ItemIndex].label = label.Text;
            fields[e.Item.ItemIndex].value = value.Text;
            fields[e.Item.ItemIndex].comment = comment.Text;

            DropDownList dl = e.Item.FindControl("type") as DropDownList;
            fields[e.Item.ItemIndex].type = dl.SelectedValue;

            DropDownList dl1 = e.Item.FindControl("mandatory") as DropDownList;
            fields[e.Item.ItemIndex].mandatory = dl1.SelectedValue.Equals("YES");

            G_Fields.EditItemIndex = -1;
            FieldsDataBind();
        }
        catch (Exception ee)
        {
        }

    }
    protected void G_Fields_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        List<Ticketing.Field> fields = (List<Ticketing.Field>)ViewState["fields"];
        fields.RemoveAt(e.Item.ItemIndex);
        FieldsDataBind();
    }
    protected void BT_Add_Field_Click(object sender, EventArgs e)
    {
        List<Ticketing.Field> fields = (List<Ticketing.Field>)ViewState["fields"];
        Ticketing.Field field = new Ticketing.Field();
        fields.Add(field);
        FieldsDataBind();
    }

    
}