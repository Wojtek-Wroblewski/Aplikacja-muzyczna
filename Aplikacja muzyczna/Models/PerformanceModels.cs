﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Text;
using System.Web;

namespace Aplikacja_muzyczna.Models
{
    public class AddPerformance
    {
        [Key]
        public int PerformanceId { get; set; }
        [Display(Name = "Insert date of performance")]
        [Required(ErrorMessage = "Field can't be empty")]
        [DataType(DataType.Date)]
        public DateTimeOffset UploadDate { get; set; }
        [Display(Name = "Choose music file")]
        public HttpPostedFileBase File { get; set; }
        public byte[] FileReadytoDB { get; set; }
        public List<AddComment> ListOfComment { get; set; }
        [Display(Name = "Search Track or Artist")]
        public string SearchString{ get; set; }

    }



}