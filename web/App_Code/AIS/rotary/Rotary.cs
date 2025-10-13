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
using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Linq;
using System.Web;


/// <summary>
/// Description résumée de Rotary
/// </summary>
public class Rotary
{
    public class Parametres
    {
        public string url_api { get; set; }
        public string api_username { get; set; }
        public string api_password { get; set; }
    }


    public class Club
    {
        public int? id { get; set; }
        public int ClubId { get; set; }
        public string ClubType { get; set; }
        public string ClubSubType { get; set; }
        public string ClubName { get; set; }
        public string ClubCountry { get; set; }
        public DateTime? CharterDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Subscription subscription { get; set; }
        public string Language { get; set; }
        public Members members { get; set; }

        public int DistrictId { get; set; }
        public string ZoneName { get; set; }
        public string ZoneSectionName { get; set; }
        public string ZoneSectionKey { get; set; }

        public List<RequestorOrganizations> requestorOrganizations { get; set; }

        public List<Address> Addresses { get; set; }
        public List<Email> EmailAddresses { get; set; }
        public List<Website> Websites { get; set; }
        public List<Phone> PhoneNumbers { get; set; }
        public List<Fax> FaxNumbers { get; set; }

        public string Key { get; set; }
        public DateTime? LastUpdated { get; set; }

        public int MemberCount {  get; set; }  
        public int HonoraryMemberCount { get; set; }
        public DateTime DtLastUpdate { get; set; }

       
        public class RequestorOrganizations
        {
            public string OrganizationType { get; set; }
            public string OrganizationName { get; set; }
            public bool Add { get; set; }
            public bool Edit { get; set; }
            public bool Delete { get; set; }
            public bool Get { get; set; }
            public bool IsPrefered { get; set; }
            public DateTime LastUpdated { get; set; }
        }

        public class Website
        {
            public int ClubId { get; set; }
            public string ClubType { get; set; }
            public string WebsiteAddress { get; set; }
            public string WebsiteType { get; set; }
            public bool IsPrimary { get; set; }
            public string Key {  get; set; }
            public DateTime LastUpdated { get; set; }
        }

        public class Phone
        {
            public int ClubId { get; set; }
            public string ClubType { get; set; }
            public string PhoneNumber { get; set; }
            public string PhoneExtension { get; set; }
            public string CountryCode { get; set; }
            public string PhoneCountryName { get; set; }
            public string PhoneType { get; set; }
            public bool IsPrimary { get; set; }
            public string Key { get; set; } 
            public DateTime LastUpdated { get; set; }
        }

        public class Fax : Phone
        {

        }

        public class Address
        {
            public string AddressType { get; set; }
            public string AddressLine1 { get; set; }
            public string AddressLine2 { get; set; }
            public string AddressLine3 { get; set; }
            public string Country { get; set; }
            public string State { get; set; }
            public string InternationalProvince { get; set; }
            public string City { get; set; }
            public string PostalCode { get; set; }
            public string MeetingName { get; set; }
            public string MeetingDay { get; set; }
            public string MeetingTime { get; set; }
            public string MeetingComment { get; set; }
            public int ClubId { get; set; }
            public string ClubType { get; set; }
            public bool IsPrimary { get; set; }
            public string MeetingType { get; set; }
            public string OnlineLocation { get; set; }
            public string MeetinglocationVariesFlag { get; set; }
            public string MeetingLocationName { get; set; }
            public string Key { get; set; }
            public DateTime LastUpdated { get; set; }
        }

        public class Email
        {
            public string EmailAddress { get; set; }
            public string EmailType { get; set; }
            public bool IsPrimary { get; set; }
            public int ClubId { get; set; }
            public string ClubType { get; set; }
            public string Key { get; set; } 
            public DateTime LastUpdated { get; set; }
        }

        public class Location
        {
            public string State { get; set; }
            public string InternationalProvince { get; set; }
            public string Country { get; set; }
        }

        public class Members
        {
            public int MemberCount { get; set; }
            public int HonoraryMemberCount { get; set; }
            public int AssociatedMemberCount { get; set; }
            public int SatelliteMemberCount { get; set; }
        }

        public class Subscription
        {
            public string Key { get; set; }
            public string Magazine { get; set; }
        }

        public class Officer
        {
            public int? id { get; set; }
            public int MemberId { get; set; }
            public int ClubId { get; set; }
            public string OfficerRole { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public string ClubName { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string MiddleName { get; set; }
            public string Suffix { get; set; }
            public string Key { get; set; }
            public DateTime LastUpdated { get; set; }

            public DateTime DtLastUpdate { get; set; }
        }

        public Club() 
        {
            requestorOrganizations = new List<RequestorOrganizations>(); 
        }

    }
    public class Sponsor
    {
        public int MemberId { get; set; }
        public int ClubId { get; set; }
        public string ClubType { get; set; }
        public int SponsorMemberId { get; set; }
        public string SponsorFirstName { get; set; }
        public string SponsorMiddleName { get; set; }
        public string SponsorLastName { get; set; }
        public string SponsorPrefix { get; set; }
        public string SponsorSuffix{ get; set; }
        public string Key { get; set; }
    }

