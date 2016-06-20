package net.aisdev.rotary1730;

import android.app.Activity;
import android.content.Intent;
import android.content.SharedPreferences;
import android.graphics.Color;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.ProgressBar;
import android.widget.TextView;
import android.widget.Toast;

import java.util.HashMap;
import java.util.Map;
import java.util.regex.Matcher;
import java.util.regex.Pattern;


public class Contact extends Activity {
    private String TypeNav = "public";
    private Contact Ancre;
    private TextView MailExp;
    private TextView MailObj;
    private TextView MailCorps;
    private TextView MailNom;
    private Button btn;
    private String To = "";
    private String Exp = "";
    private String Obj = "";
    private String Corps = "";
    private String Nom ="";
    ProgressBar pg;
    String Retour;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_contact);
        try {
            Ancre = this;
            MailExp = (TextView) findViewById(R.id.mailExp);
            MailObj = (TextView) findViewById(R.id.mailObj);
            MailCorps = (TextView) findViewById(R.id.mailCorps);
            MailNom = (TextView) findViewById(R.id.mailNom);
            btn = (Button) findViewById(R.id.btn_Contact);
            pg = (ProgressBar) findViewById(R.id.ProgressB);
            pg.setVisibility(View.GONE);

            Bundle extras = getIntent().getExtras();
            if (extras != null) {
                TypeNav = extras.getString("TypeNav");
                To = extras.getString("To");
            }

            /*if(To.contentEquals("")){
                btn.setText("Contacter l'administrateur");
            }
            else {
                btn.setText("Contacter le membre");
            }*/
        }
        catch (Exception ee) {
            ee.printStackTrace();
        }
    }

    public void onSendClick(View v) {
        boolean hasErrors = false;
        MailExp.setTextColor(Color.BLACK);
        MailObj.setTextColor(Color.BLACK);
        MailCorps.setTextColor(Color.BLACK);
        MailNom.setTextColor(Color.BLACK);

        Exp = MailExp.getText().toString();
        Obj = MailObj.getText().toString();
        Corps = MailCorps.getText().toString();
        Nom = MailNom.getText().toString();

        if(Exp.length() < 1){
            hasErrors = true;
            //MailExp.setBackgroundColor(Color.RED);
            MailExp.setTextColor(Color.RED);
            MailExp.setHintTextColor(Color.RED);
        }
        else {
            Pattern pattern = Pattern.compile(Fonctions.EMAIL_PATTERN);
            Matcher matcher = pattern.matcher(Exp);
            if(!matcher.matches()) {
                hasErrors = true;
                //MailExp.setBackgroundColor(Color.RED);
                MailExp.setTextColor(Color.RED);
                MailExp.setHintTextColor(Color.RED);
            }
        }

        if (Obj.length() < 1) {
            hasErrors = true;
            //MailObj.setBackgroundColor(Color.RED);
            MailObj.setTextColor(Color.RED);
            MailObj.setHintTextColor(Color.RED);
        }

        if (Corps.length() < 1) {
            hasErrors = true;
            //MailCorps.setBackgroundColor(Color.RED);
            MailCorps.setTextColor(Color.RED);
            MailCorps.setHintTextColor(Color.RED);
        }

        if (Nom.length() < 1) {
            hasErrors = true;
            //MailNom.setBackgroundColor(Color.RED);
            MailNom.setTextColor(Color.RED);
            MailNom.setHintTextColor(Color.RED);
        }

        if (hasErrors) {
            Toast.makeText(getApplicationContext(), "Saisie incorrecte",
                    Toast.LENGTH_LONG).show();
            return;
        }
        else {
            AsyncCallWS task = new AsyncCallWS();
            //Call execute
            task.execute();
        }
    }

    private class AsyncCallWS extends AsyncTask<String, Void, Void> {
        @Override
        protected void onPreExecute() {
            //Make ProgressBar invisible
            pg.setVisibility(View.VISIBLE);
        }

        @Override
        protected Void doInBackground(String... params) {
//SendMail(string MembreID, string exp, string nom, string obj, string msg)
            Map<String,String> map = new HashMap<String,String>();
            map.put("MembreID", To);
            map.put("exp", Exp);
            map.put("nom", Nom);
            map.put("obj", Obj);
            map.put("msg", Corps);
            Retour = WebService.invokeWSParams(map, "SendMail");

            return null;
        }

        @Override
        protected void onProgressUpdate(Void... values) {
        }

        @Override
        protected void onPostExecute(Void result) {
            pg.setVisibility(View.GONE);

            //Set response
            if (Retour.contentEquals("0")) {
                View v = findViewById(R.id.body);

                Fonctions.ShowAlertNeutralButton(Ancre, "Erreur", "Impossible d'envoyer le message!", "Ok");
            }
            else {
                Toast.makeText(getApplicationContext(), "Message envoyé",
                        Toast.LENGTH_SHORT).show();

                onBackPressed();
            }

        }




    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.contact, menu);
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
}
