package net.aisdev.rotary1730;

import android.app.Activity;
import android.app.AlertDialog;
import android.app.ListActivity;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.GestureDetector;
import android.view.Gravity;
import android.view.MotionEvent;
import android.view.View;
import android.view.View.OnTouchListener;
import android.view.ViewGroup;
import android.view.inputmethod.InputMethodManager;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.RadioButton;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.reflect.TypeToken;

import java.util.ArrayList;
import java.util.Calendar;
import java.util.Collections;
import java.util.Comparator;
import java.util.GregorianCalendar;
import java.util.HashMap;
import java.util.List;
import java.util.Locale;
import java.util.Map;
import java.util.regex.Pattern;


public class Tab_Annuaire extends ListActivity {
    private AlphabetListAdapter adapter = new AlphabetListAdapter();
    private GestureDetector mGestureDetector;
    private List<Object[]> alphabet = new ArrayList<Object[]>();
    private HashMap<String, Integer> sections = new HashMap<String, Integer>();
    private int sideIndexHeight;
    private static float sideIndexX;
    private static float sideIndexY;
    private int indexListSize;

    //private List<Membre> ListeMembres  = new ArrayList<Membre>();
    private List<Membre> OriginalListeMembres = new ArrayList<Membre>();
    private List<Membre> OriginalListeMembresPro  = new ArrayList<Membre>();
    private List<Club> OriginalListeClubs  = new ArrayList<Club>();
    private String RetourMembres = "";
    private String RetourMembresPro = "";
    //private String RetourClubs = "";
    private String TypeNav = "public";
    private boolean MajMembres = false;
    private boolean MajMembresPro = false;
    //private boolean MajClubs = false;
    private String [] LesClubs = null;
    private Button btnClub;

    private LinearLayout layoutListView;
    private LinearLayout layoutProgress;
    private LinearLayout layoutSearch;
    private LinearLayout layoutSearchClub;
    private LinearLayout layoutClub;
    private LinearLayout linearLayout2;
    private ListView listview;
    private Tab_Annuaire Ancre;
    private Spinner spinner1;
    private RadioButton rbt_Pro;
    private RadioButton rbt_Gen;
    private TextView Search;

    private SpinAdapter adapterSpin;
    private Club clubSelect;
    private Context _context;
    private String id = "";
    private String pwd = "";

    BureauListAdapter adapterBureau;
    ListView listBureau;

    public class SideIndexGestureListener extends GestureDetector.SimpleOnGestureListener {
        @Override
        public boolean onScroll(MotionEvent e1, MotionEvent e2, float distanceX, float distanceY) {
            sideIndexX = sideIndexX - distanceX;
            sideIndexY = sideIndexY - distanceY;
            if (sideIndexX >= 0 && sideIndexY >= 0) {
                displayListItem();
            }
            return super.onScroll(e1, e2, distanceX, distanceY);
        }
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.list_alphabet);

        _context = getApplicationContext();
        Ancre = this;
        layoutListView = (LinearLayout) findViewById(R.id.linlaListeView);//linlaListeView
        layoutProgress = (LinearLayout) findViewById(R.id.linlaHeaderProgress);
        layoutSearch = (LinearLayout) findViewById(R.id.linlaSearch);
        layoutSearchClub = (LinearLayout) findViewById(R.id.linlaSearchClubs);
        layoutClub = (LinearLayout) findViewById(R.id.linlaClub);
        linearLayout2 = (LinearLayout) findViewById(R.id.linearLayout2);
        listview = (ListView) findViewById(android.R.id.list);
        rbt_Pro = (RadioButton) Ancre.findViewById(R.id.radioProfessionnel);
        rbt_Gen = (RadioButton) Ancre.findViewById(R.id.radioGeneral);
        Search = (TextView)findViewById(R.id.edtSearch);
        btnClub = (Button)findViewById(R.id.btn_Club_Select);
        listBureau = (ListView) findViewById(R.id.list_Bureau);
        //spinner1 = (Spinner) findViewById(R.id.spinner1);

