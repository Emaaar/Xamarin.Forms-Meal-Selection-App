using Xamarin.Forms;

namespace App21
{
    public partial class OrderSummaryPage : ContentPage
    {
        public OrderSummaryPage(double totalPrice)
        {
            InitializeComponent();
            PopulateOrderDetails(totalPrice);
        }

        private void PopulateOrderDetails(double totalPrice)
        {
            string orderDetails = "Selected Items:\n";

            string selectedTopping = (BindingContext as MainPage)?.SelectedTopping;
            if (!string.IsNullOrEmpty(selectedTopping))
                orderDetails += $"Toppings: {selectedTopping}\n";

            OrderDetailsLabel.Text = orderDetails;
            TotalPriceLabel.Text = $"Total Price: ${totalPrice.ToString("F2")}";
        }
    }
}
