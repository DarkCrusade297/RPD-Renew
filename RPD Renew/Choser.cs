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
            int count = 0;
            List<int> saverKafedr = new List<int>();
            List<string> saverDisciplines = new List<string>();
            List<int> saverPlans = new List<int>();
            //SqlDataAdapter adapter;
            string a = @"Data Source=DESKTOP-2KLBEO1\SQLEXPRESS;Initial Catalog=plany;Integrated Security=True";
            sql = new SqlConnection(a);
            await sql.OpenAsync();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT Код, Название FROM Кафедры WHERE Код IN(SELECT КодКафедры FROM ПланыСтроки)", sql);
            
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    TreeList.Nodes.Add(Convert.ToInt32(sqlReader["Код"]) + "   " + Convert.ToString(sqlReader["Название"]));
                    saverKafedr.Add(Convert.ToInt32(sqlReader["Код"]));
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
            for (int i=0;i<saverKafedr.Count;i++)
            {
                command = new SqlCommand("SELECT Дисциплина FROM ПланыСтроки WHERE КодКафедры=" + saverKafedr[i] + "ORDER BY Дисциплина", sql);
                try
                {
                    sqlReader = await command.ExecuteReaderAsync();
                    while (await sqlReader.ReadAsync())
                    {
                        TreeList.Nodes[i].Nodes.Add(sqlReader["Дисциплина"].ToString());
                        saverDisciplines.Add(sqlReader["Дисциплина"].ToString());
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
            for (int i = 0; i < saverKafedr.Count; i++)
            {
                    for (int p = 0; p < TreeList.Nodes[i].Nodes.Count; p++)
                    {
                        command = new SqlCommand("SELECT Планы.Код, ИмяФайла, Дисциплина, КодПлана  FROM Планы, ПланыСтроки WHERE ПланыСтроки.Дисциплина=" + "'" + saverDisciplines[count].ToString() + "'" + " AND Планы.Код=ПланыСтроки.КодПлана", sql);
                        try
                        {
                            sqlReader = await command.ExecuteReaderAsync();
                            while (await sqlReader.ReadAsync())
                            {
                                TreeList.Nodes[i].Nodes[p].Nodes.Add(sqlReader["Код"].ToString() + "  " + sqlReader["ИмяФайла"]);
                                saverPlans.Add(Convert.ToInt32(sqlReader["Код"]));
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
                    count++;
                    }
            }
        }
    }
}
