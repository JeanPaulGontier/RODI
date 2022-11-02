using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetNuke.Entities.Portals;

namespace AIS
{
    [Serializable]
    public class Membre
    {
        
        public int id { get; set; }
        public int nim { get; set; }
        public string membre_honneur { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public int cric { get; set; }
        public string membre_actif { get; set; }
        public string civilite { get; set; }
        public string nom_jeune_fille { get; set; }
        public string prenom_conjoint { get; set; }
        public string titre { get; set; }
        public DateTime? annee_naissance { get; set; }
        public DateTime? annee_adhesion_rotary { get; set; }
        public string email { get; set; }
        public string adresse_1 { get; set; }
        public string adresse_2 { get; set; }
        public string adresse_3 { get; set; }
        public string code_postal { get; set; }
        public string ville { get; set; }
        public string telephone { get; set; }
        public string fax { get; set; }
        public string gsm { get; set; }
        public string pays { get; set; }
        public string fonction_metier { get; set; }
        public string branche_activite { get; set; }
        public string biographie { get; set; }
        public DateTime? date_majbase { get; set; }
        public string adresse_professionnelle { get; set; }
        public string code_postal_professionnel { get; set; }
        public string ville_professionnel { get; set; }
        public string tel_professionnel { get; set; }
        public string fax_professionnel { get; set; }
        public string portable_professionnel { get; set; }
        public string email_professionnel { get; set; }
        public string retraite { get; set; }
        public string radie { get; set; }
        public int district_id { get; set; }
        public string nom_club { get; set; }
        public int userid { get; set; }
        public string photo { get; set; }
        public string visible { get; set; }
        public bool presentation { get; set; }
        public string fonction_rotarienne { get; set; }



        public string GetPhoto()
        {
            string chemin = PortalSettings.Current.HomeDirectory;
            chemin += Const.MEMBERS_PHOTOS_PREFIX;
            if (string.IsNullOrEmpty(photo))
            {
                if (civilite == "M")
                    chemin = Const.MEMBERS_NOPHOTO_H;
                else
                    chemin = Const.MEMBERS_NOPHOTO_F;
            }
            else
            {
                chemin += photo;
            }
            return chemin;
        }
        public bool IsWoman()
        {
            if (civilite == null)
                return false;
            return civilite.Equals("Mme") || civilite.Equals("Mlle");
        }
    }
}

