using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Aplikacja_muzyczna.Models;

namespace Aplikacja_muzyczna.DBConnect.Track
{
    public class DetailTrackDB
    {
        public static DetailTracks DetailFromId(int TrackId)
        {

            string sql = @"select * from dbo.Track where TrackId=" + TrackId+ ";";


            return DataAccess.LoadData<DetailTracks>(sql).First();
        }

    }
}