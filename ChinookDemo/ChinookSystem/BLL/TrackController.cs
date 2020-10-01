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
    public class TrackController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<AlbumTrack> Track_FindByArtist(string artistname)
        {
            using (var context = new ChinookSystemContext())
            {
                var results = from x in context.Tracks
                               where x.Album.Artist.Name.Equals(artistname)
                               orderby x.Name
                               select new AlbumTrack
                               {
                                   Song = x.Name,
                                   Album = x.Album.Title,
                                   Year = x.Album.ReleaseYear,
                                   Length = x.Milliseconds,
                                   Price = x.UnitPrice,
                                   Genre = x.Genre.Name
                               };
                return results.ToList();
            }
        }
    }
}
