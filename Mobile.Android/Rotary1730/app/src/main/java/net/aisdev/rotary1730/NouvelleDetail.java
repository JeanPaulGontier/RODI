package net.aisdev.rotary1730;

import android.app.Activity;
import android.app.DownloadManager;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.content.SharedPreferences;
import android.database.Cursor;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Paint;
import android.net.Uri;
import android.os.Bundle;
import android.util.Base64;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.ImageView;
import android.widget.ShareActionProvider;
import android.widget.TextView;
import android.widget.Toast;

import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Locale;


public class NouvelleDetail extends Activity {
    private NouvelleDetail Ancre;
    private Nouvelle LaNouvelle;
    private ImageView img;
    private TextView titre;
    private TextView date;
    private TextView description;
    private TextView url;
    private DownloadManager mManager;
    private long enqueue;
    private String TypeNav = "public";
    private ShareActionProvider mShareActionProvider;
    private Intent mShareIntent;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_nouvelle_detail);

        try {
            Ancre = this;

            Bundle extras = getIntent().getExtras();

            if (extras != null) {
                TypeNav = extras.getString("TypeNav");
            }

            if (getIntent().getSerializableExtra("Nouvelle") != null) {
                LaNouvelle = (Nouvelle) getIntent().getSerializableExtra("Nouvelle");
                img = (ImageView) findViewById(R.id.ImageViewNouvelle);
                titre = (TextView) findViewById(R.id.tvw_Titre);
                date = (TextView) findViewById(R.id.tvw_Date);
                description = (TextView) findViewById(R.id.tvw_Descrip);
                url = (TextView) findViewById(R.id.tvw_Url);

                ShareNews();

                BroadcastReceiver receiver = new BroadcastReceiver() {
                    @Override
                    public void onReceive(Context context, Intent intent) {
                        String action = intent.getAction();
                        if (DownloadManager.ACTION_DOWNLOAD_COMPLETE.equals(action)) {
                            long downloadId = intent.getLongExtra(
                                    DownloadManager.EXTRA_DOWNLOAD_ID, 0);
                            DownloadManager.Query query = new DownloadManager.Query();
                            query.setFilterById(enqueue);
                            Cursor c = mManager.query(query);
                                if (c.moveToFirst()) {
                                    int columnIndex = c
                                            .getColumnIndex(DownloadManager.COLUMN_STATUS);
                                    if (DownloadManager.STATUS_SUCCESSFUL == c
                                            .getInt(columnIndex)) {

                                        Intent i = new Intent();
                                        i.setAction(DownloadManager.ACTION_VIEW_DOWNLOADS);
                                        startActivity(i);
                                    }
                                }
                        }
                    }
                };

                registerReceiver(receiver, new IntentFilter(
                        DownloadManager.ACTION_DOWNLOAD_COMPLETE));

                if (!LaNouvelle.getTitre().isEmpty()) {
                    titre.setText(LaNouvelle.getTitre());
                } else {
                    titre.setVisibility(View.GONE);
                }

                if (LaNouvelle.getDt() != null) {
                    Calendar cal = Fonctions.DateToCalendar(LaNouvelle.getDt());

                    SimpleDateFormat Day_date = new SimpleDateFormat("dd");
                    String LeJour = Day_date.format(cal.getTime());

                    //SimpleDateFormat month_date = new SimpleDateFormat("MMM");
                    SimpleDateFormat month_date = new SimpleDateFormat("LLL", Locale.getDefault());
                    String LaMois = month_date.format(cal.getTime());

                    SimpleDateFormat Year_date = new SimpleDateFormat("yyyy");
                    String LAnnee = Year_date.format(cal.getTime());

                    String LaDate = LeJour + " " + LaMois + " " + LAnnee;

                    /*SimpleDateFormat sdf = new SimpleDateFormat("dd-MM-yyyy");*/
                    date.setText(LaDate);
                } else {
                    date.setVisibility(View.GONE);
                }

                if (!LaNouvelle.getTexte().isEmpty()) {
                    description.setText(LaNouvelle.getTexte());
                } else {
                    description.setVisibility(View.GONE);
                }

                if (!LaNouvelle.getUrl().isEmpty()) {
                    if(!LaNouvelle.getUrl_texte().isEmpty()) {
                        url.setText("Document à télécharger : " + LaNouvelle.getUrl_texte());
                        url.setPaintFlags(url.getPaintFlags() | Paint.UNDERLINE_TEXT_FLAG);
                    }
                    else {
                        url.setText("Document à télécharger : " + LaNouvelle.getUrl());
                        url.setPaintFlags(url.getPaintFlags() | Paint.UNDERLINE_TEXT_FLAG);
                    }
                } else {
                    if (!LaNouvelle.getTexte().isEmpty()) {

                    }
                    url.setVisibility(View.GONE);
                }

                if (!LaNouvelle.getPhotoString64().isEmpty()) {
                    byte[] LaPhoto = Base64.decode(LaNouvelle.getPhotoString64(), Base64.NO_WRAP);
                    Bitmap bitmap = BitmapFactory.decodeByteArray(LaPhoto, 0, LaPhoto.length);
               /* int hauteur = bitmap.getHeight();
                int largeur = bitmap.getWidth();
                //float ratio = (float)largeur/hauteur;
                float ratio = (float)hauteur/largeur;
                Bitmap resizedbitmap = Bitmap.createScaledBitmap(bitmap, 100, (int)(100*ratio) , true);
                img.setImageBitmap(resizedbitmap);*/
                    img.setImageBitmap(bitmap);
                }
                else {
                    img.setVisibility(View.GONE);
                }
            }
        }
        catch (Exception ee) {
            ee.printStackTrace();
        }
    }

    public void ShareNews() {
        try
        {
            mShareIntent = new Intent();
            mShareIntent.setAction(Intent.ACTION_SEND);
            mShareIntent.setType("text/plain");
            mShareIntent.putExtra(Intent.EXTRA_TITLE, LaNouvelle.getTitre());
            mShareIntent.putExtra(Intent.EXTRA_SUBJECT, LaNouvelle.getTitre());
            mShareIntent.putExtra(Intent.EXTRA_TEXT, LaNouvelle.getUrlNews());
            //startActivity(Intent.createChooser(mShareIntent, "Partager une nouvelle"));
        }
        catch (Exception ee) {
            ee.printStackTrace();
        }
    }

    public  void onAddAgendaClick(View v){
        try {
            Calendar cal = Fonctions.DateToCalendar(LaNouvelle.getDt());
            Intent intent = new Intent(Intent.ACTION_EDIT);
            intent.setType("vnd.android.cursor.item/event");
            intent.putExtra("beginTime", cal.getTimeInMillis());
            intent.putExtra("allDay", true);
            //intent.putExtra("rrule", "FREQ=YEARLY");
            //intent.putExtra("endTime", cal.getTimeInMillis() + 60 * 60 * 1000);
            intent.putExtra("title", LaNouvelle.getTitre());
            //intent.putExtra("description", "This is a sample description");
            startActivity(intent);
        }
        catch (Exception ee) {
            ee.printStackTrace();
        }
    }

    public void onDownloadClick(View v) {
        try {
            if (Fonctions.isConnected(getApplicationContext())) {
                mManager = (DownloadManager) getSystemService(Context.DOWNLOAD_SERVICE);
                DownloadManager.Request request = new DownloadManager.Request(
                        Uri.parse(LaNouvelle.getUrl()));
                enqueue = mManager.enqueue(request);

                Toast.makeText(getApplicationContext(), "Fichier en cours de téléchargement. Veuillez patienter.",
                        Toast.LENGTH_LONG).show();
            }
            else {
                Toast.makeText(getApplicationContext(), "Aucune connexion trouvée. Pas téléchargement possible!",
                        Toast.LENGTH_LONG).show();
            }
        }
        catch (Exception ee){
            ee.printStackTrace();
        }
    }
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.nouvelle_detail, menu);
        Fonctions.updateMenuCon_Deconn(menu.findItem(R.id.action_settings), TypeNav);
        // Locate MenuItem with ShareActionProvider
        MenuItem item = menu.findItem(R.id.menu_item_share);

        // Fetch and store ShareActionProvider
        mShareActionProvider = (ShareActionProvider) item.getActionProvider();

        // Connect the dots: give the ShareActionProvider its Share Intent
        if (mShareActionProvider != null) {
            mShareActionProvider.setShareIntent(mShareIntent);
        }

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
