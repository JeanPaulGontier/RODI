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
using AIS;
using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Data.SqlClient;
using Telerik.Web;
using Yemon.dnn.SIPro;

/// <summary>
/// Description résumée de ComptaHelper
/// </summary>
public class ComptaHelper
{

    public static List<Compta.Domaine> GetDomaine(string type)
    {
        var sql = new SqlCommand("select * from " + Const.TABLE_PREFIX + "c_domaines where type=@type order by id");
        sql.Parameters.AddWithValue("type", type);
        var liste = Yemon.dnn.DataMapping.ExecSql<Compta.Domaine>(sql);
        return liste;
    }

    

    public static Compta.Parametres GetParametres(int cric)
    {
        var item = Yemon.dnn.Helpers.GetItem(Const.DISTRICT_ID + ":" + cric + ":ComptaParametres", 0);
        if (item == null) return new Compta.Parametres();
        return Yemon.dnn.Functions.Deserialize<Compta.Parametres>("" + item);
    }


    public static void SetParametres(int cric, int userid, Compta.Parametres parametres)
    {
        Yemon.dnn.Helpers.SetItem(Const.DISTRICT_ID + ":" + cric + ":ComptaParametres", Yemon.dnn.Functions.Serialize(parametres), "" + userid, keephistory: false);
    }

    public static Compta.Cotisations GetCotisations(int cric)
    {
        var item = Yemon.dnn.Helpers.GetItem(Const.DISTRICT_ID + ":" + cric + ":ComptaCotisations", 0);
        if (item == null) return new Compta.Cotisations();
        return Yemon.dnn.Functions.Deserialize<Compta.Cotisations>("" + item);
    }

    public static void SetCotisations(int cric, int userid, Compta.Cotisations parametres)
    {
        Yemon.dnn.Helpers.SetItem(Const.DISTRICT_ID + ":" + cric + ":ComptaCotisations", Yemon.dnn.Functions.Serialize(parametres), "" + userid, keephistory: false);
    }


    public static List<Compta.Element> GetFacturesClub(int cric)
    {
        var factures = Yemon.dnn.DataMapping.ExecSql<Compta.Element>(new SqlCommand("SELECT * FROM " + Const.TABLE_PREFIX + "c_elements WHERE type=1 AND cric=" + cric + " AND district_id=" + Const.DISTRICT_ID + " ORDER BY numero DESC"));
        return factures;
    }

    public static List<Compta.Element.Type> GetElementsTypes()
    {
        var l = Yemon.dnn.DataMapping.ExecSql<Compta.Element.Type>(new SqlCommand("SELECT * FROM " + Const.TABLE_PREFIX + "c_types ORDER BY id"));
        return l;
    }

    public static int ProductionClubFacture(Guid guid, bool forceprod = false, SqlConnection conn = null,SqlTransaction trans=null)
    {
        bool localConn = conn==null;
        try {
            if (localConn)
            {
                conn = Yemon.dnn.DataMapping.GetOpenedConn();
                trans = conn.BeginTransaction();
            }

            var sql = new SqlCommand("select * from " + Const.TABLE_PREFIX + "c_elements where guid=@guid");
            sql.Parameters.AddWithValue("guid", guid);
            var facture = Yemon.dnn.DataMapping.ExecSqlFirst<Compta.Element>(sql,conn, trans);
            if (facture == null)
                return 0;

            int idprod = 0;

            sql = new SqlCommand("select id as idprod from sip_prod where instance_name='clubfacture' and instance=@instance");
            sql.Parameters.AddWithValue("instance", guid);
            int.TryParse("" + Yemon.dnn.DataMapping.ExecSqlScalar(sql, conn, trans), out idprod);

            if (forceprod || idprod == 0)
            {
                
                if (idprod != 0)
                {
                    SIPro.DeleteProduction(Yemon.dnn.Functions.GetPortalId(), idprod,conn,trans);
                    idprod = 0;

                }

                var lignes = Yemon.dnn.Functions.Deserialize<List<Compta.Element.Ligne>>(facture.detail);

                int nb=Yemon.dnn.DataMapping.ExecSqlNonQuery(new SqlCommand("DELETE FROM " + Const.TABLE_PREFIX + "c_lignes WHERE reference='clubfacture:" + guid + "'"), conn, trans);

                foreach(var l in lignes)
                {
                    sql = new SqlCommand(
                        "INSERT INTO " + Const.TABLE_PREFIX + "c_lignes" +
                        " (reference,libelle,montant,qte,total) VALUES " +
                        " (@reference,@libelle,@montant,@qte,@total)",
                        conn,
                        trans
                    );
                    sql.Parameters.AddWithValue("reference", "clubfacture:" + guid);
                    sql.Parameters.AddWithValue("libelle", ""+l.libelle);
                    sql.Parameters.AddWithValue("montant", l.montant);
                    sql.Parameters.AddWithValue("qte", l.qte);
                    sql.Parameters.AddWithValue("total", l.total);
                    if(sql.ExecuteNonQuery()!=1)
                        throw new Exception("Erreur creation lignes club facture");
                }

                
                var objets = new Dictionary<string, string>();
                objets.Add("reference", "clubfacture:" + guid);
                objets.Add("cric", "" + facture.cric);
                //idprod = SIPro.ProductionForce(
                //    Yemon.dnn.Functions.GetPortalId(), 
                //    "document", 
                //    "ClubFacture", 
                //    "clubfacture", 
                //    "" + guid, 
                //    objets);

                idprod = SIPro.AddMessage(Yemon.dnn.Functions.GetPortalId(), 0, "clubfacture", "" + guid, Yemon.dnn.Functions.Serialize(objets),"json", conn, trans);


                if (localConn)
                {
                    trans.Commit();
                    conn.Close();

                }

            }


            return idprod;
        }
        catch(Exception e)
        {
            Functions.Error(e);
            return 0;
        }
    }



