using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AIS;

public partial class AIS_CommandeView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         try
         {
            string id = "" + Request.QueryString["id"];

            if (id == "")
                 throw new Exception("La facture est introuvable sans parametre id (querystring : "+Request.QueryString+")");

           
            Order order = DataMapping.GetOrderByGuid(id);
            if (order == null)
                throw new Exception("La facture "+id+" est introuvable");

            Payment payment = DataMapping.GetPayment(order.id_payment);
            if(payment==null)
                throw new Exception("Le reglement "+order.id_payment+" de la commande "+id+" est introuvable");

            Club club = DataMapping.GetClub(order.cric);
            if (club == null)
                throw new Exception("Le club " + order.club + " est introuvable");

            string model = Const.ORDER_MODELE;
            if (!payment.model.Equals(""))
                model = payment.model;

            Media media = DataMapping.ProductionDocumentOrderPdf(model, order, payment, club, Functions.ClearFileName("Facture."+order.id+".pdf"));


            Response.Buffer = true;
            Response.Expires = 0;
            Response.Cache.SetCacheability(HttpCacheability.Public);


            Response.AppendHeader("Content-Disposition", "attachment; filename=" + media.name );
            Response.ContentType = media.content_type;
            Response.BinaryWrite(media.content);
            

        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
    }
}