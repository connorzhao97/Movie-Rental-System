<%@ Page Title="" Language="C#" MasterPageFile="~/Account/Member/Member.master" AutoEventWireup="true" CodeBehind="LimitManagement.aspx.cs" Inherits="MovieTeam.Account.Member.LimitManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MemberContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" OnRowUpdating="GridView1_RowUpdating" Width="100%" >
        <Columns>
            <asp:BoundField DataField="L_Id" HeaderText="编号" ReadOnly="True">
            
            </asp:BoundField>
            <asp:BoundField DataField="Ch_Name" HeaderText="角色名" >
            
            </asp:BoundField>
            <asp:BoundField DataField="F_Name" HeaderText="功能名" >
            
            </asp:BoundField>
            
            <asp:BoundField DataField="L_Enable" HeaderText="是否启用" >
            
            </asp:BoundField>
            
            <asp:CommandField EditText="修改" HeaderText="编辑" ShowEditButton="True" UpdateText="保存" >
            
            </asp:CommandField>
            <asp:CommandField HeaderText="删除" ShowDeleteButton="True" >
            
            </asp:CommandField>
            <asp:CommandField HeaderText="启用/禁用" SelectText="禁用" ShowSelectButton="True" >
            
            </asp:CommandField>
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
    <hr />
    <asp:Label ID="Label_cname" runat="server" Text="角色名："></asp:Label>
    <asp:DropDownList ID="DropDownList_cname" runat="server" AutoPostBack="True"></asp:DropDownList>
    <hr />
    <asp:Label ID="Label_fname" runat="server" Text="功能名："></asp:Label>
    <asp:DropDownList ID="DropDownList_fname" runat="server" AutoPostBack="True"></asp:DropDownList>
    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox_intro" ErrorMessage="角色介绍不能为空" ForeColor="Red">*角色介绍不能为空！</asp:RequiredFieldValidator>--%>
    <hr />

    <asp:Button ID="Button_insert" runat="server" Text="添加权限" OnClick="Button_insert_Click" />
</asp:Content>
