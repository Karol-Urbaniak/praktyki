using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace praktyki.Models
{
    [Table("client_addresses")]


    public class ClientAddress
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("client_id")]
        public int ClientId { get; set; }

        [Column("is_main")]
        public bool IsMain { get; set; }

        [Column("street")]
        public string Street { get; set; } = string.Empty;

        [Column("city")]
        public string City { get; set; } = string.Empty;

        [ForeignKey("ClientId")]
        [JsonIgnore]
        public Client? Client { get; set; }
    }
}
