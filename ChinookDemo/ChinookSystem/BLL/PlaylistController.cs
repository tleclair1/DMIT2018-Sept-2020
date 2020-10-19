using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using ChinookSystem.DAL;
using ChinookSystem.Entities;
using ChinookSystem.ViewModels;
using System.ComponentModel;
#endregion

namespace ChinookSystem.BLL
{
    [DataObject]
    public class PlaylistController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<PlaylistItem> Playlist_GetPlaylistOfSize(int playlistsize)
        {
            using (var context = new ChinookSystemContext())
            {
                var results = from x in context.Playlists
                              orderby x.UserName
                              where x.PlaylistTracks.Count() == playlistsize
                              select new PlaylistItem
                              {
                                  Name = x.Name,
                                  SongCount = x.PlaylistTracks.Count(),
                                  UserName = x.UserName,
                                  Songs = (from y in x.PlaylistTracks
                                           orderby y.Track.Genre.Name, y.Track.Name
                                           select new PlaylistSong
                                           {
                                               Song = y.Track.Name,
                                               Genre = y.Track.Genre.Name
                                           })
                              };
                return results.ToList();
            }
        }
    }
}
