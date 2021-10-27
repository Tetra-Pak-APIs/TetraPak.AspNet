namespace demo.WebApp.Models
{
    public abstract class ViewModel
    {
        string _title;
        
        public string Title
        {
            get => _title ?? OnGetTitle();
            set => _title = value;
        }

        protected virtual string OnGetTitle()
        {
            var s = GetType().Name;
            return s.EndsWith("Model") 
                ? s[^"Model".Length..] 
                : s;
        }

        public ViewModel(string title = null)
        {
            _title = title;
        }
    }
}