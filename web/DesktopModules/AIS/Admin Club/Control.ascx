<!--**********************************************************************************-->
<!-- RODI - https://rodi-platform.org                                                 -->
<!-- Copyright (c) 2012-2016                                                          -->
<!-- by SAS AIS : https://www.aisdev.net                                              -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Control.ascx.cs" Inherits="DesktopModules_AIS_Admin_Club" %>
<script src="/AIS/TextEditor/ckeditor/ckeditor.js"></script>

<asp:Panel ID="pnl_edit" runat="server" Visible="false">

    <div class="row">
        <div class="col-sm-4">
            <strong>Type club :</strong>
        </div>
        <div class="col-sm-8">
            <asp:RadioButtonList runat="server" ID="RB_Type_Club" RepeatDirection="Horizontal" Enabled="false">
                <asp:ListItem Text="Rotary" Value="rotary"></asp:ListItem>
                <asp:ListItem Text="Rotaract" Value="rotaract"></asp:ListItem>
                <asp:ListItem Text="Interact" Value="interact"></asp:ListItem>
            </asp:RadioButtonList>
        </div>
    </div>

    <div class="row">
        <div class="col-sm-4">
            <strong>CRIC :</strong>
        </div>
        <div class="col-sm-8">
            <asp:HiddenField ID="hf_last_cric" runat="server" />
            <asp:TextBox ID="hfd_cric" Width="500" runat="server" Enabled="false"> </asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="hfd_cric" Text="Veuillez compléter" ForeColor="Red" Display="Dynamic">*</asp:RequiredFieldValidator>
        </div>
    </div>

    <div class="row">
        <div class="col-sm-4">
            <strong>Nom du club :</strong>
        </div>
        <div class="col-sm-8">
            <asp:TextBox ID="tbx_name" Width="500" runat="server" Enabled="false"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="tbx_name" Text="Veuillez compléter" ForeColor="Red" Display="Dynamic">*</asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <strong>SEO :</strong>
        </div>
        <div class="col-sm-8">
            <asp:TextBox ID="tbx_seo" Width="500" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="tbx_name" Text="Veuillez compléter" ForeColor="Red" Display="Dynamic">*</asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <strong>Adresse 1 :</strong>
        </div>
        <div class="col-sm-8">
            <asp:TextBox ID="tbx_adr1" Width="500" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <strong>Adresse 2 :</strong>
        </div>
        <div class="col-sm-8">
            <asp:TextBox ID="tbx_adr2" Width="500" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <strong>Adresse 3 :</strong>
        </div>
        <div class="col-sm-8">
            <asp:TextBox ID="tbx_adr3" Width="500" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <strong>Code postal : </strong>
        </div>
        <div class="col-sm-8">
            <asp:TextBox ID="tbx_zip" Width="500" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <strong>Ville : </strong>
        </div>
        <div class="col-sm-8">
            <asp:TextBox ID="tbx_town" Width="500" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <strong>Fanion : </strong>
        </div>
        <div class="col-sm-8">
            <asp:HiddenField ID="hfd_filename" runat="server" />
            <asp:Image ID="img_fanion" runat="server" />
            <asp:FileUpload ID="ful_img" runat="server" />
            <asp:Button ID="btn_img" runat="server" OnClick="btn_img_Click" Text="Modifier le fanion" CssClass="btn btn-primary" />
        </div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <strong>Réunions : </strong>
        </div>
        <div class="col-sm-8">
            <asp:TextBox ID="tbx_meetings" TextMode="MultiLine" Width="500" Height="300" runat="server"></asp:TextBox>
        </div>
        <script> CKEDITOR.replace('<%=tbx_meetings.ClientID%>', {
            uiColor: '#CCEAEE'
        });  </script>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <strong>Téléphone : </strong>
        </div>
        <div class="col-sm-8">
            <asp:TextBox ID="tbx_tel" Width="500" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <strong>Fax : </strong>
        </div>
        <div class="col-sm-8">
            <asp:TextBox ID="tbx_fax" Width="500" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <strong>Email : </strong>
        </div>
        <div class="col-sm-8">
            <asp:TextBox ID="tbx_email" Width="500" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <strong>Site web : </strong>
            <em>(incluant https://)</em>
        </div>
        <div class="col-sm-8">
            <asp:TextBox ID="tbx_web" Width="500" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <strong>Présentation du club :</strong>
        </div>
        <div class="col-sm-8">
            <asp:RadioButtonList runat="server" ID="SEO_MODE" RepeatDirection="Horizontal">
                <asp:ListItem Text="Carte de visite" Value=""></asp:ListItem>
                <asp:ListItem Text="Site" Value="m"></asp:ListItem>
                <asp:ListItem Text="Site avec domaine" Value="d"></asp:ListItem>
            </asp:RadioButtonList>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <strong>Nom de domaine site :</strong>
        </div>
        <div class="col-sm-8">
            <asp:TextBox ID="tbx_domaine" Width="500" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <strong>Texte de présentation : </strong>
        </div>
        <div class="col-sm-8">
            <asp:TextBox ID="tbx_text" TextMode="MultiLine" Width="500" Height="300" runat="server"></asp:TextBox>
        </div>
        <script> CKEDITOR.replace('<%=tbx_text.ClientID%>', {
            uiColor: '#CCEAEE'
        });  </script>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <strong>Adresse de réunion 1 : </strong>
        </div>
        <div class="col-sm-8">
            <asp:TextBox ID="tbx_meetAdr1" Width="500" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <strong>Adresse de réunion 2 : </strong>
        </div>
        <div class="col-sm-8">
            <asp:TextBox ID="tbx_meetAdr2" Width="500" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <strong>Ville de réunion : </strong>
        </div>
        <div class="col-sm-8">
            <asp:TextBox ID="tbx_meetTown" Width="500" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <strong>Code postal de réunion : </strong>
        </div>
        <div class="col-sm-8">
            <asp:TextBox ID="tbx_meetZip" Width="500" runat="server"></asp:TextBox>
        </div>
    </div>

    <asp:Button ID="btn_validate" runat="server" Text="Valider" CssClass="btn btn-primary" OnClick="btn_validate_Click" />    

</asp:Panel>
<asp:Label ID="lbl_choisirClub" runat="server" Text="Choisissez un club" />

