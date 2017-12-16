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
    public partial class AddProductForm : Form
    {
        ProdContext prodContext = new ProdContext();
        public AddProductForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) ||
                String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show(
                    "Wystąpił błąd. Błędnie wypełniony formularz. Nie dodano produktu. ",
                    "Zamknij",
                    MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
            else {
                string name = textBox1.Text;
                int number = int.Parse(textBox2.Text);
                decimal price = decimal.Parse(textBox3.Text);
                int id_kategorii = int.Parse(textBox4.Text);
                Product product = new Product()
                {
                    Name = name,
                    UnitsInStock = number,
                    CategoryID = id_kategorii,
                    UnitPrice = price

                };

                prodContext.Products.Add(product);
                prodContext.SaveChanges();
                MessageBox.Show(
                    "Dodano produkt",
                    "Zamknij",
                    MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                this.Close();
                CategoryForm categoryForm = new CategoryForm();
                categoryForm.ShowDialog();
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
            OrderForm orderForm = new OrderForm();
            orderForm.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            CategoryForm categoryForm = new CategoryForm();
            categoryForm.ShowDialog();
        }
    }
}
