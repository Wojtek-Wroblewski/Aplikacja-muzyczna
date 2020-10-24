using Aplikacja_muzyczna.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using Aplikacja_muzyczna.Functions;

namespace Aplikacja_muzyczna.DBConnect.Track
{
    public class EditTrackDB
    {


        public static DetailTrackWithArtist EditTrack(DetailTrackWithArtist NewModel)
        {

            DetailTrackWithArtist OldModel = DetailTrackDB.DetailFromId(NewModel.TrackId);
            string sql = TrackFunctions.ModifyTrackSring(NewModel, OldModel);

            DataAccess.SaveData(sql, NewModel);

            DetailTrackWithArtist NewModelfromDB = new DetailTrackWithArtist();
            NewModelfromDB = DetailTrackDB.DetailFromId(OldModel.ArtistId);

            return NewModelfromDB;
        }




    }
}