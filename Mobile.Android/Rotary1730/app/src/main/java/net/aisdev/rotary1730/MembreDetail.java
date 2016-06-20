package net.aisdev.rotary1730;

import android.app.Activity;
import android.content.ActivityNotFoundException;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.net.Uri;
import android.os.AsyncTask;
import android.os.Bundle;
import android.provider.ContactsContract;
import android.util.Base64;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.TextView;

import com.google.gson.Gson;

import java.util.HashMap;
import java.util.Map;


public class MembreDetail extends Activity {
    private String TypeNav = "public";
    private Membre LeMembre;
    //private Club LeClub;
    private MembreDetail Ancre;
    private ImageView img;
    private TextView nom;
    private TextView prenom;
    private TextView profession;
    private TextView activite;
    private TextView club;
    private byte[] LaPhoto;
    private Button btn_contacterMembre;
    private View Privee;
    private TextView addressPerso1;
    private TextView addressPerso2;
    private TextView addressPerso3;
    private TextView CpPerso;
    private TextView TelPerso;
    private TextView FaxPerso;
    private TextView GsmPerso;
    private TextView GsmPersoSMS;
    private TextView MailPerso;
    private TextView addressPro;
    private TextView CpPro;
    private TextView TelPro;
    private TextView FaxPro;
    private TextView GsmPro;
    private TextView GsmProSMS;
    private TextView MailPro;
    private View lltTelPro;
    private View lltGsmPro;
    private View lltGsmProSMS;
    private View lltMailPro;
    private View lltTelPerso;
    private View lltGsmPerso;
    private View lltMailPerso;
    private View lltGsmPersoSMS;
    public Context LeContext;

