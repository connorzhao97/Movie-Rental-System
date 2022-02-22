<%@ Page Title="" Language="C#" MasterPageFile="~/Account/Member/Member.master" AutoEventWireup="true" CodeBehind="MovieManagement_Off.aspx.cs" Inherits="MovieTeam.Account.Member.MovieManagement_Off" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MemberContent" runat="server">
    
    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" PageSize="5" Width="100%" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" OnRowDeleting="GridView1_RowDeleting">
        <Columns>
            <asp:BoundField DataField="M_Id" HeaderText="编号" ReadOnly="True" />
            <asp:BoundField DataField="M_Name" HeaderText="电影名" >
            <ControlStyle Width="100%" />
            </asp:BoundField>
            <asp:BoundField DataField="M_eName" HeaderText="电影英文" >
            <ControlStyle Width="100%" />
            </asp:BoundField>
            <asp:BoundField DataField="M_Grade" HeaderText="评分" >
            <ControlStyle Width="100%" />
            </asp:BoundField>
            <asp:BoundField DataField="M_Length" HeaderText="电影片长" >
            <ControlStyle Width="100%" />
            </asp:BoundField>
            <asp:BoundField DataField="M_Grade" HeaderText="评分" >
            <ControlStyle Width="100%" />
            </asp:BoundField>
            <asp:BoundField DataField="M_Type" HeaderText="电影类型" >
            <ControlStyle Width="100%" />
            </asp:BoundField>
            <asp:BoundField DataField="M_Area" HeaderText="电影地区" >
            <ControlStyle Width="100%" />
            </asp:BoundField>
            <asp:BoundField DataField="M_Date" HeaderText="出版日期" >
            <ControlStyle Width="100%" />
            </asp:BoundField>
            <asp:BoundField DataField="M_Stock" HeaderText="电影存货" >
            <ControlStyle Width="100%" />
            </asp:BoundField>
            <asp:BoundField DataField="M_Frequency" HeaderText="借阅次数" >
            <ControlStyle Width="100%" />
            </asp:BoundField>
            <asp:BoundField DataField="M_Intro" HeaderText="电影简介" />
            <asp:ImageField DataImageUrlField="M_Picture" HeaderText="电影图片" ReadOnly="True">
                <ControlStyle Width="100%" />
                <ItemStyle Height="50px" Width="50px" />
            </asp:ImageField>
            <asp:TemplateField HeaderText="更改图片">
                <ItemTemplate>
                    <asp:FileUpload ID="FileUpload2" runat="server" Enabled="False" />
                    <asp:Button ID="Button1" runat="server" Text="上传" OnClick="UpLoad_Click" Enabled="False" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField EditText="修改" HeaderText="编辑" ShowEditButton="True" UpdateText="保存" >
            <ControlStyle Width="100%" />
            </asp:CommandField>
            <asp:CommandField HeaderText="删除" ShowDeleteButton="True" >
            <ControlStyle Width="100%" />
            </asp:CommandField>
            <asp:CommandField HeaderText="启用/禁用" SelectText="启用" ShowSelectButton="True" >
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
    </asp:Content>
