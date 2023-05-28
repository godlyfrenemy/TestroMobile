using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testro.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Testro.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TestPage : ContentPage
	{
		public TestPage (long testId)
		{
			InitializeComponent ();
            BindingContext = new TestProcessViewModel(testId);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            (BindingContext as TestProcessViewModel).OnAppearing();
        }

    }
}