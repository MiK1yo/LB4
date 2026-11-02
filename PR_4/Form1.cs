using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.Entity;

namespace PR_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ModelEF model = new ModelEF();
        private void StartLoadData()
        {
            model.Users.Load();
            role_NameComboBox.DataSource = model.Roles.ToList();
            usersBindingSource.DataSource = model.Users.Local.ToBindingList();
        }
        private void SaveDate()
        {
            try
            {

                Validate();
                usersBindingSource.EndEdit();
                usersBindingSource.ResetBindings(true);
                model.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                StartLoadData();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartLoadData();
        }
        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            SaveDate();
        }
        private void usersBindingNavigatorSaveItems(object sender, EventArgs e)
        {
            SaveDate();
        }
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            role_NameComboBox.SelectedIndex = 0;
        }
    }
}
