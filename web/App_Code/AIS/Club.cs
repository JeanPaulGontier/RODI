﻿#region Copyrights

//
// RODI - https://rodi-platform.org
// Copyright (c) 2012-2024
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIS
{
    [Serializable]
    public class Club
    {
        public int cric { get; set; }
        public int district_id { get; set; }
        public string name { get; set; }
        public string adress_1 { get; set; }
        public string adress_2 { get; set; }
        public string adress_3 { get; set; }
        public string zip { get; set; }
        public string town { get; set; }
        public string pennant { get; set; }
        public string meetings { get; set; }
        public string telephone { get; set; }
        public string fax { get; set; }
        public string email { get; set; }
        public string web { get; set; }
        public string text { get; set; }
        public string seo { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string meeting_adr1 { get; set; }
        public string meeting_adr2 { get; set; }
        public string meeting_zip { get; set; }
        public string meeting_town { get; set; }
        public string former_presidents { get; set; }
        public string club_type { get; set; }
        public string roles { get; set; }
        public string seo_mode { get; set; }
        public string domaine { get; set; }
        public string payment_method { get; set; }
        public double nb_free_of_charge { get; set; }
        public int charter_year { get; set; }
        #region RotaryMag Specific Fields
        public DateTime? rm_agreement_date { get; set; }
        public string rm_agreement_name { get; set; }
        public string rm_agreement_firstname { get; set; }
        public string rm_agreement_function { get; set; }
        #endregion

        public DateTime? rotary_agreement_date { get; set; }
        public string rotary_agreement_type { get; set; } // '': pas de synchronisation , 'auto': maj auto, 'analyse': analyse seulement


        public string GetSynchroRI()
        {
            if (rotary_agreement_date == null)
                return "Non autorisée";
            if (rotary_agreement_type == "")
                return "Non configurée";
            if (rotary_agreement_type == "auto")
                return "Automatique";
            if (rotary_agreement_type == "analyse")
                return "Seulement analyse";
            return "Non";
        }

        public string GetPennant()
        {
            string chemin = PortalSettings.Current.HomeDirectory;
            if (pennant == "")
                return "";

            return Functions.UrlAddParam(chemin + Const.CLUBS_PREFIX + Const.PENNANT_PREFIX + pennant,"v",""+DateTime.Now.Ticks) ;
        }

        public string GetPostalAdress()
        {
            string a = name + Environment.NewLine;
            if (adress_1 != "")
                a += adress_1 + Environment.NewLine;
            if (adress_2 != "")
                a += adress_2 + Environment.NewLine;
            if (adress_3 != "")
                a += adress_3 + Environment.NewLine;
            a += zip + " " + town;
            return a;
        }

        public bool IsSatellite
        {
            get
            {
                return Functions.GetClubParent(cric) > 0;
            }
        }

        public Club GetClubSatellite()
        {
            int cricsat = Functions.GetClubSatellite(cric);
            if (cricsat > 0)
            {
                var club = DataMapping.GetClub(cricsat);
                if (club != null)
                {
                    return club;
                }
            }
            return null;
        }

        public Club GetClubParent()
        {
            int cricparent = Functions.GetClubParent(cric);
            if (cricparent > 0)
            {
                var club = DataMapping.GetClub(cricparent);
                if (club != null)
                {
                    return club;
                }
            }
            return null;
        }
    }
}
