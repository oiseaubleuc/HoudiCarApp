using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using System.Collections.Generic;
using System.Windows;
using System.Linq;
using HoudiCarApp.Models;
using Microsoft.EntityFrameworkCore;
using AutoProject.Views;
using HoudiCarApp.Models;

namespace HoudiCarApp
{
    public partial class Dashboard : Window
    {
        private List<Car> _cars;

        public Dashboard()
        {
           // InitializeComponent();
            LoadCars();
        }

        private void LoadCars()
        {
            using (var context = new CarDealershipContext())
            {
                _cars = context.Cars.ToList();
            }
           // CarListView.ItemsSource = _cars;
        }

        private void AddCarButton_Click(object sender, RoutedEventArgs e)
        {
            AddCar addCarWindow = new AddCar();
            addCarWindow.ShowDialog();
            LoadCars();
        }

        private void EditCarButton_Click(object sender, RoutedEventArgs e)
        {
            /*
            if (CarListView.SelectedItem is Car selectedCar)
            {
                //EditCar editCarWindow = new EditCar(selectedCar);
                //editCarWindow.ShowDialog();
                LoadCars(); 
            }
            else
            {
                MessageBox.Show("Selecteer een advertentie om te bewerken.", "Waarschuwing", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            */
        }

        private void DeleteCarButton_Click(object sender, RoutedEventArgs e)
        {
            /*
            if (CarListView.SelectedItem is Car selectedCar)
            {
                using (var context = new CarDealershipContext())
                {
                    context.Cars.Remove(selectedCar);
                    context.SaveChanges();
                }
                LoadCars(); 
            }
            else
            {
                MessageBox.Show("Selecteer een advertentie om te verwijderen.", "Waarschuwing", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            */
        }
    }
}
