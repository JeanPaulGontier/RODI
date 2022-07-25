<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Control.ascx.cs" Inherits="DesktopModules_AIS_Agenda_Gouverneur_Control" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.Client.ClientResourceManagement" Assembly="DotNetNuke.Web.Client" %>
<dnn:DnnJsInclude ID="angularJS" runat="server" FilePath="https://ajax.googleapis.com/ajax/libs/angularjs/1.7.9/angular.min.js" />
<dnn:DnnJsInclude ID="appJS" runat="server" />
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

<div id="AppPane<%=this.ModuleId %>" ng-app="App" ng-controller="AppController" data-ng-init="init(<%=this.ModuleId %>)" ng-cloak>

        <div ng-show="!agenda">
            <i class="fa fa-refresh fa-spin" style="font-size: 24px"></i>
        </div>
      
        <table style="100%" class="table table-striped" ng-show="agenda">
            <tr ng-repeat="event in agenda">
                <td>{{event.title}}</td>
                <td>{{event.dt}}</td>
                <td>{{event.hr}}</td>           
            </tr>
        </table>
   
</div>