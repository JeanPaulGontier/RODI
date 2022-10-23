
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
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AIS;
using DotNetNuke.Common;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Users;
using DotNetNuke.Security.Membership;
using DotNetNuke.Security.Roles;
using DotNetNuke.Services.Mail;


public partial class DesktopModules_AIS_Admin_Maj_AAR_Control : PortalModuleBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        

//        DotNetNuke.Entities.Users.UserController objUserController = new DotNetNuke.Entities.Users.UserController();
//        ArrayList listroles = objUserController.GetUsers(PortalId, true, true);
//        foreach (object i in listroles)
//        {
//            DotNetNuke.Entities.Users.UserInfo objuser = (DotNetNuke.Entities.Users.UserInfo)i;


//            string oldPassword = DotNetNuke.Entities.Users.UserController.GetPassword(ref objuser, objuser.Membership.PasswordAnswer);
//            if (oldPassword.StartsWith("<") && oldPassword.EndsWith(">"))
//            {

//                Response.Write(objuser.Username + "&nbsp;" + oldPassword + "<br/>");

                
//                string password = "" + DateTime.Now.Ticks;
//                password = "rodi" + password.Substring(password.Length - 4, 4);
//                //password = "rodi1730test";
                

//                DotNetNuke.Entities.Users.UserController.ChangePassword(objuser, oldPassword, password);

//                string message = "Cheres amies et chers amis,<br/><br/>";
//                message += "Certains anciens mot de passes posent des problemes<br/>";
//                message += "afin d'eviter ca, j'en ai genere de nouveaux<br/><br/>";
//                message += "Donc pour acceder a site du district :<br/>";
//                message += "site : www.rotary1730.org<br/>";
//                message += "nom d'utiliasteur : " + objuser.Email + "<br/>";
//                message += "mot de passe : " + password + "<br/><br/>";
//                message += "en cas de probleme n'hésitez pas a me contacter<br/>";
//                message += "sur : webmaster@rotary1730.org";

                
////                Mail.SendEmail(ps.Email, ps.Email, objuser.Email, "Nouveau mot de passe site district", message);
//                //Mail.SendEmail(Globals.GetPortalSettings().Email, Globals.GetPortalSettings().Email, objuser.Email, "Nouveau mot de passe site district", message);

