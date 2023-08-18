using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using SportClubISS.Infrastructure.Commands;
using SportClubISS.Models;
using SportClubISS.ViewModels.Base;

namespace SportClubISS.ViewModels.UserControlsViewModel;

public class SportsmenViewModel : BaseUserControlViewModel
{
    private string _fullName;

    public string FullName
    {
        get => _fullName;
        set => Set(ref _fullName, value);
    }

    private string _phoneNumber;

    public string PhoneNumber
    {
        get => _phoneNumber;
        set => Set(ref _phoneNumber, value);
    }

    private int _age;

    public int Age
    {
        get => _age;
        set => Set(ref _age, value);
    }

    private Specialization _specialization;

    public Specialization Specialization
    {
        get => _specialization;
        set => Set(ref _specialization, value);
    }

    private List<Specialization> _specializations;

    public List<Specialization> Specializations
    {
        get => _specializations;
        set => Set(ref _specializations, value);
    }
    
    private SportClub _sportClub;

    public SportClub SportClub
    {
        get => _sportClub;
        set => Set(ref _sportClub, value);
    }
    
    private List<SportClub> _sportClubs;

    public List<SportClub> SportClubs
    {
        get => _sportClubs;
        set => Set(ref _sportClubs, value);
    }
    
    private Coach _coach;

    public Coach Coach
    {
        get => _coach;
        set => Set(ref _coach, value);
    }
    
    private List<Coach> _coaches;

    public List<Coach> Coaches
    {
        get => _coaches;
        set => Set(ref _coaches, value);
    }
    
    private List<Sportsman> _sportsmen;

    public List<Sportsman> Sportsmen
    {
        get => _sportsmen;
        set => Set(ref _sportsmen, value);
    }
    
    protected override void OnCreateRecordCommandExecute(object p)
    {
        _repository.CreateSportsman(FullName, Age, PhoneNumber, Specialization.Id, SportClub.Id, Coach.Id);
        
        IsViewState = Visibility.Visible;
        IsCreatOrEditSate = Visibility.Collapsed;

        Sportsmen = null;
        Sportsmen = _repository.GetAllSportsmen();
    }

    protected override void OnDeleteRecordCommandExecute(object p)
    {
        _repository.DeleteSportsmanByGuid(((Sportsman)p).Id);
    }
    
    private Visibility _isEditState;

    public Visibility IsEditState
    {
        get => _isEditState;
        set => Set(ref _isEditState, value);
    }

    private Sportsman _sportsman;

    public Sportsman Sportsman
    {
        get => _sportsman;
        set => Set(ref _sportsman, value);
    }
    
    public ICommand EditRecordCommand { get; }
        
    private bool CanEditRecordCommandExecute(object p) => true;

    private void OnEditRecordCommandExecute(object p)
    {
        IsEditState = Visibility.Visible;
        IsViewState = Visibility.Collapsed;
        IsCreatOrEditSate = Visibility.Collapsed;
        
        
        Sportsman = (Sportsman)p;
        FullName = Sportsman.FullName;
        PhoneNumber = Sportsman.PhoneNumber;
        Age = Sportsman.Age;
        SportClub = _repository.GetSportClubByGuid(Sportsman.SportClubId);
        Specialization = _repository.GetSpecializationByGuid(Sportsman.SpecializationId);
        Coach = _repository.GetCoachByGuid(_sportsman.Coach);
    }
    
    public ICommand SaveRecordCommand { get; }
        
    private bool CanSaveRecordCommandExecute(object p) => true;

    private void OnSaveRecordCommandExecute(object p)
    {
        IsEditState = Visibility.Collapsed;
        IsViewState = Visibility.Visible;
        IsCreatOrEditSate = Visibility.Collapsed;
        
        Sportsman.UpdateInfo(FullName, Age, PhoneNumber, Specialization.Id, SportClub.Id, Coach.Id);
        FullName = Sportsman.FullName;
        PhoneNumber = Sportsman.PhoneNumber;
        Age = Sportsman.Age;
        SportClub = _repository.GetSportClubByGuid(Sportsman.SportClubId);
        Specialization = _repository.GetSpecializationByGuid(Sportsman.SpecializationId);
        Coach = _repository.GetCoachByGuid(_sportsman.Coach);
        UpdateData();
    }

    private void UpdateData()
    {
        Sportsmen = null;
        Sportsmen = _repository.GetAllSportsmen();
        Specializations = _repository.GetAllSpecializations();
        SportClubs = _repository.GetAllSportClubs();
        Coaches = _repository.GetAllCoaches();
    }
    public SportsmenViewModel() : base()
    {
        UpdateData();
        IsEditState = Visibility.Collapsed;
        EditRecordCommand = new LambdaCommand(OnEditRecordCommandExecute, CanEditRecordCommandExecute);
        SaveRecordCommand = new LambdaCommand(OnSaveRecordCommandExecute, CanSaveRecordCommandExecute);
    }
}