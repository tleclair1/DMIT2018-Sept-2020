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

//Grouping 

//basically, grouping is the technique of placing a large
//pile of data into a smaller piles of data depending on 
//a criteria

//nav properties allow for natural grouping of parent to child (pkey/fkey) collections
//pinstance.childnavproperty.Count() counts all the child records associated with the parent instance

//problem: what if there is no nav property for the grouping of the data collection

//here you can use the group clause to create a set of smaller collections based on the desired criteria

//it is important to remember that once the smaller groups are created, all reporting must use the smaller groups as the collection reference

//grouping is not the same as ordering

//syntax
//group instance by criteria [into group reference name]

//the instance is one record from the original pile of data
//the criteria can be:
//	a) a signle attribute ...
//	b) multiple attributes new{...,...,...}
//	c) a class name

//if you wish to do processing on the smaller group
//you will place the grouping results into a smaller
//pile of data referenced by a specified name

//groups have 2 componenets
//	a) key component
//	b) data component

//report albums by ReleaseYear showing the year and the number of albums for the year.
//Order by the most albums, then by the year within count.

//group query process
//	a) create and display the grouping

//from x in Albums
//group x by x.ReleaseYear into gYear
//select gYear

//	b) create the reporting row for a group

//from x in Albums
//group x by x.ReleaseYear into gYear
//select new
//{
//	Year = gYear.Key,
//	albumCount = gYear.Count()
//}

//	c) complete any additional report customization

//from x in Albums
//group x by x.ReleaseYear into gYear
//orderby gYear.Count() descending, gYear.Key
//select new
//{
//	Year = gYear.Key,
//	albumCount = gYear.Count()
//}

//report albums by ReleaseYear showing the year and the number of albums for the year.
//Order by the most albums, then by the year within count.
//Report the album title, artist name and number of album tracks. report only albums from 90s

//from x in Albums
////where x.ReleaseYear > 1989 && x.ReleaseYear < 2000
//group x by x.ReleaseYear into gYear
//where gYear.Key > 1989 && gYear.Key < 2000
//orderby gYear.Count() descending, gYear.Key
//select new
//{
//	Year = gYear.Key,
//	albumCount = gYear.Count(),
//	albumData = from y in gYear
//				select new
//				{
//					Title = y.Title,
//					Artist = y.Artist.Name,
//					trackCount = y.Tracks.Count(trk => trk.AlbumId == y.AlbumId)
//				}
//}

//list tracks for albums produced after 2010 by genre name. count tracks for the name

//from x in Tracks
//group x by x.Genre.Name into gTrack
//select gTrack

//

//from x in Tracks
//where x.Album.ReleaseYear > 2010
//group x by x.Genre.Name into gTrack
//select new
//{
//	Genre = gTrack.Key,
//	Count = gTrack.Count()
//}

//same report but using entity as the group

//from x in Tracks
//where x.Album.ReleaseYear > 2010
//group x by x.Genre into gTrack
//select new
//{
//	Genre = gTrack.Key.Name,
//	Count = gTrack.Count()
//}


//question
from x in Customers
where x.SupportRep != null
group x by x.SupportRep into gEmpSup
select new
{
	Employee = gEmpSup.Key.LastName + ", " + gEmpSup.Key.FirstName + " ("+ gEmpSup.Key.Phone + ")",
	customerCount = gEmpSup.Count(),
	customerList = 	from customer in gEmpSup
					orderby customer.State, customer.City
					select new
					{
						State = customer.State == null ? "--" : customer.State,
						City = customer.City,
						Name = customer.LastName + ", " + customer.FirstName
					}
}




















