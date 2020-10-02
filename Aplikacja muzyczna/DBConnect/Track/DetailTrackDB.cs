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
        public static EditTrack DetailTracktoEdit (int TrackId)
        {

            string sql = @"Select dbo.Artist.ArtistId,  dbo.Artist.Firstname, dbo.Artist.Lastname  , dbo.Track.ReleaseDate, dbo.Track.Title,dbo.Track.TrackId from Track left join Artist ON Track.ArtistIdFK = Artist.ArtistId where Trackid = '" + TrackId + "';";

            var model = DataAccess.LoadData<EditTrack>(sql).First();
            string WrongDate = model.ReleaseDate;
            char Separator = '/';
            WrongDate = WrongDate.Substring(0, 10);
            string[] Separate = WrongDate.Split(Separator);
            string GoodDate = Separate[2]+"-" + Separate[1] + "-" + Separate[0];
            model.ReleaseDate = GoodDate;
            /*TODO 
             wrzucić to co wyżej do ładnej funkcji*/
            return model;
        }
    }
}