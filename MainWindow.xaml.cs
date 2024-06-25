using System.Collections.Generic;
using System.Windows;

namespace CityDirectory
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DatabaseHelper.InitializeDatabase();
        }

        private void AddEnterprise_Click(object sender, RoutedEventArgs e)
        {
            AddEnterpriseWindow addWindow = new AddEnterpriseWindow();
            addWindow.ShowDialog();
            LoadEnterprises();
        }

        private void ViewAll_Click(object sender, RoutedEventArgs e)
        {
            LoadEnterprises();
        }

        private void LoadEnterprises()
        {
            List<Enterprise> enterprises = DatabaseHelper.GetAllEnterprises();
            EnterpriseListBox.Items.Clear();
            foreach (var enterprise in enterprises)
            {
                EnterpriseListBox.Items.Add(enterprise.ToString());
            }
        }
    }
}