    public void getContext(Context _Context) {
        LeContext = _Context;
    }


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_membre_detail);

        try {
            Ancre = this;

            Bundle extras = getIntent().getExtras();
            if (extras != null) {
                TypeNav = extras.getString("TypeNav");

                getContext(this.getApplicationContext());
        }

        /*if(getIntent().getSerializableExtra("Club") != null) {
            LeClub = (Club) getIntent().getSerializableExtra("Club");
        }*/

            if (getIntent().getSerializableExtra("Membre") != null) {
                LeMembre = (Membre) getIntent().getSerializableExtra("Membre");
                img = (ImageView) findViewById(R.id.ImageView01);
                nom = (TextView) findViewById(R.id.tvw_nom);
                //prenom = (TextView) findViewById(R.id.tvw_prenom);
                club = (TextView) findViewById(R.id.tvw_Club);
                profession = (TextView) findViewById(R.id.tvw_profession);
                activite = (TextView) findViewById(R.id.tvw_activite);
                Privee = (View) findViewById(R.id.glt_privee);
                btn_contacterMembre = (Button) findViewById(R.id.ContactMembre);
                addressPerso1 = (TextView) findViewById(R.id.tvw_adressPerso1);
                addressPerso2 = (TextView) findViewById(R.id.tvw_adressPerso2);
                addressPerso3 = (TextView) findViewById(R.id.tvw_adressPerso3);
                CpPerso = (TextView) findViewById(R.id.tvw_CpPerso);
                TelPerso = (TextView) findViewById(R.id.tvw_TelPerso);
                FaxPerso = (TextView) findViewById(R.id.tvw_FaxPerso);
                GsmPerso = (TextView) findViewById(R.id.tvw_GsmPerso);
                MailPerso = (TextView) findViewById(R.id.tvw_MailPerso);
                addressPro = (TextView) findViewById(R.id.tvw_adressPro);
                CpPro = (TextView) findViewById(R.id.tvw_CpPro);
                TelPro = (TextView) findViewById(R.id.tvw_TelPro);
                FaxPro = (TextView) findViewById(R.id.tvw_FaxPro);
                GsmPro = (TextView) findViewById(R.id.tvw_GsmPro);
                MailPro = (TextView) findViewById(R.id.tvw_MailPro);
                lltTelPro = (View) findViewById(R.id.lltTelPro);
                lltGsmPro = (View) findViewById(R.id.lltGsmPro);
                lltGsmProSMS = (View) findViewById(R.id.lltGsmProSMS);
                lltMailPro = (View) findViewById(R.id.lltMailPro);
                lltTelPerso = (View) findViewById(R.id.lltTelPerso);
                lltGsmPerso = (View) findViewById(R.id.lltGsmPerso);
                lltMailPerso = (View) findViewById(R.id.lltMailPerso);
                lltGsmPersoSMS = (View) findViewById(R.id.lltGsmPersoSMS);
                GsmPersoSMS = (TextView) findViewById(R.id.tvw_GsmPersoSMS);
                GsmProSMS = (TextView) findViewById(R.id.tvw_GsmProSMS);

                //img.setImageURI(Uri.parse(LeMembre.getPhoto()));
                nom.setText(LeMembre.getPrenom() + " " + LeMembre.getNom());
                //prenom.setText(LeMembre.getPrenom());
                //club.setText("Club : " + LeClub.getNom());
                club.setText("Club : " + LeMembre.getNom_club());
                String actif = "| En activité";
                if (LeMembre.getRetraite().toLowerCase().contentEquals("o")) {
                    actif = "| Retraitée";
                }
                profession.setText(LeMembre.getFonction_metier() + " " + actif);

                //activite.setText("Branche d'activité : " + LeMembre.getBranche_activite());
                activite.setText(LeMembre.getBranche_activite());

                if (TypeNav.contentEquals("privee")) {
                    Privee.setVisibility(View.VISIBLE);
                    btn_contacterMembre.setVisibility(View.GONE);

                    /*Calendar cal = Calendar.getInstance();
                    cal.setTime(LeMembre.getAnnee_naissance());
                    String YNaissance = "" + cal.get(Calendar.YEAR);*/

                    /*Calendar cal2 = Calendar.getInstance();
                    cal2.setTime(LeMembre.getAnnee_adhesion_rotary());
                    String YAnnRot = "" + cal2.get(Calendar.YEAR);*/

                    if (!LeMembre.getAdresse_1().isEmpty()) {
                        addressPerso1.setText(LeMembre.getAdresse_1());
                    } else {
                        addressPerso1.setVisibility(View.GONE);
                    }
                    if (!LeMembre.getAdresse_2().isEmpty()) {
                        addressPerso2.setText(LeMembre.getAdresse_2());
                    } else {
                        addressPerso2.setVisibility(View.GONE);
                    }
                    if (!LeMembre.getAdresse_3().isEmpty()) {
                        addressPerso3.setText(LeMembre.getAdresse_3());
                    } else {
                        addressPerso3.setVisibility(View.GONE);
                    }
                    if (!LeMembre.getCode_postal().isEmpty() && !LeMembre.getVille().isEmpty()) {
                        CpPerso.setText(LeMembre.getCode_postal() + " " + LeMembre.getVille());
                    } else {
                        CpPerso.setVisibility(View.GONE);
                    }
                    if (!LeMembre.getTelephone().isEmpty()) {
                        TelPerso.setText(LeMembre.getTelephone());
                    } else {
                        lltTelPerso.setVisibility(View.GONE);
                    }
                    if (!LeMembre.getFax().isEmpty()) {
                        FaxPerso.setText("Fax : " + LeMembre.getFax());
                    } else {
                        FaxPerso.setVisibility(View.GONE);
                    }
                    if (!LeMembre.getGsm().isEmpty()) {
                        GsmPerso.setText(LeMembre.getGsm());
                        GsmPersoSMS.setText(LeMembre.getGsm());
                    } else {
                        lltGsmPerso.setVisibility(View.GONE);
                        lltGsmPersoSMS.setVisibility(View.GONE);
                    }
                    if (!LeMembre.getEmail().isEmpty()) {
                        MailPerso.setText(LeMembre.getEmail());
                    } else {
                        lltMailPerso.setVisibility(View.GONE);
                    }

                    if (!LeMembre.getAdresse_professionnelle().isEmpty()) {
                        addressPro.setText(LeMembre.getAdresse_professionnelle());
                    } else {
                        addressPro.setVisibility(View.GONE);
                    }
                    if (!LeMembre.getCode_postal_professionnel().isEmpty() && !LeMembre.getVille_professionnel().isEmpty()) {
                        CpPro.setText(LeMembre.getCode_postal_professionnel() + " " + LeMembre.getVille_professionnel());
                    } else {
                        CpPro.setVisibility(View.GONE);
                    }
                    if (!LeMembre.getTel_professionnel().isEmpty()) {
                        TelPro.setText(LeMembre.getTel_professionnel());
                    } else {
                        lltTelPro.setVisibility(View.GONE);
                    }
                    if (!LeMembre.getFax_professionnel().isEmpty()) {
                        FaxPro.setText("Fax : " + LeMembre.getFax_professionnel());
                    } else {
                        FaxPro.setVisibility(View.GONE);
                    }
                    if (!LeMembre.getPortable_professionnel().isEmpty()) {
                        GsmPro.setText(LeMembre.getPortable_professionnel());
                        GsmProSMS.setText(LeMembre.getPortable_professionnel());
                    } else {
                        lltGsmPro.setVisibility(View.GONE);
                        lltGsmProSMS.setVisibility(View.GONE);
                    }
                    if (!LeMembre.getEmail_professionnel().isEmpty()) {
                        MailPro.setText(LeMembre.getEmail_professionnel());
                    } else {
                        lltMailPro.setVisibility(View.GONE);
                    }
                } else {
                    Privee.setVisibility(View.GONE);
                    //btn_contacterMembre.setVisibility(View.VISIBLE);
                }

                AsyncCallWS taskClub = new AsyncCallWS();
                taskClub.execute();
            }
        }
        catch (Exception ee) {
            ee.printStackTrace();
        }
    }




    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.membre_detail, menu);

        Fonctions.updateMenuCon_Deconn(menu.findItem(R.id.action_settings), TypeNav);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();
        if (id == R.id.action_settings) {
            SharedPreferences settings = getSharedPreferences("id", 0);
            SharedPreferences.Editor editor = settings.edit();
            editor.putString("id", "");
            // Commit the edits!
            editor.commit();

            SharedPreferences settings2 = getSharedPreferences("pwd", 0);
            SharedPreferences.Editor editor2 = settings2.edit();
            editor2.putString("pwd", "");
            // Commit the edits!
            editor2.commit();

            Intent intent = new Intent(this, Start.class);
            this.startActivity(intent);
            return true;
        }

        if (id == R.id.action_Propos) {
            Intent intent = new Intent(this, A_Propos.class);
            this.startActivity(intent);
            return true;
        }

        return super.onOptionsItemSelected(item);
    }

    private class AsyncCallWS extends AsyncTask<String, Void, Void> {
        @Override
        protected void onPreExecute() {
        }

        @Override
        protected Void doInBackground(String... params) {
            //Récupération de la photo du membre
            Gson gson = new Gson();
            Map<String, String> map = new HashMap<String, String>();
            map.put("filepath", "" + LeMembre.getPhoto());
            String retour;

            retour = WebService.invokeWSParams(map, "GetPhotoMembre");

    try {
        if (retour != null) {
            LaPhoto =  Base64.decode(retour, Base64.NO_WRAP);


            /*LaPhoto = gson.fromJson(retour, new TypeToken<byte[]>() {
            }.getType());*/
        } else {
            Fonctions.ShowAlertNeutralButton(Ancre, "Erreur", "Problème de récupération des données", "Ok");
        }
    }
    catch (Exception ee)
    {
        ee.printStackTrace();
    }

            return null;
        }

        @Override
        protected void onProgressUpdate(Void... values) {
        }

        @Override
        protected void onPostExecute(Void result) {
            try {
                Bitmap bitmap = BitmapFactory.decodeByteArray(LaPhoto, 0, LaPhoto.length);
                int hauteur = bitmap.getHeight();
                int largeur = bitmap.getWidth();
                //float ratio = (float)largeur/hauteur;
                float ratio = (float)hauteur/largeur;
                int toto = (int)Fonctions.dipToPixels(LeContext, 100);
                //Bitmap resizedbitmap = Bitmap.createScaledBitmap(bitmap, 100, (int)(100*ratio) , true);
                Bitmap resizedbitmap = Bitmap.createScaledBitmap(bitmap, toto, (int)(toto*ratio) , true);
                img.setImageBitmap(resizedbitmap);

            } catch (Exception e) {
                e.printStackTrace();
                Fonctions.ShowAlertNeutralButton(Ancre, "Erreur", "Problème de traitement des données", "Ok");
            }
        }
    }

    public void onTelclick(View v) {
        try {
            String Temp = "";
            switch (v.getId()) {
                case R.id.ImageButtonTelPerso:
                    Temp = LeMembre.getTelephone();
                    break;

                case R.id.ImageButtonGsmPerso:
                    Temp = LeMembre.getGsm();
                    break;

                case R.id.ImageButtonTelPro:
                    Temp = LeMembre.getTel_professionnel();
                    break;

                case R.id.ImageButtonGsmPro:
                    Temp = LeMembre.getPortable_professionnel();
                    break;
            }

            String Tel = Temp.replace("-", "");


            Intent callIntent = new Intent(Intent.ACTION_CALL);
            callIntent.setData(Uri.parse("tel:" + Tel));
            startActivity(callIntent);

        }
        catch (Exception ee) {
            ee.printStackTrace();
        }
    }

    public void onSMSclick(View v) {
        try {
            String Temp = "";
            switch (v.getId()) {
                case R.id.ImageButtonGsmPersoSMS:
                    Temp = LeMembre.getGsm();
                    break;

                case R.id.ImageButtonGsmProSMS:
                    Temp = LeMembre.getPortable_professionnel();
                    break;
            }

            String Tel = Temp.replace("-", "");

            Intent smsIntent = new Intent(Intent.ACTION_SENDTO);
            smsIntent.addCategory(Intent.CATEGORY_DEFAULT);
            smsIntent.setType("vnd.android-dir/mms-sms");
            smsIntent.setData(Uri.parse("smsto:" + Tel));
            startActivity(smsIntent);

        }
        catch (Exception ee) {
            ee.printStackTrace();
        }



    }

    public void onMailclick(View v) {
        try{
            String LeMail = "";
            switch (v.getId()) {
                case R.id.ImageButtonMailPerso:
                    LeMail = LeMembre.getEmail();
                    break;

                case R.id.ImageButtonMailPro:
                    LeMail = LeMembre.getEmail_professionnel();
                    break;
            }

            final Intent emailLauncher = new Intent(Intent.ACTION_SEND);
            emailLauncher.setType("message/rfc822");
            emailLauncher.putExtra(android.content.Intent.EXTRA_EMAIL, new String[]{LeMail});

            startActivity(emailLauncher);
        }catch(ActivityNotFoundException e){

        }
    }

    public void onContactPriveeClick(View v) {
        try {
        /*Intent intent = new Intent(Intent.ACTION_INSERT);
            intent.setType(ContactsContract.Contacts.CONTENT_TYPE);

            intent.putExtra(ContactsContract.Intents.Insert.NAME, LeMembre.getNom() + " " + LeMembre.getPrenom());
            intent.putExtra(ContactsContract.Intents.Insert.PHONE, LeMembre.getTel_professionnel());
            intent.putExtra(ContactsContract.Intents.Insert.EMAIL, person.email);

            startActivity(intent);*/
            String AdresseHome = "";
            if(LeMembre.getAdresse_1() != null) { AdresseHome = AdresseHome + LeMembre.getAdresse_1();}
            if(LeMembre.getAdresse_2() != null) { AdresseHome = AdresseHome + " " + LeMembre.getAdresse_2();}
            if(LeMembre.getAdresse_3() != null) { AdresseHome = AdresseHome + " " + LeMembre.getAdresse_3();}
            if(LeMembre.getCode_postal() != null) { AdresseHome = AdresseHome + " " +  LeMembre.getCode_postal();}
            if(LeMembre.getVille() != null) { AdresseHome = AdresseHome + " " + LeMembre.getVille();}
            if(LeMembre.getPays() != null) { AdresseHome = AdresseHome + " " + LeMembre.getPays();}

            String TelHome = "";
            if(LeMembre.getTelephone() != null) { TelHome = LeMembre.getTelephone().replace("-", "");}

            String FaxHome = "";
            if(LeMembre.getFax() != null) { FaxHome = LeMembre.getFax().replace("-", "");}

            String MobileHome = "";
            if(LeMembre.getGsm() != null) { MobileHome = LeMembre.getGsm().replace("-", "");}

            String EmailHome = "";
            if(LeMembre.getEmail() != null) { EmailHome = LeMembre.getEmail();}

            String AdressePro = "";
            if(LeMembre.getAdresse_professionnelle() != null) { AdressePro = AdressePro + LeMembre.getAdresse_professionnelle();}
            if(LeMembre.getCode_postal_professionnel() != null) { AdressePro = AdressePro + " " + LeMembre.getCode_postal_professionnel();}
            if(LeMembre.getVille_professionnel() != null) { AdressePro = AdressePro + " " + LeMembre.getVille_professionnel();}

            String TelWork = "";
            if(LeMembre.getTel_professionnel() != null) { TelWork = LeMembre.getTel_professionnel().replace("-", "");}

            String FaxWork = "";
            if(LeMembre.getFax_professionnel() != null) { FaxWork = LeMembre.getFax_professionnel().replace("-", "");}

            String MobileWork = "";
            if(LeMembre.getPortable_professionnel() != null) { MobileWork = LeMembre.getPortable_professionnel().replace("-", "");}

            String EmailWork = "";
            if(LeMembre.getEmail_professionnel() != null) { EmailWork = LeMembre.getEmail_professionnel();}


            Intent intent = new AddContactIntentBuilder(LeMembre.getPrenom() + " " + LeMembre.getNom())
                    .addFormattedAddress(AdresseHome, ContactsContract.CommonDataKinds.StructuredPostal.TYPE_HOME)
                    .addPhone(TelHome, ContactsContract.CommonDataKinds.Phone.TYPE_HOME)
                    .addPhone(FaxHome, ContactsContract.CommonDataKinds.Phone.TYPE_FAX_HOME)
                    .addPhone(MobileHome, ContactsContract.CommonDataKinds.Phone.TYPE_MOBILE)
                    .addPhone(EmailHome, ContactsContract.CommonDataKinds.Email.TYPE_HOME)
                    .addFormattedAddress(AdressePro, ContactsContract.CommonDataKinds.StructuredPostal.TYPE_WORK)
                    .addPhone(TelWork, ContactsContract.CommonDataKinds.Phone.TYPE_WORK)
                    .addPhone(FaxWork, ContactsContract.CommonDataKinds.Phone.TYPE_FAX_WORK)
                    .addPhone(MobileWork, ContactsContract.CommonDataKinds.Phone.TYPE_WORK_MOBILE)
                    .addPhone(EmailWork, ContactsContract.CommonDataKinds.Email.TYPE_WORK)
                    .addPhoto(LaPhoto)
                    .build();

            startActivity(intent);

        }catch(ActivityNotFoundException e){

        }
    }

    public void onContactPublicClick(View v) {
        Intent intent = new Intent(Ancre, Contact.class);
        intent.putExtra("TypeNav", "public");
        intent.putExtra("To", "" + LeMembre.getId());
        startActivity(intent);
    }
}
