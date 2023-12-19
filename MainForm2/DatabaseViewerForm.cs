using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MainForm2
{
    public partial class DatabaseViewerForm : Form
    {
        private DataGridView dataGridView1; // Добавьте это поле

        public DatabaseViewerForm(DataTable dataTable)
        {
            InitializeComponent();

            // DataGridView для отображения данных
            dataGridView1 = new DataGridView();
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.DataSource = dataTable;
            Controls.Add(dataGridView1);
            this.Text = "База данных";
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "datasource=localhost;port=3306;user=root;password=root;database=linear_equations";

                // Создаем подключение к базе данных
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Выполняем запрос к базе данных для получения данных
                    string query = "SELECT * FROM linear_equations_2";
                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            // Обновляем источник данных в DataGridView
                            dataGridView1.DataSource = dataTable;
                        }
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
