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
    public partial class AddCategoryForm : Form
    {
        ProdContext prodContext = new ProdContext();
        public AddCategoryForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
	
		private void label2_Click(object sender, EventArgs e) {

        }
		
		private void textBox1_TextChanged(object sender, EventArgs e){
			
		}
        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show(
                    "Wystąpił błąd. Błędnie wypełniony formularz. Nie dodano kategorii. ",
                    "Zamknij",
                    MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
            else
            {
                string name = textBox1.Text;
                string description = textBox2.Text;
                Category category = new Category()
                {
                    Name = name,
                    Description = description

                };
                prodContext.Categories.Add(category);
                prodContext.SaveChanges();
                MessageBox.Show(
                    "Dodano kategorię",
                    "Zamknij",
                    MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                this.Close();
                CategoryForm categoryForm = new CategoryForm();
                categoryForm.ShowDialog();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            CategoryForm categoryForm = new CategoryForm();
            categoryForm.ShowDialog();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AddCategoryForm_Load(object sender, EventArgs e)
        {

        }
    }
}
