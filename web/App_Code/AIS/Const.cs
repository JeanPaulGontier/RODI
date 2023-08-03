
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
using System.Web;

namespace AIS
{
    public static class Const
    {
        public const string NO = "N";
        public const string YES = "O";
        public const string NO_UF = "Non";
        public const string YES_UF = "Oui";
        public static DateTime NO_DATE = new DateTime(1900, 1, 1);
        public static int DISTRICT_ID = int.Parse("" + System.Configuration.ConfigurationManager.AppSettings["DistrictId"]);
        
        public static string DISTRICT_GUID = "" + System.Configuration.ConfigurationManager.AppSettings["DistrictGuid"];
        public static string DISTRICT_URL = "" + System.Configuration.ConfigurationManager.AppSettings["DistrictUrl"];
        public static string DISTRICT_TITLE = HttpUtility.HtmlDecode("" + System.Configuration.ConfigurationManager.AppSettings["DistrictTitle"]);
        public static string DISTRICT_LOGO_TITLE = HttpUtility.HtmlDecode("" + System.Configuration.ConfigurationManager.AppSettings["DistrictLogoTitle"]);

        public static int MENU_CLUB_ROOT_TABID = int.Parse("" + System.Configuration.ConfigurationManager.AppSettings["MenuClubRootTabId"]);
        public static int MENU_MEMBER_ROOT_TABID = int.Parse("" + System.Configuration.ConfigurationManager.AppSettings["MenuMemberRootTabId"]);

        public static string NOTIFICATIONS_DEBUG_DEST = "" + System.Configuration.ConfigurationManager.AppSettings["NotificationsDebugDest"];

        public static bool CLUB_SATELLITE_APART = (""+ System.Configuration.ConfigurationManager.AppSettings["ClubSatelliteApart"]).Equals("true");
        public static int[,] CLUB_SATELLITE_PARENT_CHILD
        {
            get
            {
                var parent = new int[0,0];
               
                string t = "" + System.Configuration.ConfigurationManager.AppSettings["ClubSatelliteParentChild"];
                if (t != "")
                {
                    try
                    {

                        parent = Yemon.dnn.Functions.Deserialize<int[,]>(t);
                    }
                    catch (Exception e)
                    {
                        Functions.Error(e);
                    }

                }

                return parent;
            }
        }

        public const string GoogleMapsKey = "AIzaSyBdbBwqDZJ2_E0UZ3m84pIgWd9Q4LXwQjU";
        public const string ZOOM = "7";
        public const string Coord_Centre_carte = "42.871938,7.002869";
        public static string MARQUEUR = System.Configuration.ConfigurationManager.AppSettings["DistrictUrl"];
        public static string Max_Width_InfoBulle = "0";

        public const string ROLE_MEMBERS = "Membres";
        public const string ROLE_ADMIN_DISTRICT = "Administrateur District";
        public const string ROLE_ADMIN_CLUB = "Administrateur Club";
        public const string ROLE_ADMIN_ROTARACT = "Administrateur Rotaract";
        public static string AFFECTATIONS_ADMIN_CLUB = ""+System.Configuration.ConfigurationManager.AppSettings["AffectationsAdminClub"];

        public const string no_image = "/images/1x1.gif";
        public const string TABLE_PREFIX = "ais_";
        public const string IMG_VIEWER_URL = "/AIS/AISMediaViewer.ashx";
        public const string MEDIA_DOWNLOAD_URL = "/AIS/download.aspx";
        public const string MEDIA_VIEW_URL = "/AIS/mediaview.aspx";
        public const string ORDER_VIEW_URL = "/AIS/commandeview.aspx";
        public const string ORDER_PAY_URL = "/EspaceMembre/MonClub/PaiementCommande.aspx";
        public const string MERCANET_RETURN_URL = "/Mercanet/response.aspx";
        public const string MEMBERS_AREA_URL = "/Espace-Membre";

        public static string IMG_PREFIX = "images/";
        public static string DOCUMENT_PREFIX = "documents/";
        public static string PENNANT_PREFIX = "fanions/";
        public static int PENNANT_PHOTOS_WIDTH = 200;

        public static string CLUBS_PREFIX = "clubs/";
        public static string CLUBS_MEDIA_PREFIX = "clubs/media/";
        public static string DISTRICT_PREFIX = "district/";

        public static string MEMBERS_NOPHOTO_H = "/images/no_avatar.gif";
        public static string MEMBERS_NOPHOTO_F = "/images/no_avatar.gif";

        public static string MEMBERS_CARTES_RECTO_MODELE = "/modeles/Carte_Membre_Recto.docx";
        public static string MEMBERS_CARTES_VERSO_MODELE = "/modeles/Carte_Membre_Verso.docx";
        public static string ORDER_MODELE = "/modeles/Commande.docx";


        public static string MEDIA_URL = "/DesktopModules/BlocksContent/API/Blocks/getMedia?guid=";

        public static string MEMBERS_PHOTOS_PREFIX = "membres/photos/";
        public static int MEMBERS_PHOTOS_WIDTH = 200;

        public static int NEWS_PHOTOS_WIDTH = 699;

        public static string ADMIN_ROLE = "Administrators";
        
        public static string[] cultures = new string[] { "FR" };
        public static string[] cultures2 = new string[] { "fr-FR" };

        public static string CONTENT_ANNOUNCEMENT_PREFIX = "Media/Annonces/";
        public static int CONTENT_PHOTOS_WIDTH = 200;
        public static string CONTENT_PRESENTATION_PREFIX = "Media/Presentations/";

        public static string Price_Presentation = "50";
        public static int Duration_Presentation = 12; //En mois

        public static string Price_Announcement = "20";
        public static int Duration_Announcement = 2;//En mois

        public static string Club_Rotaract = "rotaract";
        public static string Club_Rotary = "rotary";
        public static string Club_Interact = "interact";
    }
}
