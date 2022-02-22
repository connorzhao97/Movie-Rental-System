<%@ Page Title="" Language="C#" MasterPageFile="~/Account/Member/Member.master" AutoEventWireup="true" CodeBehind="ExamineCommentManagement.aspx.cs" Inherits="MovieTeam.Account.Member.CommentsManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MemberContent" runat="server">
    <asp:GridView ID="gvCommet" runat="server" AutoGenerateColumns="False" OnPageIndexChanging="gvCommet_PageIndexChanging" OnRowCancelingEdit="gvCommet_RowCancelingEdit" OnRowDataBound="gvCommet_RowDataBound" OnRowDeleting="gvCommet_RowDeleting" OnRowEditing="gvCommet_RowEditing" OnRowUpdating="gvCommet_RowUpdating" AllowPaging="True" CellPadding="4" Width="100%" OnSelectedIndexChanging="gvCommet_SelectedIndexChanging">
        <Columns>
            <asp:BoundField DataField="Com_Id" HeaderText="评论编号" ReadOnly="True" />
            <asp:BoundField DataField="U_Id" HeaderText="用户编号" ReadOnly="True"/>
            <asp:BoundField DataField="U_Name" HeaderText="用户名" ReadOnly="True"/>
            <asp:BoundField DataField="M_Id" HeaderText="电影编号" ReadOnly="True"/>
            <asp:BoundField DataField="Com_Grade" HeaderText="评论分数" />
            <asp:BoundField DataField="Com_Date" HeaderText="评论时间" />
            <asp:BoundField DataField="Com_Content" HeaderText="评论内容" />
            <asp:CommandField HeaderText="审查评论" SelectText="通过此评论" ShowSelectButton="True" />
            <asp:CommandField EditText="修改" HeaderText="编辑" ShowEditButton="True" UpdateText="保存" />
            <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />           
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
