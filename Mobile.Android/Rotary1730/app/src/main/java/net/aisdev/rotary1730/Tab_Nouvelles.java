package net.aisdev.rotary1730;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.MenuItem;
import android.view.View;
import android.view.inputmethod.InputMethodManager;
import android.widget.AdapterView;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.RadioButton;
import android.widget.Toast;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.reflect.TypeToken;

import java.util.ArrayList;
import java.util.Calendar;
import java.util.GregorianCalendar;
import java.util.HashMap;
import java.util.List;
import java.util.Map;


public class Tab_Nouvelles extends Activity {

    ListView list;
    NouvellesListAdapter adapter;
    private Tab_Nouvelles Ancre;
    private List<Nouvelle> OriginalListeNouvelles = new ArrayList<Nouvelle>();
    String RetourNouvelles;
    private RadioButton rbt_Tous;
    private RadioButton rbt_District;
    private RadioButton rbt_Clubs;
    private LinearLayout layoutListView;
    private LinearLayout layoutProgress;
    private Context _context;
    private String TypeNav = "public";
    private MenuItem menu;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_tab_nouvelles);
        try {
            Ancre = this;
            rbt_Tous = (RadioButton) Ancre.findViewById(R.id.radioNewsTous);
            rbt_District = (RadioButton) Ancre.findViewById(R.id.radioNewsDistrict);
            rbt_Clubs = (RadioButton) Ancre.findViewById(R.id.radioNewsClubs);
            list = (ListView) findViewById(R.id.listView_Nouvelles);
            layoutListView = (LinearLayout) findViewById(R.id.linlaTypeAnnu);//linlaListeView
            layoutProgress = (LinearLayout) findViewById(R.id.linlaHeaderProgress);
            _context = getApplicationContext();



            Bundle extras = getIntent().getExtras();
            if (extras != null) {
                TypeNav = extras.getString("TypeNav");
            }

            //Pour masquer le clavier
            InputMethodManager inputManager = (InputMethodManager) this.getSystemService(Context.INPUT_METHOD_SERVICE);
            View view = this.getCurrentFocus();
            if(view != null) {
                inputManager.hideSoftInputFromWindow(view.getWindowToken(), InputMethodManager.HIDE_NOT_ALWAYS);
            }

            layoutProgress.setVisibility(View.VISIBLE);
            layoutListView.setVisibility(View.GONE);

            SharedPreferences settings3 = _context.getSharedPreferences("Nouvelles", 0);
            String RetourLesNouvelles = settings3.getString("Nouvelles", "");

            if(!RetourLesNouvelles.contentEquals("") && !RetourLesNouvelles.contentEquals("[]") )
            {
                Gson gson = new GsonBuilder().setDateFormat("yyyy-MM-dd").create();
                if (OriginalListeNouvelles != null) {
                    OriginalListeNouvelles = new ArrayList<Nouvelle>();
                }
                OriginalListeNouvelles = gson.fromJson(RetourLesNouvelles, new TypeToken<List<Nouvelle>>() {
                }.getType());

                attachListView(OriginalListeNouvelles);

                layoutProgress.setVisibility(View.GONE);
                layoutListView.setVisibility(View.VISIBLE);

                //Tester s'il y a de l'internet
                if (Fonctions.isConnected(_context)) {
                    //On vérifie la date de MAJ des listes
                    SharedPreferences settingsY = _context.getSharedPreferences("dtMajYNouv", 0);
                    int dtMajY = settingsY.getInt("dtMajYNouv", -1);
                    SharedPreferences settingsMO = _context.getSharedPreferences("dtMajMONouv", 0);
                    int dtMajMO = settingsMO.getInt("dtMajMONouv", -1);
                    SharedPreferences settingsD = _context.getSharedPreferences("dtMajDNouv", 0);
                    int dtMajD = settingsD.getInt("dtMajDNouv", -1);
                    SharedPreferences settingsH = _context.getSharedPreferences("dtMajHNouv", 0);
                    int dtMajH = settingsH.getInt("dtMajHNouv", -1);
                    SharedPreferences settingsMn = _context.getSharedPreferences("dtMajMmNouv", 0);
                    int dtMajMm = settingsMn.getInt("dtMajMmNouv", -1);


                    if (dtMajY > -1 || dtMajMO > -1 || dtMajD > -1 || dtMajH > -1 || dtMajMm > -1) {
                        //Convert to calendar
                        Calendar cal = Calendar.getInstance();
                        cal.set(Calendar.YEAR, dtMajY);
                        cal.set(Calendar.MONTH, dtMajMO); // 11 = december
                        cal.set(Calendar.DAY_OF_MONTH, dtMajD);
                        cal.set(Calendar.HOUR_OF_DAY, dtMajH);// 24 hour clock
                        cal.set(Calendar.MINUTE, dtMajMm);

                        Calendar c = Calendar.getInstance();
                        c.set(Calendar.HOUR_OF_DAY, 9);// 24 hour clock

                        if (cal.before(c)) {
                            AsyncCallWSNews taskNews = new AsyncCallWSNews();
                            taskNews.execute();
                        }
                    }
                    else {
                        AsyncCallWSNews taskNews = new AsyncCallWSNews();
                        taskNews.execute();
                    }
                }
                else {
                    Toast.makeText(getApplicationContext(), "Aucune connexion trouvée. Pas de mise à jour possible!",
                            Toast.LENGTH_LONG).show();
                }

            }
            else {
                //Pas de liste existante
                //Tester s'il y a de l'internet
                if (Fonctions.isConnected(_context)) {
                    layoutProgress.setVisibility(View.VISIBLE);
                    layoutListView.setVisibility(View.GONE);

                    AsyncCallWSNews taskNews = new AsyncCallWSNews();
                    taskNews.execute();
                }
                else {
                    layoutProgress.setVisibility(View.GONE);
                    layoutListView.setVisibility(View.VISIBLE);
                    Fonctions.ShowAlertNeutralButton(Ancre, "Erreur", "Aucune connexion trouvée. Impossible de récupérer les données!", "Ok");
                }
            }

            list.setOnItemClickListener(new AdapterView.OnItemClickListener() {
                public void onItemClick(AdapterView<?> parent, View view, int position, long id) {

                    Intent intent = new Intent(Ancre, NouvelleDetail.class);
                    Nouvelle nouvelleSelect = (Nouvelle)parent.getAdapter().getItem(position);
                    intent.putExtra("TypeNav", TypeNav);
                    intent.putExtra("Nouvelle", nouvelleSelect);
                    startActivity(intent);
                }
            });

        }
        catch (Exception ee){
            ee.printStackTrace();
            Fonctions.ShowAlertNeutralButton(Ancre, "Erreur", "Problème de traitement des données", "Ok");
        }
    }

    public void onSearchclick(View v) {
        try {
            attachListView(OriginalListeNouvelles);
        }
        catch (Exception ee) {
            ee.printStackTrace();
        }
    }

    private class AsyncCallWSNews extends AsyncTask<String, Void, Void> {
        @Override
        protected void onPreExecute() {
        }

        @Override
        protected Void doInBackground(String... params) {
            Calendar Today = Calendar.getInstance();
            String LaDate = "" + Today.get(Calendar.YEAR) + "-" + (Today.get(Calendar.MONTH)+1) + "-" + Today.get(Calendar.DAY_OF_MONTH);

            //Récupération de la liste des Nouvelles
            Map<String, String> map = new HashMap<String, String>();
            map.put("cric", "0");
            map.put("categorie", "");
            map.put("tags_inclus", "");
            map.put("tags_exclus", "");
            map.put("top", "");
            map.put("tri", "dt DESC");
            map.put("index", "0");
            map.put("max", "10000");
            map.put("onlyvisible", "true");
            map.put("date", "dt >= '" + LaDate +"'");
            String retour;
//ListeNews(int cric = 0, string categorie = "", string tags_inclus = "", string tags_exclus = "", string top = "", string tri = "dt DESC", int index = 0, int max = 100, bool onlyvisible = false)

            retour = WebService.invokeWSParams(map, "ListeNews");

            if(retour != null) {
                SharedPreferences settings = getSharedPreferences("Nouvelles", 0);
                SharedPreferences.Editor editor = settings.edit();
                editor.putString("Nouvelles", retour);
                // Commit the edits!
                editor.commit();

                RetourNouvelles = retour;
            }
            else
            {
                Fonctions.ShowAlertNeutralButton(Ancre, "Erreur", "Problème de récupération des nouvelles", "Ok");
            }
            return null;
        }

        @Override
        protected void onProgressUpdate(Void... values) {
        }

        @Override
        protected void onPostExecute(Void result) {
            try {
                if (!RetourNouvelles.contentEquals("")) {
                    Gson gson = new GsonBuilder().setDateFormat("yyyy-MM-dd").create();
                    if (OriginalListeNouvelles != null) {
                        OriginalListeNouvelles = new ArrayList<Nouvelle>();
                    }
                    OriginalListeNouvelles = gson.fromJson(RetourNouvelles, new TypeToken<List<Nouvelle>>() {
                    }.getType());

                    PutDate();

                    attachListView(OriginalListeNouvelles);

                    if(layoutProgress.getVisibility() == View.VISIBLE){
                        layoutProgress.setVisibility(View.GONE);
                        layoutListView.setVisibility(View.VISIBLE);
                    }

                    //MajMembres = true;
                }

            /*if(MajMembres && MajMembresPro && MajClubs) {
                //Insert dtMaj
                PutDate();

                if(layoutProgress.getVisibility() == View.VISIBLE){
                    layoutProgress.setVisibility(View.GONE);
                    layoutListView.setVisibility(View.VISIBLE);
                }
            }*/

            }
            catch(Exception ee) {
                ee.printStackTrace();
            }
        }

    }

    public void attachListView (List<Nouvelle> ListeNouvelles){
        try {
            if (ListeNouvelles != null && !ListeNouvelles.isEmpty() && ListeNouvelles.size() > 0) {

                List<NouvellesListAdapter.Row> rows = new ArrayList<NouvellesListAdapter.Row>();

                adapter = new NouvellesListAdapter();
                adapter.getContext(_context);

                for (Nouvelle Nouv : ListeNouvelles) {

                    if(rbt_District.isChecked()) {
                        if(Nouv.getCategorie().toLowerCase().contains("district")) {
                            rows.add(Nouv);
                        }
                    }
                    else if(rbt_Clubs.isChecked()) {
                        if(Nouv.getCategorie().toLowerCase().contains("clubs")) {
                            rows.add(Nouv);
                        }
                    }
                    else {
                        rows.add(Nouv);
                    }
                }

                adapter.setRows(rows);
                list.setAdapter(adapter);

                if(rows.size() == 0){
                    Toast.makeText(getApplicationContext(), "Aucun résultat!",
                            Toast.LENGTH_SHORT).show();
                }
            }
            else {
                Toast.makeText(getApplicationContext(), "Aucun résultat!",
                        Toast.LENGTH_LONG).show();

                List<NouvellesListAdapter.Row> rows = new ArrayList<NouvellesListAdapter.Row>();
                adapter.setRows(rows);
                list.setAdapter(adapter);
            }
        } catch (Exception e) {
            e.printStackTrace();
            Fonctions.ShowAlertNeutralButton(Ancre, "Erreur", "Problème de traitement des données", "Ok");
        }
    }

    private  void PutDate()
    {
        try {
            Calendar c = GregorianCalendar.getInstance();

            SharedPreferences settings = getSharedPreferences("dtMajYNouv", 0);
            SharedPreferences.Editor editor = settings.edit();
            editor.putInt("dtMajYNouv", c.get(Calendar.YEAR));
            editor.commit();

            SharedPreferences settings2 = getSharedPreferences("dtMajMONouv", 0);
            SharedPreferences.Editor editor2 = settings2.edit();
            editor2.putInt("dtMajMONouv", c.get(Calendar.MONTH));
            editor2.commit();

            SharedPreferences settings3 = getSharedPreferences("dtMajDNouv", 0);
            SharedPreferences.Editor editor3 = settings3.edit();
            editor3.putInt("dtMajDNouv", c.get(Calendar.DAY_OF_MONTH));
            editor3.commit();

            SharedPreferences settings4 = getSharedPreferences("dtMajHNouv", 0);
            SharedPreferences.Editor editor4 = settings4.edit();
            editor4.putInt("dtMajHNouv", c.get(Calendar.HOUR_OF_DAY));
            editor4.commit();

            SharedPreferences settings5 = getSharedPreferences("dtMajMmNouv", 0);
            SharedPreferences.Editor editor5 = settings5.edit();
            editor5.putInt("dtMajMmNouv", c.get(Calendar.MINUTE));
            editor5.commit();
        }
        catch (Exception ee) {
            ee.printStackTrace();
        }
    }

    /*@Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.nouvelles, menu);

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
        return super.onOptionsItemSelected(item);
    }*/
}
