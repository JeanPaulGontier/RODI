using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetNuke.Entities.Portals;

namespace AIS
{
    public class Nouvelle
    {
        public string id { get; set; }
        public int cric { get; set; }
        public DateTime dt { get; set; }
        public string titre { get; set; }
        public string texte { get; set; }
        public string url { get; set; }
        public string url_texte { get; set; }
        public string photo { get; set; }
        public string categorie { get; set; }
        public string tag1 { get; set; }
        public string tag2 { get; set; }
        public string nom_club { get; set; }
        public string visible { get; set; }
        public string PhotoString64 { get; set; }
        public string urlNouvelle { get; set; }
        public string type_club { get; set; }

        /// <summary>
        /// retourne le chemin de la photo
        /// avec le nom du club en prefixe s'il s'agit d'une news club
        /// ou district
        /// </summary>
        /// <returns></returns>
        public string GetPhoto()
        {
            string chemin = PortalSettings.Current.HomeDirectory;
            if (photo == "")
                return Const.no_image;
            if (nom_club != null && nom_club != "")
                chemin += Const.CLUBS_PREFIX + nom_club.Replace(" ", "-").Replace("'", "-").ToLower() + "/";
            else if (photo.StartsWith("/"))
                return photo;
            else
                chemin += Const.DISTRICT_PREFIX;
            return chemin + Const.IMG_PREFIX + photo;
        }
        /// <summary>
        /// retour l'url du document a télécharger avec le nom du club en préfixe
        /// ou district
        /// sauf si l'url est http... alors la retourne telle quelle
        /// </summary>
        /// <returns></returns>
        public string GetUrl()
        {
            if (url == null || url == "")
                return "";
            if (url.StartsWith("http"))
                return url;

            string chemin = PortalSettings.Current.HomeDirectory;
            if (nom_club != null && nom_club != "")
                chemin += Const.CLUBS_PREFIX + nom_club.Replace(" ", "-").Replace("'", "-").ToLower() + "/";
            else
                chemin += Const.DISTRICT_PREFIX;
            return chemin + Const.DOCUMENT_PREFIX + url;
        }
    }
}
