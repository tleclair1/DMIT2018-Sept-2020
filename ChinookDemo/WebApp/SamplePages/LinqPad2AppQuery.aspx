<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LinqPad2AppQuery.aspx.cs" Inherits="WebApp.SamplePages.LinqPad2AppQuery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Demo of moving LinqPad query to Web App</h1>
    <blockquote>
        This page was used to demo moving a query developped and proven in LinqPad into the web application.
    </blockquote>
    <br />
    <asp:Label ID="Label1" Text="Artist track search:" runat="server" />&nbsp;&nbsp;
    <asp:DropDownList ID="ArtistList" runat="server" DataSourceID="ArtistListODS" DataTextField="DisplayText" DataValueField="DisplayText" AppendDataBoundItems="true">
        <asp:ListItem Value="" Text="select an artist" />
    </asp:DropDownList>&nbsp;&nbsp;
    <asp:LinkButton ID="SearchButton" Text="Search" runat="server" />
    <br />
    <br />
    <asp:GridView ID="TrackList" runat="server" AutoGenerateColumns="False" DataSourceID="TrackListODS" AllowPaging="True" CssClass="table table-striped" GridLines="Horizontal" BorderStyle="None">
        <Columns>
            <asp:BoundField DataField="Song" HeaderText="Song" SortExpression="Song"></asp:BoundField>
            <asp:BoundField DataField="Album" HeaderText="Album" SortExpression="Album"></asp:BoundField>
            <asp:BoundField DataField="Year" HeaderText="Year" SortExpression="Year"></asp:BoundField>
            <asp:BoundField DataField="Length" HeaderText="Length" SortExpression="Length"></asp:BoundField>
            <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price"></asp:BoundField>
            <asp:BoundField DataField="Genre" HeaderText="Genre" SortExpression="Genre"></asp:BoundField>
        </Columns>
        <EmptyDataTemplate>
            No data available for current artist selection
        </EmptyDataTemplate>   
    </asp:GridView>
    <asp:ObjectDataSource ID="ArtistListODS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Artist_List" TypeName="ChinookSystem.BLL.ArtistController" />
    <asp:ObjectDataSource ID="TrackListODS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Track_FindByArtist" TypeName="ChinookSystem.BLL.TrackController">
        <SelectParameters>
            <asp:ControlParameter ControlID="ArtistList" PropertyName="SelectedValue" Name="artistname" Type="String" DefaultValue=""></asp:ControlParameter>
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
