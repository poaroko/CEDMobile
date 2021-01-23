using System;
using System.Collections.Generic;
using System.Text;
using CEDMobile.Model;

namespace CEDMobile.ViewModel
{
    public class PersonViewModel : BaseViewModel
    {
        private PersonModel personModel;
        public PersonViewModel()
        {
            // set some default here for example
            personModel = new PersonModel
            {
                FirstName = "first",
                LastName = "last"
            };
        }
        public string FirstName
        {
            get { return personModel.FirstName; }
            set
            {
                personModel.FirstName = value;
                OnPropertyChanged("FirstName");
                OnPropertyChanged("FullName");
            }
        }
        public string LastName
        {
            get { return personModel.LastName; }
            set
            {
                personModel.LastName = value;
                OnPropertyChanged("LastName");
                OnPropertyChanged("FullName");
            }
        }
        public string FullName
        {
            get { return personModel.FullName; }
        }
    }
}


