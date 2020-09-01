using FishFactoryBusinessLogic.BindingModels;
using FishFactoryBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishFactoryClientView
{
    public partial class FormCreateOrder : Form
    {
        public FormCreateOrder()
        {
            InitializeComponent();
        }
        private void FormCreateOrder_Load(object sender, EventArgs e)
        {
            try
            {
                comboBoxCanned.DisplayMember = "EngineName";
                comboBoxCanned.ValueMember = "Id";
                comboBoxCanned.DataSource =
               APIClient.GetRequest<List<CannedViewModel>>("api/main/getenginelist");
                comboBoxCanned.SelectedItem = null;
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
                    CannedViewModel Engine =
APIClient.GetRequest<CannedViewModel>($"api/main/getengine?engineId={id}");
                    int count = Convert.ToInt32(textBoxCount.Text);
                    textBoxSum.Text = (count * Engine.Price).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }
        private void TextBoxCount_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }
        private void ComboBoxEngine_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSum();
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxCanned.SelectedValue == null)
            {
                MessageBox.Show("Выберите изделие", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                APIClient.PostRequest("api/main/createorder", new CreateOrderBindingModel
                {
                    ClientId = Program.Client.Id,
                    CannedId = Convert.ToInt32(comboBoxCanned.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text),
                    Sum = Convert.ToDecimal(textBoxSum.Text)
                });
                MessageBox.Show("Заказ создан", "Сообщение", MessageBoxButtons.OK,
               MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
    }
}