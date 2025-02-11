﻿using SharpVectors.Dom.Css;
using SlideMenuBarExample.Commands;
using SlideMenuBarExample.Commands.Interfaces;
using System.ComponentModel;
using System.Windows.Input;

namespace SlideMenuBarExample.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Home 버튼 커맨드
        /// </summary>
        public ICommand ShowHomeCommand { get; }

        /// <summary>
        /// 기본정보관리 버튼 커맨드
        /// </summary>
        public ICommand BasicInfoCommand { get; }

        /// <summary>
        /// Setting 버튼 커맨드
        /// </summary>
        public ICommand ShowSettingCommend { get; }

        #region 화면이동 네비게이션
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }
        #endregion
     

        private readonly IAuthService AuthService;

        public string RoleName { get; set; }
        public string UserName { get; set; }
        public string PlaceName { get; set; }

        /// <summary>
        /// 기본 생성자
        /// </summary>
        public MainViewModel(IAuthService _authservice)
        {
            this.AuthService = _authservice;

            CurrentViewModel = new HomeViewModel(); // 초기화면 설정

            ShowHomeCommand = new RelayCommand(param => CurrentViewModel = new HomeViewModel());
            BasicInfoCommand = new RelayCommand(param => CurrentViewModel = new BasicInfoViewModel());
            ShowSettingCommend = new RelayCommand(param => CurrentViewModel = new SettingViewModel());


            RoleName = $"[{AuthService.Role ?? ""}]";
            UserName = AuthService.UserName ?? "";
            PlaceName = AuthService.PlaceName ?? "";
        }
        


    }
}
