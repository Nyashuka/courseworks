using System.Windows.Controls;
using SportClubISS.ViewModels.Base;

namespace SportClubISS.Views.UserControls;

public partial class SportClubUS : UserControl
{
    public SportClubUS(ViewModel dataContext)
    {
        InitializeComponent();

        DataContext = dataContext;

    }
}