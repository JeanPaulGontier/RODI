<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MediaUpload.ascx.cs" Inherits="AIS_MediaUpload" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<script>
    function AutoUpload<%=this.ClientID%>() { document.getElementById("<%=BT2.ClientID %>").click(); }
</script>

<asp:Label ID="lbl_titre" Text="" runat="server" CssClass="dnnLabel"/>
<asp:HiddenField ID="Ref_folder" runat="server" />
<asp:HiddenField ID="Ref_portalID" runat="server" />

<asp:UpdatePanel ID="UpdatePanel1" runat="server" >
    <ContentTemplate>
        <asp:Panel runat="server" ID="Panel0" >   
            <asp:GridView ID="gvw_Photos" runat="server" AllowSorting="false"
                GridLines="None" 
                AutoGenerateColumns="False" 
                AutoGenerateSelectButton="false" 
                OnRowDataBound="gvw_Photos_RowDataBound" 
                OnRowCommand="gvw_Photos_RowCommand" 
                ShowHeader="false">
			    <Columns>   
			        <asp:TemplateField >
			            <ItemTemplate>
			                <asp:Image runat="server" ID="img_Photos" Width="130" />
			            </ItemTemplate>
			        </asp:TemplateField>
			
			        <asp:TemplateField>
			            <ItemTemplate>
			                <asp:button ID="btn_Supprimer_img_Photos" runat="server" Text="Supprimer" CausesValidation="false" CommandName="supprimer" OnClientClick="return confirm('Etes-vous sûr de vouloir supprimer cette photo?');" CssClass="secondaryMiniButton"/>
			            </ItemTemplate>
			        </asp:TemplateField>
			    </Columns>   
			    <PagerSettings Mode="NumericFirstLast" Position="Bottom" /> 
            </asp:GridView>
            <%--<asp:HiddenField runat="server" ID="hfd_Photos" />--%>
        </asp:Panel>

        <%--<asp:Panel runat="server" ID="Panel1" >           
            <asp:Button runat="server" Text="Joindre des photos" ID="BT1" OnClick="BT1_Click" CssClass="secondaryMiniButton"/>
        </asp:Panel>--%>

        <asp:Panel runat="server" ID="Panel2"  Visible="false">
             <telerik:RadAsyncUpload ID="RadUpload1" runat="server" EnableInlineProgress="true" 
                Localization-Cancel="Annuler" 
                Localization-Remove="Supprimer" 
                Localization-Select="Parcourir..." 
                MultipleFileSelection="Automatic"
                DropZones="#dz" />

            <div id="dz" class="panel panel-info">
            <h2>Déposez vos fichiers ici</h2>
        </div>
        
            <span> <!--style="visibility:hidden"--> 
                <asp:Button runat="server" Text="Upload" ID="BT2" OnClick="BT2_Click" />
            </span>
        </asp:Panel>

        <asp:Panel runat="server" ID="Panel3" Visible="false">
            <%--<asp:HyperLink runat="server" ID="HL_Download"></asp:HyperLink>
            <asp:Image runat="server" ID="img" Width="300" Visible="false"/>
            <asp:Button runat="server" Text="Supprimer" ID="BT3" OnClick="BT3_Click" />--%>
            <asp:HiddenField runat="server" ID="SessionMedia"></asp:HiddenField>
        </asp:Panel>

     </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="gvw_Photos" EventName="RowCommand" />
            <asp:AsyncPostBackTrigger ControlID="gvw_Photos" EventName="RowDataBound" />
            <%--<asp:AsyncPostBackTrigger ControlID="BT1" EventName="Click" />--%>
            <asp:AsyncPostBackTrigger ControlID="BT2" EventName="Click" />
            <%--<asp:AsyncPostBackTrigger ControlID="BT3" EventName="Click" />--%>
        </Triggers>
</asp:UpdatePanel>
<asp:Label ID="lbl_required" Text="Obligatoire" ForeColor="Red" runat="server" CssClass="dnnLabel" Visible="false"/>