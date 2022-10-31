<%@ Control Language="C#" AutoEventWireup="true" CodeFile="People.ascx.cs" Inherits="AIS.Ticketing_People" %>
<h3><asp:Label runat="server"  ID="L_Name"/></h3>
<asp:HiddenField runat="server" ID="H_GUID" />

<div class="form-group">
    <asp:Label runat="server" Text="Prénom :" CssClass="control-label col-sm-3"></asp:Label>
    <div class="col-sm-9">
        <asp:TextBox runat="server" ID="TXT_Firstname" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="TXT_Firstname" Text="Veuillez compléter" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>                    
    </div>
</div>
<div class="form-group">
    <asp:Label runat="server" Text="Nom :" CssClass="control-label col-sm-3"></asp:Label>
    <div class="col-sm-9">
        <asp:TextBox runat="server" ID="TXT_Lastname" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="TXT_Lastname" Text="Veuillez compléter" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>                                        
    </div>
</div>
<div class="form-group">
    <asp:Label runat="server" Text="Mél : " CssClass="control-label col-sm-3"></asp:Label>
    <div class="col-sm-9">
        <asp:TextBox runat="server" ID="TXT_Email" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="TXT_Email" Text="Veuillez compléter" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
    </div>
</div>
<asp:Panel CssClass="form-group" runat="server" ID="P_Fields">

</asp:Panel>