<%@ Page Title="" Language="C#" MasterPageFile="~/Account/Member/Member.master" AutoEventWireup="true" CodeBehind="FunctionManagement.aspx.cs" Inherits="MovieTeam.Account.Member.FunctionManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MemberContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" PageSize="5" Width="100%" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting">
        <Columns>
            <asp:BoundField DataField="F_Id" HeaderText="编号" ReadOnly="True" />
            <asp:BoundField DataField="F_Name" HeaderText="功能名" >
            <ControlStyle Width="100%" />
            </asp:BoundField>
            <asp:BoundField DataField="F_Path" HeaderText="功能路径" >
            <ControlStyle Width="100%" />
            </asp:BoundField>
            <asp:BoundField DataField="F_ParentId" HeaderText="父功能编号" >
            <ControlStyle Width="100%" />
            </asp:BoundField>
            <asp:BoundField DataField="F_Enable" HeaderText="是否启用" >
            <ControlStyle Width="100%" />
            </asp:BoundField>
            
            <asp:CommandField EditText="修改" HeaderText="编辑" ShowEditButton="True" UpdateText="保存" >
            <ControlStyle Width="100%" />
            </asp:CommandField>
            <asp:CommandField HeaderText="删除" ShowDeleteButton="True" >
            <ControlStyle Width="100%" />
            </asp:CommandField>
            <asp:CommandField HeaderText="启用/禁用" SelectText="禁用" ShowSelectButton="True" >
            <ControlStyle Width="100%" />
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
    <asp:Label ID="Label_name" runat="server" Text="功能名："></asp:Label>
    <asp:TextBox ID="TextBox_name" runat="server"></asp:TextBox>
    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox_name" ErrorMessage="角色名不能为空" ForeColor="Red">*角色名不能为空！</asp:RequiredFieldValidator>--%>
    <hr />
    <asp:Label ID="Label_path" runat="server" Text="功能路径："></asp:Label>
    <asp:TextBox ID="TextBox_path" runat="server"></asp:TextBox>
    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox_intro" ErrorMessage="角色介绍不能为空" ForeColor="Red">*角色介绍不能为空！</asp:RequiredFieldValidator>--%>
    <hr />
    <asp:Label ID="Label_pid" runat="server" Text="父功能编号："></asp:Label>
    <asp:TextBox ID="TextBox_pid" runat="server"></asp:TextBox>
    <hr />
    <asp:Button ID="Button_insert" runat="server" Text="添加功能" OnClick="Button_insert_Click" />

</asp:Content>
