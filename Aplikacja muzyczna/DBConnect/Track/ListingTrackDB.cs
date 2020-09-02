using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Aplikacja_muzyczna.Models;

namespace Aplikacja_muzyczna.DBConnect.Track
{
    public class ListingTrackDB
    {
        public static List<DetailTracks> SelectAll ()
        {

            string sql = @"Select * from dbo.Track";
            /*
             TODO 
             ładne zapytanie które automagicznie zwraca Track detale razem z imieniem i nazwiskiem artysty w kolejnej kolumnie podpisanej jako Artist
             */
            var List = DataAccess.LoadData<DetailTracks>(sql);
            foreach (var item in List)
            {
                
            }
            return null; /*TODO żeby coś ładnego zwracało*/
             
        }
    }
}