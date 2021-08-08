using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentACar
{
    public partial class FormOperation : Form
    {
        public bool OperBack { get; set; }
        public string RegPlate { get; set; }
        public int CarId { get; set; }

        int LastRekordId;
        public FormOperation()
        {
            InitializeComponent();
        }

        private void FormOperation_Load(object sender, EventArgs e)
        {
            if (OperBack)
            {
                Text = $"Zdaj auto - {RegPlate}";
                DataTable dt = GlobalData.ExecSQL($"SELECT * FROM cars");

                if (dt.Rows.Count >0)
                {
                    LastRekordId = Convert.ToInt32(dt.Rows[0]["id"]);
                }

            }
            else
            {
                Text = $"Wydaj auto = {RegPlate}";
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string sql;
            if (OperBack)
            {
                //aktua;ziacja rekordu 

                sql = @"UPDATE operations SET
                            ts_in = @ts,
                            mileage_in = @mileage, 
                            description = description + @desc
                        WHERE id = @id";

                MySqlCommand cmd = new MySqlCommand(sql, GlobalData.connection);

                cmd.Parameters.AddWithValue("@id", CarId);
                cmd.Parameters.AddWithValue("@ts", dtDate.Value);
                cmd.Parameters.AddWithValue("@mileage", numMileade.Value);
                cmd.Parameters.AddWithValue("@desc", tbDesc.Text);
                cmd.ExecuteNonQuery();

            }
            else
            {
                sql = @"INSERT INTO operations (car_id, ts_out, mileage_out, description)
                        VALUES (@car_id, @ts_out, @mileage, @desc)";

                MySqlCommand cmd = new MySqlCommand(sql, GlobalData.connection);
                cmd.Parameters.AddWithValue("@car_id", CarId);
                cmd.Parameters.AddWithValue("@ts_out", dtDate.Value);
                cmd.Parameters.AddWithValue("@mileage", numMileade.Value);
                cmd.Parameters.AddWithValue("@desc", tbDesc.Text);
                cmd.ExecuteNonQuery();

                sql = "UPDATE cars SET avail = @avail WHERE id = @car_id";
                cmd = new MySqlCommand(sql, GlobalData.connection);
                cmd.Parameters.AddWithValue("@car_id", CarId);
                cmd.Parameters.AddWithValue("@avail", OperBack ? 1 : 0);
                cmd.ExecuteNonQuery();

                DialogResult = DialogResult.OK;
                Close();

            }
        }
    }
}
