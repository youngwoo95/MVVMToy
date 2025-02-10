using SlideMenuBarExample.ViewModels;
using System.Windows;

namespace SlideMenuBarExample.Views
{
    /// <summary>
    /// PlaceSelectView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PlaceSelectView : Window
    {
        // 사용자가 확인 버튼을 눌렀을 때, ViewModel의 선택 결과를 확인 후
        // DialogResult를 true로 설정하도록 ViewModel과 상호작용할 수 있음.
        public int SelectionResult { get; private set; }

        public PlaceSelectView(PlaceSelectViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;

            // ViewModel의 RequestClose 이벤트 구독
            viewModel.RequestClose += (s, result) =>
            {
                // 필요에 따라 SelectionResult를 설정할 수 있음. 
                // 예를 들어, ViewModel의 SelectedBusiness.Id를 선택 결과로 사용한다면:
                if (viewModel.SelectedPlaces is not null)
                {
                    SelectionResult = viewModel.SelectedPlaces.Id;
                }

                // 창의 DialogResult를 설정하고 닫음
                this.DialogResult = result;
                this.Close();
            };
        }
    }
}
