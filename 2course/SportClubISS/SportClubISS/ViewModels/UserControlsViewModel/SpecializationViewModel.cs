using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using SportClubISS.Models;
using SportClubISS.ViewModels.Base;

namespace SportClubISS.ViewModels.UserControlsViewModel;

public class SpecializationViewModel : BaseUserControlViewModel
{
    private string _name;

    public string Name
    {
        get => _name;
        set => Set(ref _name, value);
    }
    
    private List<Specialization> _specializations;

    public List<Specialization> Specializations
    {
        get => _specializations;
        set => Set(ref _specializations, value);
    }
    
    protected override void OnCreateRecordCommandExecute(object p)
    {
        _repository.CreateSpecialization(Name);

        IsViewState = Visibility.Visible;
        IsCreatOrEditSate = Visibility.Collapsed;
        
        Specializations = null;
        Specializations = _repository.GetAllSpecializations();
    }

    protected override void OnDeleteRecordCommandExecute(object p)
    {
        _repository.DeleteSpecializationByGuid((p as Specialization).Id);
        Specializations = _repository.GetAllSpecializations();
    }
    
    public SpecializationViewModel() : base()
    {
        _specializations = _repository.GetAllSpecializations();
    }

    
}