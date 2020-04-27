using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Web;

namespace Aplikacja_muzyczna.Models
{
    public class DodajArtysta
    {

        [Display(Name = "Podaj nazwisko lub nazwę zespołu")]
        [Required(ErrorMessage = "Pole nie może być puste")]
        public string Nazwa1 { get; set; }
        [Display(Name = "Podaj imię lub skrót od nazwy zespołu")]
        public string Nazwa2 { get; set; }
        [Display(Name = "Podaj datę urodzenia artysty/najmłodszego członka")]
        [Required(ErrorMessage = "Pole nie może być puste")]
        [DataType(DataType.Date)]
        public DateTimeOffset DataUr { get; set; }
        [Display(Name = "Wybierz zdjęcie")]
        public byte[] Zdj { get; set; }
        [Display(Name = "Dodatkowe informacje (np. wykonywane gatunki)")]
        public string Uwaga { get; set; }
        public HttpPostedFileBase UserProfilePicture { get; set; }
        public int ArtId { get; set; }

    }

    public class WyświetlArtysta
    {

        [Display(Name = "Podaj nazwisko lub nazwę zespołu")]
        [Required(ErrorMessage = "Pole nie może być puste")]
        public string Nazwa1 { get; set; }
        [Display(Name = "Podaj imię lub skrót od nazwy zespołu")]
        public string Nazwa2 { get; set; }
        [Display(Name = "Podaj datę urodzenia artysty/najmłodszego członka")]
        [Required(ErrorMessage = "Pole nie może być puste")]
        [DataType(DataType.Date)]
        public DateTimeOffset DataUr { get; set; }
        [Display(Name = "Wybierz zdjęcie")]
        public byte[] Zdj { get; set; }
        [Display(Name = "Dodatkowe informacje (np. wykonywane gatunki)")]
        public string Uwaga { get; set; }
        public HttpPostedFileBase UserProfilePicture { get; set; }
        [Key]
        public int ArtId { get; set; }

    }

    public class edytujArtysta
    {

        [Display(Name = "Podaj nazwisko lub nazwę zespołu")]
        [Required(ErrorMessage = "Pole nie może być puste")]
        public string Nazwa1 { get; set; }
        [Display(Name = "Podaj imię lub skrót od nazwy zespołu")]
        public string Nazwa2 { get; set; }
        [Display(Name = "Podaj datę urodzenia artysty/najmłodszego członka")]
        [Required(ErrorMessage = "Pole nie może być puste")]
        [DataType(DataType.Date)]
        public DateTimeOffset DataUr { get; set; }
        [Display(Name = "Wybierz zdjęcie")]
        public byte[] Zdj { get; set; }
        [Display(Name = "Dodatkowe informacje (np. wykonywane gatunki)")]
        public string Uwaga { get; set; }
        public HttpPostedFileBase UserProfilePicture { get; set; }
        public int ArtId { get; set; }

    }

}
