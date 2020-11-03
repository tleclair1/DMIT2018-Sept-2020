using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using ChinookSystem.ViewModels;
using ChinookSystem.DAL;
using System.ComponentModel;
using ChinookSystem.Entities;
using DMIT2018Common.UserControls;
#endregion

namespace ChinookSystem.BLL
{
    public class PlaylistTracksController
    {
        public List<UserPlaylistTrack> List_TracksForPlaylist(string playlistname, string username)
        {
            using (var context = new ChinookSystemContext())
            {

                var results = from x in context.PlaylistTracks
                              where x.Playlist.Name.Equals(playlistname) &&
                                    x.Playlist.UserName.Equals(username)
                              orderby x.TrackNumber
                              select new UserPlaylistTrack
                              {
                                  TrackID = x.TrackId,
                                  TrackNumber = x.TrackNumber,
                                  TrackName = x.Track.Name,
                                  Milliseconds = x.Track.Milliseconds,
                                  UnitPrice = x.Track.UnitPrice,
                              };

                return results.ToList();
            }
        }//eom
        public void Add_TrackToPLaylist(string playlistname, string username, int trackid)
        {
            using (var context = new ChinookSystemContext())
            {
                //code to go here
                int tracknumber = 0;
                PlaylistTrack newtrack = null;
                List<string> errors = new List<string>();
                Playlist exists = (from x in context.Playlists
                                   where x.Name.Equals(playlistname) && x.UserName.Equals(username)
                                   select x).FirstOrDefault();
                if (exists == null)
                {
                    exists = new Playlist()
                    {
                        Name = playlistname,
                        UserName = username
                    };
                    context.Playlists.Add(exists);
                    tracknumber = 1;
                }
                else
                {
                    newtrack = (from x in context.PlaylistTracks
                                where x.Playlist.Name.Equals(playlistname) && x.Playlist.UserName.Equals(username) && x.TrackId == trackid
                                select x).FirstOrDefault();
                    if (newtrack == null)
                    {
                        tracknumber = (from x in context.PlaylistTracks
                                       where x.Playlist.Name.Equals(playlistname) && x.Playlist.UserName.Equals(username)
                                       select x.TrackNumber).Max();
                        tracknumber++;
                    }
                    else
                    {
                        //throw new Exception("Track already on the playlist. No duplicates allowed");
                        errors.Add("Track already on the playlist. No duplicates allowed");
                    }
                }

                newtrack = new PlaylistTrack();
                newtrack.TrackId = trackid;
                newtrack.TrackNumber = tracknumber;
                exists.PlaylistTracks.Add(newtrack);

                if (errors.Count > 0)
                {
                    throw new BusinessRuleException("Adding a track", errors);
                }
                else
                {
                    context.SaveChanges();
                }
                
             
            }
        }//eom
        public void MoveTrack(string username, string playlistname, int trackid, int tracknumber, string direction)
        {
            using (var context = new ChinookSystemContext())
            {
                //code to go here 
                List<string> errors = new List<string>();
                PlaylistTrack moveTrack = null;
                PlaylistTrack otherTrack = null;
                Playlist exists = (from x in context.Playlists
                                   where x.Name.Equals(playlistname) && x.UserName.Equals(username)
                                   select x).FirstOrDefault();
                if (exists == null)
                {
                    errors.Add("Playlist does not exist");
                }
                else
                {
                    moveTrack = (from x in context.PlaylistTracks
                                 where x.Playlist.Name.Equals(playlistname) && x.Playlist.UserName.Equals(username) && x.TrackId == trackid
                                 select x).FirstOrDefault();
                    if (moveTrack == null)
                    {
                        errors.Add("Playlist track does not exist");
                    }
                    else
                    {
                        if (direction.Equals("up"))
                        {

                        }
                        else
                        {

                        }
                    }
                }

                if (errors.Count > 0)
                {
                    throw new BusinessRuleException("Track movement", errors);
                }
                else
                {
                    //context.SaveChanges();
                }
            }
        }//eom


        public void DeleteTracks(string username, string playlistname, List<int> trackstodelete)
        {
            using (var context = new ChinookSystemContext())
            {
               //code to go here


            }
        }//eom
    }
}
