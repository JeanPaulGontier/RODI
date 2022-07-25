
#region Copyrights

//
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
using System.Text;
using System.IO;
using System.Net;
using System.Xml;
using AIS;
using DotNetNuke.Common;

namespace AIS
{
    public static class Maps
    {

        public static string[] ResolveAddress(string query)
        {
            string url = "http://maps.googleapis.com/maps/api/geocode/xml?address={0}&sensor=true";

            url = String.Format(url, query);

            XmlNode coords = null;

            try
            {

                string xmlString = GetUrl(url);

                XmlDocument xd = new XmlDocument();
                xd.LoadXml(xmlString);
                coords = xd.GetElementsByTagName("location")[0];
                string[] coordinateArray = new string[2];
                coordinateArray[0] = coords.ChildNodes[0].FirstChild.InnerText;
                coordinateArray[1] = coords.ChildNodes[1].FirstChild.InnerText;
                if (coordinateArray.Length >= 2)
                {
                    return coordinateArray;
                }
                else
                {
                    return null;
                }


            }
            catch { return null; }
            
            }

        /// <summary>
        /// Retourne en [0] la latitude et en [1] la longitude
        /// </summary>
        /// <param name="address"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="postcode"></param>
        /// <param name="country"></param>
        /// <returns></returns>
        public static string[] ResolveAddress(string address, string city, string state, string postcode, string country)
        {
            return ResolveAddress(address + "," + city + "," + state + "," + postcode + "," + country);
        }

        
        /// Retrieve a Url via WebClient
        private static string GetUrl(string url)
        {
            string result = string.Empty;

            System.Net.WebClient Client = new WebClient();

            using (Stream strm = Client.OpenRead(url))
            {

                StreamReader sr = new StreamReader(strm);

                result = sr.ReadToEnd();

            }
            return result;

        }

