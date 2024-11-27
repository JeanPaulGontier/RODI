<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Settings.ascx.cs" Inherits="Form_Inscription_Settings" %>

<asp:Panel runat="server" ID="PEdit" Visible="false" CssClass="panel">
    <div class="panel-body">
        <div class="form-group">
            <label>Libellé</label>
            <asp:TextBox ID="K" runat="server" CssClass="form-control" Width="50%"></asp:TextBox>
        </div>
        <div  class="form-group">
          <label>Quantité max</label>
           <asp:TextBox ID="V" runat="server" TextMode="Number" CssClass="form-control" Width="10%"></asp:TextBox>
 
        </div>
        <div>
            <asp:Button runat="server" ID="BTValider" CssClass="btn btn-primary" Text="Valider" OnClick="BTValider_Click" />
            <asp:Button runat="server" ID="BTAnnuler" CssClass="btn btn-default" Text="Annuler" OnClick="BTAnnuler_Click" />

        </div>
    </div>
</asp:Panel>
<asp:HiddenField runat="server" ID="currentindex" />
<asp:HiddenField runat="server" ID="adding" />
<asp:DataList runat="server" ID="DList" OnEditCommand="DList_EditCommand" OnDeleteCommand="DList_DeleteCommand">
    <HeaderTemplate>
    <h2>Créneaux</h2>
    <table style="width:100%" class="dnnGrid">
    </HeaderTemplate>
    

    <ItemTemplate>
    <tr class="dnnGridItem">
        <td>
            <%# Eval("Key") %>
        </td>
        <td>
            <%# Eval("Value") %>
        </td>
        <td>
            <asp:LinkButton runat="server" CssClass="btn btn-link" CommandName="Edit"><img src="/Icons/Sigma/Edit_16x16_Gray.png"</asp:LinkButton>
        </td>
         <td>
             <asp:LinkButton runat="server" CssClass="btn btn-link" CommandName="Delete"><img src="/Icons/Sigma/RedError_16x16_Standard.png"</asp:LinkButton>
         </td>
    </tr>
    </ItemTemplate>
     <AlternatingItemTemplate>
         <tr class="dnnGridAltItem">
             <td>
                 <%# Eval("Key") %>
             </td>
             <td>
                 <%# Eval("Value") %>
             </td>
             <td>
                 <asp:LinkButton runat="server" CssClass="btn btn-link" CommandName="Edit"><img src="/Icons/Sigma/Edit_16x16_Gray.png"</asp:LinkButton>
             </td>
              <td>
                  <asp:LinkButton runat="server" CssClass="btn btn-link" CommandName="Delete"><img src="/Icons/Sigma/RedError_16x16_Standard.png"</asp:LinkButton>
              </td>
         </tr>
     </AlternatingItemTemplate>
 
    <FooterTemplate>
    </table>
    </FooterTemplate>
</asp:DataList>

<asp:Button runat="server" ID="BT_Add" CssClass="btn btn-primary" Text="Ajouter" OnClick="BT_Add_Click" />