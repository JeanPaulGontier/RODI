<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DonStripe.aspx.cs" Inherits="AIS_DonStripe" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:UpdatePanel>
            <asp:Panel ID="pnl_paiement" runat="server">
                <div>
                <span>Veuillez saisir le montant du don que vous souhaitez faire : </span>
                <asp:TextBox runat="server" ID="TXT_Amount" AutoPostBack="True" OnTextChanged="TXT_Changed"   />
                <span>Euros</span>
                </div>
                <div>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                    ControlToValidate="TXT_Amount" runat="server"
                    ErrorMessage="Veuillez saisir un montant sans virgule, ni point, ni espace"
                    ValidationExpression="\d+" ForeColor="Red">
                </asp:RegularExpressionValidator>
                </div>
                <div>
                    <asp:Literal runat="server" ID="L_Script"></asp:Literal>
                </div>
            </asp:Panel>

            <asp:Panel ID="pnl_paiementOK" runat="server" Visible="false">
                <asp:Label ID="lbl_paiementok" Text="Merci, votre don a été accepté" runat="server" />
            </asp:Panel>
        </asp:UpdatePanel>
    </form>
</body>
</html>
