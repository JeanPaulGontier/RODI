package net.aisdev.rotary1730;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.AsyncTask;
import android.os.Bundle;
import android.widget.Toast;

import java.util.HashMap;
import java.util.Map;


public class Splash extends Activity {
    // Splash screen timer
    int SPLASH_TIME_OUT = 3000;
    String username;
    String password;
    String Retour;
    Splash Ancre;
    Context _context;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_splash);

       /* new Handler().postDelayed(new Runnable() {

            *//*
             * Showing splash screen with a timer. This will be useful when you
             * want to show case your app logo / company
             *//*

            @Override
            public void run() {*/
        try {

            Ancre = this;
            _context = getApplicationContext();

            SharedPreferences settings = _context.getSharedPreferences("id", 0);
            String id = settings.getString("id", "");

            SharedPreferences settings2 = _context.getSharedPreferences("pwd", 0);
            String pwd = settings2.getString("pwd", "");

            //S'il y a internet
            if (Fonctions.isConnected(_context)) {
                //Si l'appli possède des IDs on tester leurs validités
                if (!id.contentEquals("") && !pwd.contentEquals("")) {
                    username = id;
                    password = pwd;
                    //Si les settings sont renseignés -> Test si les settings sont actifs sur le site
                    AsyncCallWS task = new AsyncCallWS();
                    //Call execute
                    task.execute();
                }
                //Si l'appli ne possède pas d'IDs on redirige vers la page d'identification après une pause de 3secondes
                else {
                    Thread timer = new Thread(){
                        public void run(){
                            try{
                                sleep(3000);
                            }
                            catch(InterruptedException e){
                                e.printStackTrace();
                            } finally {
                                //Si pas identifié => écran d'identification
                                Intent i = new Intent(Ancre, Start.class);
                                startActivity(i);
                                finish();
                            }
                        }
                    };
                    timer.start();
                }
            }
            //S'il n'y a pas internet
            else {

                //Il n'y a pas de connection internet
                //On vérifie qu'il y a la liste des membres et des clubs

                SharedPreferences settings3 = _context.getSharedPreferences("Membres", 0);
                String LesMembres = settings3.getString("Membres", "");

                /*SharedPreferences settings4 = _context.getSharedPreferences("Clubs", 0);
                String LesClubs = settings4.getString("Clubs", "");*/

                SharedPreferences settings5 = _context.getSharedPreferences("MembresPro", 0);
                String LesMembresPro = settings5.getString("MembresPro", "");



                //Si l'appli possède les listes adéquates => redirection vers l'annuaire mais en mode public
                //if(!LesMembres.contentEquals("") && !LesClubs.contentEquals("") && !LesMembresPro.contentEquals(""))
                if(!LesMembres.contentEquals("")  && !LesMembresPro.contentEquals(""))
                {
                    Toast.makeText(getApplicationContext(), "Pas de connexion internet. Navigation en mode public!",
                            Toast.LENGTH_LONG).show();

                    Intent intent = new Intent(Ancre, Home.class);
                    intent.putExtra("TypeNav", "public");
                    startActivity(intent);
                    finish();
                }
                else {
                    Fonctions.ShowAlertNeutralButton(Ancre, "Erreur", "Vous devez disposer d'une connexion internet!", "Ok");
                }
            }
        }
        catch (Exception ee) {
            ee.printStackTrace();
        }
    }
        //}, SPLASH_TIME_OUT);
    //}

    private class AsyncCallWS extends AsyncTask<String, Void, Void> {
        @Override
        protected void onPreExecute() {
            //Make ProgressBar invisible

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

                Toast.makeText(getApplicationContext(), "Erreur d'identification!",
                        Toast.LENGTH_LONG).show();

                Intent intent = new Intent(Ancre, Start.class);
                startActivity(intent);
                finish();
            }
            else {
                //Le WS a reconnu le membre identifié
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

                Intent intent = new Intent(Ancre, Home.class);
                intent.putExtra("TypeNav", "privee");
                startActivity(intent);
                finish();
            }

        }




    }

}
