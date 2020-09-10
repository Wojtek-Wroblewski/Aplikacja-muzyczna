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
    public class DetailTrackWithArtist: DetailTracks
    {
        [Display(Name = "Original Artist Firstname")]
        public string Firstname { get; set; }
        [Display(Name = "Original Artist Lastname")]
        public string Lastname { get; set; }
        public int ArtistId { get; set; }
        
    }

}