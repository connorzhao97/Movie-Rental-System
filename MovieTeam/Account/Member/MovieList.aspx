<%@ Page Title="" Language="C#" MasterPageFile="~/Account/Member/Member.master" AutoEventWireup="true" CodeBehind="MovieList.aspx.cs" Inherits="MovieTeam.Account.Member.MovieList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MemberContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging" Width="100%" >
        <Columns>
            <asp:BoundField DataField="M_Id" HeaderText="编号" ReadOnly="True" />
            <asp:BoundField DataField="M_Name" HeaderText="电影名" >
            <ControlStyle Width="100%" />
            </asp:BoundField>
            <asp:BoundField DataField="M_Frequency" HeaderText="借阅次数" >
            <ControlStyle />
            </asp:BoundField>
            <asp:BoundField DataField="M_Stock" HeaderText="电影库存" >
            <ControlStyle Width="100%" />
            </asp:BoundField>
            
            
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
