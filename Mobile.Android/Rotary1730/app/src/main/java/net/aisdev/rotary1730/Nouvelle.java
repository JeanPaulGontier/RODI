package net.aisdev.rotary1730;

import java.io.Serializable;
import java.util.Date;

/**
 * Created by gregory on 31/10/2014.
 */
public class Nouvelle extends NouvellesListAdapter.Row implements Serializable {
    private String id ;
    private int cric;
    private Date dt;
    private String titre;
    private String texte;
    private String url;
    private String url_texte;
    private String photo;
    private String categorie;
    private String tag1;
    private String tag2;
    private String nom_club;
    private String visible;
    private String PhotoString64;
    private byte PhotoByte ;
    private String urlNews;

    public Nouvelle(){

    }

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public int getCric() {
        return cric;
    }

    public void setCric(int cric) {
        this.cric = cric;
    }

    public Date getDt() {
        return dt;
    }

    public void setDt(Date dt) {
        this.dt = dt;
    }

    public String getTitre() {
        return titre;
    }

    public void setTitre(String titre) {
        this.titre = titre;
    }

    public String getTexte() {
        return texte;
    }

    public void setTexte(String texte) {
        this.texte = texte;
    }

    public String getUrl() {
        return url;
    }

    public void setUrl(String url) {
        this.url = url;
    }

    public String getUrl_texte() {
        return url_texte;
    }

    public void setUrl_texte(String url_texte) {
        this.url_texte = url_texte;
    }

    public String getPhoto() {
        return photo;
    }

    public void setPhoto(String photo) {
        this.photo = photo;
    }

    public String getCategorie() {
        return categorie;
    }

    public void setCategorie(String categorie) {
        this.categorie = categorie;
    }

    public String getTag1() {
        return tag1;
    }

    public void setTag1(String tag1) {
        this.tag1 = tag1;
    }

    public String getTag2() {
        return tag2;
    }

    public void setTag2(String tag2) {
        this.tag2 = tag2;
    }

    public String getNom_club() {
        return nom_club;
    }

    public void setNom_club(String nom_club) {
        this.nom_club = nom_club;
    }

    public String getVisible() {
        return visible;
    }

    public void setVisible(String visible) {
        this.visible = visible;
    }

    public byte getPhotoByte() {
        return PhotoByte;
    }

    public void setPhotoByte(byte photoByte) {
        PhotoByte = photoByte;
    }

    public String getPhotoString64() {
        return PhotoString64;
    }

    public void setPhotoString64(String photoString64) {
        PhotoString64 = photoString64;
    }

    public String getUrlNews() {
        return urlNews;
    }

    public void setUrlNews(String urlNews) {
        this.urlNews = urlNews;
    }
}
