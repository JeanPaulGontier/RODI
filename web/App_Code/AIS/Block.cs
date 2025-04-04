#region Copyrights

//
// RODI - https://rodi-platform.org
// Copyright (c) 2012-2025
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

using DotNetNuke.Entities.Portals;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
/// Définitions de blocks spécifiques pour le BlockContent
/// </summary>
/// 
namespace AIS
{

    public class Block : Yemon.dnn.BlocksContent.Block
    {

        public static string[,] ColorsList(){
             try {
                var path = "/Portals/" + PortalSettings.Current.PortalId + "/blockcontent/colors.txt";
                var dir = HttpContext.Current.Server.MapPath(path);

                string colors = System.IO.File.ReadAllText(dir);
                string[] c = colors.Split(new string[]{Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
                string[,] list = new string[c.Length, 2];
                int i = 0;
                foreach (var s in c)
                {
                    if(s.IndexOf(";")>0)
                    {
                        list[i, 0] = s.Substring(0, s.IndexOf(";"));
                        list[i, 1] = s.Substring(s.IndexOf(";")+1);
                        i++;
                    }
                }
                return list;
            }catch(Exception ex){
                Functions.Error(new Exception("blockcontent colors not found"));
            }
            return null;
        }

        private static List<string> FileList(string path)
        {
            var list = new List<string>();
            var dir = HttpContext.Current.Server.MapPath(path);

            foreach (var fi in Directory.GetFiles(dir))
            {

                list.Add(path + fi.Replace(dir, "").Replace("\\", "/"));
            }
            return list;
        }

        public class Uri {
            public string Href { get; set; }
            public string Target { get; set; }
            public string Label { get; set; }
        }

        public class NewsClub
        {
            public string Title { get; set; }
            public int NBToShow { get; set; }
            public string DateBehavior { get; set; }
            public bool ShowImage { get; set; }
            public bool ShowTitle { get; set; }
            public bool ShowDate { get; set; }
        }

        public class Banner
        {
            public static readonly string THUMBNAIL = "/Portals/" + PortalSettings.Current.PortalId + "/blockcontent/banner.jpg";

            public string Title { get; set; }
            public string Title2 { get; set; }
            public string Title3 { get; set; }
            public int Type { get; set; } // 1 : picture, 2 : video , 3 : texture, 4 : color

            
            public Uri Uri { get; set; }

            public string Texture { get; set; }
            public string Video { get; set; }
            public string Image { get; set; }
            public string BGColor { get; set; }
            public string Color { get; set; }

            public string VideoThumbnail(){
                if (string.IsNullOrEmpty(Video))
                    return "";
                if (("" + Video).EndsWith(".mp4"))
                    return Video.Substring(0, Video.Length - 4) + ".jpg";
                return Video;
            }

            public static List<string> TextureList(){
                return FileList("/Portals/" + PortalSettings.Current.PortalId + "/blockcontent/banner-tex");
            }

            public static List<string> ImageList()
            {
                return FileList("/Portals/" + PortalSettings.Current.PortalId + "/blockcontent/banner-img");
            }

            public static List<string> VideoList()
            {
                return FileList("/Portals/" + PortalSettings.Current.PortalId + "/blockcontent/banner-vid").FindAll(s => s.EndsWith(".mp4"));
            }
        }

        public class NewsCards
        {
            public static readonly string THUMBNAIL = "/Portals/" + PortalSettings.Current.PortalId + "/blockcontent/newscards.jpg";

            public string Title { get; set; }
            public string Description { get; set; }
            public Uri Uri_District { get; set; }
            public Uri Uri_Clubs { get; set; }
            public bool District { get; set; }
            public bool Clubs { get; set; }
            public bool Next { get; set; }
            public string Tags_Included { get; set; }
            public string Tags_Excluded { get; set; }
            private const int NBMax = 3;
            public string Color { get; set; }

            public NewsCards() 
            {
                Tags_Excluded = "";
                Tags_Included = "";
            }

            public static String[] TagsList()
            {
                try{
                    var table = Yemon.dnn.DataMapping.ExecSql("SELECT DISTINCT tag1 FROM " + Const.TABLE_PREFIX + "news WHERE category IN ('Clubs','District') AND tag1 !='' AND tag1 IS NOT null ORDER BY tag1");
                    var liste = new List<string>();
                    if (table != null)
                        foreach (System.Data.DataRow r in table.Rows)
                            liste.Add(""+r[0]);
                            
                    return liste.ToArray();
                }catch{
                    
                }
                return new String[1];
            }

            private List<News> _news;
            public List<News> News
            {
                get
                {
                    
                    if (_news == null){
                        string[] tags_included = (""+Tags_Included).Split(new string[] { Environment.NewLine },StringSplitOptions.RemoveEmptyEntries);
                        string[] tags_excluded = ("" + Tags_Excluded).Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                        DateTime today = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

                        List<News> liste = new List<News>();
                        string category = "Tous";
                        if (Clubs && !District)
                            category = "Clubs";
                        if (!Clubs && District)
                            category = "District";

                        _news = new List<News>();

                        if (Clubs || District)
                        {

                        

                            if(Next)
                            {
                                liste = DataMapping.ListNews_EN(category: category,
                                                                tags_included: Tags_Included,
                                                                tags_excluded: Tags_Excluded,
                                                                tri: "dt ASC",
                                                                max: 100,
                                                                where: " dt>='" + today + "'",
                                                                onlyvisible: true);

                            }
                            else
                            {
                                liste = DataMapping.ListNews_EN(category: category,
                                                                    tags_included: Tags_Included,
                                                                    tags_excluded: Tags_Excluded,
                                                                    tri:"dt DESC",
                                                                    max:100,
                                                                    where:" dt<'"+today+"'",
                                                                    onlyvisible: true);

                            }
                        
                            

                            int i = 0;
                            foreach(News n in liste)
                            {
                                if(n.GetPhoto()!= Const.no_image)
                                {
                                    if(String.IsNullOrEmpty(Tags_Included) || (tags_included.Length>0 && tags_included.Contains(n.tag1)))
                                    {
                                        if(String.IsNullOrEmpty(Tags_Excluded) ||(tags_excluded.Length>0 && !tags_excluded.Contains(n.tag1)))
                                        {
                                            _news.Add(n);
                                            i++;                                        
                                        }                                    
                                    }                                
                                }
                                if (i == NBMax)
                                    break;
                            }
                        }

                    }
                    return _news;
                }
            }
        }

        public class Infos
        {
            public static readonly string THUMBNAIL = "/Portals/" + PortalSettings.Current.PortalId + "/blockcontent/infos.jpg";

            public string Title { get; set; }
            public string Title2 { get; set; }

            public Uri Uri { get; set; }

            public int Counter1 { get; set; }
            public string Label1 { get; set; }

            public int Counter2 { get; set; }
            public string Label2 { get; set; }

            public int Counter3 { get; set; }
            public string Label3 { get; set; }

            public string Image { get; set; }

            public static List<string> ImageList()
            {
                return FileList("/Portals/" + PortalSettings.Current.PortalId + "/blockcontent/infos-img");
            }
        }

        public class Bulles 
        {
            public static readonly string THUMBNAIL = "/Portals/" + PortalSettings.Current.PortalId + "/blockcontent/bulles.jpg";

            public string Title { get; set; }
            public string Description { get; set; }

            public Bulle[] List { get; set; }

            public Bulles(){
                List = new Bulle[7];
            }

            public static List<string> ImageList()
            {
                return FileList("/Portals/" + PortalSettings.Current.PortalId + "/blockcontent/bulles-img");
            }

            public class Bulle 
            {
                public string Image { get; set; }
                public Uri Uri { get; set; }
            }


        }

        public class Cards
        {
            public static readonly string THUMBNAIL = "/Portals/" + PortalSettings.Current.PortalId + "/blockcontent/cards.jpg";

            public string Title { get; set; }
            public string Description { get; set; }
            public List<Card> List { get; set; }
            public string BGColor { get; set; }
            public string Color { get; set; }

            public Cards(){
                List = new List<Card>();
            }

            public static List<string> ImageList()
            {
                return FileList("/Portals/" + PortalSettings.Current.PortalId + "/blockcontent/cards-img");
            }

            public class Card
            {
                public string Image { get; set; }
                public string Title { get; set; }
                public string Description { get; set; }
                public Uri Uri { get; set; }
            }
        }

        public class Button2Imgs
        {
            public static readonly string THUMBNAIL = "/Portals/" + PortalSettings.Current.PortalId + "/blockcontent/button2imgs.jpg";
            
            public string Title { get; set; }
            public string Description { get; set; }
            public string ImageGauche { get; set; }
            public string ImageDroite { get; set; }
            public string BGColor { get; set; }
            public string Color { get; set; }

            public Uri Uri { get; set; }
            
            public static List<string> ImageList()
            {
                return FileList("/Portals/" + PortalSettings.Current.PortalId + "/blockcontent/button2imgs-img");
            }
        }

        public class ButtonsBg
        {
            public static readonly string THUMBNAIL = "/Portals/" + PortalSettings.Current.PortalId + "/blockcontent/buttonsbg.jpg";
            public string Title { get; set; }
            public string Title2 { get; set; }
            public string BGColor { get; set; }
            public string Color { get; set; }

            public List<Uri> List { get; set; }

            public ButtonsBg(){
                List = new List<Uri>(); 
            }

            public static List<string> ImageList()
            {
                return FileList("/Portals/" + PortalSettings.Current.PortalId + "/blockcontent/buttonsbg-img");
            }
        }
    }
}