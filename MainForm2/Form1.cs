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
using Newtonsoft.Json;
using System.IO;

namespace MainForm2
{
    public partial class Form1 : Form
    {
        DataGridView dataGridViewCoefficients = new DataGridView();
        DataGridView dataGridViewConstants = new DataGridView();
        public Form1()
        {
            InitializeComponent();
            textBoxN.TextChanged += TextBoxN_TextChanged;
            solveButton.Click += SolveButton_Click;
            clearButton.Click += ClearButton_Click;

            // Настройка DataGridView для коэффициентов
            dataGridViewCoefficients.Location = new System.Drawing.Point(50, 100);
            dataGridViewCoefficients.Size = new System.Drawing.Size(200, 150);
            this.Controls.Add(dataGridViewCoefficients);

            // Настройка DataGridView для констант
            dataGridViewConstants.Location = new System.Drawing.Point(300, 100);
            dataGridViewConstants.Size = new System.Drawing.Size(100, 150);
            this.Controls.Add(dataGridViewConstants);

            textBoxN.TextChanged += TextBoxN_TextChanged;
            solveButton.Click += SolveButton_Click;
            clearButton.Click += ClearButton_Click;
        }

        private void CreateConstantsDataGridView(int n)
        {
            dataGridViewConstants.Rows.Clear();
            dataGridViewConstants.Columns.Clear();

            // Создаем колонки для ввода констант
            for (int i = 0; i < n; i++)
            {
                dataGridViewConstants.Columns.Add($"Constant_{i + 1}", $"Constant {i + 1}");
            }

            // Добавляем строки для ввода значений констант
            dataGridViewConstants.Rows.Add();
        }

        private void CreateCoefficientDataGridView(int n)
        {
            dataGridViewCoefficients.Rows.Clear();
            dataGridViewCoefficients.Columns.Clear();

            for (int i = 0; i < n; i++)
            {
                dataGridViewCoefficients.Columns.Add($"ColumnA{i + 1}", $"A{i + 1}");

                dataGridViewCoefficients.Rows.Add();
                dataGridViewCoefficients.Rows[i].HeaderCell.Value = $"Equation {i + 1}";
            }

            dataGridViewCoefficients.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
        }

