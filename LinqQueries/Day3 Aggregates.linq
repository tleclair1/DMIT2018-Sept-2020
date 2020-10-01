<Query Kind="Expression">
  <Connection>
    <ID>2e03f501-aa83-4504-8bf6-c799ec726de0</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>.</Server>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>Chinook</Database>
  </Connection>
</Query>

//Aggregates
// .Count(), .Sum(), .Max(), .Min(), .Average()
// all but count require a delegate expression

//from x in Tracks
//select new
//{
//	Name = x.Name,
//	AvgLength = x.Average(x => x.Milliseconds) //Incorrect
//}
//
//(from x in Tracks
//select x.Milliseconds
//).Average()
//
//Tracks.Average(x => x.Milliseconds)

//list all albums showing title, artist name and every aggregate values for albums containing tracks
from x in Albums
where x.Tracks.Count() > 1
select new 
{
	Title = x.Title,
	Artist = x.Artist.Name,
	NumberOfTracks = x.Tracks.Count(),
	AverageTrackLength = x.Tracks.Average(x => x.Milliseconds),
	ShortestTrack = x.Tracks.Min(x => x.Milliseconds),
	LongestTrack = x.Tracks.Max(x => x.Milliseconds),
	AlbumPrice = x.Tracks.Sum(x => x.UnitPrice)
}