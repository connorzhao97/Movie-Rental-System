<%@ Page Title="" Language="C#" MasterPageFile="~/Account/Member/Member.master" AutoEventWireup="true" CodeBehind="UserInformation.aspx.cs" Inherits="MovieTeam.Account.Member.UserInformation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MemberContent" runat="server">
    <asp:Label ID="Label_p" runat="server" Text="用户头像："></asp:Label>
    <asp:Image ID="Image_p" runat="server" Height="200px" Width="200px" />
    <hr />
    <asp:FileUpload ID="FileUpload_p" runat="server" />
    <hr />
    <asp:Label ID="Label_nname" runat="server" Text="用户昵称："></asp:Label>
    <asp:TextBox ID="TextBox_nname" runat="server"></asp:TextBox>
    <hr />
    <asp:Label ID="Label_gender" runat="server" Text="用户性别："></asp:Label>
    <asp:TextBox ID="TextBox_gender" runat="server"></asp:TextBox>
    <hr />
    <asp:Label ID="Label_email" runat="server" Text="用户邮箱："></asp:Label>
    <asp:TextBox ID="TextBox_email" runat="server"></asp:TextBox>
    <hr />
    <asp:Label ID="Label_address" runat="server" Text="用户地址："></asp:Label>
    <asp:TextBox ID="TextBox_address" runat="server"></asp:TextBox>
    <hr />
     <a href="/Account/ChangePass.aspx">修改密码</a>
    <hr />
    <asp:Button ID="Button_update" runat="server" Text="确认修改" OnClick="Button_update_Click" />
    <hr />
    
            <br />
        </div>
</asp:Content>
