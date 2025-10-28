<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Settings.ascx.cs" Inherits="DesktopModules_AIS_News_Visu_Settings" %>
<div class="dnnFormItem">   
    <div class="dnnLabel">
        <span>Type d'affichage :</span>
    </div>
    <asp:RadioButtonList runat="server" ID="RB_type" RepeatDirection="Horizontal" Width="50%">
        <asp:ListItem Text="Flipbook" Value="flipbook"></asp:ListItem>
        <asp:ListItem Text="Liste d'images" Value="images"></asp:ListItem>
    </asp:RadioButtonList>

    
</div>
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
            </ul>
        </div>
</div>
<div class="dnnFormItem">
        <div class="dnnLabel"><asp:Label runat="server" Text="Largeur image en pixels :"></asp:Label></div>
        <asp:TextBox ID="TXT_Width" runat="server" MaxLength="4" Width="10%"></asp:TextBox>
        <div class="alert alert-info">Le flipbook va prendre 2 fois la largeur de l'image afin d'afficher 2 pages</div>
</div>
<div class="dnnFormItem">
        <div class="dnnLabel"><asp:Label runat="server" Text="Hauteur image en pixels (laisser 0 pour liste d'images) :"></asp:Label></div>
        <asp:TextBox ID="TXT_Height" runat="server" MaxLength="4" Width="10%"></asp:TextBox>
</div>


<div>
    <asp:Button runat="server" ID="BT_generate" Text="Générer les images à partir du pdf" CssClass="btn btn-primary" OnClick="BT_generate_Click" />
    <asp:Panel runat="server" ID="P_result" Visible="false" CssClass="alert alert-success">Génération terminée</asp:Panel>
    <asp:Panel runat="server" ID="P_error" Visible="false" CssClass="alert alert-danger"><asp:Literal runat="server" ID="L_error"></asp:Literal></asp:Panel>
</div>