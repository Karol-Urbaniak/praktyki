namespace praktyki
{
    public class VerifyPeselRequest
    {
        public string Number { get; set; } = string.Empty;
    }

    public class VerifyPeselResponse
    {
        public bool IsValid { get; set; }
        public string? BrithDate { get; set; }
        public string? Gender { get; set; }
        public string? Message { get; set; }
    }
}
