using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFHelloWorld.Models
{
    class Client : NotifyBase
    {
        private int id;
        private string name;
        private string lastname;

        public int Id
        {
            get => id;

            set
            {
                id = value;
                OnPropertyChanged("Id");
                OnPropertyChanged("DisplayName");
            }
        }

        public string Name
        {
            get => name;

            set
            {
                name = value;
                OnPropertyChanged("Name");
                OnPropertyChanged("DisplayName");
            }
        }

        public string Lastname
        {
            get => lastname;

            set
            {
                lastname = value;
                OnPropertyChanged("lastName");
                OnPropertyChanged("DisplayName");
            }
        }

        public string DisplayName { get => Id + "-" + Name + " " + Lastname; }
    }
}
