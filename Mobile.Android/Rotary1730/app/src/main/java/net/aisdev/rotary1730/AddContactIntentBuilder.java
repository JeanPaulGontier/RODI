package net.aisdev.rotary1730;


        import android.content.ContentValues;
import android.content.Intent;
import android.os.Build;
import android.provider.Contacts.Intents.Insert;
import android.provider.ContactsContract;
import android.provider.ContactsContract.CommonDataKinds.Email;
import android.provider.ContactsContract.CommonDataKinds.Phone;
import android.provider.ContactsContract.CommonDataKinds.StructuredPostal;
import android.provider.ContactsContract.Data;

import java.lang.reflect.Field;
import java.util.ArrayList;

/**
 *
 * Class to make adding a contact easier. Works for Eclair 2.1 through Jelly Bean 4.3.
 *
 * Please note that you can only add a maximum of 3 email addresses and 3 phone numbers
 * in Android API level <11.
 *
 * Example:
 *
 * <pre>
 * {@code
 * Intent intent = new AddContactIntentBuilder("Joe Blow")
 * .addFormattedAddress("123 Fake Street, Springfield USA", StructuredPostal.TYPE_HOME)
 * .addPhone("555-867-5309", Phone.TYPE_HOME)
 * .addPhone("555-123-4567", Phone.TYPE_WORK)
 * .addPhone("555-987-6543", Phone.TYPE_FAX_WORK)
 * .addEmail("joe.blow@gmail.com", Email.TYPE_HOME)
 * .addEmail("joe@blow.com", Email.TYPE_WORK)
 * .build();
 *
 * startActivity(intent);
 * }
 * </pre>
 *

 *
 */
@SuppressWarnings("deprecation")
public class AddContactIntentBuilder {
    private Intent intent;
    private ArrayList<ContentValues> parcels;
    private int numEmails = 0;
    private int numPhones = 0;

    /**
     * Create a new builder object.
     *
     * @param contactName
     */
    public AddContactIntentBuilder(String contactName) {

        intent = new Intent();

        intent.setAction(Intent.ACTION_INSERT);
        intent.setData(ContactsContract.Contacts.CONTENT_URI);
        intent.putExtra(ContactsContract.Intents.Insert.NAME, contactName);
        if (isHoneycomb()) {
            parcels = new ArrayList<ContentValues>();
        }
    }

    /**
     * Add a full, formatted postal address with the given type from CommonDataKinds.StructuredPostal.
     * Returns the builder itself.
     *
     * @see android.provider.ContactsContract.CommonDataKinds.StructuredPostal
     * @param address
     * @param type
     * @return
     */
    public AddContactIntentBuilder addFormattedAddress(String address, int type) {

        if (isHoneycomb()) {
            ContentValues addressData = new ContentValues();

            addressData.put(Data.MIMETYPE, StructuredPostal.CONTENT_ITEM_TYPE);
            addressData.put(StructuredPostal.FORMATTED_ADDRESS, address);
            addressData.put(StructuredPostal.TYPE, type);
            parcels.add(addressData);
        } else {
            intent.putExtra(Insert.POSTAL, address);
            intent.putExtra(Insert.POSTAL_TYPE, type);
        }
        return this;
    }

    /**
     * Add a phone number, with the given type from CommonDataKinds.Phone. Returns the builder itself.
     *
     * Throws an IllegalStateException if you try to add >3 phones in Android <v11.
     *
     * //@param android.provider.ContactsContract.CommonDataKinds.Phone
     * @param phone
     * @param type
     * @return
     */
    public AddContactIntentBuilder addPhone(String phone, int type) {
        if (isHoneycomb()) {
            ContentValues data = new ContentValues();
            data.put(Data.MIMETYPE, Phone.CONTENT_ITEM_TYPE);
            data.put(Phone.NUMBER, phone);

            data.put(Phone.TYPE, type);
            parcels.add(data);
        } else {
            switch (numPhones) {
                case 0:
                    intent.putExtra(Insert.PHONE, phone);
                    intent.putExtra(Insert.PHONE_TYPE, type);
                    break;
                case 1:
                    intent.putExtra(Insert.SECONDARY_PHONE, phone);
                    intent.putExtra(Insert.SECONDARY_PHONE_TYPE, type);
                    break;
                case 2:
                    intent.putExtra(Insert.TERTIARY_PHONE, phone);
                    intent.putExtra(Insert.TERTIARY_PHONE_TYPE, type);
                    break;
                default:
                    throw new IllegalStateException(String.format("can't add %d phone numbers in Android <v11",
                            (numEmails + 1)));
            }
        }
        numPhones++;
        return this;
    }

