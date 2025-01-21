using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Budica_Andrei_Proiect.Models
{
    public class Programare
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Pacientul este obligatoriu")]
        public int PacientID { get; set; }
        public Pacient? Pacient { get; set; }

        [Required(ErrorMessage = "Terapeutul este obligatoriu")]
        public int TerapeutID { get; set; }
        public Terapeut? Terapeut { get; set; }

        [Required(ErrorMessage = "Data și ora programării sunt obligatorii")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Data și Ora")]
        public DateTime DataOra { get; set; }

        [Required(ErrorMessage = "Durata ședinței este obligatorie")]
        [Range(30, 120, ErrorMessage = "Durata trebuie să fie între 30 și 120 minute")]
        [Display(Name = "Durata (minute)")]
        public int Durata { get; set; }

        [Display(Name = "Observații")]
        public string? Observatii { get; set; }

        [Required(ErrorMessage = "Prețul este obligatoriu")]
        [Column(TypeName = "decimal(6, 2)")]
        [Range(0.01, 1000, ErrorMessage = "Prețul trebuie să fie între 0.01 și 1000 lei")]
        [Display(Name = "Preț")]
        public decimal Pret { get; set; }
    }
}
