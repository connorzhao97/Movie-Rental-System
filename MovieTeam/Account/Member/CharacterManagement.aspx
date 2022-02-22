<%@ Page Title="" Language="C#" MasterPageFile="~/Account/Member/Member.master" AutoEventWireup="true" CodeBehind="CharacterManagement.aspx.cs" Inherits="MovieTeam.Account.Member.CharacterManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MemberContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" PageSize="5" Width="100%" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting">
        <Columns>
            <asp:BoundField DataField="Ch_Id" HeaderText="编号" ReadOnly="True" />
            <asp:BoundField DataField="Ch_Name" HeaderText="角色名" >
            <ControlStyle Width="100%" />
            </asp:BoundField>
            <asp:BoundField DataField="Ch_Intro" HeaderText="角色介绍" >
            <ControlStyle />
            </asp:BoundField>
            <asp:BoundField DataField="Ch_Enable" HeaderText="是否启用" >
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
    <asp:Label ID="Label_name" runat="server" Text="角色名："></asp:Label>
    <asp:TextBox ID="TextBox_name" runat="server"></asp:TextBox>
    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox_name" ErrorMessage="角色名不能为空" ForeColor="Red">*角色名不能为空！</asp:RequiredFieldValidator>--%>
    <hr />
    <asp:Label ID="Label_intro" runat="server" Text="角色介绍："></asp:Label>
    <asp:TextBox ID="TextBox_intro" runat="server"></asp:TextBox>
    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox_intro" ErrorMessage="角色介绍不能为空" ForeColor="Red">*角色介绍不能为空！</asp:RequiredFieldValidator>--%>
    <hr />
    <asp:Button ID="Button_insert" runat="server" Text="添加角色" OnClick="Button_insert_Click" />

</asp:Content>

