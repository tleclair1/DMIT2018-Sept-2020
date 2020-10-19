<%@ Page Title="ODS Repeater" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ODSRepeater.aspx.cs" Inherits="WebApp.SamplePages.ODSRepeater" %>

<%@ Register Src="~/UserControls/MessageUserControl.ascx" TagPrefix="uc1" TagName="MessageUserControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Repeater using ODS with Nested Query</h1>
    <div class="row">
        <div class="col-12">
            <uc1:MessageUserControl runat="server" ID="MessageUserControl" />
        </div>
    </div>
    <%-- Setup the parameter serch input area --%>
    <div class="row">
        <div class="offset-1">
            <asp:Label ID="Label1" Text="Enter the desired playlist size:" runat="server" />&nbsp;&nbsp;
            <asp:TextBox ID="PlaylistSizeArg" runat="server" TextMode="Number" step="1" min="0" max="20" placeholder="0" ToolTip="Enter the desired playlist size" />&nbsp;&nbsp;
            <asp:Button ID="Fetch" Text="Fetch" runat="server" CssClass="btn btn-primary" OnClick="Fetch_Click" />
        </div>
    </div>

    <div class="row">
        <div class="offset-2">
            <asp:Repeater ID="ClientPlaylist" runat="server" DataSourceID="ClientPlaylistODS" ItemType="ChinookSystem.ViewModels.PlaylistItem">
                <HeaderTemplate>
                    <h3>Client Playlist</h3>
                </HeaderTemplate>
                <ItemTemplate>
                    <h4>Playlist Name: <%# Item.Name %> (<%# Item.SongCount %>)</h4>
                    <br />
                    <h5>Owner: <%# Item.UserName %></h5>
                    <asp:GridView ID="PlaylistSongsGV" runat="server" DataSource="<%# Item.Songs %>" CssClass="table table-striped" GridLines="Horizontal" BorderStyle="None"></asp:GridView>
                </ItemTemplate>
                <SeparatorTemplate>
                    <hr style="height:5px" />
                </SeparatorTemplate>
                <AlternatingItemTemplate>
                    <h4>Playlist Name: <%# Item.Name %> (<%# Item.SongCount %>)</h4>
                    <br />
                    <h5>Owner: <%# Item.UserName %></h5>
                    <%-- ListView 
                    <asp:ListView ID="PlaylistSongsLV" runat="server" DataSource="<%# Item.Songs %>" ItemType="ChinookSystem.ViewModels.PlaylistSong">
                        <ItemTemplate>
                            <span style="background-color:cyan">
                                <%# Item.Song %> &nbsp;&nbsp; (<%# Item.Genre %>)
                            </span>
                            <br />
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <span style="background-color:silver">
                                <%# Item.Song %> &nbsp;&nbsp; (<%# Item.Genre %>)
                            </span>
                            <br />
                        </AlternatingItemTemplate>
                        <LayoutTemplate>
                            <span runat="server" id="itemPlaceholder">
                            </span>
                        </LayoutTemplate>
                    </asp:ListView>
                    --%>
                    <%-- Repeater 
                    <asp:Repeater ID="PlaylistSongsRP" runat="server" DataSource="<%# Item.Songs %>" ItemType="ChinookSystem.ViewModels.PlaylistSong">
                        <ItemTemplate>
                            <span style="background-color:silver">
                                <%# Item.Song %> &nbsp;&nbsp; (<%# Item.Genre %>)
                            </span>
                            <br />
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <span style="background-color:cyan">
                                <%# Item.Song %> &nbsp;&nbsp; (<%# Item.Genre %>)
                            </span>
                            <br />
                        </AlternatingItemTemplate>
                    </asp:Repeater>
                    --%>
                    <%-- Table Using Repeater --%>
                    <table class="table">
                        <asp:Repeater ID="PlaylistSongsRP" runat="server" DataSource="<%# Item.Songs %>" ItemType="ChinookSystem.ViewModels.PlaylistSong">
                            <ItemTemplate>
                                <tr>
                                    <td style="background-color:silver">
                                        <%# Item.Song %>
                                    </td>
                                    <td style="background-color:silver">
                                        <%# Item.Genre %>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <AlternatingItemTemplate>
                                <tr>
                                    <td style="background-color:cyan">
                                        <%# Item.Song %>
                                    </td>
                                    <td style="background-color:cyan">
                                        <%# Item.Genre %>
                                    </td>
                                </tr>
                            </AlternatingItemTemplate>
                        </asp:Repeater>
                    </table>
                </AlternatingItemTemplate>
            </asp:Repeater>
        </div>
    </div>

    <%-- ODS --%>
    <asp:ObjectDataSource ID="ClientPlaylistODS" runat="server" 
        OldValuesParameterFormatString="original_{0}" 
        SelectMethod="Playlist_GetPlaylistOfSize" 
        TypeName="ChinookSystem.BLL.PlaylistController" 
        OnSelected="SelectCheckForException">
        <SelectParameters>
            <asp:ControlParameter ControlID="PlaylistSizeArg" 
                PropertyName="Text" DefaultValue="0" 
                Name="playlistsize" Type="Int32">
            </asp:ControlParameter>
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
