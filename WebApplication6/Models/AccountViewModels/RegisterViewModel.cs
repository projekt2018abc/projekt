using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Pole wymagane")]
        [EmailAddress(ErrorMessage = "Wprowadz poprawny adres email")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Pole wymagane")]
        [StringLength(100, ErrorMessage = "{0} musi zawierać od {2} do {1} znaków.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Pole wymagane")]
        [DataType(DataType.Password)]
        [Display(Name = "Powtórz hasło")]
        [Compare("Password", ErrorMessage = "Wprowadzone hasła różnią się.")]
        public string ConfirmPassword { get; set; }

        [RegularExpression(@"^[a-zA-ZżźćńółęąśŻŹĆĄŚĘŁÓŃ]+$", ErrorMessage = "Dozwolone tylko litery")]
        [Display(Name = "Imie")]
        public string FirstName { get; set; }

        [RegularExpression(@"^[a-zA-ZżźćńółęąśŻŹĆĄŚĘŁÓŃ\s]+$", ErrorMessage = "Dozwolone tylko litery")]
        //[Required(ErrorMessage = "Pole wymagane")]
        [Display(Name = "Nazwa Firmy")]
        public string CompanyName { get; set; }

        [RegularExpression(@"^[a-zA-ZżźćńółęąśŻŹĆĄŚĘŁÓŃ]+$", ErrorMessage = "Dozwolone tylko litery")]
        [DataType(DataType.Text)]
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }

        [StringLength(11, ErrorMessage = "Numer PESEL ma 11 cyfr.", MinimumLength = 11)]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Numer PESEL może zawierać tylko cyfry")]
        [Display(Name = "PESEL")]
        public string Pesel { get; set; }

        [Display(Name = "NIP")]
        [StringLength(10, ErrorMessage = "Numer NIP ma 10 cyfr.", MinimumLength = 10)]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Numer NIP może zawierać tylko cyfry")]
        public string Nip { get; set; }

        [Display(Name = "REGON")]
        [StringLength(14, ErrorMessage = "Numer REGON ma 9 lub 14 cyfr.", MinimumLength = 9)]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Numer REGON może zawierać tylko cyfry")]
        public string Regon { get; set; }

        [Required]
        [Display(Name ="Rodzaj Konta")]
        public ProjektZespolowy.Models.AccountViewModels.TypKontaEnum SelectedRole { get; set; }
    }
}
