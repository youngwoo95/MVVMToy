using Microsoft.Extensions.DependencyInjection;
using SlideMenuBarExample.Commands.Interfaces;
using SlideMenuBarExample.ViewModels;
using SlideMenuBarExample.Views;

namespace SlideMenuBarExample.Commands
{
    public class WindowService : IWindowService
    {
        private readonly IServiceProvider ServiceProvider;

        public WindowService(IServiceProvider _serviceprovider)
        {
            this.ServiceProvider = _serviceprovider;
        }

        public async Task<int> ShowPlaceSelectWindowAsync()
        {
            // DI 컨테이너를 통해 PlaceSelectViewModel을 생성
            var viewModel = ServiceProvider.GetRequiredService<PlaceSelectViewModel>();

            // 그리고 생성자에 viewModel을 전달하여 PlaceSelectView 생성
            var placeSelectView = new PlaceSelectView(viewModel);

            bool? result = placeSelectView.ShowDialog();
            if(result == true)
            {
                return await Task.FromResult(placeSelectView.SelectionResult);
            }
            return await Task.FromResult(-1);
        }
    }
}
