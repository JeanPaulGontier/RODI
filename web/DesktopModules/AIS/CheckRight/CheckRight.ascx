<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CheckRight.ascx.cs" Inherits="DesktopModules_CheckRight" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>


<asp:Panel ID="pnl_Tab" runat="server" CssClass="panel panel-default" >
	<div class="panel-heading">
    	<h3 class="panel-title">Liste des pages dont l'édition est activée pour tout le monde</h3>
    </div>

    
    <asp:GridView ID="gvw_tab" runat="server" CssClass="panel-body table"            
        GridLines="None"  
        AutoGenerateColumns="False" 
        DataKeyNames="TabID"  
        AutoGenerateSelectButton="false"        
        OnRowDataBound="gvw_tab_RowDataBound" >
        <Columns >             
                        
            <asp:TemplateField HeaderText="TabName">
                <ItemTemplate>
                    <asp:Label ID="lbl_TabName" runat="server" text='<%#Eval("TabName") %>' />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="TabID">
                <ItemTemplate>
                    <asp:Label ID="lbl_TabID" runat="server" text='<%#Eval("TabID") %>'   />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Title">
                <ItemTemplate>
                    <asp:Label ID="lbl_Title" runat="server" text='<%#Eval("Title") %>' />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="IsVisible">
                <ItemTemplate>
                    <asp:Label ID="lbl_IsVisible" runat="server" text='<%#Eval("IsVisible") %>' />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="IsDeleted">
                <ItemTemplate>
                    <asp:Label ID="lbl_IsDeleted" runat="server" text='<%#Eval("IsDeleted") %>' />
                </ItemTemplate>
            </asp:TemplateField>

           <asp:TemplateField HeaderText="LastModifiedOnDate">
                <ItemTemplate>
                    <asp:Label ID="lbl_LastModifiedOnDate" runat="server" text='<%#Eval("LastModifiedOnDate") %>' />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="LastModifiedByUser">
                <ItemTemplate>
                    <asp:Label ID="lbl_LastModifiedByUser" runat="server" text='<%#Eval("username") %>' />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Page" >
                <ItemTemplate>
                    <asp:HyperLink ID="lkbtn_Tab" runat="server" text="Accéder"  />
                </ItemTemplate>
            </asp:TemplateField>

            </Columns>
            <EmptyDataTemplate>Aucun résultat</EmptyDataTemplate>
            <PagerSettings Mode="NumericFirstLast" Position="Bottom" /> 
        </asp:GridView>
    </asp:Panel>

<asp:Panel ID="pnl_Mod" runat="server" CssClass="panel panel-default" >
	<div class="panel-heading">
    	<h3 class="panel-title">Liste des modules dont l'édition est activée pour tout le monde</h3>
    </div>

    
    <asp:GridView ID="gvw_Mod" runat="server" CssClass="panel-body table"            
        GridLines="None"  
        AutoGenerateColumns="False" 
        DataKeyNames="TabID"  
        AutoGenerateSelectButton="false" 
        OnRowDataBound="gvw_Mod_RowDataBound">
        <Columns >   

            <asp:TemplateField HeaderText="ModuleTitle">
                <ItemTemplate>
                    <asp:Label ID="lbl_ModuleTitle" runat="server" text='<%#Eval("ModuleTitle") %>'   />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="ModuleID">
                <ItemTemplate>
                    <asp:Label ID="lbl_moduleid" runat="server" text='<%#Eval("moduleid") %>'   />
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="TabID">
                <ItemTemplate>
                    <asp:Label ID="lbl_Mod_TabID" runat="server" text='<%#Eval("TabID") %>'   />
                </ItemTemplate>
            </asp:TemplateField>
                        
            <asp:TemplateField HeaderText="TabName">
                <ItemTemplate>
                    <asp:Label ID="lbl_Mod_TabName" runat="server" text='<%#Eval("TabName") %>' />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Title">
                <ItemTemplate>
                    <asp:Label ID="lbl_Mod_Title" runat="server" text='<%#Eval("Title") %>' />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="IsVisible">
                <ItemTemplate>
                    <asp:Label ID="lbl_Mod_IsVisible" runat="server" text='<%#Eval("IsVisible") %>' />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="IsDeleted">
                <ItemTemplate>
                    <asp:Label ID="lbl_Mod_IsDeleted" runat="server" text='<%#Eval("IsDeleted") %>' />
                </ItemTemplate>
            </asp:TemplateField>

           <asp:TemplateField HeaderText="LastModifiedOnDate">
                <ItemTemplate>
                    <asp:Label ID="lbl_Mod_LastModifiedOnDate" runat="server" text='<%#Eval("LastModifiedOnDate") %>' />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="LastModifiedByUser">
                <ItemTemplate>
                    <asp:Label ID="lbl_Mod_LastModifiedByUser" runat="server" text='<%#Eval("username") %>' />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Page" >
                <ItemTemplate>
                    <asp:HyperLink ID="lkbtn_Mod" runat="server" text="Accéder"/>
                </ItemTemplate>
            </asp:TemplateField>

            </Columns>
            <EmptyDataTemplate>Aucun résultat</EmptyDataTemplate>
            <PagerSettings Mode="NumericFirstLast" Position="Bottom" /> 
        </asp:GridView>
    </asp:Panel>

