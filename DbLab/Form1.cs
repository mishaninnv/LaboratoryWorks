using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace DbLab
{
    public partial class Form1 : Form
    {
        string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=|DataDirectory|\Постояльцы.mdb";
        private OleDbConnection connection;

        public Form1()
        {
            InitializeComponent();

            connection = new OleDbConnection(connectionString);
            connection.Open();

            var query = "SELECT * FROM Данные";
            OleDbCommand cmd = new OleDbCommand(query, connection);

            OleDbDataReader reader = cmd.ExecuteReader();

            var buffer = new List<string>();
            while (reader.Read())
            {
                for (var i = 0; i < reader.FieldCount; i++)
                {
                    buffer.Add(reader[i].ToString());
                }
                dataGridView1.Rows.Add(buffer.ToArray());
                buffer.Clear();
            }

            query = "SELECT Фамилия, Плата_за_услуги FROM Данные Where Плата_за_услуги = 0";
            cmd = new OleDbCommand(query, connection);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                dataGridView2.Rows.Add(new string[] { reader[0].ToString(), reader[1].ToString() });
            }


            query = "SELECT Фамилия, Дата_заезда FROM Данные";
            cmd = new OleDbCommand(query, connection);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var currDate = Convert.ToDateTime(reader[1]);
                if (currDate.Month == 03)
                {
                    dataGridView3.Rows.Add(new string[] { reader[0].ToString(), reader[1].ToString() });
                }
            }


            query = "SELECT Фамилия, Город FROM Данные Where Город = 'Москва'";
            cmd = new OleDbCommand(query, connection);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                dataGridView4.Rows.Add(new string[] { reader[0].ToString(), reader[1].ToString() });
            }


            query = "SELECT Фамилия, Город FROM Данные Where Город = 'Москва'";
            cmd = new OleDbCommand(query, connection);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                dataGridView4.Rows.Add(new string[] { reader[0].ToString(), reader[1].ToString() });
            }


            query = "SELECT Фамилия, Пол, Город FROM Данные Where Пол = 'муж'";
            cmd = new OleDbCommand(query, connection);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader[2].Equals("Тюмень"))
                {
                    dataGridView5.Rows.Add(new string[] { reader[0].ToString(), reader[1].ToString(), reader[2].ToString() });
                }
            }


            query = "SELECT * FROM Данные";
            cmd = new OleDbCommand(query, connection);
            reader = cmd.ExecuteReader();
            var allPrice = 0;
            while (reader.Read())
            {
                var priceOne = Convert.ToInt32(reader[6]);
                var priceTwo = Convert.ToInt32(reader[7]);
                var sum = priceOne + priceTwo;

                allPrice += sum;

                dataGridView6.Rows.Add(new string[] { reader[0].ToString(), sum.ToString() });
            }
            label2.Text = $"Суммарная стоимость оказанных услуг: {allPrice}";


            query = "SELECT Номер FROM Данные WHERE Номер = 505";
            cmd = new OleDbCommand(query, connection);
            reader = cmd.ExecuteReader();
            var counter = 0;
            while (reader.Read())
            {
                counter++;
            }
            label1.Text = $"Количество клиентов, проживавших в 505 номере: {counter}";



            reader.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
        }
    }
}
