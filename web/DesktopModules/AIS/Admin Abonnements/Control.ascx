<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2016                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Control.ascx.cs" Inherits="DesktopModules_AIS_Admin_Subscriptions_Control" %>



<asp:Panel runat="server" ID="PNL_Annonces" CssClass="left">
    <h3>Mes annonces</h3>
    <asp:Button ID="BTN_Add_Annonce" runat="server" Text="Passer une annonce" ToolTip="Passer une annonce" OnClick="BTN_Add_Annonce_Click" />
        
    <asp:GridView ID="GVW_Annonces" runat="server"  CssClass="tableDefault spacingTop" 
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
                        <%# Eval("titre") %>
                    </asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>

            <%--<asp:BoundField DataField="dt_debut" HeaderText="Date de début" dataformatstring="{0:dd/MM/yyyy}" />--%>
            <asp:TemplateField HeaderText="Date de début" >
                <ItemTemplate>
                    <asp:Label ID="LBL_dt_deb" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>

            <%--<asp:BoundField DataField="dt_fin" HeaderText="Date de fin" dataformatstring="{0:dd/MM/yyyy}"  />--%>
            <asp:TemplateField HeaderText="Date de fin" >
                <ItemTemplate>
                    <asp:Label ID="LBL_dt_fin" runat="server"  />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Actif" >
                <ItemTemplate>
                    <asp:Label ID="LBL_Actif" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Publié" >
                <ItemTemplate>
                    <asp:Label ID="LBL_Publie" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField >
                <ItemTemplate>
                    <asp:button ID="BTN_publier" runat="server" Text="Publier"  CommandName="publier"/>
                    <asp:button ID="BTN_DE_publier" runat="server" Text="Masquer"  CommandName="depublier" />
                    <asp:button ID="BTN_Supp" runat="server" Text="Supprimer"   CommandName="supprimer"/>
                </ItemTemplate>
            </asp:TemplateField>

            

           <%-- <asp:TemplateField >
                <ItemTemplate>
                    <asp:Panel ID="PNL_Orders" runat="server" >
                        <asp:GridView ID="GVW_Orders" runat="server"  
                            OnRowDataBound="GVW_Orders_RowDataBound" 
                            AllowSorting="True" GridLines="None" 
                            AllowPaging="True"
                            AutoGenerateColumns="False" 
                            DataKeyNames="id"  
                            AutoGenerateSelectButton="false">
                            <Columns> 
                                <asp:BoundField DataField="dt_debut" HeaderText="Date de début" dataformatstring="{0:dd/MM/yyyy}" />

                                <asp:BoundField DataField="dt_fin" HeaderText="Date de fin" dataformatstring="{0:dd/MM/yyyy}"  />

                                <asp:TemplateField HeaderText="Actif" >
                                    <ItemTemplate>
                                        <asp:Label ID="LBL_Actif" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                        
                                <asp:TemplateField >
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HLK_Renouveller" runat="server"   Text="Renouveller" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </ItemTemplate>
            </asp:TemplateField>--%>
            
              
        </Columns>    
   
    <EmptyDataTemplate>Aucune annonce</EmptyDataTemplate>
   <PagerSettings Mode="NumericFirstLast" Position="Bottom" /> 
</asp:GridView>

</asp:Panel>

<asp:Panel runat="server" ID="PNL_Presentation" CssClass="right">
    <h3>Ma présentation</h3>
    <asp:Button ID="BTN_Add_Presentation" runat="server" Text="Créer une présentation" ToolTip="Créer une présentation" OnClick="BTN_Add_Presentation_Click" />

    <asp:Button ID="BTN_Presentation" runat="server" Text="Voir la présentation" ToolTip="Voir la présentation" OnClick="BTN_Presentation_Click" />
    
        <asp:GridView ID="GVW_Orders_Presentation" runat="server"  
            CssClass="tableDefault spacingTop" 
            OnRowDataBound="GVW_Orders_Presentation_RowDataBound" 
            AllowSorting="True" GridLines="None" 
            AllowPaging="True"
            AutoGenerateColumns="False" 
            DataKeyNames="id"  
            AutoGenerateSelectButton="false">
            <Columns> 
                <asp:BoundField DataField="dt_debut" HeaderText="Date de début" dataformatstring="{0:dd/MM/yyyy}" />

                <asp:BoundField DataField="dt_fin" HeaderText="Date de fin" dataformatstring="{0:dd/MM/yyyy}"  />

                <asp:TemplateField HeaderText="Actif" >
                    <ItemTemplate>
                        <asp:Label ID="LBL_Actif" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                                        
                <asp:TemplateField >
                    <ItemTemplate>
                        <asp:HyperLink ID="HLK_Renouveller" runat="server"  Text="Renouveller" />
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
   
    <EmptyDataTemplate>Aucune Présentation</EmptyDataTemplate>
   <PagerSettings Mode="NumericFirstLast" Position="Bottom" /> 
</asp:GridView>

</asp:Panel>