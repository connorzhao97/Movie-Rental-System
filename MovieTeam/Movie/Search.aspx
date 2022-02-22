<%@ Page Title="" Language="C#" MasterPageFile="~/Site_Full.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="MovieTeam.MovieInfo.Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../App_Themes/Search.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../App_Themes/NavPager.css" type="text/css" />
    <div class="search">
        <asp:TextBox ID="SearchInput" runat="server" CssClass="SearchInput"></asp:TextBox>
        <asp:ImageButton ID="SearchBtn" runat="server" ImageUrl="~/Image/MovieInfo/search.png" CssClass="SearchBtn" />
    </div>
    <div class="result">
        <asp:ListView ID="ListView1" runat="server" CellPadding="10" CellSpacing="10" DataKeyField="M_Id" DataSourceID="SqlDataSource1">
            <ItemTemplate>
                <div class="filmscore">
                    <b>评分</b>
                    <p style="color:red"><%#Eval("M_Grade","{0:F1}") %></p>
                </div>
                <h3>
                    <asp:HyperLink Text='<%# Eval("M_Name") %>' runat="server" NavigateUrl='<%# "~/Movie/MovieInfo.aspx?id="+  Eval("M_Id") %>'></asp:HyperLink>
                </h3>
                <div>
                    <asp:HyperLink runat="server" NavigateUrl='<%# "~/Movie/MovieInfo.aspx?id="+  Eval("M_Id") %>' CssClass="pic">
                        <asp:Image runat="server" ImageUrl='<%# Eval("M_Picture") %>' />
                    </asp:HyperLink>
                    <div class="info">
                        <strong>类型：</strong><asp:Label ID="M_TypeLabel" runat="server" Text='<%# Eval("M_Type") %>' ForeColor="#999999" />
                        <strong>地区：</strong><asp:Label ID="M_AreaLabel" runat="server" Text='<%# Eval("M_Area") %>' ForeColor="#999999" /><br />
                        <strong>日期：</strong><asp:Label ID="M_DateLabel" runat="server" Text='<%# Eval("M_Date") %>' ForeColor="#CCCCCC" /><br />
                        <div>
                            <strong>剧情：</strong>
                            <asp:Label  style="padding:5px 0px" ID="M_IntroLabel" runat="server" Text='<%# Eval("M_Intro") %>' ForeColor="#333333" /><br />                        
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:ListView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            SelectCommand="select * from Movie where M_Name like '%' +@name+ '%' or
	M_eName like '%' +@name+ '%' or M_Type like '%' +@name+ '%' or M_Date like '%' +@name+ '%'"
            SelectCommandType="Text">
            <SelectParameters>
                <asp:ControlParameter ControlID="SearchInput" DefaultValue="%" PropertyName="Text" Type="String" Name="name" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
    <br />
    <div>
        <asp:DataPager class="nav-pager" ID="DataPager1" runat="server" PageSize="10" PagedControlID="ListView1">
            <Fields>
                <asp:NextPreviousPagerField ButtonType="Image" ShowFirstPageButton="False" ShowNextPageButton="False" ShowPreviousPageButton="True" ButtonCssClass="btn" PreviousPageImageUrl="../Image/MovieInfo/navigate_previous.png" />
                <asp:NumericPagerField />
                <asp:NextPreviousPagerField ButtonType="Image" ShowLastPageButton="False" ShowNextPageButton="True" ShowPreviousPageButton="False" ButtonCssClass="btn" NextPageImageUrl="../Image/MovieInfo/navigate_next.png" />
            </Fields>
        </asp:DataPager>

    </div>
</asp:Content>
