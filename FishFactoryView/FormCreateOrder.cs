using FishFactoryBusinessLogic.BusinessLogics;
using FishFactoryBusinessLogic.Interfaces;
using FishFactoryBusinessLogic.BindingModels;
using FishFactoryBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace FishFactoryView
{
    public partial class FormCreateOrder : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly ICannedLogic logicC;
        private readonly IClientLogic logicCl;
        private readonly MainLogic logicM;
        public FormCreateOrder(ICannedLogic logicC, IClientLogic logicCl, MainLogic logicM)
        {
            InitializeComponent();
            this.logicC = logicC;
            this.logicCl = logicCl;
            this.logicM = logicM;
        }

        private void FormCreateOrder_Load(object sender, EventArgs e)
        {
            try
            {
                var list = logicC.Read(null);
                comboBoxCanned.DataSource = list;
                comboBoxCanned.DisplayMember = "CannedName";
                comboBoxCanned.ValueMember = "Id";
                var listCl = logicCl.Read(null);
                comboBoxClient.DisplayMember = "ClientFIO";
                comboBoxClient.ValueMember = "Id";
                comboBoxClient.DataSource = listCl;
                comboBoxClient.SelectedItem = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        private void CalcSum()
        {
            if (comboBoxCanned.SelectedValue != null &&
           !string.IsNullOrEmpty(textBoxCount.Text))
            {
                try
                {
                    int id = Convert.ToInt32(comboBoxCanned.SelectedValue);
                    CannedViewModel product = logicC.Read(new CannedBindingModel
                    {
                        Id =  id
                    })?[0];
                    int count = Convert.ToInt32(textBoxCount.Text);
                    textBoxTotal.Text = (count * product?.Price ?? 0).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }

        private void textBoxCount_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void textBoxTotal_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxCanned.SelectedValue == null)
            {
                MessageBox.Show("Выберите консервы", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                logicM.CreateOrder(new CreateOrderBindingModel
                {
                    CannedId = Convert.ToInt32(comboBoxCanned.SelectedValue),
                    ClientId = Convert.ToInt32(comboBoxClient.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text),
                    Sum = Convert.ToDecimal(textBoxTotal.Text)
                }) ;
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
