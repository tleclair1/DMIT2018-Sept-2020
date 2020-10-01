<Query Kind="Statements">
  <Connection>
    <ID>2e03f501-aa83-4504-8bf6-c799ec726de0</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>.</Server>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>Chinook</Database>
  </Connection>
</Query>

//Anonymous Types

//List all track by AC/DC; orderby track name
//Display the track name, the album title, the album release year, track length, price and genre
var results = (from x in Tracks
				where x.Album.Artist.Name.Equals("AC/DC")
				orderby x.Name
				select new 
				{
					Song = x.Name,
					Album = x.Album.Title,
					Year = x.Album.ReleaseYear,
					Length = x.Milliseconds,
					Price = x.UnitPrice,
					Genre = x.Genre.Name
				});
results.Dump();

var results2 = Tracks
   .Where (x => x.Album.Artist.Name.Equals ("AC/DC"))
   .OrderBy (x => x.Name)
   .Select (x => new  
         {
            Song = x.Name, 
            Album = x.Album.Title, 
            Year = x.Album.ReleaseYear, 
            Length = x.Milliseconds, 
            Price = x.UnitPrice, 
            Genre = x.Genre.Name
         });
results2.Dump();