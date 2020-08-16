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
                ArtistId = model.ArtistId,
                ReleaseDate = model.ReleaseDate,
                Title = model.Title
            };
            string sqlSave = @"INSERT into dbo.Track (ArtistId, ReleaseDate, Title) values (@ArtistId, @ReleaseDate, @Title);";

            int Numberofsaves = DataAccess.SaveData(sqlSave, data);
            string DateWithoutGarbage = model.ReleaseDate.ToString().Substring(0, 10);
            char separator = '.';
            string[] temp = DateWithoutGarbage.Split(separator);
            DateWithoutGarbage = temp[1] + separator + temp[0] + separator + temp[2];
            if (Numberofsaves == 1)
            {
                string sqlLoad = @"SELECT TrackId from dbo.Track where " +
                " ReleaseDate = '" + DateWithoutGarbage + "' AND " +
                " ArtistId = '" + model.ArtistId + "' AND " +
                " Title = '" + model.Title + "' ;";
                int AddedId = DataAccess.LoadData<DetailTracks>(sqlLoad).First().TrackId;
                return AddedId;
            }
            return 0;
        }
    }
}