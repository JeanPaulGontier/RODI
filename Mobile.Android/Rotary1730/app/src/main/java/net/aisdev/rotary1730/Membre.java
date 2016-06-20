package net.aisdev.rotary1730;

import java.io.Serializable;
import java.util.Date;

/**
 * Created by gregory on 21/10/2014.
 */
public class Membre extends AlphabetListAdapter.Row implements Serializable  {

    public int id;
    public int nim;
    public String membre_honneur;
    public String nom;
    public String prenom;
    public int cric;
    public String membre_actif;
    public String civilite;
    public String nom_jeune_fille;
    public String prenom_conjoint;
    public String titre;
    public Date annee_naissance;
    public Date annee_adhesion_rotary;
    public String email;
    public String adresse_1;
    public String adresse_2;
    public String adresse_3;
    public String code_postal;
    public String ville;
    public String telephone;
    public String fax;
    public String gsm;
    public String pays;
    public String fonction_metier;
    public String branche_activite;
    public String biographie;
    public Date datemaj_base;
    public String adresse_professionnelle;
    public String code_postal_professionnel;
    public String ville_professionnel;
    public String tel_professionnel;
    public String fax_professionnel;
    public String portable_professionnel;
    public String email_professionnel;
    public String retraite;
    public String radie;
    public int district_id;
    public String nom_club;
    public int userid;
    public String photo;
    public String visible;
    private String fonction_rotarienne;

    public  Membre() {
    }

    public int getNim() {
        return nim;
    }

