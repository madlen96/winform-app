using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.Entity;

namespace ConsoleApp
{
    public partial class CategoryForm : Form
    {
        ProdContext _context;
        public CategoryForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            categoryDataGridView.RowLeave += new DataGridViewCellEventHandler(categoryDataGridView_RowLeave);
            categoryDataGridView.RowEnter += new DataGridViewCellEventHandler(categoryDataGridView_RowEnter);

        }



        private void categoryDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

            var categoryIDValue = Convert.ToInt32(categoryDataGridView.Rows[e.RowIndex].Cells[0].Value);

            //bindProductsQuerySyntax(categoryIDValue);
            bindProductsMethodSyntax(categoryIDValue);

        }

        private void bindProductsMethodSyntax(int value)
        {
            var actualProducts = _context.Products
                .Where(product => product.CategoryID == value)
                .ToList();

            dataGridView1.DataSource = actualProducts;
        }

        private void bindProductsQuerySyntax(int value)
        {
            var query = from p in _context.Products
                        join c in _context.Categories on p.CategoryID equals c.CategoryID
                        where c.CategoryID == value
                        select p;

            List<Product> actualProducts = query.ToList<Product>();

            dataGridView1.DataSource = actualProducts;
        }

        private void categoryDataGridView_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < categoryDataGridView.Rows[e.RowIndex].Cells.Count; i++)
            {
                categoryDataGridView[i, e.RowIndex].Style.BackColor = Color.Empty;
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _context = new ProdContext();
            _context.Categories.Load();
            _context.Products.Load();
            this.categoryBindingSource.DataSource =
                _context.Categories.Local.ToBindingList();
            this.productsBindingSource.DataSource =
               _context.Products.Local.ToBindingList();
        }

        private void categoryBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this._context.SaveChanges();
            this.categoryDataGridView.Refresh();
            this.productsDataGridView.Refresh();
        }

        private void categoryDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            this._context.Dispose();
        }

        private void categoryDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void productsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {

        }


        private void button4_Click_1(object sender, EventArgs e)
        {
            OrderForm orderForm = new OrderForm();
            Hide();
            orderForm.ShowDialog();

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }



        private void addBtn_Click_1(object sender, EventArgs e)
        {
            AddCategoryForm catForm = new AddCategoryForm();
            Hide();
            catForm.ShowDialog();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            AddProductForm prodForm = new AddProductForm();
            Hide();
            prodForm.ShowDialog();
        }
    }
}
