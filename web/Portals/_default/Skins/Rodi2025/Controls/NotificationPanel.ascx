<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NotificationPanel.ascx.cs" Inherits="NotificationPanel" %>
 <%

     string libPath = TabController.CurrentPage.SkinPath + "echoppe/";
     string appPath = TabController.CurrentPage.SkinPath+"controls/notification/app.js?cdv="+Yemon.dnn.Functions.CDV;
     
 %>
<script src="<%=libPath %>vue/3.2.23/vue.js?cdv=<%=Yemon.dnn.Functions.CDV %>"></script>
<script src="<%=libPath %>axios/0.24.0/axios.min.js?cdv=<%=Yemon.dnn.Functions.CDV %>"></script>

 <%if (Request.IsAuthenticated) {%>
    

        <!-- Notifications -->
        <div id="<%=ID %>" class="card-membre card-notif" style="display:none">
          <div class="row-fluid">
            <strong class="lead flex-grow">Notifications</strong>
            <a v-on:click="close" title="Fermer" class="close-link"><i class="fa-regular fa-circle-xmark fa-xl"></i></a>
          </div>
          <div class="row-fluid">
            <small>Afficher seulement les non lues</small>
            <label class="switch">
              <input type="checkbox" v-model="unopenedcheck" v-on:change="UpdateUnopened()">
              <span class="slider"></span>
            </label>
          </div>

          <hr>


            <span v-if="notifs.length==0">pas de notification pour le moment...</span>
            <a v-for="n in notifs" class="notif" :class="{mute: n.opened}" href="#" v-on:click="Navigate(n)">
                <i v-if="n.type==10" class="fa fa-calendar-days"></i>
                <i v-if="n.type==20" class="fa fa-info"></i> 
                <i v-if="n.type==30" class="fa fa-comment"></i>
                <span>
                  <strong>{{n.title}}</strong><br/>
                  <span>{{ GetDetail(n).message }}</span>
                </span>
            </a>
            
        
          <%--<a class="notif" href="#">
            <i class="fa fa-comment"></i>
            <span>
              <strong>Titre du message</strong><br/>
              <span>bla bla bla</span>
            </span>
          </a>
          <a class="notif mute" href="#">
            <i class="fa fa-info"></i>
            <span>
              <strong>Titre de la news</strong><br/>
              <span>bla bla bla</span>
            </span>
          </a>
        </div>--%>
      
    </div>

<%} %>
<script src="/DesktopModules/Yemon/API/Services/VueJS"></script>
<script src="<%=appPath %>"></script>

<script>
    if(typeof NOTIFICATIONS == 'undefined')
        NOTIFICATIONS =  <%=Yemon.dnn.Functions.Serialize(Notifications)%>;

    $(document).ready(function () {

        if (typeof _yemon == 'undefined')
            _yemon = [];
        _yemon[<%=ModuleID%>] = new Yemon(<%=ModuleID%>, '/Desktopmodules/AIS/API/Notification');
        InitAppNotif('<%=ID %>',<%=ModuleID%>,NOTIFICATIONS);
    });
</script>