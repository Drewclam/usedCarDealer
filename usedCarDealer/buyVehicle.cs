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
    public partial class buyVehicle : Form
    {
        public buyVehicle()
        {
            InitializeComponent();
        }
        //close button
        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
        }
        //compact selected, axle ratio is disabled
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Enabled = false;
            checkBox1.Enabled = true;
        }
        //pickup selected, hatchback is disabled 
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Enabled = false;
            textBox3.Enabled = true;
        }
        //when buy is clicked
        public void button2_Click(object sender, EventArgs e)
        {
            //validating field has input
            if ((!radioButton1.Checked && !radioButton2.Checked) || (radioButton2.Checked && textBox3.Text == string.Empty) || comboBox1.Text==string.Empty || textBox1.Text == string.Empty || textBox2.Text == string.Empty || textBox5.Text == string.Empty)
            {
                MessageBox.Show("Missing input!");
            }
            //Adds a new car from field input
            //clears fields
            else if (radioButton1.Checked)
            {
                Compact car = new Compact();
                car.make = comboBox1.Text;
                car.model = textBox1.Text;
                car.color = textBox2.Text;
                car.isHatchBack = checkBox1.Enabled;
                car.purchasePrice = Convert.ToInt32(textBox5.Text);
                car.hstPaid = float.Parse(textBox4.Text);
                Inventory.vehList.Add(car);
                MessageBox.Show("Vehicle added to inventory!");

                comboBox1.Text = "";
                textBox1.Text = "";
                textBox2.Text = "";
                checkBox1.Checked = false;
                textBox3.Text = "";
                textBox5.Text = "";
                textBox4.Text = "";
            }
            else
            {
                Pickup car = new Pickup();
                car.make = comboBox1.Text;
                car.model = textBox1.Text;
                car.color = textBox2.Text;
                car.axleRatio = float.Parse(textBox3.Text);
                car.purchasePrice = Convert.ToInt32(textBox5.Text);
                car.hstPaid = float.Parse(textBox4.Text);

                Inventory.vehList.Add(car);
                MessageBox.Show("Vehicle added to inventory!");

                comboBox1.Text = "";
                textBox1.Text = "";
                textBox2.Text = "";
                checkBox1.Checked = false;
                textBox3.Text = "";
                textBox5.Text = "";
                textBox4.Text = "";
            }
        }
        //HST Paid is updated after leaving Purchase Price box
        public void textBox5_Leave(object sender, EventArgs e)
        {
            double hstPaid;
                // tries to parse Purchase Price, returns t/f
                //if true, parses to HST Paid rounded to 2 decimal places
            if (double.TryParse(textBox5.Text, out hstPaid))
            {
                textBox5.Text = Math.Round(hstPaid, 2).ToString();
                textBox4.Text = Math.Round((hstPaid * 0.13),2).ToString();
            }
            //if false, errors and clears field
            else
            {
                MessageBox.Show("Please enter a number!");
                textBox5.Text = "";
            }
        }
        //leaving Axle Ratio
        public void textBox3_Leave(object sender, EventArgs e)
        {
            double axleRatio;
            //tries to parse Axle Ratio
            //if true, rounds Axle Ratio input to 1 decimal place
            if (double.TryParse(textBox3.Text, out axleRatio))
            {
                textBox3.Text = Math.Round(axleRatio, 1).ToString();
            }
            //if false, errors and clears field
            else
            {
                MessageBox.Show("Please enter a number!");
                textBox3.Text = "";
            }
        }
    }
}
