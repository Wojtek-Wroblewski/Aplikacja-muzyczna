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

            if (File.ContentLength > (2 * 1024 * 1024))
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


        public static string ModifyArtistSring(DetailArtist NewModel, DetailArtist Oldmodel)
        {

            string sql = @"UPDATE dbo.Artist Set ";
            if (NewModel.Firstname != null)
                if (NewModel.Firstname != Oldmodel.Firstname)
                {
                    sql += "Firstname = @Firstname, ";
                }
            
                if (NewModel.Surname != Oldmodel.Surname)
                {
                    sql += "Surname = @Surname, ";
                }

            if (NewModel.Birthdate != null)
                if (NewModel.Birthdate != Oldmodel.Birthdate)
                {
                    sql += "Birthdate = @Birthdate, ";
                }

                if (NewModel.AdditionalInfo != Oldmodel.AdditionalInfo)
                {
                    sql += "AdditionalInfo = @AdditionalInfo, ";
                }
            
                if (NewModel.Photo != Oldmodel.Photo)
                {
                    sql += "Photo = @Photo, ";
                }
            sql = sql.Remove(sql.Length - 2, 2);
            sql += "  Where ArtistId = @ArtistId; ";


            return sql;
        }

        public static Tuple< byte[],string> VerifyPhoto(HttpPostedFileBase File)     
        {
            byte[] Photo = null;
            string Error = null;
            Photo = ArtistFunction.PhotoBytefromfile(File);
            if (Photo.Length == 1)
            {
                if (Photo.ToString()[0] == 'S')
                {
                    Error = "File to large";
                }
                else if (Photo.ToString()[0] == 'F')
                {
                    Error = "Wrong file format";
                }
            }
            else if (Photo.Length == 0)
            {
                Error = "Something went wrong";
            }

            return new Tuple<byte[],string>(Photo,Error);

        }

        public static List<DetailArtist> Search(string SearchString)
        {

            return null;
        }

    }
}