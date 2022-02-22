<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangePass.aspx.cs" Inherits="MovieTeam.Account.ChangePass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
               <br />
    <div id="header_bg" style="background-image: url(https://wx3.sinaimg.cn/large/73da5f6bgy1fot9tqzyoyj21kw07nwoj.jpg);"><div id="animate" class="animate" style="font-size: 100px;height: 100px;line-height: 230px;text-shadow: 1px 1px 0 #ff3f1a, -1px -1px 0 #00a7e0;color: #ffffff;text-align: center;"><span style="left: 408.95px;font-family:华文琥珀; opacity: 1; transform: matrix(1, 0, 0, 1, 0, 0);">电影天堂</span></div><a style=" position: absolute; bottom: 0; left: 0; z-index: 1; font-size: 13px; padding: 0 5px; background-color: rgba(0,0,0,0.37); color: #fff;"></a></div>
    <br />
    <br />
    <br />
    <div style="text-align:center">
        <br />
    <div class="title-line"><span class="tit" style="font-size: 38px;font-family:华文彩云;">修改密码</span></div>
        <br />
    <div class="new_phone center_div">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
        <input runat="server" ID="TextBox1" style="border: 1px solid deepskyblue; width: 350px; height: 40px; border-radius:5px;border-color:lightslategrey" type="text" name="uname" placeholder="昵称" class="user_id_password mar_b_40px">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="用户名不能为空" ForeColor="Red">*用户名不能为空！</asp:RequiredFieldValidator>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <input runat="server" ID="TextBox4" required="required" style="border: 1px solid deepskyblue; width: 350px; height: 40px; border-radius:5px;border-color:lightslategrey" type="password" name="userpwd0" placeholder="您的原密码" class="user_id_password" maxlength="16" minlength="6"><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationExpression="^.{6,16}$ " ErrorMessage="RequiredFieldValidator" ControlToValidate="TextBox4" ForeColor="Red">*6-16个字符组成，区分大小写！</asp:RequiredFieldValidator>
        </div>
        <br />
    <div class="center_div">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
        <input runat="server" ID="TextBox2" required="required" style="border: 1px solid deepskyblue; width: 350px; height: 40px; border-radius:5px;border-color:lightslategrey" type="password" name="userpwd" placeholder="新密码（6-16个字符组成，区分大小写）" class="user_id_password" maxlength="16" minlength="6">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationExpression="^.{6,16}$ " ErrorMessage="RequiredFieldValidator" ControlToValidate="TextBox2" ForeColor="Red">*6-16个字符组成，区分大小写！</asp:RequiredFieldValidator>
    </div>
        <br />
        <div class="center_div">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
        <input runat="server" ID="TextBox3" required="required" style="border: 1px solid deepskyblue; width: 350px; height: 40px; border-radius:5px;border-color:lightslategrey" type="password" name="userpwd" placeholder="确认密码（6-16个字符组成，区分大小写）" class="user_id_password" maxlength="16" minlength="6">
            <asp:CompareValidator ID="CompareValidator1" runat="server" ValidationExpression="^.{6,16}$ " ControlToCompare="TextBox2" ControlToValidate="TextBox3" ErrorMessage="CompareValidator" ForeColor="Red">*请再次输入密码两次密码不一致</asp:CompareValidator>
    </div>
        <br />
        <br />
   <%-- <input runat="server" ID="Button1" style="border-style: solid; border-color: inherit;background-color:dodgerblue;color:white; width: 289px; height: 39px;"
        type="submit" value="注册" class="next_step center_div mar_t_120 ys-a" OnClick="Button1_Click">--%>
        <asp:Button  runat="server" ID="Button2" style="border-style: solid;border-radius:5px; border-color: inherit;background-color:dodgerblue;color:white; width: 289px; height: 39px;"
        type="submit" text="修改密码" class="next_step center_div mar_t_120 ys-a" OnClick="ChangePass_Click"/>
        </div>
</asp:Content>
