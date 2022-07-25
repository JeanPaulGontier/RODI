using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Stripe;

public partial class AIS_DonStripe : System.Web.UI.Page
{
    const string PUBLIC_KEY = "";
    const string PRIVATE_KEY = "";

    /**********************************************************************************************
    * 
    * La gestion se trouve sur https://dashboard.stripe.com
    * La doc se trouve sur https://stripe.com/docs
    * La partie dev s'active (ou se desactive) avec le toogle "Viewing test data"
    * Les clefs API se trouvent sur https://dashboard.stripe.com/account/apikeys
    * Les URL pour les notifications se trouvent sur https://dashboard.stripe.com/account/webhooks
    * Le montant est exprimé en centimes
    * On peut régler une redirection sur https://dashboard.stripe.com/account/applications/settings
    * Les cartes de tests se trouvent sur https://stripe.com/docs/testing#cards
    * 
    * ************************************************************************************************/
    public int GetAmount()
    {
        int v = 0;
        int.TryParse(TXT_Amount.Text, out v);
        return v*100;
    }
    protected void TXT_Changed(object sender, EventArgs e)
    { }

    protected void Page_Load(object sender, EventArgs e)
    {
        StripeConfiguration.SetApiKey(PRIVATE_KEY);
    
        L_Script.Text = @"<script src='https://checkout.stripe.com/checkout.js' class='stripe-button' data-key='"+PUBLIC_KEY+"' data-amount='"+ GetAmount() +"' data-name='Rotary District 1700' data-description='Faire un don' data-image='https://files.stripe.com/files/f_test_S3eodGhrXndslVhvVM0H3BMj'  data-locale='fr' data-currency='eur' data-label='Valider le don'></script>";
        L_Script.Visible = GetAmount() > 0;

        #region Paiement
        if (Request["stripeToken"] != null)
        {
            try
            {
                var customers = new StripeCustomerService();
                var charges = new StripeChargeService();

                Dictionary<string, string> dico = new Dictionary<string, string>();
                if (Request["hfd_transcId"] != null)
                {
                    dico.Add("IdTransaction", Request["hfd_transcId"]);
                }

                var customer = customers.Create(new StripeCustomerCreateOptions
                {
                    Email = Request.Form["stripeEmail"],
                    SourceToken = Request.Form["stripeToken"]

                });



                var charge = charges.Create(new StripeChargeCreateOptions
                {
                    Amount = GetAmount(),
                    Description = "Faire un don",
                    Currency = "eur",
                    CustomerId = customer.Id,
                    Metadata = dico
                });
                #endregion Paiement


                if (charge.Status == "succeeded")
                {
                    pnl_paiement.Visible = false;
                    pnl_paiementOK.Visible = true;
                   
                }

            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
        }
        else
        {
            pnl_paiement.Visible = true;
            pnl_paiementOK.Visible = false;

        }

    }




   

    
}