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
using Interfaces;

namespace TestsApplication.Menu
{
    /// <summary>
    /// Interaction logic for TestAdd.xaml
    /// </summary>
    public partial class TestAdd : UserControl, ISwitchable
    {
        public TestAdd()
        {
            InitializeComponent();
            DataContext = new AddTestViewModel();
        }

        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }
    }
}
