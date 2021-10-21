using System.Text;

#nullable enable

namespace demo.BackendServiceAPI.Models
{
    public static class GreetingHelper
    {
        public static string GetMessage(this GreetingDTO? self)
        {
            self ??= GreetingDTO.Default;
            var sb = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(self.Greeting))
            {
                sb.Append(self.Greeting);
            }

            if (string.IsNullOrWhiteSpace(self.Subject))
                return exclaimed();
            
            if (sb.Length != 0)
            {
                sb.Append(' ');
            }

            sb.Append(self.Subject);
            return exclaimed();

            string exclaimed()
            {
                sb.Append('!');
                return sb.ToString();
            }
        }
    }
}