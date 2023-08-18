using System.Windows.Controls;
using SportClubISS.ViewModels.Base;

namespace SportClubISS.Views.UserControls;

public partial class RatesUC : UserControl
{
    public RatesUC(ViewModel dataContext)
    {
        InitializeComponent();

        DataContext = dataContext;
    }
}