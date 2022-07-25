using AIS;
using DotNetNuke.Common;
using DotNetNuke.Entities.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class DesktopModules_AIS_Admin_Section_Selecteur_Section_Selecteur : PortalModuleBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        creerOrganigramme("AARD");
    }

    #region Table Domain

    /// <summary>
    /// Permet de créer les onglets sous forme d'un organigramme
    /// </summary>
    /// <param name="nomDomain">Le domaine dans lequel sont stockées les informations des onglets</param>
    public void creerOrganigramme(string nomDomain)
    {
        try
        {
            #region decalage
            //On cherche à placer les onglets suivant l'organigramme. On représente chaque onglet par son ID dans une liste d'int. Pour symboliser un décalage, on ajoutera un 0. Ainsi, un entier précédé d'un 0 sera l'enfant du dernier entier non précédé d'un 0. La liste se crée de la manière suivante :
            List<Domain> listeDomains = DataMapping.GetListDomain(nomDomain, "");
            List<int> listeId = new List<int>();
            for (int i = 0; i < listeDomains.Count; i++)
            {
                if (!listeId.Contains(listeDomains[i].id))
                {
                    if (listeDomains[i].parent == 0)
                        listeId.Add(listeDomains[i].id);
                    else
                    {
                        listeId.Add(0);
                        listeId.Add(listeDomains[i].id);
                    }

                    int j = i;
                    int decalage = 1;
                    while (aUnEnfant(listeDomains[j]) && j < listeDomains.Count)
                    {//tant que l'onglet a un enfant, il faut récupérer cet enfant et le placer après n+1 zéros. n étant le nombre de zéros précédant l'onglet parent
                        for (int k = 0; k < decalage; k++)
                            listeId.Add(0);
                        listeId.Add(idEnfant(listeDomains[j]));
                        decalage++;
                        Domain domEnf = new Domain();
                        domEnf.id = idEnfant(listeDomains[j]);
                        domEnf.domain = listeDomains[j].domain;
                        j = trouverPos(domEnf);
                    }
                }
            }

            #endregion decalage


            #region Bouton ou label
            //Ici, on utilise la liste précédemment créée pour ajouter les controles dans notre panel. Les derniers enfants seront des Boutons et les parents seront des Labels
            for (int i = 0; i < listeId.Count; i++)
            {
                if (((i + 1 >= listeId.Count || listeId[i + 1] != 0) && listeId[i] != 0))
                {//Si l'int suivant n'est pas un zéro et que l'int actuel n'est pas un zéro ou qu'il est le dernier de la liste, on crée un Bouton
                    int w = 0;
                    while (listeDomains[w].id != listeId[i])
                        w++;
                    System.Web.UI.WebControls.LinkButton btn = new LinkButton();
                    btn = (LinkButton)creerControl(listeDomains[w].wording, btn);
                    pnl_domaine.Controls.Add(btn);
                    HtmlGenericControl br = new HtmlGenericControl("br");
                    pnl_domaine.Controls.Add(br);
                }
                else if (listeId[i] != 0 && listeId[i + 1] == 0)
                {//Si l'int actuel n'est pas un zéro mais que le suivant en est un, on crée un Label 
                    if (nbZeros(listeId, i, "apres") > nbZeros(listeId, i, "avant"))
                    {
                        int w = 0;
                        while (listeDomains[w].id != listeId[i])
                            w++;
                        System.Web.UI.WebControls.Label lbl = new Label();
                        lbl = (Label)creerControl(listeDomains[w].wording, lbl);
                        pnl_domaine.Controls.Add(lbl);
                        HtmlGenericControl br = new HtmlGenericControl("br");
                        pnl_domaine.Controls.Add(br);
                    }
                    else
                    {
                        int w = 0;
                        while (listeDomains[w].id != listeId[i])
                            w++;
                        System.Web.UI.WebControls.LinkButton btn = new LinkButton();
                        btn = (LinkButton)creerControl(listeDomains[w].wording, btn);
                        pnl_domaine.Controls.Add(btn);
                        HtmlGenericControl br = new HtmlGenericControl("br");
                        pnl_domaine.Controls.Add(br);
                    }

                }
                else if (listeId[i] == 0)
                {//Si l'int actuel est un 0, on crée un décalage
                    Literal nbsp = new Literal();
                    nbsp.Text = "&nbsp &nbsp &nbsp";
                    pnl_domaine.Controls.Add(nbsp);
                }
            }
            #endregion Bouton ou label
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
    }

    /// <summary>
    /// Définit si l'onglet possède un enfant
    /// </summary>
    /// <param name="dom">Domain à étudier</param>
    /// <returns>Vérification</returns>
    public bool aUnEnfant(Domain dom)
    {
        List<Domain> listDom = DataMapping.GetListDomain(dom.domain, "");
        foreach (Domain domaine in listDom)
        {//Parcours la liste de domaines jusqu'à trouver l'enfant du domaine
            if (dom.id == domaine.parent)
                return true;
        }
        return false;
    }

    /// <summary>
    /// Crée un contrôle du type spécifié (Bouton ou Label)
    /// </summary>
    /// <param name="nom">Nom associé au contrôle</param>
    /// <param name="type">Type du contrôle</param>
    /// <returns>Le contrôle créé</returns>
    public Control creerControl(string nom, Control type)
    {
        if (type.GetType() == typeof(LinkButton))
        {//Création d'un Bouton
            LinkButton btn = new LinkButton();
            btn.ID = "btn_" + nom;
            string nomEvent = btn.ID + "_Click";
            btn.Text = nom;
            btn.Click += new EventHandler(btn_click);
            btn.Width = 190;
            return btn;
        }
        else if (type.GetType() == typeof(Label))
        {//Création d'un Label
            Label lbl = new Label();
            lbl.ID = "lbl_" + nom;
            lbl.Text = nom;
            return lbl;
        }
        else
            throw new Exception("Type de controle non reconnu ou non pris en charge");
    }

    /// <summary>
    /// Cherche l'ID de l'enfant d'un domaine
    /// </summary>
    /// <param name="dom">Domain parent</param>
    /// <returns>ID du domaine enfant</returns>
    public int idEnfant(Domain dom)
    {
        if (!aUnEnfant(dom)) //On vérifie que le domaine a bien un enfant
            throw new Exception("Pas d'enfants");
        List<Domain> listeDom = DataMapping.GetListDomain(dom.domain, "");
        for (int i = 0; i < listeDom.Count; i++)
        {//On parcourt la liste jusqu'à trouver l'ID de l'enfant
            if (listeDom[i].parent == dom.id)
                return listeDom[i].id;
        }
        throw new Exception("ID introuvable");
    }

    /// <summary>
    /// Trouve la position d'un domaine dans la liste de domaine 
    /// </summary>
    /// <param name="dom">Le domaine à chercher</param>
    /// <returns>Index de la position dans la liste</returns>
    public int trouverPos(Domain dom)
    {
        List<Domain> liste = DataMapping.GetListDomain(dom.domain, "");
        for (int i = 0; i < liste.Count; i++)
        {//On parcourt la liste de domaines jusqu'à trouver la position du domaine
            if (liste[i].id == dom.id)
                return i;
        }
        throw new Exception("Id introuvable");
    }

    /// <summary>
    /// Compte le nombre de zéros avant ou après une position
    /// </summary>
    /// <param name="liste">List à parcourir</param>
    /// <param name="position">La position à partir de laquelle chercher</param>
    /// <param name="typeRecherche">Le sens dans lequel effectuer la recherche</param>
    /// <returns>Nombre de zéros trouvés avant un entier différent</returns>
    public int nbZeros(List<int> liste, int position, string typeRecherche)
    {
        int i = 1;
        int compteur = 0;
        if (typeRecherche == "avant")
        {//Recherche les zéros avant la position
            while (position - i > 0 && liste[position - i] == 0)
            {
                compteur++;
                i++;
            }
            return compteur;
        }
        else if (typeRecherche == "apres")
        {//Recherche les zéros après la position
            while (position + i < liste.Count && liste[position + i] == 0)
            {
                compteur++;
                i++;
            }
            return compteur;
        }
        else throw new Exception("Type de recherche non pris en charge ou incorrect");
    }

    /// <summary>
    /// Affiche le contenu en fonction de l'onglet cliqué. Vérifie si l'utilisateur à les autorisations pour avoir accès aux boutons de modification
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_click(object sender, EventArgs e)
    {

        LinkButton btn = (LinkButton)sender;
        String url = Globals.NavigateURL();
        switch (btn.ID)
        {
            case ("btn_Gouverneurs et Conseillers"):
                url = Functions.UrlAddParam(url, "section", "Gouverneur");
                break;
            case ("btn_Le Bureau"):
                url = Functions.UrlAddParam(url, "section", "Bureau");
                break;
            case ("btn_La Fondation"):
                url = Functions.UrlAddParam(url, "section", "Fondation");
                break;
            case ("btn_Alpes Maritimes et Monaco"):
                url = Functions.UrlAddParam(url, "section", "Adjoint Alpes-Maritimes Monaco");
                break;
            case ("btn_Corse"):
                url = Functions.UrlAddParam(url, "section", "Adjoint Corse");
                break;
            case ("btn_Var"):
                url = Functions.UrlAddParam(url, "section", "Adjoint Var");
                break;
            case ("btn_Les Commissions"):
                url = Functions.UrlAddParam(url, "section", "Commissions");
                break;
            case ("btn_Les présidents des clubs"):
                url = Functions.UrlAddParam(url, "section", "Présidents");
                break;
        }

        Response.Redirect(url);
    }

    #endregion Table domaine
}