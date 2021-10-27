// using System.Text.Json.Serialization;
// using demo.Acme.Models; obsolete
// using TetraPak;
//
// namespace demo.Acme
// {
//     public class GreetingModel : Model
//     {
//         public string Greeting { get; set; }
//
//         public string Subject { get; set; }
//
//         [JsonConstructor]
//         public GreetingModel(string id) : base(id)
//         {
//             Greeting = "Hello";
//             Subject = "World";
//         }
//
//         public GreetingModel() 
//         : this(new RandomString())
//         {
//         }
//     }
// }