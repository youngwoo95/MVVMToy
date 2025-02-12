﻿using Microsoft.Extensions.DependencyInjection;
using SlideMenuBarExample.Commands;
using SlideMenuBarExample.Commands.Interfaces;
using SlideMenuBarExample.Helpers;
using SlideMenuBarExample.ViewModels;
using SlideMenuBarExample.ViewModels.BasicInfoManagement;
using SlideMenuBarExample.Views;
using SlideMenuBarExample.Views.BasicInfoManagement;
using SlideMenuBarExample.Views.BasicInfoManagement.Buildings;
using System.Windows;

namespace SlideMenuBarExample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider? ServiceProvider { get; private set; }
        public static IServiceCollection? Services { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // DI 컨테이너 구성
            ConfigureServices();

            // 로그인 창이 닫혀도 바로 종료되지 않도록 ShutdownMode를 OnExplicitShutdown으로 설정
            Application.Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;

            // DI 컨테이너에서 LoginWindow를 생성
            var loginWindow = ServiceProvider!.GetRequiredService<LoginWindow>();
            bool? result = loginWindow.ShowDialog();

            if (result == true)
            {
                // 로그인 성공 시 MainWindow를 DI 컨테이너에서 생성
                var mainWindow = ServiceProvider!.GetRequiredService<MainWindow>();
                Application.Current.MainWindow = mainWindow; // MainWindow로 지정

                // 이제 ShutdownMode를 OnMainWindowClose로 전환 (메인 창이 닫힐 때 애플리케이션 종료)
                Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
                mainWindow.Show();
            }
            else
            {
                Shutdown();
            }
        }

        /// <summary>
        /// 의존성 주입
        /// </summary>
        private void ConfigureServices()
        {
            Services = new ServiceCollection();

            // 서비스 등록
            Services.AddSingleton<HttpApiService>(new HttpApiService(Commons.BaseUrl));
            Services.AddSingleton<IWindowService, WindowService>();
            Services.AddSingleton<IAuthService, AuthService>();

            // ViewModel 등록
            Services.AddTransient<LoginViewModel>();
            Services.AddTransient<PlaceSelectViewModel>();
            Services.AddTransient<MainViewModel>();
            
            Services.AddTransient<HomeViewModel>();
            Services.AddTransient<BasicInfoViewModel>();
            Services.AddTransient<SettingViewModel>();

            Services.AddTransient<BuildingViewModel>();
            Services.AddTransient<LocationViewModel>();
            Services.AddTransient<UnitViewModel>();
            Services.AddTransient<BuildingEditViewModel>();

            // View 등록
            Services.AddTransient<LoginWindow>();
            Services.AddTransient<PlaceSelectView>();
            Services.AddTransient<MainWindow>();
            
            Services.AddTransient<HomeView>();
            Services.AddTransient<BasicInfoView>();
            Services.AddTransient<SettingView>();

            Services.AddTransient<BuildingView>();
            Services.AddTransient<LocationView>();
            Services.AddTransient<UnitView>();
            Services.AddTransient<BuildingEditView>();

            ServiceProvider = Services.BuildServiceProvider();
            

        }

    }

}
