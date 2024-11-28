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
        public string Profile { get; set; }
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
                        if (role.MemberType=="Honorary Member")
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