
#region Copyrights

// RODI - http://rodi.aisdev.net
// Copyright (c) 2012-2016
// by SAS AIS : http://www.aisdev.net
// supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730)
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
using AIS;
using DotNetNuke.Entities.Modules;
using System.IO;
using System.Net;
using System.Text;
using System.Collections.Specialized;
using DotNetNuke.Services.Mail;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Common;
using System.Globalization;



public partial class DesktopModules_AIS_Admin_Retour_Paypal_Admin_Retour_Paypal : PortalModuleBase
{
    DotNetNuke.Entities.Modules.ModuleController objModules = new DotNetNuke.Entities.Modules.ModuleController();
    int annoncetabid
    {
        get
        {
            int t = 0;
            int.TryParse("" + objModules.GetModuleSettings(ModuleId)["annoncetabid"], out t);
            return t;
        }
    }

    int presentationtabid
    {
        get
        {
            int t = 0;
            int.TryParse("" + objModules.GetModuleSettings(ModuleId)["presentationtabid"], out t);
            return t;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //Post back to either sandbox or live
        //string strSandbox = "https://www.sandbox.paypal.com/cgi-bin/webscr";
        string strLive = "https://www.paypal.com/cgi-bin/webscr";

        //Pour la prod, passer HttpWebRequest req = (HttpWebRequest)WebRequest.Create(strLive); en decommenté et l'autre en commenter
        //HttpWebRequest req = (HttpWebRequest)WebRequest.Create(strSandbox);
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(strLive);

        //Set values for the request back
        req.Method = "POST";
        req.ContentType = "application/x-www-form-urlencoded";
        byte[] param = Request.BinaryRead(HttpContext.Current.Request.ContentLength);
        string strRequest = Encoding.ASCII.GetString(param);
        string strResponse_copy = strRequest;  //Save a copy of the initial info sent by PayPal
        strRequest += "&cmd=_notify-validate";
        req.ContentLength = strRequest.Length;


        //for proxy
        //WebProxy proxy = new WebProxy(new Uri("http://url:port#"));
        //req.Proxy = proxy;
        //Send the request to PayPal and get the response
        StreamWriter streamOut = new StreamWriter(req.GetRequestStream(), System.Text.Encoding.ASCII);
        streamOut.Write(strRequest);
        streamOut.Close();
        StreamReader streamIn = new StreamReader(req.GetResponse().GetResponseStream());
        string strResponse = streamIn.ReadToEnd();
        streamIn.Close();


        if (strResponse.ToLower() == "verified")
        {
            //check the payment_status is Completed
            //check that txn_id has not been previously processed
            //check that receiver_email is your Primary PayPal email
            //check that payment_amount/payment_currency are correct
            //process payment

            // pull the values passed on the initial message from PayPal

            NameValueCollection these_argies = HttpUtility.ParseQueryString(strResponse_copy);
            string user_email = "" + these_argies["payer_email"];
            string pay_stat = "" + these_argies["payment_status"];
            string Item_name = "" + these_argies["item_name"];
            string Item_number = "" + these_argies["item_number"];
            string Payment_amount = "" + these_argies["mc_gross"];
            string Payment_currency = "" + these_argies["mc_currency"];
            string Txn_id = "" + these_argies["txn_id"];
            Txn_id = Txn_id.Trim();
            string Receiver_email = "" + these_argies["receiver_email"];


            if (pay_stat.ToLower().Equals("completed"))
            {
                if (!string.IsNullOrEmpty(Item_number) && !string.IsNullOrEmpty(Txn_id))
                {
                    int id_contenu = 0;
                    int.TryParse(Item_number, out id_contenu);

                    double montant = 0;
                    double.TryParse(Payment_amount, System.Globalization.NumberStyles.Number, CultureInfo.InvariantCulture, out montant);

                    if (id_contenu > 0 && !string.IsNullOrEmpty(Txn_id) && montant > 0)
                    {
                        AIS.Content c = DataMapping.GetContent_by_ID(id_contenu);
                        if (c != null)
                        {
                            DateTime fin = DateTime.Now;
                            if (c.type == "PagePro")
                            {
                                fin = fin.AddMonths(Const.Duration_Presentation);
                            }
                            else if (c.type == "Annonce")
                            {
                                fin = fin.AddMonths(Const.Duration_Announcement);
                            }

                            bool? test = DataMapping.IdOrder_Exist(Txn_id);
                            if (test != null && test == false)
                            {
                                if (DataMapping.Insert_Subscription(c.id_user, Txn_id, c.id, c.type, DateTime.Now, fin, "o", montant) == true)
                                {
                                    if (DataMapping.Update_Publish("o", c.id) == true)
                                    {
                                        Member m = DataMapping.GetMemberByUserID(c.id_user);

                                        string message = "Un paiement a été effectué.<br/>";
                                        if (c.type == "Annonce")
                                        {
                                            message += "Il concerne l'annonce: <a href=\"" + Functions.UrlAddParam(Globals.NavigateURL(annoncetabid), "id_contenu", "" + c.id) + "\">" + c.title + "</a> <br/>";
                                        }
                                        else
                                        {
                                            message += "Il concerne la présentation du membre: <a href=\"" + Functions.UrlAddParam(Globals.NavigateURL(presentationtabid), "UserId", "" + c.id_user) + "\">" + m.surname + " " + m.name + "</a> <br/>";
                                        }
                                        


                                        PortalSettings ps = Globals.GetPortalSettings();

                                        Functions.SendMail(ps.Email, "Paiement effectué", message);
                                    }
                                    else
                                    {
                                        Exception ee = new Exception("Erreur après paiement lors de la mise à publication du contenu : " + c.id);
                                        Functions.Error(ee);
                                    }
                                }
                                else
                                {
                                    Exception ee = new Exception("Erreur lors de l'insert de l'abonnement pour le contenu : " + c.id + " pour la commande : " + Txn_id);
                                    Functions.Error(ee);
                                }
                            }
                            else if (test != null && test == true)
                            {
                                //Exception ee = new Exception("La transaction: " + id_commande + " existe!");
                                //Functions.Error(ee);
                            }
                            else if (test == null)
                            {
                                Exception ee = new Exception("Impossible de vérifier si la transaction: " + Txn_id + " existe!");
                                Functions.Error(ee);
                            }
                        }
                        else
                        {
                            Exception ee = new Exception("Content: " + id_contenu + " non récupéré!");
                            Functions.Error(ee);
                        }
                    }
                    else
                    {
                        Exception ee = new Exception("PB Conversion de " + Item_number + " en  id_contenu = " + id_contenu + " et/ou  de " + Payment_amount + " en montant = " + montant + " et/ou le numéro de commande est vide ou null ");
                        Functions.Error(ee);
                    }
                }
                else
                {
                    Exception ee = new Exception("Le retour paiement : Item_number et/ou Txn_id vide ou null.");
                    Functions.Error(ee);
                }
            }
            else
            {
                Exception ee = new Exception("Le retour paiement du contenu : " + Item_number + " ayant l'id transaction paypal : " + Txn_id + " n'est pas completed. Il est a l'état : " + pay_stat);
                Functions.Error(ee);
            }
        }
        else if (strResponse.ToLower() == "invalid")
        {
            Exception ee = new Exception("Le retour paiement est revenu Invalid");
            Functions.Error(ee);
        }
        else
        {
            Exception ee = new Exception("Le retour paiement n'est pas revenu Invalid ou Verified");
            Functions.Error(ee);
        }
    }
}