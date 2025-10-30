
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Control.ascx.cs" Inherits="DesktopModules_Control_View" %>
<script src="/Portals/_default/Skins/Rodi2017/bootstrap/js/bootstrap.js" type="text/javascript"></script>
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

                 <script>
                    function print() {
                        document.getElementById('printIframe').src = '/print?popup=true&url=<%=HttpUtility.UrlEncode(Request.RawUrl)%>';
                    }
                 </script>
                   <a href="#" onclick="print()" class="btn btn-link" title="Imprimer"><i class="fa fa-print"></i> Imprimer</a>

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
                    <img src="<%=m.Image %>"  style="height:180px" />
                </div>
                <div style='padding: 2px 0'><strong><%=m.Nom %></strong></div>
                <% if (m.Affectation != "")
                { %>
                <div style='padding: 2px 0'><%=m.Affectation %></div>
                <%} %>
                 <div style='padding: 2px 0; text-overflow: ellipsis; overflow-wrap: break-word; font-size: 0.8rem;'><strong><em><%=m.Profession %></em></strong></div>
                <div style='padding: 2px 0; text-overflow: ellipsis; overflow-wrap: break-word; font-size: 0.7rem'><em><%=m.Email %> <%=m.Telephones %></em></div>
                <%if (!String.IsNullOrEmpty(m.Anniversaire)) { %>
                <div style='padding: 2px 0; text-overflow: ellipsis; overflow-wrap: break-word; font-size: 0.7rem;'><img src='<%= PortalSettings.ActiveTab.SkinPath +"images/birthday.png"%>' style="filter: grayscale(1)" width="16" title="Anniversaise le <%=m.Anniversaire %>" /><em> <%=m.Anniversaire %></em></div>               
                <% } %>
                  <%if ((Request["popup"] + "") != "") { }
                    else
                    { %>
                <div style='padding: 2px 0'><a href="<%=m.Lien %>"><%=m.LienLabel %></a></div>
                <%} %>
            </td>

            <% } %>
        </tr>
        <%--<tr>
            <td colspan="4" style="text-align:center">
                <small><em><i class="glyphicon glyphicon-phone-alt"></i> Professionnel <i class="glyphicon glyphicon-earphone"></i> Mobile <i class="glyphicon glyphicon-home"></i> Personnel</em></small>
            </td>
        </tr>--%>
    </table>



    <div class="pe-spacer size20" style="display: none;"></div>
    <div class="row text-center"  style="display: none; flex-wrap:wrap;">  
        
        <asp:Repeater ID="dataList_Members" runat="server"  OnItemDataBound="dataList_Members_ItemDataBound">
            <ItemTemplate>
                <% index++; %>
                <%if ((index % 16)==0) { %>
                <div>break</div>
                
                <% } %>
 
                <div style='margin: 10px; width: 160px; height: auto; page-break-before: auto'>
                               
                        <div style='padding:2px 0'><asp:Image ID="Image1" runat="server" Width="120"  /></div>
                        <div style='padding:2px 0'><strong><asp:Label ID="LBL_Nom" runat="server"></asp:Label></strong></div>
                        <div style='padding:2px 0'><asp:Label ID="LBL_Affectation" runat="server"></asp:Label></div>
                        <div style='padding: 2px 0; text-overflow: ellipsis; overflow-wrap: break-word;font-size:0.7rem'><em><asp:Literal ID="LBL_Coordonnees" runat="server"></asp:Literal></em></div>
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

<iframe id="printIframe" style="display:none"></iframe>