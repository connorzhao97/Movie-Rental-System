<%@ Page Title="" Language="C#" MasterPageFile="~/Account/Member/Member.master" AutoEventWireup="true" CodeBehind="UserManagement.aspx.cs" Inherits="MovieTeam.Account.Member.UserManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MemberContent" runat="server">
    <asp:RadioButtonList ID="rblEnable" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblEnable_SelectedIndexChanged" RepeatDirection="Horizontal">
        <asp:ListItem Value="true" Selected="True">已启用用户</asp:ListItem>
        <asp:ListItem Value="false">已禁用用户</asp:ListItem>
    </asp:RadioButtonList>
     <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" PageSize="5" Width="100%" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
        <Columns>
            <asp:BoundField DataField="U_Id" HeaderText="用户编号" ReadOnly="True" />
            <asp:BoundField DataField="U_Name" HeaderText="用户名" />
            <asp:BoundField DataField="U_Gender" HeaderText="用户性别" />
            <asp:BoundField DataField="U_NickName" HeaderText="用户昵称" />
            <asp:BoundField DataField="U_Address" HeaderText="用户地址" />
            <asp:BoundField DataField="U_Level" HeaderText="用户等级" />
            <asp:ImageField DataImageUrlField="U_Picture" HeaderText="用户图片">
            </asp:ImageField>
            <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />
            <asp:CommandField HeaderText="启用/禁用" SelectText="禁用/启用" ShowSelectButton="True" />
        </Columns>
        <AlternatingRowStyle BackColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerSettings FirstPageText="首页" LastPageText="末页" Mode="NumericFirstLast" Position="Top" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
</asp:Content>

