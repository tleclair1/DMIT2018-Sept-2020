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

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<TrackItem> Track_List()
        {
            using (var context = new ChinookSystemContext())
            {
                var results = from x in context.Tracks
                              select new TrackItem
                              {
                                  TrackId = x.TrackId,
                                  Name = x.Name,
                                  AlbumId = x.Album.AlbumId,
                                  MediaTypeId = x.MediaType.MediaTypeId,
                                  GenreId = x.Genre.GenreId,
                                  Composer = x.Composer,
                                  Milliseconds = x.Milliseconds,
                                  Bytes = x.Bytes,
                                  UnitPrice = x.UnitPrice
                              };
                return results.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public TrackItem Track_Find(int trackid)
        {
            using (var context = new ChinookSystemContext())
            {
                var results = (from x in context.Tracks
                               where x.TrackId == trackid
                               select new TrackItem
                               {
                                   TrackId = x.TrackId,
                                   Name = x.Name,
                                   AlbumId = x.Album.AlbumId,
                                   MediaTypeId = x.MediaType.MediaTypeId,
                                   GenreId = x.Genre.GenreId,
                                   Composer = x.Composer,
                                   Milliseconds = x.Milliseconds,
                                   Bytes = x.Bytes,
                                   UnitPrice = x.UnitPrice
                               }).FirstOrDefault();
                return results;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<TrackItem> Track_GetByAlbumId(int albumid)
        {
            using (var context = new ChinookSystemContext())
            {
                var results = (from x in context.Tracks
                               where x.AlbumId == albumid
                               select new TrackItem
                               {
                                   TrackId = x.TrackId,
                                   Name = x.Name,
                                   AlbumId = x.Album.AlbumId,
                                   MediaTypeId = x.MediaType.MediaTypeId,
                                   GenreId = x.Genre.GenreId,
                                   Composer = x.Composer,
                                   Milliseconds = x.Milliseconds,
                                   Bytes = x.Bytes,
                                   UnitPrice = x.UnitPrice
                               });
                return results.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<TrackList> List_TracksForPlaylistSelection(string tracksby, string arg)
        {
            using (var context = new ChinookSystemContext())
            {
                //var results = from x in context.Tracks
                    //          where   (x.Album.Artist.Name.Contains(arg) && tracksby.Equals("Artist")) || 
                    //                  (x.Album.Title.Contains(arg) && tracksby.Equals("Album"))
                    //          orderby x.Album.Artist.Name, x.Album.Title, x.Name
                    //          select new TrackList
                    //          {
                    //              TrackID = x.TrackId,
                    //              Name = x.Name,
                    //              Title = x.Album.Title,
                    //              ArtistName = x.Album.Artist.Name,
                    //              MediaName = x.MediaType.Name,
                    //              GenreName = x.Genre.Name,
                    //              Composer = x.Composer,
                    //              Milliseconds = x.Milliseconds,
                    //              Bytes = x.Bytes,
                    //              UnitPrice = x.UnitPrice
                    //          };
                IEnumerable<TrackList> results = null;
                if (tracksby.Equals("Artist"))
                {
                    results = from x in context.Tracks
                              where x.Album.Artist.Name.Contains(arg)
                              orderby x.Album.Artist.Name, x.Name
                              select new TrackList
                              {
                                  TrackID = x.TrackId,
                                  Name = x.Name,
                                  Title = x.Album.Title,
                                  ArtistName = x.Album.Artist.Name,
                                  MediaName = x.MediaType.Name,
                                  GenreName = x.Genre.Name,
                                  Composer = x.Composer,
                                  Milliseconds = x.Milliseconds,
                                  Bytes = x.Bytes,
                                  UnitPrice = x.UnitPrice
                              };
                }
                else if (tracksby.Equals("Album"))
                {
                    results = from x in context.Tracks
                              where x.Album.Title.Contains(arg)
                              orderby x.Album.Title, x.Name
                              select new TrackList
                              {
                                  TrackID = x.TrackId,
                                  Name = x.Name,
                                  Title = x.Album.Title,
                                  ArtistName = x.Album.Artist.Name,
                                  MediaName = x.MediaType.Name,
                                  GenreName = x.Genre.Name,
                                  Composer = x.Composer,
                                  Milliseconds = x.Milliseconds,
                                  Bytes = x.Bytes,
                                  UnitPrice = x.UnitPrice
                              };
                }
                else if (tracksby.Equals("Media Type"))
                {
                    int narg = int.Parse(arg);
                    results = from x in context.Tracks
                              where x.MediaTypeId == narg
                              orderby x.Album.Artist.Name, x.Album.Title, x.Name
                              select new TrackList
                              {
                                  TrackID = x.TrackId,
                                  Name = x.Name,
                                  Title = x.Album.Title,
                                  ArtistName = x.Album.Artist.Name,
                                  MediaName = x.MediaType.Name,
                                  GenreName = x.Genre.Name,
                                  Composer = x.Composer,
                                  Milliseconds = x.Milliseconds,
                                  Bytes = x.Bytes,
                                  UnitPrice = x.UnitPrice
                              };
                }
                else if (tracksby.Equals("Genre"))
                {
                    int narg = int.Parse(arg);
                    results = from x in context.Tracks
                              where x.GenreId == narg
                              orderby x.Album.Artist.Name, x.Album.Title, x.Name
                              select new TrackList
                              {
                                  TrackID = x.TrackId,
                                  Name = x.Name,
                                  Title = x.Album.Title,
                                  ArtistName = x.Album.Artist.Name,
                                  MediaName = x.MediaType.Name,
                                  GenreName = x.Genre.Name,
                                  Composer = x.Composer,
                                  Milliseconds = x.Milliseconds,
                                  Bytes = x.Bytes,
                                  UnitPrice = x.UnitPrice
                              };
                }

                if (results == null)
                {
                    return null;
                }
                else
                {
                    return results.ToList();
                }
                
            }
        }
    }
}
