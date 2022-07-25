<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="AIS_Contact" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>    
</head>
<body>
    <form id="form1" runat="server">

<table>
    <tr>
        <td style="vertical-align:top">
            <asp:Panel runat="server" ID="P1">
                <table style="width:400px;">
                    <tr>
                        <td>
            <asp:HiddenField runat="server" ID="HF_id" />
                <asp:Label ID="Label1" Width="120" runat="server" Text="Pour contacter :"></asp:Label></td>
                        <td>
                <asp:Label ID="TXT_membre" runat="server" Text="..."></asp:Label>    
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="Label3" runat="server" Text="Veuillez saisir les informations suivantes :"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>    
                            <asp:Label ID="Label4" Width="120" runat="server" Text="Nom &amp; Prénom :"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="TXT_Nom" runat="server" MaxLength="50" Width="280" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="TXT_Nom" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align:top">    
                            <asp:Label ID="Label5" runat="server" Width="120" Text="Email :"></asp:Label>
                        </td>
                        <td style="text-align: left; vertical-align:top">
                            <asp:TextBox ID="TXT_Email" runat="server" MaxLength="255" Width="280"  style="text-align: left"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="TXT_Email" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TXT_Email" ErrorMessage="<br/>Saisir un email valide (ex: nom@domaine.com)" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">    
                            <asp:Label ID="Label6" runat="server" Text="Message :">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="TXT_Message" Display="Dynamic"></asp:RequiredFieldValidator></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" >
                            <asp:TextBox ID="TXT_Message" runat="server" MaxLength="255" Width="402" TextMode="MultiLine"  Height="100px"></asp:TextBox>
                        </td>
                
                    </tr>
                    <tr>
                        <td style="text-align: right" colspan="2">
                            <asp:Button ID="BT_Envoyer" runat="server" Text="Envoyer" OnClick="BT_Envoyer_Click" />
                        </td>
                    </tr>
                </table>    
            </asp:Panel>
        </td>
    
        <td id="td_Coord" runat="server" visible="false" style="vertical-align:top;">
            <asp:Panel runat="server" ID="Pnl_Coord" Visible="false"  Style="margin-left: 20px;">
                
            </asp:Panel>
        </td>
    </tr>
</table>

    <asp:Panel runat="server" ID="P2" Visible="false">
        Votre message a bien été envoyé...
    </asp:Panel>
    </form>
</body>
</html>
