﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Text;
using System.Web;

namespace Aplikacja_muzyczna.Models
{
    public class AddArtist
    {
        [Display(Name = "Insert Lastname")]
        [Required(ErrorMessage = "Field can't be empty")]
        public string Lastname { get; set; }
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
        public int ArtistId { get; set; }
        public string AddedBy { get; set; }

    }

    public class DetailArtist
    {

        [Display(Name = "Lastname")]
        [Required(ErrorMessage = "Field can't be empty")]
        public string Lastname { get; set; }
        [Display(Name = "First name")]
        public string Firstname { get; set; }
        [Display(Name = "Birth date or date of established")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Field can't be empty")]
        public DateTimeOffset Birthdate { get; set; }
        [Display(Name = "Photo")]
        public byte[] Photo { get; set; }
        [Display(Name = "Additional info")]
        public string AdditionalInfo { get; set; }
        public HttpPostedFileBase File { get; set; }
        [Key]
        public int ArtistId { get; set; }

    }
    

}
