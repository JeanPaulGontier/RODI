<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Control.ascx.cs" Inherits="DesktopModules_AIS_OuKiKan_Control" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.Client.ClientResourceManagement" Assembly="DotNetNuke.Web.Client" %>
<% 
    string libPath = TabController.CurrentPage.SkinPath + "echoppe/";
    string appID = "app" + ModuleId;

    if (AIS.Functions.CurrentCric > 0)
    {
        if (editable)
        { 
            
%>
<asp:HiddenField ID="ContextGuid" runat="server" />
<script src="<%=libPath %>tinymce/tinymce.min.js"></script>
<script src="<%=libPath %>vue/3.2.23/vue.js"></script>
<script src="<%=libPath %>vue-router/4.0.12/vue-router.js"></script>
<script src="<%=libPath %>axios/0.24.0/axios.min.js"></script>
<script src="<%=libPath %>toastr/toastr.min.js"></script>
<link href="<%=libPath %>toastr/toastr.min.css" rel="stylesheet" />
<script src="<%=libPath %>vue-easy-tinymce-1.0.2/dist/vue-easy-tinymce.min.js"></script>
<!-- #include virtual ="/DesktopModules/RazorModules/RazorHost/Scripts/BlocksContent/BlockFileCollection.cshtml" -->
<!-- #include virtual ="/DesktopModules/RazorModules/RazorHost/Scripts/BlocksContent/BlockImageCollection.cshtml" -->
<!-- #include virtual ="/DesktopModules/RazorModules/RazorHost/Scripts/BlocksContent/BlockImageText.cshtml" -->
<!-- #include virtual ="/DesktopModules/RazorModules/RazorHost/Scripts/BlocksContent/BlockRaw.cshtml" -->
<!-- #include virtual ="/DesktopModules/RazorModules/RazorHost/Scripts/BlocksContent/BlockVideo.cshtml" -->
<!-- #include virtual ="/DesktopModules/RazorModules/RazorHost/Scripts/BlocksContent/BlockEditor.cshtml" -->
<link href="/DesktopModules/RazorModules/RazorHost/Scripts/BlocksContent/styles.css" rel="stylesheet" />
<link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css" rel="stylesheet">
<%--<link href="/desktopmodules/ais/oukikan/styles.css" rel="stylesheet" />--%>
<style>
    [v-cloak] {
        display: none;
    }
</style>
<div id='<%=appID %>' v-cloak>
     <router-view :moduleid="moduleid" :context="context" :editable="editable"></router-view> 
</div>
<script src="/DesktopModules/Yemon/API/Services/VueJS"></script>
<!-- #include virtual ="/DesktopModules/AIS/OuKiKan/Meetings.html" -->
<!-- #include virtual ="/DesktopModules/AIS/OuKiKan/MeetingEdit.html" -->
<script src="/DesktopModules/AIS/OuKiKan/app.js"></script>
<script>
    $(document).ready(function () {
        if (typeof _yemon == 'undefined')
            _yemon = [];
        _yemon[<%=ModuleId%>] = new Yemon(<%=ModuleId%>, '/Desktopmodules/AIS/API/Meeting');
        InitApp('<%=appID %>',<%=ModuleId%>, '<%=context%>',<%=cric%>, '<%=mode%>',<%=editable.ToString().ToLower()%>);
    });
</script>
<% }
    else
    {
%>
    <h1>Liste des réunions en cours</h1>
<%
        List<Meeting> meetings = Yemon.dnn.DataMapping.ExecSql<Meeting>(new SqlCommand("SELECT * FROM ais_meetings WHERE cric="+cric+" AND active='O' AND type='unitary' ORDER BY dtstart DESC"));
        if (meetings.Count == 0)
        {
%>
    <div class="meeting">
        

        <div class="pe-spacer size20"></div>
        <div v-if="meetings.length==0">
            Aucune réunion pour le moment...
        </div>
    </div>
<%
        }
        else
        {
%>
    <table class="table table-striped table-hover">
        <tbody>
            <tr>
                <th>Date</th>
                <th style="width:60%">Nom</th>
                <th>Lien inscription</th>
                <th>Nb Participants</th>
                <!--<th></th>-->
            </tr>
<%
            foreach (Meeting m in meetings)
            {
%>
        <tr class="trLink">
            <td>           
                <div>
<%              if (m.dtstart.ToShortDateString() != m.dtend.ToShortDateString())
    {
%>
                    du <%=m.dtstart.ToShortDateString() %> - <%=m.dtstart.ToString("HH:mm") %> <br />
                    au <%=m.dtend.ToShortDateString() %> - <%=m.dtend.ToString("HH:mm") %>
                
<%              }
                else
                { 
%>
                    le <%=m.dtstart.ToShortDateString() %><br /><small>de <%=m.dtstart.ToString("HH:mm") %> à <%=m.dtend.ToString("HH:mm") %></small>
                
<%              }         
%>
                </div>
            </td>
                            
            <td><span><%=m.name%></span></td>
            <td><a href="/m-<%=m.link%>" target="_blank">/<%=m.link%></a></td>
            <td><%=m.nbusers%></td>

        </tr>
<%
            }
%>

        </tbody>
    </table>
<%        } %>
<%  } %>
<% }
    else
{ %>
        <div>
            Veuillez choisir un club...
        </div>
<% } %>