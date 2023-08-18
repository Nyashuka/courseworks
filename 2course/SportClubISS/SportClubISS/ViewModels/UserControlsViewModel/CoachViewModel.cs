using System.Collections.Generic;
using System.Windows;
using SportClubISS.Models;
using SportClubISS.ViewModels.Base;

namespace SportClubISS.ViewModels.UserControlsViewModel;

public class CoachViewModel : BaseUserControlViewModel
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
    
    private List<Coach> _coaches;

    public List<Coach> Coaches
    {
        get => _coaches;
        set => Set(ref _coaches, value);
    }
    
    protected override void OnCreateRecordCommandExecute(object p)
    {
        _repository.CreateCoach(FullName, Age, PhoneNumber, Specialization.Id, SportClub.Id);
        
        IsViewState = Visibility.Visible;
        IsCreatOrEditSate = Visibility.Collapsed;
        
        Coaches = null;
        Coaches = _repository.GetAllCoaches();
    }

    protected override void OnDeleteRecordCommandExecute(object p)
    {
        _repository.DeleteCoachByGuid((p as Coach).Id);
    }
    
    public CoachViewModel() : base()
    {
        Specializations = _repository.GetAllSpecializations();
        Coaches = _repository.GetAllCoaches();
        SportClubs = _repository.GetAllSportClubs();
    }

}