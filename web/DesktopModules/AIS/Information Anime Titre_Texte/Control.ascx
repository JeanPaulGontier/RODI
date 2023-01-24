<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Control.ascx.cs" Inherits="DesktopModules_AIS_Information_Anime_Titre_Texte_Control" %>

<div class="cool_box">
   
        <asp:Panel runat="server" ID="pnl_Anim" >
            <div class="cool_hover text-center">
                
                    <Label runat="server" id="lbl_Icon" ></Label>
                
            </div>
            <div class="cool_content">
                
                <h3>
                    <asp:Label runat="server" ID="lbl_Title" />
                </h3>

                <div class="pe-spacer size20"></div>
                <div class="cool_border"></div>
                <div class="pe-spacer size20"></div>
                <div>
                    <asp:Literal runat="server" ID="lbl_Text" />
                </div>
            </div>
        </asp:Panel>
   
    

    <asp:Panel ID="pnl_Modify" runat="server" Visible="false">
    <br />
    <asp:Button ID="btn_Modify" runat="server" Text="Modifier" CssClass="btn btn-warning" OnClick="btn_Modify_Click" />
</asp:Panel>

    
</div>



