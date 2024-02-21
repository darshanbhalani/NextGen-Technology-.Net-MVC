namespace NextGen_Technology.Models
{
    public class SendEmail
    {
        public SMTPConfiguration configuration { get; set; }
        public string to { get; set; }
        public string subject { get; set; }
        public string body { get; set; }
    }
}
