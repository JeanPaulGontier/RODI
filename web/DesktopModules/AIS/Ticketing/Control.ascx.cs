
#region Copyrights

// RODI - https://rodi-platform.org/                                    
// Copyright(c) 2012-2019                                              
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNetNuke.Entities.Modules;
using System.IO;
using System.Drawing;
using Telerik.Web.UI;
using DotNetNuke.Security.Roles;
using DotNetNuke.Entities.Users;
using AIS;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DotNetNuke.Common.Utilities;
using System.Collections.Specialized;
using System.Text;
using System.Net;
using DotNetNuke.Common;
using DotNetNuke.UI.Skins;
using DotNetNuke.Framework;
using Stripe.Checkout;
using Stripe;
using System.Web.UI.WebControls.WebParts;


/// <summary>
/// URL Validation payment paypal
/// https://www.rotary1730.org/billetterie.aspx?ipn_track_id=123&payment_status=completed&item_number=10001
/// URL Rembourssement payment paypal
/// https://www.rotary1730.org/billetterie.aspx?ipn_track_id=123&payment_status=refunded&item_number=10001
/// URL Tickets
/// https://www.rotary1730.org/billetterie.aspx?order_guid=E6362743-CE4A-4453-816D-04F9C5DAF40F
/// 
/// </summary>

public partial class DesktopModules_AIS_Ticketing_Control : PortalModuleBase
{
    bool bypassemail = false;

    public string URL {
        get {
           return ticketing.eventurl;
        }
    }
    public string EMAIL
    {
        get
        {
            return ticketing.email;
        }
    } 


