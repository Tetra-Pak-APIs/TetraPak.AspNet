namespace demo.BackendServiceAPI.Models
{
    public class GreetingDTO : DataTransferObject
    {
        public string Greeting { get; set; }

        public string Subject { get; set; }

        public static GreetingDTO Default => new()
        {
            Greeting = "Hello",
            Subject = "World"
        };
    }
}