
#region Copyrights

//
// Copyright (c) 2023
// RODI Platform : https://www.rodi-platform.org
// Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730)
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
using AIS.controller;
using DotNetNuke.Services.Mail;
using MimeKit.Encodings;
using Stripe;
using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;


public class Mailing
{
    public enum STEPS
    {
        DRAFT = 0,
        DEST=10,
        CONTENT=20,
        PREVIEW = 30,
        PREPARE=40,
        SENDING=50,
        SENT=60            
    }


    public int id { get; set; }
    public int cric { get; set; }
    public Guid guid { get; set; } 
    public string category { get; set; }
    public DateTime dt { get; set; }
    public DateTime dt_start { get; set; }
    public string subject { get; set; }
    public string sender_email { get; set; }
    public string sender_name { get; set; }
    public STEPS step { get; set; }
    public string recipients { get; set; }
    public string template_url { get; set; }
    public int portalid { get; set; }
    
    
    public Mailing()
    {
        guid = Guid.NewGuid();
        dt = DateTime.Now;
    }
    public class Recipient
    {
        public Guid guid;
        public string name;
    }
    public class Contact
    {
        public string name { get; set; }
        public string email { get; set; }
        public int nim { get; set; }
    }
    public class Out
    {
        public const string PENDING = "N";
        public const string DELIVERED = "D";
        public const string ERROR = "E";
        public const string TEST = "T";

        public enum PRIORITY
        {
            LOW=0,
            NORMAL=10, 
            HIGH=20
        }

        public int id { get; set; }
        public Guid mailing_guid { get; set; }
        public Guid guid { get; set; }
        public int nim { get; set; }
        public string email { get; set; }
        public string status { get; set; }
        public string error { get; set; }
        public string lu { get; set; }
        public int portalid { get; set; }
        public int priority { get; set;}
    }

    public static string DoPrepare()
    {
        StringBuilder sb = new StringBuilder();

        SqlConnection conn = null;
        SqlTransaction trans = null;
        try
        {
            conn = Yemon.dnn.DataMapping.GetOpenedConn();
            trans = conn.BeginTransaction();

            var sql = new SqlCommand("SELECT TOP 1 * FROM " + Const.TABLE_PREFIX + "mailings WHERE step='"+(int)STEPS.PREPARE+"' AND dt_start<getdate()");
            DataTable table = Yemon.dnn.DataMapping.ExecSql(sql, conn, trans);
            if(table!=null && table.Rows.Count>0)
            {
                Mailing mailing = Yemon.dnn.DataMapping.RowToObject<Mailing>(table.Rows[0]);
                sb.AppendLine("" + mailing.guid + " ... preparing");
                var recipients = Yemon.dnn.Functions.Deserialize<List<string>>(mailing.recipients);
                var contacts = MailingHelper.GetContactsFromRecipients(mailing.cric, recipients);
                sb.AppendLine("" +contacts.Count+" contact(s) found");
                foreach (Mailing.Contact contact in contacts)
                {
                    sql = new SqlCommand("INSERT INTO " + Const.TABLE_PREFIX + "mailing_out " +
                        "(guid,mailing_guid,nim,email,status,portalid,priority,lu) VALUES " +
                        "(@guid,@mailing_guid,@nim,@email,@status,@portalid,@priority,@lu)");
                    sql.Parameters.AddWithValue("mailing_guid", "" + mailing.guid);
                    sql.Parameters.AddWithValue("guid", "" + Guid.NewGuid());
                    sql.Parameters.AddWithValue("nim", contact.nim);
                    sql.Parameters.AddWithValue("email",contact.email);
                    sql.Parameters.AddWithValue("status", Out.PENDING);
                    sql.Parameters.AddWithValue("lu", Const.NO) ;
                    sql.Parameters.AddWithValue("priority", Out.PRIORITY.NORMAL);
                    sql.Parameters.AddWithValue("portalid", mailing.portalid);
                    if (Yemon.dnn.DataMapping.ExecSqlNonQuery(sql, conn, trans) > 0)
                        sb.AppendLine("" + contact.email + " ... out");
                    else
                        sb.AppendLine("" + contact.email + " ... error");


                }

                sql = new SqlCommand("UPDATE " + Const.TABLE_PREFIX + "mailings SET step='"+ (int)STEPS.SENDING+"' WHERE guid=@guid");
                sql.Parameters.AddWithValue("guid", mailing.guid);
                if (Yemon.dnn.DataMapping.ExecSqlNonQuery(sql, conn, trans) > 0)
                    sb.AppendLine("" + mailing.guid + " ... prepared");
                else
                    sb.AppendLine("" + mailing.guid + " ... error");

            }

            trans.Commit();
        }
        catch (Exception ex)
        {
            Functions.Error(ex);
        }
        finally { 
            
            if(conn != null)
                conn.Close();
            conn.Dispose();
        }

        return sb.ToString();
    }