        private void TextBoxN_TextChanged(object sender, EventArgs e)
        {
            const int maxEquations = 7;
            int n;
            if (int.TryParse(textBoxN.Text, out n))
            {
                if (n > maxEquations)
                {
                    MessageBox.Show($"Максимальное количество уравнений - {maxEquations}", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxN.Text = maxEquations.ToString();
                    n = maxEquations;
                }

                CreateCoefficientDataGridView(n);
                CreateConstantsDataGridView(n);
            }
        }

        //private void TextBoxN_TextChanged(object sender, EventArgs e)
        //{
        //    int n;
        //    if (int.TryParse(textBoxN.Text, out n))
        //    {
        //        // Удаление предыдущих TextBox'ов для коэффициентов, если они уже были добавлены
        //        foreach (Control control in Controls)
        //        {
        //            if (control is TextBox && (control.Name.StartsWith("textBoxA") || control.Name.StartsWith("textBoxB")))
        //            {
        //                Controls.Remove(control);
        //                control.Dispose();
        //            }
        //        }

        //        // Создание и размещение новых TextBox'ов для коэффициентов и правой части
        //        const int textBoxWidth = 40; // Ширина TextBox'ов
        //        const int textBoxHeight = 20; // Высота TextBox'ов

        //        for (int i = 0; i < n; i++)
        //        {
        //            for (int j = 0; j < n; j++)
        //            {
        //                TextBox textBoxA = new TextBox();
        //                textBoxA.Name = "textBoxA" + i + j;
        //                textBoxA.Location = new Point(50 + j * (textBoxWidth + 5), 50 + i * (textBoxHeight + 5));
        //                textBoxA.Size = new Size(textBoxWidth, textBoxHeight);
        //                this.Controls.Add(textBoxA);
        //            }

        //            TextBox textBoxB = new TextBox();
        //            textBoxB.Name = "textBoxB" + i;
        //            textBoxB.Location = new Point(50 + n * (textBoxWidth + 5), 50 + i * (textBoxHeight + 5));
        //            textBoxB.Size = new Size(textBoxWidth, textBoxHeight);
        //            this.Controls.Add(textBoxB);
        //        }
        //    }
        //}



        // Метод для сохранения данных в базу данных MySQL
        //private void SaveToDatabase(double[,] coefficients, double[] constants, double[] result)
        //{
        //    try
        //    {
        //        string connectionString = "datasource=localhost;port=3306;user=root;password=root;database=linear_equations";
        //        MySqlConnection conn = new MySqlConnection(connectionString);
        //        conn.Open();

        //        MySqlCommand command = new MySqlCommand();
        //        command.Connection = conn;

        //        // Подготовка SQL-запроса для создания динамического INSERT-запроса
        //        string insertQuery = "INSERT INTO linear_equations (upload_time";
        //        string values = " VALUES (NOW()";

        //        for (int i = 0; i < coefficients.GetLength(0); i++)
        //        {
        //            for (int j = 0; j < coefficients.GetLength(1); j++)
        //            {
        //                insertQuery += $", coefficient{i + 1}_{j + 1}";
        //                values += $", @coefficient{i + 1}_{j + 1}";
        //                command.Parameters.AddWithValue($"@coefficient{i + 1}_{j + 1}", coefficients[i, j]);
        //            }
        //        }

        //        for (int i = 0; i < constants.Length; i++)
        //        {
        //            insertQuery += $", constant{i + 1}";
        //            values += $", @constant{i + 1}";
        //            command.Parameters.AddWithValue($"@constant{i + 1}", constants[i]);
        //        }

        //        for (int i = 0; i < result.Length; i++)
        //        {
        //            insertQuery += $", result{i + 1}";
        //            values += $", @result{i + 1}";
        //            command.Parameters.AddWithValue($"@result{i + 1}", result[i]);
        //        }

        //        insertQuery += ")" + values + ")";

        //        command.CommandText = insertQuery;
        //        command.ExecuteNonQuery();

        //        conn.Close();

        //        MessageBox.Show("Данные сохранены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Ошибка при сохранении данных в базу данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private async Task SaveEquationDataAsync(double[,] coefficients, double[] constants, double[] result)
        {
            try
            {
                string connectionString = "datasource=localhost;port=3306;user=root;password=root;database=linear_equations";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    MySqlCommand command = new MySqlCommand();
                    command.Connection = conn;

                    // Преобразование коэффициентов, векторов и результата в текстовый формат
                    StringBuilder equationData = new StringBuilder();

                    equationData.AppendLine($"Данные пользователя: ");

                    // Сохранение коэффициентов
                    for (int i = 0; i < coefficients.GetLength(0); i++)
                    {
                        for (int j = 0; j < coefficients.GetLength(1); j++)
                        {
                            equationData.AppendLine($"A({i + 1}_{j + 1}) = {coefficients[i, j]}; ");
                        }
                    }

                    // Сохранение вектора констант (b)
                    for (int i = 0; i < constants.Length; i++)
                    {
                        equationData.AppendLine($"b({i + 1}) = {constants[i]}; ");
                    }

                    equationData.AppendLine($"Ответ: ");

                    // Сохранение результатов (x)
                    for (int i = 0; i < result.Length; i++)
                    {
                        equationData.AppendLine($"x({i + 1}) = {result[i]}; ");
                    }

                    // Получение текущего времени для сохранения в базу данных
                    DateTime currentTime = DateTime.Now;

                    // Подготовка SQL-запроса для вставки данных
                    string insertQuery = "INSERT INTO linear_equations_2 (equation_data, upload_time) VALUES (@data, @uploadTime)";
                    command.Parameters.AddWithValue("@data", equationData.ToString());
                    command.Parameters.AddWithValue("@uploadTime", currentTime);

                    command.CommandText = insertQuery;
                    await command.ExecuteNonQueryAsync();

                    conn.Close();

                    MessageBox.Show("Данные сохранены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных в базу данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void LoadEquationDataFromDatabase(int equationId)
        //{
        //    try
        //    {
        //        string connectionString = "datasource=localhost;port=3306;user=root;password=root;database=linear_equations";
        //        MySqlConnection conn = new MySqlConnection(connectionString);
        //        conn.Open();

        //        MySqlCommand command = new MySqlCommand();
        //        command.Connection = conn;

        //        command.CommandText = "SELECT equation_data FROM equations1 WHERE id = @id";
        //        command.Parameters.AddWithValue("@id", equationId);

        //        string equationData = command.ExecuteScalar()?.ToString();

        //        if (!string.IsNullOrEmpty(equationData))
        //        {
        //            dynamic data = JsonConvert.DeserializeObject(equationData);

        //            double[,] coefficients = data?.Coefficients.ToObject<double[,]>();
        //            double[] constants = data?.Constants.ToObject<double[]>();
        //            double[] result = data?.Result.ToObject<double[]>();

        //            // Используйте коэффициенты, константы и результаты для дальнейших вычислений или отображения
        //        }

        //        conn.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Ошибка при загрузке данных из базы данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void SolveButton_Click(object sender, EventArgs e)
        {

            // Проверяем, что пользователь ввел данные во все поля коэффициентов
            if (!AllCoefficientsEntered())
            {
                MessageBox.Show("Введите больше данных");
                return;
            }

            // Получение коэффициентов и правой части из TextBox'ов
            double[,] coefficients = GetCoefficients();
            double[] constants = GetConstants();

            // Установка точности и максимального количества итераций
            double epsilon = 0.001;
            int maxIterations = 100000;

            // Решение системы уравнений методом последовательных итераций
            double[] result = SolveIterativeMethod(coefficients, constants, epsilon, maxIterations);

            // Вывод результатов
            DisplayResults(result);
        }

        private void showDatabaseButton_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "datasource=localhost;port=3306;user=root;password=root;database=linear_equations";
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();

                MySqlCommand command = new MySqlCommand();
                command.Connection = conn;

                command.CommandText = "SELECT * FROM linear_equations_2";

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                DatabaseViewerForm dataForm = new DatabaseViewerForm(dataTable);
                dataForm.Show();

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных из базы данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveToFileButton_Click(object sender, EventArgs e)
        {
            // Получение коэффициентов и констант
            double[,] coefficients = GetCoefficients();
            double[] constants = GetConstants();

            // Задание значений epsilon и maxIterations (возможно, у вас есть другие значения)
            double epsilon = 0.001;
            int maxIterations = 100000;

            // Получение решения из вашего метода решения уравнений
            double[] result = SolveIterativeMethod(coefficients, constants, epsilon, maxIterations);

            // Сбор данных для сохранения в файл
            StringBuilder dataToSave = new StringBuilder();

            dataToSave.AppendLine("Коэффициенты:");
            // Собираем коэффициенты
            for (int i = 0; i < coefficients.GetLength(0); i++)
            {
                for (int j = 0; j < coefficients.GetLength(1); j++)
                {
                    dataToSave.AppendLine($"A({i + 1}_{j + 1}) = {coefficients[i, j]}; ");
                }
            }

            dataToSave.AppendLine("\nКонстанты:");
            // Собираем константы
            for (int i = 0; i < constants.Length; i++)
            {
                dataToSave.AppendLine($"b({i + 1}) = {constants[i]}; ");
            }

            dataToSave.AppendLine("\nРешение:");
            // Собираем результаты
            for (int i = 0; i < result.Length; i++)
            {
                dataToSave.AppendLine($"x({i + 1}) = {result[i]}; ");
            }

            // Добавление даты и времени записи данных
            string currentDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            dataToSave.Insert(0, $"Дата и время записи: {currentDate}\n\n");

            // Запись данных в файл
            string filePath = @"C:\\Users\\k_mal\\OneDrive\\Рабочий стол\\курс.txt"; // Укажите свой путь к файлу

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, append: true))
                {
                    writer.WriteLine(dataToSave.ToString());
                    writer.WriteLine(new string('-', 50)); // Добавление разделителя
                }

                MessageBox.Show("Данные успешно добавлены в файл.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении данных в файл: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void saveToDatabaseButton_Click(object sender, EventArgs e)
        {
            if (!AllCoefficientsEntered())
            {
                MessageBox.Show("Введите больше данных");
                return;
            }

            double[,] coefficients = GetCoefficients();
            double[] constants = GetConstants();
            double epsilon = 0.001;
            int maxIterations = 100000;
            double[] result = SolveIterativeMethod(coefficients, constants, epsilon, maxIterations);

            // Проверяем, что результаты получены успешно
            if (result != null)
            {

                // Сохраняем данные в базу данных
                //SaveToDatabase(coefficients, constants, result);
                //SaveEquationDataToDatabase(coefficients, constants, result);

                // Сохраняем данные в базу данных асинхронно
                await SaveEquationDataAsync(coefficients, constants, result);
                MessageBox.Show("Данные сохранены в базе данных", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Не удалось решить уравнения или получить результаты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool AllCoefficientsEntered()
        {
            // Проверка, что все поля для коэффициентов заполнены
            foreach (Control control in Controls)
            {
                if (control is TextBox textBox && (textBox.Name.StartsWith("textBoxA") || textBox.Name.StartsWith("textBoxB")))
                {
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        //private void CreateCoefficientTextBoxes()
        //{
        //    int n;
        //    if (int.TryParse(textBoxN.Text, out n))
        //    {
        //        // Удаление предыдущих TextBox'ов для коэффициентов и правой части, если они уже были добавлены
        //        foreach (Control control in Controls)
        //        {
        //            if (control is TextBox && (control.Name.StartsWith("textBoxA") || control.Name.StartsWith("textBoxB")))
        //            {
        //                Controls.Remove(control);
        //                control.Dispose();
        //            }
        //        }

        //        // Создание и размещение новых TextBox'ов для коэффициентов и правой части
        //        const int textBoxWidth = 40; // Ширина TextBox'ов
        //        const int textBoxHeight = 20; // Высота TextBox'ов
        //        const int xOffset = 50; // Начальное смещение по оси X
        //        const int yOffset = 30; // Смещение по оси Y
        //        const int spaceBetween = 20; // Расстояние между полями и знаками "+"

        //        for (int i = 0; i < n; i++)
        //        {
        //            for (int j = 0; j < n; j++)
        //            {
        //                TextBox textBoxA = new TextBox();
        //                textBoxA.Name = "textBoxA" + i + j;
        //                textBoxA.Location = new Point(xOffset + j * (textBoxWidth + 5) + j * spaceBetween, 100 + i * (textBoxHeight + 5) + yOffset);
        //                textBoxA.Size = new Size(textBoxWidth, textBoxHeight);
        //                this.Controls.Add(textBoxA);

        //                if (j < n - 1) // Добавляем "+" между коэффициентами A, кроме последнего
        //                {
        //                    Label labelPlus = new Label();
        //                    labelPlus.Text = "+";
        //                    labelPlus.AutoSize = true;
        //                    labelPlus.Location = new Point(xOffset + (int)((j + 1) * textBoxWidth + (j + 0.6) * spaceBetween), 100 + i * (textBoxHeight + 5) + yOffset);
        //                    this.Controls.Add(labelPlus);
        //                }
        //            }

        //            Label labelEquals = new Label();
        //            labelEquals.Text = "=";
        //            labelEquals.AutoSize = true;
        //            labelEquals.Location = new Point(xOffset + n * (textBoxWidth + 5) + n * spaceBetween, 100 + i * (textBoxHeight + 5) + yOffset);
        //            this.Controls.Add(labelEquals);

        //            TextBox textBoxB = new TextBox();
        //            textBoxB.Name = "textBoxB" + i;
        //            textBoxB.Location = new Point(xOffset + (n + 1) * (textBoxWidth + spaceBetween), 100 + i * (textBoxHeight + 5) + yOffset);
        //            textBoxB.Size = new Size(textBoxWidth, textBoxHeight);
        //            this.Controls.Add(textBoxB);
        //        }
        //    }
        //}

        private double[,] GetCoefficients()
        {
            int n = int.Parse(textBoxN.Text);

            double[,] coefficients = new double[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (!double.TryParse(dataGridViewCoefficients.Rows[i].Cells[j].Value?.ToString(), out coefficients[i, j]))
                    {
                        MessageBox.Show($"Некорректное значение коэффициента A{i + 1}{j + 1}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
                }
            }

            return coefficients;
        }

        private double[] GetConstants()
        {
            int n = int.Parse(textBoxN.Text);

            double[] constants = new double[n];

            for (int i = 0; i < n; i++)
            {
                if (!double.TryParse(dataGridViewConstants.Rows[i].Cells[0].Value?.ToString(), out constants[i]))
                {
                    MessageBox.Show($"Некорректное значение правой части B{i + 1}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }

            return constants;
        }

        private double[] SolveIterativeMethod(double[,] coefficients, double[] constants, double epsilon, int maxIterations)
        {
            int n = constants.Length;
            double[] result = new double[n];
            double[] previousResult = new double[n];

            for (int i = 0; i < n; i++)
            {
                result[i] = 0; // Начальное приближение
            }

            int iterations = 0;
            while (iterations < maxIterations)
            {
                Array.Copy(result, previousResult, n);

                for (int i = 0; i < n; i++)
                {
                    double sum = 0;
                    for (int j = 0; j < n; j++)
                    {
                        if (j != i)
                        {
                            sum += coefficients[i, j] * result[j];
                        }
                    }
                    result[i] = (constants[i] - sum) / coefficients[i, i];
                }

                double error = CalculateError(result, previousResult);
                if (error < epsilon)
                {
                    break;
                }

                iterations++;
            }

            if (iterations == maxIterations)
            {
                MessageBox.Show("Решение не достигнуто с заданной точностью за максимальное количество итераций.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return result;
        }

        private double CalculateError(double[] current, double[] previous)
        {
            // Расчет ошибки по норме разности текущего и предыдущего приближений
            double sum = 0;
            for (int i = 0; i < current.Length; i++)
            {
                sum += Math.Pow(current[i] - previous[i], 2);
            }
            return Math.Sqrt(sum);
        }

        private void DisplayResults(double[] result)
        {
            // Получаем количество уравнений (n) из текстового поля или другого источника данных
            int n = int.Parse(textBoxN.Text); // Предположим, что textBoxN содержит количество уравнений

            // Очищаем текстовое поле для вывода результатов
            textBoxResults.Clear();

            // Выводим результаты в столбик в текстовое поле
            for (int i = 0; i < n; i++)
            {
                textBoxResults.AppendText($"x{i + 1} = {result[i]}\r\n"); // Добавляем результат в новой строке
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            int n;
            if (int.TryParse(textBoxN.Text, out n))
            {
                for (int i = Controls.Count - 1; i >= 0; i--)
                {
                    Control control = Controls[i];
                    if (control is TextBox textBox && (textBox.Name.StartsWith("textBoxA") || textBox.Name.StartsWith("textBoxB")))
                    {
                        Controls.Remove(control);
                        control.Dispose();
                    }
                    else if (control is Label label && (label.Text == "+" || label.Text == "="))
                    {
                        Controls.Remove(label);
                        label.Dispose();
                    }
                }
                // Очищаем текстовое поле с результатами
                textBoxResults.Clear();
            }
        }
    }
}

