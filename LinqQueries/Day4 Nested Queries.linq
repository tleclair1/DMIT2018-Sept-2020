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

//nested queries

//list all sales support employees showing their fullname (lastname, firstname)
//their title and number of customers each support. order by fullname

//from x in Employees
//where x.Title.Contains("Support")
//orderby x.LastName, x.FirstName
//select new
//{
//	Name = x.LastName + ", " + x.FirstName,
//	Title = x.Title,
//	ClientCount = (	from y in x.SupportRepCustomers
//					select y).Count(),
//	//ClientCount = x.SupportRepCustomers.Count(),
//	Clients = (	from y in x.SupportRepCustomers
//				orderby y.LastName, y.FirstName
//				select new
//				{
//				Name = y.LastName + ", " + y.FirstName,
//				City = y.City,
//				State = y.State
//				})
//	//Clients = (	from y in Customers
//	//			where y.SupportRepId == x.EmployeeId
//	//			orderby y.LastName, y.FirstName
//	//			select new
//	//			{
//	//			Name = y.LastName + ", " + y.FirstName,
//	//			City = y.City,
//	//			State = y.State
//	//			})
//}

//create list of albums showing their title and artist
//show albums 25 or more tracks only
//show the songs on the album (name and length)

//from x in Albums
//where x.Tracks.Count() >= 25
//select new
//{
//	Title = x.Title,
//	Artist = x.Artist.Name,
//	TrackCount = x.Tracks.Count(),
//	Tracks = (	from y in x.Tracks
//				select new 
//				{
//					Name = y.Name,
//					Length = y.Milliseconds
//				})
//}

//Create playlist report that shows playlist name, the number of songs
//the username attached to playlist, and the songs on playlist with their genre

from x in Playlists
select new
{
	Name = x.Name,
	SongCount = x.PlaylistTracks.Count(),
	User = x.UserName,
	Songs = (	from y in x.PlaylistTracks
				select new
				{
					Title = y.Track.Name,
					Genre = y.Track.Genre.Name
				})
}

