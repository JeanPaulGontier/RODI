
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Control.ascx.cs" Inherits="DesktopModules_Control_View" %>
<asp:Panel runat="server" ID="P_Club">
    Veuillez choisir un club ...
</asp:Panel>
<asp:Panel runat="server" ID="P_Members" class="panel panel-body">

    <table>
        <tr>
            <td colspan="3">
                <h1>Trombinoscope <%= clubname %></h1>
            </td>
            <td style="text-align:right">
                <%if ((Request["popup"] + "") != "") { }
                    else
                    { %>
                <a href="/print?popup=true&url=<%= HttpUtility.UrlEncode(Request.RawUrl) %>" target="_blank" class="fa fa-print" title="Imprimer"></a>
                <%} %>
            </td>
        </tr>
        <tr>
            <% 
            index = 0;
            foreach (Me m in MemberList())
            {                
                if((index % 4)==0)
                {
                    Response.Write("</tr><tr>");
                }
                 index++;

            %>
            <td style="width:25%;padding: 15px; text-align: center; vertical-align: top">
                <div style='padding: 2px 0'>
                    <img src="<%=m.Image %>" width="100%" />
                </div>
                <div style='padding: 2px 0'><strong><%=m.Nom %></strong></div>
                <% if (m.Affectation != "")
                { %>
                <div style='padding: 2px 0'><%=m.Affectation %></div>
                <%} %>
                <div style='padding: 2px 0; text-overflow: ellipsis; overflow-wrap: break-word; font-size: 0.7rem'><em><%=m.Email %></em></div>
                <%if ((Request["popup"] + "") != "") { }
                    else
                    { %>
                <div style='padding: 2px 0'><a href="<%=m.Lien %>"><%=m.LienLabel %></a></div>
                <%} %>
            </td>

            <% } %>
        </tr>
    </table>



    <div class="pe-spacer size20" style="display: none;"></div>
    <div class="row text-center"  style="display: none; flex-wrap:wrap;">  
        
        <asp:Repeater ID="dataList_Members" runat="server"  OnItemDataBound="dataList_Members_ItemDataBound">
            <ItemTemplate>
                <% index++; %>
                <%if ((index % 16)==0) { %>
                <div>break</div>
                
                <% } %>
 
                <div style='margin: 10px; width: 160px; height: 230px; page-break-before: auto'>
                               
                        <div style='padding:2px 0'><asp:Image ID="Image1" runat="server" Width="120"  /></div>
                        <div style='padding:2px 0'><strong><asp:Label ID="LBL_Nom" runat="server"></asp:Label></strong></div>
                        <div style='padding:2px 0'><asp:Label ID="LBL_Affectation" runat="server"></asp:Label></div>
                        <div style='padding: 2px 0; text-overflow: ellipsis; overflow-wrap: break-word;font-size:0.7rem'><em><asp:Label ID="LBL_Coordonnees" runat="server"></asp:Label></em></div>
                        <%if ((Request["popup"] + "") != "") { }
                        else
                        { %>
                        <div style='padding:2px 0'><asp:HyperLink ID="HL_Contact" runat="server">Le contacter</asp:HyperLink></div>
                        <%} %>
                      
                    </div>
                 
             </ItemTemplate>            
        </asp:Repeater>
    </div>

</asp:Panel>

