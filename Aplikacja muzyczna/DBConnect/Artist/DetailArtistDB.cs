﻿using Aplikacja_muzyczna.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
namespace Aplikacja_muzyczna.DBConnect.Artist
{
    public class DetailArtistDB
    {

        public static DetailArtist DetailFromId(int ArtId)
        {

            string sql = @"select * from dbo.Artist where ArtId=" + ArtId + ";";


            return DataAccess.LoadData<DetailArtist>(sql).First();
        }

    }
}