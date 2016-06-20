package net.aisdev.rotary1730;

import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.util.Base64;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.TextView;

import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.List;
import java.util.Locale;

/**
 * Created by gregory on 04/11/2014.
 */
public class NouvellesListAdapter extends BaseAdapter {
    public static abstract class Row {}
    public Context LeContext;

    private List<Row> rows;
    public void setRows(List<Row> rows) {
        this.rows = rows;
    }

    public void getContext(Context _Context) {
        LeContext = _Context;
    }

    @Override
    public int getCount() {
        return rows.size();
    }

    @Override
    public Row getItem(int position) {
        return rows.get(position);
    }

    @Override
    public long getItemId(int position) {
        return position;
    }

    @Override
    public int getViewTypeCount() {
        return 2;
    }


    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        View view = convertView;

        if (view == null) {
            LayoutInflater inflater = (LayoutInflater) parent.getContext().getSystemService(Context.LAYOUT_INFLATER_SERVICE);
            view = (LinearLayout) inflater.inflate(R.layout.row_listview_item, parent, false);
        }

        Nouvelle item = (Nouvelle)getItem(position);

        TextView textView = (TextView) view.findViewById(R.id.text_Nouvelle);
        textView.setText(item.getTitre());

        TextView dateView = (TextView) view.findViewById(R.id.date_Nouvelle);
        Calendar cal = Fonctions.DateToCalendar(item.getDt());

        SimpleDateFormat Day_date = new SimpleDateFormat("dd");
        String LeJour = Day_date.format(cal.getTime());

        //SimpleDateFormat month_date = new SimpleDateFormat("MMM");
        SimpleDateFormat month_date = new SimpleDateFormat("LLL", Locale.getDefault());
        String LaMois = month_date.format(cal.getTime());

        SimpleDateFormat Year_date = new SimpleDateFormat("yyyy");
        String LAnnee = Year_date.format(cal.getTime());

        String LaDate = LeJour + " " + LaMois + " " + LAnnee;
        dateView.setText(LaDate);

        ImageView img = (ImageView) view.findViewById(R.id.image_Nouvelle);
        byte[] LaPhoto =  Base64.decode(item.getPhotoString64(), Base64.NO_WRAP);
        Bitmap bitmap = BitmapFactory.decodeByteArray(LaPhoto, 0, LaPhoto.length);
        int hauteur = bitmap.getHeight();
        int largeur = bitmap.getWidth();
        int toto = (int)Fonctions.dipToPixels(LeContext, 100);
        //int toto = (int) Fonctions.convertDpToPixel(100, LeContext);
        float ratio = (float)hauteur/largeur;
        Bitmap resizedbitmap;
        if((int)(toto*ratio) < toto)
        {
            resizedbitmap = Bitmap.createScaledBitmap(bitmap, toto, toto, true);
        }
        else {
            resizedbitmap = Bitmap.createScaledBitmap(bitmap, toto, (int) (toto * ratio), true);
        }
        //Bitmap resizedbitmap = Bitmap.createScaledBitmap(bitmap, toto ,  ((int) Fonctions.convertDpToPixel(toto*ratio, LeContext)), true);
        img.setImageBitmap(resizedbitmap);

        return view;
    }
}