    public static string DoSend()
    {
        string mailings_debug_dest = Const.MAILINGS_DEBUG_DEST;

        StringBuilder sb = new StringBuilder();

        SqlConnection conn = null;
        SqlTransaction trans = null;
        try
        {
            conn = Yemon.dnn.DataMapping.GetOpenedConn();
            trans = conn.BeginTransaction();

            var sql = new SqlCommand(   "SELECT * FROM " + Const.TABLE_PREFIX + "mailings " +
                                        "WHERE step='" + (int)STEPS.SENDING + "' AND dt_start<getdate() " +
                                        "ORDER BY dt_start");

            DataTable table = Yemon.dnn.DataMapping.ExecSql(sql, conn, trans);
            if (table != null && table.Rows.Count > 0)
            {
                foreach(DataRow row in table.Rows)
                {


                    //try
                    //{
                        Mailing mailing = Yemon.dnn.DataMapping.RowToObject<Mailing>(row);
                        sb.AppendLine("" + mailing.guid + " ... sending");

                        sql = new SqlCommand(   "SELECT TOP 50 * FROM " + Const.TABLE_PREFIX + "mailing_out " +
                                                "WHERE mailing_guid=@mailing_guid AND status='" + Out.PENDING+"' " +
                                                "ORDER BY priority DESC, id ASC");
                        sql.Parameters.AddWithValue("mailing_guid", mailing.guid);
                        
                        List<Mailing.Out> mailsout = Yemon.dnn.DataMapping.ExecSql<Mailing.Out>(sql,conn,trans);
                        if(mailsout.Count> 0 )
                        {
                            foreach (Mailing.Out mailout in mailsout)
                            {
                                Dictionary<string, object> data = new Dictionary<string, object>();
                                data.Add("mailout_nim", "" + mailout.nim);
                                data.Add("mailing_guid", "" + mailing.guid);
                                data.Add("mailing_subject", "" + mailing.subject);
                                data.Add("mailing_from", "" + mailing.sender_name);
                                data.Add("mailing_email", "" + mailing.sender_email);
                                if (mailings_debug_dest != "")
                                    data.Add("mailout_email", "" + mailings_debug_dest);
                                else
                                    data.Add("mailout_email", "" + mailout.email);

                                if (Yemon.dnn.SIPro.SIPro.AddMessage(0, 0, "mailingsend", "" + mailout.guid, Yemon.dnn.Functions.Serialize(data), conn: conn, trans: trans) > 0)
                                {
                                    Yemon.dnn.DataMapping.ExecSqlNonQuery(new SqlCommand("UPDATE  " + Const.TABLE_PREFIX + "mailing_out SET status='" + Out.DELIVERED + "' WHERE id='" + mailout.id + "'"), conn, trans);
                                    sb.AppendLine("" + data["mailout_email"] + " ... out");
                                }
                                else
                                {
                                    Yemon.dnn.DataMapping.ExecSqlNonQuery(new SqlCommand("UPDATE  " + Const.TABLE_PREFIX + "mailing_out SET status='" + Out.ERROR + "',error='Error add message' WHERE id='" + mailout.id + "'"), conn, trans);
                                    sb.AppendLine("" + data["mailout_email"] + " ... error");
                                }
                            }

                        } 
                        else
                        {
                            sb.AppendLine("no more mail to send...");
                            sql = new SqlCommand(   "UPDATE " + Const.TABLE_PREFIX + "mailings " +
                                                    "SET step='" + (int)STEPS.SENT + "' " +
                                                    "WHERE guid=@guid");
                            sql.Parameters.AddWithValue("guid", mailing.guid);
                            
                            if (Yemon.dnn.DataMapping.ExecSqlNonQuery(sql, conn, trans) > 0)
                                sb.AppendLine("" + mailing.guid + " ... sent");
                            else
                                sb.AppendLine("" + mailing.guid + " ... error");

                        }

                    //}
                    //catch(Exception ex)
                    //{
                    //    Functions.Error(new Exception("Mailing Send Error " + ex.Message));

                    //}
                    
                }                                           

            }

            trans.Commit();
        }
        catch (Exception ex)
        {
            Functions.Error(ex);
        }
        finally
        {

            if (conn != null)
                conn.Close();
            conn.Dispose();
        }

        return sb.ToString();
    }

