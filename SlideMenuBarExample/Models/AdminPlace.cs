using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SlideMenuBarExample.Models
{
    public class AdminPlace : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ContractNum { get; set; }
        public string? ContractDT { get; set; }
        public bool Status { get; set; }
        
        private bool isselected;

        public bool isSelected 
        {
            get => isselected;
            set
            {
                if(isselected != value)
                {
                    isselected = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
