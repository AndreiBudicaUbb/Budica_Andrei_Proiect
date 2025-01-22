using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Budica_Andrei_Proiect.Models
{
    public class Plata
    {
       
        public int ID { get; set; }

       
        [Required(ErrorMessage = "Pacientul este obligatoriu")]
        public int PacientID { get; set; }

        
        public Pacient? Pacient { get; set; }

        
        [Required(ErrorMessage = "Data plății este obligatorie")]
        [DataType(DataType.Date)]
        [Display(Name = "Data Plății")]
        public DateTime DataPlata { get; set; } = DateTime.Now;

        
        [Required(ErrorMessage = "Suma este obligatorie")]
        [Column(TypeName = "decimal(8, 2)")] 
        [Range(0.01, 999999.99, ErrorMessage = "Suma trebuie să fie între 0.01 și 999999.99 lei")]
        [Display(Name = "Sumă (Lei)")]
        public decimal Suma { get; set; }


        [Required(ErrorMessage = "Metoda de plată este obligatorie")]
        [Display(Name = "Metoda de Plată")]
        public TipPlata MetodaPlata { get; set; }


        [Required(ErrorMessage = "Numărul documentului este obligatoriu")]
        [Display(Name = "Număr Document")]
        [StringLength(20, ErrorMessage = "Numărul documentului nu poate depăși 20 de caractere")]
        public string NumarDocument { get; set; }

       
        [Display(Name = "Observații")]
        [StringLength(500, ErrorMessage = "Observațiile nu pot depăși 500 de caractere")]
        public string? Observatii { get; set; }

        
        [Required(ErrorMessage = "Status-ul plății este obligatoriu")]
        [Display(Name = "Status Plată")]
        public string StatusPlata { get; set; } = "Efectuată"; 
    }
}
