using System.Windows;
using System.Windows.Input;
using SportClubISS.Infrastructure.Commands;
using SportClubISS.Infrastructure.Services;
using SportClubISS.Models;

namespace SportClubISS.ViewModels.Base;

public abstract class BaseUserControlViewModel : ViewModel
{
    protected Repository _repository;
    
    private Visibility _isCreatOrEditState;

    public Visibility IsCreatOrEditSate
    {
        get => _isCreatOrEditState;
        set => Set(ref _isCreatOrEditState, value);
    }
    
    private Visibility _isViewState;

    public Visibility IsViewState
    {
        get => _isViewState;
        set => Set(ref _isViewState, value);
    }
    
    public ICommand CreateRecord { get; }
        
    private bool CanCreateRecordCommandExecute(object p) => true;

    protected abstract void OnCreateRecordCommandExecute(object p);
    
    
    public ICommand DeleteRecord { get; }
        
    private bool CanDeleteRecordCommandExecute(object p) => true;

    protected abstract void OnDeleteRecordCommandExecute(object p);

    public void EnterViewState()
    {
        IsViewState = Visibility.Visible;
        IsCreatOrEditSate = Visibility.Collapsed;
    }

    public void EnterCreateOrEditState()
    {
        IsViewState = Visibility.Collapsed;
        IsCreatOrEditSate = Visibility.Visible;
    }

    public BaseUserControlViewModel()
    {
        _repository = Repository.Instance;
        
        CreateRecord = new LambdaCommand(OnCreateRecordCommandExecute, CanCreateRecordCommandExecute);
        DeleteRecord = new LambdaCommand(OnDeleteRecordCommandExecute, CanDeleteRecordCommandExecute);
    }
}