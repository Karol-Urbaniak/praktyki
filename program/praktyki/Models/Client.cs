using System.ComponentModel.DataAnnotations.Schema;

namespace praktyki.Models
{
    [Table("clients")]
    public class Client
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("is_company")]
        public bool IsCompany { get; set; }

        [Column("nip")]
        public string? Nip { get; set; }

        [Column("pesel")]
        public string? Pesel { get; set; }

        [Column("firstname")]
        public string? Firstname { get; set; }

        [Column("lastname")]
        public string? Lastname { get; set; }

        [Column("name")]
        public string Name { get; set; } = string.Empty;

        [Column("country_code")]
        public string? CountryCode { get; set; }
    }
}