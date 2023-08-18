using System.Windows.Controls;
using SportClubISS.ViewModels.Base;

namespace SportClubISS.Views;

public partial class SpecializationUS : UserControl
{
    public SpecializationUS(ViewModel dataContext)
    {
        InitializeComponent();

        DataContext = dataContext;
    }
}