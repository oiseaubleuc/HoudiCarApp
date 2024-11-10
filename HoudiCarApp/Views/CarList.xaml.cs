using System.Collections.Generic;
using System.Linq;
using System.Windows;
using HoudiCarApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HoudiCarApp.Views
{
    public partial class CarList : Window
    {
        public CarList()
        {
            InitializeComponent();
            LoadPostedCars();
        }

        private void LoadPostedCars()
        {
            try
            {
                using (var context = new CarDealershipContext())
                {
                    List<Car> postedCars = context.Cars.Include(c => c.FuelType).ToList();

                    //CarListView.ItemsSource = postedCars;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fout bij het laden van advertenties: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
