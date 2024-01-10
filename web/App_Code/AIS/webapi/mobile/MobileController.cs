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

namespace AIS.controller
{
    public class MobileController : DnnApiController
    {

        public class Member
        {
            public Guid Guid { get; set; }
            public string FullName { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Gender { get; set; }
            public string Title { get; set; }

            public string Job { get; set; }
            public string Industry { get; set; }

            public string ClubName { get; set; }

            public DateTime LastUpdate { get; set; }


            public List<Email> Emails = new List<Email>();
            public List<Phone> Phones = new List<Phone>();
            public List<Address> Addresses = new List<Address>();

            public List<String> Assignments = new List<String>();

            public string Biography { get; set; }
            public string Photo { get; set; }
            public bool Retired { get; set; }
            public bool Honorary { get; set; }
            public bool Presentation { get; set; }

            public class Email
            {
                public string Value { get; set; }
                public string Type { get; set; }
            }

            public class Phone
            {
                public string Value { get; set; }
                public string Type { get; set; }
                public string Kind { get; set; }
            }
           
            public class Address
            {
                public string Street { get; set; }
                public string City { get; set; }
                public string PostalCode { get; set; }
                public string Country { get; set; }
            }


            public Member(Guid guid, string name,string surname,string clubname)
            {
                this.Guid = guid;
                this.FirstName = name;
                this.LastName = surname;
                this.FullName = name +" " + surname;
                this.ClubName = clubname;
            }

            public Member(AIS.Member member) {
                this.Guid = member.guid;

                this.FullName = member.name + " " + member.surname;
                this.FirstName = member.name;
                this.LastName = member.surname;
                this.Gender = member.civility;
                this.Title = member.title;

                this.Job = member.job;
                this.Industry = member.industry;

                this.ClubName = member.club_name;
                this.LastUpdate = member.base_dtupdate ?? DateTime.Now;
                
                this.Biography = member.biography;
                this.Photo = AIS.Const.DISTRICT_URL + member.GetPhoto();

                this.Retired = member.retired == Const.YES;
                this.Honorary = member.honorary_member == Const.YES;
                this.Presentation = member.presentation;


                if (member.email != "")
                    this.Emails.Add(new Email
                    {
                        Type = "home",
                        Value = member.email
                    });

                if (member.professionnal_email != "")
                    this.Emails.Add(new Email
                    {
                        Type = "work",
                        Value = member.professionnal_email
                    });

                if (member.telephone != "")
                    this.Phones.Add(new Phone
                    {
                        Type = "home",
                        Value = Functions.FormatNumber(member.telephone),
                        Kind= "phone"
                    });

                if (member.gsm != "")
                    this.Phones.Add(new Phone
                    {
                        Type = "home",
                        Value = Functions.FormatNumber(member.gsm),
                        Kind= "gsm"
                    });

                if (member.professionnal_mobile != "")
                    this.Phones.Add(new Phone
                    {
                        Type = "work",
                        Value = Functions.FormatNumber(member.professionnal_mobile),
                        Kind = "gsm"
                    });

                if (member.professionnal_tel != "")
                    this.Phones.Add(new Phone
                    {
                        Type = "work",
                        Value = Functions.FormatNumber(member.professionnal_tel),
                        Kind="phone"
                    });

                if(member.professionnal_adress!="")
                    this.Addresses.Add(new Address
                    {
                       Street = member.professionnal_adress,
                       City = member.professionnal_town,
                       PostalCode = member.professionnal_zip_code,
                       Country="",
                       
                    });

            }

        }


        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage SendMessage(dynamic param)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }


