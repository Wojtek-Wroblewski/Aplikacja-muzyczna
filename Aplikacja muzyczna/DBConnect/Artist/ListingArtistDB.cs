using Aplikacja_muzyczna.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
namespace Aplikacja_muzyczna.DBConnect.Artist
{
    public class ListingArtistDB
    {

        public static List<DetailArtist> SelectAll()
        {
            string sql = @"select * from dbo.Artist;";
            return DataAccess.LoadData<DetailArtist>(sql);
        }

    }
}