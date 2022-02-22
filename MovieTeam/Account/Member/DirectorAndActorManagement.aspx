<%@ Page Title="" Language="C#" MasterPageFile="~/Account/Member/Member.master" AutoEventWireup="true" CodeBehind="DirectorAndActorManagement.aspx.cs" Inherits="MovieTeam.Account.Member.DirectorAndActorManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MemberContent" runat="server">
    <asp:RadioButtonList ID="rblEnable" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblEnable_SelectedIndexChanged" RepeatDirection="Horizontal" Width="100%">
        <asp:ListItem Value="true" Selected="True">导演</asp:ListItem>
        <asp:ListItem Value="false">演员</asp:ListItem>
    </asp:RadioButtonList>
    <asp:GridView ID="gvDirectorAndActor" runat="server" AutoGenerateColumns="False" OnPageIndexChanging="gvDirectorAndActor_PageIndexChanging" OnRowCancelingEdit="gvDirectorAndActor_RowCancelingEdit" OnRowDataBound="gvDirectorAndActor_RowDataBound" OnRowDeleting="gvDirectorAndActor_RowDeleting" OnRowEditing="gvDirectorAndActor_RowEditing" OnRowUpdating="gvDirectorAndActor_RowUpdating" AllowPaging="True" CellPadding="4" Width="100%" OnSelectedIndexChanging="gvDirectorAndActor_SelectedIndexChanging" ForeColor="#333333" GridLines="None" PageSize="6">
        <Columns>
            <asp:BoundField DataField="DA_Id" HeaderText="演员/导演编号" ReadOnly="True" />
            <asp:BoundField DataField="M_Id" HeaderText="电影编号" />
            <asp:BoundField DataField="DA_Name" HeaderText="演员/导演名" />
            <asp:BoundField DataField="DA_EName" HeaderText="演员/导演英文名" />
            <asp:ImageField DataImageUrlField="DA_Picture" HeaderText="导演/演员图片" ReadOnly="True"  ControlStyle-Height="100px" ControlStyle-Width="100px">
<ControlStyle Height="100px" Width="100px"></ControlStyle>
            </asp:ImageField>
             <asp:BoundField DataField="DA_Intro" HeaderText="演员导演简介" />
            <asp:TemplateField HeaderText="更改图片">
                <ItemTemplate>
                    <asp:FileUpload ID="FileUpload_DA" runat="server" Enabled="False"/>
                    <asp:Button ID="DA_PictureBt" runat="server" Text="上传"  Enabled="False" OnClick="DA_Picture_Click"/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField HeaderText="导演/演员" SelectText="导演/演员" ShowSelectButton="True" />
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
