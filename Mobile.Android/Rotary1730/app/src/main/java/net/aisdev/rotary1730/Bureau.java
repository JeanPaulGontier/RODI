package net.aisdev.rotary1730;

import java.io.Serializable;

/**
 * Created by gregory on 13/11/2014.
 */
public class Bureau extends BureauListAdapter.Row implements Serializable {
    private Membre membre;

    public  Bureau() {
    }


    public Membre getMembre() {
        return membre;
    }

    public void setMembre(Membre membre) {
        this.membre = membre;
    }
}
