
#region Copyrights

// RODI - https://rodi-platform.org
// Copyright (c) 2012-2023
// by SAS AIS : https://www.aisdev.net
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

using DotNetNuke.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AIS;
using DotNetNuke.Entities.Modules;
using System.IO;
using System.Drawing;
using Telerik.Web.UI;
using System.Data;
using System.Data.SqlClient;
using Argotic.Extensions.Core;
using DNN.Modules.SecurityAnalyzer.Components.Checks;

public partial class DesktopModules_AIS_Admin_Comptabilite_Control : PortalModuleBase
{
   /// <summary>
   /// Au chargement de la page, définit les controles à afficher et actualise le GridView
   /// </summary>
   /// <param name="sender"></param>
   /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
       

        if (TXT_Email_Sender.Text.Trim().Equals("")){
            TXT_Email_Sender.Text = UserInfo.Email;
        }
        if ("" + Functions.CurrentCric != HF_Cric.Value)
        {
            HF_Cric.Value = "" + Functions.CurrentCric;
            GridView1.PageIndex = 0;
            Panel1.Visible = true;
            Panel2.Visible = false;
        }

            RefreshGrid();         
    }

    /// <summary>
    /// Définit le script à exécuter en fonction de la commande sélectionnée sur le GridView
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Sort":

                break;
            case "detail":
                GridView gv = sender as GridView;
                int index = (gv.PageIndex * gv.PageSize) + Convert.ToInt32(e.CommandArgument);
                List<Payment> liste = gv.DataSource as List<Payment>;

                Payment n = liste[index];
                HF_id.Value = "" + n.id;
                
                TXT_Titre.Text = "" + n.title;
                TXT_Dt.Text = n.dt.ToString("yyyy-MM-dd");
                TXT_Editor.Text = n.text;
                
                LBL_libelle1.Text = n.wording1;
                TXT_montant1.Text = FromDouble(n.amount1);
                LBL_libelle2.Text = n.wording2;
                TXT_montant2.Text = FromDouble(n.amount2);
                TXT_Result.Text = "";
                TXT_Result_Mails.Text = "";
                tri2.Value = "club";
                sens2.Value = "ASC";

                
                Panel1.Visible = false;
                Panel2.Visible = true;
                RefreshGridOrders();
                Check_Buttons();

                break;
        }
    }

    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Sort":

                break;
            case "detail":
               
                break;
            case "Editer":
                Panel2.Visible = false;
                pnl_modif.Visible = true;
                hfd_id.Value =""+ e.CommandArgument;
                BindPanelModif();
                break;

        }
    }

    private void BindPanelModif()
    {
        Order o = DataMapping.GetOrder(hfd_id.Value);
        lbl_Titre.Text = "Règlement facture du club " + o.club;
        BindDDL(o.cric);
        ddl_members.Items.Insert(0, "");
        if(o.rule_par!=null && o.rule_par!="")
        {
            foreach(ListItem li in ddl_members.Items)
            {
                if (li.Text == o.rule_par)
                    li.Selected = true;
            }
        }
        if (o.rule_type != null && o.rule_type != "")
            rbl_type.SelectedValue = o.rule_type;
        tbx_amount.Text=FromDouble(o.amount);
        tbx_info.Text = ""+o.rule_info;
        btn_validate.CommandArgument = ""+o.id;
        if (o.rule_dt == Const.NO_DATE)
            o.rule_dt = DateTime.Now;
        tbx_date.Text = ""+ o.rule_dt.ToString("yyyy-MM-dd");
    }

    private void BindDDL(int cric)
    {
        ddl_members.Items.Clear();
        foreach (Member m in DataMapping.ListMembers(cric: cric))
        {      
            ddl_members.Items.Add(new ListItem(m.name + " " + m.surname, "" + m.id));
        }
    }

    /// <summary>
    /// Définit le type de tri à effectuer sur le GridView
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        tri.Value = "" + e.SortExpression;
        sens.Value = sens.Value == "ASC" ? sens.Value = "DESC" : sens.Value = "ASC";
        RefreshGrid();
    }

    /// <summary>
    /// Rafraichit le GridView et associe de nouvelles données lors d'un changement de page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (GridView1.PageIndex == e.NewPageIndex)
        {
            e.Cancel = true;
            return;
        }
        GridView1.PageIndex = e.NewPageIndex;
        RefreshGrid();
    }

    /// <summary>
    /// Définit le type de tri à effectuer sur le GridView
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView2_Sorting(object sender, GridViewSortEventArgs e)
    {
        tri2.Value = "" + e.SortExpression;
        sens2.Value = sens2.Value == "ASC" ? sens2.Value = "DESC" : sens2.Value = "ASC";
        RefreshGridOrders();
    }

    /// <summary>
    /// Actualise les données du GridView1
    /// </summary>
    void RefreshGrid()
    {
        List<Payment> liste = DataMapping.ListPayments(index: GridView1.PageIndex, max: GridView1.PageSize,sort: tri.Value+ " "+sens.Value);
        GridView1.DataSource = liste;
        GridView1.DataBind();
    }

    /// <summary>
    /// Actualise les données du GridView2
    /// </summary>
    void RefreshGridOrders()
    {
        List<Order> liste = DataMapping.ListOrderByPayment(HF_id.Value,sort: tri2.Value+ " "+sens2.Value);
        GridView2.DataSource = liste;
        GridView2.DataBind();
        P_GenerateOrders.Visible = liste.Count == 0;
        Lit_Info_Generation_Commandes.Visible = !BT_Generer_Orders.Visible;
        P_SendMail.Visible = liste.Count > 0;
    }

    /// <summary>
    /// Actualise le GridView, affiche le panel1 et cache le panel2
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BT_Annuler_Click(object sender, EventArgs e)
    {
        RefreshGrid();
        Panel1.Visible = true;
        Panel2.Visible = false;
    }

    /// <summary>
    /// Modifie ou ajoute le règlement 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BT_Valider_Click(object sender, EventArgs e)
    {
        try
        {
            Payment obj = new Payment();
            if (HF_id.Value != "")
            {
                obj = DataMapping.GetPayment(HF_id.Value);
            }
            obj.dt = TXT_Dt.Text != null ? DateTime.Parse(TXT_Dt.Text) : DateTime.Now;
            obj.text = Server.HtmlDecode(TXT_Editor.Text);
            obj.title = TXT_Titre.Text;
            obj.type = "T";
            obj.wording1 = LBL_libelle1.Text;
            obj.amount1 = TXT_montant1.Text == "" ? 0 : ToDouble(TXT_montant1.Text);
            if (obj.amount1 <= 0.01)
                throw new Exception("Veuillez saisir un montant");
            obj.wording2 = LBL_libelle2.Text;
            obj.amount2 = TXT_montant2.Text == "" ? 0 : ToDouble(TXT_montant2.Text);
            if (!DataMapping.UpdatePayment(obj))
                return;


            RefreshGrid();
            Panel1.Visible = true;
            Panel2.Visible = false;
            HideError();
            Check_Buttons();
        }
        catch(Exception ee)
        {
            Functions.Error(ee);
            ShowError(ee.Message);
        }
        
    }
    void HideError()
    {
        P_Error.Visible= false;
    }
    void ShowError(string msg)
    {
        TXT_Error.Text=msg;
        P_Error.Visible = true;
    }
    double ToDouble(string str)
    {
        double d = 0;
        str = str.Trim().Replace(".", ",");
        double.TryParse(str,out d);

        return d;
    }
    string FromDouble(double d)
    {
        return d.ToString().Replace(",",".");
    }
    /// <summary>
    /// Permet d'afficher les champs nécessaires à l'ajout d'un règlement
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BT_Ajouter_Click(object sender, EventArgs e)
    {

        HF_id.Value = "";
        TXT_Titre.Text = "";
        TXT_Dt.Text = DateTime.Now.ToString("yyyy-MM-dd");
        TXT_Editor.Text = "";
       
        Check_Buttons();
        RefreshGridOrders();
        Panel2.Visible = true;
        Panel1.Visible = false;

    }

    /// <summary>
    /// Supprime le règlement sélectionné, actualise le GridView et affiche le panel 1
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BT_Supprimer_Click(object sender, EventArgs e)
    {
        if (!DataMapping.DeletePayment(HF_id.Value))
        {
            return;
        }
        RefreshGrid();
        Panel1.Visible = true;
        Panel2.Visible = false;
    }

    /// <summary>
    /// Appelle la méthode Check_Buttons
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void RB_Type_SelectedIndexChanged(object sender, EventArgs e)
    {
        Check_Buttons();
    }

    /// <summary>
    /// Définit les éléments à afficher en fonction du radioButton sélectionné
    /// </summary>
    void Check_Buttons()
    {
        int nbcommandes = 0;
        if(HF_id.Value!="")    
            nbcommandes=  DataMapping.NbOrderByPayment(HF_id.Value);

        BT_Valider.Visible = true;// nbcommandes == 0;
        BT_Supprimer.Visible = nbcommandes == 0;
        BT_Export_Orders.Visible = nbcommandes > 0;
        BT_Export_Only_Transfers.Visible = nbcommandes > 0;
        Lit_Info_Generation_Commandes.Visible = !BT_Generer_Orders.Visible;

       
        LBL_libelle1.Text = "Montant par membre :";
        //TXT_montant1.Value = 50;
        P_Montant1.Visible = true;
        P_Montant2.Visible = false;
        BT_Generer_Orders.Visible = HF_id.Value!="" && !DataMapping.OrdersComplete(HF_id.Value) && ToDouble(TXT_montant1.Text)>0;
        Lit_Info_Generation_Commandes.Visible = !BT_Generer_Orders.Visible;

        P_Admin_Commands.Visible = (UserInfo.IsAdmin || UserInfo.IsSuperUser) && Panel2.Visible && nbcommandes>0;

    }

    /// <summary>
    /// Crée une commande associée à un club (si elle n'as pas déjà été créée) dont le détail correspond aux informations de chaque membre
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BT_Generer_Orders_Click(object sender, EventArgs e)
    {
        
        List<Club> clubs = DataMapping.ListClubs(club_type:"rotary");
        List<Order> commandes = DataMapping.ListOrderByPayment(HF_id.Value);
        foreach (Club club in clubs)
        {
            bool dejacommande = false;
            foreach(Order commande in commandes)
                if (commande.cric == club.cric)
                {
                    dejacommande = true;
                    break;
                }
            if (!dejacommande)
            {
             

                List<Member> membres = DataMapping.ListMembers(cric: club.cric, sort: "name ASC");


                Order commande = new Order();
                commande.cric = club.cric;
                commande.club = club.name;
                commande.dt = DateTime.Now;
                commande.id_payment = HF_id.Value;
                commande.rule = "N";
                commande.rule_dt = Const.NO_DATE;
                commande.rule_info = "";
                commande.rule_par = "";
                commande.rule_type = "";
                if (!String.IsNullOrEmpty(club.payment_method))
                    commande.rule_type = club.payment_method;
                
                foreach (Member membre in membres)
                {
                    Order.Detail detail = new Order.Detail();
                    detail.wording = membre.surname + " " + membre.name + " (" + membre.nim + ")";
                    detail.amount = ToDouble(TXT_montant1.Text);
                    detail.quantity = 1;
                    detail.unitary = ToDouble(TXT_montant1.Text);
                    detail.id_parent = 0;
                    if(membre.honorary_member=="N")
                        commande.Details.Add(detail);
                }
                commande.amount = ToDouble(TXT_montant1.Text) * (commande.Details.Count- club.nb_free_of_charge);


                if (DataMapping.UpdateOrder(commande))
                    TXT_Result.Text += "<br/>" + club.name + " commande pour " + membres.Count + " membres";
                else
                    TXT_Result.Text += "<br/>Erreur commande : " + club.name;





            }
        }
        RefreshGridOrders();
        Check_Buttons();
    }

    /// <summary>
    /// Lors du Bind du GridView2, récupère les inforamtions nécessaires aux autres méthodes
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItem == null)
            return;

        Label lbl_paid = (Label)e.Row.FindControl("lbl_paid");

        if (((Order)e.Row.DataItem).rule == "O")
            lbl_paid.Text = "Oui";

        //RadioButtonList RB_Regle = e.Row.FindControl("RB_Regle") as RadioButtonList;
        //RB_Regle.SelectedValue = ((Order)e.Row.DataItem).rule;

        HyperLink HL_Detail = e.Row.FindControl("HL_Detail") as HyperLink;
        HL_Detail.NavigateUrl = Functions.UrlAddParam(Const.ORDER_VIEW_URL, "id", ((Order)e.Row.DataItem).guid);
    }

    /// <summary>
    /// Modifie la commande avec le nouvel item sélectionné
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void RB_Regle_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            RadioButtonList RB_Regle = sender as RadioButtonList;
            GridViewRow row = (GridViewRow)RB_Regle.NamingContainer;
            int id_commande = int.Parse(row.Cells[1].Text);
            DataMapping.UpdateOrderRule(id_commande, RB_Regle.SelectedValue);
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }

    }

    /// <summary>
    /// Exporte les commandes vers un fichier excel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BT_Export_Orders_Click(object sender, EventArgs e)
    {
        DataSet ds = DataMapping.ExecSql("SELECT cric,club,id as 'no commande',amount as 'montant',type_rule as 'moyen',par_rule as 'par qui',dt,dt_rule as 'date reglement',[rule] as 'regle',info_rule as 'commentaire'," +
            "(select top 1 RoleName from Roles where RoleID = (SELECT roles from ais_clubs WHERE cric = O.cric)) as groupe," +
            "(select top 1 displayname from users where userid in (select top 1 UserID from UserRoles where RoleID = (SELECT roles from ais_clubs WHERE cric = O.cric))) as adg,"+
            "(select top 1 email from users where userid in (select top 1 UserID from UserRoles where RoleID = (SELECT roles from ais_clubs WHERE cric = O.cric))) as email " +
            "FROM [ais_orders] O  where id_payment='" + HF_id.Value + "' order by club");

        List<DataTable> liste = new List<DataTable>();
        liste.Add(ds.Tables[0]);
        Media media = DataMapping.ExportDataTablesToXLS(liste, "Liste des commandes au " + DateTime.Now.ToShortDateString().Replace("/", "-") + ".xlsx", Aspose.Cells.SaveFormat.Xlsx);
        string guid = Guid.NewGuid().ToString();
        Session[guid] = media;
        Response.Redirect(Const.MEDIA_DOWNLOAD_URL + "?id=" + guid);
    }

    /// <summary>
    /// Exporte les transactions vers un fichier Excel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BT_Exporter_Transactions_CB_Click(object sender, EventArgs e)
    {
        DataSet ds = DataMapping.ExecSql("SELECT [dt],[data] FROM [ais_mercanet_resp]");

        List<DataTable> liste = new List<DataTable>();
        liste.Add(ds.Tables[0]);
        Media media = DataMapping.ExportDataTablesToXLS(liste, "List des transactions au " + DateTime.Now.ToShortDateString().Replace("/", "-") + ".xls", Aspose.Cells.SaveFormat.Excel97To2003);
        string guid = Guid.NewGuid().ToString();
        Session[guid] = media;
        Response.Redirect(Const.MEDIA_DOWNLOAD_URL + "?id=" + guid);
       
    }

    /// <summary>
    /// Exporte les inscrits vers un fichier Excel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BT_Exporter_Inscrits_Click(object sender, EventArgs e)
    {
            DataSet ds = DataMapping.ExecSql("SELECT C.club as 'Nom club',D.wording as 'Nom participant',C.dt as 'Inscrit le',C.[rule] as 'Payé'  FROM [ais_orders_details] D,[ais_orders] C where D.id_order = C.id and C.id_payment='" + HF_id.Value + "' order by C.club,D.wording");

            List<DataTable> liste = new List<DataTable>();
            liste.Add(ds.Tables[0]);
            Media media = DataMapping.ExportDataTablesToXLS(liste, "List des inscrits au " + DateTime.Now.ToShortDateString().Replace("/", "-") + ".xls", Aspose.Cells.SaveFormat.Excel97To2003);
            string guid = Guid.NewGuid().ToString();
            Session[guid] = media;
            Response.Redirect(Const.MEDIA_DOWNLOAD_URL + "?id=" + guid);
       
    }

    protected void btn_validate_Click(object sender, EventArgs e)
    {
        Order o = DataMapping.GetOrder(hfd_id.Value);
        o.amount = ToDouble(tbx_amount.Text);
        o.rule_type = rbl_type.SelectedValue;
        o.rule_par = ddl_members.SelectedItem.Text;
        o.rule_info = tbx_info.Text;
        DateTime dt = DateTime.Now;
        DateTime.TryParse("" + tbx_date.Text, out dt);
        o.rule_dt = dt;
        o.rule = "O";
       // o.rule_dt = DateTime.Now;

        DataMapping.UpdateOrder(o);
        RefreshGridOrders();
        Panel2.Visible = true;
        pnl_modif.Visible = false;
        tbx_info.Text = "";
    }

    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        tbx_info.Text = "";
        pnl_modif.Visible = false;
        Panel2.Visible = true;
    }

    protected void BT_Send_Emails_Click(object sender, EventArgs e)
    {
        TXT_Result_Mails.Text = "";
        List<Order> commandes = DataMapping.ListOrderByPayment(HF_id.Value);
        foreach(Order order in commandes)
        {
            
            List<Affectation> affectations = DataMapping.ListAffectationRY(order.cric,Functions.GetRotaryYear());
            bool notresorier = true;
            List<string> emails = new List<string>();
            foreach(Affectation a in affectations)
            {
                if(a.function.Equals("Trésorier") || a.function.Equals("Président") || a.function.Equals("Secrétaire"))
                {
                    TXT_Result_Mails.Text = TXT_Result_Mails.Text + order.club + " : " + a.name+"<br/>";
                    
                    Member m = DataMapping.GetMemberByNim(a.nim);
                    if(m!=null)
                    {
                        notresorier = false;
                        emails.Add(m.email);
                    }
                }
            }
            
            if (notresorier)
            {
                TXT_Result_Mails.Text =TXT_Result_Mails.Text  +"<strong style='color: red'>ATTENTION : " + order.club + " pas de trésorier, ni président, ni secrétaire déclaré</strong><br/>";
            }
            else
            {
                string url =  Functions.UrlAddParam(Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, "") + Const.ORDER_VIEW_URL, "id", order.guid);

                if(CB_Just_A_Test.Checked)
                {
                    Functions.SendMail(TXT_Email_Sender.Text, TXT_Email_Sender.Text, TXT_Titre.Text, Server.HtmlDecode(TXT_Editor.Text).Replace("#URL#", url).Replace("#url#", url));
                }
                else
                {
                    foreach (string em in emails)
                        Functions.SendMail(TXT_Email_Sender.Text, em, TXT_Titre.Text, Server.HtmlDecode(TXT_Editor.Text).Replace("#URL#", url).Replace("#url#", url));
                }
            }
            if(CB_Just_A_Test.Checked)
                break;
        }
        Functions.SendMail(TXT_Email_Sender.Text, "Rapport envoi emails : " + TXT_Titre.Text, TXT_Result_Mails.Text);
    }

    public string ShowDate(DateTime d)
    {
        if (d == Const.NO_DATE)
            return "";
        return d.ToString("dd/MM/yyyy");
    }

    
    protected void BT_Delete_Invoices_Click(object sender, EventArgs e)
    {
        DataMapping.ExecSql("DELETE FROM ais_orders_details WHERE id_order IN (SELECT id FROM ais_orders WHERE id_payment='" + HF_id.Value + "'");
        DataMapping.ExecSql("DELETE FROM ais_orders WHERE id_payment='" + HF_id.Value + "'");
        BT_Valider_Click(sender, e);
    }

    protected void BT_Validate_Transfers_Click(object sender, EventArgs e)
    {

    }

    protected void BT_Export_Only_Transfers_Click(object sender, EventArgs e)
    {
        DataSet ds = DataMapping.ExecSql("SELECT cric,club,id as 'no commande',amount as 'montant',type_rule as 'moyen',par_rule as 'par qui',dt,dt_rule as 'date reglement',[rule] as 'regle',info_rule as 'commentaire'," +
           "(select top 1 RoleName from Roles where RoleID = (SELECT roles from ais_clubs WHERE cric = O.cric)) as groupe," +
           "(select top 1 displayname from users where userid in (select top 1 UserID from UserRoles where RoleID = (SELECT roles from ais_clubs WHERE cric = O.cric))) as adg," +
           "(select top 1 email from users where userid in (select top 1 UserID from UserRoles where RoleID = (SELECT roles from ais_clubs WHERE cric = O.cric))) as email " +
           "FROM [ais_orders] O  where id_payment='" + HF_id.Value + "' and type_rule='Prélèvement'  order by club");

        List<DataTable> liste = new List<DataTable>();
        liste.Add(ds.Tables[0]);
        Media media = DataMapping.ExportDataTablesToXLS(liste, "Liste des commandes par prélèvement au " + DateTime.Now.ToShortDateString().Replace("/", "-") + ".xlsx", Aspose.Cells.SaveFormat.Xlsx);
        string guid = Guid.NewGuid().ToString();
        Session[guid] = media;
        Response.Redirect(Const.MEDIA_DOWNLOAD_URL + "?id=" + guid);
    }
}