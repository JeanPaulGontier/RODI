<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Settings.ascx.cs" Inherits="DesktopModules_AIS_News_Visu_Settings" %>
<div class="dnnFormItem">
        <div class="dnnLabel"><asp:Label runat="server" Text="Document PDF :"></asp:Label></div>
        <asp:TextBox ID="TXT_Document" runat="server" MaxLength="1024" Width="100%"></asp:TextBox>
        <div class="alert alert-info">
            <ul>
                <li>
                    Spéficier le chemin du fichier par rapport à la racine du site, exemple : /Portals/0/Documents/mondoc.pdf
                </li>
                <li>
                    Si le fichier est dans un dossier protégé ajouter .resources à la fin.
                </li>
                <li>
                    ATTENTION : ne pas utiliser l'url linkclick du fichier mais son vrai chemin !
                </li>
                <li>
                    Les images sont regénérées à chaque fois qu'on entre dans le panneau de paramètres
                </li>
            </ul>
        </div>
</div>
<div class="dnnFormItem">
        <div class="dnnLabel"><asp:Label runat="server" Text="Largeur image en pixels :"></asp:Label></div>
        <asp:TextBox ID="TXT_Width" runat="server" MaxLength="4" Width="10%"></asp:TextBox>
        <div class="alert alert-info">Le flipbook va prendre 2 fois la largeur de l'image afin d'afficher 2 pages</div>
</div>
<div class="dnnFormItem">
        <div class="dnnLabel"><asp:Label runat="server" Text="Hauteur image en pixels :"></asp:Label></div>
        <asp:TextBox ID="TXT_Height" runat="server" MaxLength="4" Width="10%"></asp:TextBox>
</div>
