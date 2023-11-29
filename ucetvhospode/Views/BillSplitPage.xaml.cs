using ucetvhospode.ViewModels;

namespace ucetvhospode.Views;

public partial class BillSplitPage : ContentPage
{
    public BillSplitPage()
    {
        InitializeComponent();
        BindingContext = new BillSplitViewModel();
    }

}