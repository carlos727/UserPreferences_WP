using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Windows.Navigation;

namespace Configuraciones_WP
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            using (Data context = new Data(App.DataconnectionString))
            {
                if (!context.DatabaseExists())
                    context.CreateDatabase();

                var user_exist = (from user in context.User select user).FirstOrDefault();
                if (user_exist == null)
                {
                    User user = new User();
                    user.name = "User Name";
                    user.age = "User age";
                    user.gender = "User gender";
                    context.User.InsertOnSubmit(user);
                    context.SubmitChanges();
                }
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            using (Data context = new Data(App.DataconnectionString))
            {
                var u = (from user in context.User select user).FirstOrDefault();
                name_txt.Text = u.name;
                age_txt.Text = u.age;
                gender_txt.Text = u.gender;
            }
        }

        private void settings(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Settings.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}