package net.aisdev.rotary1730;

import android.app.TabActivity;
import android.content.Intent;
import android.content.SharedPreferences;
import android.content.res.Resources;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.ProgressBar;
import android.widget.TabHost;


public class Home extends TabActivity {

    String TypeNav = "public";
    ProgressBar pg;
    View llt_Tabs;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_home);

        llt_Tabs = (View) findViewById(R.id.llt_Tabs);
        pg = (ProgressBar) findViewById(R.id.ProgressB);

        pg.setVisibility(View.VISIBLE);
        llt_Tabs.setVisibility(View.GONE);

        Resources ressources = getResources();
        TabHost tabHost = getTabHost();

        Bundle extras = getIntent().getExtras();
        if (extras != null) {
            TypeNav = extras.getString("TypeNav");
        }

        // Annuaire tab
        Intent intentAnnuaire = new Intent().setClass(this, Tab_Annuaire.class);
        intentAnnuaire.putExtra("TypeNav", TypeNav);
        TabHost.TabSpec tabSpecAnnuaire = tabHost.newTabSpec("Annuaire")
                .setIndicator("Annuaire", ressources.getDrawable(R.drawable.annuaire_cfg))
                .setContent(intentAnnuaire);


        /*// Agenda tab
        Intent intentAgenda = new Intent().setClass(this, Tab_Agenda.class);
        intentAgenda.putExtra("TypeNav", TypeNav);
        TabHost.TabSpec tabSpecAgenda = tabHost.newTabSpec("Agenda")
                .setIndicator("Agenda", ressources.getDrawable(R.drawable.agenda_cfg))
                .setContent(intentAgenda);*/

        // Nouvelles tab
        Intent intentNouvelles = new Intent().setClass(this, Tab_Nouvelles.class);
        intentNouvelles.putExtra("TypeNav", TypeNav);
        TabHost.TabSpec tabSpecNouvelles = tabHost.newTabSpec("Nouvelles")
                .setIndicator("Nouvelles", ressources.getDrawable(R.drawable.nouvelles_cfg))
                .setContent(intentNouvelles);

        // add all tabs
        tabHost.addTab(tabSpecNouvelles);
        tabHost.addTab(tabSpecAnnuaire);
        //tabHost.addTab(tabSpecAgenda);


        //set Windows tab as default (zero based)
        tabHost.setCurrentTab(0);

        pg.setVisibility(View.GONE);
        llt_Tabs.setVisibility(View.VISIBLE);
    }



    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.home, menu);

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
