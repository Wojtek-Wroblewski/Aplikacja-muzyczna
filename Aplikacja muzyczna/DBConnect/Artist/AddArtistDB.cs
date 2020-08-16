using Aplikacja_muzyczna.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace Aplikacja_muzyczna.DBConnect.Artist
{
    public static class AddArtistDB
    {
        public static int SaveArtisttoDB(AddArtist model)
        {
            AddArtist data = new AddArtist
            {
                Lastname =model.Lastname,
                Firstname=model.Firstname,
                Photo=model.Photo,
                AdditionalInfo=model.AdditionalInfo,
                Birthdate=model.Birthdate,

            };
            // string sql = @"insert into dbo.Artysta (Nazwa1, Nazwa2, DataNajmłodszego, Uwaga, Zdjęcie, ZdjęcieString) values (@Nazwa1, @Nazwa2, @DataNajmłodszego, @Uwaga, @Zdjęcie, @ZdjęcieString);";
            string sqlSave = @"insert into dbo.Artist (Lastname, Firstname, Photo, AdditionalInfo, Birthdate) values (@Lastname, @Firstname, @Photo, @AdditionalInfo, @Birthdate);";

            int Numberofsaves = DataAccess.SaveData(sqlSave, data);
            if (Numberofsaves == 1)
            {
                string sqlLoad = @"SELECT ArtistId from dbo.Artist where " +
                    " Lastname = '" + model.Lastname + "' AND " +
                    " Firstname = '" + model.Firstname + "' AND " +
                    //" Photo = '" + model.Photo + "' AND " +
                    " AdditionalInfo = '" + model.AdditionalInfo + "' ; ";
                /*TODO 
                 wyjąterk że jak jest additiona info ==null*/

                //" AdditionalInfo = ' " + model.AdditionalInfo + "' AND " +
                // " Birthdate ='" + model.Birthdate + "'";
                int AddedId = DataAccess.LoadData<DetailArtist>(sqlLoad).First().ArtistId;
                return AddedId;
            }
            else
return 0;
        }
    }
}

