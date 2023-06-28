
#region Copyrights

//
// RODI - https://rodi-platform.org
// Copyright (c) 2012-2020
// by SAS AIS : https://www.aisdev.net
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
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetNuke.Common;
using DotNetNuke.Common.Utilities;
using System.Data;
using Aspose.Words;
using Aspose.Pdf;
using Aspose.Cells;
using Aspose.BarCode;
using System.Web.UI.WebControls;
using System.IO;
using System.Resources;
using DotNetNuke.Entities.Portals;
using System.Drawing;
using DotNetNuke.Entities.Users;
using DotNetNuke.Security.Membership;
using DotNetNuke.Security.Roles;
using Newtonsoft.Json;
using System.Web.Security;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Web;
using Dnn.PersonaBar.Security.Components;
using DotNetNuke.Security;

namespace AIS
{
    public static class DataMapping
    {
        #region Aspose
        public static void InitLicenceAsposeCells()
        {
            Aspose.Cells.License licenseCells = new Aspose.Cells.License();
            licenseCells.SetLicense(HttpContextSource.Current.Server.MapPath("/App_Code/AIS/Aspose.Total.lic"));
        }
        public static void InitLicenceAsposeWords()
        {
            Aspose.Words.License licenseWord = new Aspose.Words.License();
            licenseWord.SetLicense(HttpContextSource.Current.Server.MapPath("/App_Code/AIS/Aspose.Total.lic"));
        }
        public static void InitLicenceAsposeBarcode()
        {
            Aspose.BarCode.License licenseBarCode = new Aspose.BarCode.License();
            licenseBarCode.SetLicense(HttpContextSource.Current.Server.MapPath("/App_Code/AIS/Aspose.Total.lic"));
        }
        public static void InitLicenceAsposePdf()
        {
            Aspose.Pdf.License licensePdf = new Aspose.Pdf.License();
            licensePdf.SetLicense(HttpContextSource.Current.Server.MapPath("/App_Code/AIS/Aspose.Total.lic"));
        }
        #endregion Aspose

        /// <summary>
        /// Execute a SQL query
        /// </summary>
        /// <param name="query">SQL query</param>
        /// <returns>DataSet</returns>
        public static DataSet ExecSql(string query)
        {
            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                conn.Open();
                SqlCommand sql = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(sql);
                da.Fill(ds);

            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return ds;
        }

        #region Payments / Orders

        /// <summary>
        /// Create a payments list
        /// </summary>
        /// <param name="top">Nombre de règlements à sélectionner</param>
        /// <param name="tri">Type de tri</param>
        /// <param name="index">Numéro de la page de sélection</param>
        /// <param name="max">Nombre maximal d'entrées par pages</param>
        /// <returns>List de règlements</returns>
        public static List<Payment> ListPayments(string top = "", string sort = "dt DESC", int index = 0, int max = 100)
        {
            List<Payment> list = new List<Payment>();
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                DataSet ds = new DataSet();
                string query = "SELECT " + top + " * FROM " + Const.TABLE_PREFIX + "payment " + (sort != "" ? "ORDER BY " + sort : "");

                //if(HttpContextSource.Current.Application["news:"+query]!=null)
                //    ds = (DataSet)HttpContextSource.Current.Application["news:" + query];
                //else
                //{
                conn.Open();

                SqlCommand sql = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(sql);
                da.Fill(ds);

                //HttpContextSource.Current.Application["news:" + query] = ds;
                //}
                int i = 0;
                int c = 0;
                foreach (DataRow rd in ds.Tables[0].Rows)
                {
                    if (i >= (index * max) && c < max)
                    {
                        list.Add(GetPaymentByRD(rd));
                        c++;
                    }
                    else
                    {
                        list.Add(new Payment());
                    }
                    i++;
                }
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }

            return list;
        }

        /// <summary>
        /// Get a payment
        /// </summary>
        /// <param name="id">Payment ID</param>
        /// <returns>Payment</returns>
        public static Payment GetPayment(string id)
        {
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                string query = "SELECT * FROM " + Const.TABLE_PREFIX + "payment WHERE id=@id";
                conn.Open();
                DataSet ds = new DataSet();
                SqlCommand sql = new SqlCommand(query, conn);
                sql.Parameters.AddWithValue("id", id);
                SqlDataAdapter da = new SqlDataAdapter(sql);
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                    return GetPaymentByRD(ds.Tables[0].Rows[0]);
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }

