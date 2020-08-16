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

        public static string Format_rrrrmmdd(DateTimeOffset ReleaseDate)
        {
            string WrongDate = ReleaseDate.ToString();
            char separator = '.';
            string[] CorrectDate = WrongDate.Split(separator);
            string[] YearCorrection = CorrectDate[2].Split(' ');
            CorrectDate[2] = YearCorrection[0];
            return CorrectDate[2] + '-' + CorrectDate[1] + '-' + CorrectDate[0];
        }
       // public static string 
    }
}