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

//.Distinct()
//Create a list of customer countries

//(from x in Customers
//orderby x.Country
//select x.Country).Distinct()

//boolean filters .Any() and .All()
//.Any() iterates through the entire collection
// if item matches condition, return true

//show genres that have tracks which are not on any playlist

var anyResults = (	from x in Genres
					where x.Tracks.Any(trk => trk.PlaylistTracks.Count() == 0)
					orderby x.Name
					select new 
					{
						genre = x.Name,
						tracksInGenre = x.Tracks.Count(),
						boringTracks = (from y in x.Tracks
										where y.PlaylistTracks.Count() == 0
										select y.Name)
					});
//anyResults.Dump();

//sometimes you have two lists that need too be compared
//usually you're looking for items that are the same (in both collections) or
// 		  you're looking for items that are different
//in either case: you're comparing one collection to a second collection

//we are going to compare the playlistss of two individuals on the database

//obtain list of all playlist tracks for Roberto Almedia (user AlmeidaR)
var almeidar = (from x in PlaylistTracks
				where x.Playlist.UserName.Contains("Almeida")
				select new 
				{
					Song = x.Track.Name,
					Genre = x.Track.Genre.Name,
					Id = x.TrackId
				}).Distinct().OrderBy(x => x.Song);
//almeidar.Dump();

//obtain list of all playlist tracks for Michelle Brooks (user BrooksM)
var brooks = (from x in PlaylistTracks
				where x.Playlist.UserName.Contains("Brooks")
				select new 
				{
					Song = x.Track.Name,
					Genre = x.Track.Genre.Name,
					Id = x.TrackId
				}).Distinct().OrderBy(x => x.Song);
//brooks.Dump();

//start with the comparisons
//list the tracks that both Roberto and Michelle like
//i find it best to think of the collections A and B
//think of processing a for each A, check to see if it is any of B
var likes = almeidar.Where(a => brooks.Any(b => b.Id == a.Id))
					.OrderBy(a => a.Genre)
					.Select(a => a);
//likes.Dump();

//differences
//list Roberto's tracks that Michelle does not have
//find records in collection A that are not in collection B
var almdiff = almeidar.Where(a => !brooks.Any(b => b.Id == a.Id))
					.OrderBy(a => a.Song)
					.Select(a => a);
//almdiff.Dump();

var brodiff = brooks.Where(a => !almeidar.Any(b => b.Id == a.Id))
					.OrderBy(a => a.Song)
					.Select(a => a);
//brodiff.Dump();

//All() method iterates through the entire collection to see all items
//		that match the condtition
// return true or false
//an instance of the collection that receives a true on the condition
// 		is selected for processing
//show genres that have all their tracks appearing at least once on a playlist

var genreTotal = Genres.Count();
genreTotal.Dump();

var popularGenres = (from x in Genres
					where x.Tracks.All(trk => trk.PlaylistTracks.Count() > 0)
					orderby x.Name
					select new
					{
						Genre = x.Name,
						trackNumber = x.Tracks.Count(),
						theTracks = (	from y in x.Tracks
										where y.PlaylistTracks.Count() > 0
										select new
										{
											Song = y.Name
										})
					});
popularGenres.Dump();







