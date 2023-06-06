using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_10
{
    class Contact : INotifyPropertyChanged
    {
        string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FullName));
                OnPropertyChanged(nameof(Info));
            }
        }
        string surname;
        public string Surname
        {
            get => surname;
            set
            {
                surname = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FullName));
                OnPropertyChanged(nameof(Info));
            }
        }
        string phoneNumber;
        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                phoneNumber = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Info));
            }
        }
        string country;
        public string Country
        {
            get => country;
            set 
            {
                country = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Info));
            }
        }
        bool isImportant;
        public bool IsImportant
        {
            get => isImportant;
            set
            {
                //if (isImportant == true)
                //    isImportant = "*";
                isImportant = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Info));
            }
        }
        public List<Contact> Contacts { get; set; }
        public string FullName => Name + " " + Surname;
        public string Info => FullName + "\n" + "+" + PhoneNumber + "\n" + Country + "\n" + "Is Important: " + "\n" + IsImportant;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
