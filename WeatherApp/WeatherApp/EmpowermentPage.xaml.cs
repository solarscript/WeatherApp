using System;
using Xamarin.Forms;

namespace EmpowermentApp
{
    public partial class EmpowermentPage : ContentPage
    {
        public EmpowermentPage()
        {
            InitializeComponent();

            //Set the default binding to a default object for now
            BindingContext = new Empowerment();
        }

        private async void GetEmpowermentBtn_Clicked(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(zipCodeEntry.Text))
            {
                Empowerment Empowerment = await Core.GetEmpowerment(zipCodeEntry.Text);
                BindingContext = Empowerment;
                getEmpowermentBtn.Text = "Search Again";
            }
        }
    }
}