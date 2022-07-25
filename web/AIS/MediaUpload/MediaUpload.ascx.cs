using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AIS;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Users;
using DotNetNuke.Security.Permissions;
using DotNetNuke.Security.Roles;
using DotNetNuke.Services.FileSystem;
using Telerik.Web.UI;

public partial class AIS_MediaUpload : System.Web.UI.UserControl
{
    public Media media { 
        get 
        {
            //if (SessionMedia.Value != "" && Session[SessionMedia.Value] != null)
            //    return (Media)Session[SessionMedia.Value];
            return null;
        }
        set 
        {
            //if (value == null)
            //{
            //    SessionMedia.Value = "";
            //    Panel1.Visible = true;
            //    Panel2.Visible = false;
            //    Panel3.Visible = false;
            //    img.ImageUrl = "";
            //}
            //else
            //{
            //    SessionMedia.Value = Guid.NewGuid().ToString();
            //    Panel1.Visible = false;
            //    Panel2.Visible = false;
            //    Panel3.Visible = true;

            //    //img.ImageUrl = "/AIS/ViewMedia.aspx?id=" + SessionMedia.Value;
            //    HL_Download.NavigateUrl = "/AIS/DownloadMedia.aspx?id=" + SessionMedia.Value;
            //    HL_Download.Text = ((Media)value).name;
            //}
            //Session[SessionMedia.Value] = value;


        }
    }

    //public List<Media> GetMedias
    //{
    //    get
    //    {
    //        if(!string.IsNullOrEmpty(ref_VO.Value))
    //        {

    //            List<Media> lesNEWmedias = new List<Media>();
    //            if (Session["lesmediasTEMP"] != null)
    //            {
    //                List<Media> lesmedias = new List<Media>();
    //                lesmedias = (List<Media>)Session["lesmediasTEMP"];
    //                if (lesmedias != null)
    //                {
    //                    foreach (Media m in lesmedias)
    //                    {
    //                        if (m.name.StartsWith(Const.MEDIA_VIEW_URL + "?id="))
    //                        {
    //                            string nomSession = m.name;
    //                            string chemin = PortalSettings.Current.HomeDirectory + Const.CONTENU_PHOTOS_FOLDER + ref_VO.Value + "-" + m.name.Replace(Const.MEDIA_VIEW_URL + "?id=", "");
    //                            DirectoryInfo d = new DirectoryInfo(Server.MapPath(PortalSettings.Current.HomeDirectory + Const.CONTENU_PHOTOS_FOLDER));
    //                            if (!d.Exists)
    //                            {
    //                                d.Create();
    //                            }
    //                            File.WriteAllBytes(Server.MapPath(chemin), m.content);

    //                            m.name = Const.CONTENU_PHOTOS_FOLDER + ref_VO.Value + "-" + m.name.Replace(Const.MEDIA_VIEW_URL + "?id=", "");

    //                            lesNEWmedias.Add(m);
    //                            Session[nomSession] = null;
    //                        }
    //                    }
    //                }
    //            }
    //            return lesNEWmedias;
    //        }
    //        else
    //        {
    //            return null;
    //        }
    //    }
    //    set
    //    {
            
    //    }
        
    //}

    public string AllowedFileExtensions
    {
        set {
            string[] exts = value.Split(',');
            RadUpload1.AllowedFileExtensions = exts; }
    }
    public Boolean Deletable
    {
        set { }
        //set { BT3.Visible = value; }
    }

    public Boolean required
    {
        set { lbl_required.Visible = value; }
    }

    public String Label
    {
        get
        {
            return Label;
        }
        set { lbl_titre.Text = value; }
    }

    public bool IsPresent()
    {
        if ((Media)Session[SessionMedia.Value] == null)
        {
            lbl_required.Visible = true;
            return false;
        }
        else
        {
            lbl_required.Visible = false;
            return true;
        }
    }

    private bool _IsAdmin;
    public bool IsAdmin
    {
        get { return _IsAdmin; }
        set 
        { 
            _IsAdmin = value; 
        }
    }

