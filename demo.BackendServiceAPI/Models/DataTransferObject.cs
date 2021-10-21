using System.ComponentModel.DataAnnotations;
using TetraPak;

namespace demo.BackendServiceAPI.Models
{
    public class DataTransferObject
    {
        [Required, Key]
        public string Id { get; set; }

        public DataTransferObject()
        {
            Id = new RandomString();
        }
    }
}