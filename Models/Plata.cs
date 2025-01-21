using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Budica_Andrei_Proiect.Models
{
    public class Plata
    {
        // Cheia primară care identifică unic fiecare plată
        public int ID { get; set; }

        // Legătura cu pacientul care efectuează plata
        [Required(ErrorMessage = "Pacientul este obligatoriu")]
        public int PacientID { get; set; }

        // Proprietatea de navigare către pacient
        public Pacient? Pacient { get; set; }

        // Data la care s-a efectuat plata
        [Required(ErrorMessage = "Data plății este obligatorie")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Data Plății")]
        public DateTime DataPlata { get; set; } = DateTime.Now;

        // Suma plătită
        [Required(ErrorMessage = "Suma este obligatorie")]
        [Column(TypeName = "decimal(8, 2)")] // Permite sume până la 999999.99
        [Range(0.01, 999999.99, ErrorMessage = "Suma trebuie să fie între 0.01 și 999999.99 lei")]
        [Display(Name = "Sumă (Lei)")]
        public decimal Suma { get; set; }

        // Metoda de plată folosită
        [Required(ErrorMessage = "Metoda de plată este obligatorie")]
        [Display(Name = "Metoda de Plată")]
        public string MetodaPlata { get; set; }

        // Numărul bonului fiscal sau al facturii
        [Required(ErrorMessage = "Numărul documentului este obligatoriu")]
        [Display(Name = "Număr Document")]
        [StringLength(20, ErrorMessage = "Numărul documentului nu poate depăși 20 de caractere")]
        public string NumarDocument { get; set; }

        // Observații opționale despre plată
        [Display(Name = "Observații")]
        [StringLength(500, ErrorMessage = "Observațiile nu pot depăși 500 de caractere")]
        public string? Observatii { get; set; }

        // Status plata implicit
        [Required(ErrorMessage = "Status-ul plății este obligatoriu")]
        [Display(Name = "Status Plată")]
        public string StatusPlata { get; set; } = "Efectuată"; // Valoare implicită
    }
}
