<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="MovieTeam.Account.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <br />
    <div id="header_bg" style="background-image: url(../Image/73da5f6bgy1fot9tqzyoyj21kw07nwoj.jpg);">
        <div id="animate" class="animate" style="font-size: 100px; height: 100px; line-height: 230px; text-shadow: 1px 1px 0 #ff3f1a, -1px -1px 0 #00a7e0; color: #ffffff; text-align: center;"><span style="left: 408.95px; font-family: 华文琥珀; opacity: 1; transform: matrix(1, 0, 0, 1, 0, 0);">电影天堂</span></div>
        <a style="position: absolute; bottom: 0; left: 0; z-index: 1; font-size: 13px; padding: 0 5px; background-color: rgba(0,0,0,0.37); color: #fff;"></a>
    </div>
    <br />
    <br />
    <br />
    <div style="text-align: center">
        <br />
        <div class="title-line"><span class="tit" style="font-size: 38px; font-family: 华文彩云;">注册</span></div>
        <br />
        <div class="new_phone center_div">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
        <input runat="server" id="TextBox1" style="border: 1px solid deepskyblue; width: 350px; height: 40px; border-radius: 5px; border-color: lightslategrey" type="text" name="uname" placeholder="用户名" class="user_id_password mar_b_40px">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="用户名不能为空" ForeColor="Red">*用户名不能为空！</asp:RequiredFieldValidator>
        </div>
        <br />
         <div class="new_phone center_div">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
        <input runat="server" id="Email" style="border: 1px solid deepskyblue; width: 350px; height: 40px; border-radius: 5px; border-color: lightslategrey" type="text" name="uname" placeholder="邮箱" class="user_id_password mar_b_40px">
             <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*邮箱格式不正确！" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="Email"></asp:RegularExpressionValidator>
        </div>
        <br />
        <div class="center_div">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
        <input runat="server" id="TextBox2" required="required" style="border: 1px solid deepskyblue; width: 350px; height: 40px; border-radius: 5px; border-color: lightslategrey" type="password" name="userpwd" placeholder="密码（6-16个字符组成，区分大小写）" class="user_id_password" maxlength="16" minlength="6">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationExpression="^.{6,16}$ " ErrorMessage="RequiredFieldValidator" ControlToValidate="TextBox2" ForeColor="Red">*6-16个字符组成，区分大小写！</asp:RequiredFieldValidator>
        </div>
        <br />
        <div class="center_div">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
        <input runat="server" id="TextBox3" required="required" style="border: 1px solid deepskyblue; width: 350px; height: 40px; border-radius: 5px; border-color: lightslategrey" type="password" name="userpwd" placeholder="确认密码（6-16个字符组成，区分大小写）" class="user_id_password" maxlength="16" minlength="6">
            <asp:CompareValidator ID="CompareValidator1" runat="server" ValidationExpression="^.{6,16}$ " ControlToCompare="TextBox2" ControlToValidate="TextBox3" ErrorMessage="CompareValidator" ForeColor="Red">*请再次输入密码两次密码不一致</asp:CompareValidator>
        </div>
        <br />
        <div class="register-hidden-gruop">
            <div class="center_div pc-register-descript ">
                <label>
                    <asp:CheckBox ID="CheckBox1" runat="server" Text="我已同意" />
                    <a target="_blank">《电影天堂用户使用协议》</a>和<a>《电影天堂账号中心规范》</a>
                </label>
            </div>
        </div>
        <br />
        <%-- <input runat="server" ID="Button1" style="border-style: solid; border-color: inherit;background-color:dodgerblue;color:white; width: 289px; height: 39px;"
        type="submit" value="注册" class="next_step center_div mar_t_120 ys-a" OnClick="Button1_Click">--%>
        <asp:Button runat="server" ID="Button2" Style="border-style: solid; border-radius: 5px; border-color: inherit; background-color: dodgerblue; color: white; width: 289px; height: 39px;"
            type="submit" Text="注册" class="next_step center_div mar_t_120 ys-a" OnClick="Register_Click" />
    </div>
</asp:Content>
