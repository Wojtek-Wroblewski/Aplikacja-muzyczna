using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Text;
using System.Web;

namespace Aplikacja_muzyczna.Models
{
    public class AddArtist
    {

        [Display(Name = "Insert surname")]
        [Required(ErrorMessage = "Field can't be empty")]
        public string Surname { get; set; }
        [Display(Name = "Insert First name")]
        public string Firstname { get; set; }
        [Display(Name = "Insert birth date or date of established")]
        [Required(ErrorMessage = "Field can't be empty")]
        [DataType(DataType.Date)]
        public DateTimeOffset Birthdate { get; set; }
        [Display(Name = "Choose photo")]
        public byte[] Photo { get; set; }
        [Display(Name = "Additional info")]
        public string AdditionalInfo { get; set; }
        public HttpPostedFileBase File { get; set; }
        [Key]
        public int ArtId { get; set; }

    }

    public class DetailArtist
    {

        [Display(Name = "Surname")]
        public string Surname { get; set; }
        [Display(Name = "First name")]
        public string Firstname { get; set; }
        [Display(Name = "Birth date or date of established")]
        [DataType(DataType.Date)]
        public DateTimeOffset Birthdate { get; set; }
        [Display(Name = "Photo")]
        public byte[] Photo { get; set; }
        [Display(Name = "Additional info")]
        public string AdditionalInfo { get; set; }
        public HttpPostedFileBase File { get; set; }
        [Key]
        public int ArtId { get; set; }

    }


    public class ArtFunction
    { 

        public static byte[] PhotoBytefromfile(HttpPostedFileBase File)
        {

            if (File.ContentLength > (4 * 1024 * 1024))
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



    }

}
