﻿using Aplikacja_muzyczna.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using Aplikacja_muzyczna.Functions;
namespace Aplikacja_muzyczna.DBConnect.Artist
{
    public class EditArtistDB
    {

        public static DetailArtist EditArtist(DetailArtist NewModel)
        {

            DetailArtist OldModel = DetailArtistDB.DetailFromId(NewModel.ArtistId);
            string sql = ArtistFunctions.ModifyArtistSring(NewModel, OldModel);

            DataAccess.SaveData(sql, NewModel);

            DetailArtist NewModelfromDB = new DetailArtist(); 
            NewModelfromDB = DetailArtistDB.DetailFromId(OldModel.ArtistId);

            return NewModelfromDB;
        }

    }
}