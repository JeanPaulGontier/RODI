using DotNetNuke.Entities.Portals;
using Org.BouncyCastle.Utilities.Date;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Description résumée de RotaryMag
/// types de données RotaryMag
/// </summary>
public class RotaryMag
{
    public class Parametres
    {
        // url rotarymag pour login et extend token
        public string jwt_url_login { get; set; }
        public string jwt_url_extendtoken { get; set; }

        // url endpoint rotarymag pour récupérer les membres
        public string url_membres { get; set; }
        // url endpoint rotarymag pour accéder à l'annuaire francophone
        public string url_annuaire { get; set; }

        // login & pass pour token JWT rotarymag
        public string jwt_username { get; set; }
        public string jwt_password { get; set; }

        public Dico dico { get; set; }
        public int user_id_apiaccess { get; set; }
        // ips ou hosts autorisés,séparé par virgules
        public string allowed_hosts {  get; set; }

    
    }


    public class Dico
    {
        public string nom { get; set; }
        public string prenom { get; set; }
        public string email { get; set; }   
        public string telephone { get; set; }
        public int district_id { get; set; }
        public int nim { get; set; }
        public int cric { get; set; }
        public string nom_club { get; set; }
    }

    public class Membre
    {
        public int district_id { get; set; }
        public int cric { get; set; }
        public int nim { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string prenom_conjoint { get; set; }
        public int civilite { get; set; }
        public int annee_naissance { get; set; }    
        public int annee_adhesion { get; set; }
        public int annee_entree_club { get; set; }
        public int statut_pro { get; set; }
        public string email { get; set; }
        public string telephone { get; set;}
        public string fax { get; set; }
        public string gsm { get; set; }
        public string phf { get; set; }
        public string legion_honneur { get; set; }
        public string ordre_merite { get; set; }
        public string palmes_academiques { get; set; }
        public int medaille_militaire { get; set; } 
        public int croix_guerre { get; set; }
        public int autre_decorations { get; set; }
        public string adresse { get; set; }
        public string complement1 { get; set; }
        public string codepostal { get; set; }
        public string localite {  get; set; }
        public string pays {  get; set; }
        public string telephone_pro { get; set; }
        public string fax_pro { get; set; }
        public int pro_secteur_activite { get; set; }
        public string pro_metier {  get; set; }
        public string pro_fonction { get; set; }
        public string pro_raison_sociale { get; set; }
        public int no_adr_pro { get; set; }
        public string pro_adresse { get; set; }
        public string pro_complement1 { get; set; }
        public string pro_codepostal { get; set; }
        public string pro_localite { get; set; }
        public string pro_pays { get; set; }
        public DateTime dt_update { get; set; }
        public DateTime? dt_update_manuel_rodi {  get; set; }
        public DateTime? dt_update_import_ri_club { get; set; }
        public DateTime? dt_update_import_ri_district { get; set; }
        public DateTime? dt_update_import_rm {  get; set; }
    }

    public class Club
    {
        public int cric {  get; set; }
        public int district_id { get; set; }
        public string nom { get; set; }
        public string adresse { get; set; }
        public string complement_1 { get; set; }
        public string complement_2 { get; set;}
        public string codepostal { get; set; }
        public string ville { get; set; }
        public string reunions { get; set; }
        public string telephone { get; set; }
        public string fax { get; set; }
        public string email { get; set; }
        public string web {  get; set; }
        public string presentation { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string reunion_adr1 { get; set; }
        public string reunion_adr2 { get; set; }
        public string reunion_zip {  get; set; }
        public string reunion_town { get; set; }
        public int annee_charte { get; set; }
        public DateTime accord_date { get; set; }
        public string accord_nom { get; set; }
        public string accord_prenom { get; set; }
        public string accord_fonction { get; set; }

    }

    public class Affectation
    {
        public int cric { get; set; }
        public int nim { get; set; }
        public string fonction { get; set; }
        public int annee { get; set; }
    }

    public class Membre_Recherche
    {
        public int district { get; set; }
        public string nom_club { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string email { get; set; }
        public string telephone { get; set; }
        public string gsm { get; set; }
        public string roles_rotariens { get; set; }
        public string secteur_activite { get; set; }
        public string metier { get; set; }
        public string fonction { get; set; }

    }

    
}