    public class Role {
        public int MemberId { get; set; }
        public string IndividualKey { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string RoleKey { get; set; }
        public string role { get; set; }
        public int OrganizationId { get; set; }
        public string Organization { get; set; }
        public string OrganizationType { get; set; }
        public string Committee { get; set; }
        public string CommitteeType { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public bool IsDelegationEligible { get; set; }
        public Location Location { get; set; }
        public string TerminationReason { get; set; }
        public string Key { get; set; }
        public DateTime LastUpdated { get; set; }
    }

    public class Location
    {
        public string State { get; set; }
        public string InternationalProvince { get; set; }
        public string Country { get; set; }
    }

    public class Member
    {
        public int? id { get; set; }
        public int MemberId { get; set; }
        public int ClubId { get; set; }
        public string MemberType { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string AdmissionDate { get; set; }
        public bool IsHonoraryMember { get; set; }
        public bool IsSatelliteMember { get; set; }
        public DateTime DtLastUpdate { get; set; }

        #region specifique aux membres terminés
        public DateTime LastUpdated { get; set; }
        public string TerminationDate { get; set; }
        public string TerminationReason { get; set; }
        #endregion

        public string Profile { get; set; }
    }

    public class Member_Terminated
    {
        public int? id { get; set; }
        public int DistrictId { get; set; }
        public int ClubId { get; set; }
        public DateTime LastUpdated { get; set; }
        public DateTime TerminationDate { get; set; }
        public string TerminationReason { get; set; }
        public int MemberId { get; set; }        
        public string MemberType { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public DateTime AdmissionDate { get; set; }

       
    }

    public class Profile 
    {
        public Individual individual { get; set; }
        public List<Address> address { get; set; }
        public List<Phone> phone { get; set; }
        public List<Fax> fax { get; set; }
        public List<Email> email { get; set; }
        public List<Website> website { get; set; }
        public List<Language> language { get; set; }
        public List<Expertise> expertise { get; set; }
        public List<CurrentEmployers> currentemployers { get; set; }
        public List<Recognition> recognition { get; set; }

        public DateTime DtLastUpdate()
        {
            DateTime date = DateTime.MinValue;
            if (individual.LastUpdated>date)
                date = DateTime.MinValue;
            foreach (var a in address)
                if (a.LastUpdated > date)
                    date = a.LastUpdated;
            foreach (var a in email)
                if (a.LastUpdated > date)
                    date = a.LastUpdated;
            foreach (var a in fax)
                if (a.LastUpdated > date)
                    date = a.LastUpdated;
            foreach (var a in phone)
                if (a.LastUpdated > date)
                    date = a.LastUpdated;
            
            return date;
        }

        public Profile() 
        {
            address = new List<Address>();
            phone = new List<Phone>();
            fax = new List<Fax>();
            email = new List<Email>();
            website = new List<Website>();
            language = new List<Language>();
            expertise = new List<Expertise>();
            currentemployers = new List<CurrentEmployers>();
            recognition = new List<Recognition>();
        }

        public class Individual
        {
            public int MemberId { get; set; }
            public int ClubId { get; set; }
            public string Prefix { get; set; }
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string LastName { get; set; }
            public string Suffix { get; set; }
            public string BadgeName { get; set; }
            public string LocalizedName { get; set; }
            public string Gender { get; set; }
            public string DateOfBirth { get; set; }
            public string BirthYear { get; set; }
            public string PrimaryLanguage { get; set; }
            public string Classification { get; set; }
            public bool YouthFlag { get; set; }
            public string GenderDescription { get; set; }
            public string Key { get; set; }
            public DateTime LastUpdated { get; set; }
        }

        public class Email
        {
            public string Type { get; set; }
            public string Address { get; set; }
            public string EmailAddress 
            { 
                get {
                    return Address;
                } 
                set {
                    Address = value;
                } 
            }
            public string EmailType
            {
                get
                {
                    return Type;
                }
                set
                {
                    Type = value;
                }
            }
            public bool IsPrimary { get; set; }
            public int MemberId { get; set; }
            public bool IsOnlineId { get; set; }
            public string Key { get; set; }
            public DateTime LastUpdated { get; set; }
        }

        public class Language
        {
            public int MemberId { get; set; }
            public string LanguageName { get; set; }
            public bool Speak { get; set; }
            public bool Read { get; set; }
            public bool Prodiciency { get; set; }
            public bool IsPrimary { get; set; }
            public string Key { get; set; }
            public DateTime LastUpdated { get; set; }

        }

        public class Address
        {
            public string AddressType
            {
                get
                {
                    return Type;
                }
                set
                {
                    Type = value;
                }
            }
            public string AddressLine1
            {
                get
                {
                    return Line1;
                }
                set
                {
                    Line1 = value;
                }
            }
            public string AddressLine2
            {
                get
                {
                    return Line2;
                }
                set
                {
                    Line2 = value;
                }
            }
            public string AddressLine3
            {
                get
                {
                    return Line3;
                }
                set
                {
                    Line3 = value;
                }
            }
            public string Type { get; set; }
            public string Line1 { get; set; }
            public string Line2 { get; set; }
            public string Line3 { get; set; }
            public string Country { get; set; }
            public string State { get; set; }
            public string InternationalProvince { get; set; }
            public string City { get; set; }
            public string PostalCode { get; set; }
            public int MemberId { get; set; }
            public bool IsPrimary { get; set; }
            public string Key {  set; get; }
            public DateTime LastUpdated {  set; get; }
        }

        public class Phone
        {
            public int MemberId { get; set; }
            public string PhoneType
            {
                get
                {
                    return Type;
                }
                set
                {
                    Type = value;
                }
            }
            public string PhoneNumber
            {
                get
                {
                    return Number;
                }
                set
                {
                    Number = value;
                }
            }
            public string PhoneExtension
            {
                get
                {
                    return Extension;
                }
                set
                {
                    Extension = value;
                }
            }
            public string PhoneCountryCode
            {
                get
                {
                    return CountryCode;
                }
                set
                {
                    CountryCode = value;
                }
            }
            public string PhoneCountryName
            {
                get
                {
                    return Country;
                }
                set
                {
                    Country = value;
                }
            }

            public string Type { get; set; }
            public string Number { get; set; }
            public string Extension { get; set; }
            public string CountryCode { get; set; }
            public string Country { get; set; }
            public bool IsPrimary {  set; get; }
            public string Key {  get; set; }
            public DateTime LastUpdated { get; set; }
        }

        public class Fax: Phone
        {
           
        }

        public class Expertise
        {
            public int MemberId { get; set; }
            public string ExpertiseArea { get; set; }
            public string ExpertiseAreaKey { get; set; }
            public string ExpertiseLevel { get; set; }
            public string ExpertiseLevelKey { get; set; }
            public bool IsPrimary { get; set; }
            public string Key { get; set; }
            public DateTime LastUpdated { get; set; }
        }

        public class Role {
            public DateTime? AdmissionDate { get; set; }
            public bool IsSatelliteMember { get; set; }
            public string MemberType { get; set; }
            public DateTime? OriginalAdmissionDate { get; set; }
            public DateTime? TerminationDate { get; set; }
            public string TerminationReason { get; set; }
            public DateTime LastUpdated { get; set; }
        }

        public class Website
        {

        }

        public class CurrentEmployers{
            public int MemberId { get; set; }
            public string CurrentEmployer { get; set; }
            public string Position { get; set; }
            public string Occupation { get; set; }
            public bool IsPrimary { get; set; }
            public string Key { get; set; }
            public DateTime LastUpdated { get; set; }
        }

        public class Recognition {
            public string MajorDonor { get; set; }
            public string Bequest { get; set; }
            public string Benefactor { get; set; }
            public List<PaulHarrisFellow> paulharrisfellows { get; set; }
            public string Eligibility { get; set; }

            public class PaulHarrisFellow {
                public string Level { get; set; }
                public string Amount { get; set; }
                public float Points { get; set; }
            }
        }
    }

    
    public class Club_Members{
    
        public List<Member> ClubMembers { get; set; }

        public class Member : Profile.Individual {

            public bool IsHonoraryMember()
            {
                if (Role.Count > 0)
                {
                    foreach (var role in Role)
                    {
                        if (role.MemberType.Contains("Honorary Member"))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            public bool IsSatelliteMember(){
                if(Role.Count>0){
                    foreach(var role in Role)
                    {
                        if(role.IsSatelliteMember){
                            return true;
                        }
                    }
                }
                return false;
            }
            public DateTime DtLastUpdate(){
                DateTime date = DateTime.MinValue;
                if (LastUpdated > date)
                    date = LastUpdated;
                foreach (var a in Address)
                    if (a.LastUpdated > date)
                        date = a.LastUpdated;
                foreach (var a in Email)
                    if (a.LastUpdated > date)
                        date = a.LastUpdated;
                foreach (var a in Fax)
                    if (a.LastUpdated > date)
                        date = a.LastUpdated;
                foreach (var a in Phone)
                    if (a.LastUpdated > date)
                        date = a.LastUpdated;
                foreach (var a in Role)
                    if (a.LastUpdated > date)
                        date = a.LastUpdated;

                return date;
            }

            public List<Profile.Address> Address { get; set; }
            public List<Profile.Email> Email { get; set; }
            public List<Profile.Fax> Fax { get; set; }
            public List<Profile.Phone> Phone { get; set; }
            public List<Profile.Role> Role { get; set; }
           
        }
    }

    public class ClubLog
    {
        public int Cric { get; set; }
        public string Name { get; set; }
        public string Errors { get; set; }
        public string Logs { get; set; }

        public ClubLog(int cric, string name){
            Cric = cric;
            Name = name;
            Errors = "";
            Logs = "";
        }
    }

    public class Update
    {
        public int MemberId { get; set; }
        public string EntityType { get; set; }
        public string Key { get; set; }
        public DateTime LastUpdated {  get; set; } 
    }
}