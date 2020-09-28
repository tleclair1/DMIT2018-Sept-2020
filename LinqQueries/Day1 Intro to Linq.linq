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

//Comments just like C#
//	Hotkeys for commenting
//	Ctrl + K,C
//	Ctrl + K,U

//There are two styles of coding linq queries
//	Query Syntax (very sql-ish)
//	Method Syntax (very C#-ish)

//In the Expression environment you can code multiple queries BUT you MUST highlight the query to execute (F5)

//In the Statement environment you can code multiple queries as C# statements and run the entire physical file without highlighting the query

//In the Program environment you can code multiple queries AND class definitions or program methods which are tested in a Main() program

//Query Syntax of a query
//The 'from' clause is first and the 'select' clause is last
//from x in Albums
//orderby x.Title ascending
//select x
//
////Method Syntax of a query
//Albums.OrderBy (x => x.Title)

//from x in Albums
//orderby x.ReleaseYear descending, x.Title
//select x
//
//Albums.OrderByDescending(x => x.ReleaseYear).ThenBy (x => x.Title)

//Filtering data
//'where' clause
//List artists with a Q in their name
//from x in Artists
//where x.Name.Contains("Q")
//select x

//Show all Albums releades in the 90's
//from x in Albums
//where x.ReleaseYear >= 1990 && x.ReleaseYear < 2000
//orderby x.ReleaseYear 
//select x

//List all customers who live in the USA and have a yahoo email in alphabetical order by last name
from x in Customers
where x.Country.Equals("USA") && x.Email.Contains("yahoo")
orderby x.LastName
select x