    /**
     * Add an email address, with the given type from CommonDataKinds.Email. Returns the builder itself.
     *
     * Throws an IllegalStateException if you try to add >3 email addresses in Android <v11.
     *
     * @see android.provider.ContactsContract.CommonDataKinds.Email
     * @param email
     * @param type
     * @return
     */
    public AddContactIntentBuilder addEmail(String email, int type) {
        if (isHoneycomb()) {
            ContentValues data = new ContentValues();
            data.put(Data.MIMETYPE, Email.CONTENT_ITEM_TYPE);
            data.put(Email.ADDRESS, email);

            data.put(Email.TYPE, type);
            parcels.add(data);
        } else {
            switch (numEmails) {
                case 0:
                    intent.putExtra(Insert.EMAIL, email);
                    intent.putExtra(Insert.EMAIL_TYPE, type);
                    break;
                case 1:
                    intent.putExtra(Insert.SECONDARY_EMAIL, email);
                    intent.putExtra(Insert.SECONDARY_EMAIL_TYPE, type);
                    break;
                case 2:
                    intent.putExtra(Insert.TERTIARY_EMAIL, email);
                    intent.putExtra(Insert.TERTIARY_EMAIL_TYPE, type);
                    break;
                default:
                    throw new IllegalStateException(String.format("can't add %d emails in Android <v11", (numEmails + 1)));
            }
        }
        numEmails++;
        return this;
    }

    public AddContactIntentBuilder addPhoto(byte[] photo) {
        if (isHoneycomb()) {
            ContentValues addressData = new ContentValues();

            addressData.put(ContactsContract.Data.MIMETYPE,    ContactsContract.CommonDataKinds.Photo.CONTENT_ITEM_TYPE);
            addressData.put(ContactsContract.CommonDataKinds.Photo.PHOTO, photo);
            parcels.add(addressData);
        }
        return this;
    }

    /**
     * Build the final intent to be passed to startActivity().
     * @return
     */
    public Intent build() {
        if (isHoneycomb()) {
            intent.putParcelableArrayListExtra(ContactsContract.Intents.Insert.DATA, parcels);
        }
        return intent;
    }

    private static boolean isHoneycomb() {
        return VersionHelper.getVersionSdkIntCompat() >= VersionHelper.VERSION_HONEYCOMB;
    }

    /**
     * Helper to determine what version of Android the device is running.
     *
     * @author nolan
     *
     */
    public static class VersionHelper {

        public static final int VERSION_CUPCAKE = 3;
        public static final int VERSION_DONUT = 4;
        public static final int VERSION_FROYO = 8;
        public static final int VERSION_HONEYCOMB = 11;
        public static final int VERSION_JELLYBEAN = 16;

        private static Field sdkIntField = null;
        private static boolean fetchedSdkIntField = false;

        public static int getVersionSdkIntCompat() {
            try {
                Field field = getSdkIntField();
                if (field != null) {
                    return (Integer) field.get(null);
                }
            } catch (IllegalAccessException ignore) {
// ignore
            }
            return VERSION_CUPCAKE; // cupcake
        }

        private static Field getSdkIntField() {
            if (!fetchedSdkIntField) {
                try {
                    sdkIntField = Build.VERSION.class.getField("SDK_INT");
                } catch (NoSuchFieldException ignore) {
// ignore
                }
                fetchedSdkIntField = true;
            }
            return sdkIntField;
        }
    }
}
