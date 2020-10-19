<Query Kind="Program">
  <Connection>
    <ID>2e03f501-aa83-4504-8bf6-c799ec726de0</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>.</Server>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>Chinook</Database>
  </Connection>
</Query>

void Main()
{
	//Create playlist report that shows playlist name, the number of songs
	//the username attached to playlist, and the songs on playlist with their genre
	
	var lowestPlaylistSize = 20;
	var results = 	from x in Playlists
					orderby x.UserName
					where x.PlaylistTracks.Count() >= lowestPlaylistSize
					select new PlaylistItem
					{
						Name = x.Name,
						SongCount = x.PlaylistTracks.Count(),
						UserName = x.UserName,
						Songs = (	from y in x.PlaylistTracks
									orderby y.Track.Genre.Name, y.Track.Name
									select new PlaylistSong
									{
										Song = y.Track.Name,
										Genre = y.Track.Genre.Name
									})
					};
	results.Dump();
}

// You can define other methods, fields, classes and namespaces here

public class PlaylistSong 
{
	public string Song { get; set; }
	public string Genre { get; set; }
}

public class PlaylistItem 
{
	public string Name { get; set; }
	public int SongCount { get; set; }
	public string UserName { get; set; }
	public IEnumerable<PlaylistSong> Songs { get; set; }
}

















