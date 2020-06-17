using Aplikacja_muzyczna.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Aplikacja_muzyczna.DBConnect.Artist;

namespace Aplikacja_muzyczna.Functions
{
    public class ArtistFunction
    {


        public static byte[] PhotoBytefromfile(HttpPostedFileBase File)
        {

            if (File.ContentLength > (1 * 1024 * 1024))
            {
                string S = "S";
                return Encoding.ASCII.GetBytes(S);
            }

            if (!File.ContentType.Contains("image/"))

            {
                string F = "F";
                return Encoding.ASCII.GetBytes(F);
            }

            byte[] data = new byte[File.ContentLength];

            File.InputStream.Read(data, 0, File.ContentLength);

            return data;
        }


        public static string ModifyArtistSring(DetailArtist UpdatedModel)
        {

            DetailArtist Oldmodel = DetailArtistDB.DetailFromId(UpdatedModel.ArtId);

            string sql = @"UPDATE dbo.Artist Set ";
            if (UpdatedModel.Firstname != null)
                if (UpdatedModel.Firstname != Oldmodel.Firstname)
                {
                    sql += "Firstname = @Firstname, ";
                }
            
                if (UpdatedModel.Surname != Oldmodel.Surname)
                {
                    sql += "Surname = @Surname, ";
                }

            if (UpdatedModel.Birthdate != null)
                if (UpdatedModel.Birthdate != Oldmodel.Birthdate)
                {
                    sql += "Birthdate = @Birthdate, ";
                }

                if (UpdatedModel.AdditionalInfo != Oldmodel.AdditionalInfo)
                {
                    sql += "AdditionalInfo = @AdditionalInfo, ";
                }
            
                if (UpdatedModel.Photo != Oldmodel.Photo)
                {
                    sql += "Photo = @Photo, ";
                }
            sql = sql.Remove(sql.Length - 2, 2);
            sql += "  Where ArtId = @ArtId ";


            return sql;
        }
    }
}