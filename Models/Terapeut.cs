using System.ComponentModel.DataAnnotations;

namespace Budica_Andrei_Proiect.Models
{
    public class Terapeut
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Numele este obligatoriu")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Numele trebuie să aibă între 3 și 30 caractere")]
        [Display(Name = "Nume")]
        public string Nume { get; set; }

        [Required(ErrorMessage = "Prenumele este obligatoriu")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Prenumele trebuie să aibă între 3 și 30 caractere")]
        [Display(Name = "Prenume")]
        public string Prenume { get; set; }

        [Required(ErrorMessage = "Specializarea este obligatorie")]
        [Display(Name = "Specializare")]
        public string Specializare { get; set; }

        [Required(ErrorMessage = "Adresa de email este obligatorie")]
        [EmailAddress(ErrorMessage = "Adresa de email nu este validă")]
        public string Email { get; set; }

        [Display(Name = "Nume Complet")]
        public string NumeComplet
        {
            get { return Nume + " " + Prenume; }
        }

 
        public ICollection<Programare>? Programari { get; set; }
    }
}
