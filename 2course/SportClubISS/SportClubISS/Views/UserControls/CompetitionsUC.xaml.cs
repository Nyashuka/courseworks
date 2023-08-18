using System.Windows.Controls;
using SportClubISS.ViewModels.Base;

namespace SportClubISS.Views.UserControls;

public partial class CompetitionsUC : UserControl
{
    public CompetitionsUC(ViewModel dataContext)
    {
        InitializeComponent();

        DataContext = dataContext;
    }
}