using demo.Acme.Models;
using demo.DataModel;

namespace WebAPI.Models
{
    public class MessageModel : Model
    {
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public string Message { get; set; }

        public MessageModel(string id) : base(id)
        {
        }
    }
}