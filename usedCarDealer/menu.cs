using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace usedCarDealer
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            buyVehicle frm = new buyVehicle();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
          sellVehicle frm2 = new sellVehicle();
          frm2.Show();

        }
        //total profit and total HST collected are updated
        private void menu_Activated(object sender, EventArgs e)
        {
            label6.Text = Inventory.hstCollected.ToString("c");
            label5.Text = Inventory.totalProfit.ToString("c");
        }
    }
}
