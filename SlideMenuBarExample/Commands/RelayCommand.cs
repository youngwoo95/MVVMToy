using System.Windows.Input;

namespace SlideMenuBarExample.Commands
{
    /// <summary>
    /// ICommand 인터페이스의 간단한 구현체이다. - 거의 이게 베이스라고 보면됨.
    /// 실제 로직과 실행 가능 여부를 결정하는 조건을 지정할 수 있다.
    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Action<object> execute;
        private readonly Predicate<object> canExecute;

        /// <summary>
        /// RelayCommand 생성자이다.
        /// </summary>
        /// <param name="_execute"> 명령이 실행될 때 호출되는 Action </param>
        /// <param name="_canExecute"> 명령의 실행 가능 여부를 반환하는 조건 (옵션) </param>
        public RelayCommand(Action<object> _execute, Predicate<object> _canExecute = null)
        {
            this.execute = _execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = _canExecute;
        }

        /// <summary>
        /// 명령이 실행 가능한지 여부를 결정한다.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object? parameter)
        {
            return canExecute == null || canExecute(parameter);
        }

        /// <summary>
        /// 명령 실행 시 호출된다.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object? parameter)
        {
            execute(parameter);
        }

        /// <summary>
        /// CanExecute 상태가 변경되었음을 알리기 위한 이벤트이다.
        /// CommandManager가 이 이벤트를 이용해 커맨드의 활성 상태를 재평가한다.
        /// </summary>
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
