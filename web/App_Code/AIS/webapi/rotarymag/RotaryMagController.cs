
#region Copyrights

//
// RODI - https://rodi-platform.org
// Copyright (c) 2024
// by SARL AIS : https://www.aisdev.net
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
using DotNetNuke.Common;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Users;
using DotNetNuke.Security.Membership;
using DotNetNuke.Security.Roles;
using DotNetNuke.Web.Api;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Yemon.dnn;
using System.Linq;
using DotNetNuke.ExtensionPoints;

namespace AIS.controller
{
    public class RotaryMagController : DnnApiController
    {
      
        private bool CheckAccess()
        {
            string prefixe  = "Erreur accès api rotarymag " + Environment.NewLine + Request.GetHttpContext().Request.RawUrl+"" + Environment.NewLine;
            var parametres = RotaryMagHelper.GetParametres();
            if (parametres == null)
            {
                Functions.Error(new Exception(prefixe+"paramètres non définis"));
                return false;
            }
               

            if (String.IsNullOrEmpty(parametres.allowed_hosts))
            {
                Functions.Error(new Exception(prefixe + "pas d'hôte autorisé dans les paramètres"));
                return false;
            }
                

            string[] ALLOWED_HOSTS = parametres.allowed_hosts.Split(new char[] { ',' },StringSplitOptions.RemoveEmptyEntries);

            string[] auth = Request.GetHttpContext().Request.Headers.GetValues("Authorization");
            if (auth != null && auth.Length > 0)
            {
                if (!(auth[0].StartsWith("Bearer") && ( UserInfo.UserID != parametres.user_id_apiaccess || UserInfo.UserID<1)))
                {
                    if(ALLOWED_HOSTS.Contains<string>(Request.GetIPAddress()))
                    {
                        Functions.Log(new Exception(prefixe.Replace("Erreur a", "A")) { 
                        Source= "Ip client : " + Request.GetIPAddress() + ", User id : " + UserInfo.Username
                        },DotNetNuke.Services.Log.EventLog.EventLogController.EventLogType.LOGIN_SUCCESS);
                        return true;
                    }
                        
                    else
                        Functions.Error(new Exception(prefixe + "hôte " + Request.GetIPAddress()+" non autorisé"));
                }
                else
                {
                    Functions.Error(new Exception(prefixe + "utilisateur non autorisé"));
                }
               
            }
            else
            {
                Functions.Error(new Exception(prefixe + "bearer non fourni"));
            }
            
            return false;
        }
     

