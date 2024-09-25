using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module0Exercise0.Model;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Module0Exercise0.ViewModel
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        //Role of ViewModel
        private Employee _employee;

        private string _fullName; //Variable for data conversion

        public EmployeeViewModel()
        {
            //Initialize a sample employee model. Coordination with Model
            _employee = new Employee { FirstName = "Marcos", LastName = "Highway", Position = "Admin", Department = "CCS", IsActive = true};

            //UI Thread Management
            LoadEmployeeDataCommand = new Command(async () => await LoadEmployeeDataAsync());

            Employees = new ObservableCollection<Employee>
            {
                new Employee {FirstName="Alice", LastName="Guo", Position = "Mayor", Department = "Bamban", IsActive = true},
                new Employee {FirstName="James", LastName="Bond", Position = "Detective", Department = "FEDS", IsActive = true},
                new Employee {FirstName="Dutch", LastName="Mill", Position = "Program Chair", Department = "CCS", IsActive = true}
            };

        }

        //Settig collections in public
        public ObservableCollection<Employee> Employees { get; set; }

        public string FullName
        {
            get => _fullName;
            set
            {
                if (_fullName != value)
                {
                    _fullName = value;
                    OnPropertyChanged(nameof(FullName));
                }
            }
        }

        //UI Thread Management
        public ICommand LoadEmployeeDataCommand { get; }

        //Two-way Data Binding and Data Conversion

        private async Task LoadEmployeeDataAsync()
        {
            await Task.Delay(1000); // I/O operation
            FullName = $"{_employee.FirstName} {_employee.LastName} {_employee.Position} {_employee.Department}"; //Data Conversion

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}