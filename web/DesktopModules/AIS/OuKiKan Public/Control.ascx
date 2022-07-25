<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Control.ascx.cs" Inherits="DesktopModules_AIS_OuKiKan_Control" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.Client.ClientResourceManagement" Assembly="DotNetNuke.Web.Client" %>
<dnn:dnnjsinclude id="VueJS" runat="server" filepath="/desktopmodules/ais/oukikan public/js/vue.3.2.31/vue.js" />
<dnn:dnnjsinclude id="VueJSAxios" runat="server" filepath="/desktopmodules/ais/oukikan public/js/axios/axios.js" />
<dnn:dnnjsinclude id="VueJSRouter" runat="server" filepath="/desktopmodules/ais/oukikan public/js/router.4.0.13/Router.js" />
<link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css" rel="stylesheet">

<div  id="AppPane<%=this.ModuleId %>" style="display: none">

    <!--VIEW MEETING -->
    <div id="viewMeeting" v-if="viewMeeting">

      <div class="meeting">
        <h1>{{ currentMeeting.name }} - {{ currentMeeting.lieu }}</h1>
        <div class="meetingDescription"><pre>{{ currentMeeting.description }}</pre></div>
            
          <div v-if="currentMeeting.videoConfLink" class="alert">Pour suivre la réunion en visio voici le lien : <a :href="currentMeeting.videoConfLink">{{currentMeeting.videoConfLink}}</a></div>
        

        <table id="meetingTable" class="table table-striped" v-if="users.length>0">
          <tr>
            <th>NOM</th>
            <th>PRENOM</th>
            <th v-for="(opt, index2) in currentMeeting.options" :key="index2">Option {{index2+1}}</th>

          </tr>
          <tr>
            <td></td>
            <td></td>
            <td  v-for="(option, index3) in currentMeeting.options" :key="index3">
              {{option.date}}<br> {{option.heure}}<br> </td>
          </tr>
          <tr v-for="(user, index4) in users" :key="index4">
            <td>
                <input type="text" v-model="user.name" ref="meetingUser"  placeholder="Nom" @change="saveUser(user)" v-if="token==user.token">
                <span v-if="token!=user.token">{{user.name}}</span>
            </td>
            <td>
                <input type="text" v-model="user.surname"  placeholder="Prénom"  @change="saveUser(user)" v-if="token==user.token">
                <span v-if="token!=user.token">{{user.surname}}</span>
            </td>
            <td v-for="(meetingoption, index5) in currentMeeting.options" :key="index5">
              <label>
                <input type="checkbox" :value="meetingoption.Guid" v-model="user.options" @change="saveUser(user)" v-if="token==user.token">
                <input type="checkbox" :value="meetingoption.Guid" v-model="user.options" @change="saveUser(user)" v-if="token!=user.token" disabled>
                <span class="checkmark"></span>
              </label>
            </td>
          </tr>
        </table>
        <button type="button" @click="addNewUser()" class="btn btn-primary">Ajouter un participant</button>
      </div>
    </div>

</div>

<dnn:DnnJsInclude ID="appJS" runat="server"  />
<script>
    window.onload = InitVue(<%=this.ModuleId%>,'<%=GUID%>');
</script>