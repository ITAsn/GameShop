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
using System.Windows.Shapes;

namespace GameShop.Win
{
    /// <summary>
    /// Логика взаимодействия для SomeAdd.xaml
    /// </summary>
    public partial class SomeAdd : Window
    {
        public static bool PD=false;
        public SomeAdd(bool pd1)
        {
            InitializeComponent();
            PD = pd1;
        }
        GameShopDBEntities entities = new GameShopDBEntities();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(textBox1.Text))
                    if (PD)
                    {
                        int id1 = entities.Developers.ToList().Last().ID + 1;
                        Developers developers = new Developers()
                        {
                            ID = id1,
                            DeveloperName = textBox1.Text
                        };
                        entities.Developers.Add(developers);
                    }
                    else
                    {
                        int id1 = entities.Publishers.ToList().Last().ID + 1;
                        Publishers developers = new Publishers()
                        {
                            ID = id1,
                            PublisherName = textBox1.Text
                        };
                        entities.Publishers.Add(developers);
                    }
                entities.SaveChanges();
                this.DialogResult = true;
            }
            catch {
                throw (new Exception("Not good"));
                    }
          
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.DialogResult =false ;
        }
    }
}
