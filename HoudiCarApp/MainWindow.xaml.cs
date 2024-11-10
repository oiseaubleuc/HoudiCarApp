using System.Collections.Generic;
using System.Linq;
using System.Windows;
using HoudiCarApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HoudiCarApp
{
    public partial class MainWindow : Window
    {
        private List<Car> _cars;

        public MainWindow()
        {
            InitializeComponent();
            LoadCars();
        }

        private void LoadCars()
        {
            try
            {
                using (var context = new CarDealershipContext())
                {
                    _cars = context.Cars.Include(c => c.FuelType).ToList();
                }
                CarListView.ItemsSource = _cars;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fout bij het laden van auto's: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            FilterCars();
        }

        private void FilterCars()
        {
            var filteredCars = _cars;

            // Filter op model
            if (!string.IsNullOrWhiteSpace(ModelTextBox.Text))
            {
                filteredCars = filteredCars.Where(c => c.Model.Contains(ModelTextBox.Text, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            // Filter op locatie
            if (!string.IsNullOrWhiteSpace(LocationTextBox.Text))
            {
                filteredCars = filteredCars.Where(c => c.Location.Contains(LocationTextBox.Text, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            // Filter op prijs
            int minPrice = GetComboBoxValueAsInt(MinPriceComboBox);
            int maxPrice = GetComboBoxValueAsInt(MaxPriceComboBox);

            if (minPrice > 0)
            {
                filteredCars = filteredCars.Where(c => c.Price >= minPrice).ToList();
            }
            if (maxPrice > 0)
            {
                filteredCars = filteredCars.Where(c => c.Price <= maxPrice).ToList();
            }

            // Filter op kilometerstand
            int minKm = GetComboBoxValueAsInt(MinKilometerstandComboBox);
            int maxKm = GetComboBoxValueAsInt(MaxKilometerstandComboBox);

            if (minKm > 0)
            {
                filteredCars = filteredCars.Where(c => c.Kilometerstand >= minKm).ToList();
            }
            if (maxKm > 0)
            {
                filteredCars = filteredCars.Where(c => c.Kilometerstand <= maxKm).ToList();
            }

            // Filter op jaar
            int minYear = GetComboBoxValueAsInt(MinJaarComboBox);
            int maxYear = GetComboBoxValueAsInt(MaxJaarComboBox);

            if (minYear > 0)
            {
                filteredCars = filteredCars.Where(c => c.Jaar >= minYear).ToList();
            }
            if (maxYear > 0)
            {
                filteredCars = filteredCars.Where(c => c.Jaar <= maxYear).ToList();
            }

            CarListView.ItemsSource = filteredCars;
        }

        private int GetComboBoxValueAsInt(System.Windows.Controls.ComboBox comboBox)
        {
            if (comboBox.SelectedItem is System.Windows.Controls.ComboBoxItem selectedItem)
            {
                if (int.TryParse(selectedItem.Content.ToString(), out int value))
                {
                    return value;
                }
            }
            return 0;
        }

        // Navigatie naar andere schermen
        private void OpenMainWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void OpenCarList_Click(object sender, RoutedEventArgs e)
        {
            CarList carListWindow = new CarList();
            carListWindow.Show();
            this.Close();
        }

        private void OpenLogin_Click(object sender, RoutedEventArgs e)
        {
            Login loginWindow = new Login();
            loginWindow.Show();
            this.Close();
        }
    }
}
