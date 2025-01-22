using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Budica_Andrei_Proiect.Models
{
    
    public class Pacient
    {
        private string cnp;
        // Proprietăți existente
        public int ID { get; set; }

        [Required(ErrorMessage = "Numele este obligatoriu")]
        [Display(Name = "Nume")]
        [StringLength(100, ErrorMessage = "Numele nu poate depăși 100 de caractere")]
        public string Nume { get; set; }

        [Required(ErrorMessage = "Prenumele este obligatoriu")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Prenumele trebuie să aibă între 3 și 30 caractere")]
        [Display(Name = "Prenume")]
        public string Prenume { get; set; }



       public string CNP 
    { 
        get { return cnp; }
        set
        {
            cnp = value;
            if (value?.Length == 13) // Verify we have a complete CNP
            {
                DataNasterii = ExtractDateFromCNP(value);
            }
        }
    }

    // Method to extract date from CNP
    private DateTime ExtractDateFromCNP(string cnp)
    {
        try
        {
            int firstDigit = int.Parse(cnp[0].ToString());
            int year = int.Parse(cnp.Substring(1, 2));
            int month = int.Parse(cnp.Substring(3, 2));
            int day = int.Parse(cnp.Substring(5, 2));

            // Determine the century based on the first digit
            int century = 0;
            switch (firstDigit)
            {
                case 1:
                case 2:
                    century = 1900;
                    break;
                case 5:
                case 6:
                    century = 2000;
                    break;
                // You can add more cases for other scenarios
            }

            // Combine the century with the two-digit year
            year = century + year;

            
            return new DateTime(year, month, day);
        }
        catch (Exception)
        {
           
            return DateTime.Now;
        }
    }

        public DateTime DataNasterii { get; set; } = DateTime.Now;
        

        [Display(Name = "Adresă")]
        [StringLength(200, ErrorMessage = "Adresa nu poate depăși 200 de caractere")]
        public string Adresa { get; set; }

        [Required(ErrorMessage = "Numărul de telefon este obligatoriu")]
        [Phone(ErrorMessage = "Număr de telefon invalid")]
        [Display(Name = "Număr de Telefon")]
        [RegularExpression(@"^0[0-9]{9}$", ErrorMessage = "Numărul de telefon trebuie să înceapă cu 0 și să conțină 10 cifre")]
        public string Telefon { get; set; }

        // Proprietăți noi pentru funcționalități adiționale
        [Display(Name = "Observații Medicale")]
        public string? ObservatiiMedicale { get; set; }

        [Display(Name = "Data Înregistrării")]
        [DataType(DataType.Date)]
        public DateTime DataInregistrarii { get; set; } = DateTime.Now;

        // Proprietăți de navigare pentru relații

        public ICollection<Programare>? Programari { get; set; }
        public ICollection<Plata>? Plati { get; set; }

    }
}