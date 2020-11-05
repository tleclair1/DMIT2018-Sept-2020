using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additonal Namespaces
using ChinookSystem.BLL;
using ChinookSystem.ViewModels;
//using ChinookSystem.BLL;
//using ChinookSystem.Data.POCOs;
//using WebApp.Security;
#endregion

namespace WebApp.SamplePages
{
    public partial class ManagePlaylist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TracksSelectionList.DataSource = null;
        }

        /// <summary>
        /// your MessageUsercontrol ODS methods go here
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void ArtistFetch_Click(object sender, EventArgs e)
        {
            TracksBy.Text = "Artist";
            SearchArg.Text = ArtistName.Text;
            //validate data exist
            if (string.IsNullOrEmpty(ArtistName.Text))
            {
                MessageUserControl.ShowInfo("Search entry error", "Please enter an artist name or partial artist name");
                SearchArg.Text = "ERROR";
            }
            TracksSelectionList.DataBind();
          }

        protected void MediaTypeFetch_Click(object sender, EventArgs e)
        {
            TracksBy.Text = "Media Type";
            SearchArg.Text = MediaTypeDDL.SelectedValue;
            TracksSelectionList.DataBind();

        }

        protected void GenreFetch_Click(object sender, EventArgs e)
        {
            TracksBy.Text = "Genre";
            SearchArg.Text = GenreDDL.SelectedValue;
            TracksSelectionList.DataBind();

        }

        protected void AlbumFetch_Click(object sender, EventArgs e)
        {
            TracksBy.Text = "Album";
            SearchArg.Text = AlbumTitle.Text;
            //validate data exist
            if (string.IsNullOrEmpty(AlbumTitle.Text))
            {
                MessageUserControl.ShowInfo("Search entry error", "Please enter an album name or partial album name");
                SearchArg.Text = "ERROR";
            }
            TracksSelectionList.DataBind();
        }

        protected void PlayListFetch_Click(object sender, EventArgs e)
        {
            string username = "HansenB";
            if (string.IsNullOrEmpty(PlaylistName.Text))
            {
                MessageUserControl.ShowInfo("Missing data", "Please enter the playlist name");
            }
            else
            {
                MessageUserControl.TryRun(() => 
                {
                    PlaylistTracksController sysmgr = new PlaylistTracksController();
                    List<UserPlaylistTrack> info = sysmgr.List_TracksForPlaylist(PlaylistName.Text, username);
                    PlayList.DataSource = info;
                    PlayList.DataBind();
                }, "Playlist","View the current songs on the playlist");
            }

        }

        protected void MoveDown_Click(object sender, EventArgs e)
        {
            //code to go here
            if (string.IsNullOrEmpty(PlaylistName.Text))
            {
                MessageUserControl.ShowInfo("Track movement", "You must have a playlist name");
            }
            else
            {
                if (PlayList.Rows.Count == 0)
                {
                    MessageUserControl.ShowInfo("Track movement", "You must have a playlist displayed");
                }
                else
                {
                    CheckBox selectedSong = null;
                    int selectedRows = 0;
                    int trackid = 0;
                    int tracknumber = 0;
                    for (int index = 0; index < PlayList.Rows.Count; index++)
                    {
                        selectedSong = PlayList.Rows[index].FindControl("Selected") as CheckBox;
                        if (selectedSong.Checked)
                        {
                            selectedRows++;
                            trackid = int.Parse((PlayList.Rows[index].FindControl("TrackId") as Label).Text);
                            tracknumber = int.Parse((PlayList.Rows[index].FindControl("TrackNumber") as Label).Text);
                        }
                    }

                    if (selectedRows != 1)
                    {
                        MessageUserControl.ShowInfo("Track movement", "You must select a single song to move");
                    }
                    else
                    {
                        if (tracknumber == PlayList.Rows.Count)
                        {
                            MessageUserControl.ShowInfo("Track movement", "Song is at the bottom of the list already. Can't move down anymore");
                        }
                        else
                        {
                            MoveTrack(trackid, tracknumber, "down");
                        }
                    }
                }
            }
        }

        protected void MoveUp_Click(object sender, EventArgs e)
        {
            //code to go here
            if (string.IsNullOrEmpty(PlaylistName.Text))
            {
                MessageUserControl.ShowInfo("Track movement","You must have a playlist name");
            }
            else
            {
                if (PlayList.Rows.Count == 0)
                {
                    MessageUserControl.ShowInfo("Track movement","You must have a playlist displayed");
                }
                else
                {
                    CheckBox selectedSong = null;
                    int selectedRows = 0;
                    int trackid = 0;
                    int tracknumber = 0;
                    for (int index = 0; index < PlayList.Rows.Count; index++)
                    {
                        selectedSong = PlayList.Rows[index].FindControl("Selected") as CheckBox;
                        if (selectedSong.Checked)
                        {
                            selectedRows++;
                            trackid = int.Parse((PlayList.Rows[index].FindControl("TrackId") as Label).Text);
                            tracknumber = int.Parse((PlayList.Rows[index].FindControl("TrackNumber") as Label).Text);
                        }
                    }

                    if (selectedRows != 1)
                    {
                        MessageUserControl.ShowInfo("Track movement","You must select a single song to move");
                    }
                    else
                    {
                        if (tracknumber == 1)
                        {
                            MessageUserControl.ShowInfo("Track movement","Song is at the top of the list already. Can't move up anymore");
                        }
                        else
                        {
                            MoveTrack(trackid, tracknumber, "up");
                        }
                    }
                }
            }
        }

        protected void MoveTrack(int trackid, int tracknumber, string direction)
        {
            //call BLL to move track
            string username = "HansenB";
            MessageUserControl.TryRun(() =>
            {
                PlaylistTracksController sysmgr = new PlaylistTracksController();
                sysmgr.MoveTrack(username, PlaylistName.Text, trackid, tracknumber, direction);
                List<UserPlaylistTrack> info = sysmgr.List_TracksForPlaylist(PlaylistName.Text, username);
                PlayList.DataSource = info;
                PlayList.DataBind();
            }, "Track movement","Track has been moved");
        }


        protected void DeleteTrack_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(PlaylistName.Text))
            {
                MessageUserControl.ShowInfo("Track movement", "You must have a playlist name");
            }
            else
            {
                if (PlayList.Rows.Count == 0)
                {
                    MessageUserControl.ShowInfo("Track movement", "You must have a playlist displayed");
                }
                else
                {
                    List<int> trackIds = new List<int>();
                    CheckBox selectedSong = null;
                    int selectedRows = 0;
                    for (int i = 0; i < PlayList.Rows.Count; i++)
                    {
                        selectedSong = PlayList.Rows[i].FindControl("Selected") as CheckBox;
                        if (selectedSong.Checked)
                        {
                            selectedRows++;
                            trackIds.Add(int.Parse((PlayList.Rows[i].FindControl("TrackId") as Label).Text));
                        }
                    }
                    if (selectedRows == 0)
                    {
                        MessageUserControl.ShowInfo("Track removal","You must select at least 1 track to remove");
                    }
                    else
                    {
                        string username = "HansenB";
                        MessageUserControl.TryRun(() =>
                        {
                            PlaylistTracksController sysmgr = new PlaylistTracksController();
                            sysmgr.DeleteTracks(username, PlaylistName.Text, trackIds);
                            List<UserPlaylistTrack> info = sysmgr.List_TracksForPlaylist(PlaylistName.Text, username);
                            PlayList.DataSource = info;
                            PlayList.DataBind();
                        }, "Track removal", "Selected track(s) has been removed from playlist");
                    }
                }
            }
        }

        protected void TracksSelectionList_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            string username = "HansenB";
            if (string.IsNullOrEmpty(PlaylistName.Text))
            {
                MessageUserControl.ShowInfo("Missing Data", "Enter the playlist name");
            }
            else
            {
                MessageUserControl.TryRun(() =>
                {
                    PlaylistTracksController sysmgr = new PlaylistTracksController();
                    sysmgr.Add_TrackToPLaylist(PlaylistName.Text, username, int.Parse(e.CommandArgument.ToString()));
                    List<UserPlaylistTrack> info = sysmgr.List_TracksForPlaylist(PlaylistName.Text, username);
                    PlayList.DataSource = info;
                    PlayList.DataBind();
                }, "Add track to playlist", "Track has been added to the playlist");
            }
            
        }


        #region Error Handling
        protected void SelectCheckForException(object sender,
                                       ObjectDataSourceStatusEventArgs e)
        {
            MessageUserControl.HandleDataBoundException(e);
        }
        protected void InsertCheckForException(object sender,
                                              ObjectDataSourceStatusEventArgs e)
        {
            if (e.Exception == null)
            {
                MessageUserControl.ShowInfo("Success", "Album has been added.");
            }
            else
            {
                MessageUserControl.HandleDataBoundException(e);
            }
        }
        protected void UpdateCheckForException(object sender,
                                               ObjectDataSourceStatusEventArgs e)
        {
            if (e.Exception == null)
            {
                MessageUserControl.ShowInfo("Success", "Album has been updated.");
            }
            else
            {
                MessageUserControl.HandleDataBoundException(e);
            }
        }
        protected void DeleteCheckForException(object sender,
                                                ObjectDataSourceStatusEventArgs e)
        {
            if (e.Exception == null)
            {
                MessageUserControl.ShowInfo("Success", "Album has been removed.");
            }
            else
            {
                MessageUserControl.HandleDataBoundException(e);
            }
        }
        #endregion

    }
}