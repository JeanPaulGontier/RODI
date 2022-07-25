<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2016                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Control.ascx.cs" Inherits="DesktopModules_AIS_Admin_Webmaster_Subscriptions_Control" %>



<asp:Panel runat="server" ID="PNL_Annonces" CssClass="left">
    <h3>Les abonnements</h3>
            
    <asp:GridView ID="GVW_Annonces" runat="server"  CssClass="table table-striped" 
        OnRowDataBound="GVW_Annonces_RowDataBound" 
        OnRowCommand="GVW_Annonces_RowCommand"
        AllowSorting="True" 
        GridLines="None" 
        AllowPaging="True" 
        PageSize="25" 
        AutoGenerateColumns="False" 
        DataKeyNames="id"  
        AutoGenerateSelectButton="false">
        <Columns>   

            <asp:TemplateField HeaderText="Titre" >
                <ItemTemplate>
                    <asp:HyperLink ID="HLK_Titre" runat="server"  >
                        Accéder
                    </asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Type" >
                <ItemTemplate>
                    <asp:Label ID="LBL_type" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Id paypal" >
                <ItemTemplate>
                    <asp:Label ID="LBL_paypal" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
                        
            <asp:TemplateField HeaderText="Date de début" >
                <ItemTemplate>
                    <asp:Label ID="LBL_dt_deb" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
                        
            <asp:TemplateField HeaderText="Date de fin" >
                <ItemTemplate>
                    <asp:Label ID="LBL_dt_fin" runat="server"  />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Montant" >
                <ItemTemplate>
                    <asp:Label ID="LBL_Montant" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Actif" >
                <ItemTemplate>
                    <asp:Label ID="LBL_Actif" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Membre" >
                <ItemTemplate>
                    <%--<asp:PlaceHolder ID="LBL_Membre" runat="server" />--%>
                    <asp:Label ID="LBL_Membre" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField >
                <ItemTemplate>                    
                    <asp:button ID="BTN_inactif" runat="server" Text="Désactiver"  CommandName="inactif" ToolTip="Rendre inactif"/>
                    <asp:button ID="BTN_actif" runat="server" Text="Activer"  CommandName="actif" ToolTip="Rendre actif"/>
                </ItemTemplate>
            </asp:TemplateField>
              
        </Columns>    
   
    <EmptyDataTemplate>Aucun abonnement</EmptyDataTemplate>
   <PagerSettings Mode="NumericFirstLast" Position="Bottom" /> 
</asp:GridView>

</asp:Panel>

