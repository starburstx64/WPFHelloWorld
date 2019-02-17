using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.ObjectModel;
using WPFHelloWorld.Models;

namespace WPFHelloWorld.MV
{
    class ClientViewModel : ObservableCollection<Client>, INotifyPropertyChanged
    {
        private int selectedIndex;

        private int id;
        private string name;
        private string lastName;
        private ICommand addClientCommand;
        private ICommand clearCommand;

        public int SelectedIndexOfCollection
        {
            get => selectedIndex;

            set
            {
                selectedIndex = value;
                OnPropertyChanged("SelectedIndexOfCollection");
                OnPropertyChanged("Id");
                OnPropertyChanged("Name");
                OnPropertyChanged("LastName");
            }
        }

        public int Id
        {
            get
            {
                if (SelectedIndexOfCollection > -1)
                {
                    return Items[SelectedIndexOfCollection].Id;
                }

                return id;
            }

            set
            {
                if (SelectedIndexOfCollection > -1)
                {
                    Items[SelectedIndexOfCollection].Id = value;
                }

                else
                {
                    id = value;
                }

                OnPropertyChanged("Id");
            }
        }

        public string Name
        {
            get
            {
                if (SelectedIndexOfCollection > -1)
                {
                    return Items[SelectedIndexOfCollection].Name;
                }

                return Name;
            }

            set
            {
                if (SelectedIndexOfCollection > -1)
                {
                    Items[SelectedIndexOfCollection].Name = value;
                }

                else
                {
                    Name = value;
                }

                OnPropertyChanged("Name");
            }
        }

        public string LastName
        {
            get
            {
                if (SelectedIndexOfCollection > -1)
                {
                    return Items[SelectedIndexOfCollection].LastName;
                }

                return LastName;
            }

            set
            {
                if (SelectedIndexOfCollection > -1)
                {
                    Items[SelectedIndexOfCollection].LastName = value;
                }

                else
                {
                    LastName = value;
                }

                OnPropertyChanged("LastName");
            }
        }

        public ICommand AddClientCommand
        {
            get => addClientCommand;

            set { addClientCommand = value }
        }

        public ICommand ClearCommand
        {
            get => clearCommand;

            set { clearCommand = value; }
        }

        public ClientViewModel()
        {
            Client vlClient1 = new Client();
            vlClient1.Id = 1;
            vlClient1.Name = "Pablo";
            vlClient1.LastName = "Gonzalez";
            Add(vlClient1);

            Client vlClient2 = new Client();
            vlClient2.Id = 2;
            vlClient2.Name = "Roberto";
            vlClient2.LastName = "Herrera";
            Add(vlClient2);

            Client vlClient3 = new Client();
            vlClient3.Id = 3;
            vlClient3.Name = "Anibal";
            vlClient3.LastName = "Salazar";
            Add(vlClient3);

            AddClientCommand = new CommandBase(param => this.AddClient());
            ClearCommand = new CommandBase(new Action<Object>(ClearClient));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void AddClient()
        {
            Client vlClient = new Client();
            vlClient.Id = Id;
            vlClient.Name = Name;
            vlClient.LastName = LastName;
            Add(vlClient);
        }

        private void ClearClient(object obj)
        {
            SelectedIndexOfCollection = -1;
            Id = 0;
            Name = "";
            LastName = "";
        }
    }
}