    public static string DoTest()
    {
        StringBuilder sb = new StringBuilder();

        SqlConnection conn = null;
        SqlTransaction trans = null;
        try
        {
            conn = Yemon.dnn.DataMapping.GetOpenedConn();
            trans = conn.BeginTransaction();

            var sql = new SqlCommand(           "SELECT TOP 50 *," +
                                                "   (SELECT subject FROM " + Const.TABLE_PREFIX + "mailings WHERE guid=M.mailing_guid) as subject, " +
                                                "   (SELECT sender_name FROM " + Const.TABLE_PREFIX + "mailings WHERE guid=M.mailing_guid) as sender_name, " +
                                                "   (SELECT sender_email FROM " + Const.TABLE_PREFIX + "mailings WHERE guid=M.mailing_guid) as sender_email " +
                                                "FROM " + Const.TABLE_PREFIX + "mailing_out M " +
                                                "WHERE status='" + Out.TEST + "' " +
                                                "ORDER BY priority DESC, id ASC");
            
            DataTable mailsout = Yemon.dnn.DataMapping.ExecSql(sql, conn, trans);
            if (mailsout!=null && mailsout.Rows.Count > 0)
            {
                foreach (DataRow row in mailsout.Rows)
                {
                    sb.AppendLine("" + row["guid"] + "");
                    Dictionary<string, object> data = new Dictionary<string, object>();
                    data.Add("mailout_nim", "" + row["nim"]);
                    data.Add("mailout_email", "" + row["email"]);
                    data.Add("mailing_guid", "" + row["mailing_guid"]);
                    data.Add("mailing_subject", "[TEST] " + row["subject"]);
                    data.Add("mailing_from", "" + row["sender_name"]);
                    data.Add("mailing_email", "" + row["sender_email"]);

                    if (Yemon.dnn.SIPro.SIPro.AddMessage(0, 0, "mailingsend", "" + row["guid"], Yemon.dnn.Functions.Serialize(data), conn: conn, trans: trans) > 0)
                    {
                        Yemon.dnn.DataMapping.ExecSqlNonQuery(new SqlCommand("UPDATE  " + Const.TABLE_PREFIX + "mailing_out SET status='" + Out.DELIVERED + "' WHERE id='" + row["id"] + "'"), conn, trans);
                        sb.AppendLine("TEST : " + row["email"] + " ... out");
                    }
                    else
                    {
                        Yemon.dnn.DataMapping.ExecSqlNonQuery(new SqlCommand("UPDATE  " + Const.TABLE_PREFIX + "mailing_out SET status='" + Out.ERROR + "',error='Error add message' WHERE id='" + row["id"] + "'"), conn, trans);
                        sb.AppendLine("TEST : " + row["email"] + " ... error");
                    }
                }

            }

            trans.Commit();
        }
        catch (Exception ex)
        {
            Functions.Error(ex);
        }
        finally
        {

            if (conn != null)
                conn.Close();
            conn.Dispose();
        }

        return sb.ToString();
    }

}