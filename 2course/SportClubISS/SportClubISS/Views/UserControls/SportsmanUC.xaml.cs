using System.Windows.Controls;
using SportClubISS.ViewModels.Base;

namespace SportClubISS.Views;

public partial class SportsmanUC : UserControl
{
    public SportsmanUC(ViewModel dataContext)
    {
        InitializeComponent();

        DataContext = dataContext;
    }
}