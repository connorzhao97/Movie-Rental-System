<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MovieTeam.Account.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div id="header_bg" style="background-image: url(../Image/73da5f6bgy1fot9tqzyoyj21kw07nwoj.jpg);">
        <div id="animate" class="animate" style="font-size: 100px; height: 100px; line-height: 230px; text-shadow: 1px 1px 0 #ff3f1a, -1px -1px 0 #00a7e0; color: #ffffff; text-align: center;"><span style="left: 408.95px; font-family: 华文琥珀; opacity: 1; transform: matrix(1, 0, 0, 1, 0, 0);">电影天堂</span></div>
        <a style="position: absolute; bottom: 0; left: 0; z-index: 1; font-size: 13px; padding: 0 5px; background-color: rgba(0,0,0,0.37); color: #fff;"></a>
    </div>
    <div style="text-align: center">
        <br />
        <br />
        <br />
        <br />
        <div class="title-line"><span class="tit" style="font-size: 38px; font-family: 华文彩云;">登录</span></div>
        <div class="input-box">
            <p>
                &nbsp;
            </p>
            <p>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <input runat="server" id="TextBox1" style="border: 1px solid deepskyblue; width: 350px; height: 40px; border-radius: 5px; border-color: lightslategrey" type="text" value="" placeholder="您的帐号/邮箱" maxlength="50" autocomplete="off" class="" validationgroup="1">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="1">*帐号不能为空！</asp:RequiredFieldValidator>
            </p>
            <p>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <input runat="server" id="TextBox2" style="border: 1px solid deepskyblue; width: 350px; height: 40px; border-radius: 5px; border-color: lightslategrey" type="password" placeholder="密码" class="" validationgroup="1">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="1">*密码不能为空！</asp:RequiredFieldValidator>
            </p>
            <p>
                <input id="RememberMe" type="checkbox" runat="server">记住我
						<span></span>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CausesValidation="False">忘记密码？</asp:LinkButton>
                <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click" CausesValidation="False">修改密码？</asp:LinkButton>
                <!--<a class="forget-password">忘记密码?</a> <a class="not-checkout">修改密码?</a></label> <!---->
                <!---->
            </p>
            <p>
                <asp:Button Style="border-style: solid; border-color: inherit; background-color: dodgerblue; color: white; width: 138px;" class="btn btn-login" ID="Button3" runat="server" Text="登录" OnClick="Login_Click" />
                <!--<a runat="server" ID="Button1" style="border-style: solid; border-color: inherit;background-color:dodgerblue;color:white; width: 138px;" class="btn btn-login">登录</a> -->
                <asp:Button Style="border-style: solid; border-color: lightslategrey; width: 138px;" class="btn btn-reg" ID="Button4" runat="server" Text="注册" CausesValidation="False" OnClick="Button4_Click" />
                <!--<a runat="server" ID="Button2" style="border-style: solid; border-color: lightslategrey; width: 138px;" class="btn btn-reg">注册</a> -->
            </p>
            <p class="sns">
                <a class="btn weibo">微博账号登录</a> <a class="btn qq">QQ账号登录</a>
            </p>
        </div>
    </div>
    <div style="border-style: solid; border-color: inherit; border-width: 1px; width: 259px; height: 29px; border-radius: 8px; margin: 0 auto"></div>

    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
