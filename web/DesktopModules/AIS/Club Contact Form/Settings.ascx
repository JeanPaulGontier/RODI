<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Settings.ascx.cs" Inherits="DesktopModules_BBPEnregistrement_Settings" %>
<%--<p>
<asp:Label ID="Label2" runat="server" Text="Catégorie :"></asp:Label>
<asp:DropDownList ID="TabCategorie" runat="server" DataSourceID="SqlDataSource1" DataTextField="nom" DataValueField="id">
</asp:DropDownList>    
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SiteSqlServer %>" SelectCommand="SELECT  [id] ,[nom]  FROM [bbp_categories]"></asp:SqlDataSource>
</p>
<p>
<asp:Label ID="Label1" runat="server" Text="TAB ID page redirection après sélection :"></asp:Label>
<asp:DropDownList ID="TabID" runat="server">
</asp:DropDownList>
</p>

<asp:Panel ID="pnl_1" runat="server">
    <asp:HiddenField ID="hfd_mail" runat="server" />
    <asp:HiddenField ID="hfd_sujet" runat="server" />
    <asp:HiddenField ID="hfd_message" runat="server" />

    <table>
        <tr>        
            <td>
                <asp:Label ID="lbl_mail" runat="server" Text="Email" />
             </td>
            <td>
                <asp:TextBox ID="tbx_mail" runat="server" Width="250" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" ControlToValidate="tbx_mail" Width="20px"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tbx_mail" ErrorMessage="Saisir un email valide (ex: nom@domaine.com)" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
	</tr>

    <tr>
    
        <td>
            <asp:Label ID="lbl_sujet" runat="server" Text="Sujet"/>
        </td>
        <td>
            <asp:TextBox ID="tbx_sujet" runat="server"  Width="250"/>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*" ControlToValidate="tbx_sujet"></asp:RequiredFieldValidator>
        </td>
	</tr>
</table>
        
<table>
    <tr>
        <td>
            
                <asp:Label ID="lbl_message" runat="server" Text="Message : (ATTENTION : mettre #URL# dans le message pour que le lien vers la page soit inséré automatiquement.)"/>
        </td>
    </tr>

    <tr>
        <td>
            <asp:TextBox ID="tbx_message" runat="server" TextMode="multiline" Width="600" Height="200" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*" ControlToValidate="tbx_message"></asp:RequiredFieldValidator>
        </td>
    </tr>
</table>

</asp:Panel>--%>
