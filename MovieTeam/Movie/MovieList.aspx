<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" EnableEventValidation="True" AutoEventWireup="true" CodeBehind="MovieList.aspx.cs" Inherits="MovieTeam.MovieInfo.MovieList" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%--<script src="http://libs.baidu.com/jquery/1.10.2/jquery.min.js"></script>--%>
    <script src="../Scripts/jquery.jqlouds.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            <%--$("ul.rank_list li:nth-child(odd)").css("background-color", "#B2E0FF");--%>
            var self = $("#movie_rank img");
            $(".rank_list li").hover(function () {
                $(this).addClass('hover_li');
                //$(self).attr("src", );              
                //$(this).find('span').html
            },
                function () { $(this).removeClass('hover_li'); $(self).attr("src", "../Image/Home/HotRight.jpg"); });
        });

        //clouds
        jQuery(function ($) {
            $('#sky').jQlouds({
                wind: true
            });
        });

    </script>

    <style>
       
        .auto-style1 {
            height: 64px;
        }
       
    </style>

    <link rel="stylesheet" href="../App_Themes/MovieList.css" type="text/css" />
    <link rel="stylesheet" href="../App_Themes/NavPager.css" type="text/css" />
    <div id="sky">

        <div class="menu">
            <!-- jquery 2.1~3.0+ -->
            <script type="text/javascript" src="https://cdn.bootcss.com/jquery/2.1.0/jquery.js"></script>
            <!-- inpit/assembly 2.0 +  -->
            <script type="text/javascript" src="http://cdn.cabbagelol.net/inpitassembly/2.7/inpitassembly.js"></script>

            <script>
                function test() {
                    return true;
                }
            </script>
            <div class="table" type="inpit/assembly" formname="table_c">
                <asp:Table ID="Table1" runat="server" CellSpacing="10" CellPadding="10" Width="100%" radio>
                    <asp:TableRow ID="Type">
                        <asp:TableHeaderCell>类型</asp:TableHeaderCell>
                        <asp:TableCell name="c" value="剧情"><asp:Button  CssClass="cell" runat="server" text="剧情" onClick="submit_Click"/></asp:TableCell>
                        <asp:TableCell name="c" value="喜剧"><asp:Button  CssClass="cell" runat="server" text="喜剧" onClick="submit_Click"/></asp:TableCell>
                        <asp:TableCell name="c" value="爱情"><asp:Button  CssClass="cell" runat="server" text="爱情" onClick="submit_Click"/></asp:TableCell>
                        <asp:TableCell name="c" value="动作"><asp:Button  CssClass="cell" runat="server" text="动作" onClick="submit_Click"/></asp:TableCell>
                        <asp:TableCell name="c" value="科幻"><asp:Button  CssClass="cell" runat="server" text="科幻" onClick="submit_Click"/></asp:TableCell>
                        <asp:TableCell name="c" value="惊悚"><asp:Button  CssClass="cell" runat="server" text="惊悚" onClick="submit_Click"/></asp:TableCell>
                        <asp:TableCell name="c" value="恐怖"><asp:Button  CssClass="cell" runat="server" text="恐怖" onClick="submit_Click"/></asp:TableCell>
                        <asp:TableCell name="c" value="动画"><asp:Button  CssClass="cell" runat="server" text="动画" onClick="submit_Click"/></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow ID="Location">
                        <asp:TableHeaderCell>地区</asp:TableHeaderCell>
                        <asp:TableCell name="c" value="美国"><asp:Button  CssClass="cell" runat="server" text="美国" onClick="submit_Click"/></asp:TableCell>
                        <asp:TableCell name="c" value="中国"><asp:Button  CssClass="cell" runat="server" text="中国" onClick="submit_Click"/></asp:TableCell>
                        <asp:TableCell name="c" value="日本"><asp:Button  CssClass="cell" runat="server" text="日本" onClick="submit_Click"/></asp:TableCell>
                        <asp:TableCell name="c" value="英国"><asp:Button  CssClass="cell" runat="server" text="英国" onClick="submit_Click"/></asp:TableCell>
                        <asp:TableCell name="c" value="法国"><asp:Button  CssClass="cell" runat="server" text="法国" onClick="submit_Click"/></asp:TableCell>
                        <asp:TableCell name="c" value="印度"><asp:Button  CssClass="cell" runat="server" text="印度" onClick="submit_Click"/></asp:TableCell>

                    </asp:TableRow>
                    <asp:TableRow ID="Date">
                        <asp:TableHeaderCell>年代</asp:TableHeaderCell>
                        <asp:TableCell name="c" value="2018"><asp:Button  CssClass="cell" runat="server" text="2018" onClick="submit_Click"/></asp:TableCell>
                        <asp:TableCell name="c" value="2017"><asp:Button  CssClass="cell" runat="server" text="2017" onClick="submit_Click"/></asp:TableCell>
                        <asp:TableCell name="c" value="2016"><asp:Button  CssClass="cell" runat="server" text="2016" onClick="submit_Click"/></asp:TableCell>
                        <asp:TableCell name="c" value="2000-2015"><asp:Button  CssClass="cell" runat="server" text="2000-2015" onClick="submit_Click"/></asp:TableCell>
                        <asp:TableCell name="c" value="90年代"><asp:Button  CssClass="cell" runat="server" text="90年代" onClick="submit_Click"/></asp:TableCell>
                        <asp:TableCell name="c" value="80年代"><asp:Button  CssClass="cell" runat="server" text="80年代" onClick="submit_Click"/></asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </div>
        </div>

        <div class="cols">
            <div class="rank" id="movie_rank">
                <img src="../Image/Home/HotRight.jpg" class="auto-style1" />
                <div class="rank_list">
                    <asp:ListView ID="ListView2" runat="server" DataKeyNames="M_Id" DataSourceID="SqlDataSource1">
                        <EmptyDataTemplate>
                            <span>未返回数据。</span>
                        </EmptyDataTemplate>

                        <ItemTemplate>
                            <li style="">
                                <em><%# Eval("num") %></em>
                                <asp:HyperLink runat="server" NavigateUrl='<%# "~/Movie/MovieInfo.aspx?id="+ DataBinder.Eval(Container.DataItem,"M_Id") %>'>
                                    <%# Eval("M_Name") %>
                                </asp:HyperLink>
                                <span>
                                    <%# Eval("M_Frequency") %>
                                </span>
                                <asp:HiddenField ID="PictureField" runat="server" Value='<%# Eval("M_Picture") %>' />
                            </li>
                        </ItemTemplate>
                        <LayoutTemplate>
                            <div style="" id="itemPlaceholderContainer" runat="server">
                                <span runat="server" id="itemPlaceholder" />
                            </div>
                            <div style="">
                            </div>
                        </LayoutTemplate>

                    </asp:ListView>

                    <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                        SelectCommand="SELECT top 5 ROW_NUMBER() over( ORDER BY [M_Frequency] DESC) as num,[M_Id], [M_Name], [M_Frequency], [M_Picture] FROM [Movie]"></asp:SqlDataSource>
                </div>

            </div>
            <div class="list_view">
                <asp:ListView ID="ListView1" runat="server" GroupItemCount="3" OnPagePropertiesChanging="ListView1_PagePropertiesChanging">
                    <EmptyDataTemplate>
                        <table style="" runat="server">
                            <tr>
                                <td>未返回数据。</td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>

                    <EmptyItemTemplate>
                        <td runat="server" />
                    </EmptyItemTemplate>
                    <GroupTemplate>
                        <tr id="itemPlaceholderContainer" runat="server">
                            <td id="itemPlaceholder" runat="server"></td>
                        </tr>
                    </GroupTemplate>
                    <ItemTemplate>
                        <td runat="server" style="padding: 0px 25px">
                            <div style="margin: 0px 5% 15px 10%;">
                                <asp:HyperLink runat="server" NavigateUrl='<%# "~/Movie/MovieInfo.aspx?id="+ DataBinder.Eval(Container.DataItem,"M_Id") %>'>
                                    <asp:Image ID="M_PictureLabel" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem,"M_Picture") %>' Width="240px" Height="360px" />
                                    <div>
                                        <p style="">
                                            <asp:Label ID="M_NameLabel" runat="server" Style="position: relative; font-size: large; font-weight: bold" Text='<%# DataBinder.Eval(Container.DataItem,"M_Name") %>' />
                                            <asp:Label ID="M_GradeLabel" runat="server" Style="float: right; font-size: medium;color:red;" Text='<%# DataBinder.Eval(Container.DataItem,"M_Grade","{0:F1}") %>' />
                                        </p>
                                        <p style="">
                                            <asp:Label ID="Dr_IdLabel" runat="server" Style="position: relative; font-size: medium;" Text='<%# DataBinder.Eval(Container.DataItem,"M_Type") %>' />
                                            <asp:Label ID="Ac_IdLabel" runat="server" Style="font-size: medium;" Text='<%# DataBinder.Eval(Container.DataItem,"M_Area") %>' />
                                        </p>
                                    </div>
                                </asp:HyperLink></div></td></ItemTemplate><LayoutTemplate>
                        <table runat="server">
                            <tr runat="server">
                                <td runat="server">
                                    <table id="groupPlaceholderContainer" runat="server" border="0" style="">
                                        <tr id="groupPlaceholder" runat="server">
                                        </tr>
                                    </table>
                                </td>
                            </tr>

                        </table>
                    </LayoutTemplate>

                </asp:ListView>
                <asp:DataPager ID="DataPager1" class="nav-pager" runat="server" PageSize="6" PagedControlID="ListView1">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonType="Image" ShowFirstPageButton="False" ShowNextPageButton="False" ShowPreviousPageButton="True" ButtonCssClass="btn" PreviousPageImageUrl="../Image/MovieInfo/navigate_previous.png" />
                        <asp:NumericPagerField />
                        <asp:NextPreviousPagerField ButtonType="Image" ShowLastPageButton="False" ShowNextPageButton="True" ShowPreviousPageButton="False" ButtonCssClass="btn" NextPageImageUrl="../Image/MovieInfo/navigate_next.png" />
                    </Fields>
                </asp:DataPager>
            </div>
        </div>

    </div>



</asp:Content>
