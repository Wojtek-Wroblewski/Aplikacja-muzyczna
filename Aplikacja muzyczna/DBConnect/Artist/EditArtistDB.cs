using Aplikacja_muzyczna.Models;
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

            string sql = ArtistFunction.ModifyArtistSring(NewModel);

            DetailArtist NewModelfromDB = new DetailArtist(); 

            DetailArtist OldModel = DetailArtistDB.DetailFromId(NewModel.ArtId);

            


            DataAccess.SaveData(sql, NewModel);

            NewModelfromDB = DetailArtistDB.DetailFromId(OldModel.ArtId);

            return NewModel;
        }

    }
}