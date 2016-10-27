using Interfaces;
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

namespace TestsApplication.Menu
{
    /// <summary>
    /// Interaction logic for TestEdit.xaml
    /// </summary>
    public partial class TestEdit : UserControl, ISwitchable
    {
        public TestEdit()
        {
            InitializeComponent();
            DataContext = new EditTestViewModel();
        }

        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }
    }
}
