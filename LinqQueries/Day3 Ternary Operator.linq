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

//condition statement using if
//if (condition)
//{
//	true path
//}
//else
//{
//	false path
//}

////ternary operator
//condition(s) ? true value : false value

////nested ternary operator
//condition(s) ? condition(s) ? true value : false : condition(s) ? true value : condition(s) ? true value : false value

//list all albums by release label. any album with no label should be indicated as unknown. list title and label
//var results = 	from x in Albums
//				orderby x.ReleaseLabel
//				select new
//				{
//					Title = x.Title,
//					Label = x.ReleaseLabel != null ? x.ReleaseLabel : "Unknown"
//				};
//results.Dump();

//list all albums showing their title, artistname, and decade. order by artist.
//var results = 	from x in Albums
//				orderby x.Artist.Name
//				select new
//				{
//					Title = x.Title,
//					Artist = x.Artist.Name,
//					Year = x.ReleaseYear,
//					Decade = x.ReleaseYear < 1970 ? "Oldies" : 
//							 x.ReleaseYear < 1980 ? "70's" : 
//							 x.ReleaseYear < 1990 ? "80's" : 
//							 x.ReleaseYear < 2000 ? "90's" : "Modern"
//				};
//results.Dump();

//list all tracks indicating wether they are longer, shorter or equal to the average of all track lengths
var avgresults = Tracks.Average(x => x.Milliseconds);
var results = 	from x in Tracks
				select new
				{
					Title = x.Name,
					Milliseconds = x.Milliseconds,
					Length = x.Milliseconds > avgresults ? "longer" : x.Milliseconds < avgresults ? "shorter" : "equal"
				};
avgresults.Dump();
results.Dump();