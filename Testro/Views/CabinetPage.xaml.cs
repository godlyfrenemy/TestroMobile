using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testro.Models;
using Testro.ViewModels;
using Testro.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Testro.Views
{
    public partial class CabinetPage : ContentPage
    {
        public CabinetPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((CabinetViewModel)BindingContext).OnAppearing();
        }

        private void UserName_Unfocused(object sender, FocusEventArgs e)
        {
            ((CabinetViewModel)BindingContext).UserName.ModifyValueCommand.Execute(sender);
        }

        private void UserName_Focused(object sender, FocusEventArgs e)
        {        
            ((CabinetViewModel)BindingContext).UserName.SaveLastValueCommand.Execute(sender);
        }

        private void UserSurname_Unfocused(object sender, FocusEventArgs e)
        {
            ((CabinetViewModel)BindingContext).UserSurname.ModifyValueCommand.Execute(sender);
        }

        private void UserSurname_Focused(object sender, FocusEventArgs e)
        {
            ((CabinetViewModel)BindingContext).UserSurname.SaveLastValueCommand.Execute(sender);
        }

        private void UserForm_Unfocused(object sender, FocusEventArgs e)
        {
            ((CabinetViewModel)BindingContext).UserForm.ModifyValueCommand.Execute(sender);
        }

        private void UserForm_Focused(object sender, FocusEventArgs e)
        {
            ((CabinetViewModel)BindingContext).UserForm.SaveLastValueCommand.Execute(sender);
        }
    }
}