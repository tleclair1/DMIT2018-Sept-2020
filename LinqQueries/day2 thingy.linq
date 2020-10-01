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
	var results = BLL_Query("AC/DC");
	results.Dump();
}

public class AlbumTrack 
{
	public string Song {get; set;}
	public string Album {get; set;}
	public int Year {get; set;}
	public int Length {get; set;}
	public decimal Price {get; set;}
	public string Genre {get; set;}
}

public List<AlbumTrack> BLL_Query(string artistname)
{
var results = (from x in Tracks
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
					});
return results.ToList();
}

// Define other methods, classes and namespaces here
