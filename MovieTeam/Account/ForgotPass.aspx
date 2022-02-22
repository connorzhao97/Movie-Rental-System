<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ForgotPass.aspx.cs" Inherits="MovieTeam.Account.ForgotPass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <br />
    <div id="header_bg" style="background-image: url(../Image/73da5f6bgy1fot9tqzyoyj21kw07nwoj.jpg);"><div id="animate" class="animate" style="font-size: 100px;height: 100px;line-height: 230px;text-shadow: 1px 1px 0 #ff3f1a, -1px -1px 0 #00a7e0;color: #ffffff;text-align: center;"><span style="left: 408.95px;font-family:华文琥珀; opacity: 1; transform: matrix(1, 0, 0, 1, 0, 0);">电影天堂</span></div><a style=" position: absolute; bottom: 0; left: 0; z-index: 1; font-size: 13px; padding: 0 5px; background-color: rgba(0,0,0,0.37); color: #fff;"></a></div>
    <div style="text-align:center">
        <br />
        <br />
        <br />
        <br />
    <div class="title-line"><span class="tit" style="font-size: 38px;font-family:华文彩云;">找回密码</span></div>
        <br />
        <br />
    <div class="input-box">
        <p>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp
            <input runat="server" ID="TextBox1" required="required" style="border: 1px solid deepskyblue; width: 350px; height: 40px; border-radius:5px;border-color:lightslategrey" type="text" value="" placeholder="请输入邮箱"  maxlength="50" autocomplete="off">
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*邮箱格式错误！" ForeColor="Red" ControlToValidate="TextBox1" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Button style="border-style: solid; border-color: inherit;background-color:dodgerblue;color:white; " class="btn btn-login" ID="Button3" runat="server" Text="将验证码发送至邮箱" OnClick="ForgotPass_Click" Height="39px" Width="350px" />
            </p>
        <p class="sns">&nbsp;</p>
    </div>
        </div>
</asp:Content>
