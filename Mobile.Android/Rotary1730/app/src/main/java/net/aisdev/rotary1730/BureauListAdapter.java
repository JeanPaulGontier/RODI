package net.aisdev.rotary1730;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.LinearLayout;
import android.widget.TextView;

import java.util.List;

/**
 * Created by gregory on 13/11/2014.
 */
public class BureauListAdapter extends BaseAdapter {
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
            view = (LinearLayout) inflater.inflate(R.layout.row_item_bureau, parent, false);
        }

        try {
            Bureau item = (Bureau) getItem(position);

            if(item != null) {
                TextView textView = (TextView) view.findViewById(R.id.text_Bureau);
                TextView txtFct = (TextView) view.findViewById(R.id.text_fct);

                if(item.getMembre().getNom() != null && !item.getMembre().getNom().isEmpty() && !item.getMembre().getNom().trim().contentEquals("")) {
                    if (item.getMembre().getFonction_rotarienne() != null && !item.getMembre().getFonction_rotarienne().isEmpty() && !item.getMembre().getFonction_rotarienne().toLowerCase().trim().contentEquals("fondation rotary")) {
                        //textView.setText(item.getMembre().getNom() + " " + item.getMembre().getPrenom());
                        textView.setText(item.getMembre().getNom() + " " + item.getMembre().getPrenom());
                        txtFct.setText(item.getMembre().getFonction_rotarienne());
                    } else {
                        textView.setText(item.getMembre().getNom() + " " + item.getMembre().getPrenom());
                        txtFct.setText("");
                        //textView.setText(item.getMembre().getNom() + " " + item.getMembre().getPrenom() + " - " + item.getMembre().getFonction_rotarienne());
                    }
                }
            }

        }
        catch (Exception ee){
            ee.printStackTrace();
        }

        return view;
    }
}
