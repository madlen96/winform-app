using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp
{
    public partial class AddOrderForm : Form
    {
        ProdContext prodContext = new ProdContext();
        List<Product> allProducts = new List<Product>();
        List<Customer> allCustomers = new List<Customer>();
        
        public AddOrderForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Load += AddOrderForm_Load;

        }
        private void AddOrderForm_Load(object sender, EventArgs e)
        {
            var allP = from p in prodContext.Products
                       select p;
            foreach (var p in allP)
            {
                allProducts.Add(p);
            }
            comboBox1.DataSource = allProducts;
            comboBox1.DisplayMember = "Name";

            var allC = from c in prodContext.Customers
                       select c;
            foreach (var c in allC)
            {
                allCustomers.Add(c);
            }
            comboBox4.DataSource = allCustomers;
            comboBox4.DisplayMember = "CompanyName";

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void totalValueNumber_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
                
            int index1 = comboBox1.SelectedIndex;
            var product = allProducts[index1];
            decimal quantity = numericUpDown1.Value;
            int ind = comboBox4.SelectedIndex;
            var customer = allCustomers[ind];

            bool ok = true;
            bool ok1 = true;
            if (numericUpDown1.Value > product.UnitsInStock)
            {
                ok = false;                
            }
            else if (numericUpDown1.Value == 0)
            {
                ok1 = false;
            }

            if (ok && ok1)
            {

                Order order = new Order()
                {
                    CompanyName = customer.CompanyName,
                };

                prodContext.Orders.Add(order);
                prodContext.SaveChanges();

                int orderID = order.OrderID;
                allProducts[index1].UnitsInStock =
                    allProducts[index1].UnitsInStock - (int)quantity;
                OrderDetails orderDetails = new OrderDetails()
                {
                    OrderID = orderID,
                    ProductID = allProducts[comboBox1.SelectedIndex].ProductID,
                    Quantity = (int)quantity
                };
                prodContext.OrderDetails.Add(orderDetails);
                prodContext.SaveChanges();
                MessageBox.Show("Złożono zamówienie", "Zamknij",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                this.Hide();
                OrderForm orderForm = new OrderForm();
                orderForm.ShowDialog();
            }
            else
            {
                if (ok == false)
                {
                    MessageBox.Show("Brak podanej liczby sztuk w magazynie. Proszę wybrać mniejszą liczbę.", "Zamknij",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error);
                }
                if (ok1 == false)
                {
                    MessageBox.Show("Proszę wybrać liczbę sztuk większą od 0.", "Zamknij",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error);
                }
            }

            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            OrderForm orderForm = new OrderForm();
            orderForm.ShowDialog();

        }
    }
}
