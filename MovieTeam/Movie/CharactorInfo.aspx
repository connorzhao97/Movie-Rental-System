<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CharactorInfo.aspx.cs" Inherits="MovieTeam.Movie.CharactorInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link rel="stylesheet"  type="text/css" href="../App_Themes/Charactor.css" />
    <div class="bodybg"></div>
    <div class="shadow">
        <div class="topcont">
            <div class="Cha_head">
                <div class="coverout">
                    <div class="coverinner">
                        <div class="coverpicbox">
                            <div class="cover">
                                <asp:Image ID="Cha_Image" runat="server" Height="405px" Width="270px" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="ihead" style="height: 500px">
                    <div class="head">
                        <div class="clearfix">
                            <h2 id="chname" style="font-size: 36px; font-weight: bold" runat="server"></h2>
                            <p id="enname" style="font-size: 30px;" runat="server"></p>
                        </div>
                    </div>
                    <div class="base">
                        <dl>
                            <dd style="left: 0px; top: 0px; width: 561px">
                            <strong>个人简介：</strong>
                                <asp:Label ID="Cha_Intro" runat="server"></asp:Label>
                        </dd>
                        </dl>                   
                    </div>
                </div>
                <div class="otherMovie">
                    <p style="font-size:30px;padding-left:15px;color:white">相关电影：</p>
                    <div class="Other">
                        <asp:ImageButton ID="OtherMovie1" runat="server" Height="400px" Width="270px" Visible="True"/>
                    
                    </div>
                    <div class="Other">
                        <asp:ImageButton ID="OtherMovie2" runat="server" Height="400px" Width="270px" Visible="False" />
                    </div>
                    <div class="Other">
                        <asp:ImageButton ID="OtherMovie3" runat="server" Height="400px" Width="270px" Visible="False" />
                    </div>
                    
                </div>
            </div>
        </div>
    </div>
</asp:Content>
