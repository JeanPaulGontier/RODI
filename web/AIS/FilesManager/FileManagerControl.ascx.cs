using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AIS_FilesManager_FileManagerControl : System.Web.UI.UserControl
{
    /// <summary>
    /// Indiquer le chemin relatif du repertoire
    /// </summary>
    string pathFile = "";
    public string PathFile
    {
        get
        {
            return pathFile;
        }

        set
        {
            pathFile = value;
            hfd_path.Value = pathFile;
        }
    }

    /// <summary>
    /// Permet ou pas de sélectionner plusieurs fichiers à uploader
    /// </summary>
    bool multipleFiles = false;
    public bool Multiple
    {
        get
        {
            return multipleFiles;
        }

        set
        {
            multipleFiles = value;
            if (multipleFiles == true)
            { hfd_mult.Value = "multiple"; }
            else { hfd_mult.Value = ""; }
        }
    }

    /// <summary>
    /// Permet d'avoir un thumb sur les images
    /// </summary>
    bool thumbImage = false;
    public bool ThumbImage
    {
        get
        {
            return thumbImage;
        }

        set
        {
            thumbImage = value;
            hfd_thumb.Value = thumbImage.ToString().ToLower();
        }
    }

    /// <summary>
    /// Permet de filtrer, par type, l'affichage des fichiers contenus dans le répertoire
    /// A séparer par une vigule et sans espace
    /// </summary>
    string typeFilter = "";
    public string TypeFilter
    {
        get
        {
            return typeFilter;
        }

        set
        {
            typeFilter = value;
            hfd_typeFilter.Value = typeFilter;
        }
    }

    /// <summary>
    /// /// Permet de filtrer, par extension, l'affichage des fichiers contenus dans le répertoire
    /// A séparer par une vigule et sans espace
    /// </summary>
    string extFilter = "";
    public string ExtFilter
    {
        get
        {
            return extFilter;
        }

        set
        {
            extFilter = value;
            hfd_extFilter.Value = extFilter;
        }
    }

    /// <summary>
    /// Permet d'appliquer un filtre lors de la sélection des fichiers à uploader
    /// Example : audio/*,video/*,image/*, .gif, .jpg, .png, .doc
    /// </summary>
    string extAuthorised = "";
    public string ExtAuthorised
    {
        get
        {
            return extAuthorised;
        }

        set
        {
            extAuthorised = value;
            hfd_extAuthorised.Value = extAuthorised;
        }
    }

    /// <summary>
    /// Permet de n'avoir que le visu d'un répertoire
    /// </summary>
    bool readOnly = false;
    public bool ReadOnly
    {
        get
        {
            return readOnly;
        }

        set
        {
            readOnly = value;
            hfd_readOnly.Value = readOnly.ToString().ToLower();
        }
    }

    /// <summary>
    /// Permet de n'avoir que le visu d'un répertoire et cache ainsi le label du nom du fichier
    /// </summary>
    bool nameHide = false;
    public bool NameHide
    {
        get
        {
            return nameHide;
        }

        set
        {
            nameHide = value;
            hfd_nameHide.Value = nameHide.ToString().ToLower();
        }
    }

    /// <summary>
    /// Permet d'appliquer une CSS au bouton supprimé
    /// </summary>
    string cssBtnDelete = "";
    public string CssBtnDelete
    {
        get
        {
            return cssBtnDelete;
        }

        set
        {
            cssBtnDelete = value;
            hfd_cssBtnDelete.Value = cssBtnDelete;
        }
    }

    /// <summary>
    /// Permet d'appliquer une CSS au lien du fichier
    /// </summary>
    string cssLink = "";
    public string CssLink
    {
        get
        {
            return cssLink;
        }

        set
        {
            cssLink = value;
            hfd_cssLink.Value = cssLink;
        }
    }

    /// <summary>
    /// Permet d'appliquer une CSS au ThumbImage
    /// </summary>
    string cssThumbImage = "";
    public string CssThumbImage
    {
        get
        {
            return cssThumbImage;
        }

        set
        {
            cssThumbImage = value;
            hfd_cssThumbImage.Value = cssThumbImage;
        }
    }

    /// <summary>
    /// Permet de définir une largeur au ThumbImage
    /// </summary>
    string widthThumbImage = "100";
    public string WidthThumbImage
    {
        get
        {
            return widthThumbImage;
        }

        set
        {
            widthThumbImage = value;
            if (string.IsNullOrEmpty(widthThumbImage)) { widthThumbImage = "100"; }
            hfd_widthThumbImage.Value = widthThumbImage;
        }
    }

    /// <summary>
    /// Permet de définir une hauteur au ThumbImage
    /// </summary>
    string heightThumbImage = "100";
    public string HeightThumbImage
    {
        get
        {
            return heightThumbImage;
        }

        set
        {
            heightThumbImage = value;
            hfd_heightThumbImage.Value = heightThumbImage;
        }
    }

    /// <summary>
    /// Permet de définir une CSS au UL
    /// </summary>
    string cssUL = "";
    public string CssUL
    {
        get
        {
            return cssUL;
        }

        set
        {
            cssUL = value;
            hfd_cssUL.Value = cssUL;
        }
    }

    /// <summary>
    /// Permet de définir une CSS au LI
    /// </summary>
    string cssLI = "";
    public string CssLI    {
        get
        {
            return cssLI;
        }

        set
        {
            cssLI = value;
            hfd_cssLI.Value = cssLI;
        }
    }

    /// <summary>
    /// Permet de définir le texte du bouton de sélection de fichier
    /// </summary>
    string txt_Button = "";
    public string Txt_Button
    {
        get
        {
            return txt_Button;
        }

        set
        {
            txt_Button = value;
            hfd_txt_Button.Value = txt_Button;
        }
    }

    /// <summary>
    /// Permet de rafraichir la page parent
    /// </summary>
    string url_Refresh = "";
    public string Url_Refresh
    {
        get
        {
            return url_Refresh;
        }

        set
        {
            url_Refresh = value;
            hfd_url_Refresh.Value = url_Refresh;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void DisplayVisible(bool visible)
    {
        try
        {            
            pnl_Control.Visible = visible;            
        }
        catch(Exception ee)
        {

        }
    }
}