using System.Windows.Controls;
using SportClubISS.ViewModels.Base;

namespace SportClubISS.Views.UserControls;

public partial class CoachesUS : UserControl
{
    public CoachesUS(ViewModel dataContext)
    {
        InitializeComponent();

        DataContext = dataContext;
    }
}