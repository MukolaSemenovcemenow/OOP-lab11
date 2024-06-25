using System.Windows;

namespace CityDirectory
{
    public partial class AddEnterpriseWindow : Window
    {
        public AddEnterpriseWindow()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var enterprise = new Enterprise
            {
                Name = NameTextBox.Text,
                Address = AddressTextBox.Text,
                Phone = PhoneTextBox.Text
            };
            DatabaseHelper.AddEnterprise(enterprise);
            this.Close();
        }
    }
}
