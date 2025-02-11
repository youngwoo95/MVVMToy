using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SlideMenuBarExample.Models
{
    public class PlaceBuilding : INotifyPropertyChanged
    {
        private bool buildingcheck;
        private DateTime? completiondt;

        public bool BuildingCheck 
        {
            get
            {
                return buildingcheck;
            }
            set
            {
                if(buildingcheck != value)
                {
                    buildingcheck = value;
                    OnPropertyChanged();
                }
            }
        }
        /// <summary>
        /// 건물 ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 건물 전화번호
        /// </summary>
        public string? Tel { get; set; }

        /// <summary>
        /// 건물 층수
        /// </summary>
        public string? TotalFloor { get; set; }

        /// <summary>
        /// 건물명
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// 건물주소
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// 준공년월
        /// </summary>
        public DateTime? CompletionDT 
        {
            get
            {
                return completiondt;
            }
            set
            {
                completiondt = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 생성일
        /// </summary>
        public DateTime? CreateDT { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
