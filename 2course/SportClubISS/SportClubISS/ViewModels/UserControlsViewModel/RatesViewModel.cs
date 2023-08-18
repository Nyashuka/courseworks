using System.Collections.Generic;
using System.Windows.Documents;
using System.Windows.Input;
using SportClubISS.Infrastructure.Commands;
using SportClubISS.Models;
using SportClubISS.Models.Rating;
using SportClubISS.ViewModels.Base;

namespace SportClubISS.ViewModels.UserControlsViewModel;

public class RatesViewModel : BaseUserControlViewModel
{
    private List<SportMember> _sportMembers;

    public List<SportMember> SportMembers
    {
        get => _sportMembers;
        set => Set(ref _sportMembers, value);
    }

    protected override void OnCreateRecordCommandExecute(object p)
    {
        throw new System.NotImplementedException();
    }

    protected override void OnDeleteRecordCommandExecute(object p)
    {
        throw new System.NotImplementedException();
    }

    public ICommand FilterSelectCommand { get; }

    private bool CanExecuteFilterSelectCommand(object p) => true;

    private void OnExecuteFilterSelectCommand(object p)
    {
        SelectedFilter.FilterAction?.Invoke();
    }

    private List<FilterData> _filterData;
    public List<FilterData> FilterData
    {
        get => _filterData; 
        set => Set(ref _filterData, value);
    }

    private FilterData _selectedFilter;

    public FilterData SelectedFilter
    {
        get => _selectedFilter;
        set => Set(ref _selectedFilter, value);
    }

    private void LoadSportsman()
    {
        SportMembers = new List<SportMember>(_repository.GetAllSportsmen());
    }

    private void LoadCoaches()
    {
        SportMembers = new List<SportMember>(_repository.GetAllCoaches());
    }

    public RatesViewModel() : base()
    {
        FilterSelectCommand = new LambdaCommand(OnExecuteFilterSelectCommand, CanExecuteFilterSelectCommand);
        FilterData = new List<FilterData>()
        {
            new FilterData("Coaches", LoadCoaches),
            new FilterData("Sportsmen", LoadSportsman)
        };
    }
}