using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Configuraciones_WP
{
    public partial class Settings : PhoneApplicationPage
    {
        public Settings()
        {
            InitializeComponent();
            male.IsChecked = true;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            using (Data context = new Data(App.DataconnectionString))
            {
                var UserLoaded = (from user in context.User select user).FirstOrDefault();
                if (UserLoaded != null)
                {
                    name.Text = UserLoaded.name;
                    age.Text = UserLoaded.age;
                    if (UserLoaded.gender == "Male")
                    {
                        male.IsChecked = true;
                        female.IsChecked = false;
                    }
                    else
                    {
                        male.IsChecked = false;
                        female.IsChecked = true;
                    }
                }
            }            
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            using (Data context = new Data(App.DataconnectionString))
            {
                var u = (from user in context.User select user).FirstOrDefault();
                u.name = name.Text;
                u.age = age.Text;
                if (male.IsChecked == true)
                {
                    u.gender = "Male";
                }
                else
                {
                    u.gender = "Female";
                }
                context.SubmitChanges();
            }
        }
    }
}