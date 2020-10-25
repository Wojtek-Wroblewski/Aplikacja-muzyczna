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
        [Display (Name = "Insert original Title")]
        [Required(ErrorMessage = "Field can't be empty")]
        public string Title { get; set; }
        [Key]
        public int TrackId { get; set; }
        [ForeignKey("ArtistIdFK")]
        public int ArtistIdFK { get; set; }
        public DetailArtist Artist { get; set; }
        [Display(Name = "Insert date of first release")]
        [Required(ErrorMessage = "Field can't be empty")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTimeOffset ReleaseDate { get; set; }
        [Display(Name = "Search for an artist")]
        public string SearchString { get; set; }
    }

    public class DetailTracks
    {
        [Display(Name = "Original Title")]
        [Required(ErrorMessage = "Field can't be empty")]
        public string Title { get; set; }
        [Key]
        public int TrackId { get; set; }
        [ForeignKey("ArtistIdFK")]
        public int ArtistIdFK { get; set; }
        [Display (Name = "Artist")]
        public DetailArtist Artist { get; set; }
        [Display(Name = "First release")]
        [Required(ErrorMessage = "Field can't be empty")]
        [DataType(DataType.Date)]
        public DateTimeOffset ReleaseDate { get; set; }
        [Display(Name = "Search for an artist")]
        public string SearchString { get; set; }
    }
    public class DetailTrackWithArtist
    {
        [Display(Name = "Original Artist Firstname")]
        public string Firstname { get; set; }
        [Display(Name = "Original Artist Lastname")]
        public string Lastname { get; set; }
        public int ArtistId { get; set; }

        public int TrackId { get; set; }
        public  DateTimeOffset ReleaseDate { get; set; }
        public string SearchString { get; set; }
        public string Title { get; set; }
        public int ArtistIdFK { get; set; }
    }
    public class EditTrack
    {
        [Display(Name = "Original Artist Firstname")]
        public string Firstname { get; set; }
        [Display(Name = "Original Artist Lastname")]
        public string Lastname { get; set; }
        public int ArtistId { get; set; }
        [Display(Name = "Original Title")]
        public string Title { get; set; }
        [Display(Name = "Insert date of first release")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTimeOffset ReleaseDate { get; set; }
        [Key]
        public int TrackId { get; set; }
        [Display (Name = "Search for an artist")]
        public string SearchString { get; set; }
    }
}