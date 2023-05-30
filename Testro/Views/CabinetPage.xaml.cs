﻿using Testro.ViewModels;
using Xamarin.Forms;

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
            ((Entry)sender).Unfocus();
            ((CabinetViewModel)BindingContext).UserName.ModifyValueCommand.Execute(sender);
        }

        private void UserName_Focused(object sender, FocusEventArgs e)
        {
            ((Entry)sender).Focus();
            ((CabinetViewModel)BindingContext).UserName.SaveLastValueCommand.Execute(sender);
        }

        private void UserSurname_Unfocused(object sender, FocusEventArgs e)
        {
            ((Entry)sender).Unfocus();
            ((CabinetViewModel)BindingContext).UserSurname.ModifyValueCommand.Execute(sender);
        }

        private void UserSurname_Focused(object sender, FocusEventArgs e)
        {
            ((Entry)sender).Focus();
            ((CabinetViewModel)BindingContext).UserSurname.SaveLastValueCommand.Execute(sender);
        }

        private void UserForm_Unfocused(object sender, FocusEventArgs e)
        {
            ((Entry)sender).Unfocus();
            ((CabinetViewModel)BindingContext).UserForm.ModifyValueCommand.Execute(sender);
        }

        private void UserForm_Focused(object sender, FocusEventArgs e)
        {
            ((Entry)sender).Focus();
            ((CabinetViewModel)BindingContext).UserForm.SaveLastValueCommand.Execute(sender);
        }
    }
}