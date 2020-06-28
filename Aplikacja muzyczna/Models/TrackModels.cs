using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Aplikacja_muzyczna.Models
{
    public class AddTracks
    {
        [Display (Name = "Original Title")]
        [Required(ErrorMessage = "Field can't be empty")]
        public string Title { get; set; }
        [Key]
        public int TrackId { get; set; }
        [ForeignKey("ArtistId")]
        public DetailArtist Artist { get; set; }
        [Display(Name = "First release")]
        [Required(ErrorMessage = "Field can't be empty")]
        public DateTime ReleaseDate { get; set; }
    }
}