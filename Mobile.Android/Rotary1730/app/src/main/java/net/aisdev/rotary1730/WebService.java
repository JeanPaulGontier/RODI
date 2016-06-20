package net.aisdev.rotary1730;

/**
 * Created by gregory on 02/09/2014.
 */

import org.ksoap2.SoapEnvelope;
import org.ksoap2.serialization.PropertyInfo;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapPrimitive;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;

import java.util.Map;

public class WebService {
    //Namespace of the Webservice - It is http://tempuri.org for .NET webservice
    private static String NAMESPACE = "http://tempuri.org/";
    //Webservice URL - It is asmx file location hosted in the server in case of .Net
    //Change the IP address to your machine IP address
    private static String URL = "http://www.rotary1730.org/ais/Android.asmx";
    //SOAP Action URI again http://tempuri.org
    private static String SOAP_ACTION = "http://tempuri.org/";

    public static String invokeWS(String user, String pass, String webMethName) {
        String resTxt = null;
        // Create request
        SoapObject request = new SoapObject(NAMESPACE, webMethName);
        //request.addProperty("username",user);
        //request.addProperty("password",pass);

        // Property which holds input parameters
        PropertyInfo sayHelloPI = new PropertyInfo();

        // Set Name
        sayHelloPI.setName("username");
        // Set Value
        sayHelloPI.setValue(user);
        // Set dataType
        sayHelloPI.setType(String.class);
        // Add the property to request object
        request.addProperty(sayHelloPI);

        PropertyInfo sayHelloPI2 = new PropertyInfo();
        sayHelloPI2.setName("password");
        sayHelloPI2.setValue(pass);
        // Set dataType
        sayHelloPI2.setType(String.class);
        // Add the property to request object
        request.addProperty(sayHelloPI2);

        // Create envelope
        SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(
                SoapEnvelope.VER11);
        //Set envelope as dotNet
        envelope.dotNet = true;
        // Set output SOAP object
        envelope.setOutputSoapObject(request);
        // Create HTTP call object
        HttpTransportSE androidHttpTransport = new HttpTransportSE(URL);

        try {
            // Invoke web service
            androidHttpTransport.call(SOAP_ACTION+webMethName, envelope);
            // Get the response
            SoapPrimitive response = (SoapPrimitive) envelope.getResponse();
            // Assign it to resTxt variable static variable
            resTxt = response.toString();

        } catch (Exception e) {
            //Print error
            e.printStackTrace();
            //Assign error message to resTxt
            resTxt = "Error occured";
        }
        //Return resTxt to calling object
        return resTxt;
    }

    public static String invokeWSParams(Map<String, String> params, String webMethName) {
        String resTxt = null;
        // Create request
        SoapObject request = new SoapObject(NAMESPACE, webMethName);
        //request.addProperty("username",user);
        //request.addProperty("password",pass);

        if (params != null && !params.isEmpty()) {
            for(Map.Entry<String, String> entry : params.entrySet()) {
                // Property which holds input parameters
                PropertyInfo sayHelloPI = new PropertyInfo();

                String cle = entry.getKey();
                String valeur = entry.getValue();

                // traitements
                // Set Name
                sayHelloPI.setName(cle);
                // Set Value
                sayHelloPI.setValue(valeur);
                // Set dataType
                sayHelloPI.setType(String.class);
                // Add the property to request object
                request.addProperty(sayHelloPI);
            }

            //Pour enregistrer les stats
            PropertyInfo sayHelloPI = new PropertyInfo();
            String cle = "device";
            String valeur = "" + Fonctions.getDeviceName();
            sayHelloPI.setName(cle);
            sayHelloPI.setValue(valeur);
            sayHelloPI.setType(String.class);
            request.addProperty(sayHelloPI);

            PropertyInfo sayHelloPI2 = new PropertyInfo();
            String cle2 = "version";
            String valeur2 = "" + Fonctions.getVersion();
            sayHelloPI2.setName(cle2);
            sayHelloPI2.setValue(valeur2);
            sayHelloPI2.setType(String.class);
            request.addProperty(sayHelloPI2);

            PropertyInfo sayHelloPI3 = new PropertyInfo();
            String cle3 = "fonction";
            String valeur3 = webMethName;
            sayHelloPI3.setName(cle3);
            sayHelloPI3.setValue(valeur3);
            sayHelloPI3.setType(String.class);
            request.addProperty(sayHelloPI3);
        }


        // Create envelope
        SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(
                SoapEnvelope.VER11);
        //Set envelope as dotNet
        envelope.dotNet = true;
        // Set output SOAP object
        envelope.setOutputSoapObject(request);
        // Create HTTP call object
        HttpTransportSE androidHttpTransport = new HttpTransportSE(URL);

        try {
            // Invoke web service
            androidHttpTransport.call(SOAP_ACTION+webMethName, envelope);
            // Get the response
            SoapPrimitive response = (SoapPrimitive) envelope.getResponse();
            // Assign it to resTxt variable static variable
            resTxt = response.toString();

        } catch (Exception e) {
            //Print error
            e.printStackTrace();
            //Assign error message to resTxt
            resTxt = "Error occured";
        }
        //Return resTxt to calling object
        return resTxt;
    }

    public static SoapObject invokeWS_Obj(String user, String pass, String webMethName) {
        SoapObject request = new SoapObject(NAMESPACE, webMethName);
        //request.addProperty("username",user);
        //request.addProperty("password",pass);

        // Property which holds input parameters
        PropertyInfo sayHelloPI = new PropertyInfo();

        // Set Name
        sayHelloPI.setName("username");
        // Set Value
        sayHelloPI.setValue(user);
        // Set dataType
        sayHelloPI.setType(String.class);
        // Add the property to request object
        request.addProperty(sayHelloPI);

        PropertyInfo sayHelloPI2 = new PropertyInfo();
        sayHelloPI2.setName("password");
        sayHelloPI2.setValue(pass);
        // Set dataType
        sayHelloPI2.setType(String.class);
        // Add the property to request object
        request.addProperty(sayHelloPI2);

        // Create envelope
        SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(
                SoapEnvelope.VER11);
        //Set envelope as dotNet
        envelope.dotNet = true;
        // Set output SOAP object
        envelope.setOutputSoapObject(request);
        // Create HTTP call object
        HttpTransportSE androidHttpTransport = new HttpTransportSE(URL);

        try {
            // Invoke web service
            androidHttpTransport.call(SOAP_ACTION+webMethName, envelope);
            // Get the response
            //SoapPrimitive response = (SoapPrimitive) envelope.getResponse();
            SoapObject response = (SoapObject)envelope.getResponse();
            //Object response = (Object)envelope.getResponse();
           return  response;

        } catch (Exception e) {
            //Print error
            e.printStackTrace();
            //Assign error message to resTxt
            return  null;
        }
    }
}
