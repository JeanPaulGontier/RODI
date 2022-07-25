
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Control.ascx.cs" Inherits="DesktopModules_Control_View" %>
<asp:Panel runat="server" ID="P_Club">
    Veuillez choisir un club ...
</asp:Panel>
<asp:Panel runat="server" ID="P_Members" class="panel panel-body" >
    <div class="pe-spacer size20"></div>
    <div class="row text-center"  style="display: flex; flex-wrap:wrap;">  
        <asp:Repeater ID="dataList_Members" runat="server"  OnItemDataBound="dataList_Members_ItemDataBound">
            <ItemTemplate>
                    <div style='margin: 15px;width:220px;'>
                               
                        <div style='padding:2px 0'><asp:Image ID="Image1" runat="server"  /></div>
                        <div style='padding:2px 0'><strong><asp:Label ID="LBL_Nom" runat="server"></asp:Label></strong></div>
                        <div style='padding:2px 0'><asp:Label ID="LBL_Affectation" runat="server"></asp:Label></div>
                        <div style='padding:2px 0; text-overflow:ellipsis;'><em><asp:Label ID="LBL_Coordonnees" runat="server"></asp:Label></em></div>
                        <div style='padding:2px 0'><asp:HyperLink ID="HL_Contact" runat="server">Le contacter</asp:HyperLink></div>
                               
	                </div>
             </ItemTemplate> 
        </asp:Repeater>
    </div>
</asp:Panel>
