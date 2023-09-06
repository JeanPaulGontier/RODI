using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AIS;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Services.Mail;
public partial class AIS_Contact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
  
        int id = 0;
        int.TryParse("" + Request.QueryString["id"], out id);
        if (id > 0)
        {
            Member member = DataMapping.GetMember(id);
            if (member != null)
            {
                HF_id.Value = ""+id;
                TXT_membre.Text = member.name + " " + member.surname;
                
                lit_bio.Text = member.biography.Replace("\n","<br/>");
                Pnl_Bio.Visible = member.biography != "";

                PortalSettings ps = PortalController.GetCurrentPortalSettings();
                if (ps.UserInfo.Roles != null && ps.UserInfo.Roles.Count() > 0)
                {
                    td_Coord.Visible = true;
                    Pnl_Coord.Visible = true;

                    Table tbC = new Table();
                

                    #region Cartouche
                    //if(!string.IsNullOrEmpty(membre.photo))
                    //{
                    TableRow trC = new TableRow();

                    TableCell tdC = new TableCell();
                    Image IMG_Logo2 = new Image();
                    IMG_Logo2.ImageUrl = member.GetPhoto();
                    tdC.Controls.Add(IMG_Logo2);
                    trC.Controls.Add(tdC);
                        

                    TableCell tdC2 = new TableCell();

                    Panel p = new Panel();

                    Label lbNom = new Label();
                    lbNom.Text = member.name + "  " + member.surname;
                    lbNom.Font.Bold = true;
                    lbNom.Font.Size = FontUnit.Point(14);
                    p.Controls.Add(lbNom);

                    Literal lit = new Literal();
                    lit.Text = "<br/>";
                    p.Controls.Add(lit);
                    
                    Club club = DataMapping.GetClub(member.cric);
                    if (club != null)
                    {
                        HyperLink lbclub = new HyperLink();
                        lbclub.Text = club.name;
                        lbclub.NavigateUrl = Request.Url.AbsoluteUri.ToString().Replace(Request.Url.PathAndQuery, "") + "/" + club.seo + "/";
                        lbclub.Target = "_top";
                        p.Controls.Add(lbclub);

                        Literal lit2 = new Literal();
                        lit2.Text = "<br/>";
                        p.Controls.Add(lit2);
                    }

                    #region metier
                    string metier = "";
                    if(!string.IsNullOrEmpty(member.job))
                    {
                        metier = member.job;
                    }

                    if(!string.IsNullOrEmpty(metier))
                    {
                        metier = metier + " | ";
                    }

                    if(!string.IsNullOrEmpty(member.retired) && member.retired == "O")
                    {
                        if (member.IsWoman())
                        {                            
                            metier = metier + "Retraité";
                        }
                        else
                        {
                            metier = metier + "Retraitée";
                        }
                    }
                    else
                    {
                        metier = metier + "En activité";
                    }

                    if (!string.IsNullOrEmpty(metier))
                    {
                        Label lbmetier = new Label();
                        lbmetier.Text = metier;
                        p.Controls.Add(lbmetier);

                        //p.Controls.Add(lit);
                        Literal lit3 = new Literal();
                        lit3.Text = "<br/>";
                        p.Controls.Add(lit3);
                    }
                    #endregion metier

                    if(!string.IsNullOrEmpty(member.industry))
                    {
                        Label lbBranche = new Label();
                        lbBranche.Text = member.industry;
                        p.Controls.Add(lbBranche);
                    }

                    tdC2.Controls.Add(p);
                    trC.Controls.Add(tdC2);

                    tbC.Controls.Add(trC); 
                    //}

                    #endregion Cartouche

                    Pnl_Coord.Controls.Add(tbC);

                    Table tb = new Table();
                  

                    #region Coordonnées Pro
                    if (!string.IsNullOrEmpty(member.professionnal_adress) || !string.IsNullOrEmpty(member.professionnal_tel) || !string.IsNullOrEmpty(member.professionnal_fax) || !string.IsNullOrEmpty(member.professionnal_mobile) || !string.IsNullOrEmpty(member.professionnal_email))
                    {
                        TableRow trH = new TableRow();
                        TableCell tdH = new TableCell();
                        tdH.ColumnSpan = 2;
                        Label lH = new Label();
                        lH.Text = "Coordonnées professionnelles : ";
                        lH.Font.Bold = true;
                        tdH.Controls.Add(lH);
                        trH.Controls.Add(tdH);
                        tb.Controls.Add(trH);


                        if(!string.IsNullOrEmpty(member.professionnal_adress))
                        {
                            TableRow tr = new TableRow();

                            TableCell tdLabel = new TableCell();
                            Label lab = new Label();
                            lab.Text = "Adresse : ";
                            lab.Width = Unit.Pixel(80);
                            tdLabel.Controls.Add(lab);
                            tr.Controls.Add(tdLabel);

                            TableCell td = new TableCell();
                            Label l = new Label();
                            l.Text = member.professionnal_adress;
                            td.Controls.Add(l);
                            tr.Controls.Add(td);
                            tb.Controls.Add(tr);

                            if (!string.IsNullOrEmpty(member.professionnal_zip_code) && !string.IsNullOrEmpty(member.professionnal_town))
                            {
                                TableRow tr2 = new TableRow();

                                TableCell tdLabel2 = new TableCell();
                                Label lab2 = new Label();
                                lab2.Text = "";
                                lab2.Width = Unit.Pixel(80);
                                tdLabel2.Controls.Add(lab2);
                                tr2.Controls.Add(tdLabel2);

                                TableCell td2 = new TableCell();
                                Label l2 = new Label();
                                l2.Text = member.professionnal_zip_code + " " + member.professionnal_town;
                                td2.Controls.Add(l2);
                                tr2.Controls.Add(td2);
                                tb.Controls.Add(tr2);
                            }
                        }

                        if (!string.IsNullOrEmpty(member.professionnal_tel))
                        {
                            TableRow tr = new TableRow();

                            TableCell tdLabel = new TableCell();
                            Label lab = new Label();
                            lab.Text = "Téléphone : ";
                            lab.Width = Unit.Pixel(80);
                            tdLabel.Controls.Add(lab);
                            tr.Controls.Add(tdLabel);

                            TableCell td = new TableCell();
                            Label l = new Label();
                            l.Text = member.professionnal_tel;
                            td.Controls.Add(l);
                            tr.Controls.Add(td);

                            tb.Controls.Add(tr);
                        }

                        if (!string.IsNullOrEmpty(member.professionnal_fax))
                        {
                            TableRow tr = new TableRow();

                            TableCell tdLabel = new TableCell();
                            Label lab = new Label();
                            lab.Text = "Fax : ";
                            lab.Width = Unit.Pixel(80);
                            tdLabel.Controls.Add(lab);
                            tr.Controls.Add(tdLabel);

                            TableCell td = new TableCell();
                            Label l = new Label();
                            l.Text = member.professionnal_fax;
                            td.Controls.Add(l);
                            tr.Controls.Add(td);

                            tb.Controls.Add(tr);
                        }

                        if (!string.IsNullOrEmpty(member.professionnal_mobile))
                        {
                            TableRow tr = new TableRow();

                            TableCell tdLabel = new TableCell();
                            Label lab = new Label();
                            lab.Text = "Mobile : ";
                            lab.Width = Unit.Pixel(80);
                            tdLabel.Controls.Add(lab);
                            tr.Controls.Add(tdLabel);

                            TableCell td = new TableCell();
                            Label l = new Label();
                            l.Text = member.professionnal_mobile;
                            td.Controls.Add(l);
                            tr.Controls.Add(td);

                            tb.Controls.Add(tr);
                        }

                        if (!string.IsNullOrEmpty(member.professionnal_email))
                        {
                            TableRow tr = new TableRow();

                            TableCell tdLabel = new TableCell();
                            Label lab = new Label();
                            lab.Text = "Email : ";
                            lab.Width = Unit.Pixel(80);
                            tdLabel.Controls.Add(lab);
                            tr.Controls.Add(tdLabel);

                            TableCell td = new TableCell();
                            HyperLink l = new HyperLink();
                            l.Text = member.professionnal_email;
                            l.NavigateUrl = "mailto:" + member.professionnal_email;
                            td.Controls.Add(l);
                            tr.Controls.Add(td);

                            tb.Controls.Add(tr);
                        }

                        //Pour le saut de ligne entre les coord pro et coord perso
                        TableRow trF = new TableRow();
                        TableCell tdF = new TableCell();
                        tdF.ColumnSpan = 2;
                        Label lF = new Label();
                        lF.Height = Unit.Pixel(15);
                        lF.Text = "";
                        tdF.Controls.Add(lF);
                        trF.Controls.Add(tdF);
                        tb.Controls.Add(trF);

                    }
                    #endregion Coordonnées Pro

                    #region Coordonnées Perso
                    if (!string.IsNullOrEmpty(member.adress_1) || !string.IsNullOrEmpty(member.telephone) || !string.IsNullOrEmpty(member.fax) || !string.IsNullOrEmpty(member.gsm) || !string.IsNullOrEmpty(member.email))
                    {
                        TableRow trH = new TableRow();
                        TableCell tdH = new TableCell();
                        tdH.ColumnSpan = 2;
                        Label lH = new Label();
                        lH.Text = "Coordonnées personnelles : ";
                        lH.Font.Bold = true;
                        tdH.Controls.Add(lH);
                        trH.Controls.Add(tdH);
                        tb.Controls.Add(trH);


                        if (!string.IsNullOrEmpty(member.adress_1))
                        {
                            TableRow tr = new TableRow();

                            TableCell tdLabel = new TableCell();
                            Label lab = new Label();
                            lab.Text = "Adresse : ";
                            lab.Width = Unit.Pixel(80);
                            tdLabel.Controls.Add(lab);
                            tr.Controls.Add(tdLabel);

                            TableCell td = new TableCell();
                            Label l = new Label();
                            l.Text = member.adress_1;
                            td.Controls.Add(l);
                            tr.Controls.Add(td);
                            tb.Controls.Add(tr);

                            if (!string.IsNullOrEmpty(member.adress_2) )
                            {
                                TableRow tr2 = new TableRow();

                                TableCell tdLabel2 = new TableCell();
                                Label lab2 = new Label();
                                lab2.Text = "";
                                lab2.Width = Unit.Pixel(80);
                                tdLabel2.Controls.Add(lab2);
                                tr2.Controls.Add(tdLabel2);

                                TableCell td2 = new TableCell();
                                Label l2 = new Label();
                                l2.Text = member.adress_2;
                                td2.Controls.Add(l2);
                                tr2.Controls.Add(td2);
                                tb.Controls.Add(tr2);
                            }

                            if (!string.IsNullOrEmpty(member.adress_3))
                            {
                                TableRow tr2 = new TableRow();

                                TableCell tdLabel2 = new TableCell();
                                Label lab2 = new Label();
                                lab2.Text = "";
                                lab2.Width = Unit.Pixel(80);
                                tdLabel2.Controls.Add(lab2);
                                tr2.Controls.Add(tdLabel2);

                                TableCell td2 = new TableCell();
                                Label l2 = new Label();
                                l2.Text = member.adress_3;
                                td2.Controls.Add(l2);
                                tr2.Controls.Add(td2);
                                tb.Controls.Add(tr2);
                            }

                            if (!string.IsNullOrEmpty(member.zip_code) && !string.IsNullOrEmpty(member.town))
                            {
                                TableRow tr2 = new TableRow();

                                TableCell tdLabel2 = new TableCell();
                                Label lab2 = new Label();
                                lab2.Text = "";
                                lab2.Width = Unit.Pixel(80);
                                tdLabel2.Controls.Add(lab2);
                                tr2.Controls.Add(tdLabel2);

                                TableCell td2 = new TableCell();
                                Label l2 = new Label();
                                l2.Text = member.zip_code + " " + member.town;
                                td2.Controls.Add(l2);
                                tr2.Controls.Add(td2);
                                tb.Controls.Add(tr2);
                            }
                        }

                        if (!string.IsNullOrEmpty(member.telephone))
                        {
                            TableRow tr = new TableRow();

                            TableCell tdLabel = new TableCell();
                            Label lab = new Label();
                            lab.Text = "Téléphone : ";
                            lab.Width = Unit.Pixel(80);
                            tdLabel.Controls.Add(lab);
                            tr.Controls.Add(tdLabel);

                            TableCell td = new TableCell();
                            Label l = new Label();
                            l.Text = member.telephone;
                            td.Controls.Add(l);
                            tr.Controls.Add(td);

                            tb.Controls.Add(tr);
                        }

                        if (!string.IsNullOrEmpty(member.fax))
                        {
                            TableRow tr = new TableRow();

                            TableCell tdLabel = new TableCell();
                            Label lab = new Label();
                            lab.Text = "Fax : ";
                            lab.Width = Unit.Pixel(80);
                            tdLabel.Controls.Add(lab);
                            tr.Controls.Add(tdLabel);

                            TableCell td = new TableCell();
                            Label l = new Label();
                            l.Text = member.fax;
                            td.Controls.Add(l);
                            tr.Controls.Add(td);

                            tb.Controls.Add(tr);
                        }

                        if (!string.IsNullOrEmpty(member.gsm))
                        {
                            TableRow tr = new TableRow();

                            TableCell tdLabel = new TableCell();
                            Label lab = new Label();
                            lab.Text = "Mobile : ";
                            lab.Width = Unit.Pixel(80);
                            tdLabel.Controls.Add(lab);
                            tr.Controls.Add(tdLabel);

                            TableCell td = new TableCell();
                            Label l = new Label();
                            l.Text = member.gsm;
                            td.Controls.Add(l);
                            tr.Controls.Add(td);

                            tb.Controls.Add(tr);
                        }

                        if (!string.IsNullOrEmpty(member.email))
                        {
                            TableRow tr = new TableRow();

                            TableCell tdLabel = new TableCell();
                            Label lab = new Label();
                            lab.Text = "Email : ";
                            lab.Width = Unit.Pixel(80);
                            tdLabel.Controls.Add(lab);
                            tr.Controls.Add(tdLabel);

                            TableCell td = new TableCell();
                            HyperLink l = new HyperLink();
                            l.Text = member.email;
                            l.NavigateUrl = "mailto:" + member.email;
                            td.Controls.Add(l);
                            tr.Controls.Add(td);

                            tb.Controls.Add(tr);
                        }
                    }
                    #endregion Coordonnées Perso

                    Pnl_Coord.Controls.Add(tb);
                }
            }
        }

        
    }
    protected void BT_Envoyer_Click(object sender, EventArgs e)
    {
      
        if (HF_id.Value != "")
        {
            int id = 0;
            int.TryParse("" + HF_id.Value, out id);
            if (id > 0)
            {
                Member member = DataMapping.GetMember(id);
                if (member != null)
                {

                    PortalSettings ps = PortalController.GetCurrentPortalSettings();


                    string message =  "<p>Vous avez un message à partir du site du district " + Const.DISTRICT_ID +"</p>";
                    message += "<p>Nom & Prenom : " + TXT_Nom.Text + "</p>";
                    message += "<p>Email : " + TXT_Email.Text + "</p>";
                    message += "<p>Message :</p>";
                    message += "<p><pre>"+TXT_Message.Text+"</pre></p>";
                    message +="";

                    //Mail.SendEmail( TXT_Email.Text,ps.Email, member.email, "Contact à partir du site du district", message);
                    //Functions.SendMail(TXT_Email.Text, member.email, "[RODI] Contact à partir du site du district "+Const.DISTRICT_ID, message);
                    Yemon.dnn.Functions.SendMail(TXT_Email.Text, member.email, "[RODI] Contact à partir du site du district " + Const.DISTRICT_ID, message);
                    P1.Visible = false;
                    P2.Visible = true;
                }
            }
        }
    }

    public void DynamicClick(object sender, EventArgs e)
    {        
        Response.Redirect("/", true);
    }
}