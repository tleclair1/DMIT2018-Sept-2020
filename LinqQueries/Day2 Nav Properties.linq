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

////Query syntax
//from x in Albums
//where x.Artist.Name.Equals("U2")
//orderby x.ReleaseYear, x.Title
//select x
//
////Method syntax
//Albums
//.Where (x => x.Artist.Name.Equals ("AC/DC"))
//.OrderBy (x => x.ReleaseYear)
//.ThenBy (x => x.Title)
//

//List all jazz tracks by name
//from x in Tracks
//where x.Genre.Name.Equals("Jazz")
//orderby x.Name
//select x

//Tracks
//.Where (x => x.Genre.Name.Equals ("Jazz"))
//.OrderBy (x => x.Name)

//List all AC/DC tracks
from x in Tracks
where x.Album.Artist.Name.Equals("AC/DC")
select x