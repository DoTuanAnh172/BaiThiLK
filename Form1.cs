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

namespace BaiThiLK
{
    public partial class Form1 : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=MSI;Initial Catalog=C#;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();


        void loaddata()
        {
            using (connection = new SqlConnection(str))
            {
                connection.Open();

                // Lấy dữ liệu cho table1 và hiển thị trong dataGridView1
                command = new SqlCommand("SELECT * FROM SINH_VIEN", connection);
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                dataGridView1.DataSource = table;



                connection.Close();
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentCell.RowIndex;
            MSSV.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            Ten_sinh_vien.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            Ma_lop.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            Ten_lop.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            loaddata();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (connection = new SqlConnection(str))
                {
                    connection.Open();
                    command = connection.CreateCommand();
                    command.CommandText = "INSERT INTO SINH_VIEN (MSSV,Ten_sinh_vien,Ma_lop,Ten_lop) " +
                "VALUES (@MSSV,@Ten_sinh_vien,@Ma_lop,@Ten_lop);";
                    command.Parameters.AddWithValue("@MSSV", MSSV.Text);
                    command.Parameters.AddWithValue("@Ten_sinh_vien", Ten_sinh_vien.Text);
                    command.Parameters.AddWithValue("@Ma_lop", Ma_lop.Text);
                    command.Parameters.AddWithValue("@Ten_lop", Ten_lop.Text);
                    command.ExecuteNonQuery();
                    loaddata();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (connection = new SqlConnection(str))
                {
                    connection.Open();
                    command = connection.CreateCommand();
                    command.CommandText = "DELETE FROM SINH_VIEN WHERE MSSV=@MSSV";
                    command.Parameters.AddWithValue("@MSSV", MSSV.Text);
                    command.ExecuteNonQuery();
                    loaddata();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi:" + "không thể xóa thông tin sinh viên", "lỗi", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(str))
                {
                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "UPDATE SINH_VIEN SET " +
                            " Ten_sinh_vien=@Ten_sinh_vien,Ma_lop=@Ma_lop,Ten_lop=@Ten_lop WHERE MSSV=@MSSV";
                        command.Parameters.AddWithValue("@Ten_sinh_vien", Ten_sinh_vien.Text);
                        command.Parameters.AddWithValue("@Ma_lop", Ma_lop.Text);
                        command.Parameters.AddWithValue("@Ten_lop", Ten_lop.Text);
                        command.Parameters.AddWithValue("@MSSV", MSSV.Text);
                        command.ExecuteNonQuery();
                    }
                    loaddata();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: Không thể khởi tạo thông tin sinh viên\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Ma_lop_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
