using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Aplikacja_muzyczna.Models;

namespace Aplikacja_muzyczna.Functions
{
    public class TrackFunctions
    {
        public static List<DetailTracks> Search(string SearchString)
        {


            return null;
        }

        public static string OBSOLETEFormat_rrrrmmdd(string ReleaseDate)
        {
            string WrongDate = ReleaseDate.ToString();
            char separator = '.';
            string[] CorrectDate = WrongDate.Split(separator);
            string[] YearCorrection = CorrectDate[2].Split(' ');
            CorrectDate[2] = YearCorrection[0];
            return CorrectDate[2] + '-' + CorrectDate[1] + '-' + CorrectDate[0];
        }
        public static string ModifyTrackSring(DetailTrackWithArtist NewModel, DetailTrackWithArtist Oldmodel)
        {
            {
                int Numberofchange = 0;
                string sql = @"UPDATE dbo.Track Set  ";
                if (NewModel.Title != null)
                    if (NewModel.Title != Oldmodel.Title)
                    {
                        sql += "Title = @Title, ";
                        Numberofchange++;
                    }


                if (NewModel.ReleaseDate != null)
                    if (NewModel.ReleaseDate != Oldmodel.ReleaseDate)
                    {
                        sql += "ReleaseDate = @ReleaseDate, ";
                        Numberofchange++;
                    }

                if (NewModel.ArtistIdFK != Oldmodel.ArtistIdFK)
                {
                    sql += "ArtistIdFK = @ArtistIdFK, ";
                    Numberofchange++;
                }

                sql = sql.Remove(sql.Length - 2, 2);
                sql += "  Where TrackId = @TrackId; ";
                if (Numberofchange != 0)
                {
                    return sql;
                }
                else
                {
                    return null;
                }
            }

        }

        public static List <DetailTrackWithArtist> OrderListTrack (List<DetailTrackWithArtist> List, string sortOrder)
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
                    List = List.OrderBy(x => x.ReleaseDate).ToList();
                    break;
                case "DateDesc":
                    List = List.OrderByDescending(x => x.ReleaseDate).ToList();
                    break;
                case "LastNameDesc":
                    List = List.OrderByDescending(x => x.Lastname).ToList();
                    break;
                case "LastName":
                    List = List.OrderBy(x => x.Lastname).ToList();
                    break;
                case "TitleDesc":
                    List = List.OrderByDescending(x => x.Title).ToList();
                    break;
                case "Title":
                    List = List.OrderBy(x => x.Title).ToList();
                    break;
                default:
                    List = List.OrderBy(x => x.Title).ToList();
                    break;
            }
            return List;

        }
    }
}