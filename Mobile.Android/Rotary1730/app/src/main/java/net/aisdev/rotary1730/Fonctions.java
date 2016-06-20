package net.aisdev.rotary1730;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.res.Resources;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.os.Build;
import android.util.DisplayMetrics;
import android.util.TypedValue;
import android.view.MenuItem;

import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;
import java.util.Calendar;
import java.util.Date;

/**
 * Created by gregory on 21/10/2014.
 */
public class Fonctions {

    public static final String md5(final String s) {
        final String MD5 = "MD5";
        try {
            // Create MD5 Hash
            MessageDigest digest = java.security.MessageDigest
                    .getInstance(MD5);
            digest.update(s.getBytes());
            byte messageDigest[] = digest.digest();

            // Create Hex String
            StringBuilder hexString = new StringBuilder();
            for (byte aMessageDigest : messageDigest) {
                String h = Integer.toHexString(0xFF & aMessageDigest);
                while (h.length() < 2)
                    h = "0" + h;
                hexString.append(h);
            }
            return hexString.toString();

        } catch (NoSuchAlgorithmException e) {
            e.printStackTrace();
        }
        return "";
    }

    public static boolean isConnected(Context context){
        boolean connect = false;
        try {

            ConnectivityManager connectivityManager = (ConnectivityManager) context.getSystemService(Context.CONNECTIVITY_SERVICE);
            NetworkInfo wifiInfo = connectivityManager.getNetworkInfo(ConnectivityManager.TYPE_WIFI);
            NetworkInfo mobileInfo = connectivityManager.getNetworkInfo(ConnectivityManager.TYPE_MOBILE);

            //boolean wifi = wifiInfo.isConnected();
            //boolean mobile = mobileInfo.isConnected();

            if(wifiInfo != null || mobileInfo != null )
            {
                if(wifiInfo != null && wifiInfo.isConnected()){
                    connect = true;
                }
                else if(mobileInfo != null && mobileInfo.isConnected()){
                    connect = true;
                }
            }

           /* if (  (wifiInfo != null && wifiInfo.isConnected()) || (mobileInfo != null && mobileInfo.isConnected())) {
                //return true;
            } else {
                //return false;
            }*/
        }
        catch (Exception ee) {
            ee.printStackTrace();
        }
        finally {
            return connect;
        }
    }

    public static void updateMenuCon_Deconn(MenuItem leMenu, String type_nav) {
        try {
            if (type_nav.contentEquals("privee")) {
                leMenu.setTitle("Déconnexion");
            } else {
                leMenu.setTitle("Connexion");
            }
        }
        catch (Exception ee) {
            ee.printStackTrace();
        }
    }

    public static void ShowAlertPositiveButton(Activity act, String title, String Message, String MessButton){
        new AlertDialog.Builder(act)
                .setTitle(title)
                .setMessage(Message)
                .setPositiveButton(MessButton, new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialogInterface, int i) {

                    }
                })
                .show();
    }

    public static void ShowAlertNeutralButton(Activity act, String title, String Message, String MessButton){
        new AlertDialog.Builder(act)
                .setTitle(title)
                .setMessage(Message)
                .setNeutralButton(MessButton, new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialogInterface, int i) {

                    }
                })
                .show();
    }

    public static void ShowAlertNegativeButton(Activity act,String title, String Message, String MessButton){
        new AlertDialog.Builder(act)
                .setTitle(title)
                .setMessage(Message)
                .setNegativeButton(MessButton, new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialogInterface, int i) {

                    }
                })
                .show();
    }

    public static Calendar DateToCalendar(Date date){
        Calendar cal = Calendar.getInstance();
        cal.setTime(date);
        return cal;
    }

    public static float dipToPixels(Context context, float dipValue) {
        DisplayMetrics metrics = context.getResources().getDisplayMetrics();
        return TypedValue.applyDimension(TypedValue.COMPLEX_UNIT_DIP, dipValue, metrics);
    }

    public static float convertDpToPixel(float dp, Context context)
    {
        Resources resources = context.getResources();
        DisplayMetrics metrics = resources.getDisplayMetrics();
        float px = dp * (metrics.densityDpi / 160f);
        return px;
    }

    public static String getDeviceName() {
        String manufacturer = Build.MANUFACTURER;
        String model = Build.MODEL;
        if (model.startsWith(manufacturer)) {
            return capitalize(model);
        } else {
            return capitalize(manufacturer) + " " + model;
        }
    }

    private static String capitalize(String s) {
        if (s == null || s.length() == 0) {
            return "";
        }
        char first = s.charAt(0);
        if (Character.isUpperCase(first)) {
            return s;
        } else {
            return Character.toUpperCase(first) + s.substring(1);
        }
    }

    public static String getVersion() {
        return android.os.Build.VERSION.RELEASE;
    }

    public static int getSdkVersion() {
        return android.os.Build.VERSION.SDK_INT;
    }

    public static final String EMAIL_PATTERN =
            "^[_A-Za-z0-9-\\+]+(\\.[_A-Za-z0-9-]+)*@"
                    + "[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$";

}