        [HttpGet]        
        [DnnAuthorize(AuthTypes = "JWT")]
        public HttpResponseMessage Hello()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "is it me you looking for ?");
        }

        public Size GetImageSize(string imageUrl)
        {
            try { 
                WebClient client = new WebClient();
                Stream stream = client.OpenRead(imageUrl);
                Bitmap bitmap; bitmap = new Bitmap(stream);

                stream.Flush();
                stream.Close();
                client.Dispose();

                if (bitmap != null && bitmap.Width>1 && bitmap.Height>1)
                {
                    return new Size(bitmap.Width, bitmap.Height);
                }
            } catch(Exception ex)
            {
                Functions.Error(ex);
            }

            return new Size(0, 0);
        }


        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage GetNews()
        {
            
            List<News> news = new List<News>();
            List<object> news1 = new List<object>();
         
                
            news = DataMapping.ListNews_EN(onlyvisible: true, category: "Clubs", tri: "dt asc", tags_included: "", tags_excluded: "Bulletins", max: 100, where:" dt > getdate()-1");
            foreach (News n in news)
            {
                if (n.id != null)
                {


                    n.photo = Const.DISTRICT_URL + n.GetPhoto();
                    Size size = GetImageSize(n.photo);
                    news1.Add(new
                    {
                        id = n.id,
                        dt = n.dt.ToLongDateString(),
                        newsColor = "blue",
                        category = n.category,
                        title = n.title,
                        photo = n.photo,
                        tag1 = n.tag1,
                        clubname = n.club_name,
                        width = size.Width,
                        height = size.Height
                    }) ;
                }
            }
            news = DataMapping.ListNews_EN(onlyvisible: true, category: "District", tri: "dt asc", tags_excluded: "", max: 100, where: " dt > getdate()-1");
            foreach (News n in news)
            {
                if (n.id != null)
                {


                    n.photo = Const.DISTRICT_URL + n.GetPhoto();
                    Size size = GetImageSize(n.photo);
                    news1.Add(new
                    {
                        id = n.id,
                        dt = n.dt.ToLongDateString(),
                        newsColor = "blue",
                        category = n.category,
                        title = n.title,
                        photo = n.photo,
                        tag1 = n.tag1,  
                        clubname = "",
                        width = size.Width,
                        height = size.Height
                    });
                }
            }

         
            return Request.CreateResponse(HttpStatusCode.OK, Yemon.dnn.Functions.Serialize(news1));
        }


        [HttpGet]
        [AllowAnonymous]
        [DnnAuthorize(AuthTypes = "JWT")]
        public HttpResponseMessage GetMembers()
        {
            try
            {
                string[] auth = Request.GetHttpContext().Request.Headers.GetValues("Authorization");
                if(auth!=null && auth.Length>0)
                {
                    if (auth[0].StartsWith("Bearer") && UserInfo.UserID<0)
                    {
                        return Request.CreateResponse(HttpStatusCode.Unauthorized);
                    }
                }

                List<AIS.Member> list = DataMapping.ListMembers(max: int.MaxValue, onlyvisible: UserInfo.UserID < 0, sort: "surname asc");
                List<Member> list1 = new List<Member>();
                foreach (AIS.Member m in list)
                {
                    Member member = new Member(m);
                    if(!member.Honorary)
                    { 
                        if(UserInfo.UserID<0)
                        {
                            member = new Member(m.guid,m.name,m.surname,m.club_name);

                        }
                        list1.Add(member);
                    }
                }

                return Request.CreateResponse(HttpStatusCode.OK, Yemon.dnn.Functions.Serialize(list1));
            }
            catch(Exception e)
            {
                Functions.Error(e);
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            
        }


        [HttpGet]
        [DnnAuthorize(AuthTypes = "JWT")]
        public HttpResponseMessage GetMyProfile()
        {
            try
            {
                if(UserInfo.UserID<0)
                    return Request.CreateResponse(HttpStatusCode.Unauthorized);


                var m = DataMapping.GetMemberByUserID(UserInfo.UserID);
                if (m == null)
                {
                    m = new AIS.Member { name = "Membre", surname = "Anonyme", userid = UserInfo.UserID, email = UserInfo.Email };
                }

                Member member = new Member(m);

                return Request.CreateResponse(HttpStatusCode.OK, Yemon.dnn.Functions.Serialize(member)); ;
            }
            catch(Exception e)
            {
                Functions.Error(e);
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
    }
}
