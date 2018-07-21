using System;
using System.Collections.Generic;
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
using System.Collections.ObjectModel;

namespace WpfApp_dz3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Person> Persons { set; get; }
        public MainWindow()
        {
            InitializeComponent();
            Persons = new ObservableCollection<Person>
            {
                new Person{ Name = "Сергей", SurName="Петров", Post="Менеджер", Age = 33},
                new Person{ Name = "Пётр", SurName="Сергеев", Post="Дизайнер", Age = 41}
            };
            this.DataContext = Persons;
            list.ItemsSource = Persons; 
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            if (!isEmptyFild(TextBoxName, TextBoxSurname, TextBoxPost, TextBoxAge))
            {
                return;
            }
            Persons.Add(new Person { Name = TextBoxName.Text, SurName = TextBoxSurname.Text, Post = TextBoxPost.Text, Age = Convert.ToInt32(TextBoxAge.Text) });
            if (list.Items.Count != 0)
            {
                header.Visibility = Visibility.Visible;
            }
            Cliar();
        }

        private void Button_Del(object sender, RoutedEventArgs e)
        {
            Cliar();
            ChangeAdd.Visibility = Visibility.Hidden;
            if (list.SelectedIndex != -1)
            {
                Persons.RemoveAt(list.SelectedIndex);
            }
            if (list.Items.Count == 0)
            {
                header.Visibility = Visibility.Hidden;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            ChangeAdd.Visibility = Visibility.Visible;
            list.SelectedIndex = -1;
            LabelContent.Content = btn.Content;
            Cliar();
            ok.IsEnabled = true;
        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
               
                Person per = list.SelectedValue as Person;
                if (per != null)
                {
                    
                    ChangeAdd.Visibility = Visibility.Visible;
                    TextBoxName.Text = per.Name;
                    TextBoxSurname.Text = per.SurName;
                    TextBoxPost.Text = per.Post;
                    TextBoxAge.Text = per.Age.ToString();
                }
                ok.IsEnabled = false;
                LabelContent.Content = "Данные";
        }
        private void Button_Cliar(object sender, RoutedEventArgs e)
        {
            Cliar();
        }
        private void Cliar()
        {
            TextBoxName.Text = "";
            TextBoxSurname.Text = "";
            TextBoxPost.Text = "";
            TextBoxAge.Text = "";
        }

        private void Button_Cancel(object sender, RoutedEventArgs e)
        {
            Cliar();
            ChangeAdd.Visibility = Visibility.Hidden;
            list.SelectedIndex = -1;
        }

        private void Button_Change(object sender, RoutedEventArgs e)
        {
            if (list.SelectedItem != null)
            {
                if (!isEmptyFild(TextBoxName, TextBoxSurname, TextBoxPost, TextBoxAge))
                {
                    return;
                }
                Person per = list.SelectedValue as Person;
                per.Name = TextBoxName.Text;
                per.SurName = TextBoxSurname.Text;
                per.Post = TextBoxPost.Text;
                per.Age = Convert.ToInt32(TextBoxAge.Text);
            }
            
        }
        private bool isEmptyFild(TextBox name, TextBox sname, TextBox post, TextBox age)
        {
            try
            {
                if (name.Text == String.Empty)
                {
                    MessageBox.Show("Поле Имя не заполненно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                if (sname.Text == String.Empty)
                {
                    MessageBox.Show("Поле Фамилия не заполненно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                if (post.Text == String.Empty)
                {
                    MessageBox.Show("Поле Должность не заполненно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                if (age.Text == String.Empty)
                {
                    MessageBox.Show("Поле Возраст не заполненно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                int number;
                bool result = Int32.TryParse(age.Text, out number);
                if (!result)
                {
                    MessageBox.Show("Поле Возраст заполненно не корректно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                
            }
            catch (Exception)
            {

            }
            return true;
        }
    }
}
