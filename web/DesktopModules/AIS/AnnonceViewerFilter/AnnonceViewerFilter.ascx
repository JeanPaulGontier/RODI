<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2016                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AnnonceViewerFilter.ascx.cs" Inherits="DesktopModules_AIS_AnnonceViewerFilter_AnnonceViewerFilter" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>


    <div>
        <asp:RadioButton id="RBT_Offre" Text="Offre" GroupName="typeAnnonce" runat="server" OnCheckedChanged="RBT_Offre_CheckedChanged" AutoPostBack="true"/>
        <asp:RadioButton id="RBT_Demande" Text="Demande" GroupName="typeAnnonce" runat="server" OnCheckedChanged="RBT_Demande_CheckedChanged" AutoPostBack="true"/>
        <asp:RadioButton id="RBT_All" Text="Toutes" Checked="True" GroupName="typeAnnonce" runat="server" OnCheckedChanged="RBT_All_CheckedChanged" AutoPostBack="true"/>
    </div>


    <asp:ListView ID="GVW_Annonces" runat="server" OnItemDataBound="GVW_Annonces_ItemDataBound" AutoPostBack="true">
        <LayoutTemplate>

            <table>
                <tr runat="server" id="itemPlaceholder" />
            </table>

            <asp:DataPager runat="server" ID="PeopleDataPager" PageSize="12">
                <Fields>
                    <asp:NumericPagerField ButtonCount="10" />
                </Fields>
            </asp:DataPager>

        </LayoutTemplate>

        <ItemTemplate>  
            <asp:Hyperlink runat="server" ID="Hyperlink1"  ToolTip="Voir l'annonce" >
		        <asp:Label runat="server" ID="Label1" Text="" />
		        <asp:Literal runat="server" ID="Literal1"  />
	        </asp:HyperLink>
        </ItemTemplate>
        
    </asp:ListView>

   










