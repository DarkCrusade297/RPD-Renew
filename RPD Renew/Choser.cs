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

namespace RPD_Renew
{
    public partial class Choser : Form
    {
        SqlConnection sql;
        public Choser()
        {
            InitializeComponent();
        }

        private async void Choser_Load(object sender, EventArgs e)
        {
            string a = @"Data Source=DESKTOP-2KLBEO1\SQLEXPRESS;Initial Catalog=plany;Integrated Security=True";
            sql = new SqlConnection(a);
            await sql.OpenAsync();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT* from Кафедры Where Код IN(SELECT КодКафедры FROM ПланыСтроки)", sql);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    TreeList.Nodes.Add(Convert.ToString(sqlReader["Код"])+"   "+ Convert.ToString(sqlReader["Название"]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }
    }
}
