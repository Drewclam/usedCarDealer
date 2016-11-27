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
    public partial class sellVehicle : Form
    {
        private Vehicle cls;
        List<Vehicle> filterList;

        public sellVehicle()
        {
            InitializeComponent();
        }

        //close button
        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
        }

        //Show compact cars in inventory
        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (radioButton1.Checked == true)
            {
                filterList = Inventory.vehList.FindAll(p => p is Compact);
                foreach (Vehicle veh in filterList)
                {
                    Compact v = (Compact)veh;
                    listBox1.Items.Add(v.make + " | " + v.model + " | " + v.color + " | " + "Hatchback: " + v.isHatchBack + " | " + v.purchasePrice);
                }
            }
            else
            {

                filterList = Inventory.vehList.FindAll(p => p is Pickup);
                foreach (Vehicle veh in filterList)
                {
                    Pickup v = (Pickup)veh;
                    listBox1.Items.Add(v.make + " | " + v.model + " | " + v.color + " | " + "Axle Ratio: " + v.axleRatio + " | " + v.purchasePrice);
                }
            }
        }

        //validates Selling Price and updates HST Collected
        private void textBox2_Leave(object sender, EventArgs e)
        {
            double sellingPrice;
            if (double.TryParse(textBox2.Text, out sellingPrice))
            {
                //rounds Selling Price to 2 decimals
                textBox2.Text = Math.Round(sellingPrice, 2).ToString();
                //multiply Selling Price by 1.13 and round to 2 decimals
                textBox3.Text = Math.Round((sellingPrice * 0.13), 2).ToString();
            }
            //if false, errors and clears field
            else
            {
                MessageBox.Show("Please enter a number!");
                textBox2.Text = "";
            }
        }
        //validates Upgrade Cost 
        private void textBox4_Leave(object sender, EventArgs e)
        {
            double upgradeCost;
            //rounds to 2 decimal places
            if (double.TryParse(textBox4.Text, out upgradeCost))
            {
                textBox4.Text = Math.Round(upgradeCost, 2).ToString();
            }
            //if false, errors and clears field
            else
            {
                MessageBox.Show("Please enter a number!");
                textBox4.Text = "";
            }
        }
        //sell Button
        private void button2_Click(object textBox, EventArgs e)
        {
            //validating field has input
            if (listBox1.SelectedItem == null || textBox2.Text == String.Empty || textBox4.Text == String.Empty)
            {
                MessageBox.Show("Missing input!");
            }

            int index2 = listBox1.SelectedIndex;
            Vehicle cls = filterList[index2];
            //profit for vehicle is calculated, total profit updated
            // total HST collected updated
            int vehicleProfit;

            vehicleProfit = Convert.ToInt32(textBox2.Text) - Convert.ToInt32(cls.purchasePrice) - Convert.ToInt32(cls.hstPaid) - Convert.ToInt32(textBox4.Text);
            Inventory.totalProfit += vehicleProfit;
            Inventory.hstCollected += float.Parse(textBox3.Text);
            //fields cleared
            MessageBox.Show("Vehicle Removed from Inventory!");
            textBox2.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";

            Inventory.vehList.Remove(cls);
            radioButton_CheckedChanged(textBox, e);
        }
    }
    }


