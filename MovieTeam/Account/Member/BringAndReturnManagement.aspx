<%@ Page Title="" Language="C#" MasterPageFile="~/Account/Member/Member.master" AutoEventWireup="true" CodeBehind="BringAndReturnManagement.aspx.cs" Inherits="MovieTeam.Account.Member.BringAndReturnManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MemberContent" runat="server">
    <asp:RadioButtonList ID="rblEnable" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblEnable_SelectedIndexChanged" RepeatDirection="Horizontal" Width="100%">
        <asp:ListItem Value="true" Selected="True">已经归还</asp:ListItem>
        <asp:ListItem Value="false">未归还</asp:ListItem>
    </asp:RadioButtonList>
    <asp:GridView ID="gvBringAndReturn" runat="server" AutoGenerateColumns="False" OnPageIndexChanging="gvBringAndReturn_PageIndexChanging" OnRowCancelingEdit="gvBringAndReturn_RowCancelingEdit" OnRowDataBound="gvBringAndReturn_RowDataBound" OnRowDeleting="gvBringAndReturn_RowDeleting" OnRowEditing="gvBringAndReturn_RowEditing" OnRowUpdating="gvBringAndReturn_RowUpdating" AllowPaging="True" CellPadding="4" Width="100%" OnSelectedIndexChanging="gvBringAndReturn_SelectedIndexChanging">
        <Columns>
            <asp:BoundField DataField="BR_Id" HeaderText="租赁编号" ReadOnly="True" />
            <asp:BoundField DataField="U_Id" HeaderText="用户编号" ReadOnly="True"/>
            <asp:BoundField DataField="M_Id" HeaderText="电影编号" ReadOnly="True"/>
            <asp:BoundField DataField="B_Date" HeaderText="租赁日期" ReadOnly="True"/>
            <asp:BoundField DataField="R_Date" HeaderText="归还日期" />
            <asp:BoundField DataField="B_Rent" HeaderText="租金" />
            <asp:CommandField EditText="修改" HeaderText="编辑" ShowEditButton="True" UpdateText="保存" />
            <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />
            <asp:CommandField HeaderText="归还/未归还" SelectText="规划/未归还" ShowSelectButton="True" />
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
