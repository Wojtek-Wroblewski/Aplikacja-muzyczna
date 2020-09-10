using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Aplikacja_muzyczna.Models;

namespace Aplikacja_muzyczna.DBConnect.Track
{
    public class DetailTrackDB
    {
        public static DetailTrackWithArtist DetailFromId(int TrackId)
        {
            string sql = @"Select dbo.Artist.ArtistId,  dbo.Artist.Firstname, dbo.Artist.Lastname  , dbo.Track.ReleaseDate, dbo.Track.Title,dbo.Track.TrackId from Track left join Artist ON Track.ArtistIdFK = Artist.ArtistId where Trackid = '"+TrackId+"';";


            return DataAccess.LoadData<DetailTrackWithArtist>(sql).First();
        }
        public static List<DetailTrackWithArtist>  ListAll ()
        {

            string sql = @"Select dbo.Artist.ArtistId,  dbo.Artist.Firstname, dbo.Artist.Lastname  , dbo.Track.ReleaseDate, dbo.Track.Title,dbo.Track.TrackId from Track left join Artist ON Track.ArtistIdFK = Artist.ArtistId ;";


            return DataAccess.LoadData<DetailTrackWithArtist>(sql);
        }
    }
}