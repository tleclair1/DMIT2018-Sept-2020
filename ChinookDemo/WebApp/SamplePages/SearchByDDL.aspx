<%@ Page Title="Search Filter Demo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchByDDL.aspx.cs" Inherits="WebApp.SamplePages.SearchByDDL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Search Albums by Artists</h1>
    <div class="row">
        <asp:Label ID="Label1" runat="server" Text="Select an artist"></asp:Label>&nbsp;&nbsp;
        <asp:DropDownList ID="ArtistList" runat="server"></asp:DropDownList>&nbsp;&nbsp;
        <asp:LinkButton ID="SearchAlbums" runat="server" OnClick="SearchAlbums_Click">Search for Albums</asp:LinkButton>
    </div>
    <br /><br />
    <div class="row">
        <asp:Label ID="MessageLabel" runat="server" ></asp:Label>
    </div>
    <br /><br />
    <div class="row">
        <asp:GridView ID="AlbumArtistList" runat="server" CssClass="table table-striped" GridLines="Horizontal" BorderStyle="None" AutoGenerateColumns="false" OnSelectedIndexChanged="AlbumArtistList_SelectedIndexChanged">
            <Columns>
                <asp:CommandField SelectText="View" ShowSelectButton="True">
                </asp:CommandField>
                <asp:TemplateField HeaderText="ID" Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="AlbumId" Text='<%# Eval("AlbumId") %>' runat="server" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Right"/>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Title">
                    <ItemTemplate>
                        <asp:Label ID="Title" Text='<%# Eval("Title") %>' runat="server" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left"/>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Artist">
                    <ItemTemplate>
                        <%--<asp:Label ID="Label4" Text='<%# Eval("ArtistId") %>' runat="server" />--%>
                        <asp:DropDownList ID="ArtistListGV" runat="server" DataSourceID="ArtistListGVODS" DataTextField="DisplayText" DataValueField="ValueId" SelectedValue='<%# Eval("ArtistId") %>' Width="300px" Enabled="false">
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Released">
                    <ItemTemplate>
                        <asp:Label ID="ReleaseYear" Text='<%# Eval("ReleaseYear") %>' runat="server" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"/>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Label">
                    <ItemTemplate>
                        <asp:Label ID="ReleaseLabel" Text='<%# Eval("ReleaseLabel") %>' runat="server" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left"/>
                </asp:TemplateField>
            </Columns>
            <Columns>

            </Columns>   
        </asp:GridView>
    </div>
    <asp:ObjectDataSource ID="ArtistListGVODS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Artist_List" TypeName="ChinookSystem.BLL.ArtistController" />
</asp:Content>
