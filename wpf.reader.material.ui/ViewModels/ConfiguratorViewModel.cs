using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using wpf.reader.material.ui.Models;

namespace wpf.reader.material.ui.ViewModels
{
    
    public class ConfiguratorViewModel : INotifyPropertyChanged
    {
        const string CONFIG_FILE_NAME = "configurator.json";

        public event PropertyChangedEventHandler PropertyChanged;

        private Person _selectedPerson;

        private Role _selectedRole;
            
        public List<Configurator> Configurator { get; set; }

        public List<Role> Roles { get; set; }

        public List<Person> Persons { get; set; }
            
        public Person SelectedPerson
        {
            get
            {
                return _selectedPerson;
            }
            set
            {
                _selectedPerson = value;

                OnPropertyChanged("SelectedPerson");

                this.Roles = _selectedPerson?.Roles;

                OnPropertyChanged("Roles");
            }
        }

        public Role SelectedRole
        {
            get
            {
                return _selectedRole;
            }
            set
            {
                _selectedRole = value;

                OnPropertyChanged("SelectedRole");
            }
        }

        public ConfiguratorViewModel()
        {
            Configurator = LoadConfiguration();

            Persons = new List<Person>();

            Persons.AddRange(from item in Configurator
                            select item.Person);
        }

        private void Clear()
        {               
            SelectedRole = null;

            SelectedPerson = null;            
        }

        private void Execute(Person obj)
        {
            // Logic to save, print or send to external app            
        }

        private List<Configurator> LoadConfiguration()
        {
            var testFile = GetConfiguratorData(CONFIG_FILE_NAME);

            var configJson = File.ReadAllText(testFile);

            var persons = JsonConvert.DeserializeObject<List<Configurator>>(configJson);

            return persons;
        }

        private string GetConfiguratorData(string name)
        {
            var baseDir = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory())?.ToString() ?? string.Empty)?.ToString();

            return Path.Combine(baseDir ?? string.Empty, name);
        }

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
    
}