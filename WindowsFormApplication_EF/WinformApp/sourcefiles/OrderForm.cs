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
    public partial class OrderForm : Form
    {
        ProdContext prodContext = new ProdContext();
        //List<Product> allProducts = new List<Product>();
        public OrderForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Load += OrderForm_Load;
            orderDataGridView1.RowLeave += new DataGridViewCellEventHandler(orderDataGridView1_RowLeave);
            orderDataGridView1.RowEnter += new DataGridViewCellEventHandler(orderDataGridView1_RowEnter);

        }


        private void orderDataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

            var orderID = Convert.ToInt32(orderDataGridView1.Rows[e.RowIndex].Cells[0].Value);

            //bindOrdersQuerySyntax(orderID);
            bindOrdersMethodSyntax(orderID);

        }

        private void bindOrdersMethodSyntax(int value)
        {
            var actualOrders = prodContext.OrderDetails
                .Where(o => o.OrderID == value)
                .ToList();

            dataGridView1.DataSource = actualOrders;
        }

        private void bindOrdersQuerySyntax(int value)
        {
            var query = from o in prodContext.OrderDetails
                        join ord in prodContext.Orders on o.OrderID equals ord.OrderID
                        where ord.OrderID == value
                        select o;

            List<OrderDetails> actualOrders = query.ToList<OrderDetails>();

            dataGridView1.DataSource = actualOrders;
        }

        private void orderDataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < orderDataGridView1.Rows[e.RowIndex].Cells.Count; i++)
            {
                orderDataGridView1[i, e.RowIndex].Style.BackColor = Color.Empty;
            }
        }
        private void OrderForm_Load(object sender, EventArgs e)
        {

            var allOrders = from order in prodContext.Orders
                            select order;

            List<Order> orders = new List<Order>();
            foreach (var order in allOrders)
            {
                orders.Add(order);
            }
            orderDataGridView1.DataSource = orders;

            var allOrdersDetails = from o in prodContext.OrderDetails
                            select o;

            List<OrderDetails> oDetails = new List<OrderDetails>();
            foreach (var o in allOrdersDetails)
            {
                oDetails.Add(o);
            }
            dataGridView1.DataSource = oDetails;


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AddOrderForm orderForm = new AddOrderForm();
            Hide();
            orderForm.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            CategoryForm categoryForm = new CategoryForm();
            Hide();
            categoryForm.ShowDialog();
        }
    }
}
