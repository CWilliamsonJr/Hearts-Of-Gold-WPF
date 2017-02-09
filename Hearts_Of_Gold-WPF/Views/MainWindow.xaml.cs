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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Hearts_Of_Gold_WPF.Models;
using System.Data;
using System.Data.Entity;
//using System.Linq;

namespace Hearts_Of_Gold_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Hearts_Of_Gold_Entities _context = new Hearts_Of_Gold_Entities();
        public MainWindow()
        {
            InitializeComponent();
        }

       

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource itemViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("itemViewSource")));
            // Load data by setting the CollectionViewSource.Source property:

             itemViewSource.Source = _context.Items.Include(i => i.Donation_Categories.Categories).Include(i => i.Donation_Location.BusinessName).Include(i => i.User).ToList();
            
        }
    }
}
