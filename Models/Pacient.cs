using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Budica_Andrei_Proiect.Models
{
    
    public class Pacient
    {
        
       
        public int ID { get; set; }

        [Required(ErrorMessage = "Numele este obligatoriu")]
        [Display(Name = "Nume")]
        [StringLength(100, ErrorMessage = "Numele nu poate depăși 100 de caractere")]
        public string Nume { get; set; }

        [Required(ErrorMessage = "Prenumele este obligatoriu")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Prenumele trebuie să aibă între 3 și 30 caractere")]
        [Display(Name = "Prenume")]
        public string Prenume { get; set; }



        [Required(ErrorMessage = "CNP-ul este obligatoriu")]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "CNP-ul trebuie să aibă exact 13 caractere")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "CNP-ul poate conține doar cifre")]
        public string CNP { get; set; }


        [Required(ErrorMessage = "Data nașterii este obligatorie")]
        [DataType(DataType.Date)]
        [Display(Name = "Data Nașterii")]
        public DateTime DataNasterii { get; set; }


        [Display(Name = "Adresă")]
        [StringLength(200, ErrorMessage = "Adresa nu poate depăși 200 de caractere")]
        public string Adresa { get; set; }

        [Required(ErrorMessage = "Numărul de telefon este obligatoriu")]
        [Phone(ErrorMessage = "Număr de telefon invalid")]
        [Display(Name = "Număr de Telefon")]
        [RegularExpression(@"^0[0-9]{9}$", ErrorMessage = "Numărul de telefon trebuie să înceapă cu 0 și să conțină 10 cifre")]
        public string Telefon { get; set; }

        
        [Display(Name = "Observații Medicale")]
        public string? ObservatiiMedicale { get; set; }

        [Display(Name = "Data Înregistrării")]
        [DataType(DataType.Date)]
        public DateTime DataInregistrarii { get; set; } = DateTime.Now;

       

        public string NumeComplet
        {
            get { return Nume + " " + Prenume; }
        }

        public ICollection<Programare>? Programari { get; set; }
        public ICollection<Plata>? Plati { get; set; }

    }
}