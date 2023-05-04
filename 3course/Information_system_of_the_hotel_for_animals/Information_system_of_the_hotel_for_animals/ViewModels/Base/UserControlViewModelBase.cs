using System.Windows;
using System.Windows.Input;
using Information_system.Infrastructure.Commands;

namespace Information_system.ViewModels.Base
{
    public class UserControlViewModelBase : ViewModel
    {
        #region Visibility

        private Visibility _viewDataVisibility = Visibility.Visible;
        private Visibility _creatingVisibility = Visibility.Collapsed;
        private Visibility _editFieldVisibility = Visibility.Collapsed;

        public Visibility ViewDataVisibility
        {
            get => _viewDataVisibility;
            set => Set(ref _viewDataVisibility, value);
        }
        
        public Visibility CreatingDataVisibility
        {
            get => _creatingVisibility;
            set => Set(ref _creatingVisibility, value);
        }
        
        public Visibility EditDataVisibility
        {
            get => _editFieldVisibility;
            set => Set(ref _editFieldVisibility, value);
        }

        #endregion

        #region Commands

        public ICommand EnterViewDataStateCommand { get; }
        
        private bool CanEnterViewDataStateCommandExecute(object p) => true;
        private void OnEnterViewDataStateCommandExecute(object p)
        {
            CreatingDataVisibility = Visibility.Collapsed;
            ViewDataVisibility = Visibility.Visible;
            EditDataVisibility = Visibility.Collapsed;
        }
        
        public ICommand EnterCreatingDataStateCommand { get; }
        
        private bool CanEnterCreatingDataStateCommandExecute(object p) => true;
        private void OnEnterCreatingDataStateCommandExecute(object p)
        {
            CreatingDataVisibility = Visibility.Visible;
            ViewDataVisibility = Visibility.Collapsed;
            EditDataVisibility = Visibility.Collapsed;
        }
        
        public ICommand EnterEditFieldStateCommand { get; }
        
        private bool CanEnterEditFieldStateCommandExecute(object p) => true;
        private void OnEnterEditFieldStateCommandExecute(object p)
        {
            CreatingDataVisibility = Visibility.Collapsed;
            ViewDataVisibility = Visibility.Collapsed;
            EditDataVisibility = Visibility.Visible;
        }

        #endregion

        protected UserControlViewModelBase()
        {
            EnterViewDataStateCommand =
                new LambdaCommand(OnEnterViewDataStateCommandExecute, CanEnterViewDataStateCommandExecute);
            EnterCreatingDataStateCommand = new LambdaCommand(OnEnterCreatingDataStateCommandExecute,
                CanEnterCreatingDataStateCommandExecute);
            EnterEditFieldStateCommand =
                new LambdaCommand(OnEnterEditFieldStateCommandExecute, CanEnterEditFieldStateCommandExecute);
        }
    }
}