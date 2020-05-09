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
                Surname =model.Surname,
                Firstname=model.Firstname,
                Photo=model.Photo,
                AdditionalInfo=model.AdditionalInfo,
                Birthdate=model.Birthdate,

            };
            // string sql = @"insert into dbo.Artysta (Nazwa1, Nazwa2, DataNajmłodszego, Uwaga, Zdjęcie, ZdjęcieString) values (@Nazwa1, @Nazwa2, @DataNajmłodszego, @Uwaga, @Zdjęcie, @ZdjęcieString);";
            string sql = @"insert into dbo.Artist (Surname, Firstname, Photo, AdditionalInfo, Birthdate) values (@Surname, @Firstname, @Photo, @AdditionalInfo, @Birthdate);";

            return DataAccess.SaveData(sql, data);
        }
    }
}