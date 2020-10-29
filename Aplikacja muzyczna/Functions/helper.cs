using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Aplikacja_muzyczna.Functions;
using Aplikacja_muzyczna.Models;
using Aplikacja_muzyczna.DBConnect;

namespace System.Web.Mvc
{
    public static class Helper
    {
        public static MvcHtmlString DisplayPhoto(this HtmlHelper html, byte[] Photo)
        {
                if (Photo != null)
                {
                    byte[] photo = Photo;
                    string imageSrc = null;
                    MemoryStream ms = new MemoryStream();
                    ms.Write(photo, 0, photo.Length);
                    string imageBase64 = Convert.ToBase64String(ms.ToArray());
                    imageSrc = string.Format("data:image/gif;base64,{0}", imageBase64);
                    string nonempty = @"<img src="+'"' +imageSrc+ '"'+@" alt = ""Photo"" style = ""border:0;width:80%; margin:30px 10% 0 10%;"" id = ""Photo"" />";

                    return new MvcHtmlString(nonempty);
                }
                else
                {
                    string empty = @" </hr> ";
                return new MvcHtmlString(empty);
            }

        }
        public static string RemoveCookie(this HtmlHelper html, string CookieName)
        {
            Cookies.RemoveCookie(CookieName);
            return null;
        }

        public static bool HasRoleToShow (this HtmlHelper html , string UserID, string Role )
        {
            string sql = @"Select * from dbo.AspNetUserRoles where userId = '"+UserID+"'";

            //DataAccess.LoadData<DetailArtist>(sql).First();
            
            //Aplikacja_muzyczna.DBConnect.DataAccess.LoadData<>

                

            return false;
        }


        //public static bool CzyUytkownikMaRole(this HtmlHelper html, string UserName, string rolaString)
        //{
        //    if (UserName.Length > 0)
        //    {
        //        string sqlName = @"select Id from dbo.AspNetUsers where Email='" + UserName + "';";
        //        List<RolaModel> IdzEmail = SqlDataAccess.LoadData<RolaModel>(sqlName);

        //        string sql = @" Select RoleId from  dbo.AspNetUserRoles where UserId = '" + IdzEmail[0].Id + "';";
        //        List<RolaModel> lista = SqlDataAccess.LoadData<RolaModel>(sql);


        //        string sqlrola = @"select Id from dbo.AspNetRoles where Name='" + rolaString + "';";

        //        List<RolaModel> listarole = SqlDataAccess.LoadData<RolaModel>(sqlrola);
        //        if (lista.Count == 0 || listarole.Count == 0)
        //        { return false; }
        //        else if (lista[0].RoleId == listarole[0].Id)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}
        //public static int Ukryjocene(this HtmlHelper html, string Idoceny, string IdModerator)
        //{
        //    OcenaModel data = new OcenaModel
        //    {
        //        OcId = Int32.Parse(Idoceny),
        //        ModId = IdModerator,
        //    };

        //    string sql = @"update dbo.Oceny set ModId = '" + IdModerator + "' where OcId = @OcId;";



        //    return SqlDataAccess.SaveData(sql, data);
        //}
        //public static bool CzyWidocznyKomentarz(this HtmlHelper html, string Idocena)
        //{
        //    string sqlUkryta = @"select * from dbo.Uwagi where OcId='" + Idocena + "';";

        //    List<OcenaModel> komentarz = SqlDataAccess.LoadData<OcenaModel>(sqlUkryta);
        //    if (komentarz.Count > 0)
        //    {
        //        return false;
        //    }
        //    else
        //        return true;
        //}
        //public static bool CzyModerator(this HtmlHelper html, string Idocena, string Id)
        //{
        //    string sqlUwaga = @" select * from dbo.Uwagi where OcId='" + Idocena + "';";
        //    List<OcenaModel> Uwaga = SqlDataAccess.LoadData<OcenaModel>(sqlUwaga);



        //    bool znaleziono = false;
        //    if (Uwaga.Count > 0)
        //    {
        //        if (Uwaga[0].ModId == Id)
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //    return false;
        //}
        //public static bool CzyAutor(this HtmlHelper html, string Idocena, string Id)
        //{

        //    string sqlKomentarz = @" select * from dbo.Oceny where OcId='" + Idocena + "';";
        //    List<OcenaModel> komentarz = SqlDataAccess.LoadData<OcenaModel>(sqlKomentarz);
        //    if (komentarz.Count > 0)
        //    {
        //        if (komentarz[0].ZalId == Id)
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //    return false;
        //}
        //public static string DokiedySubskrypcja(this HtmlHelper html, string id)
        //{
        //    string sql = @"select * from dbo.AspNetUserRoles where UserId = '" + id + "';";

        //    List<RolaModel> subskrybent = SqlDataAccess.LoadData<RolaModel>(sql);
        //    string data = subskrybent.First().DataZm.ToString();
        //    data = data.Substring(0, 10);
        //    return data;
        //}

    }

}