<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShoppingCar.aspx.cs" Inherits="MovieTeam.Account.ShoppingCar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="text-align:left">
        <link rel="stylesheet" href="../App_Themes/Home.css" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../App_Themes/component.css" />
<link rel="stylesheet" type="text/css" href="../App_Themes/StyleSheet1.css" />
        <div id="J_Header" class="header tb-header">
            <h1 class="cart-logo">
            <br />
                    <a style="font-size: 38px;font-family:华文彩云;color:azure" href=""  target="_top">租赁电影<span></span></a>
                    
        </h1>
        <p class="cart-logo">
                    <asp:TextBox ID="TextBox1" runat="server" placeholder="请输入您想购买的电影名" style="border-style: solid;border-radius:5px;" Height="29px" Width="312px"></asp:TextBox>
                    <asp:Button ID="Button1" runat="server" style="border-style: solid;border-radius:5px;" Text="搜索影片" Height="28px" Width="99px" />
        </p>
        </div>
        <div style="width:1400px;margin:0px auto">
            <a style="font-size: 18px;font-family:华文琥珀;color:azure" href=""  target="_top">你的购物车如下:<span></span></a>
            <asp:GridView  style="text-align:center" ID="GridView2" runat="server"  CellPadding="4" ForeColor="#333333" AutoGenerateColumns="False" OnRowDeleting="GridView2_RowDeleting">
                 <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                <asp:BoundField DataField="S_Id" HeaderText="租赁编号" ReadOnly="True" />
                <asp:BoundField DataField="U_Id" HeaderText="用户编号" ReadOnly="True" />
                    <asp:BoundField DataField="M_Id" HeaderText="电影编号" ReadOnly="True" />
                <asp:BoundField DataField="M_Name" HeaderText="电影名" ReadOnly="True" />
                <asp:BoundField DataField="M_eName" HeaderText="电影英文名" ReadOnly="True" />
                <asp:ImageField HeaderText="电影图片" ReadOnly="True" DataImageUrlField="M_Picture" ControlStyle-Height="100px" ControlStyle-Width="100px">
<ControlStyle Height="100px" Width="100px"></ControlStyle>
                </asp:ImageField>
                <asp:BoundField DataField="M_Intro" HeaderText="电影简介" ReadOnly="True" />
                <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />  
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
            <br />
        </div>
     <br />
        <a href="" style="font-size: 18px;font-family:华文琥珀;color:azure" target="_top">租赁时长:</a><br />
        <asp:Button ID="Button2" runat="server" style="border-style: solid;border-radius:5px; border-color: inherit;background-color:cornflowerblue;color:white; " Text="一天（需要用户等级1）" Height="27px" Width="155px" OnClick="Button2_Click" />
        &nbsp;<asp:Button ID="Button3" runat="server" style="border-style: solid;border-radius:5px; border-color: inherit;background-color:cornflowerblue;color:white; " Text="一周（需要用户等级2）" Height="27px" Width="155px" OnClick="Button3_Click" />
        &nbsp;<asp:Button ID="Button4" runat="server" style="border-style: solid;border-radius:5px; border-color: inherit;background-color:cornflowerblue;color:white; " Text="一月（需要用户等级3）" Height="27px" Width="155px" OnClick="Button4_Click" />
        </div>
    <br />
    <br />
<a style="font-size: 30px;font-family:华文彩云;color:azure" href=""  target="_top">猜您喜欢：<span></span></a>
            <div class="J_banner J_banner2" style="text-align:left">
                <ul class="img">
                    <li><a href="">
                        <img src="../Image/Home/1.jpg" alt=""></a></li>
                    <li><a href="">
                        <img src="../Image/Home/2.jpg" alt=""></a></li>
                    <li><a href="">
                        <img src="../Image/Home/3.jpg" alt=""></a></li>
                </ul>
                <ul class="pointer"></ul>
                <a class="cut prev"><</a>
                <a class="cut next">></a>
            </div>

   <a style="font-size: 18px;font-family:华文琥珀;color:azure" href=""  target="_top">全部商品:<span></span></a>
    <br />

    <div style="width:1400px;margin:0px auto">
        &nbsp; <asp:GridView  style="text-align:center" ID="GridView1" runat="server"  CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" AutoGenerateColumns="False" Width="1152px" AllowPaging="True" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="M_Id" HeaderText="编号" ReadOnly="True" />
                <asp:BoundField DataField="M_Name" HeaderText="电影名" />
                <asp:BoundField DataField="M_eName" HeaderText="电影英文名" />
                <asp:ImageField HeaderText="电影图片" ReadOnly="True" DataImageUrlField="M_Picture" ControlStyle-Height="100px" ControlStyle-Width="100px">
<ControlStyle Height="100px" Width="100px"></ControlStyle>
                </asp:ImageField>
                <asp:BoundField DataField="M_Grade" HeaderText="评分" />
                <asp:BoundField DataField="M_Type" HeaderText="电影类型 " />
                <asp:BoundField DataField="M_Area" HeaderText="电影地区" />
                <asp:BoundField DataField="M_Date" HeaderText="出版日期" />
                <asp:BoundField DataField="M_Intro" HeaderText="电影简介" />
                <asp:BoundField DataField="M_Stock" HeaderText="存货" />
                <asp:CommandField HeaderText="添加到购物车" SelectText="添加到购物车" ShowSelectButton="True" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
     <script src="../Scripts/jquery-1.10.2.min.js"></script>
    <script src="../Scripts/Myapi.js"></script>
    <script src="../Scripts/Layout/jquery.easing.min.js"></script>
    <script src="../Scripts/Layout/waypoints.min.js"></script>
    <script src="../Scripts/Layout/jquery.debouncedresize.js"></script>
    <script src="../Scripts/Layout/cbpFixedScrollLayout.min.js"></script>
    <script src="../Scripts/Layout/modernizr.custom.js"></script>
    <script>
        $(function () {
            var Ad = new Myapi();
            Ad.JSON.lagout($('.J_banner2'), 2000, 10);
            cbpFixedScrollLayout.init();
        });
    </script>
            <br />
        </div>
</asp:Content>
