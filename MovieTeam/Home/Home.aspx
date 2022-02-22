<%@ Page Title="" Language="C#" MasterPageFile="~/Site_Full.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="MovieTeam.Home.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <link rel="stylesheet" href="../App_Themes/Home.css" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../App_Themes/default.css" />
    <link rel="stylesheet" type="text/css" href="../App_Themes/component.css" />
    <div id="cbp-fbscroller" class="cbp-fbscroller">
        <nav>
            <a href="#fbsection1" class="cbp-fbcurrent">Section 1</a>
            <a href="#fbsection2">Section 2</a>
            <a href="#fbsection3">Section 3</a>
            <a href="#fbsection4">Section 4</a>
            <a href="#fbsection5">Section 5</a>
            <a href="#fbsection6">Section 6</a>
            <a href="#fbsection7">Section 7</a>
            <a href="#fbsection8">Section 8</a>
            <a href="#fbsection9">Section 9</a>

        </nav>
        <section id="fbsection1">
            <h1 style="text-align: left; padding: 100px 0 30px 200px;">热门电影：</h1>
            
            <div class="J_banner J_banner2">
                <ul class="img">
                    <li><a href="../../Movie/MovieInfo?id=30">
                        <img src="../Image/Home/Hot1.jpg" alt="" style="width: 1100px; height: 563px"></a></li>
                    <li><a href="../../Movie/MovieInfo?id=29">
                        <img src="../Image/Home/Hot2.jpg" alt="" style="width: 1100px; height: 563px"></a></li>
                    <li><a href="../../Movie/MovieInfo?id=31">
                        <img src="../Image/Home/Hot3.jpg" alt="" style="width: 1100px; height: 563px"></a></li>
                </ul>
                <ul class="pointer"></ul>
                <a class="cut prev"><</a>
                <a class="cut next">></a>
            </div>
            <br />
        </section>

        <section id="fbsection2">
            <div class="Hot">
                <div class="Action">
                    <div>
                        <div class="M_block">
                            <asp:ImageButton ID="Ac_Ib1" runat="server" Width="350px" Height="525px" CssClass="Movie" />
                        </div>
                        <div class="M_block">
                            <asp:ImageButton ID="Ac_Ib2" runat="server" Width="350px" Height="525px" CssClass="Movie" />
                        </div>
                        <div class="M_block">
                            <asp:ImageButton ID="Ac_Ib3" runat="server" Width="350px" Height="525px" CssClass="Movie" />
                        </div>
                    </div>
                </div>
                <div class="More">
                    <asp:HyperLink runat="server" Font-Size="XX-Large" CssClass="Hover" ForeColor="#ffffff" NavigateUrl="~/Movie/MovieList.aspx?Type=动作">更多动作片</asp:HyperLink>
                </div>

            </div>
        </section>
        <section id="fbsection3">
            <div class="Hot">
                <div class="Comedy">
                    <div>
                        <div class="M_block">
                            <asp:ImageButton ID="Co_Ib1" runat="server" Width="350px" Height="525px" CssClass="Movie" />
                        </div>
                        <div class="M_block">
                            <asp:ImageButton ID="Co_Ib2" runat="server" Width="350px" Height="525px" CssClass="Movie" />
                        </div>
                        <div class="M_block">
                            <asp:ImageButton ID="Co_Ib3" runat="server" Width="350px" Height="525px" CssClass="Movie" />
                        </div>
                    </div>
                </div>
                <div class="More">
                    <asp:HyperLink runat="server" Font-Size="XX-Large" CssClass="Hover" ForeColor="#ffffff" NavigateUrl="~/Movie/MovieList.aspx?Type=喜剧">更多喜剧片</asp:HyperLink>
                </div>
            </div>
        </section>
        <section id="fbsection4">
            <div class="Hot">
                <div class="Romance">
                    <div>
                        <div class="M_block">
                            <asp:ImageButton ID="Ro_Ib1" runat="server" Width="350px" Height="525px" ImageUrl="~/Image/C1.png" CssClass="Movie" />
                        </div>

                        <div class="M_block">
                            <asp:ImageButton ID="Ro_Ib2" runat="server" Width="350px" Height="525px" ImageUrl="~/Image/C2.png" CssClass="Movie" />
                        </div>
                        <div class="M_block">
                            <asp:ImageButton ID="Ro_Ib3" runat="server" Width="350px" Height="525px" ImageUrl="~/Image/C3.png" CssClass="Movie" />
                        </div>
                    </div>
                </div>
                <div class="More">
                    <asp:HyperLink runat="server" Font-Size="XX-Large" CssClass="Hover" ForeColor="#ffffff" NavigateUrl="~/Movie/MovieList.aspx?Type=爱情">更多爱情片</asp:HyperLink>
                </div>
            </div>
        </section>
        <section id="fbsection5">
            <div class="Hot">
                <div class="Science">
                    <div>
                        <div class="M_block">
                            <asp:ImageButton ID="Sc_Ib1" runat="server" Width="350px" Height="525px" ImageUrl="~/Image/C1.png" CssClass="Movie" />
                        </div>

                        <div class="M_block">
                            <asp:ImageButton ID="Sc_Ib2" runat="server" Width="350px" Height="525px" ImageUrl="~/Image/C2.png" CssClass="Movie" />
                        </div>
                        <div class="M_block">
                            <asp:ImageButton ID="Sc_Ib3" runat="server" Width="350px" Height="525px" ImageUrl="~/Image/C3.png" CssClass="Movie" />
                        </div>
                    </div>
                </div>
                <div class="More">
                    <asp:HyperLink runat="server" Font-Size="XX-Large" CssClass="Hover" ForeColor="#ffffff" NavigateUrl="~/Movie/MovieList.aspx?Type=科幻">更多科幻片</asp:HyperLink>
                </div>
            </div>
        </section>
        <section id="fbsection6">
            <div class="Hot">
                <div class="Thriller">
                    <div>
                        <div class="M_block">
                            <asp:ImageButton ID="Th_Ib1" runat="server" Width="350px" Height="525px" ImageUrl="~/Image/C1.png" CssClass="Movie" />
                        </div>
                        <div class="M_block">
                            <asp:ImageButton ID="Th_Ib2" runat="server" Width="350px" Height="525px" ImageUrl="~/Image/C2.png" CssClass="Movie" />
                        </div>
                        <div class="M_block">
                            <asp:ImageButton ID="Th_Ib3" runat="server" Width="350px" Height="525px" ImageUrl="~/Image/C3.png" CssClass="Movie" />
                        </div>
                    </div>
                </div>
                <div class="More">
                    <asp:HyperLink runat="server" Font-Size="XX-Large" CssClass="Hover" ForeColor="#ffffff" NavigateUrl="~/Movie/MovieList.aspx?Type=惊悚">更多惊悚片</asp:HyperLink>

                </div>
            </div>
        </section>
        <section id="fbsection7">
            <div class="Hot">
                <div class="Horror">
                    <div>
                        <div class="M_block">
                            <asp:ImageButton ID="Ho_Ib1" runat="server" Width="350px" Height="525px" ImageUrl="~/Image/C1.png" CssClass="Movie" />
                        </div>

                        <div class="M_block">
                            <asp:ImageButton ID="Ho_Ib2" runat="server" Width="350px" Height="525px" ImageUrl="~/Image/C2.png" CssClass="Movie" />
                        </div>
                        <div class="M_block">
                            <asp:ImageButton ID="Ho_Ib3" runat="server" Width="350px" Height="525px" ImageUrl="~/Image/C3.png" CssClass="Movie" />
                        </div>
                    </div>
                </div>
                <div class="More">
                    <asp:HyperLink runat="server" Font-Size="XX-Large" CssClass="Hover" ForeColor="#ffffff" NavigateUrl="~/Movie/MovieList.aspx?Type=恐怖">更多恐怖片</asp:HyperLink>
                </div>
            </div>
        </section>
        <section id="fbsection8">
            <div class="Hot">
                <div class="Feature">
                    <div>
                        <div class="M_block">
                            <asp:ImageButton ID="Fe_Ib1" runat="server" Width="350px" Height="525px" ImageUrl="~/Image/C1.png" CssClass="Movie" />
                        </div>

                        <div class="M_block">
                            <asp:ImageButton ID="Fe_Ib2" runat="server" Width="350px" Height="525px" ImageUrl="~/Image/C2.png" CssClass="Movie" />
                        </div>
                        <div class="M_block">
                            <asp:ImageButton ID="Fe_Ib3" runat="server" Width="350px" Height="525px" ImageUrl="~/Image/C3.png" CssClass="Movie" />
                        </div>
                    </div>
                </div>
                <div class="More">
                    <asp:HyperLink runat="server" Font-Size="XX-Large" CssClass="Hover" ForeColor="#ffffff" NavigateUrl="~/Movie/MovieList.aspx?Type=剧情">更多剧情片</asp:HyperLink>
                </div>
            </div>
        </section>
        <section id="fbsection9">
            <div class="Hot">
                <div class="Cartoon">
                    <div>
                        <div class="M_block">
                            <asp:ImageButton ID="Ca_Ib1" runat="server" Width="350px" Height="525px" ImageUrl="~/Image/C1.png" CssClass="Movie" />
                        </div>

                        <div class="M_block">
                            <asp:ImageButton ID="Ca_Ib2" runat="server" Width="350px" Height="525px" ImageUrl="~/Image/C2.png" CssClass="Movie" />
                        </div>
                        <div class="M_block">
                            <asp:ImageButton ID="Ca_Ib3" runat="server" Width="350px" Height="525px" ImageUrl="~/Image/C3.png" CssClass="Movie" />
                        </div>
                    </div>
                </div>
                <div class="More">
                    <asp:HyperLink runat="server" Font-Size="XX-Large" CssClass="Hover" ForeColor="#ffffff" NavigateUrl="~/Movie/MovieList.aspx?Type=动画">更多动画片</asp:HyperLink>
                </div>
            </div>
        </section>

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


    </div>
</asp:Content>
