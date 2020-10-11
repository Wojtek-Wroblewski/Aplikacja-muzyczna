using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Aplikacja_muzyczna.Models;

namespace Aplikacja_muzyczna.DBConnect.Track
{
    public class AddTrackDB
    {
        public static int SaveTracktoDB(AddTracks model)
        {

            AddTracks data = new AddTracks
            {
                ArtistIdFK = model.ArtistIdFK,
                ReleaseDate = model.ReleaseDate,
                Title = model.Title
            };
            string sqlSave = @"INSERT into dbo.Track (ArtistIdFK, ReleaseDate, Title) values (@ArtistIdFK, @ReleaseDate, @Title);";



            int Numberofsaves = DataAccess.SaveData(sqlSave, data);
            if (Numberofsaves == 1)
            {
                string date = model.ReleaseDate.ToString();
                date = date.Substring(0, 10);
                char separator = '.';
                string[] temp = date.Split(separator);
                date = temp[2] + "." + temp[1] + "." + temp[0];
                string sqlLoad = @"SELECT TrackId from dbo.Track where " +
                " ReleaseDate = '" + date + "' AND " +
                " ArtistIdFK = '" + model.ArtistIdFK + "' AND " +
                " Title = '" + model.Title + "' ;";
                int AddedId = DataAccess.LoadData<DetailTracks>(sqlLoad).First().TrackId;
                return AddedId;
            }
            return 0;
        }
    }
}