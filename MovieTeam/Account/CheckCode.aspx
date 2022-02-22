<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CheckCode.aspx.cs" Inherits="MovieTeam.Account.CheckCode" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
    <div style="width:100%">
        <div style="margin:250px 400px">

            <asp:Label ID="Label1" runat="server" Text="请输入收到的验证码：" ></asp:Label>
            <asp:TextBox ID="TextBox_check" runat="server"></asp:TextBox>
            <asp:Button ID="Button_check" runat="server" Text="确认" OnClick="Button_check_Click" />
            <hr />
            <div>
                <asp:Label ID="Label2" runat="server" Visible="False">您的密码为：</asp:Label>
            </div>
            
    </div>
    </div>
   
</asp:Content>
