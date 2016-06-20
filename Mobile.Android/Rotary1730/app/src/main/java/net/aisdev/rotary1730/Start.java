package net.aisdev.rotary1730;

import android.app.Activity;
import android.content.Intent;
import android.content.SharedPreferences;
import android.graphics.Color;
import android.graphics.Paint;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.ProgressBar;
import android.widget.TextView;
import android.widget.Toast;

import java.util.HashMap;
import java.util.Map;
import java.util.regex.Matcher;
import java.util.regex.Pattern;


public class Start extends Activity {
    String username;
    String password;
    String Retour;
    String RetourPass;
    ProgressBar pg;
    Start Ancre;
    MenuItem menu;
    String RetourMembres = "";
    String RetourMembresPro = "";
    String RetourClubs = "";
    View linearLayout1;
    View View03;
    View linearLayout2;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_start);
        Ancre = this;
        menu = (MenuItem)findViewById(R.id.action_settings);

        TextView url = (TextView)findViewById(R.id.forgotPassword);
        url.setPaintFlags(url.getPaintFlags() | Paint.UNDERLINE_TEXT_FLAG);

        linearLayout1 = (View) findViewById(R.id.linearLayout1);
        //linearLayout1.setVisibility(View.INVISIBLE);

        View03 = (View) findViewById(R.id.View03);
        //View03.setVisibility(View.INVISIBLE);

        linearLayout2 = (View) findViewById(R.id.linearLayout2);
        //linearLayout2.setVisibility(View.INVISIBLE);

        pg = (ProgressBar) findViewById(R.id.ProgressB);
        pg.setVisibility(View.GONE);
    }


    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.start, menu);

        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();
        if (id == R.id.action_Propos) {
            Intent intent = new Intent(this, A_Propos.class);
            this.startActivity(intent);
            return true;
        }
        return super.onOptionsItemSelected(item);
    }

    public void onSaveClick(View v) {
        try {
            TextView tvUsername;
            TextView tvPassword;
            boolean hasErrors = false;

            tvUsername = (TextView) this.findViewById(R.id.accountName);
            tvPassword = (TextView) this.findViewById(R.id.accountPassword);
            //tvApiKey = (TextView) this.findViewById(R.id.uc_txt_api_key);

            tvUsername.setTextColor(Color.BLACK);//.setBackgroundColor(Color.WHITE)
            tvPassword.setTextColor(Color.BLACK);//.setBackgroundColor(Color.WHITE);
            //tvApiKey.setBackgroundColor(Color.WHITE);

            username = tvUsername.getText().toString();
            password = tvPassword.getText().toString();
            //apiKey = tvApiKey.getText().toString();

            if(username.length() < 6){
                hasErrors = true;
                //tvUsername.setBackgroundColor(Color.RED);
                tvUsername.setTextColor(Color.RED);
                tvUsername.setHintTextColor(Color.RED);
            }
            else {
                Pattern pattern = Pattern.compile(Fonctions.EMAIL_PATTERN);
                Matcher matcher = pattern.matcher(username);
                if(!matcher.matches()) {
                    hasErrors = true;
                    //tvUsername.setBackgroundColor(Color.RED);
                    tvUsername.setTextColor(Color.RED);
                    tvUsername.setHintTextColor(Color.RED);
                }
            }

            if (password.length() < 8) {
                hasErrors = true;
                //tvPassword.setBackgroundColor(Color.RED);
                tvPassword.setTextColor(Color.RED);
                tvPassword.setHintTextColor(Color.RED);
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
        catch (Exception ee){
            ee.printStackTrace();
        }
    }

    public void onForgetClick(View v) {
        try {
            boolean hasErrors = false;

            TextView tvUsername;
            tvUsername = (TextView) this.findViewById(R.id.accountName);
            tvUsername.setBackgroundColor(Color.WHITE);
            username = tvUsername.getText().toString();
            if(username.length() < 6){
                hasErrors = true;
                //tvUsername.setBackgroundColor(Color.RED);
                tvUsername.setTextColor(Color.RED);
                tvUsername.setHintTextColor(Color.RED);
            }
            else {
                Pattern pattern = Pattern.compile(Fonctions.EMAIL_PATTERN);
                Matcher matcher = pattern.matcher(username);
                if(!matcher.matches()) {
                    hasErrors = true;
                    //tvUsername.setBackgroundColor(Color.RED);
                    tvUsername.setTextColor(Color.RED);
                    tvUsername.setHintTextColor(Color.RED);
                }
            }

            if (hasErrors) {
                Toast.makeText(getApplicationContext(), "Saisie incorrecte de votre adresse mail",
                        Toast.LENGTH_LONG).show();
                return;
            }
            else {
                AsyncCallWSPass task = new AsyncCallWSPass();
                //Call execute
                task.execute();
            }
        }
        catch (Exception ee){
            ee.printStackTrace();
        }
    }

    public void onGoClick(View v) {
        Intent intent = new Intent(Ancre, Home.class);
        intent.putExtra("TypeNav", "public");
        startActivity(intent);
    }

    public void onContactClick(View v) {
        Intent intent = new Intent(Ancre, Contact.class);
        intent.putExtra("TypeNav", "public");
        intent.putExtra("To", "");
        startActivity(intent);
    }

    private class AsyncCallWS extends AsyncTask<String, Void, Void> {
        @Override
        protected void onPreExecute() {
            //Make ProgressBar invisible
            pg.setVisibility(View.VISIBLE);
            linearLayout1.setVisibility(View.INVISIBLE);
            View03.setVisibility(View.INVISIBLE);
            linearLayout2.setVisibility(View.INVISIBLE);
        }

        @Override
        protected Void doInBackground(String... params) {

            //MD5 des identifiants
            //String userMD5 = Fonctions.md5(username);
            String passMD5 = Fonctions.md5(password);

            Map<String,String> map = new HashMap<String,String>();
            map.put("username", username);
            map.put("password", passMD5);
            Retour = WebService.invokeWSParams(map, "ConnectFromAndroid");

            return null;
        }

        @Override
        protected void onProgressUpdate(Void... values) {
        }

        @Override
        protected void onPostExecute(Void result) {

            //Set response
            if (Retour.contentEquals("0")) {
                View v = findViewById(R.id.body);

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

                pg.setVisibility(View.GONE);
                linearLayout1.setVisibility(View.VISIBLE);
                View03.setVisibility(View.VISIBLE);
                linearLayout2.setVisibility(View.VISIBLE);

                Fonctions.ShowAlertNeutralButton(Ancre, "Erreur", "Erreur de connection", "Ok");
            }
            else {
                SharedPreferences settings = getSharedPreferences("id", 0);
                SharedPreferences.Editor editor = settings.edit();
                editor.putString("id", username);
                // Commit the edits!
                editor.commit();

                SharedPreferences settings2 = getSharedPreferences("pwd", 0);
                SharedPreferences.Editor editor2 = settings2.edit();
                editor2.putString("pwd", password);
                // Commit the edits!
                editor2.commit();

                /*pg.setVisibility(View.INVISIBLE);
                linearLayout1.setVisibility(View.VISIBLE);
                View03.setVisibility(View.VISIBLE);
                linearLayout2.setVisibility(View.VISIBLE);*/

                Intent intent = new Intent(Ancre, Home.class);
                intent.putExtra("TypeNav", "privee");
                startActivity(intent);
            }

        }




    }

    private class AsyncCallWSPass extends AsyncTask<String, Void, Void> {
        @Override
        protected void onPreExecute() {
            //Make ProgressBar invisible
            pg.setVisibility(View.VISIBLE);
        }

        @Override
        protected Void doInBackground(String... params) {
            Map<String,String> map = new HashMap<String,String>();
            map.put("UserName", username);
            RetourPass = WebService.invokeWSParams(map, "GetPassword");

            return null;
        }

        @Override
        protected void onProgressUpdate(Void... values) {
        }

        @Override
        protected void onPostExecute(Void result) {
            pg.setVisibility(View.GONE);

            //Set response
            if (RetourPass.contentEquals("0")) {
                View v = findViewById(R.id.body);

                Fonctions.ShowAlertNeutralButton(Ancre, "Erreur", "Cette adresse mail n'est pas associée à un membre du rotary 1730!", "Ok");
            }
            else if (RetourPass.contentEquals("1")) {
                Toast.makeText(getApplicationContext(), "Un email vous a été adressé avec votre mot de passe.",
                        Toast.LENGTH_LONG).show();
            }

        }




    }


}