    Ticketing _ticketing;
    Ticketing ticketing {
        get
        {
            if(_ticketing==null)
            { 
                if (Settings.Contains("ticketing"))
                {
                    string ts = "" + Settings["ticketing"];

                    _ticketing = (Ticketing)Functions.Deserialize(ts, typeof(Ticketing));

                    L_Comment.Text = _ticketing.labelcomment;
                }
            }
            return _ticketing;
        }
        set
        {
            _ticketing = value;
        }
    }
    public int CurrentStep
    {
        get {
            int s = 0;
            int.TryParse(""+H_Step.Value, out s);
            return s;
        }
        set {
            H_Step.Value = ""+value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        // stripe redirect to checkout
        if ("" + Request["striperedirecttockeckout"] != "")
        {
            string src = "" +
"                   <script type='text/javascript'>" +
"                       var stripe = Stripe('" + ticketing.stripepublickey + "');" +
"                       stripe.redirectToCheckout({ sessionId: '" + Request["striperedirecttockeckout"] + "' });" +
"                   </script>" +
"                ";

            LT_STRIPE.Text = src;
            LT_STRIPE.Visible = true;
            return;

        }
      // stripe return after payment or cancel
        if (Request["trid"] != null)
        {
            string transactionid = "" + Request["trid"];
            string stripe = "" + Request["stripe"];
            if (stripe.Equals("success"))
            {
                var service = new PaymentIntentService();
                try
                {
                    var intent = service.Get(
                      "" + Application[transactionid]
                    );
                    Ticketing.Order order = (Ticketing.Order)Session[transactionid];
                    if (intent.Status == "succeeded")
                    {
                        UpdateOrderPayment(order.reference, "YES", intent.ToString(), intent.Id);
                        Confirmation(transactionid);
                    }
                    else
                    {
                        UpdateOrderPayment(order.reference, "NO", intent.ToString(), intent.Id);
                        ShowMessage("danger", "Le paiement n'a pas été accepté...");
                    }
                }
                catch (Exception ee)
                {
                    Functions.Error(ee);
                }
            }
        }


        // handler stripe
        //if(!String.IsNullOrEmpty(Request["stripeToken"]))
        //{
        //    P3_Stripe_PopUp.Visible = false;
        //    try
        //    {
        //        Ticketing.Order order = (Ticketing.Order)Session[TXT_GUID.Value];
        //        LBLOrderReference.Text = order.reference;

        //        StripeConfiguration.SetApiKey(ticketing.stripeprivatekey);
        //        var customers = new StripeCustomerService();
        //        var charges = new StripeChargeService();

        //        Dictionary<string, string> dico = new Dictionary<string, string>();
        //        if (Request["tId"] != null)
        //        {
        //            dico.Add("IdTransaction", Request["tId"]);
        //            dico.Add("Nom", order.customerlastname);
        //            dico.Add("Prénom", order.customerfirstname);
        //            dico.Add("Club", order.clubname);
        //            dico.Add("E-mail", order.customeremail);
        //            dico.Add("Téléphone", order.customerphone);
        //        }

        //        var customer = customers.Create(new StripeCustomerCreateOptions
        //        {
        //            Email = Request.Form["stripeEmail"],
        //            SourceToken = Request.Form["stripeToken"]

        //        });

        //        var charge = charges.Create(new StripeChargeCreateOptions
        //        {
        //            Amount = (int)(order.amount*100),
        //            Description = ticketing.name,
        //            Currency = "eur",
        //            CustomerId = customer.Id,
        //            Metadata = dico

        //        });

        //        if (charge.Status == "succeeded")
        //        {
        //          //  Pay();
        //            UpdateOrderPayment(order.reference, "YES",charge.Description, charge.BalanceTransactionId);
        //            GoNextStep();
        //        }
        //        return;
        //    }
        //    catch (Exception ee)
        //    {
        //        ShowMessage("danger", "Le paiement n'a pas été accepté...");
        //        Functions.Error(ee);
        //        return;
        //    }

        //}


        // handler paypal
        if (!String.IsNullOrEmpty(Request["ipn_track_id"]))
        { 
            PayPalIPN();
            return;
        }
       

        // return with order guid (paypal ou autre)
        if (!String.IsNullOrEmpty(Request["guid"]))
        {
            Confirmation(""+ Request["guid"]);
            return;
        }
        // show tickets 
        if(!String.IsNullOrEmpty(Request["order_guid"]))
        {
            ShowOrderTickets(""+Request["order_guid"]);
        }
        // show tickets
        if (!String.IsNullOrEmpty(Request["ticket_guid"]))
        {
            Check("" + Request["ticket_guid"]);
        }
        // show receipt
        if (!String.IsNullOrEmpty(Request["receipt"]))
        {
            Receipt("" + Request["receipt"]);
        }
        //// stripe payment
        //if (!String.IsNullOrEmpty(Request["stripe"]))
        //{

        //    CurrentStep = 3;
        //    TXT_GUID.Value = Request["stripe"];
        //    HF_PAYMENTMETHOD.Value = "";


        //    HidePayButtons();
        //    P3_Stripe_PopUp.Visible = true;
        //    HideOrShowPayButton();

        //    Ticketing.Order order = (Ticketing.Order)Session[TXT_GUID.Value];
        //    if (order == null)
        //        return;
        //    string src = @"<script src='https://checkout.stripe.com/checkout.js' 
        //                            class='stripe-button' 
        //                            data-key = '" + ticketing.stripepublickey + @"' 
        //                            data-amount = '" + (order.amount * 100) + @"' 
        //                            data-name = '" + Server.HtmlEncode(ticketing.name) + @"'
        //                            data-description = '" + Server.HtmlEncode(ticketing.description) + @"'
        //                            data-image = '" + ticketing.stripelogourl + @"'
        //                            data-locale = 'fr'
        //                            data-currency = 'eur'
        //                            data-label = 'Payer'
        //                            data-email = '" + order.customeremail + "'" +
        //                            "data-IdCommande = '" + order.reference + "'></script>";
        //    LT_STRIPE.Text = src;

        //    UpdatePanels();

        //    //UpdatePayButton();
        //    return;
        //}

        if (Page.IsPostBack)
        {
            Ticketing.Order order;

            if (Session[TXT_GUID.Value] != null)
            {
                order = (Ticketing.Order)Session[TXT_GUID.Value];

                Member member = DataMapping.GetMemberByUserID(UserId);
                P_People.Controls.Clear();
                foreach (Ticketing.Order.Item item in order.items)
                {
                    Ticketing_People p = (Ticketing_People)Page.LoadControl("~/DesktopModules/AIS/Ticketing/People.ascx");
                    p.ticketing = ticketing;
                    p.item = item;
                    if (member != null)
                        p.member = member;
                    P_People.Controls.Add(p);
                }
            }
            return;
        }

        try
        {
            if (ticketing!=null)
            {
                UserInfo ui = UserController.GetUserById(PortalId, UserId);
                if (ui != null)
                {
                    PAdmin.Visible = ui.IsSuperUser || ui.IsInRole("Administrators");
                    P_SuperAdmin.Visible = ui.IsSuperUser;

                    if (!string.IsNullOrEmpty(ticketing.readonlyrole))
                    {
                        PAdminExport.Visible = ui.IsInRole(ticketing.readonlyrole);
                       
                    }
                    if (!string.IsNullOrEmpty(ticketing.adminrole))
                    {
                        PAdmin.Visible = ui.IsInRole(ticketing.adminrole) || PAdmin.Visible;
                        PAdminExport.Visible = PAdmin.Visible || PAdminExport.Visible;
                    }

                    
                }

                L_Name.Text = ticketing.name;
                L_Description.Text = ticketing.description;
                TXT_GUID.Value = ticketing.guid;
                DateTime now = DateTime.Now;
                if (CurrentStep == 0 && ticketing.eventstartdate.CompareTo(now) < 0 && ticketing.eventenddate.CompareTo(now) > 0 && ticketing.opened)
                {
                    GoNextStep();
                }

                if (CurrentStep == 1)
                {
                    

                    List<Ticketing.Option> options = new List<Ticketing.Option>();
                    foreach (Ticketing.Option o in ticketing.options)
                        if (o.enabled)
                            options.Add(o);

                    

                    // auto add coupon guid form querystring
                    if (!String.IsNullOrEmpty(Request["voucher"]))
                    {
                        Ticketing.Voucher v = GetVoucher(ticketing.guid, "" + Request["voucher"]);
                        if (v == null)
                        {
                            // voucher doesn't exist                           
                            ShowMessage("warning", "Le coupon n'existe pas, veuillez contacter : " + ticketing.email);
                        }
                        else
                        {
                            if (!String.IsNullOrEmpty(v.order_guid)) // already used
                            {
                                ShowMessage("warning", "Le coupon a déjà été utilisé...");
                            }
                            else
                            {
                                Ticketing.Option o = new Ticketing.Option();
                                o.description = v.item_description;
                                o.name = v.item_label;
                                o.price = v.price;
                                o.guid = v.guid;
                                o.enabled = true;
                                o.maxqty = v.qty;
                                options.Add(o);
                                
                            }
                        }
                    }

                    L_Basket.DataSource = options;
                    L_Basket.DataBind();

                    if (Session[TXT_GUID.Value] != null)
                    {
                        Ticketing.Order order = (Ticketing.Order)Session[TXT_GUID.Value];

                        foreach (Ticketing.Order.Basket basket in order.basket)
                        {
                            foreach (DataListItem i in L_Basket.Items)
                            {
                                HiddenField g = i.FindControl("H_GUID") as HiddenField;
                                if (g.Value == basket.guid)
                                {
                                    double n = basket.qty;
                                    DropDownList dl = i.FindControl("DL_NB") as DropDownList;
                                    dl.SelectedIndex = (int)n;
                                    break;
                                }
                            }
                        }

                        InitClubList("");
                    }
                    CheckBTBook();
                }

            }
            else
            {
                CurrentStep = 0;
            }
        }catch(Exception ee)
        {
            CurrentStep = 0;
            Functions.Error(ee);
        }
        UpdatePanels();
    }


    private void InitClubList(string selectedvalue)
    {
        DL_ClubName.Items.Clear();
        DL_ClubName.Items.Add(new ListItem("", ""));
        DL_ClubName.SelectedIndex = 0;
        List<Club> clubs = DataMapping.ListClubs(sort:"name asc");
        foreach (Club club in clubs)
            DL_ClubName.Items.Add(club.name);

        try
        {
            DL_ClubName.SelectedValue =selectedvalue;
        }
        catch { }
    }

    private Ticketing.Voucher GetVoucher(string ticketing_guid,string voucher_guid)
    {
        Ticketing.Voucher v = null;
        SqlConnection conn = new SqlConnection(Config.GetConnectionString());
        try
        {
            conn.Open();
            SqlCommand sql = new SqlCommand("SELECT * FROM [ais_ticketing_vouchers] WHERE ticketing_guid=@ticketing_guid AND guid=@guid", conn);
            sql.Parameters.AddWithValue("ticketing_guid", ticketing_guid);
            sql.Parameters.AddWithValue("guid", voucher_guid);

            SqlDataReader rd = sql.ExecuteReader();
            if(rd.Read())
            {
                v = new Ticketing.Voucher();
                v.guid = "" + rd["guid"];
                v.item_label = "" + rd["item_label"];
                v.item_description = "" + rd["item_description"];
                v.name = "" + rd["name"];
                v.surname = "" + rd["surname"];
                double.TryParse("" + rd["qty"], out v.qty);
                double.TryParse("" + rd["price"], out v.price);
                v.email = "" + rd["email"];
                v.order_guid = "" + rd["order_guid"];
            }
            rd.Close();
        }
        catch (Exception ee)
        {
            Functions.Error(ee);

        }
        finally
        {
            conn.Close();
        }

        return v;
    }

    void UpdatePanels()
    {
        P0.Visible = CurrentStep == 0;
        P1.Visible = CurrentStep == 1;
        P2.Visible = CurrentStep == 2;       
        P3.Visible = CurrentStep == 3;
        P4.Visible = CurrentStep == 4;
    }
    void GoPreviousStep()
    {
        CurrentStep--;
        UpdatePanels();
    }
    void GoNextStep()
    {
        CurrentStep++;
        UpdatePanels();
    }

    void CheckBTBook()
    {
        double total = 0;
        BT_Book.Visible = false;
        foreach (DataListItem item in L_Basket.Items)
        {
            DropDownList ddl = item.FindControl("DL_NB") as DropDownList;
            HiddenField guid = item.FindControl("H_GUID") as HiddenField;
            HiddenField price = item.FindControl("L_PriceValue") as HiddenField;
            if (ddl.SelectedIndex > 0)
            {
                double p = 0;
                double.TryParse("" + price.Value, out p);
                total += p * ddl.SelectedIndex;
                BT_Book.Visible = true;
            }
        }
        L_Total.Text = string.Format("{0} €", total);
    }
    void Confirmation(string guid)
    {
        CurrentStep = 4;
        UpdatePanels();


        SqlConnection conn = new SqlConnection(Config.GetConnectionString());
        SqlCommand sql;
        try
        {
            conn.Open();
            sql = new SqlCommand("SELECT paid,reference,payment_method,description FROM ais_ticketing_orders WHERE guid=@guid", conn);
            sql.Parameters.AddWithValue("guid", guid);
            SqlDataReader rd = sql.ExecuteReader();

            if (rd.Read())
            {
                Ticketing.Order order = (Ticketing.Order)Functions.Deserialize("" + rd["description"], typeof(Ticketing.Order));


                LBLOrderReference.Text = "" + rd["reference"];
                string paid = "" + rd["paid"];
                if (paid.Equals("YES"))
                {
                    if(order.amount==0)
                        LBLReponse.Text = "La commande est validée";
                    else
                        LBLReponse.Text = "Le paiement a été accepté";
                    BT_ShowTickets.Visible = true;
                    BT_ShowTickets.NavigateUrl = URL + "?order_guid=" + guid;
                    BT_ShowReceipt.Visible = true && order.amount>0;
                    BT_ShowReceipt.NavigateUrl = URL + "?receipt=" + guid;

                }
                else if (paid.Equals("REFUNDED"))
                {
                    LBLReponse.Text = "Votre commande a été remboursée";
                }
                else if (paid.Equals("CANCELED"))
                {
                    LBLReponse.Text = "Votre commande a été annulée";
                }
                else if (paid.Equals("NO"))
                {
                    if((""+rd["payment_method"]).Equals("PAYPAL"))
                        LBLReponse.Text = "Le paiement n'a pas encore été accepté";
                    else
                        LBLReponse.Text = "Le paiement n'a pas encore été reçu";

                 }
                LBLReponse2.Text = "Pour toute question, veuillez contacter :<br/><strong>" + ticketing.contactname + "<br/>" + ticketing.contactemail + "<br/>" + ticketing.contactphone + "</strong>";

            }
            rd.Close();
        }
        catch (Exception eee)
        {
            Functions.Error(eee);
        }
        finally
        {
            conn.Close();
        }
    }
    void Receipt(string guid)
    {
        SqlConnection conn = new SqlConnection(Config.GetConnectionString());
        SqlCommand sql;
        try
        {
            conn.Open();
            sql = new SqlCommand("SELECT * FROM ais_ticketing_orders WHERE guid=@guid", conn);
            sql.Parameters.AddWithValue("guid", guid);
            SqlDataReader rd = sql.ExecuteReader();

            if (rd.Read())
            {
                string ticketing_guid = "" + rd["ticketing_guid"];
                

                Ticketing.Order order = (Ticketing.Order)Functions.Deserialize("" + rd["description"], typeof(Ticketing.Order));

                String receipt = System.IO.File.ReadAllText(Server.MapPath(this.ControlPath+"receipt.html"));
                receipt = receipt.Replace("#reference#", "" + rd["reference"]);
                receipt = receipt.Replace("#date#", "" + rd["dt"]);
                receipt = receipt.Replace("#customername#", "" + rd["firstname"] + " " + rd["lastname"]);
                receipt = receipt.Replace("#customerclubname#", "" + rd["club"]);
                receipt = receipt.Replace("#amount#", order.amount.ToString("#,##0 €"));
                receipt = receipt.Replace("#paymentmethod#", ""+rd["payment_method"]);

                string paid = "Non payée";
                
                string payment_detail = "";
                if (("" + rd["paid"]).Equals("YES"))
                { 
                    paid = "Payée";
                    if(!(""+rd["payment_transaction_id"]).Equals(""))
                    {
                        payment_detail = " - Numéro de transaction : " + rd["payment_transaction_id"];
                    }
                }

                rd.Close();

                sql = new SqlCommand("SELECT [name] FROM [ais_ticketing] WHERE guid=@guid", conn);
                sql.Parameters.AddWithValue("guid", ticketing_guid);
                string ticketing_name = "" + sql.ExecuteScalar();
                receipt = receipt.Replace("#ticketing#", ticketing_name);



                receipt = receipt.Replace("#paid#", paid);
                receipt = receipt.Replace("#paymentdetail#", payment_detail);


                int index = receipt.IndexOf("#detail#");
                int index1 = receipt.IndexOf("#enddetail#");
                string detail = receipt.Substring(index, index1 - index);
                detail = detail.Replace("#detail#","");
                StringBuilder sb = new StringBuilder();

                foreach(Ticketing.Order.Basket b in order.basket)
                {
                    string detail1 = detail;
                    detail1 = detail1.Replace("#itemname#", b.name);
                    detail1 = detail1.Replace("#itemqte#", ""+b.qty);
                    detail1 = detail1.Replace("#itemprice#", ""+b.price.ToString("#,##0 €"));
                    detail1 = detail1.Replace("#itemamount#", (b.qty * b.price).ToString("##,##0 €"));
                    sb.Append(detail1);
                }

               


                receipt = receipt.Substring(0, index) + sb.ToString() + receipt.Substring(index1 + 11);

                Response.Clear();
                Response.Write(receipt);
                Response.Flush();
                Response.End();
            }
            else
            { 
                rd.Close();
            }
        }
        catch (Exception eee)
        {
            Functions.Error(eee);
        }
        finally
        {
            conn.Close();
        }
    }

    protected void BT_Book_Click(object sender, EventArgs e)
    {
        Member member = AIS.DataMapping.GetMemberByUserID(UserInfo.UserID);
        Ticketing.Order order;
        
        if(Session[TXT_GUID.Value]!=null)
        {
            order = (Ticketing.Order)Session[TXT_GUID.Value];
        }
        else
        {
            order = new Ticketing.Order();


           
            if(member!=null)
            {
                order.customerfirstname = member.name;
                order.customerlastname = member.surname;
                order.customeremail = member.email;
                order.customerphone = member.telephone;
                order.clubname = member.club_name;
            }
        }

        order.basket.Clear();
        order.items.Clear();

        double total = 0;

        foreach (DataListItem it in L_Basket.Items)
        {
            DropDownList ddl = it.FindControl("DL_NB") as DropDownList;
            Label name = it.FindControl("L_Libelle") as Label;
            HiddenField price = it.FindControl("L_PriceValue") as HiddenField;
            HiddenField guid = it.FindControl("H_GUID") as HiddenField;

            int nb = ddl.SelectedIndex;
            if(nb>0)
            { 
                Ticketing.Order.Basket basket = new Ticketing.Order.Basket();
                basket.guid = guid.Value;
                basket.name = name.Text;
                basket.price = 0;
                double.TryParse("" + price.Value, out basket.price);
                basket.qty = nb;
                order.basket.Add(basket);

                double p = 0;
                double.TryParse("" + price.Value, out p);
                total += p * nb;

                for (int i=1;i<=nb;i++)
                { 
                    Ticketing.Order.Item item = new Ticketing.Order.Item();
                    item.guid = Guid.NewGuid().ToString();
                    item.option_guid = guid.Value;
                    item.name = name.Text + " - Personne n°"+i;
                    if(i==1 && member!=null)
                    { 
                        item.firstname = member.name;
                        item.lastname = member.surname;
                        item.email = member.email;
                    }
                    order.items.Add(item);
                }

              
            }
        }

        TXT_Customerfirstname.Text = order.customerfirstname;
        TXT_Customerlastname.Text = order.customerlastname;
        TXT_Customeremail.Text = order.customeremail;
        TXT_Customerphone.Text = order.customerphone;
        TXT_Comment.Text = order.customercomment;
        InitClubList(order.clubname);
      

        order.amount = total;

        P_People.Controls.Clear();

        foreach(Ticketing.Order.Item item in order.items)
        {
            Ticketing_People p = (Ticketing_People)Page.LoadControl("~/DesktopModules/AIS/Ticketing/People.ascx");
            p.ticketing = ticketing;
            p.item = item;            
            P_People.Controls.Add(p);
        }
        //L_People.DataSource = order.items;
        //L_People.DataBind();

        Session[TXT_GUID.Value] = order;
        ViewState["order"] = TXT_GUID.Value;

        GoNextStep();
    }
  
    protected void BT_ValidatePeople_Click(object sender, EventArgs e)
    {


        UpdatePayButton();

        if (Session[TXT_GUID.Value] != null)
        {
            Ticketing.Order order = (Ticketing.Order)Session[TXT_GUID.Value];
            order.customerfirstname = TXT_Customerfirstname.Text;
            order.customerlastname = TXT_Customerlastname.Text;
            order.customeremail = TXT_Customeremail.Text;
            order.customerphone = TXT_Customerphone.Text;
            order.clubname = "" + DL_ClubName.SelectedValue;
            order.customercomment = TXT_Comment.Text;

            


            int i = 0;
            foreach (Ticketing_People tp in P_People.Controls)
            {
                order.items[i] = tp.item;
                i++;
            }

            

            Session[TXT_GUID.Value] = order;
            GoNextStep();

            if(order.amount==0)
            {
                Pay();
            }

        }
        else
        {
            Response.Redirect(Request.RawUrl+"#"+ModuleId);
        }
       
    }
    
    protected void BT_Pay_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty("" + HF_PAYMENTMETHOD.Value))
            return;

