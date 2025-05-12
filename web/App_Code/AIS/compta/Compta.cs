using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Description résumée de Compta
/// </summary>
public class Compta
{
    public class Domaine {     
        public string libelle { get; set; }
        public int val { get; set; }
    }

    public class Parametres {
        public string cotisation { get; set; }
        public int moisCotisationAnnuelle { get; set; }
        public int jourCotisationAnnuelle { get; set; }
        
        public bool repasInclus {  get; set; }
        public decimal prixDuRepas { get; set; }
        public decimal prixDeLAperitif { get; set; }
        public decimal prixDuRepasVisiteur { get; set; }
        public decimal prixDeLAperitifVisiteur { get; set; }
        public decimal montantCotisation { get; set; }
        public decimal montantCotisationDipenseAssiduite {  get; set; }
    }

    public class Membre {

        public int nim { get; set; }
        public string prenom { get;set; }
        public string nom { get; set; }

        public Membre(){
            this.compte = new Compte();            
        }

        public Compte compte { get; set; }

        public class Compte
        {
            public Compte(){
                this.lignes = new List<Ligne>();
            }

            public decimal debit { get; set; }
            public decimal credit { get; set; }
            public decimal solde { get; set; }

            public List<Ligne> lignes { get; set; }

            public class Ligne
            {
                public DateTime date { get; set; }
                public Guid? guid { get; set; }
                public int? numero { get; set; }
                public string libelle { get; set; }
                public int type { get; set; }
                public bool? provisoire { get; set; }
                public string typeLibelle { get; set; }
                public string lettrage { get; set; }
                public decimal debit { get; set; }
                public decimal credit { get; set; }
                public decimal solde { get; set; }

                public int document_id { get; set; }
            }
        }

        
    }

    public class Element
    {
        public int? id { get; set; }
        public Guid? guid { get; set; }
        public int district_id { get; set; }
        public int cric {  get; set; }
        public int? numero { get; set; }
        public int type { get; set; }
        public bool? provisoire { get; set; }
        public int moyenPaiement { get; set; }
        public string reference { get; set; }

        public DateTime date { get; set; }
        public DateTime? dateReglement { get; set; }
        public string lettrage { get; set; }
        public DateTime? dateLettrage { get; set; }
        public string libelle { get; set; }

        public int? nim { get; set; }
        public string raisonSociale { get; set; }
        public string nom {  get; set; }
        public string prenom {  get; set; }
        public string email {  get; set; }
        public string ad1 { get; set; }
        public string ad2 { get; set; }
        public string cp {  get; set; }
        public string ville { get; set; }
        public string pays { get;set; }

        public decimal montant {  get; set; }

        public string detail { get; set; }

        public int document_id { get; set; }

        public Element() {
            lignes = new List<Ligne>();
            provisoire = true;
        }

        public List<Ligne> lignes { 
            get{
                var li = new List<Ligne>();
                if(!string.IsNullOrEmpty(detail)){
                    li = Yemon.dnn.Functions.Deserialize<List<Ligne>>(detail);
                }
                return li;

            }
            set{
                detail = Yemon.dnn.Functions.Serialize(value);
            }
        } 

        public class Ligne
        {
            public bool? provisoire { get; set; }
            public string lettrage { get; set; }
            public string libelle { get; set; }
            public decimal montant { get; set; }
            public decimal qte { get; set; }
            public decimal total { get; set; }
           
        }
        
        public class Type 
        {
            public int id { get; set; }
            public string libelle { get; set; }
            public bool recette { get; set; }
            public bool membre { get; set; }
        }
    }    
}