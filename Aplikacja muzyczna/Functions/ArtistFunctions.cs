using Aplikacja_muzyczna.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Aplikacja_muzyczna.DBConnect.Artist;

namespace Aplikacja_muzyczna.Functions
{
    public class ArtistFunctions
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
            int Numberofchange = 0;
            string sql = @"UPDATE dbo.Artist Set  ";
            if (NewModel.Firstname != null)
                if (NewModel.Firstname != Oldmodel.Firstname)
                {
                    sql += "Firstname = @Firstname, ";
                    Numberofchange++;
                }
            
                if (NewModel.Lastname != Oldmodel.Lastname)
                {
                    sql += "Lastname = @Lastname, ";
                Numberofchange++;
            }

            if (NewModel.Birthdate != null)
                if (NewModel.Birthdate != Oldmodel.Birthdate)
                {
                    sql += "Birthdate = @Birthdate, ";
                    Numberofchange++;
                }

                if (NewModel.AdditionalInfo != Oldmodel.AdditionalInfo)
                {
                    sql += "AdditionalInfo = @AdditionalInfo, ";
                Numberofchange++;
            }
            
                if (NewModel.Photo != Oldmodel.Photo)
                {
                    sql += "Photo = @Photo, ";
                Numberofchange++;
            }
            sql = sql.Remove(sql.Length - 2, 2);
            sql += "  Where ArtistId = @ArtistId; ";
            if (Numberofchange != 0)
            { 
            return sql;
            }
            else
            {
                return null;
            }
        }

        public static void VerifyPhoto(HttpPostedFileBase File, out byte[] Photo, out string Error)
        {
       // public static Tuple< byte[],string> VerifyPhoto(HttpPostedFileBase File)     
       // {
            //byte[] Photo = null;
            //string Error = null;
            Photo = ArtistFunctions.PhotoBytefromfile(File);
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
            Error = "OK";

            // return new Tuple<byte[],string>(Photo,Error);

        }

        public static string SearchStringArtist(string SearchString)
        {
            string sql =
                @"declare @Fullname varchar(max) = '" + SearchString + @"' "+
@"DECLARE @Firstname varchar(max) = (SELECT TOP 1 * FROM string_split(@Fullname, ' ')) " +
@"Declare @Lastname varchar(max) = (SELECT Top 1 * FROM string_split(@Fullname, ' ') where value != @Firstname) " +
@"Declare @Table table(ArtistId int, Lastname varchar(max), Firstname varchar(max), Photo image, AdditionalInfo varchar(max),Birthdate datetime )  "  +
@"if (@Lastname is null) " +
@"    begin "+
@"                    insert into @Table Select* from Artist where Firstname like @Firstname or Lastname like @Firstname " +
@"               end " +
@"Insert into @Table Select *from Artist where Firstname like @Firstname and Lastname like @Lastname; " +
@"            if (select count(*) from @Table) < 1 " +
@"    BEGIN " +
@"        DECLARE @LastnameSWAP varchar(max) = @Firstname " +
@"        DECLARE @FirstnameSWAP varchar(max) = @Lastname " +
@"        Insert into @Table Select *from Artist where Firstname = @FirstnameSWAP and Lastname = @LastnameSWAP; " +
@"            END " +
@"            if (select count(*) from @Table) < 1 " +
@"    BEGIN " +
@"        Insert into @Table Select *from Artist where Firstname = @Firstname or Lastname = @Lastname; " +
@"            END " +
@"            if (select count(*) from @Table) < 1 " +
@"    BEGIN " +
@"        Insert into @Table Select *from Artist where Firstname = @FirstnameSWAP or Lastname = @LastnameSWAP; " +
@"            END " +
@"if (select count(*) from @Table) < 1 " +
@"    BEGIN " +
@"        Insert into @Table select* from Artist where Lastname = @Lastname " +
@"        Insert into @Table select *from Artist where Firstname = @Firstname " +
@"    END " +
@" Select* from @Table; "; 
            return sql;
        }

        public static List<DetailArtist> OrderListArtist (List<DetailArtist> List, string sortOrder )
        {
            switch (sortOrder)
            {
                case "FirstNameDesc":
                    List = List.OrderByDescending(x => x.Firstname).ToList();
                    break;
                case "FirstName":
                    List = List.OrderBy(x => x.Firstname).ToList();
                    break;
                case "Date":
                    List = List.OrderBy(x => x.Birthdate).ToList();
                    break;
                case "DateDesc":
                    List = List.OrderByDescending(x => x.Birthdate).ToList();
                    break;

                case "LastNameDesc":
                    List = List.OrderByDescending(x => x.Lastname).ToList();
                    break;
                case "LastName":
                    List = List.OrderBy(x => x.Lastname).ToList();
                    break;
                default:
                    List = List.OrderBy(x => x.Lastname).ToList();
                    break;
            }
            return List;

        }


    }
}