
#region Copyrights

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


using DotNetNuke.Entities.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AIS;
using Telerik.Web.UI;
using System.Drawing;
using System.IO;
using DotNetNuke.Entities.Users;
using DotNetNuke.Security.Membership;
using DotNetNuke.Common;
using DotNetNuke.Entities.Portals;
using System.Drawing.Imaging;
using System.Data;
using Aspose;
using System.Diagnostics;



public partial class DesktopModules_AIS_Admin_General_Attendance_Admin_General_Attendance : PortalModuleBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //if (Functions.GetCurrentMember()!=null &&(UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT) || UserInfo.IsInRole(Const.ROLE_ADMIN_ROTARACT) || UserInfo.IsSuperUser || DataMapping.isADG(Functions.GetCurrentMember().id)))
            //{
                if (!IsPostBack)
                {
                    tbx_annee.Text = "" + DateTime.Now.Year;
                    if (ddl_mois.Items.Count < 11)
                        BindingDDL_mois();
                    lbl_hidden.Text = "";
                    lbl_assMoyenne.Text = "";
                    RefreshGrid();
                    double hauteur = (int.Parse(tbx_tailleImg.Text) / 5) / 2.8;
                    int hauteurCase = (int)hauteur;
                    lbl_hautImg.Text = "" + (hauteurCase + gvw_assiduite.Rows.Count * hauteurCase);
                    tbx_hautImg.Text = lbl_hautImg.Text;


                }
            //}
            //else
            //{
            //    if (PortalSettings.HomeTabId > 0)
            //    {
            //        Response.Redirect(Globals.NavigateURL(PortalSettings.HomeTabId), true);
            //    }
            //    else
            //    {
            //        Response.Redirect(Globals.GetPortalDomainName(PortalSettings.PortalAlias.HTTPAlias, Request, true), true);
            //    }
            //}
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
    }

    /// <summary>
    /// Rajoute le name des mois dans la DDL
    /// </summary>
    protected void BindingDDL_mois()
    {
        ddl_mois.Items.Add("Janvier");
        ddl_mois.Items.Add("Février");
        ddl_mois.Items.Add("Mars");
        ddl_mois.Items.Add("Avril");
        ddl_mois.Items.Add("Mai");
        ddl_mois.Items.Add("Juin");
        ddl_mois.Items.Add("Juillet");
        ddl_mois.Items.Add("Août");
        ddl_mois.Items.Add("Septembre");
        ddl_mois.Items.Add("Octobre");
        ddl_mois.Items.Add("Novembre");
        ddl_mois.Items.Add("Décembre");
    }

    /// <summary>
    /// Actualise les données du GridView
    /// </summary>
    protected void RefreshGrid()
    {
        try
        {
            lbl_hidden.Text = "";
            lbl_assMoyenne.Text = "";
            int mois = ddl_mois.SelectedIndex + 1;
            string annee = tbx_annee.Text;

            List<General_Attendance> LesAss = new List<General_Attendance>();
            List<General_Attendance> assG = new List<General_Attendance>();

            if (Functions.GetCurrentMember() == null || !DataMapping.isADG(Functions.GetCurrentMember().id))
            {
                LesAss = DataMapping.GetListAssiduitePurcentFinal("A.month =" + mois + "AND A.year = " + annee);//On crée la liste d'assiduités avec les pourcentages en fonction du mois et de l'année définis
            }
            else
            {
                List<Domain> listeDom = DataMapping.GetListDomain("ADG", "");

                foreach (Domain dom in listeDom)
                {
                    if (UserInfo.IsInRole(dom.subdomain))
                    {
                        if (DataMapping.GetListAssiduitePurcentFinal("A.month =" + mois + "AND A.year = " + annee + " AND A.cric=" + dom.value) != null && DataMapping.GetListAssiduitePurcentFinal("A.month =" + mois + "AND A.year = " + annee + " AND A.cric=" + dom.value).Count != 0)
                        {
                            foreach (General_Attendance assGe in DataMapping.GetListAssiduitePurcentFinal("A.month =" + mois + "AND A.year = " + annee + " AND A.cric=" + dom.value))
                            {
                                LesAss.Add(assGe);
                            }
                        }
                    }
                }
            }



            if (LesAss != null && LesAss.Count != 0)
            {
                gvw_assiduite.DataSource = LesAss;
                pnl_export.Visible = true;
            }
            else
            {
                gvw_assiduite.DataSource = assG;
                pnl_export.Visible = false; //On cache les boutons d'export
            }

            gvw_assiduite.Columns[1].HeaderText = "Effectif de " + ddl_mois.SelectedValue.ToString() + " " + tbx_annee.Text;
            gvw_assiduite.Columns[3].HeaderText = "Assiduité moyenne : ";


            gvw_assiduite.DataBind();
            mean();
            gvw_assiduite.HeaderRow.Cells[3].Text += lbl_assMoyenne.Text;


        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }




    }

    /// <summary>
    /// Calcule le pourcentage d'assiduité moyen
    /// </summary>
    public void mean()
    {
        int mean = 0;
        if (lbl_hidden.Text != "")
        {
            string[] splits = lbl_hidden.Text.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in splits)
            {
                mean += int.Parse(s);
            }
            int count = splits.Count();
            mean = mean / count;

            lbl_assMoyenne.Text = "" + mean + "%";
        }


    }

    /// <summary>
    /// Lors du bind des données, modifie les colonnes "Variation de l'assiduité" et "Variation de l'effectif"
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvw_assiduite_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblVariation = (Label)e.Row.FindControl("lbl_variation");
            System.Web.UI.WebControls.Image imgHausse = (System.Web.UI.WebControls.Image)e.Row.FindControl("img_hausse");
            System.Web.UI.WebControls.Image imgBaisse = (System.Web.UI.WebControls.Image)e.Row.FindControl("img_baisse");
            Label lblPourcent = (Label)e.Row.FindControl("lbl_moyenne");
            Label lblStagn = (Label)e.Row.FindControl("lbl_stagn");
            Label lblNoEntries = (Label)e.Row.FindControl("lbl_no_entries");
            Label lblVarAss = (Label)e.Row.FindControl("lbl_varAss");
            lbl_hidden.Text += " " + lblPourcent.Text;




            if (lblVariation.Text != "" && lblVarAss.Text != "")
            {
                int var = int.Parse(lblVariation.Text);
                if (var < 0)
                    lblVariation.Text = "-";
                else if (var > 0.0)
                    lblVariation.Text = "+";
                else if (var == 0.0)
                    lblVariation.Text = "=";
                else
                    throw new Exception("Problème de récupération de la variation");
                if (lblVarAss.Text != "777")
                {
                    int varAss = int.Parse(lblVarAss.Text);
                    int purcent = int.Parse(lblPourcent.Text);
                    if (varAss > purcent)
                        imgBaisse.Visible = true;
                    else if (varAss < purcent)
                        imgHausse.Visible = true;
                    else if (varAss == purcent)
                        lblStagn.Visible = true;
                    else
                        throw new Exception("Problème de récupération de la variation assiduité");
                    lblVarAss.Visible = false;
                }



            }
            else if (lblVarAss.Text != "")
            {
                if (ddl_mois.SelectedIndex != 6)
                    lblVariation.Text = "Pas d'entrées sur le mois de juillet de l'année en cours";
                else
                    lblVariation.Text = "Aucune variation à calculer";

                int varAss = int.Parse(lblVarAss.Text);
                int purcent = int.Parse(lblPourcent.Text);
                if (varAss > purcent)
                    imgBaisse.Visible = true;
                else if (varAss < purcent)
                    imgHausse.Visible = true;
                else if (varAss == purcent)
                    lblStagn.Visible = true;
                else
                    throw new Exception("Problème de récupération de la variation assiduité");
                lblVarAss.Visible = false;
            }

            else if (lblVariation.Text != "")
            {
                int var = int.Parse(lblVariation.Text);
                if (var < 0)
                    lblVariation.Text = "-";
                else if (var > 0.0)
                    lblVariation.Text = "+";
                else if (var == 0.0)
                    lblVariation.Text = "=";
                else
                    throw new Exception("Problème de récupération de la variation");

                lblVarAss.Text = "N.C.";
            }
            else
            {
                lblVarAss.Text = "N.C.";
                if (ddl_mois.SelectedIndex != 6)
                    lblVariation.Text = "Pas d'entrées sur le mois de juillet de l'année en cours";
                else
                    lblVariation.Text = "Aucune variation à calculer";
            }

            lblPourcent.Text = lblPourcent.Text + "%";



        }





    }

    /// <summary>
    /// Vide tous les controls contenu dans control
    /// </summary>
    /// <param name="control">Le control parent contenant les controls à vider</param>
    private void ClearControls(Control control)
    {
        for (int i = control.Controls.Count - 1; i >= 0; i--)
        {
            ClearControls(control.Controls[i]);
        }

        if (!(control is TableCell))
        {
            if (control.GetType().GetProperty("SelectedItem") != null)
            {
                LiteralControl literal = new LiteralControl();
                control.Parent.Controls.Add(literal);
                try
                {
                    literal.Text =
                        (string)control.GetType().GetProperty("SelectedItem").
                            GetValue(control, null);
                }
                catch (Exception ee)
                {
                    Functions.Error(ee);
                }
                control.Parent.Controls.Remove(control);
            }
            else if (control.GetType().GetProperty("Text") != null)
            {
                LiteralControl literal = new LiteralControl();
                control.Parent.Controls.Add(literal);
                literal.Text =
                    (string)control.GetType().GetProperty("Text").
                        GetValue(control, null);
                control.Parent.Controls.Remove(control);
            }
        }
        return;
    }

    #region Boutons

    /// <summary>
    /// Rafraichit la GridView
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_valider_Click(object sender, EventArgs e)
    {
        RefreshGrid();
        double height = (int.Parse(tbx_tailleImg.Text) / 5) / 2.8;
        int heightCase = (int)height;
        lbl_hautImg.Text = "" + (heightCase + gvw_assiduite.Rows.Count * heightCase);
        double width = (14 * (int.Parse(tbx_hautImg.Text))) / (1 + gvw_assiduite.Rows.Count);
        int widthEnt = (int)width;
        lbl_tailleImg.Text = "" + widthEnt;
    }

    /// <summary>
    /// Exporte la GridView en Excel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_export_excel_Click(object sender, EventArgs e)
    {
        // Reference your own GridView here
        if (gvw_assiduite.Rows.Count > 65535)
        {
            throw new Exception("Trop de colonnes");
        }

        string filename = String.Format("General_Attendance_{1}.xls",
            DateTime.Today.Month.ToString(), DateTime.Today.Year.ToString());

        Response.Clear();
        Response.AddHeader("Content-Disposition", "attachment;filename=" + filename);
        Response.Charset = "";

        // SetCacheability doesn't seem to make a difference (see update)
        Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);

        Response.ContentType = "application/vnd.xls";

        System.IO.StringWriter stringWriter = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWriter = new HtmlTextWriter(stringWriter);

        // Replace all gridview controls with literals
        ClearControls(gvw_assiduite);

        // Throws exception: Control 'ComputerGrid' of type 'GridView'
        // must be placed inside a form tag with runat=server.
        // ComputerGrid.RenderControl(htmlWrite);

        // Alternate to ComputerGrid.RenderControl above
        System.Web.UI.HtmlControls.HtmlForm form
            = new System.Web.UI.HtmlControls.HtmlForm();
        Controls.Add(form);
        form.Controls.Add(gvw_assiduite);
        form.RenderControl(htmlWriter);

        Response.Write(stringWriter.ToString());
        Response.End();

    }

    /// <summary>
    /// Permet d'exporter la gridView en PNG
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ExportToImage(object sender, EventArgs e)
    {
        try
        {
            if (lbl_tailleImg.Visible && (int.Parse(lbl_tailleImg.Text) < 200 || int.Parse(lbl_tailleImg.Text) > 2000))
            {
                if (int.Parse(lbl_tailleImg.Text) < 200)
                    lbl_erreurTailleImg.Text = "Veuillez augmenter la hauteur afin d'avoir une largeur supérieure à 200";
                else
                    lbl_erreurTailleImg.Text = "Veuillez réduire la hauteur afin d'avoir une largeur inférieure à 2000";
            }
            else
            {
                if (cbx_tailleImg.Checked)
                {//Si on modifie la hauteur, on synchronise la textbox qui définit la largeur avec son label associé
                    double width = (14 * (int.Parse(tbx_hautImg.Text))) / (1 + gvw_assiduite.Rows.Count);
                    int widthEnt = (int)width;
                    lbl_tailleImg.Text = "" + widthEnt;
                    tbx_tailleImg.Text = lbl_tailleImg.Text;
                }

                else
                {//Si on modifie la largeur, on synchronise la textbox qui définit la hauteur avec son label associé
                    double height = (int.Parse(tbx_tailleImg.Text) / 5) / 2.8;
                    int heightCase = (int)height;
                    lbl_hautImg.Text = "" + (heightCase + gvw_assiduite.Rows.Count * heightCase);
                    tbx_hautImg.Text = lbl_hautImg.Text;
                }


                //Ici, on initialise la table
                #region Table
                int gvWidth = int.Parse(tbx_tailleImg.Text);
                int HeightCase = int.Parse(tbx_hautImg.Text) / (1 + gvw_assiduite.Rows.Count);
                //double hauteur = (gvWidth / 5) / 3;
                //int hautCase = (int)hauteur;
                int gvHeight = HeightCase + gvw_assiduite.Rows.Count * HeightCase;
                int widthCase = gvWidth / 5;
                int areaCase = widthCase * HeightCase;
                Bitmap tempbmp = new Bitmap(gvWidth, gvHeight);
                Graphics g = Graphics.FromImage(tempbmp);

                //On définit les polices d'écriture que l'on utilisera par la suite
                System.Drawing.Font fHeader = new System.Drawing.Font("Arial", (float)0.3 * HeightCase);
                System.Drawing.Font fGrosHeader = new System.Drawing.Font("Arial", (float)0.24 * HeightCase);
                System.Drawing.Font fText = new Font("Verdana", (float)0.2 * HeightCase);

                //On crée nos propres brosses afin d'avoir les mêmes couleurs que la GridView
                System.Drawing.SolidBrush rotary;
                rotary = new System.Drawing.SolidBrush(System.Drawing.ColorTranslator.FromHtml("#005DAA"));
                System.Drawing.SolidBrush line1;
                line1 = new System.Drawing.SolidBrush(System.Drawing.ColorTranslator.FromHtml("#E7F0F7"));
                System.Drawing.SolidBrush line2;
                line2 = new System.Drawing.SolidBrush(System.Drawing.ColorTranslator.FromHtml("#FAFCFD"));
                g.FillRectangle(rotary, 0, 0, gvWidth, HeightCase);

                //On alterne les couleurs en fonction de la ligne
                for (int i = 0; i < gvw_assiduite.Rows.Count; i++)
                {
                    if (i % 2 == 0) //Détection de la parité
                    {
                        g.FillRectangle(line1, 0, (i + 1) * HeightCase, gvWidth, (i + 2) * HeightCase);
                    }
                    else
                    {
                        g.FillRectangle(line2, 0, (i + 1) * HeightCase, gvWidth, (i + 2) * HeightCase);
                    }

                }

                //On crée les contours du tableau
                g.DrawLine(Pens.Black, 0, HeightCase, gvWidth, HeightCase);
                g.DrawLine(Pens.Black, 0, 0, gvWidth, 0);
                g.DrawLine(Pens.Black, 0, gvHeight - 1, gvWidth, gvHeight - 1);

                //On dessine les lignes verticales séparant les colonnes 
                for (int i = 0; i < 6; i++)
                {
                    g.DrawLine(Pens.Black, widthCase * i, 0, widthCase * i, gvHeight);
                    if (widthCase * i >= gvWidth)
                        g.DrawLine(Pens.Black, gvWidth - 1, 0, gvWidth - 1, gvHeight);
                }
                //Puis les lignes horizontales séparant les lignes
                for (int i = 0; i < gvw_assiduite.Rows.Count; i++)
                {
                    g.DrawLine(Pens.Black, 0, HeightCase + i * HeightCase, gvWidth, HeightCase + i * HeightCase);

                }
                #endregion Table

                //Ici, on crée les Headers
                #region Headers
                g.DrawString("Clubs", fHeader, Brushes.White, new PointF((float)0.25 * widthCase, (float)0.3 * HeightCase));
                g.DrawString("Effectif", fGrosHeader, Brushes.White, new PointF((float)1.29 * widthCase, (float)0.06 * HeightCase));
                g.DrawString("de", fGrosHeader, Brushes.White, new PointF((float)1.43 * widthCase, (float)0.3 * HeightCase));
                g.DrawString(ddl_mois.SelectedValue + " " + tbx_annee.Text, fGrosHeader, Brushes.White, new PointF((float)1.2 * widthCase, (float)0.6 * HeightCase));
                g.DrawString("Variation", fHeader, Brushes.White, new PointF((float)2.21 * widthCase, (float)0.3 * HeightCase));
                g.DrawString("Assiduité", fGrosHeader, Brushes.White, new PointF((float)3.21 * widthCase, (float)0.06 * HeightCase));
                g.DrawString("moyenne :", fGrosHeader, Brushes.White, new PointF((float)3.21 * widthCase, (float)0.3 * HeightCase));
                g.DrawString(lbl_assMoyenne.Text, fGrosHeader, Brushes.White, new PointF((float)3.36 * widthCase, (float)0.6 * HeightCase));
                g.DrawString("Variation", fGrosHeader, Brushes.White, new PointF((float)4.21 * widthCase, (float)0.14 * HeightCase));
                g.DrawString("assiduité", fGrosHeader, Brushes.White, new PointF((float)4.21 * widthCase, (float)0.5 * HeightCase));
                #endregion Headers

                //Ici, on ajoute le contenu du GridView à l'image
                #region Contenu

                //On initialise les images dont on a besoin
                System.Drawing.Image imgIncrease = System.Drawing.Image.FromFile(Server.MapPath("~/DesktopModules/Admin/Tabs/images/Icon_Up.png"));
                System.Drawing.Image imgDecrease = System.Drawing.Image.FromFile(Server.MapPath("~/DesktopModules/Admin/Tabs/images/Icon_Down.png"));


                int month = ddl_mois.SelectedIndex + 1;
                int year = int.Parse(tbx_annee.Text);
                Size newSize = new Size((int)HeightCase / 2, (int)HeightCase / 2);
                Bitmap bmpUp = new Bitmap(imgIncrease, newSize);
                Bitmap bmpDown = new Bitmap(imgDecrease, newSize);

                //On crée la liste qui nous permettra de remplir la table
                List<General_Attendance> attG = new List<General_Attendance>();

                if (Functions.GetCurrentMember() == null || !DataMapping.isADG(Functions.GetCurrentMember().id))
                {
                    attG = DataMapping.GetListAssiduitePurcentFinal("A.month =" + month + " AND A.year =" + year);
                }
                else
                {
                    List<Domain> listeDom = DataMapping.GetListDomain("ADG", "");

                    foreach (Domain dom in listeDom)
                    {
                        if (UserInfo.IsInRole(dom.subdomain))
                        {
                            if (DataMapping.GetListAssiduitePurcentFinal("A.month =" + month + "AND A.year = " + year + " AND A.cric=" + dom.value) != null && DataMapping.GetListAssiduitePurcentFinal("A.month =" + month + "AND A.year = " + year + " AND A.cric=" + dom.value).Count != 0)
                            {
                                foreach (General_Attendance assGe in DataMapping.GetListAssiduitePurcentFinal("A.month =" + month + "AND A.year = " + year + " AND A.cric=" + dom.value))
                                {
                                    attG.Add(assGe);
                                }
                            }
                        }
                    }
                }


                #region clubName

                //On répète la même opération pour chaque ligne
                for (int i = 0; i < attG.Count; i++)
                {
                    string name = attG[i].name;
                    //On vérifie que le name du club ne soit pas trop long
                    if (name.Length <= 17)
                        g.DrawString(attG[i].name, fText, Brushes.Black, new PointF(5, (float)1.3 * HeightCase + i * HeightCase));
                    else
                    {
                        string[] splits = name.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        string nameFinal = "";
                        int j = 0;
                        int count = 1;
                        while (j < splits.Count())
                        {
                            if (nameFinal.Length + splits[j].Length < 17)
                            {
                                nameFinal += splits[j] + " ";
                            }
                            else //On affiche les caractères qui peuvent rentrer puis on fait on retour à la ligne
                            {
                                g.DrawString(nameFinal, fText, Brushes.Black, new PointF(5, (float)((i + 1) * HeightCase - (HeightCase / 5) + (0.25 * HeightCase) * count)));
                                count++;
                                nameFinal = "";

                            }
                            j++;
                        }
                        if (nameFinal != "") //Si l'on n'a pas tout affiché, on affiche la chaîne manquante 
                            g.DrawString(nameFinal, fText, Brushes.Black, new PointF(5, (float)((i + 1) * HeightCase - (HeightCase / 5) + (0.25 * HeightCase) * count)));
                    }
                #endregion clubName

                    //On écrit le namebre de membres du club au début du mois
                    g.DrawString("" + attG[i].nbm, fText, Brushes.Black, new PointF((float)(2 * widthCase - (0.2 * widthCase)), (float)1.3 * HeightCase + i * HeightCase));

                    //On écrit la variation d'effectif
                    #region varEff
                    if (attG[i].varEff != "") // On vérifie quel caractère il faut afficher
                    {
                        if (int.Parse(attG[i].varEff) < 0)
                            g.DrawString("-", fText, Brushes.Black, new PointF((float)(3 * widthCase - (0.2 * widthCase)), (float)1.3 * HeightCase + i * HeightCase));
                        else if (int.Parse(attG[i].varEff) > 0)
                            g.DrawString("+", fText, Brushes.Black, new PointF((float)(3 * widthCase - (0.2 * widthCase)), (float)1.3 * HeightCase + i * HeightCase));
                        else if (int.Parse(attG[i].varEff) == 0)
                            g.DrawString("=", fText, Brushes.Black, new PointF((float)(3 * widthCase - (0.2 * widthCase)), (float)1.3 * HeightCase + i * HeightCase));
                    }
                    #endregion varEff

                    //On écrit le pourcentage d'assiduité ce mois-ci
                    g.DrawString(attG[i].purcent + "%", fText, Brushes.Black, new PointF((float)(4 * widthCase - (0.3 * widthCase)), (float)1.3 * HeightCase + i * HeightCase));

                    #region varAss
                    PointF ptF = new PointF((float)(5 * widthCase - (0.25 * widthCase)), (float)1.3 * HeightCase + i * HeightCase);
                    if (attG[i].purcentPastYear != "") //On vérifie quel caractère il faut afficher
                    {
                        int purcAv = int.Parse(attG[i].purcentPastYear);
                        int purc = int.Parse(attG[i].purcent);
                        if (purc < purcAv)
                            g.DrawImage((System.Drawing.Image)bmpDown, ptF);
                        else if (purc > purcAv)
                            g.DrawImage((System.Drawing.Image)bmpUp, ptF);
                        else if (purc == purcAv)
                            g.DrawString("=", fText, Brushes.Black, ptF);
                    }
                    #endregion varAss



                }

                #endregion contenu

                //Il ne reste qu'à exporter l'image
                #region export

                System.Drawing.Image img = (System.Drawing.Image)tempbmp;
                using (MemoryStream stream = new MemoryStream())
                {
                    img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);

                    stream.Close();
                    Response.Clear();
                    Response.ContentType = "image/png";
                    Response.AddHeader("Content-Disposition", "attachment; filename=General_Attendance_" + ddl_mois.SelectedValue + "_" + tbx_annee.Text + ".png");
                    Response.BinaryWrite(stream.ToArray()); //On envoie l'image contenue dans le stream
                    Response.Flush();
                    Response.End();
                }

                #endregion export

            }



        }
        catch (Exception ee)
        {
            Functions.Error(new Exception(ee.StackTrace.ToString() + Environment.NewLine + ee));
        }




    }

    #endregion Boutons

    /// <summary>
    /// Lors du changement de texte, on rafrachit le label donnant la hauteur de l'image
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void tbx_tailleImg_TextChanged(object sender, EventArgs e)
    {
        RefreshGrid();
        double height = (int.Parse(tbx_tailleImg.Text) / 5) / 2.8;
        int heightCase = (int)height; //On prend une valeur entière
        lbl_hautImg.Text = "" + (heightCase + gvw_assiduite.Rows.Count * heightCase);
        tbx_hautImg.Text = lbl_hautImg.Text;
    }

    /// <summary>
    /// Permet de changer le champs de modification de taille (largeur ou hauteur)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void cbx_tailleImg_CheckedChanged(object sender, EventArgs e)
    {
        if (cbx_tailleImg.Checked)
        {
            tbx_tailleImg.Visible = false;
            lbl_tailleImg.Visible = true;
            lbl_tailleImg.Text = tbx_tailleImg.Text;
            lbl_hautImg.Visible = false;
            tbx_hautImg.Visible = true;
            tbx_hautImg.Text = lbl_hautImg.Text;
        }
        else
        {
            tbx_tailleImg.Visible = true;
            lbl_tailleImg.Visible = false;
            tbx_tailleImg.Text = lbl_tailleImg.Text;
            lbl_hautImg.Visible = true;
            tbx_hautImg.Visible = false;
            lbl_hautImg.Text = tbx_hautImg.Text;
        }
    }

    /// <summary>
    /// Lors du changement de texte, on rafrachit le label donnant la largeur de l'image
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void tbx_hautImg_TextChanged(object sender, EventArgs e)
    {
        RefreshGrid();
        double width = (14 * (int.Parse(tbx_hautImg.Text))) / (1 + gvw_assiduite.Rows.Count);
        int widthInt = (int)width;
        lbl_tailleImg.Text = "" + widthInt;
        tbx_tailleImg.Text = lbl_tailleImg.Text;

    }
}