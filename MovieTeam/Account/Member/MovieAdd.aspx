<%@ Page Title="" Language="C#" MasterPageFile="~/Account/Member/Member.master" AutoEventWireup="true" CodeBehind="MovieAdd.aspx.cs" Inherits="MovieTeam.Account.Member.MovieAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MemberContent" runat="server">
    
    <asp:Label ID="Label_name" runat="server" Text="电影名称："></asp:Label>
    <asp:TextBox ID="TextBox_name" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox_name" ErrorMessage="电影名不能为空" ForeColor="Red">*电影名不能为空！</asp:RequiredFieldValidator>
    <hr />
    <asp:Label ID="Label_Ename" runat="server" Text="电影英文："></asp:Label>
    <asp:TextBox ID="TextBox_Ename" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TextBox_Ename" ErrorMessage="电影英文名不能为空" ForeColor="Red">*电影英文名不能为空！</asp:RequiredFieldValidator>
    <hr />
    <asp:Label ID="Label_grade" runat="server" Text="电影评分："></asp:Label>
    <asp:TextBox ID="TextBox_grade" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox_grade" ErrorMessage="电影评分不能为空" ForeColor="Red">*电影评分不能为空！</asp:RequiredFieldValidator>
    <hr />
    <asp:Label ID="Label_Length" runat="server" Text="电影时长："></asp:Label>
    <asp:TextBox ID="TextBox_length" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TextBox_length" ErrorMessage="电影时长不能为空" ForeColor="Red">*电影时长不能为空！</asp:RequiredFieldValidator>
    <hr />
    <asp:Label ID="Label_type" runat="server" Text="电影类型："></asp:Label>
    <asp:TextBox ID="TextBox_type" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox_type" ErrorMessage="电影类型不能为空" ForeColor="Red">*电影类型不能为空！</asp:RequiredFieldValidator>
    
    <hr />
    <asp:Label ID="Label_area" runat="server" Text="电影地区："></asp:Label>
    <asp:TextBox ID="TextBox_area" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox_area" ErrorMessage="电影地区不能为空" ForeColor="Red">*电影地区不能为空！</asp:RequiredFieldValidator>
    
    <hr />
    <asp:Label ID="Label_date" runat="server" Text="发布时间："></asp:Label>
    <asp:TextBox ID="TextBox_date" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="TextBox_date" ErrorMessage="发布时间不能为空" ForeColor="Red">*发布时间不能为空！</asp:RequiredFieldValidator>
    
    <hr />
    <asp:Label ID="Label_stock" runat="server" Text="电影库存："></asp:Label>
    <asp:TextBox ID="TextBox_stock" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox_stock" ErrorMessage="电影库存不能为空" ForeColor="Red">*电影库存不能为空！</asp:RequiredFieldValidator>
    
    <hr />
    <asp:Label ID="Label_intro" runat="server" Text="电影简介："></asp:Label>
    <asp:TextBox ID="TextBox_intro" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox_intro" ErrorMessage="电影简介不能为空" ForeColor="Red">*电影简介不能为空！</asp:RequiredFieldValidator>
    
    <hr />
    <asp:Label ID="Label_pic" runat="server" Text="电影图片："></asp:Label>
    <asp:FileUpload ID="FileUpload_pic" runat="server" />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="FileUpload_pic" ErrorMessage="电影图片不能为空" ForeColor="Red">*电影图片不能为空！</asp:RequiredFieldValidator>
    
<%--    <asp:Button ID="Button_pic" runat="server" Text="上传" OnClick="Button_pic_Click" />--%>
    
    <hr />
    <asp:Button ID="Button_insert" runat="server" Text="确认添加" OnClick="Button_insert_Click" />
</asp:Content>
