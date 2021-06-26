using Exams.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Exams
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged { 
        public string SelectedType = "";
        private IEnumerable<Patient> _PatientList = null;
        public IEnumerable<Patient> PatientList{
            get
                {
                var res = _PatientList;
                
                res = res.Where(c => (SelectedType == "Все породы" || c.TreatmentType == SelectedType));
                if (SearchFilter != "")
                    res = res.Where(c => c.Name.IndexOf(SearchFilter, StringComparison.OrdinalIgnoreCase) >= 0);
                if (SortAsc) res = res.OrderBy(c => c.Age);
                else res = res.OrderByDescending(c => c.Age);                            
                return res;
                }
            set
                {
                _PatientList = value;
            }
        }
        
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Globals.dataProvider = new LocalDataProvider();
            PatientList = Globals.dataProvider.GetPatients();
            Globals.dataProvider = new DataProvider(@"../../buyers.xml");
            PatientList = Globals.dataProvider.GetPatients();
            PatientTypeList = Globals.dataProvider.GetPatientTypes().ToList();
            PatientTypeList.Insert(0, new PatientType { Title = "Все типы" });
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        public List<PatientType> PatientTypeList { get; set; }

        private void TypeFilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedType = (TypeFilterComboBox.SelectedItem as PatientType).Title;
            Invalidate();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void Invalidate()
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("PatientList"));
        }
        private string SearchFilter = "";

        private void SearchFilter_KeyUp(object sender, KeyEventArgs e)
        {
            SearchFilter = SearchFilterTextBox.Text;
            Invalidate();
        }
        private bool SortAsc = true;

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            SortAsc = (sender as RadioButton).Tag.ToString() == "1";
            Invalidate();
        }

    }
}
