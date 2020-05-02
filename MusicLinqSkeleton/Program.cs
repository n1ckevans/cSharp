using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
  public class Program
  {
    public static void Main(string[] args)
    {
      //Collections to work with
      List<Artist> Artists = MusicStore.GetData().AllArtists;
      List<Group> Groups = MusicStore.GetData().AllGroups;

      //========================================================
      //Solve all of the prompts below using various LINQ queries
      //========================================================

      //There is only one artist in this collection from Mount Vernon, what is their name and age?
      var mtVernon = Artists.Where(art => art.Hometown == "Mount Vernon")
        .Select(artist => new { artist.Age, artist.ArtistName });

      foreach (var artist in mtVernon)
      {
        Console.WriteLine(artist.ArtistName + " is " + artist.Age + " years old");
      }

      //Who is the youngest artist in our collection of artists?
      var lil = Artists.OrderByDescending(art => art.Age).Last();
      Console.WriteLine("The youngest artist is " + lil.ArtistName);

      //Display all artists with 'William' somewhere in their real name
      var wills = Artists.Where(art => art.RealName.Contains("William"));
      Console.WriteLine("All of the artists with 'William' in their name are:");
      foreach (var artist in wills)
      {
        Console.WriteLine(artist.RealName);
      }

      //Display all groups with names less than 8 characters in length
      var shortGroups = Groups.Where(g => g.GroupName.Length < 8);
      Console.WriteLine("All of the groups with names less than 8 characters are:");
      foreach (var g in shortGroups)
      {
        Console.WriteLine(g.GroupName);
      }

      //Display the 3 oldest artist from Atlanta
      var oldAtlanta = Artists.Where(art => art.Hometown == "Atlanta").OrderByDescending(a => a.Age).Take(3);
      Console.WriteLine("The 3 oldest artists in Atlanta are:");
      foreach (var artist in oldAtlanta)
      {
        Console.WriteLine(artist.ArtistName);
      }
      //(Optional) Display the Group Name of all groups that have members that are not from New York City
      var notNY = (Artists.Where(a => a.Hometown != "New York City")).Join(Groups, aId => aId.GroupId, gId => gId.Id, (aId, gId) => { return $"{gId.GroupName} member {aId.ArtistName} is not from New York"; });
      foreach (var not in notNY)
      {
        Console.WriteLine(not);
      }

      //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
      var wutang = Groups.Where(g => g.GroupName == "Wu-Tang Clan").Join(Artists, gId => gId.Id, aId => aId.GroupId, (gId, aId) => { return $"{aId.ArtistName} is a member of {gId.GroupName}"; });

      foreach (var wu in wutang)
      {
        Console.WriteLine(wu);
      }
    }
  }
}
