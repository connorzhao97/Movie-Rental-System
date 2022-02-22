<%@ Page Title="" Language="C#" MasterPageFile="~/Account/Member/Member.master" AutoEventWireup="true" CodeBehind="HasBring.aspx.cs" Inherits="MovieTeam.Account.Member.HasBring" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MemberContent" runat="server">
    <a href="" style="font-size: 18px;font-family:华文琥珀;color:dodgerblue" target="_top">订单如下:</a><br />

            <asp:GridView  style="text-align:center" ID="gvBringAndReturn" runat="server"  CellPadding="4" ForeColor="#333333" AutoGenerateColumns="False" Width="100%">
                 <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                <asp:BoundField DataField="U_Id" HeaderText="用户编号" ReadOnly="True" />
                <asp:BoundField DataField="M_Id" HeaderText="电影编号" ReadOnly="True" />
                <asp:BoundField DataField="B_Date" HeaderText="租赁日期" />
                <asp:BoundField DataField="R_Date" HeaderText="归还日期" />
                <asp:BoundField DataField="B_Rent" HeaderText="租金" />
                <asp:BoundField DataField="BR_Return" HeaderText="是否归还" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
</asp:Content>
