using Aplikacja_muzyczna.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using Aplikacja_muzyczna.Functions;
namespace Aplikacja_muzyczna.DBConnect.Artist
{
    public class ListingArtistDB
    {

        public static List<DetailArtist> SelectAll()
        {
            string sql = @"select * from dbo.Artist;";
            return DataAccess.LoadData<DetailArtist>(sql);
        }

        public static List<DetailArtist> SearchArtist(string SearchString)
        {
            string sql = ArtistFunction.SearchStringArtist(SearchString);
            return DataAccess.LoadData<DetailArtist>(sql);
        }

        public static string SingleNamesFromId (string ArtistId)
        {
            string sql = @"select Firstname, Lastname from  Artist where ArtistId = " + ArtistId + ";";
            DetailArtist Single = new DetailArtist();
            Single = DataAccess.LoadData<DetailArtist>(sql).First() ;
            return Single.Firstname + " " + Single.Lastname;
        }
    }
}