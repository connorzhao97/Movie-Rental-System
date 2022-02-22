<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="MovieInfo.aspx.cs" Inherits="MovieTeam.Movie.MovieInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <link href="../App_Themes/MovieInfo.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Scripts/jquery-1.10.2.min.js">
    </script>
    <script type="text/javascript" src="../Scripts/jquery.raty.min.js"></script>


    <div class="bodybg"></div>
    <div class="shadow"  style="left: 0px; top: 0px; height: 1160px">
        <div class="topcont" style="height: 1155px">
            <div id="head">
                <div class="coverout">
                    <div class="coverinner">
                        <div class="coverpicbox">
                            <div class="cover">
                                <asp:Image ID="M_Image" runat="server" Height="405px" Width="270px" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="ihead">
                    <div class="head">
                        <div class="clearfix">
                            <h1 style="font-size: 35px; font-weight: bold" runat="server" id="M_title"><%= M_Name%> </h1>
                            <p class="year" runat="server" id="year"></p>
                            <div class="otherbox">
                                <span runat="server"><%= M_Length%>分钟 - </span>
                                <a target="_blank" runat="server" id="Type1"></a>

                                <a target="_blank" runat="server" id="Type2" visible="false"></a>

                                <a target="_blank" runat="server" id="Type3" visible="false"></a>
                            </div>
                            <p class="enname" style="font-size: 25px;"><%= M_eName%></p>
                        </div>
                    </div>
                    <div class="base">
                        <dl class="info_l">
                            <dd>
                                <strong>导演：</strong>
                                <asp:LinkButton ID="LinkButtonDirector" runat="server">暂无</asp:LinkButton>
                            </dd>
                            <dd>
                                <strong>主演：</strong>
                                <asp:LinkButton ID="LinkButton1" runat="server">暂无</asp:LinkButton>
                                <asp:Label ID="Label1" runat="server" Text="Label" Visible="False">/</asp:Label>

                                <asp:LinkButton ID="LinkButton2" runat="server" Visible="False"></asp:LinkButton>
                                <asp:Label ID="Label2" runat="server" Text="Label" Visible="False">/</asp:Label>

                                <asp:LinkButton ID="LinkButton3" runat="server" Visible="False"></asp:LinkButton>
                                <asp:Label ID="Label3" runat="server" Text="Label" Visible="False">/</asp:Label>

                                <asp:LinkButton ID="LinkButton4" runat="server" Visible="False"></asp:LinkButton>
                                <asp:Label ID="Label4" runat="server" Text="Label" Visible="False">/</asp:Label>

                                <asp:LinkButton ID="LinkButton5" runat="server" Visible="False"></asp:LinkButton>

                                <asp:LinkButton ID="LBmore" runat="server" OnClick="LBmore_Click" Visible="false">更多...</asp:LinkButton>
                            </dd>
                            <dd>
                                <strong>国家地区：</strong>
                                <a target="_blank" id="Area" runat="server"><%= M_Area%></a>
                            </dd>
                            <dd>
                                <strong>上映日期：</strong>
                                <asp:Label ID="LabelDate" runat="server" Text="Label"><%= M_Date%></asp:Label>
                            </dd>
                            <dd>
                                <strong>剧情：</strong>
                                <p class="mt6 lh18"><%= M_Intro%></p>
                            </dd>

                            <dd>
                                <strong>库存：</strong>
                                <asp:Label ID="LabelStock" runat="server" Text="stock"><%=M_Stock%>/件</asp:Label>
                            </dd>
                            <dt>
                                <asp:Button ID="AddShopping" runat="server" Text="加入购物车" CssClass="AddShopping" Font-Names="Microsoft YaHei UI" OnClick="AddShopping_Click"/>                               
                            </dt>
                        </dl>
                        <div class="info_r">
                            <dd>
                                <strong>电影评分：</strong>
                            </dd>

                            <div>
                                <asp:Label ID="LabelStar" runat="server" CssClass="LabelStar" Font-Bold="True" Font-Italic="True" Font-Size="64px" Font-Strikeout="False" Font-Underline="False"><%=MovieStar %></asp:Label>
                            </div>
                            <div id="MovieStar" style="padding-left: 5px;"></div>
                        </div>
                    </div>
                </div>
                <div class="i_comment">
                    <div id="ratingDownRegion" class="editmpscore">
                        <div class="gradetool">
                            <em class="radius"></em>
                            <div class="clearfix per_userbox new_userbox" style="left: 0px; top: 0px">
                                <div class="per_usergrade">
                                    <div class="mpscore">
                                        <div class="clearfix mdlr">
                                            <div class="mdr">
                                                <div class="looktool">
                                                    <span>我要评分:</span><label id="mystar">1</label>
                                                    <asp:HiddenField ID="HFStar" runat="server" Value="1" />
                                                </div>
                                                <div id="Mystar" data-score="1">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="per_message">
                                            <asp:TextBox ID="TBmessage" runat="server" BackColor="White" Height="70px" TextMode="MultiLine" Width="100%" BorderColor="#CCCCCC" BorderWidth="1px" CssClass="TBmessage" OnFocus="javascript:if(this.value=='请输入您的评论：') {this.value=''}" OnBlur="javascript:if(this.value==''){this.value='请输入您的评论：'}">请输入您的评论：</asp:TextBox>
                                            <div class="per_btn">
                                                <div class="fr">
                                                    <asp:Button ID="Btn_message" runat="server" Text="发表" CssClass="Btn_message" OnClick="Btn_message_Click" />
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="clearfix new_comcont" style="left: 0px; top: 0px">
                        <div class="comment">
                            <dl id="tweetRegion" class="clearfix">
                                <dd>
                                    <div class="mod_comment" id="comment1" runat="server" visible="false">
                                        <h3 id="h3_comment1" runat="server">评论</h3>
                                        <div class="comboxuser">
                                            <div class="pic_58">
                                                <label id="Lb_comment1" runat="server">用户名</label>
                                                <br />
                                                <label style="color: black" id="Lb_Star_comment1" runat="server">分数</label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="mod_comment" id="comment2" runat="server" visible="false">
                                        <h3 id="h3_comment2" runat="server">评论</h3>
                                        <div class="comboxuser">
                                            <div class="pic_58">
                                                <label id="Lb_comment2" runat="server">用户名</label>
                                                <br />
                                                <label style="color: black" id="Lb_Star_comment2" runat="server">分数</label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="mod_comment" id="comment3" runat="server" visible="false">
                                        <h3 id="h3_comment3" runat="server">评论</h3>
                                        <div class="comboxuser">
                                            <div class="pic_58">
                                                <label id="Lb_comment3" runat="server">用户名</label>
                                                <br />
                                                <label style="color: black" id="Lb_Star_comment3" runat="server">分数</label>
                                            </div>
                                        </div>
                                </dd>
                            </dl>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>

    <script type="text/javascript">
        $('#MovieStar').raty({ readOnly: true, number: 10, score:<%=MovieStar%>});
        $('#Mystar').raty({
            half: true,
            number: 10,
            score:1,
            click: function (score) {
                document.getElementById('mystar').innerHTML = score;
                document.getElementById("<%= HFStar.ClientID%>").value = score;
            }
        });
    </script>
</asp:Content>