        [HttpGet]        
        [DnnAuthorize(AuthTypes = "JWT")]
        public HttpResponseMessage Hello()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "is it me you looking for ?");
        }

      
        [HttpGet]
        [AllowAnonymous]
        [DnnAuthorize(AuthTypes = "JWT")]
        public HttpResponseMessage Membres()
        {
            try
            {
                if(!CheckAccess())
                    return Request.CreateResponse(HttpStatusCode.Unauthorized);



                List<RotaryMag.Membre> membres = new List<RotaryMag.Membre>();
                
                var members = Yemon.dnn.DataMapping.ExecSql<Member>(new SqlCommand("SELECT " +
                    "[nim],[honorary_member],[surname],[name],[cric],[active_member]"+
                    ",[civility],[maiden_name],[spouse_name],[title],[birth_year]"+
                    ",[year_membership_rotary],[email],[adress_1],[adress_2],[adress_3]"+
                    ",[zip_code],[town],[telephone],[fax],[gsm],[country],[job],[industry]"+
                    ",[biography],[base_dtupdate],[professionnal_adress],[professionnal_zip_code]"+
                    ",[professionnal_town],[professionnal_tel],[professionnal_fax],[professionnal_mobile]"+
                    ",[professionnal_email],[retired],[removed],[district_id],[club_name],[annee_entree_club]"+
                    ",[phf],[legion_honneur],[ordre_merite],[palmes_academiques],[medaille_militaire],[croix_guerre]"+
                    ",[autre_decorations],[pro_secteur_activite],[fonction],[no_adr_pro],[professionnal_company]"+
                    ",[professionnal_additional],[professionnal_country],[ri_ad1],[ri_ad2],[ri_ad3],[ri_zip_code]"+
                    ",[ri_town],[ri_country],[dt_update_manuel_rodi],[dt_update_import_ri_club],[dt_update_import_ri_district]"+
                    ",[dt_update_import_rm]" +
                    " FROM " + Const.TABLE_PREFIX + "members " +
                    "WHERE honorary_member='N' AND " +
                    "cric IN (SELECT cric FROM " + Const.TABLE_PREFIX + "clubs WHERE type_club='rotary' AND rm_agreement_date IS NOT NULL) ORDER BY cric,surname,name "));
                
                foreach (var m in members)
                {
                    var membre = new RotaryMag.Membre();
                    membre.district_id = m.district_id;
                    membre.cric = m.cric;
                    membre.nim = m.nim;
                    membre.nom = m.surname;
                    membre.prenom = m.name;
                    membre.prenom_conjoint = m.spouse_name;
                    membre.civilite = (m.civility == "Mme" ? 2 : 1);
                    membre.annee_naissance = m.birth_year != null ? ((DateTime)m.birth_year).Year : 0;
                    membre.annee_adhesion = m.year_membership_rotary != null ? ((DateTime)m.year_membership_rotary).Year : 0;
                    membre.annee_entree_club = m.annee_entree_club;
                    membre.statut_pro = m.retired == "O" ?0 : 1;
                    membre.email = m.email;
                    membre.telephone = m.telephone;
                    membre.fax = m.fax;
                    membre.gsm = m.gsm;
                    membre.phf = m.phf;
                    membre.legion_honneur = m.legion_honneur;
                    membre.ordre_merite = m.ordre_merite;
                    membre.palmes_academiques = m.palmes_academiques;
                    membre.medaille_militaire = m.medaille_militaire;
                    membre.croix_guerre = m.croix_guerre;
                    membre.autre_decorations = m.autre_decorations;
                    membre.adresse = m.adress_1;
                    membre.complement1 = m.adress_2;
                    membre.codepostal = m.zip_code;
                    membre.localite = m.town;
                    membre.pays = m.country;
                    membre.telephone_pro = m.professionnal_tel;
                    //membre.fax_pro = m.professionnal_fax;
                    membre.pro_secteur_activite = m.pro_secteur_activite; // : industry
                    membre.pro_metier = m.job;
                    membre.pro_fonction = m.fonction;
                    membre.pro_raison_sociale = m.professionnal_company;
                    membre.no_adr_pro = m.no_adr_pro;
                    membre.pro_adresse = m.professionnal_adress;
                    membre.pro_complement1 = m.professionnal_additional;
                    membre.pro_codepostal = m.professionnal_zip_code;
                    membre.pro_localite = m.professionnal_town;
                    membre.pro_pays = m.professionnal_country;
                    //  Console.Write(m.professionnal_country + "\t" + membre.pro_pays + Environment.NewLine);
                    
                   // membre.pro_pays = m.professionnal_country;
                    membre.dt_update = ((DateTime)m.base_dtupdate).ToUniversalTime();

                    if (m.dt_update_manuel_rodi != null)
                        membre.dt_update_manuel_rodi = ((DateTime)m.dt_update_manuel_rodi).ToUniversalTime();
                    else
                        membre.dt_update_manuel_rodi = null;

                    if (m.dt_update_import_ri_club != null)
                        membre.dt_update_import_ri_club = ((DateTime)m.dt_update_import_ri_club).ToUniversalTime();
                    else
                        membre.dt_update_import_ri_club = null;

                    if (m.dt_update_import_ri_district != null)
                        membre.dt_update_import_ri_district = ((DateTime)m.dt_update_import_ri_district).ToUniversalTime();
                    else
                        membre.dt_update_import_ri_district = null;

                    if (m.dt_update_import_rm != null)
                        membre.dt_update_import_rm = ((DateTime)m.dt_update_import_rm).ToUniversalTime();
                    else
                        membre.dt_update_import_rm = null;

                    membres.Add(membre);
                }

                return Request.CreateResponse(HttpStatusCode.OK, membres);
            }
            catch(Exception e)
            {
                Functions.Error(e);
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            
        }

        [HttpGet]
        [AllowAnonymous]
        [DnnAuthorize(AuthTypes = "JWT")]
        public HttpResponseMessage Clubs()
        {
            try
            {
                if (!CheckAccess())
                    return Request.CreateResponse(HttpStatusCode.Unauthorized);

                List<RotaryMag.Club> clubs = new List<RotaryMag.Club>();

                var cc = DataMapping.ListClubs(club_type: "rotary",sort:"name asc");
                foreach(var c in cc)
                {
                    if(c.rm_agreement_date != null)
                    {
                        var club = new RotaryMag.Club();
                        club.cric = c.cric;
                        club.district_id = c.district_id;
                        club.nom = c.name;
                        club.adresse = c.adress_1;
                        club.complement_1 = c.adress_2;
                        club.complement_2 = c.adress_3;
                        club.codepostal = c.zip;
                        club.ville = c.town;
                        club.reunions = c.meetings;
                        club.telephone = c.telephone;
                        club.fax = c.fax;
                        club.email = c.email;
                        club.web = c.web;
                        club.presentation = c.text;
                        club.latitude = c.latitude;
                        club.longitude = c.longitude;
                        club.reunion_adr1 = c.meeting_adr1;
                        club.reunion_adr2 = c.meeting_adr2;
                        club.reunion_zip = c.meeting_zip;
                        club.reunion_town = c.meeting_town;


                        club.annee_charte = c.charter_year;
                        club.accord_date = c.rm_agreement_date;
                        club.accord_nom = c.rm_agreement_name;
                        club.accord_prenom = c.rm_agreement_firstname;
                        club.accord_fonction = c.rm_agreement_function;


                        clubs.Add(club);

                    }
                }

                return Request.CreateResponse(HttpStatusCode.OK, clubs);
            }
            catch (Exception e)
            {
                Functions.Error(e);
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }

        }

        [HttpGet]
        [AllowAnonymous]
        [DnnAuthorize(AuthTypes = "JWT")]
        public HttpResponseMessage Dico()
        {
            try
            {
                if (!CheckAccess())
                    return Request.CreateResponse(HttpStatusCode.Unauthorized);

                var _param = RotaryMagHelper.GetParametres();
                if( _param == null )
                    return Request.CreateResponse(HttpStatusCode.NotFound);

                return Request.CreateResponse(HttpStatusCode.OK, _param.dico);
            }
            catch (Exception e)
            {
                Functions.Error(e);
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }

        }

        [HttpGet]
        [AllowAnonymous]
        [DnnAuthorize(AuthTypes = "JWT")]
        public HttpResponseMessage Affectations()
        {
            try
            {
                if (!CheckAccess())
                    return Request.CreateResponse(HttpStatusCode.Unauthorized);



                List<RotaryMag.Affectation> affectations = Yemon.dnn.DataMapping.ExecSql<RotaryMag.Affectation>(
                    new SqlCommand("SELECT [rotary_year] as annee,[function] as fonction,[cric],[nim] " +
                    "FROM " + Const.TABLE_PREFIX + "rya " +
                    "WHERE [function] in (select value from " + Const.TABLE_PREFIX + "domain where domain='Fonctions Rotarienne RotaryMag') and " +
                    "cric in (select cric from " + Const.TABLE_PREFIX + "clubs where type_club='rotary') AND " +
                    "rotary_year in ("+ Functions.GetRotaryYear()+","+ (Functions.GetRotaryYear() +1)+ ")"));

                return Request.CreateResponse(HttpStatusCode.OK, affectations);
            }
            catch (Exception e)
            {
                Functions.Error(e);
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }

        }

    }
}
