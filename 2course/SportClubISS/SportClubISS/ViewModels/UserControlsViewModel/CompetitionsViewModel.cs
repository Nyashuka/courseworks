using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using SportClubISS.Infrastructure.Commands;
using SportClubISS.Models;
using SportClubISS.Models.Competitions;
using SportClubISS.ViewModels.Base;

namespace SportClubISS.ViewModels.UserControlsViewModel;

public class CompetitionsViewModel : BaseUserControlViewModel
{
    private string _name;

    public string Name
    {
        get => _name;
        set => Set(ref _name, value);
    } 
    
    private DateTime _eventDate;

    public DateTime EventDate
    {
        get => _eventDate;
        set => Set(ref _eventDate, value);
    } 
    
    private CompetitionStatus _status;

    public CompetitionStatus Status
    {
        get => _status;
        set => Set(ref _status, value);
    } 
    
    public IEnumerable<CompetitionStatus> CompetitionStatuses
    {
        get
        {
            return Enum.GetValues(typeof(CompetitionStatus)).Cast<CompetitionStatus>();
        }
    }
    
    private List<Competition> _competitions;

    public List<Competition> Competitions
    {
        get => _competitions;
        set => Set(ref _competitions, value);
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

    private List<CompetitionResult> _members;
    
    public List<CompetitionResult> Members
    {
        get => _members;
        set => Set(ref _members, value);
    }
    
    protected override void OnCreateRecordCommandExecute(object p)
    {
        _repository.CreateCompetition(Guid.NewGuid(), Name, EventDate, Specialization.Id, Status, new List<CompetitionResult>());
        IsViewState = Visibility.Visible;
        IsCreatOrEditSate = Visibility.Collapsed;
        UpdateData();
    }

    protected override void OnDeleteRecordCommandExecute(object p)
    {
        _repository.DeleteCompetition(((Competition)p).Id);
    }
    
    private Visibility _isAddMemberState;

    public Visibility IsAddMemberState
    {
        get => _isAddMemberState;
        set => Set(ref _isAddMemberState, value);
    }
    
    private Visibility _isEditState;

    public Visibility IsEditState
    {
        get => _isEditState;
        set => Set(ref _isEditState, value);
    }
    
    public ICommand EditRecordCommand { get; }
        
    private bool CanEditRecordCommandExecute(object p) => true;

    private void OnEditRecordCommandExecute(object p)
    {
        IsEditState = Visibility.Visible;
        IsViewState = Visibility.Collapsed;
        IsCreatOrEditSate = Visibility.Collapsed;
        
        SelectedCompetition = (Competition)p;
        Name = SelectedCompetition.Name;
        Specialization = _repository.GetSpecializationByGuid(SelectedCompetition.Specialization);
        EventDate = SelectedCompetition.EventDate;
        Status = SelectedCompetition.Status;
        Members = SelectedCompetition.Members;
    }
    
    public ICommand AddHalfCommand { get; }
        
    private bool CanAddHalfCommandExecute(object p) => true;

    private void OnAddHalfCommandExecute(object p)
    {
        ((CompetitionResult)p).AddHalfMark();
        Members = null;
        Members = SelectedCompetition.Members;
    }
    
    public ICommand SubtractHalfCommand { get; }
        
    private bool CanSubtractHalfCommandExecute(object p) => true;

    private void OnSubtractHalfCommandExecute(object p)
    {
        ((CompetitionResult)p).SubtractHalfMark();
        Members = null;
        Members = SelectedCompetition.Members;
    }
    
    public ICommand DeleteMemberCommand { get; }
        
    private bool CanDeleteMemberCommandExecute(object p) => true;

    private void OnDeleteMemberCommandExecute(object p)
    {
        SelectedCompetition.RemoveMember(((CompetitionResult)p).SportsmanId);
        Members = null;
        Members = SelectedCompetition.Members;
    }

    private Competition _selectedCompetition;

    public Competition SelectedCompetition
    {
        get => _selectedCompetition;
        set => Set(ref _selectedCompetition, value);
    }
    
    private List<Sportsman> _sportsmen;

    public List<Sportsman> Sportsmen
    {
        get => _sportsmen;
        set => Set(ref _sportsmen, value);
    }
    
    public ICommand AddMemberCommand { get; }
        
    private bool CanAddMemberCommandCommandExecute(object p) => true;

    private void OnAddMemberCommandCommandExecute(object p)
    {
        IsAddMemberState = Visibility.Visible;

        IsCreatOrEditSate = Visibility.Collapsed;
        IsViewState = Visibility.Collapsed;
        IsEditState = Visibility.Collapsed;

        Sportsmen = _repository.GetAllSportsmen();
    }


    public ICommand SelectMemberToAddCommand { get; }
        
    private bool CanSelectMemberToAddCommandExecute(object p) => true;

    private void OnSelectMemberToAddCommandExecute(object p)
    {
        IsEditState = Visibility.Visible;

        IsAddMemberState = Visibility.Collapsed;
        IsCreatOrEditSate = Visibility.Collapsed;
        IsViewState = Visibility.Collapsed;
        
        Sportsman sportsman = (Sportsman)p;
        SelectedCompetition.Members.Add(new CompetitionResult(sportsman.Id, 0));
        Members = null;
        Members = SelectedCompetition.Members;
    }

    private void UpdateData()
    {
        Specialization = null;
        Specializations = _repository.GetAllSpecializations();
        Competitions = null;
        Competitions = _repository.GetAllCompetitions();
        EventDate = DateTime.Now;
    }
    
    public CompetitionsViewModel() : base()
    {
        IsEditState = Visibility.Collapsed;
        IsAddMemberState = Visibility.Collapsed;

        UpdateData();

        EditRecordCommand = new LambdaCommand(OnEditRecordCommandExecute, CanEditRecordCommandExecute);
        AddHalfCommand = new LambdaCommand(OnAddHalfCommandExecute, CanAddHalfCommandExecute);
        SubtractHalfCommand = new LambdaCommand(OnSubtractHalfCommandExecute, CanSubtractHalfCommandExecute);
        AddMemberCommand = new LambdaCommand(OnAddMemberCommandCommandExecute, CanAddMemberCommandCommandExecute);
        SelectMemberToAddCommand =
            new LambdaCommand(OnSelectMemberToAddCommandExecute, CanSelectMemberToAddCommandExecute);

        DeleteMemberCommand = new LambdaCommand(OnDeleteMemberCommandExecute, CanDeleteMemberCommandExecute);
    }
}