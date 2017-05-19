<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserGrid.ascx.cs" Inherits="HRMTS.Web.DesktopModules.Administration.UserGrid" %>

<asp:UpdatePanel ID="UpdatePanel_UserGrid" runat="server">
    <ContentTemplate>
        <asp:GridView ID="GridView_Users" runat="server"
            Width="100%" GridLines="None"
            AutoGenerateColumns="false" AllowSorting="true"
            AllowPaging="true" PageSize="20"
            AllowCustomPaging="true" SkinID="Default"
            OnSorting="GridView_Users_Sorting"
            OnPageIndexChanging="GridView_Users_PageIndexChanging">
            <Columns>
                <asp:TemplateField HeaderText="Id" SortExpression="Id">
                    <ItemTemplate>
                        <asp:Label ID="Label_Id" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </ContentTemplate>
</asp:UpdatePanel>
