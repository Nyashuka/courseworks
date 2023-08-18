using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using SportClubISS.Infrastructure.Commands;
using SportClubISS.Infrastructure.Services;
using SportClubISS.Models;
using SportClubISS.ViewModels.Base;
using SportClubISS.ViewModels.UserControlsViewModel;
using SportClubISS.Views;
using SportClubISS.Views.UserControls;

namespace SportClubISS.ViewModels;

public class MainWindowViewModel : ViewModel
{
    private UserControl _currentContent;

    public UserControl CurrentContent
    {
        set => Set(ref _currentContent, value);
        get => _currentContent;
    }

    private BaseUserControlViewModel _currentViewModel;

    public ICommand LoadSportsmenCommand { get; }
    private bool CanExecuteLoadSportsmenCommand(object p) => true;

    private void OnExecuteLoadSportsmenCommand(object p)
    {
        _currentViewModel = new SportsmenViewModel();
        _currentViewModel.EnterViewState();
        CurrentContent = new SportsmanUC(_currentViewModel);
    }

    public ICommand LoadSpecializationsCommand { get; }
    private bool CanExecuteLoadSpecializationsCommand(object p) => true;

    private void OnExecuteLoadSpecializationsCommand(object p)
    {
        _currentViewModel = new SpecializationViewModel();
        _currentViewModel.EnterViewState();
        CurrentContent = new SpecializationUS(_currentViewModel);
    }

    public ICommand CreateSpecializationsCommand { get; }
    private bool CanExecuteCreateSpecializationsCommand(object p) => true;

    private void OnExecuteCreateSpecializationsCommand(object p)
    {
        _currentViewModel = new SpecializationViewModel();
        _currentViewModel.EnterCreateOrEditState();
        CurrentContent = new SpecializationUS(_currentViewModel);
    }

    public ICommand CreateSportsmanCommand { get; }
    private bool CanExecuteCreateSportsmanCommand(object p) => true;

    private void OnExecuteCreateSportsmanCommand(object p)
    {
        _currentViewModel = new SportsmenViewModel();
        _currentViewModel.EnterCreateOrEditState();
        CurrentContent = new SportsmanUC(_currentViewModel);
    }


    public ICommand LoadCoachesCommand { get; }
    private bool CanExecuteLoadCoachesCommand(object p) => true;

    private void OnExecuteLoadCoachesCommand(object p)
    {
        _currentViewModel = new CoachViewModel();
        _currentViewModel.EnterViewState();
        CurrentContent = new CoachesUS(_currentViewModel);
    }

    public ICommand CreateCoachesCommand { get; }
    private bool CanExecuteCreateCoachesCommand(object p) => true;

    private void OnExecuteCreateCoachesCommand(object p)
    {
        _currentViewModel = new CoachViewModel();
        _currentViewModel.EnterCreateOrEditState();
        CurrentContent = new CoachesUS(_currentViewModel);
    }

    public ICommand LoadSportClubsCommand { get; }
    private bool CanExecuteLoadSportClubsCommand(object p) => true;

    private void OnExecuteLoadSportClubsCommand(object p)
    {
        _currentViewModel = new SportClubViewModel();
        _currentViewModel.EnterViewState();
        CurrentContent = new SportClubUS(_currentViewModel);
    }

    public ICommand CreateSportClubCommand { get; }
    private bool CanExecuteCreateSportClubCommand(object p) => true;

    private void OnExecuteCreateSportClubCommand(object p)
    {
        _currentViewModel = new SportClubViewModel();
        _currentViewModel.EnterCreateOrEditState();
        CurrentContent = new SportClubUS(_currentViewModel);
    }

    public ICommand LoadCompetitionsCommand { get; }
    private bool CanExecuteLoadCompetitionsCommand(object p) => true;

    private void OnExecuteLoadCompetitionsCommand(object p)
    {
        _currentViewModel = new CompetitionsViewModel();
        _currentViewModel.EnterViewState();
        CurrentContent = new CompetitionsUC(_currentViewModel);
    }

    public ICommand CreateCompetitionCommand { get; }
    private bool CanExecuteCreateCompetitionCommand(object p) => true;

    private void OnExecuteCreateCompetitionCommand(object p)
    {
        _currentViewModel = new CompetitionsViewModel();
        _currentViewModel.EnterCreateOrEditState();
        CurrentContent = new CompetitionsUC(_currentViewModel);
    }

    public ICommand LoadRatesCommand { get; }
    private bool CanExecuteLoadRatesCommand(object p) => true;

    private void OnExecuteLoadRatesCommand(object p)
    {
        _currentViewModel = new RatesViewModel();
        _currentViewModel.EnterViewState();
        CurrentContent = new RatesUC(_currentViewModel);
    }

    public ICommand SaveDataCommand { get; }
    private bool CanExecuteSaveDataCommand(object p) => true;

    private void OnExecuteSaveDataCommand(object p)
    {
        try
        {
            Repository.Instance.SaveData();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        finally
        {
            MessageBox.Show("Saved succesfully!");
        }

        
    }

    public MainWindowViewModel()
    {
        LoadSpecializationsCommand =
            new LambdaCommand(OnExecuteLoadSpecializationsCommand, CanExecuteLoadSpecializationsCommand);
        CreateSpecializationsCommand =
            new LambdaCommand(OnExecuteCreateSpecializationsCommand, CanExecuteCreateSpecializationsCommand);

        LoadSportsmenCommand =
            new LambdaCommand(OnExecuteLoadSportsmenCommand, CanExecuteLoadSportsmenCommand);
        CreateSportsmanCommand =
            new LambdaCommand(OnExecuteCreateSportsmanCommand, CanExecuteCreateSportsmanCommand);

        LoadCoachesCommand = new LambdaCommand(OnExecuteLoadCoachesCommand, CanExecuteLoadCoachesCommand);
        CreateCoachesCommand = new LambdaCommand(OnExecuteCreateCoachesCommand, CanExecuteCreateCoachesCommand);

        LoadSportClubsCommand = new LambdaCommand(OnExecuteLoadSportClubsCommand, CanExecuteLoadSportClubsCommand);
        CreateSportClubCommand =
            new LambdaCommand(OnExecuteCreateSportClubCommand, CanExecuteCreateSportClubCommand);

        LoadCompetitionsCommand =
            new LambdaCommand(OnExecuteLoadCompetitionsCommand, CanExecuteLoadCompetitionsCommand);
        CreateCompetitionCommand =
            new LambdaCommand(OnExecuteCreateCompetitionCommand, CanExecuteCreateCompetitionCommand);

        LoadRatesCommand = new LambdaCommand(OnExecuteLoadRatesCommand, CanExecuteLoadRatesCommand);

        SaveDataCommand = new LambdaCommand(OnExecuteSaveDataCommand, CanExecuteSaveDataCommand);
    }
}