using System.Text;

namespace eShield_API.Utils
{
    public class ExamCode
    {
        public static string GenerateCode()
        {
            int length = 6;
            string characters = "0123456789";
            StringBuilder result = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                result.Append(characters[random.Next(characters.Length)]);
            }

            return result.ToString().Trim();
        }
    }
}
