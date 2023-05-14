using System.ComponentModel;
using Testro.ViewModels;
using Xamarin.Forms;

namespace Testro.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}