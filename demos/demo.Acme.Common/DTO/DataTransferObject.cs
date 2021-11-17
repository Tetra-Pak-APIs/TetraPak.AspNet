using TetraPak.DynamicEntities;

namespace demo.Acme.DTO
{
    public class DataTransferObject : DynamicEntity
    {
        public string Id
        {
            get => Get<string>();
            set => Set(value);
        }
    }
}