            return null;
        }

        /// <summary>
        /// Get a payment thanks to a DataRow
        /// </summary>
        /// <param name="rd">DataRow</param>
        /// <returns>Payment</returns>
        static Payment GetPaymentByRD(DataRow rd)
        {
            Payment obj = new Payment();
            obj.id = "" + rd["id"];
            obj.dt = (DateTime)rd["dt"];
            obj.title = "" + rd["title"];
            obj.text = "" + rd["text"];
            obj.type = "" + rd["type"];
            obj.wording1 = "" + rd["wording1"];
            obj.closing = ("" + rd["closing"]).Equals("O");
            obj.model = "" + rd["model"];
            obj.amount1 = 0;
            try
            {
                obj.amount1 = (double)rd["amount1"];
            }
            catch { }
            obj.wording2 = "" + rd["wording2"];
            obj.amount2 = 0;
            try
            {
                obj.amount2 = (double)rd["amount2"];
            }
            catch { }

            return obj;
        }

        /// <summary>
        /// Add or edit a payment
        /// </summary>
        /// <param name="obj">Payement to add or edit</param>
        /// <returns>Validité de l'opération</returns>
        public static bool UpdatePayment(Payment obj)
        {
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                conn.Open();
                SqlCommand sql;
                if (obj.id != null)
                {
                    sql = new SqlCommand("UPDATE " + Const.TABLE_PREFIX + "payment SET [id]=@id,[dt]=@dt,[title]=@title,[text]=@text,[type]=@type,[wording1]=@wording1,[wording2]=@wording2,[amount1]=@amount1,[amount2]=@amount2 WHERE [id]=@id", conn);
                    sql.Parameters.AddWithValue("id", obj.id);
                }
                else
                {
                    sql = new SqlCommand("INSERT INTO " + Const.TABLE_PREFIX + "payment ([dt],[title],[text],[type],[wording1],[amount1],[wording2],[amount2]) VALUES (@dt,@title,@text,@type,@wording1,@amount1,@wording2,@amount2)", conn);
                }
                sql.Parameters.AddWithValue("@dt", obj.dt);
                sql.Parameters.AddWithValue("@title", obj.title);
                sql.Parameters.AddWithValue("@text", obj.text);
                sql.Parameters.AddWithValue("@type", obj.type);
                sql.Parameters.AddWithValue("@wording1", obj.wording1);
                sql.Parameters.AddWithValue("@amount1", obj.amount1);
                sql.Parameters.AddWithValue("@wording2", obj.wording2);
                sql.Parameters.AddWithValue("@amount2", obj.amount2);

                if (sql.ExecuteNonQuery() == 0)
                    throw new Exception("Erreur mise a jour reglement : " + obj.id);
                return true;

            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        /// <summary>
        /// Delete a payment
        /// </summary>
        /// <param name="id">Payment ID</param>
        /// <returns></returns>
        public static bool DeletePayment(string id)
        {
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                conn.Open();
                SqlCommand sql = new SqlCommand("DELETE " + Const.TABLE_PREFIX + "payment WHERE id=@id", conn);
                sql.Parameters.AddWithValue("@id", id);
                if (sql.ExecuteNonQuery() == 0)
                    throw new Exception("Erreur delete payment : " + id);
                return true;

            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        /// <summary>
        /// Get the number of orders associated with a payment
        /// </summary>
        /// <param name="id_payment">Payment ID</param>
        /// <returns>Nombre de orders</returns>
        public static int NbOrderByPayment(string id_payment)
        {
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                conn.Open();
                SqlCommand sql = new SqlCommand("SELECT count(*) FROM " + Const.TABLE_PREFIX + "orders WHERE id_payment=@id_payment", conn);
                sql.Parameters.AddWithValue("id_payment", id_payment);
                return int.Parse("" + sql.ExecuteScalar());

            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return 0;
        }

        /// <summary>
        /// Check if orders are complete for a defined payment
        /// </summary>
        /// <param name="id_payment">Payment ID</param>
        /// <returns>Validation</returns>
        public static bool OrdersComplete(string id_payment)
        {
            List<Club> clubs = ListClubs();
            return NbOrderByPayment(id_payment) >= clubs.Count;
        }

        /// <summary>
        /// Create a list of orders with a defined payment
        /// </summary>
        /// <param name="id_payment">Payment ID</param>
        /// <param name="sort">Sorting type</param>
        /// <param name="cric">Club cric</param>
        /// <returns></returns>
        public static List<Order> ListOrderByPayment(string id_payment, string sort = "club DESC", int cric = 0)
        {
            List<Order> list = new List<Order>();
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                conn.Open();
                string where = "WHERE id_payment=@id_payment ";
                if (cric > 0)
                    where += " AND cric=" + cric;
                SqlCommand sql = new SqlCommand("SELECT * FROM " + Const.TABLE_PREFIX + "orders " + where + " " + (sort != "" ? "ORDER BY " + sort : ""), conn);
                sql.Parameters.AddWithValue("id_payment", id_payment);
                SqlDataAdapter da = new SqlDataAdapter(sql);
                DataSet ds = new DataSet();
                da.Fill(ds);

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Order commande = new Order();
                    commande.cric = (int)row["cric"];
                    commande.guid = "" + row["guid"];
                    commande.club = "" + row["club"];
                    commande.dt = (DateTime)row["dt"];
                    commande.id = (int)row["id"];
                    commande.transaction_id = (int)row["transaction_id"];
                    commande.id_payment = "" + row["id_payment"];
                    commande.amount = (double)row["amount"];
                    commande.rule = "" + row["rule"];
                    commande.rule_dt = (DateTime)row["dt_rule"];
                    commande.rule_info = "" + row["info_rule"];
                    commande.rule_par = "" + row["par_rule"];
                    commande.rule_type = "" + row["type_rule"];

                    sql = new SqlCommand("SELECT * FROM " + Const.TABLE_PREFIX + "orders_details WHERE id_order=@id_order ORDER BY id", conn);
                    sql.Parameters.AddWithValue("id_order", commande.id);
                    da = new SqlDataAdapter(sql);
                    DataSet ds1 = new DataSet();
                    da.Fill(ds1);
                    foreach (DataRow r in ds1.Tables[0].Rows)
                    {
                        Order.Detail detail = new Order.Detail();
                        detail.id = (int)r["id"];
                        detail.id_parent = (int)r["id_parent"];
                        detail.wording = "" + r["wording"];
                        detail.amount = (double)r["amount"];
                        detail.quantity = (double)r["quantity"];
                        detail.unitary = (double)r["unitary"];
                        commande.Details.Add(detail);
                    }
                    list.Add(commande);
                }
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return list;
        }

        /// <summary>
        /// Get an order
        /// </summary>
        /// <param name="id">Order ID</param>
        /// <returns>Order</returns>
        public static Order GetOrder(string id)
        {
            Order commande = null;
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                conn.Open();
                SqlCommand sql = new SqlCommand("SELECT * FROM " + Const.TABLE_PREFIX + "orders WHERE id=@id", conn);
                sql.Parameters.AddWithValue("id", id);
                SqlDataAdapter da = new SqlDataAdapter(sql);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    commande = new Order();
                    DataRow row = ds.Tables[0].Rows[0];
                    commande.cric = (int)row["cric"];
                    commande.guid = "" + row["guid"];
                    commande.club = "" + row["club"];
                    commande.dt = (DateTime)row["dt"];
                    commande.id = (int)row["id"];
                    commande.transaction_id = (int)row["transaction_id"];
                    commande.id_payment = "" + row["id_payment"];
                    commande.amount = (double)row["amount"];
                    commande.rule = "" + row["rule"];
                    commande.rule_dt = (DateTime)row["dt_rule"];
                    commande.rule_info = "" + row["info_rule"];
                    commande.rule_par = "" + row["par_rule"];
                    commande.rule_type = "" + row["type_rule"];

                    sql = new SqlCommand("SELECT * FROM " + Const.TABLE_PREFIX + "orders_details WHERE id_order=@id_order ORDER BY id", conn);
                    sql.Parameters.AddWithValue("id_order", commande.id);
                    da = new SqlDataAdapter(sql);
                    ds = new DataSet();
                    da.Fill(ds);
                    foreach (DataRow r in ds.Tables[0].Rows)
                    {
                        Order.Detail detail = new Order.Detail();
                        detail.id = (int)r["id"];
                        detail.id_parent = (int)r["id_parent"];
                        detail.wording = "" + r["wording"];
                        detail.amount = (double)r["amount"];
                        detail.quantity = (double)r["quantity"];
                        detail.unitary = (double)r["unitary"];
                        commande.Details.Add(detail);
                    }
                }
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return commande;
        }

        /// <summary>
        /// Get an order thanks to a guid
        /// </summary>
        /// <param name="guid">Order GUID</param>
        /// <returns></returns>
        public static Order GetOrderByGuid(string guid)
        {
            Order commande = null;
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                conn.Open();
                SqlCommand sql = new SqlCommand("SELECT * FROM " + Const.TABLE_PREFIX + "orders WHERE guid=@guid", conn);
                sql.Parameters.AddWithValue("guid", guid);
                SqlDataAdapter da = new SqlDataAdapter(sql);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    commande = new Order();
                    DataRow row = ds.Tables[0].Rows[0];
                    commande.cric = (int)row["cric"];
                    commande.guid = "" + row["guid"];
                    commande.club = "" + row["club"];
                    commande.dt = (DateTime)row["dt"];
                    commande.id = (int)row["id"];
                    commande.transaction_id = (int)row["transaction_id"];
                    commande.id_payment = "" + row["id_payment"];
                    commande.amount = (double)row["amount"];
                    commande.rule = "" + row["rule"];
                    commande.rule_dt = (DateTime)row["dt_rule"];
                    commande.rule_info = "" + row["info_rule"];
                    commande.rule_par = "" + row["par_rule"];
                    commande.rule_type = "" + row["type_rule"];

                    sql = new SqlCommand("SELECT * FROM " + Const.TABLE_PREFIX + "orders_details WHERE id_order=@id_order ORDER BY id", conn);
                    sql.Parameters.AddWithValue("id_order", commande.id);
                    da = new SqlDataAdapter(sql);
                    ds = new DataSet();
                    da.Fill(ds);
                    foreach (DataRow r in ds.Tables[0].Rows)
                    {
                        Order.Detail detail = new Order.Detail();
                        detail.id = (int)r["id"];
                        detail.id_parent = (int)r["id_parent"];
                        detail.wording = "" + r["wording"];
                        detail.amount = (double)r["amount"];
                        detail.quantity = (double)r["quantity"];
                        detail.unitary = (double)r["unitary"];
                        commande.Details.Add(detail);
                    }
                }
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return commande;
        }

        /// <summary>
        /// Add or edit an order
        /// </summary>
        /// <param name="obj">Orderto add or modify</param>
        /// <returns></returns>
        public static bool UpdateOrder(Order obj)
        {
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            SqlTransaction trans = null;
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();

                SqlCommand sql;
                if (obj.id != 0)
                {
                    sql = new SqlCommand("UPDATE " + Const.TABLE_PREFIX + "orders SET [id_payment]=@id_payment,[cric]=@cric,[club]=@club,[amount]=@amount,[rule]=@rule,[info_rule]=@info_rule,[type_rule]=@type_rule,[par_rule]=@par_rule,[dt_rule]=@dt_rule,[dt]=@dt,[transaction_id]=@transaction_id WHERE [id]=@id", conn, trans);
                    sql.Parameters.AddWithValue("id", obj.id);
                }
                else
                {
                    sql = new SqlCommand("INSERT INTO " + Const.TABLE_PREFIX + "orders ([id_payment],[cric],[club],[amount],[rule],[info_rule],[type_rule],[par_rule],[dt_rule],[dt],[transaction_id]) VALUES (@id_payment,@cric,@club,@amount,@rule,@info_rule,@type_rule,@par_rule,@dt_rule,@dt,@transaction_id)", conn, trans);
                }
                sql.Parameters.AddWithValue("@id_payment", obj.id_payment);
                sql.Parameters.AddWithValue("@cric", obj.cric);
                sql.Parameters.AddWithValue("@club", obj.club);
                sql.Parameters.AddWithValue("@amount", obj.amount);
                sql.Parameters.AddWithValue("@rule", obj.rule);
                sql.Parameters.AddWithValue("@info_rule", obj.rule_info);
                sql.Parameters.AddWithValue("@type_rule", obj.rule_type);
                sql.Parameters.AddWithValue("@par_rule", obj.rule_par);
                sql.Parameters.AddWithValue("@dt_rule", obj.rule_dt);
                sql.Parameters.AddWithValue("@dt", obj.dt);
                sql.Parameters.AddWithValue("@transaction_id", obj.transaction_id);

                if (sql.ExecuteNonQuery() == 0)
                    throw new Exception("Erreur mise a day commande : " + obj.id);

                if (obj.id == 0)
                {
                    sql = new SqlCommand("SELECT @@IDENTITY", conn, trans);
                    obj.id = int.Parse("" + sql.ExecuteScalar());
                }

                sql = new SqlCommand("DELETE FROM " + Const.TABLE_PREFIX + "orders_details WHERE id_order=@id_order", conn, trans);
                sql.Parameters.AddWithValue("id_order", obj.id);
                sql.ExecuteNonQuery();

                foreach (Order.Detail detail in obj.Details)
                {
                    sql = new SqlCommand("INSERT INTO " + Const.TABLE_PREFIX + "orders_details ([id_order],[wording],[amount],[id_parent],[unitary],[quantity]) VALUES (@id_order,@wording,@amount,@id_parent,@unitary,@quantity)", conn, trans);
                    sql.Parameters.AddWithValue("@id_order", obj.id);
                    sql.Parameters.AddWithValue("@wording", detail.wording);
                    sql.Parameters.AddWithValue("@amount", detail.amount);
                    sql.Parameters.AddWithValue("@id_parent", detail.id_parent);
                    sql.Parameters.AddWithValue("@unitary", detail.unitary);
                    sql.Parameters.AddWithValue("@quantity", detail.quantity);
                    sql.ExecuteNonQuery();
                }

                trans.Commit();
                return true;

            }
            catch (Exception ee)
            {
                if (trans != null)
                    try
                    {
                        trans.Rollback();
                    }
                    catch { }
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        /// <summary>
        /// Delete an order
        /// </summary>
        /// <param name="id">Order ID</param>
        /// <returns></returns>
        public static bool DeleteOrder(string id)
        {
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            SqlTransaction trans = null;
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand sql = new SqlCommand("DELETE " + Const.TABLE_PREFIX + "orders WHERE id=@id", conn, trans);
                sql.Parameters.AddWithValue("@id", id);
                sql.ExecuteNonQuery();

                sql = new SqlCommand("DELETE " + Const.TABLE_PREFIX + "orders_details WHERE id_order=@id_order", conn, trans);
                sql.Parameters.AddWithValue("@id_order", id);
                sql.ExecuteNonQuery();

                trans.Commit();

                return true;

            }
            catch (Exception ee)
            {
                if (trans != null)
                    try
                    {
                        trans.Rollback();
                    }
                    catch { }
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        /// <summary>
        /// Update the rule of an order
        /// </summary>
        /// <param name="id_order">Order ID</param>
        /// <param name="rule"></param>
        /// <returns></returns>
        public static bool UpdateOrderRule(int id_order, string rule)
        {
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                conn.Open();
                SqlCommand sql = new SqlCommand("UPDATE " + Const.TABLE_PREFIX + "orders SET [rule]=@rule,[dt_rule]=@dt_rule WHERE [id]=@id", conn);
                sql.Parameters.AddWithValue("rule", rule);
                sql.Parameters.AddWithValue("id", id_order);
                if (rule == Const.YES)
                    sql.Parameters.AddWithValue("dt_rule", DateTime.Now);
                else
                    sql.Parameters.AddWithValue("dt_rule", Const.NO_DATE);

                sql.ExecuteNonQuery();
                return true;

            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        public static int GetOrderNewTransactionID(int id_order)
        {
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            SqlTransaction trans = null;
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand sql = new SqlCommand("SELECT MAX(transaction_id) FROM " + Const.TABLE_PREFIX + "orders", conn, trans);
                int transaction_id = 0;
                int.TryParse("" + sql.ExecuteScalar(), out transaction_id);
                transaction_id++;

                sql = new SqlCommand("UPDATE " + Const.TABLE_PREFIX + "orders SET [transaction_id]=@transaction_id WHERE [id]=@id", conn, trans);
                sql.Parameters.AddWithValue("transaction_id", transaction_id);
                sql.Parameters.AddWithValue("id", id_order);

                sql.ExecuteNonQuery();
                trans.Commit();
                return transaction_id;

            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return 0;
        }

        #endregion

        #region Affectation

        /// <summary>
        /// Create a list of affectations
        /// </summary>
        /// <param name="cric">Club cric</param>
        /// <returns></returns>
        public static List<Affectation> ListAffectation(int cric)
        {
            List<Affectation> list = new List<Affectation>();
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                DataSet ds = new DataSet();

                conn.Open();

                SqlCommand sql = new SqlCommand("SELECT * FROM " + Const.TABLE_PREFIX + "rya", conn);

                SqlDataAdapter da = new SqlDataAdapter(sql);
                da.Fill(ds);

                foreach (DataRow rd in ds.Tables[0].Rows)
                {
                    Affectation affectation = new Affectation();
                    affectation.function = "" + rd["function"];
                    affectation.cric = (int)rd["cric"];
                    affectation.nim = (int)rd["nim"];
                    affectation.name = "" + rd["name"];
                    list.Add(affectation);
                }
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return list;
        }

        /// <summary>
        /// Create a list of affectations for a rotary year
        /// </summary>
        /// <param name="cric">Club cric</param>
        /// <param name="rotary_year">Rotary year</param>
        /// <returns></returns>
        public static List<Affectation> ListAffectationRY(int cric, int rotary_year)
        {
            List<Affectation> list = new List<Affectation>();
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                conn.Open();
                DataSet ds = new DataSet();
                SqlCommand sql = new SqlCommand("SELECT * FROM " + Const.TABLE_PREFIX + "rya WHERE cric=@cric AND rotary_year=@rotary_year ORDER BY [function]", conn);
                sql.Parameters.AddWithValue("rotary_year", rotary_year);
                sql.Parameters.AddWithValue("cric", cric);
                SqlDataReader rd = sql.ExecuteReader();
                while (rd.Read())
                {
                    Affectation obj = new Affectation();
                    obj.cric = (int)rd["cric"];
                    obj.function = "" + rd["function"];
                    obj.nim = (int)rd["nim"];
                    obj.name = "" + rd["name"];
                    list.Add(obj);
                }
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return list;
        }

        /// <summary>
        /// Create a list of rotary years
        /// </summary>
        /// <returns></returns>
        public static List<int> ListRotaryYears()
        {
            List<int> list = new List<int>();

            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                conn.Open();

                SqlCommand sql = new SqlCommand("select distinct rotary_year from ais_rya order by rotary_year", conn);
                SqlDataReader rd = sql.ExecuteReader();
                if (rd.HasRows)
                    while (rd.Read())
                        list.Add((int)rd["rotary_year"]);
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return list;
        }

        /// <summary>
        /// Create a list of members by their affectation during a rotary year
        /// </summary>
        /// <param name="function"></param>
        /// <param name="year">Rotary year</param>
        /// <returns></returns>
        public static List<Member> ListMembersByRotaryYearAffectation(string function, int year)
        {
            List<Member> list = new List<Member>();

            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                conn.Open();

                SqlCommand sql;
                if (year == Functions.GetRotaryYear())
                    //sql = new SqlCommand("select * FROM " + Const.TABLE_PREFIX + "members where  nim in (select distinct nim from " + Const.TABLE_PREFIX + "aar where rotary_year=@year and function=@function) order by club_name", conn);
                    sql = new SqlCommand("select * FROM " + Const.TABLE_PREFIX + "members M," + Const.TABLE_PREFIX + "rya A where A.cric = M.cric and  A.nim=M.nim and A.function=@function and A.rotary_year = @year  order by M.club_name", conn);
                else
                    //sql = new SqlCommand("select * FROM " + Const.TABLE_PREFIX + "members_archives where year=@year and month=(select top 1 month from " + Const.TABLE_PREFIX + "members_archives where year=@year order by month desc)  and nim in (select distinct nim from " + Const.TABLE_PREFIX + "aar where rotary_year=@year and function=@function) order by club_name", conn);
                    sql = new SqlCommand("select * FROM ais_archived_members M,ais_rya A where A.cric = M.cric and M.month = 6 and M.year=(@year+1) and  A.nim=M.nim and A.function=@function and A.rotary_year = @year  order by A.name", conn);
                sql.Parameters.AddWithValue("year", year);
                sql.Parameters.AddWithValue("function", function);
                SqlDataAdapter da = new SqlDataAdapter(sql);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables.Count > 0)
                    foreach (DataRow rd in ds.Tables[0].Rows)
                        list.Add(GetMemberByRD(rd));

            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return list;
        }

        /// <summary>
        /// Edit the affectations
        /// </summary>
        /// <param name="cric">Club cric</param>
        /// <param name="rotary_year">Rotary year</param>
        /// <param name="affecations"></param>
        /// <returns></returns>
        public static bool UpdateAffectationRY(int cric, int rotary_year, List<Affectation> affecations)
        {
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            SqlTransaction trans = null;
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();

                SqlCommand sql = new SqlCommand("DELETE FROM " + Const.TABLE_PREFIX + "rYA WHERE cric=@cric AND rotary_year=@rotary_year", conn, trans);
                sql.Parameters.AddWithValue("cric", cric);
                sql.Parameters.AddWithValue("rotary_year", rotary_year);
                sql.ExecuteNonQuery();

                foreach (Affectation affectation in affecations)
                {
                    sql = new SqlCommand("INSERT INTO " + Const.TABLE_PREFIX + "rya (rotary_year,[function],cric,nim,name) VALUES (@rotary_year,@function,@cric,@nim,@name) ", conn, trans);
                    sql.Parameters.AddWithValue("cric", cric);
                    sql.Parameters.AddWithValue("rotary_year", rotary_year);
                    sql.Parameters.AddWithValue("function", affectation.function);
                    sql.Parameters.AddWithValue("nim", affectation.nim);
                    sql.Parameters.AddWithValue("name", affectation.name);
                    if (sql.ExecuteNonQuery() == 0)
                        throw new Exception("Erreur insertion affectation : " + affectation.name + " : " + affectation.function);

                }

                sql = new SqlCommand("DELETE FROM " + Const.TABLE_PREFIX + "ry WHERE cric=@cric AND rotary_year=@rotary_year", conn, trans);
                sql.Parameters.AddWithValue("cric", cric);
                sql.Parameters.AddWithValue("rotary_year", rotary_year);
                sql.ExecuteNonQuery();

                sql = new SqlCommand("INSERT INTO " + Const.TABLE_PREFIX + "ry (rotary_year,cric,confirmed) VALUES (@rotary_year,@cric,@confirmee) ", conn, trans);
                sql.Parameters.AddWithValue("cric", cric);
                sql.Parameters.AddWithValue("rotary_year", rotary_year);
                sql.Parameters.AddWithValue("confirmee", Const.YES);
                if (sql.ExecuteNonQuery() == 0)
                    throw new Exception("Erreur insertion confirmation : " + cric + " : " + rotary_year);


                trans.Commit();
                return true;
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
                if (trans != null)
                    try { trans.Rollback(); }
                    catch { }
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        /// <summary>
        /// Get an affectation
        /// </summary>
        /// <param name="nim">Member nim</param>
        /// <param name="year">Rotary year</param>
        /// <returns></returns>
        public static Affectation GetAffectation(int nim, int year)
        {
            Affectation affectation = new Affectation();
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                DataSet ds = new DataSet();

                conn.Open();

                SqlCommand sql = new SqlCommand("SELECT * FROM " + Const.TABLE_PREFIX + "rya WHERE nim = @nim and rotary_year = @year", conn);
                sql.Parameters.AddWithValue("year", year);
                sql.Parameters.AddWithValue("nim", nim);

                SqlDataAdapter da = new SqlDataAdapter(sql);
                da.Fill(ds);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DataRow rd = ds.Tables[0].Rows[0];

                    affectation.function = "" + rd["function"];
                    affectation.cric = (int)rd["cric"];
                    affectation.nim = (int)rd["nim"];
                    affectation.name = "" + rd["name"];
                }
                else
                {
                    affectation = null;
                }
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return affectation;
        }

        #endregion Affectation

        #region Functions

        /// <summary>
        /// Get functions
        /// </summary>
        /// <returns></returns>
        public static List<string> GetFunctions()
        {
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            List<string> thelist = new List<string>();

            try
            {
                conn.Open();
                SqlCommand sql = new SqlCommand("SELECT DISTINCT [function] FROM " + Const.TABLE_PREFIX + "rya", conn);

                SqlDataAdapter da = new SqlDataAdapter(sql);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow r in ds.Tables[0].Rows)
                    {
                        thelist.Add(r[0].ToString());
                    }
                }
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return thelist;
        }

        /// <summary>
        /// Get a list of functions thanks to a club cric
        /// </summary>
        /// <param name="cric">Club cric</param>
        /// <returns></returns>
        public static List<string> ListFunctionsRY(int cric)
        {
            List<string> list = new List<string>();
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                conn.Open();
                DataSet ds = new DataSet();
                SqlCommand sql = new SqlCommand("SELECT DISTINCT [function] FROM " + Const.TABLE_PREFIX + "rya WHERE " + (cric == 0 ? "cric=0" : "cric>0") + " ORDER BY [function]", conn);
                SqlDataReader rd = sql.ExecuteReader();
                while (rd.Read())
                {
                    list.Add("" + rd["function"]);
                }
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return list;
        }
        #endregion Fonctions

        #region Divers

        /// <summary>
        /// Create or edit a user
        /// </summary>
        /// <param name="membreid">Member ID</param>
        /// <param name="email">Member email</param>
        /// <returns></returns>
        public static bool UpdateOrCreateUser(int membreid, string email, string password = "")
        {
            Member membre = GetMember(membreid);
            if (membre == null)
                return false;
            if (String.IsNullOrEmpty(membre.email))
                return false;
            return UpdateOrCreateUser(membre, password);
        }
        public static bool UpdateOrCreateUser(Member membre, string password = "", SqlConnection conn = null,SqlTransaction trans=null) 
        {
            int lastuserid = membre.userid;
           
            UserInfo ui = UserController.GetUserById(Globals.GetPortalSettings().PortalId, membre.userid);
            if(ui==null)
            { 
                ui = UserController.GetUserByName(Globals.GetPortalSettings().PortalId, membre.email);

                // il n'y pas d'email ni utilisateur alors pas de pb
                if (String.IsNullOrEmpty(membre.email))
                    return false;

            }
            if (ui == null)
            {
                ui = new UserInfo();
                ui.Username = membre.email;
                ui.FirstName = membre.name;
                ui.LastName = membre.surname;
                ui.DisplayName = membre.name + " " + membre.surname;
                ui.Email = membre.email;
                ui.IsSuperUser = false;
                ui.PortalID = Globals.GetPortalSettings().PortalId;

                UserMembership mb = new UserMembership(ui);
                mb.IsDeleted = false;                
                mb.Approved = true;
                mb.CreatedDate = System.DateTime.Now;
                

                if (password.Equals(""))
                {
                    password = "" + DateTime.Now.Ticks;
                    password = "rodi" + password.Substring(password.Length - 4, 4);
                }
                //password = "rodi1730test";
                mb.Password = password;

                ui.Membership = mb;


                if (UserCreateStatus.Success == UserController.CreateUser(ref ui))
                {

                    DotNetNuke.Security.Roles.RoleController rc = new DotNetNuke.Security.Roles.RoleController();
                    RoleInfo uri = rc.GetRoleByName(Globals.GetPortalSettings().PortalId, Const.ROLE_MEMBERS);
                    rc.AddUserRole(Globals.GetPortalSettings().PortalId, ui.UserID, uri.RoleID, Null.NullDate, Null.NullDate);


                    return UpdateMemberDNNUserID(membre.id, ui.UserID, conn, trans);

                }
                return false;
            }
            else
            {
                if(membre.email!=ui.Username)
                {
                    if(String.IsNullOrEmpty(membre.email))
                    {
                        bool mustlogout = PortalSettings.Current.UserInfo.UserID == ui.UserID;
                        // on detruit l'utilisateur si pas d'email n'existe pas
                        if (UserController.DeleteUser(ref ui, false, false))
                        {
                            if (mustlogout)
                            {

                                PortalSecurity objPortalSecurity = new PortalSecurity();
                                objPortalSecurity.SignOut();
                            }

                            membre.id = 0;
                            //DataCache.ClearCache();
                            return UpdateMemberDNNUserID(membre.id, ui.UserID, conn, trans);
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        bool mustrelogin = PortalSettings.Current.UserInfo.UserID == ui.UserID;

                        UserController.ChangeUsername(ui.UserID, membre.email);
                        ui = UserController.GetUserById(PortalSettings.Current.PortalId, ui.UserID);
                        if (mustrelogin)
                        {
                            // on reloggue automatiquement l'utilisateur si c'est lui meme qui change son mail
                            LoginStatus loginStatus;
                            UserController.UserLogin(PortalSettings.Current.PortalId, ui, PortalSettings.Current.PortalName, HttpContext.Current.Request.UserHostAddress, false);
                        }
                    }
                
                }
                ui.FirstName = membre.name;
                ui.LastName = membre.surname;
                ui.DisplayName = membre.name + " " + membre.surname;
                ui.Email = membre.email;
                ui.IsDeleted = false;
                
                //UserMembership mb = new UserMembership(ui);
                
                //mb.IsDeleted = false;
                //mb.Approved = true;

                UserController.UpdateUser(Globals.GetPortalSettings().PortalId, ui,true,false);
                
                //DataCache.ClearCache();
                if(ui.UserID!=membre.userid)
                {
                    return UpdateMemberDNNUserID(membre.id, ui.UserID, conn, trans);
                }
                return true;
            }

        }

        /// <summary>
        /// Check if the member has a defined role
        /// </summary>
        /// <param name="membreid">Member ID</param>
        /// <param name="rolename">Role name</param>
        /// <returns></returns>
        public static bool IsMemberInRole(int memberid, string rolename)
        {
            Member member = GetMember(memberid);
            if (member != null && member.userid != 0)
            {
                UserInfo ui = UserController.GetUserById(Globals.GetPortalSettings().PortalId, member.userid);
                if (ui != null)
                {
                    return ui.IsInRole(rolename);
                }
            }
            return false;
        }

        /// <summary>
        /// Define if the member is an ADG
        /// </summary>
        /// <param name="membreid"></param>
        /// <returns></returns>
        public static bool isADG(int memberid)
        {
            Member member = GetMember(memberid);
            if (member != null && member.userid != 0)
            {
                UserInfo ui = UserController.GetUserById(Globals.GetPortalSettings().PortalId, member.userid);
                for (int i = 0; i < ui.Roles.Count(); i++)
                {
                    if (ui.Roles[i].StartsWith("ADG"))
                        return true;
                }
            }

            return false;
        }

        public static bool isADG()
        {
            return Functions.GetCurrentMember() != null && DataMapping.isADG(Functions.GetCurrentMember().id);
        }

        /// <summary>
        /// Export DataTables to XLS file
        /// </summary>
        /// <param name="tables"></param>
        /// <param name="name">File name</param>
        /// <param name="sf">Save Format</param>
        /// <returns></returns>
        public static Media ExportDataTablesToXLS(List<DataTable> tables, string name, Aspose.Cells.SaveFormat sf)
        {
            InitLicenceAsposeCells();
            Workbook xls = new Workbook();
            int tablenum = 0;
            foreach (DataTable table in tables)
            {
                if (tablenum > 0)
                    xls.Worksheets.Add();
                Worksheet sheet = xls.Worksheets[tablenum++];
                sheet.Name = table.TableName;
                ImportTableOptions opt = new ImportTableOptions();
                opt.TotalRows = table.Rows.Count;
                sheet.Cells.ImportData(table.DefaultView, 0, 0, opt);
                sheet.AutoFitColumns();
            }

            MemoryStream ms = new MemoryStream();
            if (sf == Aspose.Cells.SaveFormat.CSV)
            {
                Aspose.Cells.TxtSaveOptions o = new TxtSaveOptions(sf);
                o.Separator = Convert.ToChar(";");
                xls.Save(ms, o);

            }
            else
            {
                xls.Save(ms, sf);
            }


            Media media = new Media();
            media.content = ms.ToArray();
            media.content_size = media.content.Length;
            media.dt = DateTime.Now;
            media.name = name;
            switch (sf)
            {
                case Aspose.Cells.SaveFormat.CSV:
                    media.content_type = "text/csv";
                    break;
                case Aspose.Cells.SaveFormat.Excel97To2003:
                    media.content_type = "application/vnd.ms-excel";
                    break;
                case Aspose.Cells.SaveFormat.Xlsx:
                    media.content_type = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    break;
                case Aspose.Cells.SaveFormat.TabDelimited:
                    media.content_type = "text/tab-separated-values";
                    break;
                case Aspose.Cells.SaveFormat.TIFF:
                    media.content_type = "image/tiff";
                    break;

            }


            return media;
        }

        /// <summary>
        /// Export a GridView to Excel
        /// </summary>
        /// <param name="gv"></param>
        /// <param name="name">File name</param>
        /// <param name="sf">Export format</param>
        /// <returns></returns>
        public static Media ExportDataGridToXLS(GridView gv, string name, Aspose.Cells.SaveFormat sf)
        {
            DataTable table = new DataTable();
            foreach (DataControlField col in gv.Columns)
            {
                table.Columns.Add(new DataColumn(HttpContextSource.Current.Server.HtmlDecode(col.HeaderText)));
            }
            foreach (GridViewRow row in gv.Rows)
            {
                DataRow r = table.NewRow();
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    DataControlFieldCell cell = row.Cells[i] as DataControlFieldCell;
                    r[i] = HttpContextSource.Current.Server.HtmlDecode(cell.Text);
                }

                table.Rows.Add(r);
            }




            InitLicenceAsposeCells();



            Workbook xls = new Workbook();
            Worksheet sheet = xls.Worksheets[0];
            ImportTableOptions opt = new ImportTableOptions();
            opt.TotalRows = table.Rows.Count;
            sheet.Cells.ImportData(table.DefaultView, 0, 0, opt);
            sheet.AutoFitColumns();

            MemoryStream ms = new MemoryStream();
            if (sf == Aspose.Cells.SaveFormat.CSV)
            {
                Aspose.Cells.TxtSaveOptions o = new TxtSaveOptions(sf);
                o.Separator = Convert.ToChar(";");
                xls.Save(ms, o);

            }
            else
            {
                xls.Save(ms, sf);
            }

            Media media = new Media();
            media.content = ms.ToArray();
            media.content_size = media.content.Length;
            media.dt = DateTime.Now;
            media.name = name;
            switch (sf)
            {
                case Aspose.Cells.SaveFormat.CSV:
                    media.content_type = "text/csv";
                    break;
                case Aspose.Cells.SaveFormat.Excel97To2003:
                    media.content_type = "application/vnd.ms-excel";
                    break;
                case Aspose.Cells.SaveFormat.Xlsx:
                    media.content_type = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    break;
                case Aspose.Cells.SaveFormat.TabDelimited:
                    media.content_type = "text/tab-separated-values";
                    break;
                case Aspose.Cells.SaveFormat.TIFF:
                    media.content_type = "image/tiff";
                    break;

            }


            return media;
        }

        /// <summary>
        /// Insert data into ws_stats table
        /// </summary>
        /// <param name="os"></param>
        /// <param name="device"></param>
        /// <param name="version"></param>
        /// <param name="ip"></param>
        /// <param name="datetime"></param>
        /// <param name="duree"></param>
        /// <param name="function"></param>
        /// <param name="code"></param>
        /// <param name="comment"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public static bool InsertLogWS(string os, string device, string version, string ip, DateTime datetime, float duration, string function, string code, string comment, string username)
        {
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                conn.Open();

                SqlCommand sql = new SqlCommand("INSERT INTO " + Const.TABLE_PREFIX + "ws_stats ([os],[device],[version],[ip],[datetime],[duration],[function],[code],[comment],[username]) VALUES (@os,@device,@version,@ip,@datetime,@duration,@function,@code,@comment,@username)", conn);


                sql.Parameters.AddWithValue("@os", os);
                sql.Parameters.AddWithValue("@device", device);
                sql.Parameters.AddWithValue("@version", version);
                sql.Parameters.AddWithValue("@ip", ip);
                sql.Parameters.AddWithValue("@datetime", datetime);
                sql.Parameters.AddWithValue("@duration", duration);
                sql.Parameters.AddWithValue("@function", function);
                sql.Parameters.AddWithValue("@code", code);
                sql.Parameters.AddWithValue("@comment", comment);
                sql.Parameters.AddWithValue("@username", username);
                if (sql.ExecuteNonQuery() == 0)
                    throw new Exception("Erreur lors de l'insert dans ws_stats");
                return true;

            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }


        #endregion Divers

        #region Club

        


        /// <summary>
        /// Get a list of clubs
        /// </summary>
        /// <param name="dept"></param>
        /// <param name="top"></param>
        /// <param name="tri"></param>
        /// <param name="index"></param>
        /// <param name="max"></param>
        /// <param name="club_type"></param>
        /// <returns></returns>
        public static List<Club> ListClubs(string dept = "", string top = "", string sort = "", int index = 0, int max = 1000, string club_type = "")
        {
            List<Club> list = new List<Club>();
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                DataSet ds = new DataSet();
                string where = "";
                if (dept != "")
                    where = " WHERE SUBSTRING(zip, 1, 2) IN (" + dept + ") ";

                if (!string.IsNullOrEmpty(club_type))
                {
                    if (where.StartsWith(" WHERE "))
                    {
                        where = where + " AND type_club = '" + club_type + "' ";
                    }
                    else
                    {
                        where = where + " WHERE type_club = '" + club_type + "' ";
                    }
                }

                string query = "SELECT " + top + " * FROM " + Const.TABLE_PREFIX + "clubs " + where + (sort != "" ? "ORDER BY " + sort : "");
                //if (HttpContextSource.Current.Session["club:" + query] != null)
                //    ds = (DataSet)HttpContextSource.Current.Session["club:" + query];
                //else
                //{
                conn.Open();

                SqlCommand sql = new SqlCommand(query, conn);

                SqlDataAdapter da = new SqlDataAdapter(sql);
                da.Fill(ds);

                //    HttpContextSource.Current.Session["club:" + query] = ds;
                //}
                int i = 0;
                int c = 0;
                foreach (DataRow rd in ds.Tables[0].Rows)
                {
                    if (i >= (index * max) && c < max)
                    {
                        list.Add(GetClubByRD(rd));
                        c++;
                    }
                    else
                    {
                        list.Add(new Club());
                    }
                    i++;
                }
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return list;
        }

        /// <summary>
        /// Get a club
        /// </summary>
        /// <param name="cric">Club cric</param>
        /// <returns></returns>
        public static Club GetClub(int cric)
        {
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                string query = "SELECT * FROM " + Const.TABLE_PREFIX + "clubs WHERE cric=@cric";
                conn.Open();
                DataSet ds = new DataSet();
                SqlCommand sql = new SqlCommand(query, conn);
                sql.Parameters.AddWithValue("cric", cric);
                SqlDataAdapter da = new SqlDataAdapter(sql);
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                    return GetClubByRD(ds.Tables[0].Rows[0]);
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }

            return null;
        }

        /// <summary>
        /// Get a club with its SEO
        /// </summary>
        /// <param name="seo">Club SEO</param>
        /// <returns></returns>
        public static Club GetClubBySeo(string seo)
        {
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                string query = "SELECT * FROM " + Const.TABLE_PREFIX + "clubs WHERE seo=@seo";
                conn.Open();
                DataSet ds = new DataSet();
                SqlCommand sql = new SqlCommand(query, conn);
                sql.Parameters.AddWithValue("seo", seo);
                SqlDataAdapter da = new SqlDataAdapter(sql);
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                    return GetClubByRD(ds.Tables[0].Rows[0]);
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }

            return null;
        }

        /// <summary>
        /// Get a club thanks to a DataRow
        /// </summary>
        /// <param name="rd"></param>
        /// <returns></returns>
        public static Club GetClubByRD(DataRow rd)
        {
            Club obj = new Club();
            if (rd["cric"] == DBNull.Value) obj.cric = 0; else obj.cric = (int)rd["cric"];
            if (rd["district_id"] == DBNull.Value) obj.district_id = Const.DISTRICT_ID; else obj.district_id = (int)rd["district_id"];
            obj.name = "" + rd["name"];
            obj.roles = "" + rd["roles"];
            obj.adress_1 = "" + rd["adress_1"];
            obj.adress_2 = "" + rd["adress_2"];
            obj.adress_3 = "" + rd["adress_3"];
            obj.zip = "" + rd["zip"];
            obj.town = "" + rd["town"];
            obj.pennant = "" + rd["pennant"];
            obj.meetings = "" + rd["meetings"];
            obj.telephone = "" + rd["telephone"];
            obj.fax = "" + rd["fax"];
            obj.email = "" + rd["email"];
            obj.web = "" + rd["web"];
            obj.text = "" + rd["text"];
            obj.seo = "" + rd["seo"];
            obj.latitude = "" + rd["latitude"];
            obj.longitude = "" + rd["longitude"];
            obj.meeting_adr1 = "" + rd["meeting_adr1"];
            obj.meeting_adr2 = "" + rd["meeting_adr2"];
            obj.meeting_zip = "" + rd["meeting_zip"];
            obj.meeting_town = "" + rd["meeting_town"];
            obj.former_presidents = "" + rd["former_presidents"];
            obj.club_type = "" + rd["type_club"];
            obj.seo_mode = "" + rd["seo_mode"];
            obj.domaine = "" + rd["domaine"];
            obj.payment_method = "" + rd["payment_method"];
            if (rd["nb_free_of_charge"] == System.DBNull.Value) obj.nb_free_of_charge = 0; else obj.nb_free_of_charge = (int)rd["nb_free_of_charge"];

            return obj;
        }

        /// <summary>
        /// Edit a club
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool UpdateClub(Club c, int last_cric)
        {
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            SqlTransaction trans = null;
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();

                SqlCommand sql = new SqlCommand("UPDATE " + Const.TABLE_PREFIX + "clubs SET [district_id]=@district_id,[name]=@name,[adress_1]=@adress_1,[adress_2]=@adress_2,[adress_3]=@adress_3,[zip]=@zip,[town]=@town,[pennant]=@pennant,[meetings]=@meetings,[telephone]=@telephone,[fax]=@fax,[email]=@email,[web]=@web,[text]=@text,[seo]=@seo,[latitude]=@latitude,[longitude]=@longitude,[meeting_adr1]=@meeting_adr1,[meeting_adr2]=@meeting_adr2,[meeting_zip]=@meeting_zip,[meeting_town]=@meeting_town,[former_presidents]=@former_presidents,[cric]=@cric,roles=@roles,seo_mode=@seo_mode,domaine=@domaine,type_club=@type_club,nb_free_of_charge=@nb_free_of_charge,payment_method=@payment_method WHERE cric=@last_cric", conn, trans);

                sql.Parameters.AddWithValue("@cric", c.cric);
                sql.Parameters.AddWithValue("@last_cric", last_cric);

                sql.Parameters.AddWithValue("@district_id", c.district_id);
                sql.Parameters.AddWithValue("@name", c.name);
                sql.Parameters.AddWithValue("@adress_1", "" + c.adress_1);
                sql.Parameters.AddWithValue("@adress_2", "" + c.adress_2);
                sql.Parameters.AddWithValue("@adress_3", "" + c.adress_3);
                sql.Parameters.AddWithValue("@zip", "" + c.zip);
                sql.Parameters.AddWithValue("@town", "" + c.town);
                sql.Parameters.AddWithValue("@pennant", "" + c.pennant);
                sql.Parameters.AddWithValue("@meetings", "" + c.meetings);
                sql.Parameters.AddWithValue("@telephone", "" + c.telephone);
                sql.Parameters.AddWithValue("@fax", "" + c.fax);
                sql.Parameters.AddWithValue("@email", "" + c.email);
                sql.Parameters.AddWithValue("@web", "" + c.web);
                sql.Parameters.AddWithValue("@text", "" + c.text);
                sql.Parameters.AddWithValue("@seo", "" + c.seo);
                sql.Parameters.AddWithValue("@latitude", "" + c.latitude);
                sql.Parameters.AddWithValue("@longitude", "" + c.longitude);
                sql.Parameters.AddWithValue("@meeting_adr1", "" + c.meeting_adr1);
                sql.Parameters.AddWithValue("@meeting_adr2", "" + c.meeting_adr2);
                sql.Parameters.AddWithValue("@meeting_zip", "" + c.meeting_zip);
                sql.Parameters.AddWithValue("@meeting_town", "" + c.meeting_town);
                sql.Parameters.AddWithValue("@former_presidents", "" + c.former_presidents);
                sql.Parameters.AddWithValue("@roles", "" + c.roles);
                sql.Parameters.AddWithValue("@seo_mode", "" + c.seo_mode);
                sql.Parameters.AddWithValue("@domaine", "" + c.domaine);
                sql.Parameters.AddWithValue("@type_club", "" + c.club_type);
                sql.Parameters.AddWithValue("@payment_method", c.payment_method);
                sql.Parameters.AddWithValue("@nb_free_of_charge", c.nb_free_of_charge);
                if (sql.ExecuteNonQuery() == 0)
                    throw new Exception("Erreur update club : " + c.cric);


                sql = new SqlCommand("UPDATE " + Const.TABLE_PREFIX + "members SET cric=@cric,club_name=@club_name WHERE cric=@last_cric", conn, trans);
                sql.Parameters.AddWithValue("@last_cric", last_cric);
                sql.Parameters.AddWithValue("@cric", c.cric);
                sql.Parameters.AddWithValue("@club_name", c.name);


                sql.ExecuteNonQuery();


                trans.Commit();

                ClearClubCache();

                return true;
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
                if (trans != null)
                    try { trans.Rollback(); }
                    catch { }
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        /// <summary>
        /// Add a club
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static void InsertClub(Club c)
        {
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            SqlTransaction trans = null;
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand sql = new SqlCommand("INSERT INTO  " + Const.TABLE_PREFIX + "clubs ([cric],[district_id],[name],[adress_1],[adress_2],[adress_3],[zip],[town],[pennant],[meetings],[telephone],[fax],[email],[web],[text],[seo],[latitude],[longitude],[meeting_adr1],[meeting_adr2],[meeting_zip],[meeting_town],[former_presidents],[type_club],[roles],[seo_mode],[domaine],[payment_method],[nb_free_of_charge]) VALUES (@cric,@district_id,@name,@adress_1,@adress_2,@adress_3,@zip,@town,@pennant,@meetings,@telephone,@fax,@email,@web,@text,@seo,@latitude,@longitude,@meeting_adr1,@meeting_adr2,@meeting_zip,@meeting_town,@former_presidents,@type_club,@roles,@seo_mode,@domaine,@payment_method,@nb_free_of_charge)", conn, trans);

                sql.Parameters.AddWithValue("@cric", c.cric);
                sql.Parameters.AddWithValue("@district_id", c.district_id);
                sql.Parameters.AddWithValue("@name", c.name);
                sql.Parameters.AddWithValue("@adress_1", "" + c.adress_1);
                sql.Parameters.AddWithValue("@adress_2", "" + c.adress_2);
                sql.Parameters.AddWithValue("@adress_3", "" + c.adress_3);
                sql.Parameters.AddWithValue("@zip", "" + c.zip);
                sql.Parameters.AddWithValue("@town", "" + c.town);
                if (!string.IsNullOrEmpty(c.pennant))
                {
                    sql.Parameters.AddWithValue("@pennant", "" + c.pennant);
                }
                else
                {
                    sql.Parameters.AddWithValue("@pennant", DBNull.Value);
                }

                sql.Parameters.AddWithValue("@meetings", "" + c.meetings);
                sql.Parameters.AddWithValue("@telephone", "" + c.telephone);
                sql.Parameters.AddWithValue("@fax", "" + c.fax);
                sql.Parameters.AddWithValue("@email", "" + c.email);
                sql.Parameters.AddWithValue("@web", "" + c.web);
                sql.Parameters.AddWithValue("@text", "" + c.text);
                sql.Parameters.AddWithValue("@seo", "" + c.seo);
                sql.Parameters.AddWithValue("@latitude", "" + c.latitude);
                sql.Parameters.AddWithValue("@longitude", "" + c.longitude);
                sql.Parameters.AddWithValue("@meeting_adr1", "" + c.meeting_adr1);
                sql.Parameters.AddWithValue("@meeting_adr2", "" + c.meeting_adr2);
                sql.Parameters.AddWithValue("@meeting_zip", "" + c.meeting_zip);
                sql.Parameters.AddWithValue("@meeting_town", "" + c.meeting_town);
                sql.Parameters.AddWithValue("@former_presidents", "" + c.former_presidents);
                sql.Parameters.AddWithValue("@type_club", "" + c.club_type);
                sql.Parameters.AddWithValue("@roles", "" + c.roles);
                sql.Parameters.AddWithValue("@seo_mode", "" + c.seo_mode);
                sql.Parameters.AddWithValue("@domaine", "" + c.domaine);
                sql.Parameters.AddWithValue("@payment_method", c.payment_method);
                sql.Parameters.AddWithValue("@nb_free_of_charge", c.nb_free_of_charge);

                if (sql.ExecuteNonQuery() == 0)
                    throw new Exception("Erreur insert club");


                trans.Commit();

                ClearClubCache();

            }
            catch (Exception ee)
            {
                Functions.Error(ee);
                if (trans != null)
                    try { trans.Rollback(); }
                    catch { }
            }
            finally
            {
                conn.Close();
            }
            return;
        }

        /// <summary>
        /// Delete a club
        /// </summary>
        /// <param name="cric">Club cric to delete</param>
        /// <returns></returns>
        public static bool DeleteClub(int cric)
        {
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            SqlTransaction trans = null;
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();

                SqlCommand sql = new SqlCommand("DELETE " + Const.TABLE_PREFIX + "members WHERE cric=@cric", conn, trans);
                sql.Parameters.AddWithValue("@cric", cric);
                sql.ExecuteNonQuery();

                sql = new SqlCommand("DELETE " + Const.TABLE_PREFIX + "clubs WHERE cric=@cric", conn, trans);
                sql.Parameters.AddWithValue("@cric", cric);
                sql.ExecuteNonQuery();

                trans.Commit();

                return true;

            }
            catch (Exception ee)
            {
                if (trans != null)
                    try
                    {
                        trans.Rollback();
                    }
                    catch { }
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        public static List<String> ListSeo()
        {
            List<String> res = new List<String>();
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            DataSet ds = new DataSet();
            string query = "SELECT  * FROM " + Const.TABLE_PREFIX + "clubs";
            try
            {
                conn.Open();

                SqlCommand sql = new SqlCommand(query, conn);

                SqlDataAdapter da = new SqlDataAdapter(sql);
                da.Fill(ds);
                foreach (DataRow rd in ds.Tables[0].Rows)
                {
                    res.Add(GetClubByRD(rd).seo);
                }


            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return res;

        }
        #endregion Club

        #region Member

        /// <summary>
        /// Get a list of members
        /// </summary>
        /// <param name="cric">Club cric</param>
        /// <param name="criterion"></param>
        /// <param name="top"></param>
        /// <param name="sort">Sorting type</param>
        /// <param name="index"></param>
        /// <param name="max"></param>
        /// <param name="onlyvisible"></param>
        /// <param name="court"></param>
        /// <returns></returns>
        public static List<Member> ListMembers(int cric = 0, string criterion = "", string top = "", string sort = "", int index = 0, int max = 100, bool onlyvisible = false, bool court = false)
        {
            List<Member> list = new List<Member>();
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            string[] keywords = criterion.Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                DataSet ds = new DataSet();
                string where = "";
                if (criterion != "")
                {

                    for (int ii = 0; ii < keywords.Length; ii++)
                    {
                        if (where != "")
                            where = where + " OR ";
                        where = " email LIKE @criterion" + ii + " OR surname LIKE @criterion" + ii + " OR name LIKE @criterion" + ii + " OR job LIKE @criterion" + ii + " OR industry LIKE @criterion" + ii + " ";
                        if (!keywords[ii].StartsWith("%"))
                            keywords[ii] = "%" + keywords[ii];
                        if (!keywords[ii].EndsWith("%"))
                            keywords[ii] = keywords[ii] + "%";
                    }
                    if (where != "")
                        where = " (" + where + ") ";
                }
                if (cric != 0)
                {
                    if (where != "")
                        where += " AND ";
                    where += " cric = @cric ";
                }

                if (onlyvisible)
                {
                    if (where != "")
                        where += " AND ";
                    where += " visible='" + Const.YES + "' ";
                }

                //where = where + "";

                if (where != "")
                {
                    where = " WHERE " + where;
                }

                string query = "";
                if (court == false)
                {
                    //string query = "SELECT " + top + " M.* FROM " + Const.TABLE_PREFIX + "members as M, " + Const.TABLE_PREFIX + "subscription as A" + where + (sort!= "" ? "ORDER BY " + sort: "");
                    query = "SELECT " + top + " * FROM " + Const.TABLE_PREFIX + "members " + where + (sort != "" ? "ORDER BY " + sort : "");
                }
                else
                {
                    query = "SELECT " + top + " id, nim, surname, name, cric, civility, job, industry, base_dtupdate, retired, district_id, club_name, userid FROM " + Const.TABLE_PREFIX + "members " + where + (sort != "" ? "ORDER BY " + sort : "");
                }

                //if (where == "" && HttpContextSource.Current.Session["members:" + query] != null)
                //    ds = (DataSet)HttpContextSource.Current.Session["members:" + query];
                //else
                //{
                conn.Open();
                SqlCommand sql = new SqlCommand(query, conn);
                if (keywords.Length > 0)
                    for (int ii = 0; ii < keywords.Length; ii++)
                        sql.Parameters.AddWithValue("criterion" + ii, keywords[ii]);
                if (cric != 0)
                    sql.Parameters.AddWithValue("cric", cric);

                SqlDataAdapter da = new SqlDataAdapter(sql);
                da.Fill(ds);
                //if (where == "")
                //    HttpContextSource.Current.Session["members:" + query] = ds;
                //}
                int i = 0;
                int c = 0;
                foreach (DataRow rd in ds.Tables[0].Rows)
                {
                    if (i >= (index * max) && c < max)
                    {
                        if (court == false)
                        {
                            list.Add(GetMemberByRD(rd));
                        }
                        else
                        {
                            //id, name, name, cric, civility, job, industry, base_dtupdate, retired, photo, district_id, club_name, userid, visible
                            Member obj = new Member();
                            if (rd["id"] == DBNull.Value) obj.id = 0; else obj.id = (int)rd["id"];
                            if (rd["nim"] == DBNull.Value) obj.nim = 0; else obj.nim = (int)rd["nim"];
                            obj.surname = "" + rd["surname"];
                            obj.name = "" + rd["name"];
                            if (rd["cric"] == DBNull.Value) obj.cric = 0; else obj.cric = (int)rd["cric"];
                            obj.civility = "" + rd["civility"];
                            obj.job = "" + rd["job"];
                            obj.industry = "" + rd["industry"];
                            if (rd["base_dtupdate"] == DBNull.Value) obj.base_dtupdate = null; else obj.base_dtupdate = (DateTime)rd["base_dtupdate"];
                            obj.retired = "" + rd["retired"];
                            if (rd["district_id"] == DBNull.Value) obj.district_id = Const.DISTRICT_ID; else obj.district_id = (int)rd["district_id"];
                            obj.club_name = "" + rd["club_name"];
                            if (rd["userid"] == DBNull.Value) obj.userid = 0; else obj.userid = (int)rd["userid"];
                            // obj.photo = "" + rd["photo"];
                            // obj.visible = "" + rd["visible"];

                            list.Add(obj);
                        }
                    }
                    else
                    {
                        list.Add(new Member());
                    }
                    i++;
                }
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }

            return list;
        }

        /// <summary>
        /// Get the first 10 members
        /// </summary>
        /// <param name="cric">Club cric</param>
        /// <param name="critere"></param>
        /// <param name="tri"></param>
        /// <param name="index"></param>
        /// <param name="max"></param>
        /// <param name="onlyvisible"></param>
        /// <param name="court"></param>
        /// <returns></returns>
        public static List<Member> ListTopTenMembers(int cric = 0, string criterion = "", string sort = "", int index = 0, int max = 100, bool onlyvisible = false, bool court = false)
        {
            List<Member> list = new List<Member>();
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            string[] keywords = criterion.Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                DataSet ds = new DataSet();
                string where = "";
                if (criterion != "")
                {

                    for (int ii = 0; ii < keywords.Length; ii++)
                    {
                        if (where != "")
                            where = where + " OR ";
                        where = " surname LIKE @criterion" + ii + " OR name LIKE @criterion" + ii + " ";
                        if (!keywords[ii].StartsWith("%"))
                            keywords[ii] = "%" + keywords[ii];
                        if (!keywords[ii].EndsWith("%"))
                            keywords[ii] = keywords[ii] + "%";
                    }
                    if (where != "")
                        where = " (" + where + ") ";
                }
                if (cric != 0)
                {
                    if (where != "")
                        where += " AND ";
                    where += " cric = @cric ";
                }

                //if (onlyvisible)
                //{
                //    if (where != "")
                //        where += " AND ";
                //    where += " visible='" + Const.YES + "' ";
                //}

                //where = where + "";

                if (where != "")
                {
                    where = " WHERE " + where;
                }

                string query = "";
                if (court == false)
                {
                    //string query = "SELECT " + top + " M.* FROM " + Const.TABLE_PREFIX + "members as M, " + Const.TABLE_PREFIX + "subscription as A" + where + (sort!= "" ? "ORDER BY " + sort: "");
                    query = "SELECT TOP 10 * FROM " + Const.TABLE_PREFIX + "members " + where + (sort != "" ? "ORDER BY " + sort : "");
                }
                else
                {
                    query = "SELECT TOP10 id, nim, surname, name, cric, civility, job, industry, base_dtupdate, retired, district_id, club_name, userid FROM " + Const.TABLE_PREFIX + "members " + where + (sort != "" ? "ORDER BY " + sort : "");
                }

                //if (where == "" && HttpContextSource.Current.Session["members:" + query] != null)
                //    ds = (DataSet)HttpContextSource.Current.Session["members:" + query];
                //else
                //{
                conn.Open();
                SqlCommand sql = new SqlCommand(query, conn);
                if (keywords.Length > 0)
                    for (int ii = 0; ii < keywords.Length; ii++)
                        sql.Parameters.AddWithValue("criterion" + ii, keywords[ii]);
                if (cric != 0)
                    sql.Parameters.AddWithValue("cric", cric);
                SqlDataAdapter da = new SqlDataAdapter(sql);
                da.Fill(ds);
                //if (where == "")
                //    HttpContextSource.Current.Session["members:" + query] = ds;
                //}
                int i = 0;
                int c = 0;
                foreach (DataRow rd in ds.Tables[0].Rows)
                {
                    if (i >= (index * max) && c < max)
                    {
                        if (court == false && !list.Contains(GetMemberByRD(rd)))
                        {
                            list.Add(GetMemberByRD(rd));
                        }
                        else
                        {
                            //id, name, name, cric, civility, job, industry, base_dtupdate, retired, photo, district_id, club_name, userid, visible
                            Member obj = new Member();
                            if (rd["id"] == DBNull.Value) obj.id = 0; else obj.id = (int)rd["id"];
                            if (rd["nim"] == DBNull.Value) obj.nim = 0; else obj.nim = (int)rd["nim"];
                            obj.surname = "" + rd["surname"];
                            obj.name = "" + rd["name"];
                            if (rd["cric"] == DBNull.Value) obj.cric = 0; else obj.cric = (int)rd["cric"];
                            obj.civility = "" + rd["civility"];
                            obj.job = "" + rd["job"];
                            obj.industry = "" + rd["industry"];
                            if (rd["base_dtupdate"] == DBNull.Value) obj.base_dtupdate = null; else obj.base_dtupdate = (DateTime)rd["base_dtupdate"];
                            obj.retired = "" + rd["retired"];
                            if (rd["district_id"] == DBNull.Value) obj.district_id = Const.DISTRICT_ID; else obj.district_id = (int)rd["district_id"];
                            obj.club_name = "" + rd["club_name"];
                            if (rd["userid"] == DBNull.Value) obj.userid = 0; else obj.userid = (int)rd["userid"];
                            obj.photo = "" + rd["photo"];
                            obj.visible = "" + rd["visible"];

                            if (!list.Contains(obj))
                                list.Add(obj);

                        }
                    }
                    else
                    {
                        list.Add(new Member());
                    }
                    i++;
                }
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }

            return list;
        }

        public static List<Member> SimpleListMembers(string query)
        {
            List<Member> members = null;
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                conn.Open();
                SqlCommand sql;
                if (!string.IsNullOrEmpty(query))
                {
                    //On crée la requête permettant de récupérer les members correspondant aux critères sélectionnés 
                    sql = new SqlCommand("SELECT * FROM " + Const.TABLE_PREFIX + "members WHERE " + query + " ORDER BY name ASC", conn);
                }
                else
                {//Cette requête sélectionne tous les members
                    sql = new SqlCommand("SELECT * FROM " + Const.TABLE_PREFIX + "members ORDER BY name ASC", conn);
                }

                SqlDataAdapter da = new SqlDataAdapter(sql);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    members = new List<Member>();
                    foreach (DataRow rd in ds.Tables[0].Rows)
                    {
                        Member membre = new Member();
                        //On attocie les résultats à chaque attendance qu l'on mettra dans la list
                        if (rd["id"] != DBNull.Value) membre.id = (int)rd["id"];
                        if (rd["cric"] != DBNull.Value) membre.cric = (int)rd["cric"];
                        if (rd["nim"] != DBNull.Value) membre.nim = (int)rd["nim"];
                        if (rd["district_id"] != DBNull.Value) membre.district_id = (int)rd["district_id"];
                        if (rd["surname"] != DBNull.Value) membre.surname = (string)rd["surname"];
                        if (rd["name"] != DBNull.Value) membre.name = (string)rd["name"];
                        if (rd["civility"] != DBNull.Value) membre.civility = (string)rd["civility"];
                        if (rd["email"] != DBNull.Value) membre.email = (string)rd["email"];

                        members.Add(membre);
                    }
                }
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return members;
        }

        /// <summary>
        /// Get a member thanks to a DataRow
        /// </summary>
        /// <param name="rd"></param>
        /// <returns></returns>
        static Member GetMemberByRD(DataRow rd)
        {
            Member obj = new Member();
            if (rd["id"] == DBNull.Value) obj.id = 0; else obj.id = (int)rd["id"];
            if (rd["nim"] == DBNull.Value) obj.nim = 0; else obj.nim = (int)rd["nim"];
            obj.honorary_member = "" + rd["honorary_member"];
            obj.surname = "" + rd["surname"];
            obj.name = "" + rd["name"];
            if (rd["cric"] == DBNull.Value) obj.cric = 0; else obj.cric = (int)rd["cric"];
            obj.active_member = "" + rd["active_member"];
            obj.civility = "" + rd["civility"];
            obj.maiden_name = "" + rd["maiden_name"];
            obj.spouse_name = "" + rd["spouse_name"];
            obj.title = "" + rd["title"];
            if (rd["birth_year"] == DBNull.Value) obj.birth_year = null; else obj.birth_year = (DateTime)rd["birth_year"];
            if (rd["year_membership_rotary"] == DBNull.Value) obj.year_membership_rotary = null; else obj.year_membership_rotary = (DateTime)rd["year_membership_rotary"];
            obj.email = "" + rd["email"];
            obj.adress_1 = "" + rd["adress_1"];
            obj.adress_2 = "" + rd["adress_2"];
            obj.adress_3 = "" + rd["adress_3"];
            obj.zip_code = "" + rd["zip_code"];
            obj.town = "" + rd["town"];
            obj.telephone = "" + rd["telephone"];
            obj.fax = "" + rd["fax"];
            obj.gsm = "" + rd["gsm"];
            obj.country = "" + rd["country"];
            obj.job = "" + rd["job"];
            obj.industry = "" + rd["industry"];
            obj.biography = "" + rd["biography"];
            if (rd["base_dtupdate"] == DBNull.Value) obj.base_dtupdate = null; else obj.base_dtupdate = (DateTime)rd["base_dtupdate"];
            obj.professionnal_adress = "" + rd["professionnal_adress"];
            obj.professionnal_zip_code = "" + rd["professionnal_zip_code"];
            obj.professionnal_town = "" + rd["professionnal_town"];
            obj.professionnal_tel = "" + rd["professionnal_tel"];
            obj.professionnal_fax = "" + rd["professionnal_fax"];
            obj.professionnal_mobile = "" + rd["professionnal_mobile"];
            obj.professionnal_email = "" + rd["professionnal_email"];
            obj.retired = "" + rd["retired"];
            obj.removed = "" + rd["removed"];
            if (rd["district_id"] == DBNull.Value) obj.district_id = Const.DISTRICT_ID; else obj.district_id = (int)rd["district_id"];
            obj.club_name = "" + rd["club_name"];
            if (rd["userid"] == DBNull.Value) obj.userid = 0; else obj.userid = (int)rd["userid"];
            obj.photo = "" + rd["photo"];
            obj.visible = "" + rd["visible"];
            obj.satellite_member = "" + rd["satellite_member"];
            obj.presentation = ("" + rd["presentation"]).Equals(Const.YES);

            return obj;
        }

        /// <summary>
        /// Get a member
        /// </summary>
        /// <param name="membreid">Member ID</param>
        /// <returns>Member</returns>
        public static Member GetMember(int memberid)
        {
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                conn.Open();
                SqlCommand sql = new SqlCommand("SELECT * FROM " + Const.TABLE_PREFIX + "members WHERE id=@id", conn);
                sql.Parameters.AddWithValue("id", memberid);
                SqlDataAdapter da = new SqlDataAdapter(sql);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return GetMemberByRD(ds.Tables[0].Rows[0]);
                }
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return null;
        }

        /// <summary>
        /// Get a member thanks to his nim
        /// </summary>
        /// <param name="nim">member nim</param>
        /// <returns></returns>
        public static Member GetMemberByNim(int nim)
        {
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                conn.Open();
                SqlCommand sql = new SqlCommand("SELECT * FROM " + Const.TABLE_PREFIX + "members WHERE nim=@nim", conn);
                sql.Parameters.AddWithValue("nim", nim);
                SqlDataAdapter da = new SqlDataAdapter(sql);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return GetMemberByRD(ds.Tables[0].Rows[0]);
                }
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return null;
        }

        /// <summary>
        /// Get a member thanks to a user id
        /// </summary>
        /// <param name="userid">User ID</param>
        /// <returns></returns>
        public static Member GetMemberByUserID(int userid)
        {
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                conn.Open();
                SqlCommand sql = new SqlCommand("SELECT * FROM " + Const.TABLE_PREFIX + "members WHERE userid=@id", conn);
                sql.Parameters.AddWithValue("id", userid);
                SqlDataAdapter da = new SqlDataAdapter(sql);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return GetMemberByRD(ds.Tables[0].Rows[0]);
                }
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return null;
        }

        /// <summary>
        /// Check if the user is part of the Rotaract
        /// </summary>
        /// <param name="userid">User ID</param>
        /// <returns></returns>
        public static bool IsRotaract(int userid)
        {
            try
            {
                Member m = GetMemberByUserID(userid);
                if (m != null && m.cric != 0)
                {
                    Club c = GetClub(m.cric);
                    if (c != null && !string.IsNullOrEmpty(c.club_type) && c.club_type == Const.Club_Rotaract)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            return false;
        }

        /// <summary>
        /// Add a member
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public static bool InsertMember(Member m)
        {
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            SqlTransaction trans = null;

            try
            {
                conn.Open();
                trans = conn.BeginTransaction();

                SqlCommand sql = null;
                int NIM = 0;


                sql = new SqlCommand("INSERT INTO " + Const.TABLE_PREFIX + "members ([nim],[honorary_member],[surname],[name],[cric],[active_member],[civility],[maiden_name],[spouse_name],[title],[birth_year],[year_membership_rotary],[email],[adress_1],[adress_2],[adress_3],[zip_code],[town],[telephone],[fax],[gsm],[country],[job],[industry],[biography],[base_dtupdate],[professionnal_adress],[professionnal_zip_code],[professionnal_town],[professionnal_tel],[professionnal_fax],[professionnal_mobile],[professionnal_email],[retired],[removed],[district_id],[club_name],[photo],[visible],[satellite_member],[presentation]) VALUES (@nim,@honorary_member, @surname, @name, @cric, @active_member, @civility, @maiden_name, @spouse_name, @title, @birth_year, @year_membership_rotary, @email, @adress_1, @adress_2, @adress_3, @zip_code, @town, @telephone, @fax, @gsm, @country, @job, @industry, @biography, @base_dtupdate, @professionnal_adress, @professionnal_zip_code, @professionnal_town, @professionnal_tel, @professionnal_fax, @professionnal_mobile, @professionnal_email, @retired, @removed, @district_id, @club_name, @photo, @visible,@satellite_member,@presentation)", conn, trans);
                sql.Parameters.AddWithValue("@nim", m.nim);
                sql.Parameters.AddWithValue("@honorary_member", m.honorary_member);
                sql.Parameters.AddWithValue("@surname", m.surname);
                sql.Parameters.AddWithValue("@name", m.name);
                sql.Parameters.AddWithValue("@cric", m.cric);
                sql.Parameters.AddWithValue("@active_member", m.active_member);
                sql.Parameters.AddWithValue("@civility", m.civility);
                sql.Parameters.AddWithValue("@maiden_name", m.maiden_name);
                sql.Parameters.AddWithValue("@spouse_name", m.spouse_name);
                sql.Parameters.AddWithValue("@title", m.title);
                if (m.birth_year == null)
                {
                    sql.Parameters.AddWithValue("@birth_year", DBNull.Value);
                }
                else
                {
                    sql.Parameters.AddWithValue("@birth_year", m.birth_year);
                }

                if (m.year_membership_rotary == null)
                {
                    sql.Parameters.AddWithValue("@year_membership_rotary", DBNull.Value);
                }
                else
                {
                    sql.Parameters.AddWithValue("@year_membership_rotary", m.year_membership_rotary);
                }

                sql.Parameters.AddWithValue("@email", m.email);
                sql.Parameters.AddWithValue("@adress_1", m.adress_1);
                sql.Parameters.AddWithValue("@adress_2", m.adress_2);
                sql.Parameters.AddWithValue("@adress_3", m.adress_3);
                sql.Parameters.AddWithValue("@zip_code", m.zip_code);
                sql.Parameters.AddWithValue("@town", m.town);
                sql.Parameters.AddWithValue("@telephone", m.telephone);
                sql.Parameters.AddWithValue("@fax", m.fax);
                sql.Parameters.AddWithValue("@gsm", m.gsm);
                sql.Parameters.AddWithValue("@country", m.country);
                sql.Parameters.AddWithValue("@job", m.job);
                sql.Parameters.AddWithValue("@industry", m.industry);
                sql.Parameters.AddWithValue("@biography", m.biography);
                sql.Parameters.AddWithValue("@base_dtupdate", m.base_dtupdate);
                sql.Parameters.AddWithValue("@professionnal_adress", m.professionnal_adress);
                sql.Parameters.AddWithValue("@professionnal_zip_code", m.professionnal_zip_code);
                sql.Parameters.AddWithValue("@professionnal_town", m.professionnal_town);
                sql.Parameters.AddWithValue("@professionnal_tel", m.professionnal_tel);
                sql.Parameters.AddWithValue("@professionnal_fax", m.professionnal_fax);
                sql.Parameters.AddWithValue("@professionnal_mobile", m.professionnal_mobile);
                sql.Parameters.AddWithValue("@professionnal_email", m.professionnal_email);
                sql.Parameters.AddWithValue("@retired", m.retired);
                sql.Parameters.AddWithValue("@removed", m.removed);
                sql.Parameters.AddWithValue("@district_id", m.district_id);
                sql.Parameters.AddWithValue("@club_name", m.club_name);
                sql.Parameters.AddWithValue("@photo", m.photo);
                sql.Parameters.AddWithValue("@visible", m.visible);
                sql.Parameters.AddWithValue("@satellite_member", m.satellite_member);
                sql.Parameters.AddWithValue("@presentation", m.presentation ? Const.YES : Const.NO);


                if (sql.ExecuteNonQuery() == 0)
                    throw new Exception("Erreur Insert membre : ");

                ClearMemberCache();

                trans.Commit();

                return true;
            }
            catch (Exception ee)
            {
                if (trans != null)
                    try
                    {
                        trans.Rollback();
                    }
                    catch { }
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        /// <summary>
        /// Edit a member
        /// </summary>
        /// <param name="id">Member ID<param>
        /// <param name="photo"></param>
        /// <param name="visible"></param>
        /// <returns></returns>
        public static bool UpdateMember(int id, string photo, bool visible)
        {
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            SqlTransaction trans = null;
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();

                SqlCommand sql = new SqlCommand("UPDATE " + Const.TABLE_PREFIX + "member SET photo=@photo,visible=@visible WHERE nim=@id", conn, trans);
                sql.Parameters.AddWithValue("photo", photo);
                sql.Parameters.AddWithValue("id", DataMapping.GetMember(id).nim);
                sql.Parameters.AddWithValue("visible", visible ? Const.YES : Const.NO);
                if (sql.ExecuteNonQuery() == 0)
                    throw new Exception("Erreur update member : " + id);

                ClearMemberCache();
                trans.Commit();
                return true;

            }
            catch (Exception ee)
            {
                if (trans != null)
                    try
                    {
                        trans.Rollback();
                    }
                    catch { }
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        /// <summary>
        /// Edit a member
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public static bool UpdateMember(Member m)
        {
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            SqlTransaction trans = null;

            try
            {
                conn.Open();
                trans = conn.BeginTransaction();

                SqlCommand sql = new SqlCommand("UPDATE " + Const.TABLE_PREFIX + "members SET [nim]=@nim,[honorary_member]=@honorary_member,[surname]=@surname,[name]=@name,[cric]=@cric,[active_member]=@active_member,[civility]=@civility,[maiden_name]=@maiden_name,[spouse_name]=@spouse_name,[title]=@title,[birth_year]=@birth_year,[year_membership_rotary]=@year_membership_rotary,[email]=@email,[adress_1]=@adress_1,[adress_2]=@adress_2,[adress_3]=@adress_3,[zip_code]=@zip_code,[town]=@town,[telephone]=@telephone,[fax]=@fax,[gsm]=@gsm,[country]=@country,[job]=@job,[industry]=@industry,[biography]=@biography,[base_dtupdate]=@base_dtupdate,[professionnal_adress]=@professionnal_adress,[professionnal_zip_code]=@professionnal_zip_code,[professionnal_town]=@professionnal_town,[professionnal_tel]=@professionnal_tel,[professionnal_fax]=@professionnal_fax,[professionnal_mobile]=@professionnal_mobile,[professionnal_email]=@professionnal_email,[retired]=@retired,[removed]=@removed,[district_id]=@district_id,[club_name]=@club_name, [userid]=@userid, [photo]=@photo,[visible]=@visible,[satellite_member]=@satellite_member,[presentation]=@presentation WHERE [id]=@id", conn, trans);
                sql.Parameters.AddWithValue("@id", m.id);
                sql.Parameters.AddWithValue("@nim", m.nim);
                sql.Parameters.AddWithValue("@honorary_member", m.honorary_member);
                sql.Parameters.AddWithValue("@surname", m.surname);
                sql.Parameters.AddWithValue("@name", m.name);
                sql.Parameters.AddWithValue("@cric", m.cric);
                sql.Parameters.AddWithValue("@active_member", m.active_member);
                sql.Parameters.AddWithValue("@civility", m.civility);
                sql.Parameters.AddWithValue("@maiden_name", m.maiden_name);
                sql.Parameters.AddWithValue("@spouse_name", m.spouse_name);
                sql.Parameters.AddWithValue("@title", m.title);
                if (m.birth_year == null)
                {
                    sql.Parameters.AddWithValue("@birth_year", DBNull.Value);
                }
                else
                {
                    sql.Parameters.AddWithValue("@birth_year", m.birth_year);
                }

                if (m.year_membership_rotary == null)
                {
                    sql.Parameters.AddWithValue("@year_membership_rotary", DBNull.Value);
                }
                else
                {
                    sql.Parameters.AddWithValue("@year_membership_rotary", m.year_membership_rotary);
                }

                sql.Parameters.AddWithValue("@email", m.email);
                sql.Parameters.AddWithValue("@adress_1", m.adress_1);
                sql.Parameters.AddWithValue("@adress_2", m.adress_2);
                sql.Parameters.AddWithValue("@adress_3", m.adress_3);
                sql.Parameters.AddWithValue("@zip_code", m.zip_code);
                sql.Parameters.AddWithValue("@town", m.town);
                sql.Parameters.AddWithValue("@telephone", m.telephone);
                sql.Parameters.AddWithValue("@fax", m.fax);
                sql.Parameters.AddWithValue("@gsm", m.gsm);
                sql.Parameters.AddWithValue("@country", m.country);
                sql.Parameters.AddWithValue("@job", m.job);
                sql.Parameters.AddWithValue("@industry", m.industry);
                sql.Parameters.AddWithValue("@biography", m.biography);
                sql.Parameters.AddWithValue("@base_dtupdate", m.base_dtupdate!=null?m.base_dtupdate:DateTime.Now);
                sql.Parameters.AddWithValue("@professionnal_adress", m.professionnal_adress);
                sql.Parameters.AddWithValue("@professionnal_zip_code", m.professionnal_zip_code);
                sql.Parameters.AddWithValue("@professionnal_town", m.professionnal_town);
                sql.Parameters.AddWithValue("@professionnal_tel", m.professionnal_tel);
                sql.Parameters.AddWithValue("@professionnal_fax", m.professionnal_fax);
                sql.Parameters.AddWithValue("@professionnal_mobile", m.professionnal_mobile);
                sql.Parameters.AddWithValue("@professionnal_email", m.professionnal_email);
                sql.Parameters.AddWithValue("@retired", m.retired);
                sql.Parameters.AddWithValue("@removed", m.removed);
                sql.Parameters.AddWithValue("@district_id", m.district_id);
                sql.Parameters.AddWithValue("@club_name", m.club_name);
                sql.Parameters.AddWithValue("@userid", m.userid);
                sql.Parameters.AddWithValue("@photo", m.photo);
                sql.Parameters.AddWithValue("@visible", m.visible);
                sql.Parameters.AddWithValue("@satellite_member", m.satellite_member);
                sql.Parameters.AddWithValue("@presentation", m.presentation?Const.YES:Const.NO);

                if (sql.ExecuteNonQuery() == 0)
                    throw new Exception("Erreur update member : " + m.id);

                if(!UpdateOrCreateUser(m,conn:conn,trans:trans))
                    throw new Exception("Erreur update membre login : "+m.id);

                ClearMemberCache();

                trans.Commit();

                return true;

            }
            catch (Exception ee)
            {
                if (trans != null)
                    try
                    {
                        trans.Rollback();
                    }
                    catch { }
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        /// <summary>
        /// Delete a member
        /// </summary>
        /// <param name="id">Member ID</param>
        /// <returns></returns>
        public static bool DeleteMember(int id)
        {
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            SqlTransaction trans = null;

            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand sql = new SqlCommand("DELETE  " + Const.TABLE_PREFIX + "members where [id]=@id", conn, trans);
                sql.Parameters.AddWithValue("id", id);

                if (sql.ExecuteNonQuery() == 0)
                    throw new Exception("Erreur SUPP member id " + id + " from table members");

                ClearMemberCache();

                trans.Commit();
                    
                return true;
            }
            catch (Exception ee)
            {
                if (trans != null)
                    try
                    {
                        trans.Rollback();
                    }
                    catch { }
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }


        public static void ClearMemberCache()
        {


        }

        public static void ClearClubCache()
        {

        }

        /// <summary>
        /// Edit a member
        /// </summary>
        /// <param name="membreid">Member ID</param>
        /// <param name="dnnuserid">User ID</param>
        /// <returns></returns>
        public static bool UpdateMemberDNNUserID(int membreid, int dnnuserid, SqlConnection conn = null, SqlTransaction trans = null)
        {
            bool mustconnect = false;
            if(conn==null)
            {
                conn = new SqlConnection(Config.GetConnectionString());
                mustconnect = true;
            }
            try
            {
                if(mustconnect)
                    conn.Open();

                SqlCommand sql = new SqlCommand("UPDATE " + Const.TABLE_PREFIX + "members SET userid=@userid WHERE id=@id", conn,trans);
                sql.Parameters.AddWithValue("id", membreid);
                sql.Parameters.AddWithValue("userid", dnnuserid);
                if (sql.ExecuteNonQuery() == 0)
                    throw new Exception("Erreur update member DNN user id : " + membreid);
                return true;

            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                if(mustconnect)
                    conn.Close();
            }
            return false;
        }

        /// <summary>
        /// Get a list of the members presentation
        /// </summary>
        /// <param name="cric">Club cric</param>
        /// <param name="criterion"></param>
        /// <param name="top"></param>
        /// <param name="sort"></param>
        /// <param name="index"></param>
        /// <param name="max"></param>
        /// <param name="onlyvisible"></param>
        /// <param name="court"></param>
        /// <returns></returns>
        public static List<Member> ListMembersPresentation(int cric = 0, string criterion = "", string top = "", string sort = "", int index = 0, int max = 100, bool onlyvisible = false, bool court = false)
        {


            List<Member> list = new List<Member>();
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());

            string[] keywords = criterion.Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                DataSet ds = new DataSet();
                string where = "";
                if (criterion != "")
                {

                    for (int ii = 0; ii < keywords.Length; ii++)
                    {
                        if (where != "")
                            where = where + " OR ";
                        where = " surname LIKE @criterion" + ii + " OR name LIKE @criterion" + ii + " OR job LIKE @criterion" + ii + " OR industry LIKE @criterion" + ii + " ";
                        if (!keywords[ii].StartsWith("%"))
                            keywords[ii] = "%" + keywords[ii];
                        if (!keywords[ii].EndsWith("%"))
                            keywords[ii] = keywords[ii] + "%";
                    }
                    if (where != "")
                        where = " (" + where + ") ";
                }

                if (cric != 0)
                {
                    if (where != "")
                        where += " AND ";
                    where += " cric = @cric ";
                }

                if (onlyvisible)
                {
                    if (where != "")
                        where += " AND ";
                    where += " visible='" + Const.YES + "' ";
                }


                if (where != "")
                    where += " AND ";
                // where += " userid in (SELECT DISTINCT id_user FROM " + Const.TABLE_PREFIX + "subscription WHERE  type = @type and dt_end >= @dt_end and active = 'o' AND id_content IN (SELECT id FROM " + Const.TABLE_PREFIX + "content WHERE published = 'o')) ";
                where += " presentation ='"+Const.YES+"' ";





                //where = where + "";

                if (where != "")
                {
                    where = " WHERE " + where;
                }

                string query = "";

                if (court == false)
                {
                    query = "SELECT " + top + " * FROM " + Const.TABLE_PREFIX + "members " + where + (sort != "" ? "ORDER BY " + sort : "");
                }
                else
                {
                    query = "SELECT " + top + " id, surname, name, cric, civility, job, industry, base_dtupdate, retired, district_id, club_name, userid,satellite_member FROM " + Const.TABLE_PREFIX + "members " + where + (sort != "" ? "ORDER BY " + sort : "");
                }


                conn.Open();
                SqlCommand sql = new SqlCommand(query, conn);
                if (keywords.Length > 0)
                    for (int ii = 0; ii < keywords.Length; ii++)
                        sql.Parameters.AddWithValue("criterion" + ii, keywords[ii]);
                if (cric != 0)
                    sql.Parameters.AddWithValue("cric", cric);

                sql.Parameters.AddWithValue("type", "PagePro");
                sql.Parameters.AddWithValue("dt_end", DateTime.Now);

                SqlDataAdapter da = new SqlDataAdapter(sql);
                da.Fill(ds);
                //if (where == "")
                //    HttpContextSource.Current.Session["members:" + query] = ds;
                //}
                int i = 0;
                int c = 0;
                foreach (DataRow rd in ds.Tables[0].Rows)
                {
                    if (i >= (index * max) && c < max)
                    {
                        if (court == false)
                        {
                            Member m = GetMemberByRD(rd);
                            Content cont = GetContentPagePro(m.userid);
                            if (cont != null && !string.IsNullOrEmpty(cont.title))
                            {
                                m.title = cont.title;
                            }
                            list.Add(m);
                        }
                        else
                        {
                            //id, surname, name, cric, civility, job, industry, base_dtupdate, retired, photo, district_id, club_name, userid, visible
                            Member obj = new Member();
                            if (rd["id"] == DBNull.Value) obj.id = 0; else obj.id = (int)rd["id"];
                            obj.surname = "" + rd["surname"];
                            obj.name = "" + rd["name"];
                            if (rd["cric"] == DBNull.Value) obj.cric = 0; else obj.cric = (int)rd["cric"];
                            obj.civility = "" + rd["civility"];
                            obj.job = "" + rd["job"];
                            obj.industry = "" + rd["industry"];
                            if (rd["base_dtupdate"] == DBNull.Value) obj.base_dtupdate = null; else obj.base_dtupdate = (DateTime)rd["base_dtupdate"];
                            obj.retired = "" + rd["retired"];
                            if (rd["district_id"] == DBNull.Value) obj.district_id = Const.DISTRICT_ID; else obj.district_id = (int)rd["district_id"];
                            obj.club_name = "" + rd["club_name"];
                            if (rd["userid"] == DBNull.Value) obj.userid = 0; else obj.userid = (int)rd["userid"];
                            obj.satellite_member = "" + rd["satellite_member"];


                            list.Add(obj);
                        }
                        c++;
                    }
                    else
                    {
                        list.Add(new Member());
                    }
                    i++;
                }

            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }

            return list;
        }

       

        public static bool findMemberInList(Member m, List<Member> listMember)
        {
            foreach (Member membre in listMember)
            {
                if (m.nim == membre.nim)
                    return true;
            }
            return false;
        }

        public static bool InsertRotaryImport(Member m)
        {
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            SqlTransaction trans = null;

            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand sql;

                if (m.id == 0 || !findMemberInList(m, DataMapping.GetListRotaryImport("", max: 3000)))
                {
                    sql = new SqlCommand("INSERT INTO " + Const.TABLE_PREFIX + "rotary_import ([honorary_member],[nim],[surname],[name],[cric],[active_member],[civility],[maiden_name],[spouse_name],[title],[birth_year],[year_membership_rotary],[email],[adress_1],[adress_2],[adress_3],[zip_code],[town],[telephone],[fax],[gsm],[country],[job],[industry],[biography],[base_dtupdate],[professionnal_adress],[professionnal_zip_code],[professionnal_town],[professionnal_tel],[professionnal_fax],[professionnal_mobile],[professionnal_email],[retired],[removed],[district_id],[club_name],[satellite_member]) VALUES (@honorary_member, @nim, @name,@name,@cric,@active_member,@civility,@maiden_name,@spouse_name,@title,@birth_year,@year_membership_rotary,@email,@adress_1,@adress_2,@adress_3,@zip_code,@town,@telephone,@fax,@gsm,@country,@job,@industry,@biography,@base_dtupdate,@professionnal_adress,@professionnal_zip_code,@professionnal_town,@professionnal_tel,@professionnal_fax,@professionnal_mobile,@professionnal_email,@retired,@removed,@district_id,@club_name,@satellite_member)", conn, trans);
                }
                else
                {
                    sql = new SqlCommand("UPDATE " + Const.TABLE_PREFIX + "rotary_import SET [honorary_member]=@honorary_member,[surname]=@surname,[name]=@name,[cric]=@cric,[active_member]=@active_member,[civility]=@civility,[maiden_name]=@maiden_name,[spouse_name]=@spouse_name,[title]=@title,[birth_year]=@birth_year,[year_membership_rotary]=@year_membership_rotary,[email]=@email,[adress_1]=@adress_1,[adress_2]=@adress_2,[adress_3]=@adress_3,[zip_code]=@zip_code,[town]=@town,[telephone]=@telephone,[fax]=@fax,[gsm]=@gsm,[country]=@country,[job]=@job,[industry]=@industry,[biography]=@biography,[base_dtupdate]=@base_dtupdate,[professionnal_adress]=@professionnal_adress,[professionnal_zip_code]=@professionnal_zip_code,[professionnal_town]=@professionnal_town,[professionnal_tel]=@professionnal_tel,[professionnal_fax]=@professionnal_fax,[professionnal_mobile]=@professionnal_mobile,[professionnal_email]=@professionnal_email,[retired]=@retired,[removed]=@removed,[district_id]=@district_id,[club_name]=@club_name,[satellite_member]=@satellite_member WHERE [nim]=@nim", conn, trans);
                }
                sql.Parameters.AddWithValue("@nim", m.nim);
                sql.Parameters.AddWithValue("@honorary_member", m.honorary_member);
                sql.Parameters.AddWithValue("@surname", m.surname);
                sql.Parameters.AddWithValue("@name", m.name);
                sql.Parameters.AddWithValue("@cric", m.cric);
                sql.Parameters.AddWithValue("@active_member", m.active_member);
                sql.Parameters.AddWithValue("@civility", m.civility);
                sql.Parameters.AddWithValue("@maiden_name", m.maiden_name);
                sql.Parameters.AddWithValue("@spouse_name", m.spouse_name);
                sql.Parameters.AddWithValue("@title", m.title);
                sql.Parameters.AddWithValue("@birth_year", (m.birth_year.ToString() == "" ? new DateTime(1753, 1, 1) : m.birth_year));
                sql.Parameters.AddWithValue("@year_membership_rotary", (m.year_membership_rotary.ToString() == "" ? new DateTime(1753, 1, 1) : m.year_membership_rotary));
                sql.Parameters.AddWithValue("@email", m.email);
                sql.Parameters.AddWithValue("@adress_1", m.adress_1);
                sql.Parameters.AddWithValue("@adress_2", m.adress_2);
                sql.Parameters.AddWithValue("@adress_3", m.adress_3);
                sql.Parameters.AddWithValue("@zip_code", m.zip_code);
                sql.Parameters.AddWithValue("@town", m.town);
                sql.Parameters.AddWithValue("@telephone", m.telephone);
                sql.Parameters.AddWithValue("@fax", m.fax);
                sql.Parameters.AddWithValue("@gsm", m.gsm);
                sql.Parameters.AddWithValue("@country", m.country);
                sql.Parameters.AddWithValue("@job", m.job);
                sql.Parameters.AddWithValue("@industry", m.industry);
                sql.Parameters.AddWithValue("@biography", m.biography);
                sql.Parameters.AddWithValue("@base_dtupdate", m.base_dtupdate);
                sql.Parameters.AddWithValue("@professionnal_adress", m.professionnal_adress);
                sql.Parameters.AddWithValue("@professionnal_zip_code", m.professionnal_zip_code);
                sql.Parameters.AddWithValue("@professionnal_town", m.professionnal_town);
                sql.Parameters.AddWithValue("@professionnal_tel", m.professionnal_tel);
                sql.Parameters.AddWithValue("@professionnal_fax", m.professionnal_fax);
                sql.Parameters.AddWithValue("@professionnal_mobile", m.professionnal_mobile);
                sql.Parameters.AddWithValue("@professionnal_email", m.professionnal_email);
                sql.Parameters.AddWithValue("@retired", m.retired);
                sql.Parameters.AddWithValue("@removed", m.removed);
                sql.Parameters.AddWithValue("@district_id", m.district_id);
                sql.Parameters.AddWithValue("@club_name", m.club_name);
                sql.Parameters.AddWithValue("@photo", m.photo);
                sql.Parameters.AddWithValue("@visible", m.visible);
                sql.Parameters.AddWithValue("@satellite_member", m.satellite_member);

                if (sql.ExecuteNonQuery() == 0 && m.id != 0)
                    throw new Exception("Error Update Rotary Import : ");

                ClearMemberCache();

                trans.Commit();

                return true;

            }
            catch (Exception ee)
            {
                if (trans != null)
                    try
                    {
                        trans.Rollback();
                    }
                    catch { }
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        public static List<Member> GetListRotaryImport(string query, int index = 0, int max = 50, int top = 100)
        {
            List<Member> members = null;
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                conn.Open();
                SqlCommand sql;
                if (!string.IsNullOrEmpty(query))
                {
                    //On crée la requête permettant de récupérer les members correspondant aux critères sélectionnés 
                    sql = new SqlCommand("SELECT TOP " + top + " * FROM " + Const.TABLE_PREFIX + "rotary_import WHERE " + query + " ORDER BY base_dtupdate DESC", conn);
                }
                else
                {//Cette requête sélectionne tous les members
                    sql = new SqlCommand("SELECT TOP " + top + " * FROM " + Const.TABLE_PREFIX + "rotary_import ORDER BY base_dtupdate DESC", conn);
                }

                SqlDataAdapter da = new SqlDataAdapter(sql);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    members = new List<Member>();
                    int i = 0;
                    int c = 0;
                    foreach (DataRow rd in ds.Tables[0].Rows)
                    {
                        if (i >= (index * max) && c < max)
                        {
                            Member obj = new Member();
                            if (rd["nim"] == DBNull.Value) obj.nim = 0; else obj.nim = (int)rd["nim"];
                            obj.surname = "" + rd["surname"];
                            obj.name = "" + rd["name"];
                            if (rd["cric"] == DBNull.Value) obj.cric = 0; else obj.cric = (int)rd["cric"];
                            obj.honorary_member = "" + rd["honorary_member"];
                            obj.active_member = "" + rd["active_member"];
                            obj.civility = "" + rd["civility"];
                            obj.maiden_name = "" + rd["maiden_name"];
                            obj.spouse_name = "" + rd["spouse_name"];
                            obj.title = "" + rd["title"];
                            if (rd["birth_year"] != null) obj.birth_year = (DateTime)rd["birth_year"];
                            if (rd["year_membership_rotary"] != null) obj.year_membership_rotary = (DateTime)rd["year_membership_rotary"];
                            obj.email = "" + rd["email"];
                            obj.adress_1 = "" + rd["adress_1"];
                            obj.adress_2 = "" + rd["adress_2"];
                            obj.adress_3 = "" + rd["adress_3"];
                            obj.zip_code = "" + rd["zip_code"];
                            obj.town = "" + rd["town"];
                            obj.telephone = "" + rd["telephone"];
                            obj.fax = "" + rd["fax"];
                            obj.gsm = "" + rd["gsm"];
                            obj.country = "" + rd["country"];
                            obj.job = "" + rd["job"];
                            obj.industry = "" + rd["industry"];
                            obj.biography = "" + rd["biography"];
                            if (rd["base_dtupdate"] == DBNull.Value) obj.base_dtupdate = null; else obj.base_dtupdate = (DateTime)rd["base_dtupdate"];
                            obj.professionnal_adress = "" + rd["professionnal_adress"];
                            obj.professionnal_zip_code = "" + rd["professionnal_zip_code"];
                            obj.professionnal_town = "" + rd["professionnal_town"];
                            obj.professionnal_tel = "" + rd["professionnal_tel"];
                            obj.professionnal_fax = "" + rd["professionnal_fax"];
                            obj.professionnal_mobile = "" + rd["professionnal_mobile"];
                            obj.professionnal_email = "" + rd["professionnal_email"];
                            obj.retired = "" + rd["retired"];
                            obj.removed = "" + rd["removed"];
                            if (rd["district_id"] == DBNull.Value) obj.district_id = Const.DISTRICT_ID; else obj.district_id = (int)rd["district_id"];
                            obj.club_name = "" + rd["club_name"];
                            obj.photo = "" + rd["photo"];
                            obj.visible = "" + rd["visible"];
                            obj.satellite_member = "" + rd["satellite_member"];

                            members.Add(obj);

                            c++;
                        }
                        else
                        {
                            members.Add(new Member());
                        }
                        i++;
                    }
                }
            }

            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return members;
        }

        public static string ConnectFromMobile(string username, string password)
        {
            DateTime dt = DateTime.Now;
            string comment = "";
            string code = "ok";

            string token = "0";
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return token;
            }
            SqlConnection conn = new SqlConnection(DotNetNuke.Common.Utilities.Config.GetConnectionString());

            try
            {
                UserInfo user = UserController.GetUserByName(Globals.GetPortalSettings().PortalId, username);
                if (user != null)
                {
                    MembershipUser objUser = Membership.GetUser(user.Username);
                    if (objUser != null)
                    {
                        string strPassword = objUser.GetPassword();
                        if (!string.IsNullOrEmpty(strPassword))
                        {
                            string defaultPassMD5 = Functions.CalculateMD5Hash(Functions.StringToBytes(strPassword));

                            if (!string.IsNullOrEmpty(defaultPassMD5))
                            {
                                if (password.ToLower() == defaultPassMD5.ToLower())
                                {
                                    token = "1";
                                    //break;
                                }
                            }
                            else
                            {
                                throw new Exception("defaultPassMD5 NULL ou  vide pour le username " + username);
                            }
                        }
                        else
                        {
                            throw new Exception("strPassword NULL ou  vide pour le username " + username);
                        }
                    }
                    else
                    {
                        throw new Exception("objUser NULL pour le username " + username);
                    }
                }
                else
                {
                    throw new Exception("user NULL pour le username " + username);
                }
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
                comment = ee.ToString();
                code = "erreur";
            }
            finally
            {
                conn.Close();
                conn.Dispose();


                if (token == "1")
                {
                    comment = "Identification réussie";
                }
                else
                {
                    if (comment == "")
                    {
                        comment = "Identification refusée";
                    }
                }

                //DataMapping.InsertLogWS(os, device, version, getIP(), dt, getDuree(dt), fonction, code, comment, username);
            }

            return token;
        }

        #endregion Member

        #region News TRADUIT

        /// <summary>
        /// Add or edit a news
        /// </summary>
        /// <param name="nouvelle"></param>
        /// <returns></returns>
        public static bool UpdateNews(News news)
        {
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                conn.Open();
                SqlCommand sql;
                if (news.id != null)
                {

                    sql = new SqlCommand("UPDATE " + Const.TABLE_PREFIX + "news SET [cric]=@cric,[dt]=@dt,[dt_end]=@dt_end,[title]=@title,[abstract]=@abstract,[text]=@text,[url_text]=@url_text,[url]=@url,[photo]=@photo,[category]=@category,[tag1]=@tag1,[tag2]=@tag2,[visible]=@visible,[club_type]=@club_type,[adress]=@adress,[town]=@town,[zip_code]=@zip_code,[dt_start_event]=@dt_start_event,[dt_end_event]=@dt_end_event, [ord]=@ord WHERE [id]=@id", conn);
                    sql.Parameters.AddWithValue("id", news.id);
                }
                else
                {
                    sql = new SqlCommand("INSERT INTO " + Const.TABLE_PREFIX + "news ([id],[cric],[dt],[dt_end],[title],[abstract],[text],[url_text],[url],[photo],[category],[tag1],[tag2],[visible],[club_type],[adress],[town],[zip_code],[dt_start_event],[dt_end_event],[ord]) VALUES (@id,@cric,@dt,@dt_end,@title,@abstract,@text,@url_text,@url,@photo,@category,@tag1,@tag2,@visible, @club_type,@adress,@town,@zip_code,@dt_start_event,@dt_end_event,@ord)", conn);
                    news.id = ""+Guid.NewGuid();
                    sql.Parameters.AddWithValue("id", news.id);
                }

                sql.Parameters.AddWithValue("@cric", news.cric);
                if (news.dt != null && news.dt != DateTime.MinValue)
                    sql.Parameters.AddWithValue("@dt", news.dt);
                else
                    sql.Parameters.AddWithValue("@dt", DBNull.Value);
                if (news.end_publication == null || news.end_publication==DateTime.MinValue)
                {
                    sql.Parameters.AddWithValue("@dt_end", DBNull.Value);
                }
                else
                {
                    sql.Parameters.AddWithValue("@dt_end", news.end_publication);
                }

                if (news.date_start_event == null || news.date_start_event == DateTime.MinValue)
                {
                    sql.Parameters.AddWithValue("@dt_start_event", DBNull.Value);
                }
                else
                {
                    sql.Parameters.AddWithValue("@dt_start_event", news.date_start_event);
                }

                if (news.date_end_event == null || news.date_end_event == DateTime.MinValue)
                {
                    sql.Parameters.AddWithValue("@dt_end_event", DBNull.Value);
                }
                else
                {
                    sql.Parameters.AddWithValue("@dt_end_event", news.date_end_event);
                }

                sql.Parameters.AddWithValue("@title", ""+news.title);
                sql.Parameters.AddWithValue("@abstract", ""+news.Abstract);
                sql.Parameters.AddWithValue("@text", ""+news.text);
                sql.Parameters.AddWithValue("@url_text", ""+news.url_text);
                sql.Parameters.AddWithValue("@url", ""+news.url);
                sql.Parameters.AddWithValue("@photo", ""+news.photo);
                sql.Parameters.AddWithValue("@category", ""+news.category);
                sql.Parameters.AddWithValue("@tag1", ""+news.tag1);
                sql.Parameters.AddWithValue("@tag2", ""+news.tag2);
                sql.Parameters.AddWithValue("@visible", ""+news.visible);
                sql.Parameters.AddWithValue("@club_type", ""+news.club_type);
                sql.Parameters.AddWithValue("@adress", ""+news.adress_event);
                sql.Parameters.AddWithValue("@town", ""+news.town_event);
                sql.Parameters.AddWithValue("@zip_code", ""+news.zip_event);
                sql.Parameters.AddWithValue("@ord", news.ord);
                if (sql.ExecuteNonQuery() == 0)
                    throw new Exception("Erreur mise a day news : " + news.id);

               
                return true;

            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        /// <summary>
        /// Delete a news
        /// </summary>
        /// <param name="newsid">News ID</param>
        /// <returns></returns>
        public static bool DeleteNews(string newsid)
        {
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                conn.Open();
                SqlCommand sql = new SqlCommand("DELETE " + Const.TABLE_PREFIX + "news WHERE id=@id", conn);
                sql.Parameters.AddWithValue("@id", newsid);
                if (sql.ExecuteNonQuery() == 0)
                    throw new Exception("Erreur delete news : " + newsid);
                return true;

            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        /// <summary>
        /// Get a news thanks to a DataRow
        /// </summary>
        /// <param name="rd"></param>
        /// <param name="clubs"></param>
        /// <returns></returns>
        static News GetNewsByRD(DataRow rd, List<Club> clubs)
        {
            News obj = new News();
            obj.id = "" + rd["id"];
            if (rd["cric"] == DBNull.Value) obj.cric = 0; else obj.cric = (int)rd["cric"];
            if (rd["dt"] == DBNull.Value) obj.dt = DateTime.MinValue; else obj.dt = (DateTime)rd["dt"];
            obj.title = "" + rd["title"];
            obj.Abstract = "" + rd["abstract"];
            obj.text = "" + rd["text"];
            obj.url = "" + rd["url"];
            obj.url_text = "" + rd["url_text"];
            obj.photo = "" + rd["photo"];
            obj.category = "" + rd["category"];
            obj.tag1 = "" + rd["tag1"];
            obj.tag2 = "" + rd["tag2"];
            obj.visible = "" + rd["visible"];
            obj.club_type = "" + rd["club_type"];
            if (rd["ord"] != DBNull.Value) obj.ord = int.Parse(rd["ord"].ToString());
            if (obj.cric > 0)
            {
                foreach (Club club in clubs)
                    if (club.cric == obj.cric)
                    {
                        obj.club_name = club.name;
                        break;
                    }
            }
            else
            {
                obj.club_name = "";
            }
            return obj;
        }

        /// <summary>
        /// Get a news
        /// </summary>
        /// <param name="newsid">News ID</param>
        /// <returns>News</returns>
        public static News GetNews(string newsid)
        {
            List<Club> clubs = ListClubs(sort: "cric asc");
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                string query = "SELECT * FROM " + Const.TABLE_PREFIX + "news WHERE id=@id";
                conn.Open();
                DataSet ds = new DataSet();
                SqlCommand sql = new SqlCommand(query, conn);
                sql.Parameters.AddWithValue("id", newsid);
                SqlDataAdapter da = new SqlDataAdapter(sql);
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                    return GetNewsByRD(ds.Tables[0].Rows[0], clubs);
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }

            return null;
        }

        /// <summary>
        /// Get a list of news
        /// </summary>
        /// <param name="cric">Club cric</param>
        /// <param name="category"></param>
        /// <param name="tags_inclus"></param>
        /// <param name="tags_exclus"></param>
        /// <param name="top"></param>
        /// <param name="tri"></param>
        /// <param name="index"></param>
        /// <param name="max"></param>
        /// <param name="onlyvisible"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static List<News> ListNewsMobile(int cric = 0, string category = "", string tags_included = "", string tags_excluded = "", string top = "", string sort = "dt DESC", int index = 0, int max = 100, bool onlyvisible = false, string date = "")
        {
            List<Club> clubs = ListClubs(sort: "cric asc");
            List<News> list = new List<News>();
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                string where = "";

                #region category
                if (!string.IsNullOrEmpty(category))
                {
                    where = " category=@category AND cric=0"; // par defaut le district

                    if (category == "Clubs")
                        where = " category=@category AND cric" + (cric == 0 ? ">0" : "=@cric");
                }
                #endregion category

                #region TAG_EXCLUS
                if (tags_excluded != "")
                {
                    string t = "";
                    string[] exclude = tags_excluded.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string ex in exclude)
                        t += "'" + ex + "',";
                    if (t.EndsWith(","))
                        t = t.Substring(0, t.Length - 1);
                    if (t != "")
                    {
                        where += " and ( tag1 not in (" + t + ") and tag2 not in (" + t + ")) ";
                    }
                }
                #endregion TAG_EXCLUS

                #region TAG_INCLUS
                if (tags_included != "")
                {
                    string t = "";
                    string[] include = tags_included.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string inc in include)
                        t += "'" + inc + "',";
                    if (t.EndsWith(","))
                        t = t.Substring(0, t.Length - 1);
                    if (t != "")
                    {
                        where += " and ( tag1 in (" + t + ") or tag2 in (" + t + ")) ";
                    }
                }
                #endregion TAG_INCLUS

                #region VISIBLE
                if (onlyvisible)
                    where += " and visible='" + Const.YES + "' ";
                #endregion VISIBLE

                #region DATE
                if (!string.IsNullOrEmpty(date))
                {
                    where += " and " + date + " ";
                }

                #endregion DATE

                DataSet ds = new DataSet();
                string query = "";
                if (!string.IsNullOrEmpty(where))
                {
                    if (where.StartsWith(" and"))
                    {
                        where = where.Substring(4);
                    }
                    query = "SELECT " + top + " * FROM " + Const.TABLE_PREFIX + "news WHERE " + where + " " + (sort != "" ? "ORDER BY " + sort : "");
                }
                else
                {
                    query = "SELECT " + top + " * FROM " + Const.TABLE_PREFIX + "news " + (sort != "" ? "ORDER BY " + sort : "");
                }

                conn.Open();

                SqlCommand sql = new SqlCommand(query, conn);
                sql.Parameters.AddWithValue("cric", cric);
                sql.Parameters.AddWithValue("category", category);
                SqlDataAdapter da = new SqlDataAdapter(sql);
                da.Fill(ds);

                //HttpContextSource.Current.Application["news:" + query] = ds;
                //}
                int i = 0;
                int c = 0;
                foreach (DataRow rd in ds.Tables[0].Rows)
                {
                    if (i >= (index * max) && c < max)
                    {
                        list.Add(AIS.DataMapping.GetNewsByRD(rd, clubs));
                        c++;
                    }
                    else
                    {
                        list.Add(new News());
                    }
                    i++;
                }
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }

            return list;
        }

        /// <summary>
        /// Get a list of news
        /// </summary>
        /// <param name="cric">Club cric</param>
        /// <param name="category"></param>
        /// <param name="tags_included"></param>
        /// <param name="tags_excluded"></param>
        /// <param name="top"></param>
        /// <param name="tri"></param>
        /// <param name="index"></param>
        /// <param name="max"></param>
        /// <param name="onlyvisible"></param>
        /// <returns></returns>
        public static List<News> ListNews(int cric = 0, string category = "", string tags_included = "", string tags_excluded = "", string top = "", string sort = "dt DESC", int index = 0, int max = 100, bool onlyvisible = false)
        {
            List<Club> clubs = ListClubs(sort: "cric asc");
            List<News> list = new List<News>();
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                //string where = " category=@category AND cric=0 AND dt<='" + DateTime.Now.ToString() + "' AND (dt_end>'" + DateTime.Now.ToString() + "' OR dt_end IS NULL)"; // par defaut le district
                string where = " category=@category AND cric=0"; // par defaut le district

                //if (category == "Clubs")
                //    where = " category=@category AND cric" + (cric == 0 ? ">0" : "=@cric") + " AND dt>" + DateTime.Now;
                if (category == "Clubs" || category == "accueilclub")
                    where = " category=@category AND cric" + (cric == 0 ? ">0" : "=@cric");



                if (tags_excluded != "")
                {
                    string t = "";
                    string[] exclude = tags_excluded.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string ex in exclude)
                        t += "'" + ex + "',";
                    if (t.EndsWith(","))
                        t = t.Substring(0, t.Length - 1);
                    if (t != "")
                    {
                        where += " and ( tag1 not in (" + t + ") and tag2 not in (" + t + ")) ";
                    }
                }
                if (tags_included != "")
                {
                    string t = "";
                    string[] include = tags_included.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string inc in include)
                        t += "'" + inc + "',";
                    if (t.EndsWith(","))
                        t = t.Substring(0, t.Length - 1);
                    if (t != "")
                    {
                        where += " and ( tag1 in (" + t + ") or tag2 in (" + t + ")) ";
                    }
                }
                if (onlyvisible)
                    where += " and visible='" + Const.YES + "' ";
                DataSet ds = new DataSet();
                string query = "SELECT " + top + " * FROM " + Const.TABLE_PREFIX + "news WHERE " + where + " " + (sort != "" ? "ORDER BY " + sort : "");

                //if(HttpContextSource.Current.Application["news:"+query]!=null)
                //    ds = (DataSet)HttpContextSource.Current.Application["news:" + query];
                //else
                //{
                conn.Open();

                SqlCommand sql = new SqlCommand(query, conn);
                sql.Parameters.AddWithValue("cric", cric);
                sql.Parameters.AddWithValue("category", category);
                SqlDataAdapter da = new SqlDataAdapter(sql);
                da.Fill(ds);

                //HttpContextSource.Current.Application["news:" + query] = ds;
                //}
                int i = 0;
                int c = 0;
                foreach (DataRow rd in ds.Tables[0].Rows)
                {
                    if (i >= (index * max) && c < max)
                    {
                        list.Add(GetNewsByRD(rd, clubs));
                        c++;
                    }
                    else
                    {
                        list.Add(new News());
                    }
                    i++;
                }
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }

            return list;
        }


        public static List<News> SimpleListNews(string query)
        {
            List<News> news = null;
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                conn.Open();
                SqlCommand sql;
                if (!string.IsNullOrEmpty(query))
                {
                    //On crée la requête permettant de récupérer les members correspondant aux critères sélectionnés 
                    sql = new SqlCommand("SELECT * FROM " + Const.TABLE_PREFIX + "news WHERE " + query + " ORDER BY title ASC", conn);
                }
                else
                {//Cette requête sélectionne tous les members
                    sql = new SqlCommand("SELECT * FROM " + Const.TABLE_PREFIX + "news ORDER BY title ASC", conn);
                }

                SqlDataAdapter da = new SqlDataAdapter(sql);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    news = new List<News>();
                    foreach (DataRow rd in ds.Tables[0].Rows)
                    {
                        News nouv = new News();
                        //On attocie les résultats à chaque attendance qu l'on mettra dans la list
                        if (rd["id"] != DBNull.Value) nouv.id = (string)rd["id"];
                        if (rd["cric"] != DBNull.Value) nouv.cric = (int)rd["cric"];
                        if (rd["dt"] != DBNull.Value) nouv.dt = (DateTime)rd["dt"];
                        if (rd["title"] != DBNull.Value) nouv.title = (string)rd["title"];
                        if (rd["category"] != DBNull.Value) nouv.category = (string)rd["category"];
                        if (rd["tag1"] != DBNull.Value) nouv.tag1 = (string)rd["tag1"];
                        if (rd["visible"] != DBNull.Value) nouv.visible = (string)rd["visible"];


                        news.Add(nouv);
                    }
                }
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return news;
        }

        public static News CreateNewsTest(string n)
        {
            News obj = new News();
            obj.id = "TEST" + n;
            obj.cric = 01;
            obj.title = "News Test n°" + n;
            obj.text = "Texte de la news test n°" + n;
            obj.url = "news_test_" + n + ".pdf";
            obj.url_text = "url text test n°" + n;
            obj.photo = "news_test_" + n + ".jpg";
            obj.category = "Clubs";
            obj.tag1 = "Bulletin";
            obj.tag2 = "";
            obj.visible = "O";
            obj.club_type = "rotary";
            obj.club_name = "Club test";
            obj.Abstract = "Résumé de la news test n°" + n;
            obj.dt = new DateTime(2016, 02, 05);
            obj.end_publication = new DateTime(2016, 03, 05);
            obj.adress_event = "Adresse news test n°" + n;
            obj.town_event = "Ville news test n°" + n;
            obj.zip_event = "01000";
            obj.date_start_event = new DateTime(2016, 02, 10, 10, 00, 00);
            obj.date_end_event = new DateTime(2016, 03, 04, 19, 00, 00);

            return obj;
        }

        public static List<News> CreateListTest()
        {
            List<News> list = new List<News>();
            list.Add(CreateNewsTest("1"));
            list.Add(CreateNewsTest("2"));
            list.Add(CreateNewsTest("3"));
            list.Add(CreateNewsTest("4"));
            list.Add(CreateNewsTest("5"));

            return list;
        }

        public static List<News> ListNewsCourrier()
        {
            List<News> news = null;
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                conn.Open();
                SqlCommand sql = new SqlCommand("SELECT TOP 20 * FROM " + Const.TABLE_PREFIX + "news ORDER BY dt DESC", conn);
                SqlDataAdapter da = new SqlDataAdapter(sql);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables.Count > 0)
                {
                    news = new List<News>();
                    foreach (DataRow rd in ds.Tables[0].Rows)
                    {
                        news.Add(GetNews(rd["id"].ToString()));
                    }
                }
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }

            return news;
        }

        #endregion  News TRADUIT

        #region Nouvelles (ancienne version)

        ///// <summary>
        ///// Modifie ou ajoute une nouvelle dans la table nouvelles
        ///// </summary>
        ///// <param name="nouvelle">La nouvelle à ajouter</param>
        ///// <returns>Validité de l'opération</returns>
        //public static bool UpdateNews(Nouvelle nouvelle)
        //{
        //    SqlConnection conn = new SqlConnection(Config.GetConnectionString());
        //    try
        //    {
        //        conn.Open();
        //        SqlCommand sql;
        //        if (nouvelle.id != null)
        //        {
        //            sql = new SqlCommand("UPDATE " + Const.TABLE_PREFIX + "nouvelles SET [cric]=@cric,[dt]=@dt,[titre]=@titre,[texte]=@texte,[url_texte]=@url_texte,[url]=@url,[photo]=@photo,[categorie]=@categorie,[tag1]=@tag1,[tag2]=@tag2,[visible]=@visible, type_club = @type_club WHERE [id]=@id", conn);
        //            sql.Parameters.AddWithValue("id", nouvelle.id);
        //        }
        //        else
        //        {
        //            sql = new SqlCommand("INSERT INTO " + Const.TABLE_PREFIX + "nouvelles ([cric],[dt],[titre],[texte],[url_texte],[url],[photo],[categorie],[tag1],[tag2],[visible], type_club) VALUES (@cric,@dt,@titre,@texte,@url_texte,@url,@photo,@categorie,@tag1,@tag2,@visible, @type_club)", conn);
        //        }

        //        sql.Parameters.AddWithValue("@cric", nouvelle.cric);
        //        sql.Parameters.AddWithValue("@dt", nouvelle.dt);
        //        sql.Parameters.AddWithValue("@titre", nouvelle.titre);
        //        sql.Parameters.AddWithValue("@texte", nouvelle.texte);
        //        sql.Parameters.AddWithValue("@url_texte", nouvelle.url_texte);
        //        sql.Parameters.AddWithValue("@url", nouvelle.url);
        //        sql.Parameters.AddWithValue("@photo", nouvelle.photo);
        //        sql.Parameters.AddWithValue("@categorie", nouvelle.categorie);
        //        sql.Parameters.AddWithValue("@tag1", nouvelle.tag1);
        //        sql.Parameters.AddWithValue("@tag2", nouvelle.tag2);
        //        sql.Parameters.AddWithValue("@visible", nouvelle.visible);
        //        sql.Parameters.AddWithValue("@type_club", nouvelle.type_club);
        //        if (sql.ExecuteNonQuery() == 0)
        //            throw new Exception("Erreur mise a jour news : " + nouvelle.id);
        //        return true;

        //    }
        //    catch (Exception ee)
        //    {
        //        Functions.Error(ee);
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return false;
        //}

        ///// <summary>
        ///// Supprime une nouvelle de la table nouvelles
        ///// </summary>
        ///// <param name="newsid">ID de la nouvelle</param>
        ///// <returns>Validité de l'opération</returns>
        //public static bool DeleteNews(string newsid)
        //{
        //    SqlConnection conn = new SqlConnection(Config.GetConnectionString());
        //    try
        //    {
        //        conn.Open();
        //        SqlCommand sql = new SqlCommand("DELETE " + Const.TABLE_PREFIX + "nouvelles WHERE id=@id", conn);
        //        sql.Parameters.AddWithValue("@id", newsid);
        //        if (sql.ExecuteNonQuery() == 0)
        //            throw new Exception("Erreur delete news : " + newsid);
        //        return true;

        //    }
        //    catch (Exception ee)
        //    {
        //        Functions.Error(ee);
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return false;
        //}

        ///// <summary>
        ///// Récupère une nouvelle grâce à une DataRow
        ///// </summary>
        ///// <param name="rd">DataRow nécessaire à la récupération</param>
        ///// <param name="clubs">Liste de clubs associés à la nouvelle</param>
        ///// <returns>Nouvelle</returns>
        //static Nouvelle GetNewsByRD(DataRow rd, List<Club> clubs)
        //{
        //    Nouvelle obj = new Nouvelle();
        //    obj.id = "" + rd["id"];
        //    if (rd["cric"] == DBNull.Value) obj.cric = 0; else obj.cric = (int)rd["cric"];
        //    if (rd["dt"] == DBNull.Value) obj.dt = DateTime.MinValue; else obj.dt = (DateTime)rd["dt"];
        //    obj.titre = "" + rd["titre"];
        //    obj.texte = "" + rd["texte"];
        //    obj.url = "" + rd["url"];
        //    obj.url_texte = "" + rd["url_texte"];
        //    obj.photo = "" + rd["photo"];
        //    obj.categorie = "" + rd["categorie"];
        //    obj.tag1 = "" + rd["tag1"];
        //    obj.tag2 = "" + rd["tag2"];
        //    obj.visible = "" + rd["visible"];
        //    obj.type_club = "" + rd["type_club"];
        //    if (obj.cric > 0)
        //    {
        //        foreach (Club club in clubs)
        //            if (club.cric == obj.cric)
        //            {
        //                obj.nom_club = club.name;
        //                break;
        //            }
        //    }
        //    else
        //    {
        //        obj.nom_club = "";
        //    }
        //    return obj;
        //}

        ///// <summary>
        ///// Récupère une nouvelle
        ///// </summary>
        ///// <param name="newsid">ID de la nouvelle</param>
        ///// <returns>Nouvelle</returns>
        //public static Nouvelle GetNews(string newsid)
        //{
        //    List<Club> clubs = ListClubs(sort: "cric asc");
        //    SqlConnection conn = new SqlConnection(Config.GetConnectionString());
        //    try
        //    {
        //        string query = "SELECT * FROM " + Const.TABLE_PREFIX + "nouvelles WHERE id=@id";
        //        conn.Open();
        //        DataSet ds = new DataSet();
        //        SqlCommand sql = new SqlCommand(query, conn);
        //        sql.Parameters.AddWithValue("id", newsid);
        //        SqlDataAdapter da = new SqlDataAdapter(sql);
        //        da.Fill(ds);

        //        if (ds.Tables[0].Rows.Count > 0)
        //            return GetNewsByRD(ds.Tables[0].Rows[0], clubs);
        //    }
        //    catch (Exception ee)
        //    {
        //        Functions.Error(ee);
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }

        //    return null;
        //}

        ///// <summary>
        ///// Récupère une liste de nouvelle sélectionnées grâce aux attributs
        ///// </summary>
        ///// <param name="cric">Cric d'un club</param>
        ///// <param name="categorie">Catégorie de la nouvelle</param>
        ///// <param name="tags_inclus">Différents tags concernant la nouvelle</param>
        ///// <param name="tags_exclus"></param>
        ///// <param name="top">Nombre de nouvelles à sélectionner</param>
        ///// <param name="tri">Type de tri à effectuer</param>
        ///// <param name="index">Numéro de la page de sélection</param>
        ///// <param name="max">Nombre maximum d'entrées par page</param>
        ///// <param name="onlyvisible"></param>
        ///// <param name="date">Date de la nouvelle</param>
        ///// <returns>Liste de nouvelles</returns>
        //public static List<Nouvelle> ListeNewsMobile(int cric = 0, string categorie = "", string tags_inclus = "", string tags_exclus = "", string top = "", string tri = "dt DESC", int index = 0, int max = 100, bool onlyvisible = false, string date = "")
        //{
        //    List<Club> clubs = ListClubs(sort: "cric asc");
        //    List<Nouvelle> liste = new List<Nouvelle>();
        //    SqlConnection conn = new SqlConnection(Config.GetConnectionString());
        //    try
        //    {
        //        string where = "";

        //        #region CATEGORIE
        //        if (!string.IsNullOrEmpty(categorie))
        //        {
        //            where = " categorie=@categorie AND cric=0"; // par defaut le district

        //            if (categorie == "Clubs")
        //                where = " categorie=@categorie AND cric" + (cric == 0 ? ">0" : "=@cric");
        //        }
        //        #endregion CATEGORIE

        //        #region TAG_EXCLUS
        //        if (tags_exclus != "")
        //        {
        //            string t = "";
        //            string[] exclus = tags_exclus.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        //            foreach (string ex in exclus)
        //                t += "'" + ex + "',";
        //            if (t.EndsWith(","))
        //                t = t.Substring(0, t.Length - 1);
        //            if (t != "")
        //            {
        //                where += " and ( tag1 not in (" + t + ") and tag2 not in (" + t + ")) ";
        //            }
        //        }
        //        #endregion TAG_EXCLUS

        //        #region TAG_INCLUS
        //        if (tags_inclus != "")
        //        {
        //            string t = "";
        //            string[] inclus = tags_inclus.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        //            foreach (string inc in inclus)
        //                t += "'" + inc + "',";
        //            if (t.EndsWith(","))
        //                t = t.Substring(0, t.Length - 1);
        //            if (t != "")
        //            {
        //                where += " and ( tag1 in (" + t + ") or tag2 in (" + t + ")) ";
        //            }
        //        }
        //        #endregion TAG_INCLUS

        //        #region VISIBLE
        //        if (onlyvisible)
        //            where += " and visible='" + Const.YES + "' ";
        //        #endregion VISIBLE

        //        #region DATE
        //        if (!string.IsNullOrEmpty(date))
        //        {
        //            where += " and " + date + " ";
        //        }

        //        #endregion DATE

        //        DataSet ds = new DataSet();
        //        string query = "";
        //        if (!string.IsNullOrEmpty(where))
        //        {
        //            if (where.StartsWith(" and"))
        //            {
        //                where = where.Substring(4);
        //            }
        //            query = "SELECT " + top + " * FROM " + Const.TABLE_PREFIX + "nouvelles WHERE " + where + " " + (tri != "" ? "ORDER BY " + tri : "");
        //        }
        //        else
        //        {
        //            query = "SELECT " + top + " * FROM " + Const.TABLE_PREFIX + "nouvelles " + (tri != "" ? "ORDER BY " + tri : "");
        //        }

        //        conn.Open();

        //        SqlCommand sql = new SqlCommand(query, conn);
        //        sql.Parameters.AddWithValue("cric", cric);
        //        sql.Parameters.AddWithValue("categorie", categorie);
        //        SqlDataAdapter da = new SqlDataAdapter(sql);
        //        da.Fill(ds);

        //        //HttpContextSource.Current.Application["news:" + query] = ds;
        //        //}
        //        int i = 0;
        //        int c = 0;
        //        foreach (DataRow rd in ds.Tables[0].Rows)
        //        {
        //            if (i >= (index * max) && c < max)
        //            {
        //                liste.Add(AIS.DataMapping.GetNewsByRD(rd, clubs));
        //                c++;
        //            }
        //            else
        //            {
        //                liste.Add(new Nouvelle());
        //            }
        //            i++;
        //        }
        //    }
        //    catch (Exception ee)
        //    {
        //        Functions.Error(ee);
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }

        //    return liste;
        //}

        ///// <summary>
        ///// Récupère une liste de nouvelles sélectionnées grâce aux attributs
        ///// </summary>
        ///// <param name="cric">Cric d'un club</param>
        ///// <param name="categorie">Catégorie de la nouvelle</param>
        ///// <param name="tags_inclus"></param>
        ///// <param name="tags_exclus"></param>
        ///// <param name="top">Nombre de nouvelles à sélectionner</param>
        ///// <param name="tri">Type de tri</param>
        ///// <param name="index">Numéro de la page de sélection</param>
        ///// <param name="max">Nombre maximal d'entrées par page</param>
        ///// <param name="onlyvisible"></param>
        ///// <returns>Liste de nouvelles</returns>
        //public static List<Nouvelle> ListeNews(int cric = 0, string categorie = "", string tags_inclus = "", string tags_exclus = "", string top = "", string tri = "dt DESC", int index = 0, int max = 100, bool onlyvisible = false)
        //{
        //    List<Club> clubs = ListClubs(sort: "cric asc");
        //    List<Nouvelle> liste = new List<Nouvelle>();
        //    SqlConnection conn = new SqlConnection(Config.GetConnectionString());
        //    try
        //    {
        //        string where = " categorie=@categorie AND cric=0"; // par defaut le district

        //        if (categorie == "Clubs")
        //            where = " categorie=@categorie AND cric" + (cric == 0 ? ">0" : "=@cric");

        //        if (tags_exclus != "")
        //        {
        //            string t = "";
        //            string[] exclus = tags_exclus.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        //            foreach (string ex in exclus)
        //                t += "'" + ex + "',";
        //            if (t.EndsWith(","))
        //                t = t.Substring(0, t.Length - 1);
        //            if (t != "")
        //            {
        //                where += " and ( tag1 not in (" + t + ") and tag2 not in (" + t + ")) ";
        //            }
        //        }
        //        if (tags_inclus != "")
        //        {
        //            string t = "";
        //            string[] inclus = tags_inclus.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        //            foreach (string inc in inclus)
        //                t += "'" + inc + "',";
        //            if (t.EndsWith(","))
        //                t = t.Substring(0, t.Length - 1);
        //            if (t != "")
        //            {
        //                where += " and ( tag1 in (" + t + ") or tag2 in (" + t + ")) ";
        //            }
        //        }
        //        if (onlyvisible)
        //            where += " and visible='" + Const.YES + "' ";
        //        DataSet ds = new DataSet();
        //        string query = "SELECT " + top + " * FROM " + Const.TABLE_PREFIX + "nouvelles WHERE " + where + " " + (tri != "" ? "ORDER BY " + tri : "");

        //        //if(HttpContextSource.Current.Application["news:"+query]!=null)
        //        //    ds = (DataSet)HttpContextSource.Current.Application["news:" + query];
        //        //else
        //        //{
        //        conn.Open();

        //        SqlCommand sql = new SqlCommand(query, conn);
        //        sql.Parameters.AddWithValue("cric", cric);
        //        sql.Parameters.AddWithValue("categorie", categorie);
        //        SqlDataAdapter da = new SqlDataAdapter(sql);
        //        da.Fill(ds);

        //        //HttpContextSource.Current.Application["news:" + query] = ds;
        //        //}
        //        int i = 0;
        //        int c = 0;
        //        foreach (DataRow rd in ds.Tables[0].Rows)
        //        {
        //            if (i >= (index * max) && c < max)
        //            {
        //                liste.Add(GetNewsByRD(rd, clubs));
        //                c++;
        //            }
        //            else
        //            {
        //                liste.Add(new Nouvelle());
        //            }
        //            i++;
        //        }
        //    }
        //    catch (Exception ee)
        //    {
        //        Functions.Error(ee);
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }

        //    return liste;
        //}

        //public static List<Nouvelle> SimpleListeNews(string requete)
        //{
        //    List<Nouvelle> news = null;
        //    SqlConnection conn = new SqlConnection(Config.GetConnectionString());
        //    try
        //    {
        //        conn.Open();
        //        SqlCommand sql;
        //        if (!string.IsNullOrEmpty(requete))
        //        {
        //            //On crée la requête permettant de récupérer les membres correspondant aux critères sélectionnés 
        //            sql = new SqlCommand("SELECT * FROM " + Const.TABLE_PREFIX + "nouvelles WHERE " + requete + " ORDER BY titre ASC", conn);
        //        }
        //        else
        //        {//Cette requête sélectionne tous les membres
        //            sql = new SqlCommand("SELECT * FROM " + Const.TABLE_PREFIX + "nouvelles ORDER BY titre ASC", conn);
        //        }

        //        SqlDataAdapter da = new SqlDataAdapter(sql);
        //        DataSet ds = new DataSet();
        //        da.Fill(ds);
        //        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //        {
        //            news = new List<Nouvelle>();
        //            foreach (DataRow rd in ds.Tables[0].Rows)
        //            {
        //                Nouvelle nouv = new Nouvelle();
        //                //On associe les résultats à chaque assiduité qu l'on mettra dans la liste
        //                if (rd["id"] != DBNull.Value) nouv.id = (string)rd["id"];
        //                if (rd["cric"] != DBNull.Value) nouv.cric = (int)rd["cric"];
        //                if (rd["dt"] != DBNull.Value) nouv.dt = (DateTime)rd["dt"];
        //                if (rd["titre"] != DBNull.Value) nouv.titre = (string)rd["titre"];
        //                if (rd["categorie"] != DBNull.Value) nouv.categorie = (string)rd["categorie"];
        //                if (rd["tag1"] != DBNull.Value) nouv.tag1 = (string)rd["tag1"];
        //                if (rd["visible"] != DBNull.Value) nouv.visible = (string)rd["visible"];


        //                news.Add(nouv);
        //            }
        //        }
        //    }
        //    catch (Exception ee)
        //    {
        //        Functions.Error(ee);
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return news;
        //}

        #endregion Nouvelles

        #region News EN (Version intermédiaire courrier district)

        /// <summary>
        /// Modifie ou ajoute une nouvelle dans la table nouvelles
        /// </summary>
        /// <param name="nouvelle">La nouvelle à ajouter</param>
        /// <returns>Validité de l'opération</returns>
        public static bool UpdateNews_EN(News news)
        {
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                conn.Open();
                SqlCommand sql;
                if (news.id != null)
                {
                    sql = new SqlCommand("UPDATE " + Const.TABLE_PREFIX + "news SET [cric]=@cric,[dt]=@dt,[title]=@title,[text]=@text,[url_text]=@url_text,[url]=@url,[photo]=@photo,[category]=@category,[tag1]=@tag1,[tag2]=@tag2,[visible]=@visible,[club_type]=@club_type,[ord]=@ord WHERE [id]=@id", conn);
                    sql.Parameters.AddWithValue("id", news.id);
                }
                else
                {
                    sql = new SqlCommand("INSERT INTO " + Const.TABLE_PREFIX + "news ([cric],[dt],[title],[text],[url_text],[url],[photo],[category],[tag1],[tag2],[visible],[club_type],[ord]) VALUES (@cric,@dt,@title,@text,@url_text,@url,@photo,@category,@tag1,@tag2,@visible,@club_type,@ord)", conn);
                }

                sql.Parameters.AddWithValue("@cric", news.cric);
                if (news.dt != null)
                    sql.Parameters.AddWithValue("@dt", news.dt);
                else
                    sql.Parameters.AddWithValue("@dt", DBNull.Value);
                sql.Parameters.AddWithValue("@title", news.title);
                sql.Parameters.AddWithValue("@text", news.text);
                sql.Parameters.AddWithValue("@url_text", news.url_text);
                sql.Parameters.AddWithValue("@url", news.url);
                sql.Parameters.AddWithValue("@photo", news.photo);
                sql.Parameters.AddWithValue("@category", news.category);
                sql.Parameters.AddWithValue("@tag1", news.tag1);
                sql.Parameters.AddWithValue("@tag2", news.tag2);
                sql.Parameters.AddWithValue("@visible", news.visible);
                sql.Parameters.AddWithValue("@club_type", news.club_type);
                sql.Parameters.AddWithValue("@ord", news.ord);
                if (sql.ExecuteNonQuery() == 0)
                    throw new Exception("Erreur mise a jour news : " + news.id);
                return true;

            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        /// <summary>
        /// Supprime une nouvelle de la table nouvelles
        /// </summary>
        /// <param name="newsid">ID de la nouvelle</param>
        /// <returns>Validité de l'opération</returns>
        public static bool DeleteNews_EN(string newsid)
        {
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                conn.Open();
                SqlCommand sql = new SqlCommand("DELETE " + Const.TABLE_PREFIX + "news WHERE id=@id", conn);
                sql.Parameters.AddWithValue("@id", newsid);
                if (sql.ExecuteNonQuery() == 0)
                    throw new Exception("Erreur delete news : " + newsid);
                return true;

            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        /// <summary>
        /// Récupère une nouvelle grâce à une DataRow
        /// </summary>
        /// <param name="rd">DataRow nécessaire à la récupération</param>
        /// <param name="clubs">Liste de clubs associés à la nouvelle</param>
        /// <returns>Nouvelle</returns>
        static News GetNewsByRD_EN(DataRow rd, List<Club> clubs)
        {
            News obj = new News();
            obj.id = "" + rd["id"];
            if (rd["cric"] == DBNull.Value) obj.cric = 0; else obj.cric = (int)rd["cric"];
            if (rd["dt"] == DBNull.Value) obj.dt = DateTime.MinValue; else obj.dt = (DateTime)rd["dt"];
            obj.title = "" + rd["title"];
            obj.text = "" + rd["text"];
            obj.url = "" + rd["url"];
            obj.url_text = "" + rd["url_text"];
            obj.photo = "" + rd["photo"];
            obj.category = "" + rd["category"];
            obj.tag1 = "" + rd["tag1"];
            obj.tag2 = "" + rd["tag2"];
            obj.visible = "" + rd["visible"];
            obj.club_type = "" + rd["club_type"];
            obj.ord = rd["ord"] == DBNull.Value ? 0 : (int)rd["ord"];
            if (obj.cric > 0)
            {
                foreach (Club club in clubs)
                    if (club.cric == obj.cric)
                    {
                        obj.club_name = club.name;
                        break;
                    }
            }
            else
            {
                obj.club_name = "";
            }
            return obj;
        }

        /// <summary>
        /// Récupère une nouvelle
        /// </summary>
        /// <param name="newsid">ID de la nouvelle</param>
        /// <returns>Nouvelle</returns>
        public static News GetNews_EN(string newsid)
        {
            List<Club> clubs = ListClubs(sort: "cric asc");
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                string query = "SELECT * FROM " + Const.TABLE_PREFIX + "news WHERE id=@id";
                conn.Open();
                DataSet ds = new DataSet();
                SqlCommand sql = new SqlCommand(query, conn);
                sql.Parameters.AddWithValue("id", newsid);
                SqlDataAdapter da = new SqlDataAdapter(sql);
                da.Fill(ds);



                if (ds.Tables[0].Rows.Count > 0)
                {
                    News news = GetNewsByRD_EN(ds.Tables[0].Rows[0], clubs);

                    query = "SELECT * FROM " + Const.TABLE_PREFIX + "news_blocs WHERE news_id=@news_id ORDER BY ord";
                    ds = new DataSet();
                    sql = new SqlCommand(query, conn);
                    sql.Parameters.AddWithValue("news_id", news.id);
                    da = new SqlDataAdapter(sql);
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            News.Bloc bloc = new News.Bloc();
                            bloc.id = "" + row["id"];
                            bloc.ord = (int)row["ord"];
                            bloc.photo = "" + row["photo"];
                            bloc.content = "" + row["content"];
                            bloc.content_type = "" + row["content_type"];
                            bloc.title = "" + row["title"];
                            bloc.type = "" + row["type"];
                            bloc.visible = "" + row["visible"];
                            news.AddBloc(bloc);
                        }


                    }

                    return news;
                }
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }

            return null;
        }


        /// <summary>
        /// Récupère une liste de nouvelles sélectionnées grâce aux attributs
        /// </summary>
        /// <param name="cric">Cric d'un club</param>
        /// <param name="categorie">Catégorie de la nouvelle</param>
        /// <param name="tags_included"></param>
        /// <param name="tags_excluded"></param>
        /// <param name="top">Nombre de nouvelles à sélectionner</param>
        /// <param name="tri">Type de tri</param>
        /// <param name="index">Numéro de la page de sélection</param>
        /// <param name="max">Nombre maximal d'entrées par page</param>
        /// <param name="onlyvisible"></param>
        /// <returns>Liste de nouvelles</returns>
        public static List<News> ListNews_EN(int cric = 0, string category = "", string tags_included = "", string tags_excluded = "", string top = "", string tri = "dt ASC", int index = 0, int max = 100, bool onlyvisible = false, string where = "")
        {
            List<Club> clubs = ListClubs(sort: "cric asc");
            List<News> liste = new List<News>();
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                if (where != "")
                    where += " AND ";

                if (category == "Clubs")
                    where = where + " category=@category AND cric" + (cric == 0 ? ">0" : "=@cric");
                else if (category == "Tous")
                    where = where + " (category='District' OR category='Clubs') ";
                else if (cric!=0)
                    where = where + " category=@category AND cric="+cric; // par defaut le distric
                else
                    where = where + " category=@category AND cric=0"; // par defaut le distric

                if (tags_excluded != "")
                {
                    string t = "";
                    string[] exclus = tags_excluded.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string ex in exclus)
                        t += "'" + ex + "',";
                    if (t.EndsWith(","))
                        t = t.Substring(0, t.Length - 1);
                    if (t != "")
                    {
                        where += " and ( tag1 not in (" + t + ") and tag2 not in (" + t + ")) ";
                    }
                }
                if (tags_included != "")
                {
                    string t = "";
                    string[] inclus = tags_included.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string inc in inclus)
                        t += "'" + inc + "',";
                    if (t.EndsWith(","))
                        t = t.Substring(0, t.Length - 1);
                    if (t != "")
                    {
                        where += " and ( tag1 in (" + t + ") or tag2 in (" + t + ")) ";
                    }
                }
                if (onlyvisible)
                    where += " and visible='" + Const.YES + "' ";
                DataSet ds = new DataSet();
                string query = "SELECT " + top + " * FROM " + Const.TABLE_PREFIX + "news WHERE " + where + " " + (tri != "" ? "ORDER BY " + tri : "");

                //if(HttpContextSource.Current.Application["news:"+query]!=null)
                //    ds = (DataSet)HttpContextSource.Current.Application["news:" + query];
                //else
                //{
                conn.Open();

                SqlCommand sql = new SqlCommand(query, conn);
                sql.Parameters.AddWithValue("cric", cric);
                sql.Parameters.AddWithValue("category", category);
                SqlDataAdapter da = new SqlDataAdapter(sql);
                da.Fill(ds);

                //HttpContextSource.Current.Application["news:" + query] = ds;
                //}
                int i = 0;
                int c = 0;
                foreach (DataRow rd in ds.Tables[0].Rows)
                {
                    if (i >= (index * max) && c < max)
                    {
                        News news = GetNewsByRD_EN(rd, clubs);

                        query = "SELECT * FROM " + Const.TABLE_PREFIX + "news_blocs WHERE news_id=@news_id ORDER BY ord";
                        ds = new DataSet();
                        sql = new SqlCommand(query, conn);
                        sql.Parameters.AddWithValue("news_id", news.id);
                        da = new SqlDataAdapter(sql);
                        da.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                News.Bloc bloc = new News.Bloc();
                                bloc.id = "" + row["id"];
                                bloc.ord = (int)row["ord"];
                                bloc.photo = "" + row["photo"];
                                bloc.content = "" + row["content"];
                                bloc.content_type = "" + row["content_type"];
                                bloc.title = "" + row["title"];
                                bloc.type = "" + row["type"];
                                bloc.visible = "" + row["visible"];
                                news.AddBloc(bloc);
                            }


                        }
                        liste.Add(news);
                        c++;
                    }
                    else
                    {
                        liste.Add(new News());
                    }
                    i++;
                }
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }

            return liste;
        }


        #endregion News

        static News.Bloc GetBlocByRD(DataRow rd)
        {
            News.Bloc obj = new News.Bloc();


            obj.id = "" + rd["id"];
            obj.visible = "" + rd["visible"];
            obj.type = "" + rd["type"];
            if (rd["ord"] != DBNull.Value) obj.ord = int.Parse(rd["ord"].ToString());
            obj.title = "" + rd["title"];
            obj.photo = "" + rd["photo"];
            obj.content = "" + rd["content"];
            obj.content_type = "" + rd["content_type"];

            return obj;
        }

        public static bool UpdateNewsBloc(News.Bloc bloc, string newsid = "")
        {
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());

            try
            {
                conn.Open();
                SqlCommand sql = new SqlCommand();
                if (bloc.id != null)
                {
                    sql = new SqlCommand("UPDATE " + Const.TABLE_PREFIX + "news_blocs SET [visible]=@visible,[type]=@type,[ord]=@ord,[title]=@title,[photo]=@photo,[content_type]=@content_type,[content]=@content WHERE [id]=@id", conn);
                    sql.Parameters.AddWithValue("id", bloc.id);
                }
                else
                {
                    sql = new SqlCommand("INSERT INTO " + Const.TABLE_PREFIX + "news_blocs ([news_id],[visible],[type],[ord],[title],[photo],[content_type],[content]) VALUES (@news_id,@visible,@type,@ord,@title,@photo,@content_type,@content)", conn);
                    sql.Parameters.AddWithValue("@news_id", newsid);
                }

                sql.Parameters.AddWithValue("@visible", bloc.visible);
                sql.Parameters.AddWithValue("@type", bloc.type);
                sql.Parameters.AddWithValue("@ord", bloc.ord);
                sql.Parameters.AddWithValue("@title", bloc.title);
                sql.Parameters.AddWithValue("@photo", bloc.photo);
                sql.Parameters.AddWithValue("@content_type", bloc.content_type);
                sql.Parameters.AddWithValue("@content", bloc.content);

                if (sql.ExecuteNonQuery() == 0)
                    throw new Exception("Erreur mise a jour bloc : " + bloc.id);

                return true;

            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        public static bool DeleteNewsBloc(News.Bloc bloc)
        {
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                conn.Open();
                SqlCommand sql = new SqlCommand("DELETE " + Const.TABLE_PREFIX + "news_blocs WHERE id=@id", conn);
                sql.Parameters.AddWithValue("@id", bloc.id);
                if (sql.ExecuteNonQuery() == 0)
                    throw new Exception("Erreur delete news : " + bloc.id);
                return true;

            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        #region Newsletter
        /// <summary>
        /// Get a list of Newsletters
        /// </summary>
        /// <param name="cric">Cric of the club receiving the Newsletter</param>
        /// <param name="top"></param>
        /// <param name="tri"></param>
        /// <param name="index"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static List<Newsletter> ListNewsletters(int cric = 0, string top = "", string sort = "dt DESC", int index = 0, int max = 100)
        {
            List<Club> clubs = ListClubs(sort: "cric asc");
            List<Newsletter> list = new List<Newsletter>();
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                //string where = " cric=0"; // par defaut le district

                DataSet ds = new DataSet();
                //string query = "SELECT " + top + " * FROM " + Const.TABLE_PREFIX + "newsletters WHERE " + where + " " + (sort!= "" ? "ORDER BY " + sort: "");
                string query = "SELECT " + top + " * FROM " + Const.TABLE_PREFIX + "newsletters WHERE cric = @cric " + (sort != "" ? "ORDER BY " + sort : "");

                //if(HttpContextSource.Current.Application["news:"+query]!=null)
                //    ds = (DataSet)HttpContextSource.Current.Application["news:" + query];
                //else
                //{
                conn.Open();

                SqlCommand sql = new SqlCommand(query, conn);
                sql.Parameters.AddWithValue("cric", cric);
                SqlDataAdapter da = new SqlDataAdapter(sql);
                da.Fill(ds);

                //HttpContextSource.Current.Application["news:" + query] = ds;
                //}
                int i = 0;
                int c = 0;
                foreach (DataRow rd in ds.Tables[0].Rows)
                {
                    if (i >= (index * max) && c < max)
                    {
                        list.Add(GetNewsletterByRD(rd));
                        c++;
                    }
                    else
                    {
                        list.Add(new Newsletter());
                    }
                    i++;
                }
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }

            return list;
        }

        /// <summary>
        /// Get a list of members to send mail
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static List<Member> GetListMembers_Mailling(string query)
        {
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            List<Member> lalist = new List<Member>();

            int year_0 = Functions.GetRotaryYear();
            int year_1 = year_0 + 1;

            try
            {
                conn.Open();
                SqlCommand sql = new SqlCommand(query, conn);

                SqlDataAdapter da = new SqlDataAdapter(sql);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow r in ds.Tables[0].Rows)
                    {
                        Member m = GetMemberByRD(r);

                        if (m != null)
                        {
                            lalist.Add(m);
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return lalist;
        }

        /// <summary>
        /// Add or edit a newsletter
        /// </summary>
        /// <param name="newsletter"></param>
        /// <returns></returns>
        public static bool UpdateNewsletter(Newsletter newsletter)
        {
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                conn.Open();
                SqlCommand sql;
                if (newsletter.id != null)
                {
                    sql = new SqlCommand("UPDATE " + Const.TABLE_PREFIX + "newsletters SET [id]=@id,[cric]=@cric,[dt]=@dt,[title]=@title,[text]=@text,[recipient]=@recipient,[status]=@status,[sender_email]=@sender_email,[sender_name]=@sender_name, club_type = @club_type WHERE [id]=@id", conn);
                    sql.Parameters.AddWithValue("id", newsletter.id);
                }
                else
                {
                    sql = new SqlCommand("INSERT INTO " + Const.TABLE_PREFIX + "newsletters ([cric],[dt],[title],[text],[recipient],[status],[sender_email],[sender_name], club_type) VALUES (@cric,@dt,@title,@text,@recipient,@status,@sender_email,@sender_name, @club_type)", conn);
                }
                sql.Parameters.AddWithValue("@cric", newsletter.cric);
                sql.Parameters.AddWithValue("@dt", newsletter.dt);
                sql.Parameters.AddWithValue("@title", newsletter.title);
                sql.Parameters.AddWithValue("@text", newsletter.text);
                sql.Parameters.AddWithValue("@recipient", newsletter.recipient);
                sql.Parameters.AddWithValue("@status", newsletter.status);
                sql.Parameters.AddWithValue("@sender_email", newsletter.sender_email);
                sql.Parameters.AddWithValue("@sender_name", newsletter.sender_name);
                sql.Parameters.AddWithValue("@club_type", newsletter.club_type);

                if (sql.ExecuteNonQuery() == 0)
                    throw new Exception("Erreur mise a day newsletter : " + newsletter.id);
                return true;

            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        /// <summary>
        /// Add or edit a newsletter
        /// </summary>
        /// <param name="newsletter"></param>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static bool UpdateNewsletter(Newsletter newsletter, string guid)
        {
            string nb = "";
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                conn.Open();
                SqlCommand sql;
                if (newsletter.id != null)
                {
                    sql = new SqlCommand("UPDATE " + Const.TABLE_PREFIX + "newsletters SET [id]=@id,[cric]=@cric,[dt]=@dt,[title]=@title,[text]=@text,[recipient]=@recipient,[status]=@status,[sender_email]=@sender_email,[sender_name]=@sender_name, club_type = @club_type WHERE [id]=@id", conn);
                    sql.Parameters.AddWithValue("id", newsletter.id);
                }
                else
                {
                    sql = new SqlCommand("INSERT INTO " + Const.TABLE_PREFIX + "newsletters ([id],[cric],[dt],[title],[text],[recipient],[status],[sender_email],[sender_name], club_type) VALUES (@id,@cric,@dt,@title,@text,@recipient,@status,@sender_email,@sender_name, @club_type)", conn);
                    sql.Parameters.AddWithValue("@id", guid);
                }
                sql.Parameters.AddWithValue("@cric", newsletter.cric);
                sql.Parameters.AddWithValue("@dt", newsletter.dt);
                sql.Parameters.AddWithValue("@title", newsletter.title);
                sql.Parameters.AddWithValue("@text", newsletter.text);
                sql.Parameters.AddWithValue("@recipient", newsletter.recipient);
                sql.Parameters.AddWithValue("@status", newsletter.status);
                sql.Parameters.AddWithValue("@sender_email", newsletter.sender_email);
                sql.Parameters.AddWithValue("@sender_name", newsletter.sender_name);
                sql.Parameters.AddWithValue("@club_type", newsletter.club_type);

                if (sql.ExecuteNonQuery() == 0)
                    throw new Exception("Erreur mise a day newsletter : " + newsletter.id);
                return true;

            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        /// <summary>
        /// Delete a newsletter
        /// </summary>
        /// <param name="newsletterid"></param>
        /// <returns></returns>
        public static bool DeleteNewsletter(string newsletterid)
        {
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                conn.Open();
                SqlCommand sql = new SqlCommand("DELETE " + Const.TABLE_PREFIX + "newsletters WHERE id=@id", conn);
                sql.Parameters.AddWithValue("@id", newsletterid);
                if (sql.ExecuteNonQuery() == 0)
                    throw new Exception("Erreur delete newsletter : " + newsletterid);
                return true;

            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        /// <summary>
        /// Add a newsletter in newsletter_out
        /// </summary>
        /// <param name="newsletter_id"></param>
        /// <param name="nim"></param>
        /// <param name="email"></param>
        /// <param name="status"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public static bool Insert_Newsletter_Out(string newsletter_id, int nim, string email, string status, string error)
        {
            if (email == "")
                return true;
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                conn.Open();
                SqlCommand sql;

                sql = new SqlCommand("INSERT INTO " + Const.TABLE_PREFIX + "newsletters_out ([newsletter_id],[nim],[email],[status],[error]) VALUES (@newsletter_id,@nim,@email,@status,@error)", conn);
                sql.Parameters.AddWithValue("@newsletter_id", newsletter_id);
                sql.Parameters.AddWithValue("@nim", nim);
                sql.Parameters.AddWithValue("@email", email);
                sql.Parameters.AddWithValue("@status", status);
                sql.Parameters.AddWithValue("@error", error);

                if (sql.ExecuteNonQuery() == 0)
                    throw new Exception("Erreur Creation envoi newsletter " + newsletter_id);
                return true;

            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        /// <summary>
        /// Add a newsletter_out
        /// </summary>
        /// <param name="n"></param>
        /// <param name="les_recipients"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static bool Insert_Newsletter_Out(Newsletter n, List<Member> recipients, string status)
        {
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            SqlTransaction trans = null;
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand sql;

                foreach (Member m in recipients)
                {
                    if (m.email != "")
                    {
                        sql = new SqlCommand("INSERT INTO " + Const.TABLE_PREFIX + "newsletters_out ([newsletter_id],[nim],[email],[status],[error]) VALUES (@newsletter_id,@nim,@email,@status,@error)", conn, trans);
                        sql.Parameters.AddWithValue("@newsletter_id", n.id);
                        sql.Parameters.AddWithValue("@nim", m.nim);
                        sql.Parameters.AddWithValue("@email", m.email);
                        sql.Parameters.AddWithValue("@status", status);
                        sql.Parameters.AddWithValue("@error", "");
                        int nb = sql.ExecuteNonQuery();
                        if (nb == 0)
                        {
                            throw new Exception("Erreur Creation envoi newsletter " + n.id);
                        }
                    }
                }
                n.status = "E";
                bool retour = UpdateNewsletter(n);

                trans.Commit();

                return true;
            }
            catch
            {
                if (trans != null)
                {
                    trans.Rollback();
                }
                return false;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        /// <summary>
        /// Edit a newsletter_out
        /// </summary>
        /// <param name="n_o"></param>
        /// <returns></returns>
        public static bool Update_Newsletter_Out(Newsletter_Out n_o)
        {
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                conn.Open();
                SqlCommand sql;

                sql = new SqlCommand("UPDATE " + Const.TABLE_PREFIX + "newsletters_out SET [newsletter_id] = @newsletter_id, [nim] = @nim, [email] = @email, [status] = @status, [error] = @error WHERE id=@id", conn);
                sql.Parameters.AddWithValue("@newsletter_id", n_o.newsletter_id);
                sql.Parameters.AddWithValue("@nim", n_o.nim);
                sql.Parameters.AddWithValue("@email", n_o.email);
                sql.Parameters.AddWithValue("@status", n_o.status);
                sql.Parameters.AddWithValue("@error", n_o.error);
                sql.Parameters.AddWithValue("@id", n_o.id);

                if (sql.ExecuteNonQuery() == 0)
                    throw new Exception("Erreur MAJ newsletter " + n_o.newsletter_id);
                return true;

            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        /// <summary>
        /// Get a newsletter_out
        /// </summary>
        /// <param name="rd"></param>
        /// <returns></returns>
        static Newsletter_Out Get_Newsletter_Out(DataRow rd)
        {
            Newsletter_Out obj = new Newsletter_Out();

            if (rd["id"] == DBNull.Value) obj.id = 0; else obj.id = (int)rd["id"];
            obj.newsletter_id = "" + rd["newsletter_id"];
            if (rd["nim"] == DBNull.Value) obj.nim = 0; else obj.nim = (int)rd["nim"];
            obj.email = "" + rd["email"];
            obj.status = "" + rd["status"];
            obj.error = "" + rd["error"];

            return obj;
        }

        /// <summary>
        /// Get a list of newsletter_out
        /// </summary>
        /// <param name="Newsletter_id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static List<Newsletter_Out> Get_Recipient_by_Newsletter_id(string Newsletter_id, string status)
        {
            List<Newsletter_Out> la_List = new List<Newsletter_Out>();

            SqlConnection conn = new SqlConnection(Config.GetConnectionString());

            try
            {
                conn.Open();
                SqlCommand sql = new SqlCommand("SELECT * FROM " + Const.TABLE_PREFIX + "newsletters_out WHERE Newsletter_id = @Newsletter_id AND status = @status AND nim > 0", conn);
                sql.Parameters.AddWithValue("@Newsletter_id", Newsletter_id);
                sql.Parameters.AddWithValue("@status", status);
                SqlDataAdapter da = new SqlDataAdapter(sql);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow r in ds.Tables[0].Rows)
                    {
                        Newsletter_Out n_o = Get_Newsletter_Out(r);

                        if (n_o != null)
                        {
                            la_List.Add(n_o);
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return la_List;
        }

        public static List<Newsletter_Out> Get_Mails_Test()
        {
            List<Newsletter_Out> la_List = new List<Newsletter_Out>();

            SqlConnection conn = new SqlConnection(Config.GetConnectionString());

            try
            {
                conn.Open();
                SqlCommand sql = new SqlCommand("SELECT * FROM " + Const.TABLE_PREFIX + "newsletters_out WHERE nim = 0 AND status = 'A'", conn);

                SqlDataAdapter da = new SqlDataAdapter(sql);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow r in ds.Tables[0].Rows)
                    {
                        Newsletter_Out n_o = Get_Newsletter_Out(r);

                        if (n_o != null)
                        {
                            SqlCommand sql2 = new SqlCommand("SELECT TOP 1 * FROM " + Const.TABLE_PREFIX + "newsletters WHERE id = @id", conn);
                            sql2.Parameters.AddWithValue("id", n_o.newsletter_id);
                            SqlDataAdapter da2 = new SqlDataAdapter(sql2);
                            DataSet ds2 = new DataSet();
                            da2.Fill(ds2);
                            if (ds2.Tables.Count > 0 && ds2.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow rd in ds2.Tables[0].Rows)
                                {
                                    Newsletter n = GetNewsletterByRD(rd);
                                    if (n != null)
                                    {
                                        n_o.la_Newsletter = n;
                                    }
                                }
                            }

                            la_List.Add(n_o);
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return la_List;
        }

        /// <summary>
        /// Get a newsletter thanks to a DataRow
        /// </summary>
        /// <param name="rd"></param>
        /// <returns></returns>
        static Newsletter GetNewsletterByRD(DataRow rd)
        {
            Newsletter obj = new Newsletter();
            obj.id = "" + rd["id"];
            obj.cric = (int)rd["cric"];
            obj.dt = (DateTime)rd["dt"];
            obj.title = "" + rd["title"];
            obj.text = "" + rd["text"];
            obj.recipient = "" + rd["recipient"];
            obj.status = "" + rd["status"];
            obj.sender_email = "" + rd["sender_email"];
            obj.sender_name = "" + rd["sender_name"];

            obj.club_type = "" + rd["club_type"];

            return obj;
        }

        /// <summary>
        /// Get a Newsletter
        /// </summary>
        /// <param name="newsletterid"></param>
        /// <returns></returns>
        public static Newsletter GetNewsletter(string newsletterid)
        {
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                string query = "SELECT * FROM " + Const.TABLE_PREFIX + "newsletters WHERE id=@id";
                conn.Open();
                DataSet ds = new DataSet();
                SqlCommand sql = new SqlCommand(query, conn);
                sql.Parameters.AddWithValue("id", newsletterid);
                SqlDataAdapter da = new SqlDataAdapter(sql);
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                    return GetNewsletterByRD(ds.Tables[0].Rows[0]);
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }

            return null;
        }

        /// <summary>
        /// Get a newsletter thanks to its status
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static Newsletter GetNewsletter_By_status(string status)
        {
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                string query = "SELECT TOP 1 * FROM " + Const.TABLE_PREFIX + "newsletters WHERE status=@status";
                conn.Open();
                DataSet ds = new DataSet();
                SqlCommand sql = new SqlCommand(query, conn);
                sql.Parameters.AddWithValue("status", status);
                SqlDataAdapter da = new SqlDataAdapter(sql);
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                    return GetNewsletterByRD(ds.Tables[0].Rows[0]);
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }

            return null;
        }

        /// <summary>
        /// Get number of a newsletter's mails for a defined status
        /// </summary>
        /// <param name="newsletter_id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static string Get_Nb_Mails_by_status(string newsletter_id, string status)
        {
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                conn.Open();
                SqlCommand sql;
                if (status == "TE")
                {
                    sql = new SqlCommand("SELECT COUNT(status) FROM " + Const.TABLE_PREFIX + "newsletters_out WHERE (status = 'T' OR  status='E') AND newsletter_id = @newsletter_id AND nim > 0", conn);
                }
                else
                {
                    sql = new SqlCommand("SELECT COUNT(status) FROM " + Const.TABLE_PREFIX + "newsletters_out WHERE status = @status AND newsletter_id = @newsletter_id AND nim > 0", conn);
                    sql.Parameters.AddWithValue("status", status);
                }
                sql.Parameters.AddWithValue("newsletter_id", newsletter_id);
                string nb = "" + sql.ExecuteScalar();
                return nb;
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }

            return null;
        }
        #endregion Newsletter

        #region Documents

        /// <summary>
        /// Create a PDF document and a Word file from a list of members and affectations
        /// </summary>
        /// <param name="file_word_modele">Name of Word file</param>
        /// <param name="members">Members list</param>
        /// <param name="affectations">Affectations list</param>
        /// <param name="name">File name</param>
        /// <param name="typemime"></param>
        /// <returns></returns>
        public static Media ProductionDocument(string word_file_model, List<Member> members, List<Affectation> affectations, string name, string typemime = "application/pdf")
        {
            string validite = "30/06/" + (Functions.GetRotaryYear() + 1);

            string chemin = PortalSettings.Current.HomeDirectory;
            chemin += word_file_model;
            chemin = HttpContextSource.Current.Server.MapPath(chemin);

            InitLicenceAsposeBarcode();
            InitLicenceAsposeWords();


            Aspose.Words.Document doc = new Aspose.Words.Document();
            Aspose.Words.Document template = new Aspose.Words.Document(chemin);

            Aspose.Words.DocumentBuilder builder = new Aspose.Words.DocumentBuilder(doc);
            builder.PageSetup.LeftMargin = ConvertUtil.MillimeterToPoint(20);
            builder.PageSetup.RightMargin = ConvertUtil.MillimeterToPoint(20);
            builder.PageSetup.PaperSize = PaperSize.A4;



            List<Aspose.Words.Tables.Row> rows = new List<Aspose.Words.Tables.Row>();
            Aspose.Words.Tables.Row row = new Aspose.Words.Tables.Row(doc);
            row.RowFormat.Borders.LineWidth = 0;
            row.RowFormat.Borders.Color = System.Drawing.Color.Transparent;
            row.RowFormat.Height = ConvertUtil.MillimeterToPoint(54);
            int col = 0;

            foreach (Member membre in members)
            {
                if (col > 1)
                {
                    rows.Add(row);
                    row = new Aspose.Words.Tables.Row(doc);
                    row.RowFormat.Borders.LineWidth = 0;
                    row.RowFormat.Borders.Color = System.Drawing.Color.Transparent;
                    row.RowFormat.Height = ConvertUtil.MillimeterToPoint(54);

                    col = 0;
                }
                Aspose.Words.Tables.Cell cell = new Aspose.Words.Tables.Cell(doc);
                cell.CellFormat.Width = ConvertUtil.MillimeterToPoint(86);
                row.RowFormat.Borders.LineWidth = 0;
                cell.CellFormat.Borders.Color = System.Drawing.Color.Transparent;
                cell.CellFormat.WrapText = false;
                cell.CellFormat.BottomPadding = 0;
                cell.CellFormat.TopPadding = 0;
                cell.CellFormat.LeftPadding = 0;
                cell.CellFormat.RightPadding = 0;


                builder.MoveToDocumentEnd();


                try { template.Range.Bookmarks["club_name"].Text = membre.club_name; }
                catch { }
                try { template.Range.Bookmarks["name"].Text = membre.name + " " + membre.surname; }
                catch { }
                try { template.Range.Bookmarks["cric"].Text = "" + membre.cric; }
                catch { }
                try { template.Range.Bookmarks["nim"].Text = "" + membre.nim; }
                catch { }
                try {
                    if(membre.year_membership_rotary==null)
                        template.Range.Bookmarks["ay"].Text = "";
                    else
                    { 
                        DateTime d = (DateTime)membre.year_membership_rotary;
                        template.Range.Bookmarks["ay"].Text = ""+d.Year;
                    }
                }
                catch { }
                try { template.Range.Bookmarks["district"].Text = "" + Const.DISTRICT_ID; }
                catch { }

                string function = "Member";

                foreach (Affectation affectation in affectations)
                    if (affectation.name == membre.name + " " + membre.surname)
                    {
                        function = affectation.function;
                        break;
                    }

                try
                {
                    template.Range.Bookmarks["function"].Text = function;
                }
                catch { }

                try { template.Range.Bookmarks["ry"].Text = validite; }
                catch { }
                //String s = "";
                //foreach(Bookmark b in template.Range.Bookmarks)
                //{
                //    s += b.Name + " " + b.Text + " / ";
                //}
                //throw new Exception(s);



                Aspose.BarCode.BarCodeBuilder bcb = new BarCodeBuilder();
                bcb.SymbologyType = Aspose.BarCode.Symbology.QR;
                //bcb.CodeText = "http://rodi1730.aisdev.net";
                bcb.CodeText = "BEGIN:VCARD" + Environment.NewLine + "VERSION:4.0" + Environment.NewLine + "KIND:individual" + Environment.NewLine + "FN:" + membre.name + " " + membre.surname + Environment.NewLine + "TEL:" + membre.telephone + Environment.NewLine + Environment.NewLine + "EMAIL;PREF=1:" + membre.email + Environment.NewLine + "ORG:" + membre.club_name + Environment.NewLine + "END:VCARD";
                bcb.QREncodeMode = QREncodeMode.Auto;
                bcb.CodeLocation = CodeLocation.None;
                bcb.AutoSize = true;
                bcb.ImageWidth = 20;
                bcb.ImageHeight = 20;
                bcb.ImageQuality = ImageQualityMode.Default;
                try
                {
                    NodeCollection Shapes = template.Document.GetChildNodes(NodeType.DrawingML, true);
                    foreach (Node n in Shapes)
                    {
                        Aspose.Words.Drawing.DrawingML shape = (Aspose.Words.Drawing.DrawingML)n;
                        if (shape.AlternativeText == "qrcode")
                        {
                            shape.ImageData.SetImage(bcb.GenerateBarCodeImage());
                            shape.Width = ConvertUtil.MillimeterToPoint(16);
                            shape.Height = ConvertUtil.MillimeterToPoint(16);
                        }
                    }

                }
                catch (Exception ee) { Functions.Error(ee); }

                Node node = InsertDocument(cell.AppendChild(new Paragraph(doc)), template);


                row.AppendChild(cell);
                col++;

            }
            rows.Add(row);

            builder.MoveToDocumentEnd();
            Aspose.Words.Tables.Table table = builder.StartTable();
            foreach (Aspose.Words.Tables.Row r in rows)
                table.AppendChild(r);
            builder.EndTable();




            MemoryStream ms = new MemoryStream();
            switch (typemime)
            {
                case "application/msword":
                    doc.RemoveMacros();
                    doc.Save(ms, Aspose.Words.SaveFormat.Doc);
                    break;
                case "application/vnd.openxmlformats-officedocument.wordprocessingml.document":
                    doc.RemoveMacros();
                    doc.Save(ms, Aspose.Words.SaveFormat.Docx);
                    break;
                case "application/pdf":
                    doc.Save(ms, Aspose.Words.SaveFormat.Pdf);
                    break;
            }

            Media media = new Media();
            media.content = ms.ToArray();
            media.content_size = media.content.Length;
            media.dt = DateTime.Now;
            media.name = name;
            media.content_type = typemime;
            return media;
        }

        /// <summary>
        /// Create a PDF document of a club order
        /// </summary>
        /// <param name="file_word_modele"></param>
        /// <param name="commande"></param>
        /// <param name="reglement"></param>
        /// <param name="club"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Media ProductionDocumentOrderPdf(string word_file_model, Order order, Payment payment, Club club, string name)
        {
            string validite = "" + Functions.GetRotaryYear() + " - " + (Functions.GetRotaryYear() + 1);

            string chemin = PortalSettings.Current.HomeDirectory;
            chemin += word_file_model;
            chemin = HttpContextSource.Current.Server.MapPath(chemin);

            InitLicenceAsposeWords();


            Aspose.Words.Document doc = new Aspose.Words.Document(chemin);

            Aspose.Words.DocumentBuilder builder = new Aspose.Words.DocumentBuilder(doc);


            //List<Aspose.Words.Tables.Row> rows = new List<Aspose.Words.Tables.Row>();
            //Aspose.Words.Tables.Row row = new Aspose.Words.Tables.Row(doc);
            //row.RowFormat.Height = ConvertUtil.MillimeterToPoint(54);
            int col = 0;

            try { doc.Range.Bookmarks["adress_club"].Text = club.GetPostalAdress(); }
            catch { }
            try { doc.Range.Bookmarks["id"].Text = "" + order.id; }
            catch { }
            try { doc.Range.Bookmarks["dt"].Text = order.dt.ToString("dd/MM/yyyy"); }
            catch { }
            try { doc.Range.Bookmarks["amount"].Text = "" + order.amount; }
            catch { }
            try { doc.Range.Bookmarks["rule"].Text = Functions.YESNO2UF(order.rule) + (order.rule_type != "" ? "(" + order.rule_type + ")" : ""); }
            catch { }
            try { doc.Range.Bookmarks["dt_rule"].Text = order.rule_dt == Const.NO_DATE ? "..." : order.rule_dt.ToShortDateString(); }
            catch { }
            try { doc.Range.Bookmarks["par_rule"].Text = "" + order.rule_par; }
            catch { }
            try { doc.Range.Bookmarks["title"].Text = payment.title; }
            catch { }
            try { doc.Range.Bookmarks["nb"].Text = "" + order.Details.Count; }
            catch { }

            List<string> d = new List<string>();
            int splitnb = (order.Details.Count + 1) / 2;
            for (int i = 0; i < order.Details.Count; i++)
            {
                if (i < splitnb)
                    d.Add(order.Details[i].wording);
                else
                    d[i - splitnb] += "\t" + order.Details[i].wording;

            }

            string dd = "";
            foreach (string l in d)
                dd += l + Environment.NewLine;
            if (dd.EndsWith(Environment.NewLine))
                dd = dd.Substring(0, dd.Length - Environment.NewLine.Length);
            try { doc.Range.Bookmarks["detail"].Text = dd; }
            catch { }


            //Aspose.Words.Tables.Table table = builder.StartTable();
            //foreach (Aspose.Words.Tables.Row r in rows)
            //    table.AppendChild(r);
            //builder.EndTable();



            //doc.Save(@"c:\users\polo\desktop\test.docx");


            MemoryStream ms = new MemoryStream();
            doc.Save(ms, Aspose.Words.SaveFormat.Pdf);

            Media media = new Media();
            media.content = ms.ToArray();
            media.content_size = media.content.Length;
            media.dt = DateTime.Now;
            media.name = name;
            media.content_type = "application/pdf";
            return media;
        }

        /// <summary>
        /// </summary>
        /// <param name="insertAfterNode"></param>
        /// <param name="srcDoc"></param>
        /// <returns></returns>
        public static Node InsertDocument(Node insertAfterNode, Aspose.Words.Document srcDoc)
        {


            try
            {

                // Make sure that the node is either a pargraph or table.

                if ((!insertAfterNode.NodeType.Equals(NodeType.Paragraph)) &

                  (!insertAfterNode.NodeType.Equals(NodeType.Table)))

                    throw new ArgumentException("La recipientination doit etre un paragraphe ou une table.");


                // We will be inserting into the parent of the recipientination paragraph.

                CompositeNode dstStory = insertAfterNode.ParentNode;

                // bool firstLine = true;

                // This object will be translating styles and lists during the import.

                NodeImporter importer = new NodeImporter(srcDoc, insertAfterNode.Document, ImportFormatMode.KeepSourceFormatting);

                // Loop through all sections in the source document.


                foreach (Aspose.Words.Section srcSection in srcDoc.Sections)
                {
                    // Loop through all block level nodes (paragraphs and tables) in the body of the section.
                    foreach (Node srcNode in srcSection.Body)
                    {
                        // Let's skip the node if it is a last empty paragarph in a section.

                        if (srcNode.NodeType.Equals(NodeType.Paragraph))
                        {
                            Aspose.Words.Paragraph para = (Aspose.Words.Paragraph)srcNode;
                            if (para.IsEndOfSection && !para.HasChildNodes)
                                continue;
                        }



                        // This creates a clone of the node, suitable for insertion into the recipientination document.
                        Node newNode = importer.ImportNode(srcNode, true);

                        if (newNode.NodeType.Equals(NodeType.Table))
                        {
                            foreach (Aspose.Words.Tables.Row row in ((Aspose.Words.Tables.Table)newNode))
                            {
                                foreach (Node no in row.ChildNodes)
                                {

                                    foreach (Node noc in ((Aspose.Words.Tables.Cell)no).ChildNodes)
                                        if (noc.NodeType.Equals(NodeType.Paragraph))
                                        {
                                            ((Aspose.Words.Paragraph)noc).ParagraphFormat.SpaceAfter = 0 + ((Aspose.Words.Paragraph)noc).ParagraphFormat.SpaceAfter;
                                            ((Aspose.Words.Paragraph)noc).ParagraphFormat.SpaceBefore = 0 + ((Aspose.Words.Paragraph)noc).ParagraphFormat.SpaceBefore;
                                        }

                                }
                            }
                        }
                        if (newNode.NodeType.Equals(NodeType.Paragraph))
                        {
                            ((Aspose.Words.Paragraph)newNode).ParagraphFormat.SpaceAfter = 0 + ((Aspose.Words.Paragraph)newNode).ParagraphFormat.SpaceAfter;
                            ((Aspose.Words.Paragraph)newNode).ParagraphFormat.SpaceBefore = 0 + ((Aspose.Words.Paragraph)newNode).ParagraphFormat.SpaceBefore;

                        }


                        dstStory.InsertAfter(newNode, insertAfterNode);

                        insertAfterNode = newNode;


                    }

                }

            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            return insertAfterNode;
        }
        #endregion Documents

        #region Content

        /// <summary>
        /// Get a content
        /// </summary>
        /// <param name="id_user">User ID</param>
        /// <returns></returns>
        public static Content GetContent(int id_user)
        {
            Content content = new Content();
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                DataSet ds = new DataSet();

                conn.Open();

                SqlCommand sql = new SqlCommand("SELECT * FROM " + Const.TABLE_PREFIX + "content WHERE id_user = @id_user", conn);
                sql.Parameters.AddWithValue("id_user", id_user);

                SqlDataAdapter da = new SqlDataAdapter(sql);
                da.Fill(ds);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DataRow rd = ds.Tables[0].Rows[0];

                    if (rd["dt"] != DBNull.Value && (DateTime?)rd["dt"] != DateTime.MinValue)
                    {
                        content.dt = (DateTime?)rd["dt"];
                    }
                    else
                    {
                        content.dt = null;
                    }

                    content.file = "" + rd["file"];
                    content.textFile = "" + rd["textFile"];
                    content.id = (int)rd["id"];
                    content.id_user = (int)rd["id_user"];
                    content.photo = "" + rd["photo"];
                    content.text = "" + rd["text"];
                    content.title = "" + rd["title"];
                    content.announcementType = "" + rd["announcementType"];
                    content.type = "" + rd["type"];
                    content.url = "" + rd["URL"];
                    content.published = "" + rd["published"];
                    content.company = "" + rd["company"];
                    content.mode = "" + rd["mode"];
                }
                else
                {
                    content = null;
                }
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return content;
        }

        /// <summary>
        /// Get a content on the Page Pro
        /// </summary>
        /// <param name="id_user"></param>
        /// <returns></returns>
        public static Content GetContentPagePro(int id_user)
        {
            Content content = new Content();
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                DataSet ds = new DataSet();

                conn.Open();

                SqlCommand sql = new SqlCommand("SELECT * FROM " + Const.TABLE_PREFIX + "content WHERE id_user = @id_user and type = 'PagePro'", conn);
                sql.Parameters.AddWithValue("id_user", id_user);

                SqlDataAdapter da = new SqlDataAdapter(sql);
                da.Fill(ds);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DataRow rd = ds.Tables[0].Rows[0];

                    if (rd["dt"] != DBNull.Value && (DateTime?)rd["dt"] != DateTime.MinValue)
                    {
                        content.dt = (DateTime?)rd["dt"];
                    }
                    else
                    {
                        content.dt = null;
                    }

                    content.file = "" + rd["file"];
                    content.textFile = "" + rd["textFile"];
                    content.id = (int)rd["id"];
                    content.id_user = (int)rd["id_user"];
                    content.photo = "" + rd["photo"];
                    content.text = "" + rd["text"];
                    content.title = "" + rd["title"];
                    content.announcementType = "" + rd["announcementType"];
                    content.type = "" + rd["type"];
                    content.url = "" + rd["URL"];
                    content.published = "" + rd["published"];
                    content.company = "" + rd["company"];
                    content.mode = "" + rd["mode"];
                }
                else
                {
                    content = null;
                }
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return content;
        }

        /// <summary>
        /// Get a content thanks to its id
        /// </summary>
        /// <param name="id">Content ID</param>
        /// <returns></returns>
        public static Content GetContent_by_ID(int id)
        {
            Content content = new Content();
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                DataSet ds = new DataSet();

                conn.Open();

                SqlCommand sql = new SqlCommand("SELECT * FROM " + Const.TABLE_PREFIX + "content WHERE id = @id", conn);
                sql.Parameters.AddWithValue("id", id);

                SqlDataAdapter da = new SqlDataAdapter(sql);
                da.Fill(ds);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DataRow rd = ds.Tables[0].Rows[0];

                    if (rd["dt"] != DBNull.Value && (DateTime?)rd["dt"] != DateTime.MinValue)
                    {
                        content.dt = (DateTime?)rd["dt"];
                    }
                    else
                    {
                        content.dt = null;
                    }

                    content.file = "" + rd["file"];
                    content.textFile = "" + rd["textFile"];
                    content.id = (int)rd["id"];
                    content.id_user = (int)rd["id_user"];
                    content.photo = "" + rd["photo"];
                    content.text = "" + rd["text"];
                    content.title = "" + rd["title"];
                    content.announcementType = "" + rd["announcementType"];
                    content.type = "" + rd["type"];
                    content.url = "" + rd["url"];
                    content.published = "" + rd["published"];
                    content.company = "" + rd["company"];
                    content.mode = "" + rd["mode"];
                }
                else
                {
                    content = null;
                }
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return content;
        }

        /// <summary>
        /// Delete a content
        /// </summary>
        /// <param name="id_content">Content ID</param>
        /// <param name="id_user">User ID</param>
        /// <returns></returns>
        public static int Delete_Content(int id_content, int id_user)
        {
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            SqlTransaction trans = null;
            int nb = 0;

            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand sql = new SqlCommand("DELETE  " + Const.TABLE_PREFIX + "content where [id_user]=@id_user AND [id]=@id", conn, trans);
                sql.Parameters.AddWithValue("id", id_content);
                sql.Parameters.AddWithValue("id_user", id_user);
                nb = sql.ExecuteNonQuery();
                if (nb == 0)
                {
                    throw new Exception("Erreur SUPP content id " + id_content + " de la table content de type pour le user " + id_user);
                }

                trans.Commit();
                return nb;
            }
            catch (Exception ee)
            {
                if (trans != null)
                    try
                    {
                        trans.Rollback();
                    }
                    catch { }
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return nb;
        }

        /// <summary>
        /// Add or edit a content
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static int Insert_Content(Content content)
        {
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            SqlTransaction trans = null;
            int id = 0;
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand sql;

                if (content.id != 0)
                {
                    sql = new SqlCommand("UPDATE " + Const.TABLE_PREFIX + "content SET [id_user]=@id_user,[dt]=@dt,[type]=@type,[title]=@title, company=@company, [announcementType]=@announcementType,[text]=@text,[photo]=@photo,[URL]=@URL,[file]=@file, [textFile] = @textFile, [published]=@published, [mode]=@mode WHERE [id]=@id", conn, trans);
                    sql.Parameters.AddWithValue("id", content.id);
                }
                else
                {
                    sql = new SqlCommand("INSERT INTO " + Const.TABLE_PREFIX + "content ([id_user],[dt],[type],[title], company ,[announcementType],[text],[photo],[URL],[file], [textFile],[published],[mode]) VALUES (@id_user,@dt,@type,@title, @company,@announcementType,@text,@photo,@URL,@file,@textFile,@published,@mode)", conn, trans);
                }

                sql.Parameters.AddWithValue("@id_user", content.id_user);
                sql.Parameters.AddWithValue("@dt", DateTime.Now);
                sql.Parameters.AddWithValue("@type", content.type);
                sql.Parameters.AddWithValue("@mode", content.mode);
                if (!string.IsNullOrEmpty(content.title))
                {
                    sql.Parameters.AddWithValue("@title", content.title);
                }
                else
                {
                    sql.Parameters.AddWithValue("@title", DBNull.Value);
                }

                if (!string.IsNullOrEmpty(content.company))
                {
                    sql.Parameters.AddWithValue("@company", content.company);
                }
                else
                {
                    sql.Parameters.AddWithValue("@company", DBNull.Value);
                }

                if (!string.IsNullOrEmpty(content.announcementType))
                {
                    sql.Parameters.AddWithValue("@announcementType", content.announcementType);
                }
                else
                {
                    sql.Parameters.AddWithValue("@announcementType", DBNull.Value);
                }

                if (!string.IsNullOrEmpty(content.text))
                {
                    sql.Parameters.AddWithValue("@text", content.text);
                }
                else
                {
                    sql.Parameters.AddWithValue("@text", DBNull.Value);
                }

                if (!string.IsNullOrEmpty(content.photo))
                {
                    sql.Parameters.AddWithValue("@photo", content.photo);
                }
                else
                {
                    sql.Parameters.AddWithValue("@photo", DBNull.Value);
                }

                if (!string.IsNullOrEmpty(content.url))
                {
                    sql.Parameters.AddWithValue("@URL", content.url);
                }
                else
                {
                    sql.Parameters.AddWithValue("@URL", DBNull.Value);
                }

                if (!string.IsNullOrEmpty(content.file))
                {
                    sql.Parameters.AddWithValue("@file", content.file);
                }
                else
                {
                    sql.Parameters.AddWithValue("@file", DBNull.Value);
                }

                if (!string.IsNullOrEmpty(content.textFile))
                {
                    sql.Parameters.AddWithValue("@textFile", content.textFile);
                }
                else
                {
                    sql.Parameters.AddWithValue("@textFile", DBNull.Value);
                }

                if (!string.IsNullOrEmpty(content.published))
                {
                    sql.Parameters.AddWithValue("@published", content.published);
                }
                else
                {
                    sql.Parameters.AddWithValue("@published", DBNull.Value);
                }

                if (sql.ExecuteNonQuery() == 0)
                {
                    throw new Exception("Erreur MAJ table content de type " + content.type + " pour le user " + content.id_user);
                }
                else if (content.id < 1)
                {
                    sql = new SqlCommand("SELECT @@IDENTITY", conn, trans);
                    id = int.Parse("" + sql.ExecuteScalar());
                }
                else
                {
                    id = content.id;
                }

                trans.Commit();
                return id;

            }
            catch (Exception ee)
            {
                if (trans != null)
                    try
                    {
                        trans.Rollback();
                    }
                    catch { }
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return id;
        }

        /// <summary>
        /// Get a list of contents
        /// </summary>
        /// <param name="id_user">User ID</param>
        /// <param name="type">Content type</param>
        /// <returns></returns>
        public static List<Content> GetListContent(int id_user, string type)
        {
            List<Content> contents = new List<Content>();
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                DataSet ds = new DataSet();

                conn.Open();

                SqlCommand sql = new SqlCommand("SELECT * FROM " + Const.TABLE_PREFIX + "content WHERE id_user = @id_user and type = @type ORDER BY dt DESC", conn);
                sql.Parameters.AddWithValue("id_user", id_user);
                sql.Parameters.AddWithValue("type", type);

                SqlDataAdapter da = new SqlDataAdapter(sql);
                da.Fill(ds);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow rd in ds.Tables[0].Rows)
                    {
                        Content content = new Content();
                        if (rd["dt"] != DBNull.Value && (DateTime?)rd["dt"] != DateTime.MinValue)
                        {
                            content.dt = (DateTime?)rd["dt"];
                        }
                        else
                        {
                            content.dt = null;
                        }

                        content.file = "" + rd["file"];
                        content.textFile = "" + rd["textFile"];
                        content.id = (int)rd["id"];
                        content.id_user = (int)rd["id_user"];
                        content.photo = "" + rd["photo"];
                        content.text = "" + rd["text"];
                        content.title = "" + rd["title"];
                        content.announcementType = "" + rd["announcementType"];
                        content.type = "" + rd["type"];
                        content.url = "" + rd["url"];
                        content.published = "" + rd["published"];
                        content.company = "" + rd["company"];

                        contents.Add(content);
                    }
                }
                else
                {
                    contents = null;
                }
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return contents;
        }

        /// <summary>
        /// Get a list a nb contents
        /// </summary>
        /// <param name="type"></param>
        /// <param name="nb"></param>
        /// <returns></returns>
        public static List<Content> GetListContentHOMEPAGE(string type, int nb)
        {
            List<Content> contents = new List<Content>();
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                DataSet ds = new DataSet();

                conn.Open();
                //SqlCommand sql = new SqlCommand("SELECT TOP " + nb + " C.* FROM ais_content C WHERE published='o' AND type=@type AND id IN (select id from ais_subscription where type=@type and active ='o' and dt_end >= @dt_end)", conn);

                SqlCommand sql = new SqlCommand("SELECT TOP " + nb + "  C.* FROM " + Const.TABLE_PREFIX + "content C WHERE published='o' AND type=@type AND id IN (select id_content from " + Const.TABLE_PREFIX + "subscription where type=@type and active ='o' and dt_end >= @dt_end) Order by C.dt DESC", conn);


                //SqlCommand sql = new SqlCommand("SELECT TOP 2 C.* FROM " + Const.TABLE_PREFIX + "content as C, " + Const.TABLE_PREFIX + "subscription AS A WHERE C.type = @type AND C.published = 'o' AND A.id_content = C.id and A.type = @type and A.dt_end >= @dt_end and A.active = 'o' Order by C.dt DESC", conn);
                sql.Parameters.AddWithValue("type", type);
                sql.Parameters.AddWithValue("dt_end", DateTime.Now);

                SqlDataAdapter da = new SqlDataAdapter(sql);
                da.Fill(ds);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow rd in ds.Tables[0].Rows)
                    {
                        Content content = new Content();
                        if (rd["dt"] != DBNull.Value && (DateTime?)rd["dt"] != DateTime.MinValue)
                        {
                            content.dt = (DateTime?)rd["dt"];
                        }
                        else
                        {
                            content.dt = null;
                        }

                        content.file = "" + rd["file"];
                        content.textFile = "" + rd["textFile"];
                        content.id = (int)rd["id"];
                        content.id_user = (int)rd["id_user"];
                        content.photo = "" + rd["photo"];
                        content.text = "" + rd["text"];
                        content.title = "" + rd["title"];
                        content.announcementType = "" + rd["announcementType"];
                        content.type = "" + rd["type"];
                        content.url = "" + rd["url"];
                        content.published = "" + rd["published"];
                        content.company = "" + rd["company"];
                        content.mode = "" + rd["mode"];

                        contents.Add(content);
                    }
                }
                else
                {
                    contents = null;
                }
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return contents;
        }

        /// <summary>
        /// Get a list of contents for a specified announcement type
        /// </summary>
        /// <param name="type"></param>
        /// <param name="announcementType"></param>
        /// <returns></returns>
        public static List<Content> GetListContentHOMEPAGE(string type, string announcementType)
        {
            List<Content> contents = new List<Content>();
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                DataSet ds = new DataSet();

                conn.Open();

                //SqlCommand sql = new SqlCommand("SELECT C.* FROM " + Const.TABLE_PREFIX + "content as C, " + Const.TABLE_PREFIX + "subscription AS A WHERE C.type = @type AND C.announcementType = @announcementType AND C.published = 'o' AND A.id_content = C.id and A.type = @type and A.dt_end >= @dt_end and A.active = 'o' Order by C.dt DESC", conn);

                SqlCommand sql;
                if (string.IsNullOrEmpty(announcementType))
                {
                    sql = new SqlCommand("SELECT C.* FROM " + Const.TABLE_PREFIX + "content C WHERE published='o' AND type=@type AND id IN (select id_content from " + Const.TABLE_PREFIX + "subscription where type=@type and active ='o' and dt_end >= @dt_end) Order by C.dt DESC", conn);
                }
                else
                {
                    sql = new SqlCommand("SELECT C.* FROM " + Const.TABLE_PREFIX + "content C WHERE published='o' AND type=@type AND announcementType = @announcementType AND id IN (select id_content from " + Const.TABLE_PREFIX + "subscription where type=@type and active ='o' and dt_end >= @dt_end) Order by C.dt DESC", conn);
                    sql.Parameters.AddWithValue("announcementType", announcementType);
                }
                sql.Parameters.AddWithValue("type", type);
                sql.Parameters.AddWithValue("dt_end", DateTime.Now);


                SqlDataAdapter da = new SqlDataAdapter(sql);
                da.Fill(ds);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow rd in ds.Tables[0].Rows)
                    {
                        Content content = new Content();
                        if (rd["dt"] != DBNull.Value && (DateTime?)rd["dt"] != DateTime.MinValue)
                        {
                            content.dt = (DateTime?)rd["dt"];
                        }
                        else
                        {
                            content.dt = null;
                        }

                        content.file = "" + rd["file"];
                        content.textFile = "" + rd["textFile"];
                        content.id = (int)rd["id"];
                        content.id_user = (int)rd["id_user"];
                        content.photo = "" + rd["photo"];
                        content.text = "" + rd["text"];
                        content.title = "" + rd["title"];
                        content.announcementType = "" + rd["announcementType"];
                        content.type = "" + rd["type"];
                        content.url = "" + rd["url"];
                        content.published = "" + rd["published"];
                        content.company = "" + rd["company"];

                        contents.Add(content);
                    }
                }
                else
                {
                    contents = null;
                }
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return contents;
        }

        /// <summary>
        /// Edit the published attribute of a content
        /// </summary>
        /// <param name="published"></param>
        /// <param name="id_content">Content ID</param>
        /// <returns></returns>
        public static bool Update_Publish(string published, int id_content)
        {
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            SqlTransaction trans = null;
            bool ok = false;
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand sql;

                if (id_content != 0)
                {
                    sql = new SqlCommand("UPDATE " + Const.TABLE_PREFIX + "content SET [published]=@published WHERE [id]=@id", conn, trans);
                    sql.Parameters.AddWithValue("id", id_content);
                    sql.Parameters.AddWithValue("published", published);

                    if (sql.ExecuteNonQuery() == 0)
                    {
                        throw new Exception("Erreur MAJ table content lors de la MAJ de publication");
                    }
                    else
                    {
                        ok = true;
                    }
                }

                trans.Commit();
            }
            catch (Exception ee)
            {
                if (trans != null)
                    try
                    {
                        trans.Rollback();
                    }
                    catch { }
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return ok;
        }
        #endregion content

        #region Subscription

        /// <summary>
        /// Check if a user is subscribed
        /// </summary>
        /// <param name="id_user">User ID</param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool Sub_Active(int id_user, string type)
        {
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                DataSet ds = new DataSet();

                conn.Open();
                //On tente de sélectionner l'subscription dans la table
                SqlCommand sql = new SqlCommand("SELECT * FROM " + Const.TABLE_PREFIX + "subscription WHERE id_user = @id_user and type = @type and dt_end >= @dt_end and active = 'o'", conn);
                sql.Parameters.AddWithValue("id_user", id_user);
                sql.Parameters.AddWithValue("type", type);
                sql.Parameters.AddWithValue("dt_end", DateTime.Now);

                SqlDataAdapter da = new SqlDataAdapter(sql);
                da.Fill(ds);

                //S'il existe on retourne vrai
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                else
                {//Sinon faux
                    return false;
                }
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Check if a content is subscribed
        /// </summary>
        /// <param name="id_content">Content ID</param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool Sub_Active_by_id_content(int id_content, string type)
        {
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                DataSet ds = new DataSet();

                conn.Open();

                SqlCommand sql = new SqlCommand("SELECT * FROM " + Const.TABLE_PREFIX + "subscription WHERE id_content = @id_content and type = @type and dt_end >= @dt_end and active = 'o'", conn);
                sql.Parameters.AddWithValue("id_content", id_content);
                sql.Parameters.AddWithValue("type", type);
                sql.Parameters.AddWithValue("dt_end", DateTime.Now);

                SqlDataAdapter da = new SqlDataAdapter(sql);
                da.Fill(ds);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Get a list of subscriptions using user ID
        /// </summary>
        /// <param name="id_user">User ID</param>
        /// <param name="type"></param>
        /// <param name="withContent"></param>
        /// <returns></returns>
        public static List<Subscription> GetListSubscription_by_userID(int id_user, string type, bool withContent = false)
        {
            List<Subscription> subscriptions = null;
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                conn.Open();
                SqlCommand sql = new SqlCommand("SELECT * FROM " + Const.TABLE_PREFIX + "subscription WHERE id_user=@id_user and type = @type", conn);
                sql.Parameters.AddWithValue("id_user", id_user);
                sql.Parameters.AddWithValue("type", type);
                SqlDataAdapter da = new SqlDataAdapter(sql);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow rd in ds.Tables[0].Rows)
                    {
                        Subscription abo = new Subscription();

                        if (rd["id"] != DBNull.Value) abo.id = (int)rd["id"];
                        if (rd["id_user"] != DBNull.Value) abo.id_user = (int)rd["id_user"];
                        if (rd["id_order"] != DBNull.Value)
                        {
                            abo.id_order = "" + rd["id_order"];
                            //abo.commande = GetOrderByGuid(abo.id_order);
                        }
                        if (rd["id_content"] != DBNull.Value) abo.id_content = (int)rd["id_content"];

                        if (abo.id_content != null && abo.id_content > 0 && withContent == true)
                        {
                            abo.content = GetContent_by_ID(abo.id_content);
                        }

                        abo.type = "" + rd["type"];
                        if (rd["dt_beginning"] != DBNull.Value && (DateTime)rd["dt_beginning"] != DateTime.MinValue) abo.dt_beginning = (DateTime)rd["dt_beginning"];
                        if (rd["dt_end"] != DBNull.Value && (DateTime)rd["dt_end"] != DateTime.MinValue) abo.dt_end = (DateTime)rd["dt_end"];
                        abo.active = "" + rd["active"];
                        if (rd["amount"] != DBNull.Value) abo.amount = (double)rd["amount"];

                        subscriptions.Add(abo);
                    }
                }
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return subscriptions;
        }

        /// <summary>
        /// Get a list of subscriptions using content ID
        /// </summary>
        /// <param name="id_content">Content ID</param>
        /// <param name="type"></param>
        /// <param name="withContent"></param>
        /// <returns></returns>
        public static List<Subscription> GetListSubscription_by_ID_Content(int id_content, string type, bool withContent = false)
        {
            List<Subscription> subscriptions = null;
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                conn.Open();
                SqlCommand sql = new SqlCommand("SELECT * FROM " + Const.TABLE_PREFIX + "subscription WHERE id_content=@id_content and type = @type ORDER BY dt_end DESC", conn);
                sql.Parameters.AddWithValue("id_content", id_content);
                sql.Parameters.AddWithValue("type", type);
                SqlDataAdapter da = new SqlDataAdapter(sql);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    subscriptions = new List<Subscription>();
                    foreach (DataRow rd in ds.Tables[0].Rows)
                    {
                        Subscription abo = new Subscription();

                        if (rd["id"] != DBNull.Value) abo.id = (int)rd["id"];
                        if (rd["id_user"] != DBNull.Value) abo.id_user = (int)rd["id_user"];
                        if (rd["id_order"] != DBNull.Value)
                        {
                            abo.id_order = "" + rd["id_order"];
                            //abo.commande = GetOrderByGuid(abo.id_order);
                        }
                        if (rd["id_content"] != DBNull.Value) abo.id_content = (int)rd["id_content"];

                        if (abo.id_content != null && abo.id_content > 0 && withContent == true)
                        {
                            abo.content = GetContent_by_ID(abo.id_content);
                        }

                        abo.type = "" + rd["type"];
                        if (rd["dt_beginning"] != DBNull.Value && (DateTime)rd["dt_beginning"] != DateTime.MinValue) abo.dt_beginning = (DateTime)rd["dt_beginning"];
                        if (rd["dt_end"] != DBNull.Value && (DateTime)rd["dt_end"] != DateTime.MinValue) abo.dt_end = (DateTime)rd["dt_end"];
                        abo.active = "" + rd["active"];
                        if (rd["amount"] != DBNull.Value) abo.amount = (double)rd["amount"];

                        subscriptions.Add(abo);
                    }
                }
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return subscriptions;
        }

        /// <summary>
        /// Get a list of subscriptions
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static List<Subscription> GetListSubscriptions(string query)
        {
            List<Subscription> subscriptions = null;
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                conn.Open();
                SqlCommand sql;
                if (!string.IsNullOrEmpty(query))
                {
                    sql = new SqlCommand("SELECT * FROM " + Const.TABLE_PREFIX + "subscription WHERE " + query + " ORDER BY dt_end DESC", conn);
                }
                else
                {
                    sql = new SqlCommand("SELECT * FROM " + Const.TABLE_PREFIX + "subscription ORDER BY dt_end DESC", conn);
                }

                SqlDataAdapter da = new SqlDataAdapter(sql);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    subscriptions = new List<Subscription>();
                    foreach (DataRow rd in ds.Tables[0].Rows)
                    {
                        Subscription abo = new Subscription();

                        if (rd["id"] != DBNull.Value) abo.id = (int)rd["id"];
                        if (rd["id_user"] != DBNull.Value)
                        {
                            abo.id_user = (int)rd["id_user"];
                            abo.member = GetMemberByUserID(abo.id_user);
                        }


                        if (rd["id_order"] != DBNull.Value)
                        {
                            abo.id_order = "" + rd["id_order"];
                            //abo.commande = GetOrderByGuid(abo.id_order);
                        }
                        if (rd["id_content"] != DBNull.Value) abo.id_content = (int)rd["id_content"];


                        abo.type = "" + rd["type"];
                        if (rd["dt_beginning"] != DBNull.Value && (DateTime)rd["dt_beginning"] != DateTime.MinValue) abo.dt_beginning = (DateTime)rd["dt_beginning"];
                        if (rd["dt_end"] != DBNull.Value && (DateTime)rd["dt_end"] != DateTime.MinValue) abo.dt_end = (DateTime)rd["dt_end"];
                        abo.active = "" + rd["active"];
                        if (rd["amount"] != DBNull.Value) abo.amount = (double)rd["amount"];

                        subscriptions.Add(abo);
                    }
                }
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return subscriptions;
        }

        /// <summary>
        /// Get a list of active presentations
        /// </summary>
        /// <returns></returns>
        public static List<int> Get_List_Presentation_Active()
        {
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            List<int> lesID_users = null;
            try
            {
                DataSet ds = new DataSet();

                conn.Open();

                SqlCommand sql = new SqlCommand("SELECT DISTINCT id_user FROM " + Const.TABLE_PREFIX + "subscription WHERE  type = @type and dt_end >= @dt_end and active = 'o' AND id_content IN (SELECT id FROM " + Const.TABLE_PREFIX + "content WHERE published = 'o')", conn);

                sql.Parameters.AddWithValue("type", "PagePro");
                sql.Parameters.AddWithValue("dt_end", DateTime.Now);

                SqlDataAdapter da = new SqlDataAdapter(sql);
                da.Fill(ds);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    lesID_users = new List<int>();

                    foreach (DataRow rd in ds.Tables[0].Rows)
                    {
                        if (rd["id_user"] != DBNull.Value) lesID_users.Add((int)rd["id_user"]);
                    }
                }
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return lesID_users;
        }

        /// <summary>
        /// Check if the order exists
        /// </summary>
        /// <param name="id_order"></param>
        /// <returns></returns>
        public static bool? IdOrder_Exist(string id_order)
        {
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                DataSet ds = new DataSet();

                conn.Open();

                SqlCommand sql = new SqlCommand("SELECT * FROM " + Const.TABLE_PREFIX + "subscription WHERE id_order = @id_order ", conn);

                sql.Parameters.AddWithValue("@id_order", id_order);

                SqlDataAdapter da = new SqlDataAdapter(sql);
                da.Fill(ds);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Add a subscription
        /// </summary>
        /// <param name="id_user">User ID</param>
        /// <param name="id_order">Order ID</param>
        /// <param name="id_content">Content ID</param>
        /// <param name="type"></param>
        /// <param name="dt_beginning"></param>
        /// <param name="dt_end"></param>
        /// <param name="active"></param>
        /// <param name="amount"</param>
        /// <returns></returns>
        public static bool Insert_Subscription(int id_user, string id_order, int id_content, string type, DateTime dt_beginning, DateTime dt_end, string active, double amount)
        {
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            SqlTransaction trans = null;
            bool ok = false;
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand sql = new SqlCommand("INSERT INTO " + Const.TABLE_PREFIX + "subscription ([id_user],[id_order],[id_content],[type],[dt_beginning],[dt_end],[active], [amount]) VALUES (@id_user,@id_order,@id_content,@type,@dt_beginning,@dt_end,@active, @amount)", conn, trans);
                sql.Parameters.AddWithValue("@id_user", id_user);
                sql.Parameters.AddWithValue("@id_order", id_order);
                sql.Parameters.AddWithValue("@id_content", id_content);
                sql.Parameters.AddWithValue("@type", type);
                sql.Parameters.AddWithValue("@dt_beginning", dt_beginning);
                sql.Parameters.AddWithValue("@dt_end", dt_end);
                sql.Parameters.AddWithValue("@active", active);
                sql.Parameters.AddWithValue("@amount", amount);

                if (sql.ExecuteNonQuery() == 0)
                {
                    throw new Exception("Erreur table Abonnement lors de l'insert");
                }
                else
                {
                    ok = true;
                }


                trans.Commit();
            }
            catch (Exception ee)
            {
                if (trans != null)
                    try
                    {
                        trans.Rollback();
                    }
                    catch { }
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return ok;
        }

        /// <summary>
        /// Edit a subscription
        /// </summary>
        /// <param name="active"></param>
        /// <param name="id">Subscription ID</param>
        /// <returns></returns>
        public static bool Update_Subscription_Actif(string active, int id)
        {
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            SqlTransaction trans = null;
            bool ok = false;
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand sql = new SqlCommand("UPDATE " + Const.TABLE_PREFIX + "subscription SET [active]=@active WHERE [id]=@id ", conn, trans);
                sql.Parameters.AddWithValue("@id", id);
                sql.Parameters.AddWithValue("@active", active);

                if (sql.ExecuteNonQuery() == 0)
                {
                    throw new Exception("Erreur table Abonnement lors de l'update active o/n");
                }
                else
                {
                    ok = true;
                }


                trans.Commit();
            }
            catch (Exception ee)
            {
                if (trans != null)
                    try
                    {
                        trans.Rollback();
                    }
                    catch { }
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return ok;
        }

        #endregion

        #region Actions

        /// <summary>
        /// Add or edit an action
        /// </summary>
        /// <param name="act"></param>
        /// <returns></returns>
        public static bool UpdateActions(Actions act)
        {
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                conn.Open();
                SqlCommand sql;
                if (act.id != 0)
                {
                    sql = new SqlCommand("UPDATE " + Const.TABLE_PREFIX + "actions SET [cric]=@cric,[dt_update]=getdate(),[id_user_update]=@id_user_update,[dt_action]=@dt_action,[name_action]=@name_action,[description]=@description,[id_user_in_charge]=@id_user_in_charge,[goal]=@goal,[id_user_current]=@id_user_current,[material_resources]=@material_resources,[description_phases]=@description_phases,[human_resources]=@human_resources,[remarks]=@remarks,[results]=@results,[geographical_area]=@geographical_area WHERE [id]=@id", conn);
                    sql.Parameters.AddWithValue("id", act.id);
                }
                else
                {
                    sql = new SqlCommand("INSERT INTO " + Const.TABLE_PREFIX + "actions ([cric],[dt_update],[id_user_update],[dt_action],[name_action],[description],[id_user_in_charge],[goal],[id_user_current],[material_resources],[description_phases],[human_resources],[remarks],[results],[geographical_area]) VALUES (@cric,getdate(),@id_user_update,@dt_action,@name_action,@description,@id_user_in_charge,@goal,@id_user_current,@material_resources,@description_phases,@human_resources,@remarks,@results,@geographical_area)", conn);
                }


                sql.Parameters.AddWithValue("@cric", act.cric);
                sql.Parameters.AddWithValue("@id_user_update", act.id_user_update);
                sql.Parameters.AddWithValue("@dt_action", act.dt_action);
                sql.Parameters.AddWithValue("@name_action", "" + act.name_action);
                sql.Parameters.AddWithValue("@description", "" + act.description);
                sql.Parameters.AddWithValue("@id_user_in_charge", act.id_user_in_charge);
                sql.Parameters.AddWithValue("@goal", "" + act.goal);
                sql.Parameters.AddWithValue("@id_user_current", act.id_user_current);
                sql.Parameters.AddWithValue("@material_resources", "" + act.material_resources);
                sql.Parameters.AddWithValue("@description_phases", "" + act.description_phases);
                sql.Parameters.AddWithValue("@human_resources", "" + act.human_resources);
                sql.Parameters.AddWithValue("@remarks", "" + act.remarks);
                sql.Parameters.AddWithValue("@results", "" + act.results);
                sql.Parameters.AddWithValue("@geographical_area", "" + act.geographical_area);

                if (sql.ExecuteNonQuery() == 0)
                    throw new Exception("Erreur mise a day news : " + act.id);
                return true;

            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        /// <summary>
        /// Delete an action
        /// </summary>
        /// <param name="id">Action ID</param>
        /// <returns></returns>
        public static bool DeleteActions(string id)
        {
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                conn.Open();
                SqlCommand sql = new SqlCommand("DELETE " + Const.TABLE_PREFIX + "actions WHERE id=@id", conn);
                sql.Parameters.AddWithValue("@id", id);
                if (sql.ExecuteNonQuery() == 0)
                    throw new Exception("Erreur delete action : " + id);
                return true;

            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        /// <summary>
        /// Get an action using a DataRow
        /// </summary>
        /// <param name="rd"></param>
        /// <param name="clubs">Club list containing the action</param>
        /// <returns></returns>
        static Actions GetActionByRD(DataRow rd, List<Club> clubs)
        {
            Actions obj = new Actions();
            if (rd["id"] != DBNull.Value) obj.id = (int)rd["id"];
            if (rd["cric"] != DBNull.Value) obj.cric = (int)rd["cric"];
            if (rd["dt_update"] != DBNull.Value) obj.dt_update = (DateTime)rd["dt_update"];
            if (rd["id_user_update"] != DBNull.Value) obj.id_user_update = (int)rd["id_user_update"];
            if (rd["dt_action"] != DBNull.Value) obj.dt_action = (DateTime)rd["dt_action"];
            obj.name_action = "" + rd["name_action"];
            obj.description = "" + rd["description"];
            if (rd["id_user_in_charge"] != DBNull.Value) obj.id_user_in_charge = (int)rd["id_user_in_charge"];
            obj.goal = "" + rd["goal"];
            if (rd["id_user_current"] != DBNull.Value) obj.id_user_current = (int)rd["id_user_current"];
            obj.material_resources = "" + rd["material_resources"];
            obj.description_phases = "" + rd["description_phases"];
            obj.human_resources = "" + rd["human_resources"];
            obj.remarks = "" + rd["remarks"];
            obj.results = "" + rd["results"];
            obj.geographical_area = "" + rd["geographical_area"];

            if (obj.cric > 0)
            {
                foreach (Club club in clubs)
                    if (club.cric == obj.cric)
                    {
                        obj.club_name = club.name;
                        break;
                    }
            }
            else
            {
                obj.club_name = "";
            }

            obj.name_responsable = "";
            obj.mail_responsable = "";
            obj.mobile_responsable = "";

            if (obj.id_user_in_charge > 0)
            {
                Member m = GetMember(obj.id_user_in_charge);
                if (m != null)
                {
                    obj.name_responsable = "" + m.surname + " " + m.name;
                    obj.mail_responsable = "" + m.email;
                    obj.mobile_responsable = "" + m.professionnal_mobile;
                }
            }

            obj.name_current = "";
            obj.mail_current = "";
            obj.mobile_current = "";

            if (obj.id_user_current > 0)
            {
                Member m = GetMember(obj.id_user_current);
                if (m != null)
                {
                    obj.name_current = "" + m.surname + " " + m.name;
                    obj.mail_current = "" + m.email;
                    obj.mobile_current = "" + m.professionnal_mobile;
                }
            }

            return obj;
        }

        /// <summary>
        /// Get an action using its ID
        /// </summary>
        /// <param name="newsid">Action ID</param>
        /// <returns></returns>
        public static Actions GetActions(string newsid)
        {
            List<Club> clubs = ListClubs(sort: "cric asc");
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                string query = "SELECT * FROM " + Const.TABLE_PREFIX + "actions WHERE id=@id";
                conn.Open();
                DataSet ds = new DataSet();
                SqlCommand sql = new SqlCommand(query, conn);
                sql.Parameters.AddWithValue("id", newsid);
                SqlDataAdapter da = new SqlDataAdapter(sql);
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                    return GetActionByRD(ds.Tables[0].Rows[0], clubs);
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }

            return null;
        }

        //public static List<Action> ListNews(int cric = 0, string category = "", string tags_inclus = "", string tags_exclus = "", string top = "", string sort= "dt DESC", int index = 0, int max = 100, bool onlyvisible = false)

        /// <summary>
        /// Get a list of actions
        /// </summary>
        /// <param name="cric">Club cric</param>
        /// <param name="top"></param>
        /// <param name="tri"></param>
        /// <param name="index"></param>
        /// <param name="max"></param>
        /// <returns>List d'actions</returns>
        public static List<Actions> ListActions(int cric = 0, string top = "", string sort = "dt_update DESC", int index = 0, int max = 100)
        {
            List<Club> clubs = ListClubs(sort: "cric asc");
            List<Actions> list = new List<Actions>();
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                DataSet ds = new DataSet();
                string query = "SELECT " + top + " * FROM " + Const.TABLE_PREFIX + "actions " + (sort != "" ? "ORDER BY " + sort : "");

                conn.Open();

                SqlCommand sql = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(sql);
                da.Fill(ds);

                int i = 0;
                int c = 0;
                foreach (DataRow rd in ds.Tables[0].Rows)
                {
                    if (i >= (index * max) && c < max)
                    {
                        list.Add(GetActionByRD(rd, clubs));
                        c++;
                    }
                    else
                    {
                        list.Add(new Actions());
                    }
                    i++;
                }
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }

            return list;
        }
        #endregion Actions

        #region Attendance


        /// <summary>
        /// Add an attendance
        /// </summary>
        /// <param name="att"></param>
        /// <returns></returns>
        public static int Insert_Attendance(Attendance att)
        {
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            SqlTransaction trans = null;
            int id = 0;
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand sql;

                //On crée la requête SQL qui insère la ou les attendances voulues
                if (att.id != 0)
                {
                    sql = new SqlCommand("UPDATE " + Const.TABLE_PREFIX + "attendance SET [cric]=@cric,[year]=@year,[month]=@month,[day]=@day,[nbm]=@nbm,[nbp]=@nbp,[nbc]=@nbc,[nbe]=@nbe,[nbd]=@nbd,[nbdp]=@nbdp,[nim]=@nim,[name_surname]=@name_surname,[dt_input]=@dt_input,[dt_edit]=@dt_edit WHERE [id]=@id", conn, trans);
                    sql.Parameters.AddWithValue("id", att.id);
                }
                else
                {
                    sql = new SqlCommand("INSERT INTO " + Const.TABLE_PREFIX + "attendance ([cric],[year],[month],[day],[nbm],[nbp],[nbc],[nbe],[nbd], [nbdp],[nim],[name_surname],[dt_input],[dt_edit]) VALUES (@cric,@year,@month,@day,@nbm,@nbp,@nbc,@nbe,@nbd,@nbdp,@nim,@name_surname,@dt_input,@dt_edit)", conn, trans);
                }

                //On attocié chaque colonne à un paramètre de la clatte attendance
                sql.Parameters.AddWithValue("@cric", att.cric);
                sql.Parameters.AddWithValue("@year", att.year);
                sql.Parameters.AddWithValue("@month", att.month);
                sql.Parameters.AddWithValue("@day", att.day);
                sql.Parameters.AddWithValue("@nbm", att.nbm);
                sql.Parameters.AddWithValue("@nbp", att.nbp);
                sql.Parameters.AddWithValue("@nbc", att.nbc);
                sql.Parameters.AddWithValue("@nbe", 0);// att.nbe);
                sql.Parameters.AddWithValue("@nbd", att.nbd);
                sql.Parameters.AddWithValue("@nbdp", att.nbdp);
                sql.Parameters.AddWithValue("@nim", att.nim);
                sql.Parameters.AddWithValue("@name_surname", att.name_surname == null ? "" : att.name_surname);

                if (att.dt_input != null && att.dt_input > DateTime.MinValue && att.dt_input < DateTime.MaxValue)
                {
                    sql.Parameters.AddWithValue("@dt_input", att.dt_input);
                }
                else
                {
                    sql.Parameters.AddWithValue("@dt_input", DBNull.Value);
                }

                if (att.dt_edit != null && att.dt_edit > DateTime.MinValue && att.dt_edit < DateTime.MaxValue)
                {
                    sql.Parameters.AddWithValue("@dt_edit", att.dt_edit);
                }
                else
                {
                    sql.Parameters.AddWithValue("@dt_edit", DBNull.Value);
                }



                if (sql.ExecuteNonQuery() == 0)
                {
                    throw new Exception("Erreur MAJ table attendance");
                }
                else if (att.id < 1)
                {
                    sql = new SqlCommand("SELECT @@IDENTITY", conn, trans);
                    id = int.Parse("" + sql.ExecuteScalar());
                }
                else
                {
                    id = att.id;
                }

                trans.Commit();
                return id;

            }
            catch (Exception ee)
            {
                if (trans != null)
                    try
                    {
                        trans.Rollback();
                    }
                    catch { }
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return id;
        }

        /// <summary>
        /// Delete an attendance
        /// </summary>
        /// <param name="id_att">Attendance ID</param>
        /// <returns></returns>
        public static int Delete_Attendance(int id_att)
        {
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            SqlTransaction trans = null;
            int nb = 0;

            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                //La requête SQL supprimant l'attiduité déendie en paramètre
                SqlCommand sql = new SqlCommand("DELETE  " + Const.TABLE_PREFIX + "attendance where [id]=@id", conn, trans);
                sql.Parameters.AddWithValue("id", id_att);
                nb = sql.ExecuteNonQuery();
                if (nb == 0)
                {
                    throw new Exception("Erreur SUPP attendance id " + id_att + " de la table attendance ");
                }

                trans.Commit();
                return nb;
            }
            catch (Exception ee)
            {
                if (trans != null)
                    try
                    {
                        trans.Rollback();
                    }
                    catch { }
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return nb;
        }

        /// <summary>
        /// Get a list of attendances
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static List<Attendance> GetListAttendance(string query)
        {
            List<Attendance> attendance = null;
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                conn.Open();
                SqlCommand sql;
                if (!string.IsNullOrEmpty(query))
                {
                    //On crée la requête permettant de récupérer les attendances correspondant aux critères sélectionnés 
                    sql = new SqlCommand("SELECT * FROM " + Const.TABLE_PREFIX + "attendance WHERE " + query + " ORDER BY year DESC", conn);
                }
                else
                {//Cette requête sélectionne toutes les attendances
                    sql = new SqlCommand("SELECT * FROM " + Const.TABLE_PREFIX + "attendance ORDER BY year DESC", conn);
                }

                SqlDataAdapter da = new SqlDataAdapter(sql);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    attendance = new List<Attendance>();
                    foreach (DataRow rd in ds.Tables[0].Rows)
                    {
                        Attendance abo = new Attendance();
                        //On attocie les résultats à chaque attendance qu l'on mettra dans la list
                        if (rd["id"] != DBNull.Value) abo.id = (int)rd["id"];
                        if (rd["cric"] != DBNull.Value) abo.cric = (int)rd["cric"];
                        if (rd["year"] != DBNull.Value) abo.year = (int)rd["year"];
                        if (rd["month"] != DBNull.Value) abo.month = (int)rd["month"];
                        if (rd["day"] != DBNull.Value) abo.day = (int)rd["day"];
                        if (rd["nbm"] != DBNull.Value) abo.nbm = (int)rd["nbm"];
                        if (rd["nbp"] != DBNull.Value) abo.nbp = (int)rd["nbp"];
                        if (rd["nbc"] != DBNull.Value) abo.nbc = (int)rd["nbc"];
                        if (rd["nbe"] != DBNull.Value) abo.nbe = (int)rd["nbe"];
                        if (rd["nbd"] != DBNull.Value) abo.nbd = (int)rd["nbd"];
                        if (rd["nbdp"] != DBNull.Value) abo.nbdp = (int)rd["nbdp"];
                        if (rd["nim"] != DBNull.Value) abo.nim = (int)rd["nim"];
                        abo.name_surname = "" + rd["name_surname"];
                        if (rd["dt_input"] != DBNull.Value) abo.dt_input = (DateTime)rd["dt_input"];
                        if (rd["dt_edit"] != DBNull.Value) abo.dt_edit = (DateTime)rd["dt_edit"];

                        attendance.Add(abo);
                    }
                }
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return attendance;
        }

        /// <summary>
        /// Get a list of attendances with the average percentage of attendance
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static List<Attendance> GetListAttendancePurcent(string query)
        {
            List<Attendance> attendance = null;
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                conn.Open();
                SqlCommand sql;
                //select year, month, CONVERT(DECIMAL(5,2),100 * convert(float,SUM(nbp) + sum(nbc) + sum(nbd) + sum(nbdp)) / convert(float,sum(nbm))) AS purcent FROM [rodi.dnn].[dbo].[ais_attendance] group by year, month

                //On crée les requêtes SQL qui récupère le purcentage d'attiduité du month
                if (!string.IsNullOrEmpty(query))
                {
                    sql = new SqlCommand("select year, month, CONVERT(DECIMAL(5,2),100 * convert(float,SUM(nbp) + sum(nbc) + sum(nbd) + sum(nbdp)) / convert(float,sum(nbm))) AS purcent FROM " + Const.TABLE_PREFIX + "attendance WHERE " + query + " group by year, month ORDER BY year DESC, month DESC", conn);
                }
                else
                {
                    sql = new SqlCommand("select year, month, CONVERT(DECIMAL(5,2),100 * convert(float,SUM(nbp) + sum(nbc) + sum(nbd) + sum(nbdp)) / convert(float,sum(nbm))) AS purcent FROM " + Const.TABLE_PREFIX + "attendance group by year, month ORDER BY year DESC, month DESC", conn);
                }

                SqlDataAdapter da = new SqlDataAdapter(sql);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    attendance = new List<Attendance>();
                    foreach (DataRow rd in ds.Tables[0].Rows)
                    {//On attocie les résultats aux attendances que l'on ajoutera à la list
                        Attendance abo = new Attendance();
                        if (rd["year"] != DBNull.Value) abo.year = (int)rd["year"];
                        if (rd["month"] != DBNull.Value) abo.month = (int)rd["month"];
                        abo.purcent = "" + rd["purcent"];
                        attendance.Add(abo);
                    }
                }
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return attendance;
        }

        #endregion Attendance

        #region General Attendance

        /// <summary>
        /// Get a list of general attendances
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static List<General_Attendance> GetListAssiduitePurcentFinal(string query)
        {
            List<General_Attendance> attendance = null;
            List<General_Attendance> generalAttendance = null;
            List<General_Attendance> sortedGenAtts = null;
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                conn.Open();
                SqlCommand sql1;
                SqlCommand sql2;
                SqlCommand sql3;
                SqlCommand sql4;

                //On crée différentes requêtes SQL pour les différents cas possibles :
                //1. Les variations d'effectif et d'attiduité sont calculables
                //2. Seule la variation d'attiduité est calculable : il n'y a pas d'attiduités enregistrées pour le month de juillet de l'année rotarienne
                //3. Seule la variation d'effectif est calculable : il n'y a pas d'attiduités enregistrées pour le month précédent
                //4. Aucune variation n'est calculable : l'attiduité du month est la première entrée cette année rotarienne
                #region queries
                if (!string.IsNullOrEmpty(query))
                {

                    sql1 = new SqlCommand("select C.name AS name, A.nbm as 'nbm', A2.nbm as 'nb members month patté', A.month as 'month', A2.month as 'month patté', A.year as 'current year',	A4.year as 'year Rot', A4.nbm as 'a4 n', CONVERT(DECIMAL(3,0),100 * convert(float,SUM(A.nbp) + sum(A.nbc)) / convert(float,sum(A.nbm)- (sum(A.nbd) + sum(A.nbdp)))) AS purcent, CONVERT(DECIMAL(3,0),A.nbm-A4.nbm) as varEff, CONVERT(DECIMAL(3,0),100 * convert(float,SUM(A2.nbp) + sum(A2.nbc)) / convert(float,sum(A2.nbm)- (sum(A2.nbd) + sum(A2.nbdp)))) AS purcentPastYear FROM ais_attendance AS A, ais_attendance as A2, ais_attendance as A3, ais_attendance as A4, ais_attendance as A5, ais_attendance as A6, ais_clubs as C WHERE C.cric=A.cric AND A2.cric = A.cric AND A2.month = (case when A.month = 1 then A.month + 11 else A.month - 1 end) AND A2.year = (case when A.month = 1 then A.year - 1 else A.year end) AND A.month = A3.month AND A.cric=A3.cric AND A4.month=7 AND A4.year = (case when A.month < 7 then A.year-1 else A.year end) AND A.cric=A4.cric AND A5.cric = A4.cric AND A5.month = A4.month AND A5.year = A4.year AND A6.year = A2.year AND A6.month = A2.month AND A6.cric = A2.cric AND " + query + " GROUP BY C.name, A.nbm, A4.nbm, A.month, A2.month, A.day, A2.nbm, A.year, A4.year, A4.day, A2.day ORDER BY C.name", conn);

                    sql2 = new SqlCommand("select C.name AS name, A.nbm as 'nbm', A.month as 'month', A2.month as 'month patté', A.year as 'current year', CONVERT(DECIMAL(3,0),100 * convert(float,SUM(A3.nbp) + sum(A3.nbc)) / convert(float,sum(A3.nbm)- (sum(A3.nbd) + sum(A3.nbdp)))) AS purcent, CONVERT(DECIMAL(3,0),100 * convert(float,SUM(A2.nbp) + sum(A2.nbc)) / convert(float,sum(A2.nbm)- (sum(A2.nbd) + sum(A2.nbdp)))) AS purcentPastYear FROM ais_attendance AS A,  ais_attendance as A2, ais_attendance as A3, ais_clubs as C WHERE C.cric=A.cric AND	A2.cric = A.cric AND A2.month = (case when A.month = 1 then A.month + 11 else A.month - 1 end) AND A2.year = (case when A.month = 1 then A.year - 1 else A.year end) AND A.month = A3.month AND A.cric=A3.cric AND " + query + " GROUP BY C.name, A.nbm, A.month, A2.month, A.day, A2.nbm, A.year ORDER BY C.name", conn);

                    sql3 = new SqlCommand("select C.name AS name, A.nbm as 'nbm', A.month as 'month', 	A.year as 'current year', A4.year as 'year Rot', A4.nbm as 'a4 n', CONVERT(DECIMAL(3,0),100 * convert(float,SUM(A.nbp) + sum(A.nbc)) / convert(float,sum(A.nbm)- (sum(A.nbd) + sum(A.nbdp)))) AS purcent, CONVERT(DECIMAL(3,0),A.nbm-A4.nbm) as varEff FROM ais_attendance AS A, ais_attendance as A3, ais_attendance as A4, ais_attendance as A5, ais_clubs as C WHERE C.cric=A.cric AND A.month = A3.month AND A.cric=A3.cric AND A4.month=7 AND A4.year = (case when A.month < 7 then A.year-1 else A.year end) AND A.cric=A4.cric AND A5.cric = A4.cric AND A5.month = A4.month AND A5.year = A4.year AND " + query + " GROUP BY C.name, A.nbm, A4.nbm, A.month, A.day, A.year, A4.year, A4.day HAVING A.day=MIN(A3.day) AND A4.day = MIN(A5.day) ORDER BY C.name ", conn);

                    sql4 = new SqlCommand("select C.name, A.year, A.nbm, A.month, CONVERT(DECIMAL(3,0),100 * convert(float,SUM(A.nbp) + sum(A.nbc) ) / convert(float,sum(A.nbm)-(sum(A.nbd) + sum(A.nbdp)))) AS purcent FROM ais_attendance as A, ais_clubs as C WHERE C.cric=A.cric  AND " + query + " group by C.name, A.month, A.year, A.nbm, A.day ORDER BY name", conn);
                }
                else
                {
                    sql1 = new SqlCommand("select C.name AS name, A.nbm as 'nbm', A2.nbm as 'nb members month patté', A.month as 'month', A2.month as 'month patté', A.year as 'current year',	A4.year as 'year Rot', A4.nbm as 'a4 n', CONVERT(DECIMAL(3,0),100 * convert(float,SUM(A.nbp) + sum(A.nbc)) / convert(float,sum(A.nbm)- (sum(A.nbd) + sum(A.nbdp)))) AS purcent, CONVERT(DECIMAL(3,0),A.nbm-A4.nbm) as varEff, CONVERT(DECIMAL(3,0),100 * convert(float,SUM(A2.nbp) + sum(A2.nbc)) / convert(float,sum(A2.nbm)- (sum(A2.nbd) + sum(A2.nbdp)))) AS purcentPastYear FROM ais_attendance AS A, ais_attendance as A2, ais_attendance as A3, ais_attendance as A4, ais_attendance as A5, ais_attendance as A6, ais_clubs as C WHERE C.cric=A.cric AND A2.cric = A.cric AND A2.month = (case when A.month = 1 then A.month + 11 else A.month - 1 end) AND A2.year = (case when A.month = 1 then A.year - 1 else A.year end) AND A.month = A3.month AND A.cric=A3.cric AND A4.month=7 AND A4.year = (case when A.month < 7 then A.year-1 else A.year end) AND A.cric=A4.cric AND A5.cric = A4.cric AND A5.month = A4.month AND A5.year = A4.year AND A6.year = A2.year AND A6.month = A2.month AND A6.cric = A2.cric GROUP BY C.name, A.nbm, A4.nbm, A.month, A2.month, A.day, A2.nbm, A.year, A4.year, A4.day, A2.day ORDER BY C.name", conn);

                    sql2 = new SqlCommand("select C.name AS name, A.nbm as 'nbm', A.month as 'month', A2.month as 'month patté', A.year as 'current year', CONVERT(DECIMAL(3,0),100 * convert(float,SUM(A3.nbp) + sum(A3.nbc)) / convert(float,sum(A3.nbm)- (sum(A3.nbd) + sum(A3.nbdp)))) AS purcent, CONVERT(DECIMAL(3,0),100 * convert(float,SUM(A2.nbp) + sum(A2.nbc)) / convert(float,sum(A2.nbm)- (sum(A2.nbd) + sum(A2.nbdp)))) AS purcentPastYear FROM ais_attendance AS A,  ais_attendance as A2, ais_attendance as A3, ais_clubs as C WHERE C.cric=A.cric AND	A2.cric = A.cric AND A2.month = (case when A.month = 1 then A.month + 11 else A.month - 1 end) AND A2.year = (case when A.month = 1 then A.year - 1 else A.year end) AND A.month = A3.month AND A.cric=A3.cric GROUP BY C.name, A.nbm, A.month, A2.month, A.day, A2.nbm, A.year ORDER BY C.name", conn);

                    sql3 = new SqlCommand("select C.name AS name, A.nbm as 'nbm', A.month as 'month', 	A.year as 'current year', A4.year as 'year Rot', A4.nbm as 'a4 n', CONVERT(DECIMAL(3,0),100 * convert(float,SUM(A.nbp) + sum(A.nbc)) / convert(float,sum(A.nbm)- (sum(A.nbd) + sum(A.nbdp)))) AS purcent, CONVERT(DECIMAL(3,0),A.nbm-A4.nbm) as varEff FROM ais_attendance AS A, ais_attendance as A3, ais_attendance as A4, ais_attendance as A5, ais_clubs as C WHERE C.cric=A.cric AND A.month = A3.month AND A.cric=A3.cric AND A4.month=7 AND A4.year = (case when A.month < 7 then A.year-1 else A.year end) AND A.cric=A4.cric AND A5.cric = A4.cric AND A5.month = A4.month AND A5.year = A4.year GROUP BY C.name, A.nbm, A4.nbm, A.month, A.day, A.year, A4.year, A4.day HAVING A.day=MIN(A3.day) AND A4.day = MIN(A5.day) ORDER BY C.name ", conn);

                    sql4 = new SqlCommand("select C.name, A.year, A.nbm, A.month, CONVERT(DECIMAL(3,0),100 * convert(float,SUM(A.nbp) + sum(A.nbc) ) / convert(float,sum(A.nbm)-(sum(A.nbd) + sum(A.nbdp)))) AS purcent FROM ais_attendance as A, ais_clubs as C WHERE C.cric=A.cric group by C.name, A.month, A.year, A.nbm, A.day ORDER BY name", conn);
                }

                #endregion queries
                attendance = new List<General_Attendance>();
                generalAttendance = new List<General_Attendance>();

                //On ajoute les résultats de requête dans la list
                #region 1

                SqlDataAdapter da1 = new SqlDataAdapter(sql1);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);
                if (ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
                {

                    foreach (DataRow rd in ds1.Tables[0].Rows)
                    {
                        General_Attendance abo1 = new General_Attendance();

                        if (rd["varEff"] != DBNull.Value)
                        {
                            abo1.month = (int)rd["month"];
                            if (rd["name"] != DBNull.Value) abo1.name = (string)rd["name"];
                            if (rd["nbm"] != DBNull.Value) abo1.nbm = (int)rd["nbm"];
                            abo1.purcent = "" + rd["purcent"];
                            if (abo1.month != 7)
                                if (rd["varEff"] != DBNull.Value)
                                    abo1.varEff = "" + rd["varEff"];
                                else { }
                            else
                            {
                                abo1.varEff = "";
                            }
                            abo1.year = (int)rd["current year"];
                            if (rd["purcentPastYear"] != DBNull.Value) abo1.purcentPastYear = "" + rd["purcentPastYear"];
                            else
                                abo1.varAtt = "0";
                        }
                        attendance.Add(abo1);
                    }
                }

                #endregion 1

                #region 2
                SqlDataAdapter da2 = new SqlDataAdapter(sql2);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);
                if (ds2.Tables.Count > 0 && ds2.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow rd in ds2.Tables[0].Rows)
                    {
                        General_Attendance abo2 = new General_Attendance();

                        if (rd["name"] != DBNull.Value) abo2.name = (String)rd["name"];
                        if (rd["nbm"] != DBNull.Value) abo2.nbm = (int)rd["nbm"];
                        abo2.month = (int)rd["month"];
                        abo2.purcent = "" + rd["purcent"];
                        abo2.varEff = "";
                        if (rd["purcentPastYear"] != DBNull.Value) abo2.purcentPastYear = "" + rd["purcentPastYear"];
                        abo2.year = (int)rd["current year"];
                        int testContient = 0;
                        if (attendance != null || attendance.Count != 0)
                        {
                            foreach (General_Attendance attG in attendance)
                            {
                                if (attG.name == abo2.name && attG.month == abo2.month && attG.year == abo2.year)
                                {
                                    testContient++;
                                    break;
                                }
                            }
                            if (testContient == 0)
                                attendance.Add(abo2);
                        }
                        else
                            attendance.Add(abo2);


                    }
                }

                #endregion 2

                #region 3
                SqlDataAdapter da3 = new SqlDataAdapter(sql3);
                DataSet ds3 = new DataSet();
                da3.Fill(ds3);
                if (ds3.Tables.Count > 0 && ds3.Tables[0].Rows.Count > 0)
                {

                    foreach (DataRow rd in ds3.Tables[0].Rows)
                    {
                        General_Attendance abo3 = new General_Attendance();

                        if (rd["name"] != DBNull.Value) abo3.name = (String)rd["name"];
                        if (rd["nbm"] != DBNull.Value) abo3.nbm = (int)rd["nbm"];
                        abo3.month = (int)rd["month"];
                        abo3.purcent = "" + rd["purcent"];
                        abo3.purcentPastYear = "";
                        if (abo3.month != 7)
                            if (rd["varEff"] != DBNull.Value) abo3.varEff = "" + rd["varEff"];
                            else throw new Exception("Problem");
                        else
                            abo3.varEff = "";
                        abo3.year = (int)rd["current year"];
                        int testContient = 0;
                        if (attendance != null || attendance.Count != 0)
                        {
                            foreach (General_Attendance attG in attendance)
                            {
                                if (attG.name == abo3.name && attG.month == abo3.month && attG.year == abo3.year)
                                {
                                    testContient++;
                                    break;
                                }
                            }

                        }
                        if (testContient == 0)
                            attendance.Add(abo3);

                    }
                }

                #endregion 3

                #region 4
                SqlDataAdapter da4 = new SqlDataAdapter(sql4);
                DataSet ds4 = new DataSet();
                da4.Fill(ds4);
                if (ds4.Tables.Count > 0 && ds4.Tables[0].Rows.Count > 0)
                {

                    foreach (DataRow rd in ds4.Tables[0].Rows)
                    {
                        General_Attendance abo4 = new General_Attendance();

                        if (rd["name"] != DBNull.Value) abo4.name = (String)rd["name"];
                        if (rd["nbm"] != DBNull.Value) abo4.nbm = (int)rd["nbm"];
                        abo4.month = (int)rd["month"];
                        abo4.purcent = "" + rd["purcent"];
                        abo4.year = (int)rd["year"];
                        abo4.varEff = "";
                        abo4.purcentPastYear = "";

                        int testContient = 0;
                        if (attendance != null || attendance.Count != 0)
                        {
                            foreach (General_Attendance attG in attendance)
                            {
                                if (attG.name == abo4.name && attG.month == abo4.month)
                                {
                                    testContient++;
                                    break;
                                }
                            }
                            if (testContient == 0)
                                attendance.Add(abo4);
                        }
                        else
                            attendance.Add(abo4);

                    }
                }
                #endregion 4

                //Ici, on récupère le purcentage d'attiduité de chaque réunion et on calcule l'attiduité moyenne ainsi que celle du month précédent (qu'on utilisera pour calculer la variation d'attiduité)
                #region Calcul moyennes
                General_Attendance attG2 = new General_Attendance();
                int purcent = 0;
                int purcentAvant = 0;
                int compteur = 1;
                int compteurAvant = 1;
                for (int i = 0; i < attendance.Count; i++)
                {
                    if (attendance[i].purcentPastYear != "")
                    {
                        if (i != 0 && attendance[i].name != attendance[i - 1].name)
                        {
                            if (compteur != 1)
                            {
                                purcent = purcent / compteur;
                                attG2.purcent = "" + purcent;

                            }
                            if (compteurAvant != 1)
                            {
                                purcentAvant = purcentAvant / compteurAvant;
                                attG2.purcentPastYear = "" + purcentAvant;
                            }
                            attG2.varAtt = "" + (purcent - purcentAvant);
                            generalAttendance.Add(attG2);
                            attG2 = attendance[i];
                            purcent = int.Parse(attG2.purcent);
                            purcentAvant = int.Parse(attG2.purcentPastYear);
                            compteur = 1;
                            compteurAvant = 1;
                        }
                        else if (i != 0 && attendance[i].name == attendance[i - 1].name)
                        {
                            attG2.name = attendance[i].name;
                            purcent += int.Parse(attendance[i].purcent);
                            purcentAvant += int.Parse(attendance[i].purcentPastYear);
                            compteur++;
                            compteurAvant++;
                        }
                        else if (i == 0)
                        {
                            attG2 = attendance[0];
                            purcent = int.Parse(attendance[0].purcent);
                            purcentAvant = int.Parse(attendance[0].purcentPastYear);
                            attG2.varAtt = "" + (purcent - purcentAvant);
                            if (attendance.Count == 1)
                                generalAttendance.Add(attG2);
                        }

                    }
                    else
                        generalAttendance.Add(attendance[i]);
                }
                if (!generalAttendance.Contains(attG2) && attG2.nbm != 0)
                {
                    if (compteur != 1)
                    {
                        purcent = purcent / compteur;
                        attG2.purcent = "" + purcent;
                    }
                    if (compteurAvant != 1)
                    {
                        purcentAvant = purcentAvant / compteurAvant;
                        attG2.purcentPastYear = "" + purcentAvant;
                    }
                    attG2.varAtt = "" + (purcent - purcentAvant);
                    generalAttendance.Add(attG2);
                }
                #endregion Calcul moyennes

                //Ici on clatte les attendances générales par [order] alphabétique. Elles seront plus facilement retrouvées dans le tableau par la suite
                #region Ordre Alphabétique
                sortedGenAtts = new List<General_Attendance>();
                foreach (General_Attendance attG3 in generalAttendance)
                {
                    int j = 0;
                    if (sortedGenAtts.Count != 0)
                    {
                        for (int i = 0; i < sortedGenAtts.Count; i++)
                        {
                            if (attG3.name.CompareTo(sortedGenAtts[i].name) == -1 && !sortedGenAtts.Contains(attG3)) //Les names sont clattés par [order] alphabétique
                            {
                                sortedGenAtts.Insert(i, attG3);
                                j = i;
                                break;
                            }
                        }
                        if (j == 0 && !sortedGenAtts.Contains(attG3))
                        {
                            sortedGenAtts.Add(attG3);
                        }
                    }
                    else
                    {
                        sortedGenAtts.Add(attG3);
                    }

                }
                #endregion Ordre Alphabétique

            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return sortedGenAtts;
        }

        #endregion General Attendance

        #region DRYA

        /// <summary>
        /// Add a DRYA
        /// </summary>
        /// <param name="drya"></param>
        /// <returns></returns>
        public static int InsertDRYA(DRYA drya)
        {
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            SqlTransaction trans = null;
            int id = 0;
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand sql;

                if (drya.id != 0)
                {
                    sql = new SqlCommand("UPDATE " + Const.TABLE_PREFIX + "drya SET [nim]=@nim,[surname]=@surname, [name]=@name, [job]=@job, [description]=@description, [cric]=@cric,[club]=@club, [section]=@section, [rank]=@rank, [rotary_year]=@rotary_year WHERE [id]=@id", conn, trans);
                    sql.Parameters.AddWithValue("@id", drya.id);
                    sql.Parameters.AddWithValue("@rank", drya.rank);

                }
                else if (drya.id == 0 && drya.rank != 0)
                {
                    sql = new SqlCommand("INSERT INTO " + Const.TABLE_PREFIX + "drya ([nim],[surname],[name],[job], [description], [cric],[club],[section], [rank], [rotary_year]) VALUES (@nim,@surname,@name,@job,@description,@cric,@club,@section,@rank,@rotary_year)", conn, trans);
                    sql.Parameters.AddWithValue("@rank", drya.rank);

                }
                else
                {
                    sql = new SqlCommand("INSERT INTO " + Const.TABLE_PREFIX + "drya ([nim],[surname],[name],[job],[description],[cric],[club],[section],[rank],[rotary_year]) VALUES (@nim,@surname,@name,@job,@description@cric,@club,@section,1000000000,@rotary_year)", conn, trans);
                }

                sql.Parameters.AddWithValue("@nim", drya.nim);
                sql.Parameters.AddWithValue("@surname", drya.surname);
                sql.Parameters.AddWithValue("@name", drya.name);
                sql.Parameters.AddWithValue("@job", drya.job);
                sql.Parameters.AddWithValue("@description", drya.description);
                sql.Parameters.AddWithValue("@cric", drya.cric);
                sql.Parameters.AddWithValue("@club", drya.club);
                sql.Parameters.AddWithValue("@section", drya.section);
                sql.Parameters.AddWithValue("@rotary_year", drya.rotary_year);





                if (sql.ExecuteNonQuery() == 0)
                {
                    throw new Exception("Erreur MAJ table drya");
                }
                else if (drya.id < 1)
                {
                    sql = new SqlCommand("SELECT @@IDENTITY", conn, trans);
                    id = int.Parse("" + sql.ExecuteScalar());
                }
                else
                {
                    id = drya.id;
                }

                trans.Commit();


                UpdateDRYARank(drya.rotary_year, drya.section);

                return id;

            }
            catch (Exception ee)
            {
                if (trans != null)
                    try
                    {
                        trans.Rollback();
                    }
                    catch { }
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return id;
        }

        /// <summary>
        /// Get a list of DRYAs
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static List<DRYA> GetListDRYA(string query)
        {
            List<DRYA> architecture = null;
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                conn.Open();
                SqlCommand sql;
                if (!string.IsNullOrEmpty(query))
                {
                    sql = new SqlCommand("SELECT * FROM " + Const.TABLE_PREFIX + "drya WHERE " + query + " ORDER BY rank, id", conn);
                }
                else
                {
                    sql = new SqlCommand("SELECT * FROM " + Const.TABLE_PREFIX + "drya ORDER BY rank, id", conn);
                }

                SqlDataAdapter da = new SqlDataAdapter(sql);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    architecture = new List<DRYA>();
                    foreach (DataRow rd in ds.Tables[0].Rows)
                    {
                        DRYA archi = new DRYA();

                        if (rd["id"] != DBNull.Value) archi.id = (int)rd["id"];
                        if (rd["nim"] != DBNull.Value) archi.nim = (int)rd["nim"];
                        if (rd["surname"] != DBNull.Value) archi.surname = (string)rd["surname"];
                        if (rd["name"] != DBNull.Value) archi.name = (string)rd["name"];
                        if (rd["job"] != DBNull.Value) archi.job = (string)rd["job"];
                        if (rd["description"] != DBNull.Value) archi.description = (string)rd["description"];
                        if (rd["cric"] != DBNull.Value) archi.cric = (int)rd["cric"];
                        if (rd["club"] != DBNull.Value) archi.club = (string)rd["club"];
                        if (rd["section"] != DBNull.Value) archi.section = (string)rd["section"];
                        if (rd["rank"] != DBNull.Value) archi.rank = (int)rd["rank"];
                        if (rd["rotary_year"] != DBNull.Value) archi.rotary_year = (int)rd["rotary_year"];


                        architecture.Add(archi);
                    }
                }
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return architecture;
        }

        public static bool UpdateDRYAPosition(int year, string section, int id, bool up)
        {
           

            try
            {
                DataSet ds = ExecSql("SELECT * FROM " + Const.TABLE_PREFIX + "drya WHERE rotary_year=" + year + " AND section='" + section + "' ORDER BY rank");
                
                for(int i=0;i<ds.Tables[0].Rows.Count;i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    if ((int)row["id"] == id)
                    {
                        if (up)
                        {
                            if(i==0)
                            {
                                return true;
                            }

                            DataRow row1 = ds.Tables[0].Rows[i - 1];

                            ExecSql("UPDATE " + Const.TABLE_PREFIX + "drya SET rank=" + row["rank"] + " WHERE id=" + row1["id"]);
                            ExecSql("UPDATE " + Const.TABLE_PREFIX + "drya SET rank=" + row1["rank"] + " WHERE id=" + id);
                        }
                        else
                        {
                            if (i == ds.Tables[0].Rows.Count - 1)
                            { 
                                return true;
                            }

                            DataRow row1 = ds.Tables[0].Rows[i + 1];
                            ExecSql("UPDATE " + Const.TABLE_PREFIX + "drya SET rank=" + row["rank"] + " WHERE id=" + row1["id"]);
                            ExecSql("UPDATE " + Const.TABLE_PREFIX + "drya SET rank=" + row1["rank"] + " WHERE id=" + id);
                        }
                    }
                }

                return true;
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
             
            }
            return false;
        }

        public static bool UpdateDRYARank(int year, string section)
        {
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            SqlTransaction trans = null;

            try
            {
                DataSet ds = ExecSql("SELECT id FROM " + Const.TABLE_PREFIX + "drya WHERE rotary_year=" + year + " AND section='" + section + "' ORDER BY rank");
                conn.Open();
                trans = conn.BeginTransaction();
                int i = 1;
                foreach(DataRow row in ds.Tables[0].Rows)
                {
                    SqlCommand sql = new SqlCommand("UPDATE " + Const.TABLE_PREFIX + "drya SET rank=" + i + " WHERE id=" + row["id"], conn, trans);
                    sql.ExecuteNonQuery();
                    i++;
                }
                trans.Commit();
                return true;
            }
            catch (Exception ee)
            {
                if (trans != null)
                    try
                    {
                        trans.Rollback();
                    }
                    catch { }
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        /// <summary>
        /// Delete a DRYA
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteDRYA(int id)
        {
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            SqlTransaction trans = null;

            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand sql = new SqlCommand("DELETE  " + Const.TABLE_PREFIX + "drya where [id]=@id", conn, trans);
                sql.Parameters.AddWithValue("@id", id);

                if (sql.ExecuteNonQuery() == 0)
                    throw new Exception("Erreur SUPP drya id " + id + " de la table drya");

                ClearMemberCache();

                trans.Commit();

                return true;
            }
            catch (Exception ee)
            {
                if (trans != null)
                    try
                    {
                        trans.Rollback();
                    }
                    catch { }
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        #endregion DRYA

        #region Domain

        /// <summary>
        /// Get a list of domains
        /// </summary>
        /// <param name="domain">Domain name</param>
        /// <param name="query"></param>
        /// <returns></returns>
        public static List<Domain> GetListDomain(string domain, string query)
        {
            List<Domain> listDomain = null;
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                conn.Open();
                SqlCommand sql;
                if (!string.IsNullOrEmpty(query))
                {//On écrit la requête SQL récupérant tous les domains voulus
                    sql = new SqlCommand("SELECT * FROM " + Const.TABLE_PREFIX + "domain WHERE domain='" + domain + "' AND " + query + " ORDER BY [order]", conn);
                }
                else
                {
                    sql = new SqlCommand("SELECT * FROM " + Const.TABLE_PREFIX + "domain WHERE domain='" + domain + "' ORDER BY [order]", conn);
                }

                SqlDataAdapter da = new SqlDataAdapter(sql);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    listDomain = new List<Domain>();
                    foreach (DataRow rd in ds.Tables[0].Rows)
                    {
                        Domain dom = new Domain();
                        //On attocie chaque colonne à un paramètre de domain
                        if (rd["id"] != DBNull.Value) dom.id = (int)rd["id"];
                        if (rd["domain"] != DBNull.Value) dom.domain = (string)rd["domain"];
                        if (rd["subdomain"] != DBNull.Value) dom.subdomain = (string)rd["subdomain"];
                        if (rd["wording"] != DBNull.Value) dom.wording = (string)rd["wording"];
                        if (rd["value"] != DBNull.Value) dom.value = (string)rd["value"];
                        if (rd["culture"] != DBNull.Value) dom.culture = (string)rd["culture"];
                        if (rd["order"] != DBNull.Value) dom.order = (int)rd["order"];
                        if (rd["parent"] != DBNull.Value) dom.parent = (int)rd["parent"];



                        listDomain.Add(dom);
                    }
                }
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return listDomain;
        }

        public static List<String> GetListNatures()
        {
            List<String> listNatures = null;
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                conn.Open();
                SqlCommand sql;
                sql = new SqlCommand("SELECT [value] FROM " + Const.TABLE_PREFIX + "domain WHERE domain='Nouvelles' ORDER BY [order]", conn);
                SqlDataAdapter da = new SqlDataAdapter(sql);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    listNatures = new List<String>();
                    foreach (DataRow rd in ds.Tables[0].Rows)
                    {
                        listNatures.Add((String)rd["value"]);
                    }
                }
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return listNatures;
        }

        public static Dictionary<String, String> GetPanels(String nature)
        {
            Dictionary<String, String> listPanels = null;
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                conn.Open();
                SqlCommand sql;
                sql = new SqlCommand("SELECT [value] FROM " + Const.TABLE_PREFIX + "domain WHERE subdomain='" + nature + ".display'", conn);
                SqlDataAdapter da = new SqlDataAdapter(sql);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    listPanels = new Dictionary<String, String>();
                    DataRow rd = ds.Tables[0].Rows[0];
                    string s = rd[0].ToString();
                    string[] splits = s.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string st in splits)
                    {
                        string[] splits2 = st.Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                        listPanels.Add(splits2[0], splits2[1]);
                    }
                }

            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return listPanels;
        }

        #endregion Domain

        #region Commission

        /// <summary>
        /// Get a list of commissions 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static List<Commission> GetListCommission(string query)
        {
            List<Commission> listCommission = null;
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {
                conn.Open();
                SqlCommand sql;
                if (!string.IsNullOrEmpty(query))
                {//On crée les requêtes SQL permettant de récupérer la ou les commissions voulues
                    sql = new SqlCommand("SELECT * FROM " + Const.TABLE_PREFIX + "commission WHERE " + query + " ORDER BY name, job, id", conn);
                }
                else
                {
                    sql = new SqlCommand("SELECT * FROM " + Const.TABLE_PREFIX + "commission ORDER BY name, job, id", conn);
                }

                SqlDataAdapter da = new SqlDataAdapter(sql);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    listCommission = new List<Commission>();
                    foreach (DataRow rd in ds.Tables[0].Rows)
                    {
                        Commission com = new Commission();

                        if (rd["id"] != DBNull.Value) com.id = (int)rd["id"];
                        if (rd["name"] != DBNull.Value) com.name = (string)rd["name"];
                        if (rd["job"] != DBNull.Value) com.job = (string)rd["job"];
                        else
                            com.job = "Sans job";
                        if (rd["memberName"] != DBNull.Value) com.memberName = (string)rd["memberName"];
                        if (rd["rotary_year"] != DBNull.Value) com.rotary_year = (int)rd["rotary_year"];

                        listCommission.Add(com);
                    }
                }
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return listCommission;
        }

        /// <summary>
        /// Add a commission
        /// </summary>
        /// <param name="com"></param>
        /// <returns></returns>
        public static int InsertCommission(Commission com)
        {
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            SqlTransaction trans = null;
            int id = 0;
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                SqlCommand sql;

                if (com.id != 0)
                {//On crée la requête permettant de modifier la commission
                    sql = new SqlCommand("UPDATE " + Const.TABLE_PREFIX + "commission SET [name]=@name, [job]=@job, [memberName]=@memberName, [rotary_year]=@rotary_year WHERE [id]=@id", conn, trans);
                    sql.Parameters.AddWithValue("@id", com.id);

                }
                else
                {//Si la commission n'existe pas, on l'ajoute dans la table
                    sql = new SqlCommand("INSERT INTO " + Const.TABLE_PREFIX + "commission ([name],[job],[memberName], [rotary_year]) VALUES (@name,@job,@memberName,@rotary_year)", conn, trans);
                }

                sql.Parameters.AddWithValue("@name", com.name);
                sql.Parameters.AddWithValue("@job", com.job);
                sql.Parameters.AddWithValue("@memberName", com.memberName);
                sql.Parameters.AddWithValue("@rotary_year", com.rotary_year);






                if (sql.ExecuteNonQuery() == 0)
                {
                    throw new Exception("Erreur MAJ table commission");
                }
                else if (com.id < 1)
                {
                    sql = new SqlCommand("SELECT @@IDENTITY", conn, trans);
                    id = int.Parse("" + sql.ExecuteScalar());
                }
                else
                {
                    id = com.id;
                }

                trans.Commit();
                return id;

            }
            catch (Exception ee)
            {
                if (trans != null)
                    try
                    {
                        trans.Rollback();
                    }
                    catch { }
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return id;
        }

        /// <summary>
        /// Delete a commission
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteCommission(int id)
        {
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            SqlTransaction trans = null;

            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                //On supprime la commission voulue via une requête SQL
                SqlCommand sql = new SqlCommand("DELETE  " + Const.TABLE_PREFIX + "commission where [id]=@id", conn, trans);
                sql.Parameters.AddWithValue("@id", id);

                if (sql.ExecuteNonQuery() == 0)
                    throw new Exception("Erreur SUPP commission id " + id + " de la table commission");

                ClearMemberCache();

                trans.Commit();

                return true;
            }
            catch (Exception ee)
            {
                if (trans != null)
                    try
                    {
                        trans.Rollback();
                    }
                    catch { }
                Functions.Error(ee);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        #endregion Commission

        #region Mobile
        /// <summary>
        /// Insert data into ws_stats table
        /// </summary>
        /// <param name="os"></param>
        /// <param name="device"></param>
        /// <param name="version"></param>
        /// <param name="ip"></param>
        /// <param name="datetime"></param>
        /// <param name="duree"></param>
        /// <param name="function"></param>
        /// <param name="code"></param>
        /// <param name="comment"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public static int InsertUpdateLogMobile(int id, string os, string device, string version, string ip, DateTime datetime, float duration, string function, string code, string comment, string username)
        {
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            SqlTransaction trans = null;
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();

                SqlCommand sql;

                if (id == 0)
                {
                    sql = new SqlCommand("INSERT INTO " + Const.TABLE_PREFIX + "ws_stats ([os],[device],[version],[ip],[datetime],[duration],[function],[code],[comment],[username]) VALUES (@os,@device,@version,@ip,@datetime,@duration,@function,@code,@comment,@username)", conn, trans);
                }
                else
                {
                    sql = new SqlCommand("UPDATE " + Const.TABLE_PREFIX + "ws_stats SET [os]=@os,[device]=@device,[version]=@version,[ip]=@ip,[datetime]=@datetime,[duration]=@duration,[function]=@function,[code]=@code,[comment]=@comment, [username]=@username WHERE [id]=@id", conn, trans);

                    sql.Parameters.AddWithValue("@id", id);
                }


                sql.Parameters.AddWithValue("@os", os);
                sql.Parameters.AddWithValue("@device", device);
                sql.Parameters.AddWithValue("@version", version);
                sql.Parameters.AddWithValue("@ip", ip);
                sql.Parameters.AddWithValue("@datetime", datetime);
                sql.Parameters.AddWithValue("@duration", duration);
                sql.Parameters.AddWithValue("@function", function);
                sql.Parameters.AddWithValue("@code", code);
                sql.Parameters.AddWithValue("@comment", comment);
                sql.Parameters.AddWithValue("@username", username);

                if (sql.ExecuteNonQuery() == 0)
                    throw new Exception("Erreur lors de l'insert dans ws_stats");

                if (id == 0)
                {
                    sql = new SqlCommand("SELECT @@IDENTITY", conn, trans);
                    id = int.Parse("" + sql.ExecuteScalar());
                }

                trans.Commit();
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
                if (trans != null)
                    try { trans.Rollback(); }
                    catch { }
            }
            finally
            {
                conn.Close();
            }
            return id;
        }

        /// <summary>
        /// Add or edit a payment
        /// </summary>
        /// <param name="obj">Payement to add or edit</param>
        /// <returns>Validité de l'opération</returns>
        public static bool UpdateLogMobile(int id, float duration, string code, string comment)
        {
            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            SqlTransaction trans = null;
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();

                if (id != null && id > 0)
                {
                    SqlCommand sql = new SqlCommand("UPDATE " + Const.TABLE_PREFIX + "ws_stats SET [duration]=@duration,[code]=@code,[comment]=@comment WHERE [id]=@id", conn, trans);

                    sql.Parameters.AddWithValue("@id", id);
                    sql.Parameters.AddWithValue("@duration", duration);
                    sql.Parameters.AddWithValue("@code", code);
                    sql.Parameters.AddWithValue("@comment", comment);

                    if (sql.ExecuteNonQuery() == 0)
                        throw new Exception("Erreur mise a jour UpdateLogMobile : " + id);

                    trans.Commit();
                    return true;
                }
                else
                {
                    throw new Exception("UpdateLogMobile en erreur à cause de l'id qui est null ou = à 0");
                }

            }
            catch (Exception ee)
            {
                Functions.Error(ee);
                if (trans != null)
                    try { trans.Rollback(); }
                    catch { }
            }
            finally
            {
                conn.Close();
            }
            return false;
        }



        #endregion Mobile


    }

}