        Pay();
        
    }
    protected void Pay()
    {
        if (Session[TXT_GUID.Value] != null)
        {
            Ticketing.Order order = (Ticketing.Order)Session[TXT_GUID.Value];
            order.reference = "";
            string orderguid = Guid.NewGuid().ToString();
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            SqlTransaction trans = null;
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand sql = new SqlCommand("INSERT INTO [ais_ticketing_orders] ([ticketing_guid],[guid],[dt],[ip],[firstname],[lastname],[email],[phone],[club],[description],[paid],[payment_detail],[payment_method]) VALUES (@ticketing_guid,@guid,@dt,@ip,@firstname,@lastname,@email,@phone,@club,@description,@paid,@payment_detail,@payment_method)", conn, trans);
                sql.Parameters.AddWithValue("ticketing_guid", TXT_GUID.Value);
                sql.Parameters.AddWithValue("guid", orderguid);
                sql.Parameters.AddWithValue("dt", DateTime.Now);
                sql.Parameters.AddWithValue("ip", "" + Request.ServerVariables["REMOTE_ADDR"]);
                sql.Parameters.AddWithValue("firstname", order.customerfirstname);
                sql.Parameters.AddWithValue("lastname", order.customerlastname);
                sql.Parameters.AddWithValue("email", order.customeremail);
                sql.Parameters.AddWithValue("phone", order.customerphone);
                sql.Parameters.AddWithValue("club", order.clubname);
                sql.Parameters.AddWithValue("description", Functions.Serialize(order));
                sql.Parameters.AddWithValue("paid", "NO");
                sql.Parameters.AddWithValue("payment_detail", "");
                sql.Parameters.AddWithValue("payment_method", "" + HF_PAYMENTMETHOD.Value);
                sql.ExecuteNonQuery();

                sql = new SqlCommand("SELECT @@IDENTITY", conn, trans);
                string r = "" + sql.ExecuteScalar();

                order.reference = r;
                LBLOrderReference.Text = r;

                sql = new SqlCommand("UPDATE [ais_ticketing_orders] SET reference=@reference,description=@description WHERE id=@id", conn, trans);
                sql.Parameters.AddWithValue("reference", r);
                sql.Parameters.AddWithValue("id", r);
                sql.Parameters.AddWithValue("description", Functions.Serialize(order));
                sql.ExecuteNonQuery();


                // vouchers set to current order
                foreach (Ticketing.Order.Basket b in order.basket)
                {
                    if (b.qty > 0)
                    {

                        sql = new SqlCommand("UPDATE [ais_ticketing_vouchers] SET order_guid=@order_guid WHERE ticketing_guid=@ticketing_guid AND guid=@guid", conn, trans);
                        sql.Parameters.AddWithValue("order_guid", orderguid);
                        sql.Parameters.AddWithValue("ticketing_guid", TXT_GUID.Value);
                        sql.Parameters.AddWithValue("guid", b.guid);
                        sql.ExecuteNonQuery();
                    }
                }




                trans.Commit();

                switch ("" + HF_PAYMENTMETHOD.Value)
                {
                    case "TRANSFERT":
                        LBLReponse.Text = ticketing.banktransferttext.Replace("[amount]", "" + order.amount);
                        LBLReponse2.Text = ticketing.banktransfertiban;
                        break;
                    case "CHEQUE":
                        LBLReponse.Text = ticketing.bankchequetext.Replace("[amount]", "" + order.amount);
                        LBLReponse2.Text = ticketing.bankchequedest;
                        break;
                    case "PAYPAL":
                        break;
                    case "STRIPE":
                        break;
                }

                if(!bypassemail)
                        SendMail(PortalSettings.Email, "polo@pololand.com", "Reservation", "Nouvelle commande : " + r);

                }
            catch (Exception ee)
            {
                Functions.Error(ee);
                ShowMessage("danger", "Une erreur est survenue, veuillez contacter : " + ticketing.email);
            }
            finally
            {
                conn.Close();
            }
            if (order.reference == "")
                return;

            GoNextStep();


            if (order.amount == 0)
            {
                UpdateOrderPayment(order.reference, "YES", "Gratuit","");
                Response.Redirect(URL + "?guid=" + orderguid + "#" + ModuleId);
                return;
            }


            if (("" + HF_PAYMENTMETHOD.Value).Equals("STRIPE"))
            {
                Session[orderguid] = order;

                Dictionary<string, string> dico = new Dictionary<string, string>();
                dico.Add("OrderID", order.reference);
                try
                {   
                    dico.Add("Nom", order.customerlastname);
                    dico.Add("Prénom", order.customerfirstname);
                    dico.Add("E-mail", order.customeremail);
                    dico.Add("Téléphone", order.customerphone);
                }
                catch
                {

                }
                string urlprefix = Request.Url.ToString().Replace(Request.Url.PathAndQuery, "");
                StripeConfiguration.ApiKey = ticketing.stripeprivatekey;
                string pageurl = Server.UrlEncode(Request.RawUrl).Replace("%2f", "/");
                string successurl = urlprefix + Functions.UrlAddParam(Functions.UrlAddParam(pageurl, "stripe", "success"), "trid", orderguid);
                string cancelurl = urlprefix + Server.UrlEncode(pageurl);
                var options = new SessionCreateOptions
                {

                    ClientReferenceId = order.reference,
                    PaymentIntentData = new SessionPaymentIntentDataOptions()
                    {
                        Description = ticketing.name,
                        Metadata = dico
                    },
                    PaymentMethodTypes = new List<string>
                    {
                        "card",
                    },
                    LineItems = new List<SessionLineItemOptions>
                    {
                        new SessionLineItemOptions
                        {
                            Name = ticketing.name,
                            Amount = (long)(order.amount * 100),
                            Currency = "eur",
                            Quantity = 1
                        },
                    },
                    Mode = "payment",
                    SuccessUrl = successurl,
                    CancelUrl = cancelurl

                };
                if (order.customeremail != "")
                    options.CustomerEmail = order.customeremail;
                string redirecturlstripe = "";
                try
                {
                    var service = new SessionService();
                    Session session = service.Create(options);
                    Application[orderguid] = session.PaymentIntentId;

                    redirecturlstripe = Functions.UrlAddParam(Request.RawUrl, "striperedirecttockeckout", session.Id);

                   
                    //Response.Write("<script>window.location.assign('" + redirecturlstripe + "#" + ModuleId + "')</script>");
                    //LT_STRIPE.Text = "<script>window.location.assign('" + redirecturlstripe + "#" + ModuleId + "')</script>";
 //                   LT_STRIPE.Text =  "" +
 //"                   <script type='text/javascript'>" +
 //" alert('titi');"+
 //"                       var stripe = Stripe('" + ticketing.stripepublickey + "');" +
 //"                       stripe.redirectToCheckout({ sessionId: '" + session.Id  + "' });" +
 //"                   </script>" +
 //"                ";
 //                   LT_STRIPE.Visible = true;
                }
                catch (Exception ee)
                {
                    Response.Write(
                        "<div class='alert alert-danger'><strong>Erreur : </strong> " + ee.Message + "</div>");

                }

                Response.Redirect(redirecturlstripe + "#" + ModuleId);
                return;
                //    Response.Redirect(Functions.UrlAddParam("" + Request.RawUrl, "stripe", TXT_GUID.Value));
            }
            if (("" + HF_PAYMENTMETHOD.Value).Equals("PAYPAL"))
            {
                string LW_wallet = ticketing.paypalemail;//  
                string Item_Name = L_Name.Text;
                string Reference = order.reference;
                string Montant = "" + order.amount;
                string Url = URL + "?guid=" + orderguid;
                string Notify_Url = ticketing.paypalipnurl; // 
                //Response.Redirect(@"https:" + "//www.paypal.com/cgi-bin/webscr?business=" + LW_wallet + "&lc=FR&item_name=" + Item_Name + "&currency_code=EUR&item_number=" + Reference + "&amount=" + Montant + "&cmd=_xclick&shopping_url=" + Url);
                Response.Redirect(@"https:" + "//www.paypal.com/cgi-bin/webscr?business=" + LW_wallet + "&lc=FR&item_name=" + Item_Name + "&currency_code=EUR&item_number=" + Reference + "&amount=" + Montant + "&cmd=_xclick&return=" + Url + "&notify_url=" + Notify_Url + "&txn_id=" + orderguid);
            }

        }
    }

    protected void DL_NB_SelectedIndexChanged(object sender, EventArgs e)
    {
        CheckBTBook();
    }

    protected void BT_ReturnBasket_Click(object sender, EventArgs e)
    {
        GoPreviousStep();
    }
    protected void BT_ReturnPeople_Click(object sender, EventArgs e)
    {
        HF_PAYMENTMETHOD.Value = "";
        HidePayButtons();
        HideOrShowPayButton();
        GoPreviousStep();
    }

    protected void L_Basket_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        Ticketing.Option opt = e.Item.DataItem as Ticketing.Option;
        if (opt == null)
            return;

 
        HiddenField H_GUID = e.Item.FindControl("H_GUID") as HiddenField;
        H_GUID.Value = opt.guid;

        Label L_Libelle = e.Item.FindControl("L_Libelle") as Label;
        L_Libelle.Text = opt.name;

        Label L_Description = e.Item.FindControl("L_Description") as Label;
        L_Description.Text = opt.description;

        HiddenField L_PriceValue = e.Item.FindControl("L_PriceValue") as HiddenField;
        L_PriceValue.Value = "" + opt.price;

        Label L_Price = e.Item.FindControl("L_Price") as Label;
        if (opt.price == 0)
            L_Price.Text = "Gratuit";
        else
            L_Price.Text = string.Format("{0} €", opt.price);

        DropDownList DL_NB = e.Item.FindControl("DL_NB") as DropDownList;
        DL_NB.Items.Clear();
        for (int i = 0; i <= opt.maxqty; i++)
            DL_NB.Items.Add("" + i);

        if (!opt.enabled)
        {
            DL_NB.Enabled = false;
            e.Item.Enabled = false;
        }

        DateTime now = DateTime.Now;

        if (opt.endsaledate.CompareTo(now) < 0)
        {
            DL_NB.Enabled = false;
            e.Item.Enabled = false;
        }

        if (opt.startsaledate.CompareTo(now) > 0)
        {
            DL_NB.Enabled = false;
            e.Item.Enabled = false;
        }


    }
    protected void L_People_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        Ticketing.Order.Item opt = e.Item.DataItem as Ticketing.Order.Item;
        if (opt == null)
            return;

        Label L_Name = e.Item.FindControl("L_Name") as Label;
        L_Name.Text = opt.name;

        HiddenField H_GUID = e.Item.FindControl("H_GUID") as HiddenField;
        H_GUID.Value = opt.guid;

        TextBox TXT_Firstname = e.Item.FindControl("TXT_Firstname") as TextBox;
        TXT_Firstname.Text = opt.firstname;

        TextBox TXT_Lastname = e.Item.FindControl("TXT_Lastname") as TextBox;
        TXT_Lastname.Text = opt.lastname;

        TextBox TXT_Email = e.Item.FindControl("TXT_Email") as TextBox;
        TXT_Email.Text = opt.email;

        Panel P_Fields = e.Item.FindControl("P_Fields") as Panel;
        P_Fields.Controls.Clear();
        int i = 1;
        foreach(Ticketing.Field field in ticketing.fields)
        {
            Label l = new Label();
            l.Text = field.label;
            l.CssClass = "control-label col-sm-3";
            P_Fields.Controls.Add(l);

            Panel p = new Panel();
            p.CssClass = "col-sm-9";

            switch(field.type)
            {
                case "TEXT":
                    TextBox t = new TextBox();
                    t.ID = "f" + i;
                    t.CssClass = "form-control";
                    p.Controls.Add(t);
                    break;
                case "RADIO":
                    Panel prb = new Panel();
                    prb.CssClass = "control-label";
                    RadioButtonList rbl = new RadioButtonList();
                   
                    rbl.ID = "f" + i;
                    rbl.RepeatDirection = RepeatDirection.Horizontal;
                    string[] valeurs = field.value.Split(';');
                    foreach (string v in valeurs)
                        rbl.Items.Add(v);
                    prb.Controls.Add(rbl);
                    p.Controls.Add(prb);
                    break;

            }
            if (field.mandatory)
            {
                RequiredFieldValidator r = new RequiredFieldValidator();
                r.ControlToValidate = "f"+i;
                r.Text = "Veuillez compléter";
                r.ForeColor = Color.Red;
                r.Display = ValidatorDisplay.Dynamic;
                p.Controls.Add(r);
            }
            if(!field.comment.Equals(""))
            {
                Panel pc = new Panel();
                Label c = new Label();
                c.Text = field.comment;
                pc.Controls.Add(c);
                p.Controls.Add(pc);
            }
            

            P_Fields.Controls.Add(p);
            
            i++;
        }
    }

    void Check(string ticket_guid)
    {
        Response.Clear();
        Response.Write("<html><body>");
        Response.Write("<h1>Le guichet est fermé</h1>");
        Response.Write("</html></body>");
        Response.Flush();
        Response.End();
    }

    void ShowOrderTickets(string order_guid)
    {

        String ticket = System.IO.File.ReadAllText(Server.MapPath(this.ControlPath + "ticket.html"));

        SqlConnection conn = new SqlConnection(Config.GetConnectionString());
        SqlCommand sql;
        try
        {
            conn.Open();

            sql = new SqlCommand("select * from ais_ticketing_orders where guid=@guid", conn);
            sql.Parameters.AddWithValue("guid", order_guid);
            SqlDataReader rs = sql.ExecuteReader();
            if (rs.Read())
            {
                string ticketing_guid = "" + rs["ticketing_guid"];

                Ticketing.Order order = (Ticketing.Order)Functions.Deserialize("" + rs["description"], typeof(Ticketing.Order));
                rs.Close();

                sql = new SqlCommand("SELECT [name] FROM [ais_ticketing] WHERE guid=@guid", conn);
                sql.Parameters.AddWithValue("guid", ticketing_guid);
                string ticketing_name = "" + sql.ExecuteScalar();

                sql = new SqlCommand("select * from ais_ticketing_ticket where order_guid=@order_guid and cancelation_date is null", conn);
                sql.Parameters.AddWithValue("order_guid", order_guid);

                rs = sql.ExecuteReader();

                ticket = ticket.Replace("#ticketing#", ticketing_name);

                int index = ticket.IndexOf("#detail#");
                int index1 = ticket.IndexOf("#enddetail#");
                string detail = ticket.Substring(index, index1 - index);
                detail = detail.Replace("#detail#", "");
                StringBuilder sb = new StringBuilder();
                
                while (rs.Read())
                {
                    Ticketing.Order.Item it = new Ticketing.Order.Item();
                    foreach(Ticketing.Order.Item ii in order.items)
                        if(ii.guid.Equals(""+rs["item_guid"]))
                        {
                            it = ii;
                            break;
                        }

                    string detail1 = detail;
                    detail1 = detail1.Replace("#item#",it.name);
                    detail1 = detail1.Replace("#firstname#", "" + it.firstname);
                    detail1 = detail1.Replace("#lastname#", "" + it.lastname);
                    detail1 = detail1.Replace("#email#", it.email);
                    detail1 = detail1.Replace("#urlqr#", "/AIS/QR.ashx?s=" + Server.UrlEncode(URL + "?ticket_guid=" + it.guid) );                    
                    sb.Append(detail1);
                }

                ticket = ticket.Substring(0, index) + sb.ToString() + ticket.Substring(index1 + 11);

                Response.Clear();
                Response.Write(ticket);
                Response.Flush();
                Response.End();
            }
            rs.Close();
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

    void PayPalIPN()
    {
        string request = "";

        foreach (string p in Request.Params)
            request += p + " : " + Request[p] + Environment.NewLine;

        string strResponse = "" + Request["payment_status"];
        string Item_number = "" + Request["item_number"];
        string Txn_id = "" + Request["txn_id"];
        string payment_status = "" + Request["payment_status"];


        SqlConnection conn = new SqlConnection(Config.GetConnectionString());
        SqlCommand sql;
        try
        {
            conn.Open();
            sql = new SqlCommand("INSERT INTO [ais_paypal_ipn] ([dt],[request],[response]) VALUES (getdate(),@request,@response)", conn);
            sql.Parameters.AddWithValue("request", request);
            sql.Parameters.AddWithValue("response", strResponse);
            sql.ExecuteNonQuery();

        }
        catch (Exception eee)
        {
            Functions.Error(eee);
        }
        finally
        {
            conn.Close();
        }

        
        PayPalIPN(request, strResponse,Item_number,Txn_id, payment_status);


        //File.WriteAllText(Server.MapPath("/paypal/" + DateTime.Now.Ticks +".txt"), request);

        CurrentStep = 4;
        UpdatePanels();
    }
    void PayPalIPN(string request, string strResponse,string Item_number, string Txn_id, string payment_status)
    {
        try
        {

            if (strResponse.ToLower().Equals("completed") || strResponse.ToLower().Equals("refunded"))
            {
                //check the payment_status is Completed
                //check that txn_id has not been previously processed
                //check that receiver_email is your Primary PayPal email
                //check that payment_amount/payment_currency are correct
                //process payment

                // pull the values passed on the initial message from PayPal

                //string user_email = "" + Request["payer_email"];
                //string payment_status = "" + Request["payment_status"];
                //string Item_name = "" + Request["item_name"];
                //string Payment_amount = "" + Request["mc_gross"];
                //string Payment_currency = "" + Request["mc_currency"];
                //string Receiver_email = "" + Request["receiver_email"];
                
                
                Txn_id = Txn_id.Trim();
                
                string paid = "NO";
                if(strResponse.ToLower().Equals("completed"))
                    paid = "YES";
                else if(strResponse.ToLower().Equals("refunded"))
                    paid = "REFUNDED";


                if (!string.IsNullOrEmpty(Item_number))// && !string.IsNullOrEmpty(Txn_id))
                {
                    UpdateOrderPayment(Item_number, paid, request, Txn_id);                 
                }
                else
                {

                    Exception ee = new Exception("Le retour paiement du contenu : " + Item_number + " ayant l'id transaction paypal : " + Txn_id + " n'est pas completed. Il est a l'état : " + payment_status);
                    Functions.Error(ee);
                }
            }
            else if (strResponse.ToLower() == "invalid")
            {
                LBLReponse.Text = "Le paiement n'a pas été accepté par PayPal";
                LBLReponse2.Text = "";
                Exception ee = new Exception("Le retour paiement est revenu Invalid");
            }
            else
            {
                LBLReponse.Text = "Le paiement n'a pas abouti, une erreur est survenue";
                LBLReponse2.Text = "";
                Exception ee = new Exception("Le retour paiement n'est pas revenu Invalid ou Verified");
            }

            //}

        }
        catch (Exception ee)
        {
            Functions.Error(ee);

        }
    }

    /// <summary>
    /// </summary>
    /// <param name="reference">Order reference</param>
    /// <param name="paid">YES, CANCELED, REFUNDED</param>
    /// <param name="payment_detail"></param>
    protected void UpdateOrderPayment(string reference,string paid, string payment_detail, string payment_transaction_id)
    {
        BT_ShowTickets.Visible = false;
        BT_ShowReceipt.Visible = false;
        SqlConnection conn = new SqlConnection(Config.GetConnectionString());
        SqlCommand sql;
        try
        {
            SqlTransaction trans;
            conn.Open();
            trans = conn.BeginTransaction();

            sql = new SqlCommand("select * from ais_ticketing_orders where reference=@reference", conn, trans);
            sql.Parameters.AddWithValue("reference", reference);
            SqlDataReader rs = sql.ExecuteReader();
            if (rs.Read())
            {
                Ticketing.Order order = (Ticketing.Order)Functions.Deserialize("" + rs["description"], typeof(Ticketing.Order));
                string order_guid = "" + rs["guid"];
                string ticketing_guid = "" + rs["ticketing_guid"];
                bool already_paid = ("" + rs["paid"]).Equals("YES");
                string order_email = "" + rs["email"];
                rs.Close();

                sql = new SqlCommand("SELECT parms FROM ais_ticketing WHERE guid=@ticketing_guid", conn, trans);
                sql.Parameters.AddWithValue("ticketing_guid", ticketing_guid);
                string ti = "" + sql.ExecuteScalar();
                Ticketing t = (Ticketing)Functions.Deserialize(ti, typeof(Ticketing));

                
                sql = new SqlCommand("UPDATE ais_ticketing_orders SET paid=@paid,payment_detail=@payment_detail,payment_transaction_id=@payment_transaction_id WHERE reference=@reference", conn, trans);
                sql.Parameters.AddWithValue("paid", paid);
                sql.Parameters.AddWithValue("payment_detail", payment_detail);
                sql.Parameters.AddWithValue("payment_transaction_id", payment_transaction_id);
                sql.Parameters.AddWithValue("reference", reference);

                int nb = sql.ExecuteNonQuery();
                if (nb > 0 && paid.Equals("YES"))
                {
                   if (order.amount == 0)
                        LBLReponse.Text = "La commande est validée";
                    else
                        LBLReponse.Text = "Le paiement a été accepté";
                    LBLReponse2.Text = "";
                    BT_ShowTickets.Visible = true;
                    BT_ShowTickets.NavigateUrl = t.eventurl + "?order_guid=" + order_guid;
                    BT_ShowReceipt.Visible = true && order.amount>0;
                    BT_ShowReceipt.NavigateUrl = t.eventurl + "?receipt=" + order_guid;

                    if (!already_paid)
                    {
                        foreach (Ticketing.Order.Item it in order.items)
                        {
                            sql = new SqlCommand("INSERT INTO [ais_ticketing_ticket] ([ticket_date],[guid],[order_guid],[item_guid]) VALUES (@ticket_date,@guid,@order_guid,@item_guid)", conn, trans);
                            sql.Parameters.AddWithValue("ticket_date", DateTime.Now);
                            sql.Parameters.AddWithValue("guid", "" + Guid.NewGuid());
                            sql.Parameters.AddWithValue("order_guid", order_guid);
                            sql.Parameters.AddWithValue("item_guid", it.guid);
                            sql.ExecuteNonQuery();
                        }
                    }

                    string msg = "Bonjour," + Environment.NewLine;
                    msg += "Votre commande a bien été payée." + Environment.NewLine;
                    msg += "Pour voir vos tickets :" + Environment.NewLine;
                    msg += t.eventurl + "?order_guid=" + order_guid + Environment.NewLine;
                    msg += Environment.NewLine;
                    msg += "Pour voir votre reçu :" + Environment.NewLine;
                    msg += t.eventurl + "?receipt=" + order_guid + Environment.NewLine;
                    msg += Environment.NewLine;
                    msg += "Merci";
                    msg += Environment.NewLine;
                    msg += Environment.NewLine;
                    msg += "Pour toute question : " + t.email;
                    if(!bypassemail)
                    {
                        SendMail(t.email, order_email, PortalSettings.PortalName + " : Votre commande " + reference, msg);
                        SendMail(t.email, "polo@pololand.com", PortalSettings.PortalName + " : Votre commande " + reference, msg);
                        SendMail(order_email, t.email, PortalSettings.PortalName + " : Votre commande " + reference, msg);                       
                    }

                }
                if (nb > 0 && paid.Equals("REFUNDED"))
                {
                    sql = new SqlCommand("UPDATE [ais_ticketing_ticket] SET cancelation_date=@cancelation_date WHERE order_guid=@order_guid", conn, trans);
                    sql.Parameters.AddWithValue("cancelation_date", DateTime.Now);
                    sql.Parameters.AddWithValue("order_guid", order_guid);
                    int n = sql.ExecuteNonQuery();

                    LBLReponse.Text = "La commande a été remboursée";

                    string msg = "Bonjour," + Environment.NewLine;
                    msg += "Votre commande a bien été remboursée." + Environment.NewLine;
                    msg += "Vos tickets ont été annulés" + Environment.NewLine;
                    msg += Environment.NewLine;
                    msg += "Merci";
                    msg += Environment.NewLine;
                    msg += Environment.NewLine;
                    msg += "Pour toute question : " + t.email;
                    if (!bypassemail)
                    {
                        SendMail(t.email, order_email, PortalSettings.PortalName + " : Annulation commande " + reference, msg);
                        SendMail(t.email, "polo@pololand.com", PortalSettings.PortalName + " : Annulation commande " + reference, msg);
                        SendMail(order_email, t.email, PortalSettings.PortalName + " : Annulation commande " + reference, msg);                       
                    }
                    if (n > 0)
                        LBLReponse2.Text = "Les tickets ont été annulés";
                }
                if (nb > 0 && paid.Equals("CANCELED"))
                {
                    sql = new SqlCommand("UPDATE [ais_ticketing_ticket] SET cancelation_date=@cancelation_date WHERE order_guid=@order_guid", conn, trans);
                    sql.Parameters.AddWithValue("cancelation_date", DateTime.Now);
                    sql.Parameters.AddWithValue("order_guid", order_guid);
                    int n = sql.ExecuteNonQuery();

                    LBLReponse.Text = "La commande a été annulée";

                    string msg = "Bonjour," + Environment.NewLine;
                    msg += "Votre commande a bien été annulée." + Environment.NewLine;
                    msg += "Vos tickets ont été annulés" + Environment.NewLine;
                    msg += Environment.NewLine;
                    msg += "Merci";
                    msg += Environment.NewLine;
                    msg += Environment.NewLine;
                    msg += "Pour toute question : " + t.email;
                    if (!bypassemail)
                    {
                        SendMail(t.email, order_email, PortalSettings.PortalName + " : Annulation commande " + reference, msg);
                        SendMail(t.email, "polo@pololand.com", PortalSettings.PortalName + " : Annulation commande " + reference, msg);
                        SendMail(order_email, t.email, PortalSettings.PortalName + " : Annulation commande " + reference, msg);
                        
                    }
                    if (n > 0)
                        LBLReponse2.Text = "Les tickets ont été annulés";
                }
            }
            else
            {
                rs.Close();
            }

           

            trans.Commit();
        }
        catch (Exception eee)
        {
            Functions.Error(eee);
            ShowMessage("danger","Une erreur est survenue");
        }
        finally
        {
            conn.Close();
        }
    }

     protected void BT_Export_Orders_Unpaid_Click(object sender, EventArgs e)
    {
        Export_Orders("NO");
    }

    protected void BT_Export_Orders_Paid_Click(object sender, EventArgs e)
    {
        Export_Orders("YES");
    }
    protected void BT_Export_Orders_Refunded_Click(object sender, EventArgs e)
    {
        Export_Orders("REFUNDED");
    }
    protected void Export_Orders(string paid)
    {
        DataSet ds = GetOrders(paid);
        if (ds == null)
            return;

        Media media = DataMapping.ExportDataTablesToXLS(new List<DataTable>() { ds.Tables[0] }, DateTime.Now.ToString("yyyyMMdd") + " Export commandes "+paid+".xlsx", Aspose.Cells.SaveFormat.Xlsx);
        string guid = Guid.NewGuid().ToString();
        Session[guid] = media;
        Response.Redirect(Const.MEDIA_DOWNLOAD_URL + "?id=" + guid);
    }
    DataSet GetOrders(string paid,bool full = false)
    {
        SqlConnection conn = new SqlConnection(Config.GetConnectionString());
        SqlCommand sql;
        try
        {
            conn.Open();
            if(full)
                sql = new SqlCommand("SELECT * FROM ais_ticketing_orders WHERE ticketing_guid=@guid AND paid=@paid", conn);
            else
                sql = new SqlCommand("SELECT reference,dt,firstname,lastname,email,phone,club,(select x.Rec.query('./amount').value('.', 'float') as amount from description.nodes('/Order') as x(Rec)) as amount,(select x.Rec.query('./customercomment').value('.', 'varchar(max)') as comment from description.nodes('/Order') as x(Rec)) as comment, paid,payment_method,payment_transaction_id FROM ais_ticketing_orders WHERE ticketing_guid=@guid AND paid=@paid", conn);
            sql.Parameters.AddWithValue("guid", TXT_GUID.Value);
            sql.Parameters.AddWithValue("paid", paid);

            SqlDataAdapter da = new SqlDataAdapter(sql);
            DataSet ds = new DataSet();
            da.Fill(ds);

            return ds;
            

        }
        catch (Exception eee)
        {
            Functions.Error(eee);
        }
        finally
        {
            conn.Close();
        }
        return null;
    }

    protected void BT_Export_Attendees_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(Config.GetConnectionString());
        SqlCommand sql;
        try
        {
            conn.Open();
            sql = new SqlCommand("SELECT * FROM ais_ticketing_orders WHERE ticketing_guid=@guid", conn);
            sql.Parameters.AddWithValue("guid", TXT_GUID.Value);

            SqlDataAdapter da = new SqlDataAdapter(sql);
            DataSet ds = new DataSet();
            da.Fill(ds);

            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("order_id"));
            table.Columns.Add(new DataColumn("clubname"));
            table.Columns.Add(new DataColumn("customerfirstname"));
            table.Columns.Add(new DataColumn("customerlastname"));
            table.Columns.Add(new DataColumn("customeremail"));
            table.Columns.Add(new DataColumn("customerphone"));
            table.Columns.Add(new DataColumn("customercomment"));
            table.Columns.Add(new DataColumn("paid"));
            table.Columns.Add(new DataColumn("name"));
            table.Columns.Add(new DataColumn("firstname"));
            table.Columns.Add(new DataColumn("lastname"));
            table.Columns.Add(new DataColumn("email"));
            foreach(Ticketing.Field f in ticketing.fields)
                table.Columns.Add(new DataColumn(f.label));

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                
                Ticketing.Order o = (Ticketing.Order)Functions.Deserialize("" + row["description"], typeof(Ticketing.Order));
                foreach(Ticketing.Order.Item item in o.items)
                {
                    DataRow r = table.NewRow();
                    r["order_id"] = row["reference"];
                    r["clubname"] = o.clubname;
                    r["customerfirstname"] =  o.customerfirstname;
                    r["customerlastname"] = o.customerlastname;
                    r["customeremail"] = o.customeremail;
                    r["customerphone"] = o.customerphone;
                    r["customercomment"] = o.customercomment;
                    r["paid"] = "" + row["paid"];
                    r["name"] = item.name;  // option name

                    r["firstname"] = item.firstname;
                    r["lastname"] = item.lastname;
                    r["email"] = item.email;
                    List<Ticketing.Field> fields = new List<Ticketing.Field>();
                    if (!("" + item.fields).Equals(""))
                    {
                        fields = (List<Ticketing.Field>)Functions.Deserialize(item.fields, typeof(List<Ticketing.Field>));
                        foreach (Ticketing.Field f in fields)
                        {
                            try
                            {
                                r[f.label] = f.value;
                            }
                            catch { }
                        }
                            
                    }
                    table.Rows.Add(r);

                }
            }

            Media media = DataMapping.ExportDataTablesToXLS(new List<DataTable>() {table }, DateTime.Now.ToString("yyyyMMdd")+ " Export participants.xlsx", Aspose.Cells.SaveFormat.Xlsx);
            string guid = Guid.NewGuid().ToString();
            Session[guid] = media;
            Response.Redirect(Const.MEDIA_DOWNLOAD_URL + "?id=" + guid);

        }
        catch (Exception eee)
        {
            Functions.Error(eee);
        }
        finally
        {
            conn.Close();
        }
    }
    protected void BT_Export_Reservations_Click(object sender, EventArgs e)
    {

        List<DataTable> tables = new List<DataTable>();
        DataTable table = GetResa("YES");
        table.TableName = "Réservations Payées";
        tables.Add(table);
        table = GetResa("NO");
        table.TableName = "Réservations Non Payées";
        tables.Add(table);

        Media media = DataMapping.ExportDataTablesToXLS(tables, DateTime.Now.ToString("yyyyMMdd") + " Export réservations.xlsx", Aspose.Cells.SaveFormat.Xlsx);
        string guid = Guid.NewGuid().ToString();
        Session[guid] = media;
        Response.Redirect(Const.MEDIA_DOWNLOAD_URL + "?id=" + guid);
     
    }

    DataTable GetResa(string paid)
    {
        DataTable table = new DataTable("Réservations");
        table.Columns.Add("Commande");
        table.Columns.Add("Payée");
        table.Columns.Add("Méthode");
        table.Columns.Add("Prénom");
        table.Columns.Add("Nom");
        table.Columns.Add("Mél");
        foreach (Ticketing.Option o in ticketing.options)
        {
            table.Columns.Add(new DataColumn(o.name));
        }


        DataSet ds = GetOrders(paid, true);
        if (ds == null)
        {
            ShowMessage("danger", "Aucune commande trouvée");
        }

        //List<Ticketing.Order> orders = new List<Ticketing.Order>();
        foreach (DataRow row in ds.Tables[0].Rows)
        {
            string order_reference = "" + row["reference"];
            Ticketing.Order order = (Ticketing.Order)Functions.Deserialize("" + row["description"], typeof(Ticketing.Order));
            foreach (Ticketing.Order.Item item in order.items)
            {

                DataRow r = table.NewRow();
                r["Commande"] = row["reference"];
                r["Payée"] = row["Paid"];
                r["Méthode"] = row["payment_method"];
                r["Prénom"] = item.firstname;
                r["Nom"] = item.lastname;
                r["Mél"] = item.email;

                bool optionfinded = false;
                bool rowfinded = false;



                foreach (DataColumn col in table.Columns)
                {
                    if (item.name.StartsWith(col.ColumnName))
                    {
                        optionfinded = true;
                        // standard payable options
                        foreach (DataRow rr in table.Rows)
                        {
                            if (("" + rr["Commande"]) == order_reference)
                            {
                                rowfinded = true;
                                rr[col.ColumnName] = "1";
                                break;
                            }
                        }

                        if (!rowfinded)
                        {
                            r[col.ColumnName] = "1";
                        }
                        break;
                    }
                }

                if (optionfinded)
                {
                    if (!rowfinded)
                        table.Rows.Add(r);
                }

            }
        }
        return table;
    }

    protected void BT_BANKCHEQUE_Click(object sender, EventArgs e)
    {
        HF_PAYMENTMETHOD.Value = "CHEQUE";
        UpdatePayButton();
    }
    protected void BT_BANKTRANSFERT_Click(object sender, EventArgs e)
    {
        HF_PAYMENTMETHOD.Value = "TRANSFERT";       
        UpdatePayButton();
    }
    protected void BT_PAYPAL_Click(object sender, EventArgs e)
    {
        HF_PAYMENTMETHOD.Value = "PAYPAL";
        UpdatePayButton();
    }
    protected void BT_STRIPE_Click(object sender, EventArgs e)
    {
      //  Response.Redirect(Functions.UrlAddParam("" + Request.RawUrl , "stripe", TXT_GUID.Value) + "#" + ModuleId);

        HF_PAYMENTMETHOD.Value = "STRIPE";
        UpdatePayButton();
        
        

    }

    void HidePayButtons()
    {
        P3_Transfert.Visible = false;
        P3_Cheque.Visible = false;
        P3_Paypal.Visible = false;
        P3_Stripe.Visible = false;
        LT_STRIPE.Visible = false;

    }
    void HideOrShowPayButton()
    {
        BT_Pay.Visible = !string.IsNullOrEmpty("" + HF_PAYMENTMETHOD.Value);


    }
    void UpdatePayButton()
    {
        // this method check payment method to activate or not select method button
        // if nb = 1 button to select has no effect and pay button appears directly
        // if nb > 1 all needed panels and buttons permit to select method and make pay button to appear
        // only after selection

        HidePayButtons();

        BT_PAYPAL.Enabled = true;
        BT_BANKCHEQUE.Enabled = true;
        BT_BANKTRANSFERT.Enabled = true;
        BT_STRIPE.Enabled = true;

        int nb = 0;

        string singlepaymentmethod = "";
        if (ticketing.banktransfertactivated)
        { 
            P3_Transfert.Visible = true;
            singlepaymentmethod = "TRANSFERT";
            nb++;
        }
        if(ticketing.bankchequeactivated)
        {
            P3_Cheque.Visible = true;
            singlepaymentmethod = "CHEQUE";
            nb++;
        }
        if(ticketing.paypalactivated)
        { 
            P3_Paypal.Visible = true;
            singlepaymentmethod = "PAYPAL";
            nb++;
        }
        if (ticketing.stripeactivated)
        {
            P3_Stripe.Visible = true;
            singlepaymentmethod = "STRIPE";
            nb++;
        }
        if (nb == 1)
        { 
            HF_PAYMENTMETHOD.Value = singlepaymentmethod;
           
        }
        switch (""+HF_PAYMENTMETHOD.Value)
        {
            case "TRANSFERT":
                BT_Pay.Text = "Payer par virement";
                BT_BANKTRANSFERT.Enabled = false;
                break;
            case "CHEQUE":
                BT_Pay.Text = "Payer par chèque";
                BT_BANKCHEQUE.Enabled = false;
                break;
            case "PAYPAL":
                BT_Pay.Text = "Payer par Paypal ou carte bancaire";
                BT_PAYPAL.Enabled = false;
                break;
            case "STRIPE":
                BT_Pay.Text = "Payer par carte bancaire";
                BT_STRIPE.Enabled = false;
                break;

        }

        HideOrShowPayButton();
    }


    /// <summary>
    /// </summary>
    /// <param name="type">success, info, warning, danger</param>
    /// <param name="text"></param>
    void ShowMessage(string type, string text)
    {
        P_Message.Visible = true;
        P_Message.CssClass = "alert alert-" + type;
        L_Message.Text = text;
    }


    protected void BT_Emails_Click(object sender, EventArgs e)
    {
      
        L_Emails.Visible = true;
        SqlConnection conn = new SqlConnection(Config.GetConnectionString());
        SqlCommand sql;
        try
        {
            conn.Open();
            sql = new SqlCommand("SELECT * FROM ais_ticketing_emails WHERE ticketing_guid=@guid", conn);
            sql.Parameters.AddWithValue("guid", TXT_GUID.Value);
            SqlDataReader rd = sql.ExecuteReader();

            while (rd.Read())
            {
                string name = "" + rd["name"];
                string email = "" + rd["email"];
                string subject = "" + rd["subject"];
                string body = "" + rd["body"];


                //DotNetNuke.Services.Mail.Mail.SendEmail("joelle.cramoix@orange.fr", email, subject, body);
                //DotNetNuke.Services.Mail.Mail.SendEmail("joelle.cramoix@orange.fr", "marie-jose.caire@wanadoo.fr", subject, body);
                //DotNetNuke.Services.Mail.Mail.SendEmail("joelle.cramoix@orange.fr", "polo@pololand.com", subject, body);
                //DotNetNuke.Services.Mail.Mail.SendEmail(ticketing.email, email, subject, body);
                L_Emails.Text += "<br/>" + email ;
                
            }

            rd.Close();

        }catch(Exception eee)
        {
            Functions.Error(eee);
            ShowMessage("danger", eee.Message);
        }finally
        {
            conn.Close();
        }
    }

    protected void BT_Export_Vouchers_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(Config.GetConnectionString());
        SqlCommand sql;
        try
        {
            conn.Open();
            sql = new SqlCommand("SELECT * FROM ais_ticketing_vouchers WHERE ticketing_guid=@guid", conn);
            sql.Parameters.AddWithValue("guid", TXT_GUID.Value);

            SqlDataAdapter da = new SqlDataAdapter(sql);
            DataSet ds = new DataSet();
            da.Fill(ds);

            Media media = DataMapping.ExportDataTablesToXLS(new List<DataTable>() { ds.Tables[0] }, DateTime.Now.ToString("yyyyMMdd") + " Export invitations.xlsx", Aspose.Cells.SaveFormat.Xlsx);
            string guid = Guid.NewGuid().ToString();
            Session[guid] = media;
            Response.Redirect(Const.MEDIA_DOWNLOAD_URL + "?id=" + guid);

        }
        catch (Exception eee)
        {
            Functions.Error(eee);
        }
        finally
        {
            conn.Close();
        }
    }

    protected void BT_PaypalIPNCheck_Click(object sender, EventArgs e)
    {
        //bypassemail = true;
        L_Emails.Visible = true;
        StringBuilder sb = new StringBuilder();
        SqlConnection conn = new SqlConnection(Config.GetConnectionString());
        SqlCommand sql;
        try
        {
            conn.Open();
            sql = new SqlCommand("SELECT * FROM ais_paypal_ipn", conn);
            sql.Parameters.AddWithValue("guid", TXT_GUID.Value);

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql);
            da.Fill(ds);

            foreach(DataRow row in ds.Tables[0].Rows)
            {
                string request = "" + row["request"];
                string response = "" + row["response"];

                string item_number = request.Substring(request.IndexOf("item_number : ")+ "item_number : ".Length);
                item_number = item_number.Substring(0, item_number.IndexOf(Environment.NewLine));

                string transaction_id = request.Substring(request.IndexOf("txn_id : ") + "txn_id : ".Length);
                transaction_id = transaction_id.Substring(0, transaction_id.IndexOf(Environment.NewLine));

                string payment_status = request.Substring(request.IndexOf("payment_status : ") + "payment_status : ".Length);
                payment_status = payment_status.Substring(0, payment_status.IndexOf(Environment.NewLine));


                

                PayPalIPN(request, response, item_number, transaction_id, payment_status);
                    
                //sql = new SqlCommand("UPDATE [ais_ticketing_orders] set payment_transaction_id=@payment_transaction_id,payment_detail=@payment_detail WHERE ticketing_guid=@guid AND reference=@reference", conn);
                //sql.Parameters.AddWithValue("payment_transaction_id", transaction_id);
                //sql.Parameters.AddWithValue("payment_detail", request);
                //sql.Parameters.AddWithValue("guid", TXT_GUID.Value);
                //sql.Parameters.AddWithValue("reference",item_number);
                //int nb = sql.ExecuteNonQuery();
                sb.AppendLine(item_number + " " +response+" "+transaction_id);
            }
        }
        catch (Exception eee)
        {
            Functions.Error(eee);
        }
        finally
        {
            conn.Close();
        }
        L_Emails.Text = sb.ToString();
    }

    //protected void StripePopUpShowold()
    //{
    //    HidePayButtons();
    //    P3_Stripe_PopUp.Visible = true;
    
    //    Ticketing.Order order = (Ticketing.Order)Session[TXT_GUID.Value];
       
    //    string src = @"<script src='https://checkout.stripe.com/checkout.js' 
    //                                class='stripe-button' 
    //                                data-key = '" + ticketing.stripepublickey + @"' 
    //                                data-amount = '" + (order.amount * 100) + @"' 
    //                                data-name = '" + Server.HtmlEncode(ticketing.name) + @"'
    //                                data-description = '" + Server.HtmlEncode(ticketing.description) + @"'
    //                                data-image = '" + ticketing.stripelogourl + @"'
    //                                data-locale = 'fr'
    //                                data-currency = 'eur'
    //                                data-label = 'Payer'
    //                                data-email = '" + order.customeremail + "'" +
    //                            "data-IdCommande = '" + order.reference + "'></script>";
    //    LT_STRIPE.Text = src;
        
    //    //UpdatePanels();
    //}





    protected void BT_SearchByRef_Click(object sender, EventArgs e)
    {
        P_Order.Visible = false;
        RB_Order_Payment.SelectedIndex = -1;
        TXT_Order_Transaction_ID.Text = "";

        if (TXT_Reference.Text.Trim() == "")
            return;

        ShowOrderDetail();
    }

    void ShowOrderDetail()
    {
        StringBuilder sb = new StringBuilder();
        SqlConnection conn = new SqlConnection(Config.GetConnectionString());
        SqlCommand sql;
        try
        {
            conn.Open();
            sql = new SqlCommand("SELECT *,(select x.Rec.query('./amount').value('.', 'float') as amount from description.nodes('/Order') as x(Rec)) as amount FROM ais_ticketing_orders WHERE ticketing_guid=@guid AND reference=@reference", conn);
            sql.Parameters.AddWithValue("guid", TXT_GUID.Value);
            sql.Parameters.AddWithValue("reference", TXT_Reference.Text.Trim());
            SqlDataReader rd = sql.ExecuteReader();
            if (rd.Read())
            {
                H_Order_Reference.Value = "" + rd["reference"];

                sb.AppendLine("<pre>");
                sb.Append("Référence : ");
                sb.AppendLine("" + rd["reference"]);
                sb.Append("ID Unique : ");
                sb.AppendLine("" + rd["guid"]);
                sb.Append("Date : ");
                sb.AppendLine("" + rd["dt"]);
                sb.Append("IP : ");
                sb.AppendLine("" + rd["ip"]);
                sb.Append("Nom : ");
                sb.AppendLine("" + rd["lastname"]);
                sb.Append("Prénom : ");
                sb.AppendLine("" + rd["firstname"]);
                sb.Append("Email : ");
                sb.AppendLine("" + rd["email"]);
                sb.Append("Téléphone : ");
                sb.AppendLine("" + rd["phone"]);
                sb.Append("Club : ");
                sb.AppendLine("" + rd["club"]);
                sb.Append("Montant : ");
                sb.AppendLine("" + rd["amount"]);
                sb.Append("Méthode paiement : ");
                sb.AppendLine("" + rd["payment_method"]);
                sb.Append("Payée : ");
                sb.AppendLine("" + rd["paid"]);
                sb.Append("ID Transaction : ");
                sb.AppendLine("" + rd["payment_transaction_id"]);
                sb.AppendLine("</pre>");

                L_Order_Detail.Text = sb.ToString();
                P_Order.Visible = true;
            }
            rd.Close();

        }
        catch (Exception ee)
        {
            ShowMessage("danger", "" + ee);
        }
        finally
        {
            conn.Close();
        }
    }

    protected void BT_ManualPayment_Click(object sender, EventArgs e)
    {
        if (RB_Order_Payment.SelectedValue == "")
        {
            ShowMessage("warning", "Choisir le paiement");
            return;
        }
        if(TXT_Order_Transaction_ID.Text.Trim().Equals(""))
        {
            ShowMessage("warning", "Saisir le transaction ID ou date de virement ou n° chèque");
            return;
        }

        UpdateOrderPayment(H_Order_Reference.Value, RB_Order_Payment.SelectedValue, "", TXT_Order_Transaction_ID.Text);

        ShowOrderDetail();
     }

    
    protected void SendMail(string fromAddress,string toAddress,string subject,string body)
    {
        try
        {
            Functions.SendMail(fromAddress, toAddress, subject, body);
           // DotNetNuke.Services.Mail.Mail.SendEmail(PortalSettings.Email, fromAddress,toAddress,subject,body);
        }
        catch { }
    }




    protected void BT_ManualDelete_Click(object sender, EventArgs e)
    {
        if (TXT_Reference.Text.Trim() == "")
            return;

        SqlConnection conn = new SqlConnection(Config.GetConnectionString());
        SqlCommand sql;
        try
        {
            conn.Open();
            sql = new SqlCommand("UPDATE ais_ticketing_orders SET ticketing_guid = ticketing_guid++'_' WHERE ticketing_guid=@guid AND reference=@reference", conn);
            sql.Parameters.AddWithValue("guid", TXT_GUID.Value);
            sql.Parameters.AddWithValue("reference", TXT_Reference.Text.Trim());
            if(sql.ExecuteNonQuery()>0)
                ShowMessage("success", "Commande "+ TXT_Reference.Text.Trim()+" effacée");
        }
        catch (Exception ee)
        {
            ShowMessage("danger", ee.Message);
        }

        P_Order.Visible = false;
    }





   
}