        try{
            layoutSearch.setVisibility(View.VISIBLE);
            layoutSearchClub.setVisibility(View.GONE);
            layoutClub.setVisibility(View.GONE);
            linearLayout2.setVisibility(View.VISIBLE);
            btnClub.setText("Clubs");

            Bundle extras = getIntent().getExtras();
            if (extras != null) {
                TypeNav = extras.getString("TypeNav");
            }

            //Pour masquer le clavier jusqu'à ce que un edittext soit touché
            InputMethodManager inputMethodManger = (InputMethodManager)getSystemService(Activity
                    .INPUT_METHOD_SERVICE);
            inputMethodManger.hideSoftInputFromWindow(Search.getWindowToken(), 0);


            SharedPreferences settingsp = _context.getSharedPreferences("TypeListe", 0);
            String TypeListe = settingsp.getString("TypeListe", "");

            if(TypeNav.contentEquals("privee"))
            {
                SharedPreferences settings = _context.getSharedPreferences("id", 0);
                id = settings.getString("id", "");

                SharedPreferences settings2 = _context.getSharedPreferences("pwd", 0);
                pwd = settings2.getString("pwd", "");
            }

            layoutProgress.setVisibility(View.VISIBLE);
            layoutListView.setVisibility(View.GONE);

            SharedPreferences settings3 = _context.getSharedPreferences("Membres", 0);
            String RetourLesMembres = settings3.getString("Membres", "");

            /*SharedPreferences settings4 = _context.getSharedPreferences("Clubs", 0);
            String RetourLesClubs = settings4.getString("Clubs", "");*/

            SharedPreferences settings5 = _context.getSharedPreferences("MembresPro", 0);
            String RetourLesMembresPro = settings5.getString("MembresPro", "");



            //if(!RetourLesMembres.contentEquals("") && !RetourLesClubs.contentEquals("") && !RetourLesMembresPro.contentEquals(""))
            if(!RetourLesMembres.contentEquals("") && !RetourLesMembres.contentEquals("[]") && !RetourLesMembresPro.contentEquals("") && !RetourLesMembresPro.contentEquals("[]"))
            {
                // On vérifie que les listes que l'on a sont du bon type
                if(TypeListe.contentEquals(TypeNav)) {
                    Gson gson = new GsonBuilder().setDateFormat("yyyy-MM-dd").create();
                    if (OriginalListeMembres != null) {
                        OriginalListeMembres.clear();
                    }
                    OriginalListeMembres = gson.fromJson(RetourLesMembres, new TypeToken<List<Membre>>() {
                    }.getType());

                    GetClubs(OriginalListeMembres);

                    if (OriginalListeMembresPro != null) {
                        OriginalListeMembresPro.clear();
                    }
                    OriginalListeMembresPro = gson.fromJson(RetourLesMembresPro, new TypeToken<List<Membre>>() {
                    }.getType());

                /*if(OriginalListeClubs != null) {
                    OriginalListeClubs.clear();
                }
                OriginalListeClubs = gson.fromJson(RetourLesClubs, new TypeToken<List<Club>>() {
                }.getType());*/

                    attachListView(OriginalListeMembresPro);

                    layoutProgress.setVisibility(View.GONE);
                    layoutListView.setVisibility(View.VISIBLE);

                    //Tester s'il y a de l'internet
                    if (Fonctions.isConnected(_context)) {

                        //On vérifie la date de MAJ des listes
                        SharedPreferences settingsY = _context.getSharedPreferences("dtMajY", 0);
                        int dtMajY = settingsY.getInt("dtMajY", -1);
                        SharedPreferences settingsMO = _context.getSharedPreferences("dtMajMO", 0);
                        int dtMajMO = settingsMO.getInt("dtMajMO", -1);
                        SharedPreferences settingsD = _context.getSharedPreferences("dtMajD", 0);
                        int dtMajD = settingsD.getInt("dtMajD", -1);
                        SharedPreferences settingsH = _context.getSharedPreferences("dtMajH", 0);
                        int dtMajH = settingsH.getInt("dtMajH", -1);
                        SharedPreferences settingsMn = _context.getSharedPreferences("dtMajMm", 0);
                        int dtMajMm = settingsMn.getInt("dtMajMm", -1);


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
                        /*Calendar today = new GregorianCalendar();
                        today.set(Calendar.YEAR, c.YEAR);
                        today.set(Calendar.MONTH, c.MONTH); // 11 = december
                        today.set(Calendar.DAY_OF_MONTH, c.DAY_OF_MONTH);
                        today.set(Calendar.HOUR_OF_DAY, 9);// 24 hour clock
                        today.set(Calendar.MINUTE, 0);*/

                            if (cal.before(c)) {
                                AsyncCallWSMembres taskMembres = new AsyncCallWSMembres();
                                taskMembres.execute();

                                AsyncCallWSMembresPro taskMembresPro = new AsyncCallWSMembresPro();
                                taskMembresPro.execute();

                            /*AsyncCallWSClub taskClubs = new AsyncCallWSClub();
                            taskClubs.execute();*/
                            }

                        } else {
                            AsyncCallWSMembres taskMembres = new AsyncCallWSMembres();
                            taskMembres.execute();

                            AsyncCallWSMembresPro taskMembresPro = new AsyncCallWSMembresPro();
                            taskMembresPro.execute();

                        /*AsyncCallWSClub taskClubs = new AsyncCallWSClub();
                        taskClubs.execute();*/
                        }

                    } else {
                        Toast.makeText(getApplicationContext(), "Aucune connexion trouvée. Pas de mise à jour possible de l'annuaire!",
                                Toast.LENGTH_LONG).show();
                    }
                }
                // Les listes que l'on a ne sont pas du bon type (privee public
                else {
                    if (Fonctions.isConnected(_context)) {
                        AsyncCallWSMembres taskMembres = new AsyncCallWSMembres();
                        taskMembres.execute();

                        AsyncCallWSMembresPro taskMembresPro = new AsyncCallWSMembresPro();
                        taskMembresPro.execute();
                    }
                    else {
                        Toast.makeText(getApplicationContext(), "Aucune connexion trouvée. Pas de mise à jour possible de l'annuaire!",
                                Toast.LENGTH_LONG).show();
                    }
                }
            }
            else {
                //Pas de listes existantes
                //Tester s'il y a de l'internet
                if (Fonctions.isConnected(_context)) {
                    layoutProgress.setVisibility(View.VISIBLE);
                    layoutListView.setVisibility(View.GONE);

                    AsyncCallWSMembres taskMembres = new AsyncCallWSMembres();
                    taskMembres.execute();

                    AsyncCallWSMembresPro taskMembresPro = new AsyncCallWSMembresPro();
                    taskMembresPro.execute();

                    /*AsyncCallWSClub taskClubs = new AsyncCallWSClub();
                    taskClubs.execute();*/
                }
                else {
                    layoutProgress.setVisibility(View.GONE);
                    layoutListView.setVisibility(View.VISIBLE);
                    Fonctions.ShowAlertNeutralButton(Ancre, "Erreur", "Aucune connexion trouvée. Impossible de récupérer les données de l'annuaire", "Ok");
                }
            }

