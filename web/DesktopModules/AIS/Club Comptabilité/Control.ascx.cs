
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


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AIS;
using DotNetNuke.Entities.Modules;

public partial class DesktopModules_AIS_Club_Comptabilite_Control : PortalModuleBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        RefreshGrid(); 
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Sort":

                break;
            case "detail":
                GridView gv = sender as GridView;
                RefreshGrid2(gv, (gv.PageIndex * gv.PageSize) + Convert.ToInt32(e.CommandArgument));
                
                break;
        }
    }
    void RefreshGrid2(GridView gv,int index)
    {
            List<Payment> liste = gv.DataSource as List<Payment>;

            Payment n = liste[index];
            HF_id.Value = "" + n.id;

            TXT_Titre.Text = "" + n.title;
            TXT_Dt.Text = n.dt.ToString("dd/MM/yyyy");
            TXT_Editor.Text = n.text;
            HF_Type_Payment.Value = n.type;
            switch (n.type)
            {
                case "T":
                    TXT_Payment.Text = "Taxe per capita";
                    break;
                case "M":
                    TXT_Payment.Text = "Manifestation";
                    break;
            }
            LBL_libelle1.Text = n.wording1;
            TXT_montant1.Text = ""+n.amount1;
            LBL_libelle2.Text = n.wording2;
            TXT_montant2.Text = ""+n.amount2;
            Cloture.Value = n.closing==true?"O":"N";
            P_Cloture.Visible = n.closing && n.type.Equals("M");

            tri2.Value = "dt";
            sens2.Value = "DESC";

            Check_Buttons();

            Panel1.Visible = false;
            Panel2.Visible = true;
            RefreshGridOrders();
    }
    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        tri.Value = "" + e.SortExpression;
        sens.Value = sens.Value == "ASC" ? sens.Value = "DESC" : sens.Value = "ASC";
        RefreshGrid();
    }

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
    void RefreshGrid()
    {
        List<Payment> liste = DataMapping.ListPayments(index: GridView1.PageIndex, max: GridView1.PageSize, sort: tri.Value + " " + sens.Value);
        GridView1.DataSource = liste;
        GridView1.DataBind();
    }
    protected void GridView2_Sorting(object sender, GridViewSortEventArgs e)
    {
        tri2.Value = "" + e.SortExpression;
        sens2.Value = sens2.Value == "ASC" ? sens2.Value = "DESC" : sens2.Value = "ASC";
        RefreshGridOrders();
    }
    void RefreshGridOrders()
    {
        List<Order> liste = DataMapping.ListOrderByPayment(HF_id.Value, sort: tri2.Value + " " + sens2.Value,cric : Functions.CurrentCric);
        GridView2.DataSource = liste;
        GridView2.DataBind();       
    }
    protected void BT_Annuler_Click(object sender, EventArgs e)
    {
        RefreshGrid();
        Panel1.Visible = true;
        Panel2.Visible = false;
    }
    void Check_Buttons()
    {
        int nbcommandes = 0;
        if (HF_id.Value != "")
            nbcommandes = DataMapping.NbOrderByPayment(HF_id.Value);

        BT_Nouvelle_Order.Visible = Functions.CurrentCric != 0 && HF_Type_Payment.Value == "M" && Cloture.Value.Equals("N");
        P_Montant1.Visible = HF_Type_Payment.Value == "T" || HF_Type_Payment.Value == "M";
        P_Montant2.Visible = HF_Type_Payment.Value == "M";
        

    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItem == null)
            return;
        HyperLink HL_Paiement = e.Row.FindControl("HL_Paiement") as HyperLink;
        HL_Paiement.NavigateUrl = Functions.UrlAddParam(Const.ORDER_PAY_URL, "id", ((Order)e.Row.DataItem).guid);
        HL_Paiement.Visible = ((Order)e.Row.DataItem).rule == Const.NO;
       
        HyperLink HL_Detail = e.Row.FindControl("HL_Detail") as HyperLink;
        HL_Detail.NavigateUrl = Functions.UrlAddParam(Const.ORDER_VIEW_URL, "id", ((Order)e.Row.DataItem).guid);
    }



    float montant_membre ;
    float montant_invite ;
    float montant_total {
        get {
            if(ViewState["montant_total"]==null)
                ViewState["montant_total"]=0;
            return (float)ViewState["montant_total"];
        }
        set {
            ViewState["montant_total"]=value;
        }
    }
     List<KeyValuePair<string, string>> membres_invites
     {
        get {
            if(ViewState["membres_invites"]==null)
                ViewState["membres_invites"]=  new  List<KeyValuePair<string, string>>();
            return (List<KeyValuePair<string, string>>) ViewState["membres_invites"];
        }
        set {
            ViewState["membres_invites"]=value;
        }
    }

    protected void BT_Valider_Click(object sender, EventArgs e)
    {
        if (montant_total <= 0)
            return;
        
        Club club = Functions.CurrentClub;
        if (club == null)
            return;

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
        commande.amount = montant_total;

        foreach (Member membre in membres)
        {
            foreach (KeyValuePair<string, string> membre_invite in membres_invites)
            {
                if (membre_invite.Key.Equals("" + membre.id))
                {
                    Order.Detail detail = new Order.Detail();
                    detail.wording = membre.surname + " " + membre.name + " (" + membre.nim + ")";
                    detail.amount = float.Parse(TXT_montant1.Text);
                    detail.quantity = 1;
                    detail.unitary = float.Parse(TXT_montant1.Text);
                    detail.id_parent = 0;
                    commande.Details.Add(detail);

                    string[] invites = membre_invite.Value.Split(new string[] { "\n","\r" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string st in invites)
                    {
                        string invite = st.Trim();
                        if (!invites.Equals(""))
                        {
                            detail = new Order.Detail();
                            detail.wording = invite + " (invité par " + membre.surname+" "+membre.name + ")";
                            detail.amount = float.Parse(TXT_montant2.Text);
                            detail.quantity = 1;
                            detail.unitary = float.Parse(TXT_montant2.Text);
                            detail.id_parent = membre.nim;
                            commande.Details.Add(detail);
                        }
                    }
                }
            }   
        }


        if (DataMapping.UpdateOrder(commande))
        {
            Panel4.Visible = false;
            Panel2.Visible = true;
            RefreshGrid2(GridView1,0);
            
            
        }
        else
        {
            TXT_Result.Text = "Erreur de validation de la commande, veuillez contacter <a href='mailto:webmaster@rotary1730.org'>webmaster@rotary1730.org</a>";
            TXT_Result.Visible = true;
            BT_Valider.Visible = false;
        }
        
    }
    protected void BT_Verifier_Click(object sender, EventArgs e)
    {
        membres_invites = new List<KeyValuePair<string, string>>();
        int total_membres = 0;
        int total_invites = 0;
        string texte = "<ul>";
        foreach (Control ctrl in P_Members.Controls)
        {
            if (ctrl is CheckBox)
            {
                CheckBox cb = ctrl as CheckBox;
                
                ViewState[cb.ID] = cb.Checked;
                if (cb.Checked)
                {
                    total_membres++;
                    texte += "<li>"+cb.Text + "</li>";

                    

                    TextBox tb = P_Members.FindControl("TB_" + cb.ID.Replace("CB_", "")) as TextBox;
                    ViewState[tb.ID] = tb.Text;
                    string[] invites = tb.Text.Split(new string[] { "\n","\r" }, StringSplitOptions.RemoveEmptyEntries);
                    string soustexte = "";
                    foreach (string st in invites)
                    {
                        string invite = st.Trim();
                        if (!invites.Equals(""))
                        {
                            total_invites++;
                            soustexte += "<li>" + invite + "</li>";
                        }
                    }
                    if (!soustexte.Equals(""))
                    {
                        texte += "<ul>" + soustexte + "</ul>";
                    }

                    KeyValuePair<string, string> kvp = new KeyValuePair<string, string>(cb.ID.Replace("CB_", ""), tb.Text);
                    membres_invites.Add(kvp);

                }
            }
        }
        texte += "</ul><br/>";
        texte += "Nombre membres : "+total_membres+"<br/>";
        texte += "Nombre d'invités : " + total_invites + "<br/>";
        texte += "<br/>";
        montant_membre = float.Parse(TXT_montant1.Text);
        montant_invite = float.Parse(TXT_montant2.Text);
        montant_total = (montant_membre * total_membres) + (montant_invite * total_invites);
        texte += "Montant total : " + montant_total +" €";
        BT_Valider.Visible = montant_total > 0;
        LIT_Order.Text = texte;
        Panel3.Visible = false;
        Panel4.Visible = true;
    }
    protected void BT_Retour_Order_Click(object sender, EventArgs e)
    {
        InitListMembers();
        Panel3.Visible = true;
        Panel4.Visible = false;
    }
    protected void BT_Annuler_Order_Click(object sender, EventArgs e)
    {
        P_Boutons.Visible = true;
       
        Panel3.Visible = false;
    }
    protected void BT_Nouvelle_Order_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        P_Boutons.Visible = false;
        Panel3.Visible = true;

    }
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        InitListMembers();
    }
    void InitListMembers()
    {
        P_Members.Controls.Clear();
        if (Functions.CurrentCric == 0)
            return;
        List<Member> membres = DataMapping.ListMembers(Functions.CurrentCric, "", "", "name asc", index: 0, max: 1000);
        foreach (Member membre in membres)
        {
            Panel p = new Panel();
            p.ID = "P_" + membre.id;
            
            CheckBox cb = new CheckBox();
            cb.ID = "CB_" + membre.id;
            cb.Text = membre.surname + " " + membre.name;
            if (ViewState["CB_" + membre.id] != null)
                cb.Checked = (bool)ViewState["CB_" + membre.id];
            P_Members.Controls.Add(cb);
            Label l = new Label();
            l.ID = "L_" + membre.id;
            l.Text = "Accompagné";
            if(membre.IsWoman())
                l.Text += "e";
            l.Text += " par (une personne par ligne) : ";
            p.Controls.Add(l);
            TextBox tb = new TextBox();
            if (ViewState["TB_" + membre.id] != null)
                tb.Text = "" + ViewState["TB_" + membre.id];
            tb.TextMode = TextBoxMode.MultiLine;
            tb.ID = "TB_" + membre.id;
            p.Controls.Add(tb);
            if(cb.Checked)
                p.CssClass = "commande_invite_visible";
            else
                p.CssClass = "commande_invite_invisible";
            P_Members.Controls.Add(p);
            
            Literal br = new Literal();
            br.Text = "<br />";
            P_Members.Controls.Add(br);
            cb.Attributes.Add("onchange", "javascript: AC('" + cb.ClientID + "','" + p.ClientID + "');");

        }
    }
}