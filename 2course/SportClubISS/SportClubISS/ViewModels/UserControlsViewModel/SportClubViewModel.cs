using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using SportClubISS.Models;
using SportClubISS.ViewModels.Base;

namespace SportClubISS.ViewModels.UserControlsViewModel;

public class SportClubViewModel : BaseUserControlViewModel
{
    private string _name;

    public string Name
    {
        get => _name;
        set => Set(ref _name, value);
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

    private List<SportClub> _sportClubs;

    public List<SportClub> SportClubs
    {
        get => _sportClubs;
        set => Set(ref _sportClubs, value);
    }

    protected override void OnCreateRecordCommandExecute(object p)
    {
        _repository.CreateSportClub(_name, Specialization.Id);
        IsViewState = Visibility.Visible;
        IsCreatOrEditSate = Visibility.Collapsed;

        SportClubs = null;
        SportClubs = _repository.GetAllSportClubs();
    }

    protected override void OnDeleteRecordCommandExecute(object p)
    {
        _repository.DeleteSportClubByGuid(((SportClub)p).Id);
    }
    
    

    public SportClubViewModel() : base()
    {
        Specializations = _repository.GetAllSpecializations();
        SportClubs = _repository.GetAllSportClubs();
    }
}