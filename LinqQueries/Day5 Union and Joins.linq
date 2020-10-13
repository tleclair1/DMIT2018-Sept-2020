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

//Union
//Will combine 2 or more queries into one result
//each query needs to have the same number of columns
//each query should have the same associated data within the column
//each query column needs to be the same datatype between queries

//syntax
// (query1).union(query2).union(queryn).OrderBy(first sort).ThenBy(nth sort)
//sorting is done using the column name from the union

//generate a report covering all albums showing their title
//		their track count, the album price, and average track length
// 		order by the number of tracks on album, then by album title
Albums.Count().Dump();

var unionResults = (from x in Albums
					where x.Tracks.Count() > 0
					select new
					{
						Title = x.Title,
						trackCount = x.Tracks.Count(),
						albumPrice = x.Tracks.Sum(y => y.UnitPrice),
						averageLength = x.Tracks.Average(y => y.Milliseconds/1000.0)
					}).Union(	from x in Albums
								where x.Tracks.Count() == 0
								select new
								{
									Title = x.Title,
									trackCount = x.Tracks.Count(),
									albumPrice = 0.00m,
									averageLength = 0.0
								}).OrderBy(y => y.trackCount).ThenBy(y => y.Title);
//unionResults.Dump();
					
//var unionNoResults = 
					
//unionNoResults.Dump();


//Joins
//Avoid joins if there is an acceptable nav property available
//joins can be used where nav property do not exist
//joins can
//

//syntax
//leftside entity join rightside entity on leftside.pkey == rightside.fkey
//	supportside join processside on supportkey == processkey

//in our question support => artist and the process => album
var joinResults = (	from supportSide in Artists
					join processSide in Albums
					on supportSide.ArtistId equals processSide.ArtistId
					select new
					{
						Title = processSide.Title,
						Year = processSide.ReleaseYear,
						Label = processSide.ReleaseLabel == null ? "Unknow" : processSide.ReleaseLabel,
						Artist = supportSide.Name,
						trackCount = processSide.Tracks.Count()
					});
joinResults.Dump();







