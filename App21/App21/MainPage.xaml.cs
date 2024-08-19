using System;
using Xamarin.Forms;

namespace App21
{
    public partial class MainPage : ContentPage
    {
        internal string SelectedTopping;

        public MainPage()
        {
            InitializeComponent();
        }

        private void PlaceOrder_Clicked(object sender, EventArgs e)
        {
            double totalPrice = 0;

            if (SmallRadioButton.IsChecked)
                totalPrice += 300;
            else if (MediumRadioButton.IsChecked)
                totalPrice += 400;
            else if (LargeRadioButton.IsChecked)
                totalPrice += 500;

            if (FrenchFriesCheckBox.IsChecked)
                totalPrice += 100;
            if (SideSaladCheckBox.IsChecked)
                totalPrice += 150;
            if (OnionRingsCheckBox.IsChecked)
                totalPrice += 175;

            string selectedTopping = ToppingsPicker.SelectedItem as string;
            if (!string.IsNullOrEmpty(selectedTopping))
            {
                string[] splitTopping = selectedTopping.Split(new string[] { " - $" }, StringSplitOptions.None);
                if (splitTopping.Length == 2)
                {
                    if (double.TryParse(splitTopping[1], out double toppingPrice))
                        totalPrice += toppingPrice;
                }
            }

            Navigation.PushAsync(new OrderSummaryPage(totalPrice));
        }
    }
}
