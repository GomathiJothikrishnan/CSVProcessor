using System.Net.Mail;
using System.Text.RegularExpressions;


namespace CsvProcessor.Utilities
{
    public static class EmailValidator
    {
        public static bool Validate(string email)
        {
            try
            {
                var mail = new MailAddress(email);
                var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
                return regex.IsMatch(email);
            }
            catch
            {
                return false;
            }
        }
    }
}
