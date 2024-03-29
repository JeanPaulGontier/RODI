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
                    ",[professionnal_email],[retired],[removed],[district_id],[club_name]" +
                    " FROM " + Const.TABLE_PREFIX + "members " +
                    "WHERE honorary_member='N' AND " +
                    "cric IN (SELECT cric FROM " + Const.TABLE_PREFIX + "clubs WHERE type_club='rotary') ORDER BY surname,name "));
                
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
                    membre.statut_pro = m.active_member != "O" ?0 : 1;
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
                    membre.fax_pro = m.professionnal_fax;
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
                    membre.dt_update = m.base_dtupdate != null ? ((DateTime)m.base_dtupdate).ToUniversalTime() : DateTime.UtcNow;
                    membre.dt_update_manuel_rodi = m.dt_update_manuel_rodi;
                    membre.dt_update_import_ri_club = m.dt_update_import_ri_club;
                    membre.dt_update_import_ri_district = m.dt_update_import_ri_district;
                    membre.dt_update_import_rm = m.dt_update_import_rm;
                    
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


                    club.annee_charte = 0;
                    club.accord_date = DateTime.UtcNow;
                    club.accord_nom = "Doe";
                    club.accord_prenom = "John";
                    club.accord_fonction = "Fake";

             
                    clubs.Add(club);
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
