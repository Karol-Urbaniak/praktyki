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
        public string? firstname { get; set; }

        [Column("lastname")]
        public string? lastname { get; set; }

        [Column("name")]
        public string name { get; set; } = string.Empty;

        [Column("country")]
        public string? country { get; set; }
    }
}