        /// <summary>
        /// Génère les coordonnées de la carte google en fonction de différents coordonnées
        /// </summary>
        /// <param name="Liste_lat"></param>
        /// <param name="Liste_lng"></param>
        /// <returns></returns>
        public static string Coord_Centre(List<string> Liste_lat, List<string> Liste_lng)
        {
            List<double> lat = new List<double>();
            List<double> lng = new List<double>();

            foreach (string sLat in Liste_lat)
            {
                string lati = sLat.Replace('.', ',');
                double la;
                double.TryParse(lati, out la);
                if (la >= 0) { lat.Add(Convert.ToDouble(la)); }
            }

            foreach (string sLong in Liste_lng)
            {
                string longi = sLong.Replace('.', ',');
                double lg;
                double.TryParse(longi, out lg);
                if (lg >= 0) { lng.Add(Convert.ToDouble(lg)); }
            }

            if (lat != null && lng != null)
            {
                string coord_Carte = "" + lat.Average().ToString().Replace(',', '.') + "," + lng.Average().ToString().Replace(',', '.');
                return coord_Carte;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Génère le script des marqueurs pour la google map
        /// </summary>
        /// <param name="Liste_panneaux"></param>
        /// <returns></returns>
        public static string Marqueur(List<Club> liste, string id_Panneau)
        {
            StringBuilder strBuilderJS = new StringBuilder();
            int i = 0;
                foreach (Club p in liste)
                {
                    if (!string.IsNullOrEmpty(p.latitude) && !string.IsNullOrEmpty(p.longitude))
                    {
                    i = i + 1; 
                    // On crée un marqueur personalisé :
                    strBuilderJS.AppendLine("var imageMarqueur = new google.maps.MarkerImage('" + Const.MARQUEUR + "');");
                    // On crée un marqueur
                    strBuilderJS.AppendLine("var marker" + i.ToString() + " = new google.maps.Marker({ ");
                    // On définit la position du marqueur
                    strBuilderJS.AppendLine("position: new google.maps.LatLng(" + p.latitude + ", " + p.longitude + "), ");
                    // On précise la carte à laquelle il s'attache
                    strBuilderJS.AppendLine("map: map, ");
                    // On indique le marqueur personalisé
                    strBuilderJS.AppendLine("icon: imageMarqueur,");
                    // On lui attribue un titre (infobulle au survol du curseur)
                    strBuilderJS.AppendLine("title: \"" + "Rotary club " + p.name + "\" }); ");

                    // On crée une infobulle
                    strBuilderJS.AppendLine("var infowindow" + i.ToString() + " = new google.maps.InfoWindow({ maxWidth: " + Const.Max_Width_InfoBulle + ", ");
                    // On définit la position d'origine de l'infoWindow (la position du marqueur)
                    strBuilderJS.AppendLine("position: new google.maps.LatLng(" + p.latitude + ", " + p.longitude + "), ");

                    // On définit le texte à afficher dans l'infoWindow
                    //string url_devis = Globals.NavigateURL(Const.DEVIS_TABID);
                    //string url_video = Functions.UrlAddParam(Globals.NavigateURL(Const.XXX), "reference", p.url_camera);
                    //string url_photo = Functions.UrlAddParam(Globals.NavigateURL(Const.XXX), "reference", p.url_photo);

                    string s_Adresse = "<BR />" + p.adress_1 + "<BR />" + p.zip + " " + p.town;
                    string s_Tel = "<BR />Tél. : " + p.telephone;
                    string s_Email = "<BR />Mél : " + p.email;
                    //string s_video = "<BR>Pour visualiser la video du panneau, veuillez cliquer <a href='" + url_video + "'>ici</a>";
                    //string s_photos = "<BR>Pour visualiser les photos du panneau, veuillez cliquer <a href='" + url_photo + "'>ici</a>";
                    string s_Web = "<BR /><a href='" + p.web + "'>Site web</a>";

                    strBuilderJS.AppendLine("content: \"<b>" + p.name +"</b>"+  s_Adresse + s_Tel + s_Email + s_Web + "\" });");
                    //string url_Iframe = Functions.UrlAddParam(Const.URL_IFRAME, "id", p.id_panneau.ToString());
                    //strBuilderJS.AppendLine("content: \"<iframe src='" + url_Iframe + "' width='" + Const.WIDTH_IFRAME + "' height='" + Const.HEIGHT_IFRAME + "'</iframe> \" });");

                    // On ajoute un listener d'événement : on écoute le clic sur le marqueur
                    strBuilderJS.AppendLine("google.maps.event.addDomListener(marker" + i.ToString() + ", 'click', function() { ");
                    // Ouverture de l'infobulle
                    strBuilderJS.AppendLine("infowindow" + i.ToString() + ".open(map, marker" + i.ToString() + "); }); ");

                    //if(!string.IsNullOrEmpty(id_Panneau))
                    //{
                    //    int? marqueur_Open = Convert.ToInt32(id_Panneau);
                    //    if(p.id_panneau == marqueur_Open)
                    //    {
                    //        // Ouverture de l'infobulle
                    //        strBuilderJS.AppendLine("infowindow" + i.ToString() + ".open(map, marker" + i.ToString() + ");");
                    //    }
                    //}
                }
            }

            if (strBuilderJS != null)
            {
                return strBuilderJS.ToString();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Génère le script des polyline pour la google map
        /// </summary>
        /// <param name="Liste_panneaux"></param>
        /// <returns></returns>
        //public static string Reseaux(List<Reseau> Liste_Reseaux)
        //{
        //    StringBuilder strBuilderJS = new StringBuilder();
        //    int i = 0;
        //    foreach (Reseau R in Liste_Reseaux)
        //    { 
        //        i = i + 1;
        //        if (!string.IsNullOrEmpty(R.borne1_latitude) && !string.IsNullOrEmpty(R.borne1_longitude) && !string.IsNullOrEmpty(R.borne2_latitude) && !string.IsNullOrEmpty(R.borne2_longitude) && !string.IsNullOrEmpty(R.borne3_latitude) && !string.IsNullOrEmpty(R.borne3_longitude))
        //        {
        //            //sommets du polygone
        //            strBuilderJS.AppendLine("var parcelleHeig" + i.ToString() + " = [");
        //                // On définit la position du sommet de la borne 1
        //                strBuilderJS.AppendLine("new google.maps.LatLng(" + R.borne1_latitude + ", " + R.borne1_longitude + "),");
        //                // On définit la position du sommet de la borne 2
        //                strBuilderJS.AppendLine("new google.maps.LatLng(" + R.borne2_latitude + ", " + R.borne2_longitude + "),");
        //                // On définit la position du sommet de la borne 3
        //                strBuilderJS.AppendLine("new google.maps.LatLng(" + R.borne3_latitude + ", " + R.borne3_longitude + ")");
        //        }

        //        if(!string.IsNullOrEmpty(R.borne4_latitude) && !string.IsNullOrEmpty(R.borne4_longitude))
        //        {
        //            // On définit la position du sommet de la borne 4
        //            strBuilderJS.AppendLine(", new google.maps.LatLng(" + R.borne4_latitude + ", " + R.borne4_longitude + ")");
        //        }

        //        if(!string.IsNullOrEmpty(R.borne5_latitude) && !string.IsNullOrEmpty(R.borne5_longitude))
        //        {
        //            // On définit la position du sommet de la borne 5
        //            strBuilderJS.AppendLine(", new google.maps.LatLng(" + R.borne5_latitude + ", " + R.borne5_longitude + ")");
        //        }

        //        if(!string.IsNullOrEmpty(R.borne6_latitude) && !string.IsNullOrEmpty(R.borne6_longitude))
        //        {
        //            // On définit la position du sommet de la borne 6
        //            strBuilderJS.AppendLine(", new google.maps.LatLng(" + R.borne6_latitude + ", " + R.borne6_longitude + ")");
        //        }

        //        strBuilderJS.AppendLine("];");
        //        strBuilderJS.AppendLine("polygoneParcelleHeig" + i.ToString() + " = new google.maps.Polygon({");
        //        strBuilderJS.AppendLine("paths: parcelleHeig" + i.ToString() + " ,");
        //        //couleur des bords du polygone
        //        strBuilderJS.AppendLine("strokeColor: \"" + R.couleur_bord + "\",");
        //        //opacité des bords du polygone
        //        strBuilderJS.AppendLine("strokeOpacity: " + R.opacite_bord + ",");
        //        //épaisseur des bords du polygone
        //        strBuilderJS.AppendLine("strokeWeight: " + R.epaisseur_bord + ",");
        //        //couleur de remplissage du polygone
        //        strBuilderJS.AppendLine("fillColor: \"" + R.couleur_remplissage + "\",");
        //        //opacité de remplissage du polygone
        //        strBuilderJS.AppendLine("fillOpacity: " + R.opacite_remplissage + ",");
        //        strBuilderJS.AppendLine("});");
                
        //        //Pour l'event click sur la polyligne
        //        //strBuilderJS.AppendLine("google.maps.event.addListener(polygoneParcelleHeig" + i.ToString() + " , 'click', function() { alert('you clicked polyline'); });");

        //        if(!string.IsNullOrEmpty(R.commentaires))
        //        {
        //        // On crée une infobulle
        //        strBuilderJS.AppendLine("var reseauwindow" + i.ToString() + " = new google.maps.InfoWindow({ maxWidth: " + Const.Max_Width_InfoBulle + ", ");
        //        // On définit la position d'origine de l'infoWindow (la position du marqueur)
        //        strBuilderJS.AppendLine("position: new google.maps.LatLng(" + R.borne1_latitude + ", " + R.borne1_longitude + "), ");
        //        // On définit le texte à afficher dans l'infoWindow
        //        //Ajouter le commentaire
        //        string url_devis = Globals.NavigateURL(Const.DEVIS_TABID);
        //        strBuilderJS.AppendLine("content: \"" + R.commentaires + "<BR>Pour réaliser un devis, veuillez cliquer <a href='" + url_devis + "'>ici</a>\" });");

        //        // On ajoute un listener d'événement : on écoute le clic sur le marqueur
        //        strBuilderJS.AppendLine("google.maps.event.addListener(polygoneParcelleHeig" + i.ToString() + ", 'click', function(event) { ");
        //        // Ouverture de l'infobulle
        //        strBuilderJS.AppendLine("reseauwindow" + i.ToString() + ".open(map); }); ");
        //        }

        //        //lier le polygone à la carte
        //        strBuilderJS.AppendLine("polygoneParcelleHeig" + i.ToString() + ".setMap(map);");
        //    }

        //    if (strBuilderJS != null)
        //    {
        //        return strBuilderJS.ToString();
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        /// <summary>
        /// Génére le script pour la google map
        /// </summary>
        /// <param name="coord_Carte"></param>
        /// <param name="marqueurs"></param>
        /// <returns></returns>
        public static string Goole_Maps_Script(string coord_Carte, string marqueurs, string zonage, string zoom)
        {
            StringBuilder strBuilderJS = new StringBuilder();
            strBuilderJS.AppendLine("<script type='text/javascript'> ");
            strBuilderJS.AppendLine("window.onload = function() { ");

            // Création de la carte
            // On récupère le conteneur
            strBuilderJS.AppendLine("var mapdiv = document.getElementById(\"map_canvas\"); ");

            // On définit les options de la carte
            strBuilderJS.AppendLine("var myOptions = { ");
            // Niveau de zomm
            if (string.IsNullOrEmpty(zoom))
            {
                strBuilderJS.AppendLine("zoom: " + Const.ZOOM + ", ");
            }
            else
            {
                strBuilderJS.AppendLine("zoom: " + zoom + ", ");
            }
            // Coordonnées sur lesquelles centrer la carte (ici cood de la France)            
            if (!string.IsNullOrEmpty(coord_Carte))
            {
                strBuilderJS.AppendLine("center: new google.maps.LatLng(" + coord_Carte + "), ");
            }
            else
            {
                strBuilderJS.AppendLine("center: new google.maps.LatLng(" + Const.Coord_Centre_carte + "), ");
            }
            // Type de menu de changement de type de carte
            strBuilderJS.AppendLine("mapTypeControl: true, mapTypeControlOptions: { style: google.maps.MapTypeControlStyle.DROPDOWN_MENU }, ");
            // Type de la carte
            strBuilderJS.AppendLine("mapTypeId: google.maps.MapTypeId.ROADMAP, ");
            // Zoom
            strBuilderJS.AppendLine("zoomControl: true, zoomControlOptions: { style: google.maps.ZoomControlStyle.BIG }, ");
            // Échelle
            strBuilderJS.AppendLine("scaleControl: true, scaleControlOptions: { style: google.maps.ScaleControlStyle.DEFAULT, }, ");
            // Activer pegman (Street View)
            strBuilderJS.AppendLine("streetViewControl: true }; ");

            // On affiche la carte
            strBuilderJS.AppendLine("var map = new google.maps.Map(mapdiv, myOptions); ");

            // On récupère les marqueurs
            if (!string.IsNullOrEmpty(marqueurs))
            {
                strBuilderJS.AppendLine(marqueurs);
            }

            // On récupère le zonage
            if (!string.IsNullOrEmpty(zonage))
            {
                strBuilderJS.AppendLine(zonage);
            }

            strBuilderJS.AppendLine("} ");
            strBuilderJS.AppendLine("</script>");

            return strBuilderJS.ToString();
        }

        public static string Google_Map(string id_panneau, string zoom)
        {
            string leScript = "";

            List<Club> LC = DataMapping.ListClubs();

            List<string> liste_lat = new List<string>();
            List<string> liste_long = new List<string>();
            foreach (Club p in LC)
            {
                if (!string.IsNullOrEmpty(p.latitude) && !string.IsNullOrEmpty(p.longitude))
                {
                    liste_lat.Add(p.latitude);
                    liste_long.Add(p.longitude);
                }
            }

            // On récupère les coordonnées de centrage de la carte
            string coord_Carte = Maps.Coord_Centre(liste_lat, liste_long);

            // On récupère les marqueurs
            string marqueurs =  Maps.Marqueur(LC, id_panneau);

            // On récupère le zonage
            //string zonage = "";
            //List<Reseau> Les_reseaux = DataMapping.Get_Reseau();
            //if (Les_reseaux != null)
            //{
            //    zonage = Maps.Reseaux(Les_reseaux);
            //}

            // On récupère le script de la google maps
            leScript = Maps.Goole_Maps_Script(coord_Carte, marqueurs, "", zoom);

            return leScript;

        }

    }
}
