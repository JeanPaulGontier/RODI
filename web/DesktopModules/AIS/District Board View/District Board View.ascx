<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2016                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="District Board View.ascx.cs" Inherits="DesktopModules_AIS_District_Board_View_District_Board_View" %>

<asp:UpdatePanel runat="server">
    <ContentTemplate>

<div class="panel panel-body" >
    <div class="row text-center">
        Année rotarienne : <asp:DropDownList ID="ddl_rotaryYear" AutoPostBack="true" OnSelectedIndexChanged="ddl_rotaryYear_SelectedIndexChanged" runat="server" ></asp:DropDownList>
    </div>
    <div class="pe-spacer size20"></div>

    <div class="row text-center">
        <asp:DataList ID="dataList_Members" Width="100%" RepeatLayout="Flow" runat="server" OnItemDataBound="dataList_Members_ItemDataBound" CssClass="Trombi row" ItemStyle-CssClass="col-sm-6">
            <ItemTemplate>
                <div class="panel">
	                <div class="panel-body">
		                <asp:Image ID="Image1" runat="server" CssClass="img-ronde" />
		                <div>
			                <asp:Label ID="lbl_Fonction" runat="server" />
			                <p>
			                <strong><asp:Label ID="LBL_Nom" Text='<%# Bind("name") %>' runat="server"></asp:Label> <asp:Label ID="LBL_NomFamille" Text='<%# Bind("surname") %>' runat="server"></asp:Label></strong>
			                </p>
			                <p></p><asp:Label ID="LBL_Libelle" Text='<%# Bind("job") %>' runat="server"></asp:Label></p>
			                
			                <p><small><asp:Label ID="LBL_Club" Text='<%# Bind("club") %>' runat="server"></asp:Label></small></p>
			                <p><small><asp:Label ID="lbl_description" Text='<%# Bind("description") %>' runat="server"></asp:Label></small></p>
			                <asp:HyperLink ID="HL_Contact" runat="server">Le contacter</asp:HyperLink>
		                </div>
	                </div>
	                <div class="clearfix"></div>
                </div>
            </ItemTemplate> 
        </asp:DataList>
    </div>
</div>
        
    </ContentTemplate>
</asp:UpdatePanel>