    public void setNim(int nim) {
        this.nim = nim;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getMembre_honneur() {
        return membre_honneur;
    }

    public void setMembre_honneur(String membre_honneur) {
        this.membre_honneur = membre_honneur;
    }

    public String getNom() {
        return nom;
    }

    public void setNom(String nom) {
        this.nom = nom;
    }

    public String getPrenom() {
        return prenom;
    }

    public void setPrenom(String prenom) {
        this.prenom = prenom;
    }

    public int getCric() {
        return cric;
    }

    public void setCric(int cric) {
        this.cric = cric;
    }

    public String getMembre_actif() {
        return membre_actif;
    }

    public void setMembre_actif(String membre_actif) {
        this.membre_actif = membre_actif;
    }

    public String getCivilite() {
        return civilite;
    }

    public void setCivilite(String civilite) {
        this.civilite = civilite;
    }

    public String getNom_jeune_fille() {
        return nom_jeune_fille;
    }

    public void setNom_jeune_fille(String nom_jeune_fille) {
        this.nom_jeune_fille = nom_jeune_fille;
    }

    public String getPrenom_conjoint() {
        return prenom_conjoint;
    }

    public void setPrenom_conjoint(String prenom_conjoint) {
        this.prenom_conjoint = prenom_conjoint;
    }

    public String getTitre() {
        return titre;
    }

    public void setTitre(String titre) {
        this.titre = titre;
    }

    public Date getAnnee_naissance() {
        return annee_naissance;
    }

    public void setAnnee_naissance(Date annee_naissance) {
        this.annee_naissance = annee_naissance;
    }

    public Date getAnnee_adhesion_rotary() {
        return annee_adhesion_rotary;
    }

    public void setAnnee_adhesion_rotary(Date annee_adhesion_rotary) {
        this.annee_adhesion_rotary = annee_adhesion_rotary;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getAdresse_1() {
        return adresse_1;
    }

    public void setAdresse_1(String adresse_1) {
        this.adresse_1 = adresse_1;
    }

    public String getAdresse_2() {
        return adresse_2;
    }

    public void setAdresse_2(String adresse_2) {
        this.adresse_2 = adresse_2;
    }

    public String getAdresse_3() {
        return adresse_3;
    }

    public void setAdresse_3(String adresse_3) {
        this.adresse_3 = adresse_3;
    }

    public String getCode_postal() {
        return code_postal;
    }

    public void setCode_postal(String code_postal) {
        this.code_postal = code_postal;
    }

    public String getVille() {
        return ville;
    }

    public void setVille(String ville) {
        this.ville = ville;
    }

    public String getTelephone() {
        return telephone;
    }

    public void setTelephone(String telephone) {
        this.telephone = telephone;
    }

    public String getFax() {
        return fax;
    }

    public void setFax(String fax) {
        this.fax = fax;
    }

    public String getGsm() {
        return gsm;
    }

    public void setGsm(String gsm) {
        this.gsm = gsm;
    }

    public String getPays() {
        return pays;
    }

    public void setPays(String pays) {
        this.pays = pays;
    }

    public String getFonction_metier() {
        return fonction_metier;
    }

    public void setFonction_metier(String fonction_metier) {
        this.fonction_metier = fonction_metier;
    }

    public String getBranche_activite() {
        return branche_activite;
    }

    public void setBranche_activite(String branche_activite) {
        this.branche_activite = branche_activite;
    }

    public String getBiographie() {
        return biographie;
    }

    public void setBiographie(String biographie) {
        this.biographie = biographie;
    }

    public Date getDatemaj_base() {
        return datemaj_base;
    }

    public void setDatemaj_base(Date datemaj_base) {
        this.datemaj_base = datemaj_base;
    }

    public String getAdresse_professionnelle() {
        return adresse_professionnelle;
    }

    public void setAdresse_professionnelle(String adresse_professionnelle) {
        this.adresse_professionnelle = adresse_professionnelle;
    }

    public String getCode_postal_professionnel() {
        return code_postal_professionnel;
    }

    public void setCode_postal_professionnel(String code_postal_professionnel) {
        this.code_postal_professionnel = code_postal_professionnel;
    }

    public String getVille_professionnel() {
        return ville_professionnel;
    }

    public void setVille_professionnel(String ville_professionnel) {
        this.ville_professionnel = ville_professionnel;
    }

    public String getTel_professionnel() {
        return tel_professionnel;
    }

    public void setTel_professionnel(String tel_professionnel) {
        this.tel_professionnel = tel_professionnel;
    }

    public String getFax_professionnel() {
        return fax_professionnel;
    }

    public void setFax_professionnel(String fax_professionnel) {
        this.fax_professionnel = fax_professionnel;
    }

    public String getPortable_professionnel() {
        return portable_professionnel;
    }

    public void setPortable_professionnel(String portable_professionnel) {
        this.portable_professionnel = portable_professionnel;
    }

    public String getEmail_professionnel() {
        return email_professionnel;
    }

    public void setEmail_professionnel(String email_professionnel) {
        this.email_professionnel = email_professionnel;
    }

    public String getRetraite() {
        return retraite;
    }

    public void setRetraite(String retraite) {
        this.retraite = retraite;
    }

    public String getRadie() {
        return radie;
    }

    public void setRadie(String radie) {
        this.radie = radie;
    }

    public int getDistrict_id() {
        return district_id;
    }

    public void setDistrict_id(int district_id) {
        this.district_id = district_id;
    }

    public String getNom_club() {
        return nom_club;
    }

    public void setNom_club(String nom_club) {
        this.nom_club = nom_club;
    }

    public int getUserid() {
        return userid;
    }

    public void setUserid(int userid) {
        this.userid = userid;
    }

    public String getPhoto() {
        return photo;
    }

    public void setPhoto(String photo) {
        this.photo = photo;
    }

    public String getVisible() {
        return visible;
    }

    public void setVisible(String visible) {
        this.visible = visible;
    }

    public String getFonction_rotarienne() {
        return fonction_rotarienne;
    }

    public void setFonction_rotarienne(String fonction_rotarienne) {
        this.fonction_rotarienne = fonction_rotarienne;
    }


        /*public String GetPhoto()
        {
            String chemin = PortalSettings.Current.HomeDirectory;
            chemin += Const.MEMBRES_PHOTOS_PREFIX;
            if (photo == "")
            {
                if (civilite == "M")
                    chemin = Const.MEMBRES_NOPHOTO_H;
                else
                    chemin = Const.MEMBRES_NOPHOTO_F;
            }
            else
            {
                chemin += photo;
            }
            return chemin;
        }
        public Boolean IsWoman()
        {
            if (civilite == null)
                return false;
            return civilite.equals(("Mme") || civilite.equals("Mlle");
        }*/

}