            mGestureDetector = new GestureDetector(this, new SideIndexGestureListener());

            listview.setOnItemClickListener(new AdapterView.OnItemClickListener() {
                public void onItemClick(AdapterView<?> parent, View view, int position, long id) {

                    try {
                        Intent intent = new Intent(Ancre, MembreDetail.class);
                        intent.putExtra("TypeNav", TypeNav);

                        Membre membreSelect = (Membre) parent.getAdapter().getItem(position);
                        intent.putExtra("Membre", membreSelect);

                    /*if(OriginalListeClubs != null)
                    {
                        for(Club cl : OriginalListeClubs){
                            if(cl.getCric() == membreSelect.getCric()) {
                                intent.putExtra("Club", cl);
                                break;
                            }
                        }
                    }*/
                        startActivity(intent);
                    }
                    catch (Exception ee) {
                        ee.printStackTrace();
                    }
                }
            });

            listBureau.setOnItemClickListener(new AdapterView.OnItemClickListener() {
                public void onItemClick(AdapterView<?> parent, View view, int position, long id) {

                    try {
                        Intent intent = new Intent(Ancre, MembreDetail.class);
                        intent.putExtra("TypeNav", TypeNav);
                        Bureau b = (Bureau) parent.getAdapter().getItem(position);
                        Membre membreSelect = (Membre) b.getMembre();
                        intent.putExtra("Membre", membreSelect);

                    /*if(OriginalListeClubs != null)
                    {
                        for(Club cl : OriginalListeClubs){
                            if(cl.getCric() == membreSelect.getCric()) {
                                intent.putExtra("Club", cl);
                                break;
                            }
                        }
                    }*/
                        startActivity(intent);
                    }
                    catch (Exception ee) {
                        ee.printStackTrace();
                    }
                }
            });

        } catch (Exception e) {
            e.printStackTrace();
            Fonctions.ShowAlertNeutralButton(Ancre, "Erreur", "Problème de traitement des données", "Ok");
        }
    }

    public void GetClubs(List<Membre> LesMembres) {
        try {
            Collections.sort(LesMembres, new Comparator<Membre>() {
                public int compare(Membre s1, Membre s2) {
                    String a = "" + s1.getNom_club();
                    String b = "" + s2.getNom_club();

                    return a.compareTo(b);
                }
            });

            LesClubs = null;
            ArrayList<String> stringArrayList = new ArrayList<String>();
            String previousClub = null;

            for (Membre memb : LesMembres) {
                String leClub = "" + memb.getNom_club();
                if (leClub.length() > 0) {
                    String unClub = leClub;

                    if (previousClub != null && !unClub.equals(previousClub)) {
                        stringArrayList.add(unClub);
                    }

                    if (previousClub == null) {
                        stringArrayList.add(unClub);
                    }

                    previousClub = unClub;
                }
            }

            if(stringArrayList != null) {
                LesClubs = stringArrayList.toArray(new String[stringArrayList.size()]);
            }
        }
        catch (Exception ee) {
            ee.printStackTrace();
        }
    }

    public void attachListView (List<Membre> ListeMembres){
        try {
            if (ListeMembres != null && !ListeMembres.isEmpty()) {

                Collections.sort(ListeMembres, new Comparator<Membre>() {
                    public int compare(Membre s1, Membre s2) {
                        String a = "" + s1.getNom();
                        String b = "" + s2.getNom();
                        Boolean bb = a.isEmpty();
                        Boolean cc = b.isEmpty();

                        return a.compareTo(b);
                    }
                });

                List<AlphabetListAdapter.Row> rows = new ArrayList<AlphabetListAdapter.Row>();
                sections = new HashMap<String, Integer>();
                alphabet = new ArrayList<Object[]>();
                adapter = new AlphabetListAdapter();

                int start = 0;
                int end = 0;
                String previousLetter = null;
                Object[] tmpIndexItem = null;
                Pattern numberPattern = Pattern.compile("\\[0-9]");


                for (Membre memb : ListeMembres) {
                    String leNom = "" + memb.getNom();
                    if (leNom.length() > 0) {
                        String firstLetter = leNom.substring(0, 1);

                        // Group numbers together in the scroller
                        if (numberPattern.matcher(firstLetter).matches()) {
                            firstLetter = "#";
                        }

                        // If we've changed to a new letter, add the previous letter to the alphabet scroller
                        if (previousLetter != null && !firstLetter.equals(previousLetter)) {
                            end = rows.size() - 1;
                            tmpIndexItem = new Object[3];
                            tmpIndexItem[0] = previousLetter.toUpperCase(Locale.FRANCE);
                            tmpIndexItem[1] = start;
                            tmpIndexItem[2] = end;
                            alphabet.add(tmpIndexItem);
                            start = end + 1;
                        }

                        // Check if we need to add a header row
                        if (!firstLetter.equals(previousLetter)) {
                            rows.add(new AlphabetListAdapter.Section(firstLetter));
                            sections.put(firstLetter, start);
                        }

                        rows.add(memb);
                        // Add the item to the list
                                /*if (memb.getPrenom() != null) {
                                    rows.add(new Item(leNom + " " + memb.getPrenom()));
                                } else {
                                    rows.add(new Item(leNom));
                                }*/

                        previousLetter = firstLetter;
                    }
                }

                if (previousLetter != null) {
                    // Save the last letter
                    tmpIndexItem = new Object[3];
                    tmpIndexItem[0] = previousLetter.toUpperCase(Locale.FRANCE);
                    tmpIndexItem[1] = start;
                    tmpIndexItem[2] = rows.size() - 1;
                    alphabet.add(tmpIndexItem);
                }

                adapter.setRows(rows);
                setListAdapter(adapter);
                updateList();
            }
            else {
                Toast.makeText(getApplicationContext(), "Aucun résultat!",
                        Toast.LENGTH_LONG).show();

                List<AlphabetListAdapter.Row> rows = new ArrayList<AlphabetListAdapter.Row>();
                adapter.setRows(rows);
                setListAdapter(adapter);
                updateList();
            }


        } catch (Exception e) {
            e.printStackTrace();
            Fonctions.ShowAlertNeutralButton(Ancre, "Erreur", "Problème de traitement des données", "Ok");
        }
    }

    public void onSearchclick(View v) {
        try {
            layoutSearch.setVisibility(View.VISIBLE);
            layoutSearchClub.setVisibility(View.GONE);
            layoutClub.setVisibility(View.GONE);
            linearLayout2.setVisibility(View.VISIBLE);
            btnClub.setText("Clubs");

            InputMethodManager imm = (InputMethodManager)getSystemService(
                    Context.INPUT_METHOD_SERVICE);
            imm.hideSoftInputFromWindow(Search.getWindowToken(), 0);

            List<Membre> MembresSearch = new ArrayList<Membre>();
            String recherche = "" + Search.getText().toString().toLowerCase();

                if (rbt_Gen.isChecked()) {
                    if(!recherche.contentEquals("")) {
                        for (Membre m : OriginalListeMembres) {
                            if (m.getNom().toLowerCase().contains(recherche) || m.getPrenom().toLowerCase().contains(recherche) || m.getFonction_metier().toLowerCase().contains(recherche) || m.getBranche_activite().toLowerCase().contains(recherche)) {
                                MembresSearch.add(m);
                            }
                        }
                        attachListView(MembresSearch);
                    }
                    else {
                        attachListView(OriginalListeMembres);
                    }
                } else {
                    if(!recherche.contentEquals("")) {
                        for (Membre m : OriginalListeMembresPro) {
                            if (m.getNom().toLowerCase().contains(recherche) || m.getPrenom().toLowerCase().contains(recherche) || m.getFonction_metier().toLowerCase().contains(recherche) || m.getBranche_activite().toLowerCase().contains(recherche)) {
                                MembresSearch.add(m);
                            }
                        }

                        attachListView(MembresSearch);
                    }
                    else {
                        attachListView(OriginalListeMembresPro);
                    }
                }



        }
        catch (Exception ee) {
            ee.printStackTrace();
        }
    }

    public void onSearchClubclick(View v) {
        try {
            layoutSearch.setVisibility(View.GONE);
            layoutSearchClub.setVisibility(View.VISIBLE);
            layoutClub.setVisibility(View.VISIBLE);
            linearLayout2.setVisibility(View.GONE);

            List<BureauListAdapter.Row> rows = new ArrayList<BureauListAdapter.Row>();
            adapterBureau = new BureauListAdapter();
            adapterBureau.setRows(rows);
            listBureau.setAdapter(adapterBureau);
        }
        catch (Exception ee) {
            ee.printStackTrace();
        }
    }

    public void onClubsclick(View v) {
        try {
            AlertDialog dialog;

            //final String [] items = { "Item1", "Item2" };
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            builder.setTitle("Sélectionner un club");
            builder.setItems(LesClubs, new DialogInterface.OnClickListener() {
                public void onClick(DialogInterface dialog, int pos) {
                    btnClub.setText(LesClubs[pos]);

                    List<Membre> MembresClub = new ArrayList<Membre>();
                    List<BureauListAdapter.Row> rows = new ArrayList<BureauListAdapter.Row>();
                    Bureau president = null;
                    Bureau secretaire = null;
                    Bureau tresorier = null;

                    for (Membre memb : OriginalListeMembres) {
                        if(memb.getNom_club().contentEquals(LesClubs[pos])){
                            if(memb.getFonction_rotarienne() == null || memb.getFonction_rotarienne().isEmpty() || memb.getFonction_rotarienne().contentEquals("Fondation Rotary")) {
                                MembresClub.add(memb);
                            }
                            else {
                                Bureau b = new  Bureau();
                                b.setMembre(memb);

                                if(memb.getFonction_rotarienne().toLowerCase().contentEquals("président"))
                                {
                                    president = b;
                                }
                                else if (memb.getFonction_rotarienne().toLowerCase().contentEquals("secrétaire")){
                                    secretaire = b;
                                }
                                else if (memb.getFonction_rotarienne().toLowerCase().contentEquals("trésorier")){
                                    tresorier = b;
                                }
                                else {
                                    rows.add(b);
                                }
                            }
                        }
                    }

                    if(MembresClub != null){
                        Collections.sort(MembresClub, new Comparator<Membre>() {
                            public int compare(Membre s1, Membre s2) {
                                String a = "" + s1.getNom();
                                String b = "" + s2.getNom();

                                return a.compareTo(b);
                            }
                        });

                        for(Membre m : MembresClub){
                            Bureau b = new  Bureau();
                            b.setMembre(m);
                            rows.add(b);
                        }
                    }

                    if(president != null){
                        rows.add(0, president);
                    }

                    if(secretaire != null){
                        rows.add(1, secretaire);
                    }

                    if(tresorier != null){
                        rows.add(2, tresorier);
                    }

                    adapterBureau = new BureauListAdapter();
                    adapterBureau.setRows(rows);
                    listBureau.setAdapter(adapterBureau);

                    attachListView(MembresClub);
                }});
            dialog=builder.create();
            dialog.show();

        }
        catch (Exception ee) {
            ee.printStackTrace();
        }
    }

    @Override
    public boolean onTouchEvent(MotionEvent event) {
        if (mGestureDetector.onTouchEvent(event)) {
            return true;
        } else {
            return false;
        }
    }

    public void updateList() {
        LinearLayout sideIndex = (LinearLayout) findViewById(R.id.sideIndex);
        sideIndex.removeAllViews();

        indexListSize = alphabet.size();
        if (indexListSize < 1) {
            return;
        }
        int indexMaxSize = (int) Math.floor(sideIndex.getHeight() / 20);
        int tmpIndexListSize = indexListSize;
        while (tmpIndexListSize > indexMaxSize) {
            tmpIndexListSize = tmpIndexListSize / 2;
        }
        double delta;
        if (tmpIndexListSize > 0) {
            delta = indexListSize / tmpIndexListSize;
        } else {
            delta = 1;
        }
        TextView tmpTV;
        for (double i = 1; i <= indexListSize; i = i + delta) {
            Object[] tmpIndexItem = alphabet.get((int) i - 1);
            String tmpLetter = tmpIndexItem[0].toString();
            tmpTV = new TextView(this);
            tmpTV.setText(tmpLetter);
            tmpTV.setGravity(Gravity.CENTER);
            tmpTV.setTextSize(10);
            LinearLayout.LayoutParams params = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.WRAP_CONTENT, ViewGroup.LayoutParams.WRAP_CONTENT, 1);
            tmpTV.setLayoutParams(params);
            sideIndex.addView(tmpTV);
        }
        sideIndexHeight = sideIndex.getHeight();
        sideIndex.setOnTouchListener(new OnTouchListener() {
            @Override
            public boolean onTouch(View v, MotionEvent event) {
// now you know coordinates of touch
                sideIndexX = event.getX();
                sideIndexY = event.getY();
// and can display a proper item it country list
                displayListItem();
                return false;
            }
        });
    }

    public void displayListItem() {
        LinearLayout sideIndex = (LinearLayout) findViewById(R.id.sideIndex);
        sideIndexHeight = sideIndex.getHeight();
// compute number of pixels for every side index item
        double pixelPerIndexItem = (double) sideIndexHeight / indexListSize;
// compute the item index for given event position belongs to
        int itemPosition = (int) (sideIndexY / pixelPerIndexItem);
// get the item (we can do it since we know item index)
        if (itemPosition < alphabet.size()) {
            Object[] indexItem = alphabet.get(itemPosition);
            int subitemPosition = sections.get(indexItem[0]);
//ListView listView = (ListView) findViewById(android.R.id.list);
            getListView().setSelection(subitemPosition);
        }
    }

    /*@Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.tab__annuaire, menu);

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



    private class AsyncCallWSMembres extends AsyncTask<String, Void, Void> {
        @Override
        protected void onPreExecute() {
        }

        @Override
        protected Void doInBackground(String... params) {
            //Récupération de la liste des membres
            Gson gson = new GsonBuilder().setDateFormat("yyyy-MM-dd").create();
            Map<String, String> map = new HashMap<String, String>();
            map.put("cric", "0");
            map.put("critere", "");
            map.put("top", "");
            map.put("tri", "");
            map.put("index", "0");
            map.put("max", "10000");
            map.put("onlyvisible", "false");
            map.put("username", id);
            if(!pwd.contentEquals("")) {
                String passMD5 = Fonctions.md5(pwd);
                map.put("password", passMD5);
            }
            else {
                map.put("password", pwd);
            }
            String retour;


            retour = WebService.invokeWSParams(map, "GetListeMembres");

            if(retour != null) {
                SharedPreferences settings = getSharedPreferences("Membres", 0);
                SharedPreferences.Editor editor = settings.edit();
                editor.putString("Membres", retour);
                // Commit the edits!
                editor.commit();

                SharedPreferences settingsp = getSharedPreferences("TypeListe", 0);
                SharedPreferences.Editor editorp = settingsp.edit();
                editorp.putString("TypeListe", TypeNav);
                // Commit the edits!
                editorp.commit();

                RetourMembres = retour;
            }
            else
            {
                Fonctions.ShowAlertNeutralButton(Ancre, "Erreur", "Problème de récupération des membres", "Ok");
            }
            return null;
        }

        @Override
        protected void onProgressUpdate(Void... values) {
        }

        @Override
        protected void onPostExecute(Void result) {
            if(!RetourMembres.contentEquals(""))
            {
                Gson gson = new GsonBuilder().setDateFormat("yyyy-MM-dd").create();
                if(OriginalListeMembres != null) {
                    OriginalListeMembres = new ArrayList<Membre>();
                }
                OriginalListeMembres = gson.fromJson(RetourMembres, new TypeToken<List<Membre>>() {
                }.getType());
                GetClubs(OriginalListeMembres);

                if(rbt_Gen.isChecked())
                {
                    attachListView(OriginalListeMembres);
                }

                MajMembres = true;
            }

            //if(MajMembres && MajMembresPro && MajClubs) {
            if(MajMembres && MajMembresPro) {
                //Insert dtMaj
                PutDate();

                if(layoutProgress.getVisibility() == View.VISIBLE){
                    layoutProgress.setVisibility(View.GONE);
                    layoutListView.setVisibility(View.VISIBLE);
                }
            }
        }
    }

    private class AsyncCallWSMembresPro extends AsyncTask<String, Void, Void> {
        @Override
        protected void onPreExecute() {
        }

        @Override
        protected Void doInBackground(String... params) {
            //Récupération de la liste des membres
            Gson gson = new GsonBuilder().setDateFormat("yyyy-MM-dd").create();
            Map<String, String> map = new HashMap<String, String>();
            map.put("cric", "0");
            map.put("critere", "");
            map.put("top", "");
            map.put("tri", "");
            map.put("index", "0");
            map.put("max", "10000");
            map.put("onlyvisible", "false");
            map.put("username", id);
            if(!pwd.contentEquals("")) {
                String passMD5 = Fonctions.md5(pwd);
                map.put("password", passMD5);
            }
            else {
                map.put("password", pwd);
            }
            String retour;

            retour = WebService.invokeWSParams(map, "ListeMembresPresentation");

            if(retour != null) {
                SharedPreferences settings = getSharedPreferences("MembresPro", 0);
                SharedPreferences.Editor editor = settings.edit();
                editor.putString("MembresPro", retour);
                // Commit the edits!
                editor.commit();

                SharedPreferences settingsp = getSharedPreferences("TypeListe", 0);
                SharedPreferences.Editor editorp = settingsp.edit();
                editorp.putString("TypeListe", TypeNav);
                // Commit the edits!
                editorp.commit();

                RetourMembresPro = retour;
            }
            else
            {
                Fonctions.ShowAlertNeutralButton(Ancre, "Erreur", "Problème de récupération des données professionnelles", "Ok");
            }
            return null;
        }

        @Override
        protected void onProgressUpdate(Void... values) {
        }

        @Override
        protected void onPostExecute(Void result) {
            if(!RetourMembresPro.contentEquals(""))
            {
                Gson gson = new GsonBuilder().setDateFormat("yyyy-MM-dd").create();
                if(OriginalListeMembresPro != null) {
                    OriginalListeMembresPro= new ArrayList<Membre>();
                }
                OriginalListeMembresPro = gson.fromJson(RetourMembresPro, new TypeToken<List<Membre>>() {
                }.getType());

                if(rbt_Pro.isChecked())
                {
                    attachListView(OriginalListeMembresPro);
                }

                MajMembresPro = true;
            }

            //if(MajMembres && MajMembresPro && MajClubs) {
            if(MajMembres && MajMembresPro) {
                //Insert dtMaj
                PutDate();

                if(layoutProgress.getVisibility() == View.VISIBLE){
                    layoutProgress.setVisibility(View.GONE);
                    layoutListView.setVisibility(View.VISIBLE);
                }
            }
        }
    }

    /*private class AsyncCallWSClub extends AsyncTask<String, Void, Void> {
        @Override
        protected void onPreExecute() {
        }

        @Override
        protected Void doInBackground(String... params) {

            //Récupération de la liste des membres
            Gson gson = new Gson();
            Map<String, String> map = new HashMap<String, String>();
            map.put("dept", "");
            map.put("top", "");
            map.put("tri", "");
            map.put("index", "0");
            map.put("max", "10000");
            String retour;


            retour = WebService.invokeWSParams(map, "ListeClub");

            if(retour != null) {
                SharedPreferences settings = getSharedPreferences("Clubs", 0);
                SharedPreferences.Editor editor = settings.edit();
                editor.putString("Clubs", retour);
                // Commit the edits!
                editor.commit();

                RetourClubs = retour;
            }
            else
            {
                Fonctions.ShowAlertNeutralButton(Ancre, "Erreur", "Problème de récupération des données club", "Ok");
            }

            return null;
        }

        @Override
        protected void onProgressUpdate(Void... values) {
        }

        @Override
        protected void onPostExecute(Void result) {
            if(!RetourClubs.contentEquals(""))
            {
                Gson gson = new GsonBuilder().setDateFormat("yyyy-MM-dd").create();
                if(OriginalListeClubs != null) {
                    OriginalListeClubs.clear();
                }
                OriginalListeClubs = gson.fromJson(RetourClubs, new TypeToken<List<Club>>() {
                }.getType());

                MajClubs = true;
            }

            if(MajMembres && MajMembresPro && MajClubs) {
                //Insert dtMaj
                PutDate();

                if(layoutProgress.getVisibility() == View.VISIBLE){
                    layoutProgress.setVisibility(View.GONE);
                    layoutListView.setVisibility(View.VISIBLE);
                }
            }
        }
    }*/

    private  void PutDate()
    {
        try {
            Calendar c = GregorianCalendar.getInstance();

            SharedPreferences settings = getSharedPreferences("dtMajY", 0);
            SharedPreferences.Editor editor = settings.edit();
            editor.putInt("dtMajY", c.get(Calendar.YEAR));
            editor.commit();

            SharedPreferences settings2 = getSharedPreferences("dtMajMO", 0);
            SharedPreferences.Editor editor2 = settings2.edit();
            editor2.putInt("dtMajMO", c.get(Calendar.MONTH));
            editor2.commit();

            SharedPreferences settings3 = getSharedPreferences("dtMajD", 0);
            SharedPreferences.Editor editor3 = settings3.edit();
            editor3.putInt("dtMajD", c.get(Calendar.DAY_OF_MONTH));
            editor3.commit();

            SharedPreferences settings4 = getSharedPreferences("dtMajH", 0);
            SharedPreferences.Editor editor4 = settings4.edit();
            editor4.putInt("dtMajH", c.get(Calendar.HOUR_OF_DAY));
            editor4.commit();

            SharedPreferences settings5 = getSharedPreferences("dtMajMm", 0);
            SharedPreferences.Editor editor5 = settings5.edit();
            editor5.putInt("dtMajMm", c.get(Calendar.MINUTE));
            editor5.commit();
        }
        catch (Exception ee) {
            ee.printStackTrace();
        }
    }









}