    private int _portalID;
    public int PortalID
    {
        get { return _portalID; }
        set
        {
            _portalID = value;
            Ref_portalID.Value = _portalID.ToString();
        }
    }

    private string _folder;
    public string FolderIMG
    {
        get { return _folder; }
        set 
        { 
            _folder = value; 
            Ref_folder.Value = Server.MapPath(PortalSettings.Current.HomeDirectory + /*Const.IMG_PREFIX +*/ _folder);
        }
    }
    
    private List<String> files;
    public List<string> Files
    {
        get
        {
            return files;
        }

        set
        {
            files = value;
        }
    }


    //protected void Page_Init(object sender, EventArgs e)
    //{
    //    Page.EnableEventValidation = false;
    //}

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (IsAdmin)
                {
                    //RadUpload1.OnClientFilesUploaded = "AutoUpload" + this.ClientID;
                    Panel0.Visible = true;
                    Panel2.Visible = true;
                    Panel3.Visible = false;
                }

                if (!string.IsNullOrEmpty(Ref_folder.Value))
                {
                    if (!Directory.Exists(Ref_folder.Value))
                    {
                        int LeportalID = 0;
                        int.TryParse(Ref_portalID.Value, out LeportalID);

                        FolderManager.Instance.AddFolder(LeportalID, Ref_folder.Value);
                        FolderManager.Instance.Synchronize(LeportalID);

                        //Directory.CreateDirectory(Ref_folder.Value);
                    }

                }

                
                Gvw_Photos_Binding();                

            }
        }
        catch(Exception ee)
        {
            Functions.Error(ee);
        }
    }

    protected void Gvw_Photos_Binding()
    {
        try
        {
            gvw_Photos.DataSource = null;
            gvw_Photos.DataBind();

            List<Media> listeMed = new List<Media>();

            if(Files != null && Files.Count==0)
            {
                foreach (var files in Directory.GetFiles(Ref_folder.Value))
                {
                    System.IO.FileInfo info = new System.IO.FileInfo(files);

                    //foreach (string ext in RadUpload1.AllowedFileExtensions)
                    //{
                        //if (info.Extension == "." + ext)
                        //{

                            var fileName = Path.GetFileName(info.FullName);
                            Media m = new Media();

                            m.name = /*PortalSettings.Current.HomeDirectory + Const.IMG_PREFIX +*/ _folder + "\\" + fileName;

                            listeMed.Add(m);

                            //Session[m.name] = m;
                        //}
                    //}

                }
            }
            else
            {
                if(Files!=null)
                {
                    foreach (String file in Files)
                    {
                        Media m = new Media();

                        m.name = _folder + file;
                        listeMed.Add(m);
                    }
                }
                
            }
            

            //Session["lesmediasTEMP"] = listeMed;

            gvw_Photos.DataSource = listeMed;
            gvw_Photos.DataBind();
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
    }

    protected void gvw_Photos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.DataItem == null)
                return;

            Media v = ((Media)e.Row.DataItem);

            System.Web.UI.WebControls.Image img = (System.Web.UI.WebControls.Image)e.Row.FindControl("img_Photos");
            img.ImageUrl = v.name;

            Button btn = (Button)e.Row.FindControl("btn_Supprimer_img_Photos");
            btn.CommandArgument = v.name.ToString();
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
    }

    //protected void BT1_Click(object sender, EventArgs e)
    //{
    //    Panel0.Visible = true;
    //    Panel1.Visible = false;
    //    Panel2.Visible = true;
    //    Panel3.Visible = false;
    //}

    protected void BT2_Click(object sender, EventArgs e)
    {
        try
        {


            UploadedFileCollection liste = RadUpload1.UploadedFiles;
            String folder = _folder;
            if (RadUpload1.UploadedFiles.Count > 0 && !string.IsNullOrEmpty(_folder))
            {

                //List<Media> lesMedias = new List<Media>();

                //if (Session["lesmediasTEMP"] != null)
                //{
                //    lesMedias = (List<Media>)Session["lesmediasTEMP"];
                //}



                foreach (UploadedFile file in RadUpload1.UploadedFiles)
                {
                    //Files.Add(file.FileName);
                    //string guid = Guid.NewGuid().ToString();
                    //string filename = Functions.ClearFileName(guid + ".jpg");

                    Bitmap bmp = new Bitmap(file.InputStream);
                    //bmp = Functions.ThumbByWidth(bmp, AIS.PAULHE.Const.CONTENU_PHOTOS_WIDTH);
                    MemoryStream ms = new MemoryStream();
                    //bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                    //Media media = new Media();
                    //media.content = ms.GetBuffer();
                    //media.content_size = media.content.Length;
                    //media.dt = DateTime.Now;
                    //media.w = bmp.Width;
                    //media.h = bmp.Height;
                    //media.name = Const.MEDIA_VIEW_URL + "?id=" + filename;
                    ////media.libelle = file.FileName;
                    //media.content_type = "image/jpeg";

                    //lesMedias.Add(media);

                    //Session[filename] = media;

                    //string filename = Functions.Accent_to_Html(file.GetName().Replace(file.GetExtension(), "") + ".jpg");
                    //string filename = file.GetName().Replace(file.GetExtension(), "") + ".jpg";

                    //File.WriteAllBytes(Server.MapPath(PortalSettings.Current.HomeDirectory + _folder + "//" + filename), ms.GetBuffer());


                    FileManager.Instance.AddFile(FolderManager.Instance.GetFolder(_portalID, /*Const.IMG_PREFIX +*/   _folder), file.GetName(), file.InputStream /*ms*/);
                    FolderManager.Instance.Synchronize(_portalID);
                    //Functions.Log("fichier monté");
                }

                //Session["lesmediasTEMP"] = lesMedias;
                //gvw_Photos.DataSource = lesMedias;
                //gvw_Photos.DataBind();

                Gvw_Photos_Binding();

                Panel0.Visible = true;
                //Panel1.Visible = true;
                Panel2.Visible = true;
                Panel3.Visible = false;
            }
        }
        catch (Exception ee)
        {
            Functions.Error(ee);

            //Session["lesmediasTEMP"] = null;

            gvw_Photos.DataSource = null;
            gvw_Photos.DataBind();
        }
    }

    protected void BT3_Click(object sender, EventArgs e)
    {
        
        media = null;

    }

    protected void gvw_Photos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e == null)
                return;

            if (e.CommandName == "supprimer")
            {
                string v = e.CommandArgument.ToString();
                if (!string.IsNullOrEmpty(v))
                {

                    //Supression physique de la photo
                    if (File.Exists(Server.MapPath(v)))
                    {
                        File.Delete(Server.MapPath(v));
                    }

                    Gvw_Photos_Binding();

                    //string nomSession = "" + v.Replace(Const.MEDIA_VIEW_URL + "?id=", "");
                    //Media med = (Media)Session[nomSession];
                    //if (med != null)
                    //{
                    //    List<Media> lesMedias = new List<Media>();
                    //    lesMedias = (List<Media>)Session["lesmediasTEMP"];
                    //    if (lesMedias != null)
                    //    {
                    //        Media m = lesMedias.Find(x => x.name == v);
                    //        if (m != null)
                    //        {
                    //            lesMedias.Remove(m);
                    //            Session[nomSession] = null;

                    //            if (med.id > 0)
                    //            {                                   
                    //                //Supression physique de la photo
                    //                if (File.Exists(Server.MapPath(med.name)))
                    //                {
                    //                    File.Delete(Server.MapPath(med.name));
                    //                }
                    //            }

                    //            Session["lesmediasTEMP"] = lesMedias;

                    //            gvw_Photos.DataSource = lesMedias;
                    //            gvw_Photos.DataBind();
                    //        }
                    //    }//Récupération session MediaS
                    //}//Test media V
                }//Test string V de la session
            }//Command supprimer
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
    }




    
}