    /// <summary>
    /// Recupère l'historique du compte membre
    /// </summary>
    /// <param name="nim">nim du membre</param>
    /// <param name="complet">les lignes détaillées sont incluses</param>
    /// <param name="tous">les éléments provisoire sont inclus</param>
    /// <returns></returns>
    public static Compta.Membre.Compte GetMembreCompte(int nim, bool complet = false, bool tous=true)
    {
        var elements = Yemon.dnn.DataMapping.ExecSql<Compta.Element>(new SqlCommand("SELECT * FROM " + Const.TABLE_PREFIX + "c_elements WHERE nim=" + nim + " AND district_id=" + Const.DISTRICT_ID + " ORDER BY date"));
        var compte = new Compta.Membre.Compte();
        var types = GetElementsTypes();

        decimal solde = 0;
        foreach (var element in elements)
        {
            var t = types.Find(tt => tt.id == element.type);
            if(tous || (!(bool)element.provisoire && element.type!=2))
            {
                if (element.type!=2)
                {
                    if (!t.recette)
                        compte.debit += element.montant;
                    else
                        compte.credit += element.montant;

                    compte.solde = -compte.debit + compte.credit;
                }

                if (complet)
                {
                    var ligne = new Compta.Membre.Compte.Ligne();                
                    ligne.numero = element.numero;
                    ligne.provisoire = element.provisoire;
                    ligne.lettrage = element.lettrage;
                    ligne.guid = element.guid;
                    if (!t.recette)
                        ligne.debit = element.montant;
                    else
                        ligne.credit = element.montant;
                    ligne.libelle = element.libelle;
                    ligne.type = t.id;
                    ligne.typeLibelle = t.libelle;
                    ligne.date = element.date;
                   
                    ligne.document_id = element.document_id;
                    if(element.type==2)
                    { 
                        ligne.solde = solde;                       
                    }
                    else
                    { 
                        ligne.solde = solde - ligne.debit + ligne.credit;
                        solde = ligne.solde;
                    }

                    compte.lignes.Add(ligne);
                }
            }
        }

        //if(complet){
        //compte.lignes = compte.lignes.OrderByDescending(l => l.date).ToList();
        //decimal solde = 0;
        //foreach(var ligne in compte.lignes)
        //{
        //    ligne.solde = solde - ligne.debit + ligne.credit;
        //    solde = ligne.solde;
        //}
        //compte.solde = solde;
        //}

        return compte;
    }


    public static List<Compta.Membre> GetComptesMembres(int cric)
    {
        var membres = new List<Compta.Membre>();
        var members = DataMapping.ListMembers(cric, sort: "surname asc");
        foreach (var member in members)
        {
            var membre = new Compta.Membre();
            membre.nim = member.nim;
            membre.prenom = member.name;
            membre.nom = member.surname;
            membre.compte = GetMembreCompte(member.nim);
            membres.Add(membre);
        }
        return membres;
    }

    public static Compta.Element GetElement(int cric, Guid guid, SqlConnection conn = null, SqlTransaction trans = null)
    {
        var sql = new SqlCommand("SELECT * FROM " + Const.TABLE_PREFIX + "c_elements WHERE cric=@cric AND district_id=@district_id AND guid=@guid");
        sql.Parameters.AddWithValue("cric", cric);
        sql.Parameters.AddWithValue("district_id", Const.DISTRICT_ID);
        sql.Parameters.AddWithValue("guid", guid);

        var element = Yemon.dnn.DataMapping.ExecSqlFirst<Compta.Element>(sql,conn,trans);
        return element;
    }

