using Northwind.Business.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Northwind.Business.Concrete;
using Northwind.DataAccess.Concrete;
using Northwind.DataAccess.Concrete.NH;
using Northwind.Entity.Concrete;

namespace Northwind.GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            _productService = new ProductManager(new EfProductDal());
            _categoryService=new CategoryManager(new CategoryDal());
        }

        private IProductService _productService;
        private ICategoryService _categoryService;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _productService.Add(new Product
                {
                    ProductName = tbxName.Text,
                    UnitPrice = Convert.ToDecimal(tbxPrice.Text),
                    QuantityPerUnit = tbxQuantity.Text,
                    UnitsInStock = Convert.ToInt16(tbxStock.Text),
                    CategoryId = Convert.ToInt32(cbxCategory.SelectedValue)
                });
                MessageBox.Show("Ürün Eklendi");
                LoadProducts();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadCategories();
        }

        private void LoadCategories()
        {
            cbxCategory.DataSource=_categoryService.GetAll();
            cbxCategory.DisplayMember = "CategoryName";
            cbxCategory.ValueMember = "CategoryId";

            cbxCategoryUpdate.DataSource = _categoryService.GetAll();
            cbxCategoryUpdate.DisplayMember = "CategoryName";
            cbxCategoryUpdate.ValueMember = "CategoryId";

            cbxCategorySearch.DataSource = _categoryService.GetAll();
            cbxCategorySearch.DisplayMember = "CategoryName";
            cbxCategorySearch.ValueMember = "CategoryId";
        }

        private void LoadProducts()
        {
            dgwProducts.DataSource = _productService.GetAll();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _productService.Update(new Product
            {
                ProductId = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),
                ProductName = tbxNameUpdate.Text,
                UnitPrice = Convert.ToDecimal(tbxPriceUpdate.Text),
                QuantityPerUnit = tbxQuantityUpdate.Text,
                UnitsInStock = Convert.ToInt16(tbxStockUpdate.Text),
                CategoryId = Convert.ToInt32(cbxCategoryUpdate.SelectedValue)
            });
            LoadProducts();
        }

        private void dgwProducts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgwProducts.CurrentRow;
            tbxNameUpdate.Text = row.Cells[1].Value.ToString();
            cbxCategoryUpdate.SelectedValue = row.Cells[2].Value;
            tbxPriceUpdate.Text = row.Cells[3].Value.ToString();
            tbxQuantityUpdate.Text = row.Cells[4].Value.ToString();
            tbxStockUpdate.Text = row.Cells[5].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgwProducts.CurrentRow != null)
            {
                try
                {
                    _productService.Delete(new Product
                    {
                        ProductId = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value)
                    });
                    MessageBox.Show("Ürün silindi!");
                    LoadProducts();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }

            }
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            string key = tbxSearch.Text;
            
            if (!string.IsNullOrEmpty(key))
            {
                dgwProducts.DataSource=_productService.FindbyKey(key);
            }
            else
            {
                LoadProducts();
            }
        }

        private void cbxCategorySearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgwProducts.DataSource = _productService.FindbyCategory(Convert.ToInt32(cbxCategorySearch.SelectedValue));
            }
            catch
            {

            }
        }

      
    }
}
