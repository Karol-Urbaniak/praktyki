namespace praktyki.Models
{
    public class VerifyPeselResponse
    {
        public bool IsValid { get; set; }
        public string? BirthDate { get; set; }
        public string? Gender { get; set; }
        public string? Message { get; set; }
    }
}