    public static bool SetElement(Compta.Element element, bool createElementNum = false,SqlConnection conn=null,SqlTransaction trans=null)
    {

        if (createElementNum && element.numero==null && element.type==1) // facture
        {
            int numero = 0;
            int.TryParse("" + Yemon.dnn.DataMapping.ExecSqlScalar(new SqlCommand("SELECT MAX(numero) FROM " + Const.TABLE_PREFIX + "c_elements WHERE type="+element.type+" AND cric=" + element.cric + " AND district_id=" + element.district_id),conn,trans), out numero);
            element.numero = numero + 1;

        }
        if (element.id == null)
            element.guid = Guid.NewGuid();

        var row = new Dictionary<string, object>();
        row["id"] = element.id;
        row["guid"] = element.guid;
        row["district_id"] = element.district_id;
        row["cric"] = element.cric;
        row["numero"] = element.numero;
        row["type"] = element.type;
        row["provisoire"] = element.provisoire;
        row["moyenPaiement"] = element.moyenPaiement;
        row["reference"] = element.reference;

        row["date"] = element.date;
        row["dateReglement"] = element.dateReglement;
        row["lettrage"] = element.lettrage;
        row["dateLettrage"] = element.dateLettrage;
        row["libelle"] = element.libelle;

        row["nim"] = element.nim;
        row["raisonSociale"] = element.raisonSociale;
        row["nom"] = element.nom;
        row["prenom"] = element.prenom;
        row["email"] = element.email;
        row["ad1"] = element.ad1;
        row["ad2"] = element.ad2;
        row["cp"] = element.cp;
        row["ville"] = element.ville;
        row["pays"] = element.pays;

        row["montant"] = element.montant;

        row["detail"] = element.detail;
       
        var r = Yemon.dnn.DataMapping.UpdateOrInsertRecord(Const.TABLE_PREFIX + "c_elements", "id", row,conn,trans);
        return r.Key != "error";
    }

    public static string GetLettrageUid(SqlConnection conn= null,SqlTransaction trans=null){
        string uid = "";
        while (true){
             uid = Guid.NewGuid().ToString().Substring(0, 8);
            int count = (int)Yemon.dnn.DataMapping.ExecSqlScalar(new SqlCommand("select count(*) from " + Const.TABLE_PREFIX + "c_elements where lettrage is not null and lettrage='" + uid + "'"),conn,trans);
            if (count == 0)
                break;
        }

        return uid;
    }

    public static bool Lettrage(int cric,int nim, Guid[] liste) {
        var types = GetElementsTypes();
        var conn = Yemon.dnn.DataMapping.GetOpenedConn();
        var trans = conn.BeginTransaction();

        List<Compta.Element> elements = new List<Compta.Element>();
        foreach (Guid guid in liste)
        {
            var element = GetElement(cric, guid,conn,trans);
            if (element == null)
                throw new Exception("Erreur lecture element "+guid);
            elements.Add(element);
        }



        string lettrage = GetLettrageUid(conn,trans);
        decimal total = 0;
        DateTime dt = DateTime.Now;
        foreach (var element in elements) 
        {
            element.lettrage = lettrage;
            element.dateLettrage = dt;
            element.provisoire = false;

            var t = types.Find(tt => tt.id == element.type);
            if (t.recette)
                total += element.montant;
            else
                total -= element.montant;

            if (!SetElement(element,true,conn,trans))
                throw new Exception("Erreur maj element " + element.id);

          
        }
        if(total>0)
        {
            if (nim == 0)
                throw new Exception("Erreur de nim");

            var element = new Compta.Element();
            element.type = 2;
            element.date = DateTime.Now;
            element.montant = total;
            element.libelle = "Note de crédit";
            element.reference = lettrage;
            element.cric = cric;
            element.nim = nim;
            element.provisoire = false;
            element.district_id = Const.DISTRICT_ID;
            if (!SetElement(element, false, conn, trans))
                throw new Exception("Erreur création note de crédit");
        }
        trans.Commit();
        conn.Close();

        foreach(var element in elements)
        {
            if (element.type == 1)
                if(ComptaHelper.ProductionClubFacture((Guid)element.guid, forceprod: true)==0)
                   throw new Exception("Erreur création document facture " + cric + " : " + element.guid);        
        }


        return true;
       
        
    }

    public static bool Confirmer(int cric, int nim, Guid[] liste)
    {
        var conn = Yemon.dnn.DataMapping.GetOpenedConn();
        var trans = conn.BeginTransaction();

        List<Compta.Element> elements = new List<Compta.Element>();
        foreach (Guid guid in liste)
        {
            var element = GetElement(cric, guid, conn, trans);
            if (element == null)
                throw new Exception("Erreur lecture element " + guid);
            elements.Add(element);
        }


        DateTime dt = DateTime.Now;
        foreach (var element in elements)
        {
            element.provisoire = false;
         
            if (!SetElement(element, true, conn, trans))
                throw new Exception("Erreur maj element " + element.id);
        }
       
        trans.Commit();
        conn.Close();

        foreach (var element in elements)
        {
            if (element.type == 1)
                if (ComptaHelper.ProductionClubFacture((Guid)element.guid, forceprod: true) == 0)
                    throw new Exception("Erreur création document facture " + cric + " : " + element.guid);
        }


        return true;


    }

    public static bool DeleteElement(int cric,Guid guid)
    {
        var element = GetElement(cric, guid);
        if (element == null)
            return false;

        if (element.document_id != 0)
            Yemon.dnn.SIPro.SIPro.DeleteProduction(Yemon.dnn.Functions.GetPortalId(), element.document_id);
        var sql = new SqlCommand("delete from " + Const.TABLE_PREFIX + "c_elements where cric=@cric and guid=@guid");
        sql.Parameters.AddWithValue("cric", cric);
        sql.Parameters.AddWithValue("guid", guid);
        return Yemon.dnn.DataMapping.ExecSqlNonQuery(sql)>0;
    }
}