//            }

        //}        
    }
    protected void BT_Maj_Click(object sender, EventArgs e)
    {
        TXT_Result.Text = "";
        SqlConnection conn = new SqlConnection(Config.GetConnectionString());
        try
        {
            conn.Open();
            TXT_Result.Text = "<br/>";
            /****** Script de la commande SelectTopNRows à partir de SSMS  ******/
            SqlCommand sql = new SqlCommand("SELECT * FROM [admin_club] where open_passwd !='' and fonction like 'new_%' and cric !='' and cric is not null",conn);
            SqlDataAdapter da = new SqlDataAdapter(sql);
            DataSet ds = new DataSet();
            da.Fill(ds);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                sql = new SqlCommand("SELECT id FROM " + Const.TABLE_PREFIX + "members WHERE nim=@nim", conn);
                sql.Parameters.AddWithValue("nim", row["nim"]);
                string id = ""+sql.ExecuteScalar();
                int idn = 0;
                int.TryParse(id, out idn);
                if (idn != 0)
                {

                    Member member = DataMapping.GetMember(idn);
                    if (member.userid == 0)
                    {
                        UserInfo ui = UserController.GetUserByName(Globals.GetPortalSettings().PortalId, member.email);
                        if (ui == null && member != null)
                        {
                            TXT_Result.Text += "Creation : " + member.surname + " " + member.name + "<br/>";
                            ui = new UserInfo();
                            ui.Username = member.email;
                            ui.FirstName = member.name;
                            ui.LastName = member.surname;
                            ui.DisplayName = member.name + " " + member.surname;
                            ui.Email = member.email;
                            ui.IsSuperUser = false;
                            ui.PortalID = Globals.GetPortalSettings().PortalId;

                            UserMembership mb = new UserMembership(ui);
                            mb.Approved = true;
                            mb.CreatedDate = System.DateTime.Now;
                            mb.IsOnLine = false;

                            string password = "" + DateTime.Now.Ticks;
                            password = ""+row["open_passwd"];
                            //password = "rodi1730test";
                            mb.Password = password;

                            ui.Membership = mb;


                            if (UserCreateStatus.Success == UserController.CreateUser(ref ui))
                            {

                                DotNetNuke.Security.Roles.RoleController rc = new DotNetNuke.Security.Roles.RoleController();
                                RoleInfo uri = rc.GetRoleByName(Globals.GetPortalSettings().PortalId, Const.ROLE_MEMBERS);
                                rc.AddUserRole(Globals.GetPortalSettings().PortalId, ui.UserID, uri.RoleID, Null.NullDate, Null.NullDate);


                                TXT_Result.Text += DataMapping.UpdateMemberDNNUserID(member.id, ui.UserID)+"<br/>";
                            }
                        }
                    }
                    
                }
                else
                {
                    TXT_Result.Text += "NIM inconnu : " + row["nim"] +" "+row["surname"]+" "+row["name"]+ "<br/>";
                }
            }
        }
        catch (Exception ee)
        {
            TXT_Result.Text += ee.ToString();
        }
        finally
        {
            conn.Close();
        }
    }


    protected void BT_Refresh_AAR_Click(object sender, EventArgs e)
    {
        TXT_Result.Text = "";
        SqlConnection conn = new SqlConnection(Config.GetConnectionString());
        try
        {
            conn.Open();

            int annee = Functions.GetRotaryYear();

            DotNetNuke.Security.Roles.RoleController rc = new DotNetNuke.Security.Roles.RoleController();
            RoleInfo uri = rc.GetRoleByName(Globals.GetPortalSettings().PortalId, Const.ROLE_ADMIN_CLUB);
            ArrayList users =  rc.GetUsersByRoleName(PortalId, Const.ROLE_ADMIN_CLUB);
            foreach (UserInfo user in users)
            {
                if (!RoleController.DeleteUserRole(user, uri, Globals.GetPortalSettings(), false))
                {
                }
               // rc.DeleteUserRole(Globals.GetPortalSettings().PortalId, user.UserID,uri.RoleID);
            }
            

            String query = "SELECT nim,name FROM " + Const.TABLE_PREFIX + "rya WHERE [function] IN ("+Const.AFFECTATIONS_ADMIN_CLUB+") AND  rotary_year IN (";

            if (DateTime.Now.Month >= 1 && DateTime.Now.Month < 7)
                query += annee + "," + (annee + 1);
            else// if (DateTime.Now.Month >= 7)
                //query += (annee - 1) + "," + annee;
                query += annee;

            query += ")";

            
            SqlCommand sql = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(sql);
            DataSet ds = new DataSet();
            da.Fill(ds);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
            cestbon:
                 
                Member membre = DataMapping.GetMemberByNim((int)row["nim"]);
                if (membre != null)
                {
                    if (membre.userid == 0)
                    {
                        TXT_Result.Text += "<br/>Le membre : " + row["name"] + " n'a pas de user DNN";
                        if (DataMapping.UpdateOrCreateUser(membre.id, membre.email))
                        {                            
                            TXT_Result.Text += "<br/>et a été créé";
                            goto cestbon;
                        }
                        else
                        {
                            TXT_Result.Text += "<br/>et n'a pas été créé";
                        }

                    }
                    else
                    {
                        UserInfo ui = UserController.GetUserByName(Globals.GetPortalSettings().PortalId, membre.email);
                        if (ui != null)
                        {

                            rc.AddUserRole(Globals.GetPortalSettings().PortalId, ui.UserID, uri.RoleID, Null.NullDate, Null.NullDate);
                            TXT_Result.Text += "<br/>Ajout role admin club : " + row["name"];
                        }
                    }
                }
            }
            
        }         
        catch (Exception ee)
        {
            TXT_Result.Text += ee.ToString();
        }
        finally
        {
            conn.Close();
        }
    }



    protected void BT_CreateUsersManquants_Click(object sender, EventArgs e)
    {
        DotNetNuke.Security.Roles.RoleController rc = new DotNetNuke.Security.Roles.RoleController();
        TXT_Result.Text = "";
        List<Member> membres = DataMapping.ListMembers(max:10000);
        foreach (Member membre in membres)
        {
            if (membre.email != "")
            {
                if (membre.userid != 0)
                {
                    UserInfo ui = UserController.GetUserById(Globals.GetPortalSettings().PortalId, membre.userid);
                    if (ui == null)
                    {
                        if (DataMapping.UpdateOrCreateUser(membre.id, membre.email))
                            TXT_Result.Text += "<br/>Creation : " + membre.surname + " " + membre.name + " ("+membre.email+")";
                        else
                            TXT_Result.Text += "<br/>Erreur création user : " + membre.surname + " " + membre.name + " (" + membre.email + ")";

                    }
                    else
                    {
                        if(ui.Username != membre.email)
                        {
                            UserController.DeleteUser(ref ui, false, false);
                            UserController.DeleteUnauthorizedUsers(Globals.GetPortalSettings().PortalId);
                            TXT_Result.Text += "<br/>Suppression ancien utilisateur : " + ui.Username;

                            if (DataMapping.UpdateOrCreateUser(membre.id, membre.email))
                                TXT_Result.Text += "<br/>Creation : " + membre.surname + " " + membre.name + " (" + membre.email + ")";
                            else
                                TXT_Result.Text += "<br/>Erreur création user : " + membre.surname + " " + membre.name + " (" + membre.email + ")";
                        }
                        else
                        {
                            if (DataMapping.UpdateMemberDNNUserID(membre.id, ui.UserID))
                            { }    //TXT_Result.Text += "<br/>L'utilisateur DNN existe déjà donc mise à jour : " + membre.surname + " " + membre.name;
                            else
                                TXT_Result.Text += "<br/>L'utilisateur DNN existe déjà mais n'a pas pu être mis à jour : " + membre.surname + " " + membre.name + " (" + membre.email + ")";
                        }

                    }
                }
                else if (membre.userid == 0)
                {
                    UserInfo ui = UserController.GetUserByName(Globals.GetPortalSettings().PortalId, membre.email);
                    if (ui == null)
                    {
                        if (DataMapping.UpdateOrCreateUser(membre.id, membre.email))

                            TXT_Result.Text += "<br/>Creation : " + membre.surname + " " + membre.name;
                        else
                            TXT_Result.Text += "<br/>Erreur création user : " + membre.surname + " " + membre.name;

                    }
                    else
                    {
                        if (DataMapping.UpdateMemberDNNUserID(membre.id, ui.UserID))
                            TXT_Result.Text += "<br/>L'utilisateur DNN existe déjà donc mise à jour : " + membre.surname + " " + membre.name;
                        else
                            TXT_Result.Text += "<br/>L'utilisateur DNN existe déjà mais n'a pas pu être mis à jour : " + membre.surname + " " + membre.name;


                    }
                }
            }

        }
        TXT_Result.Text += "<br/>Traitement terminé...";


    }
    protected void BT_CorrigerSEOClubs_Click(object sender, EventArgs e)
    {
        Functions.UpdateSEOClubs(HttpContext.Current);
        pnl_error.Visible = false;
        pnl_success.Visible = true;
    }

    protected string GetSEO(string nom)
    {
        return Functions.GetSEO(nom);
    }
}