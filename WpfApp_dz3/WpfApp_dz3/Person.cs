using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp_dz3
{
    public class Person : INotifyPropertyChanged
    {
        private string name;
        private string surName;
        private string post;
        private int age;
        public string Name
        {
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
            get
            {
                return name;
            }
        }
        public string SurName
        {
            set
            {
                surName = value;
                OnPropertyChanged("SurName");
            }
            get
            {
                return surName;
            }
        }
        public string Post
        {
            set
            {
                post = value;
                OnPropertyChanged("Post");
            }
            get
            {
                return post;
            }
        }
        public int Age
        {
            set
            {
                age = value;
                OnPropertyChanged("Age");
            }
            get
            {
                return age;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
