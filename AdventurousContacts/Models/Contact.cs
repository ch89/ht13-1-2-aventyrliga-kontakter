using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContactLab.Models
{
    [MetadataType(typeof(ContactMetadata))]
    public partial class Contact
    {
    }

    public class ContactMetadata
    {
        [Required(ErrorMessage = "Förnamn måste anges.")]
        [MaxLength(50, ErrorMessage = "Förnamnet kan inte bestå av mer än 50 tecken.")]
        [DisplayName("Förnamn")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Efternamn måste anges.")]
        [MaxLength(50, ErrorMessage = "Efternamnet kan inte bestå av mer än 50 tecken.")]
        [DisplayName("Efternamn")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "E-post måste anges.")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Ogiltig e-post")]
        [DisplayName("E-post")]
        public string EmailAddress { get; set; }
    }
}