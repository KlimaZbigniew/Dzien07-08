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
    public partial class FormCarList : Form
    {
        public FormCarList()
        {
            InitializeComponent();
        }

		BindingSource bSource = new BindingSource();

		private void RefreshData()
        {
			string sql = @"SELECT 
								TC.id,
								TB.name AS brand, 
								TM.name AS model,	
								TCT.name AS car_type,
								TC.registration_plate, 
								TC.engine, 
								TC.manufacturer_year, 
								TC.avail, 
								TC.fuel
							FROM cars TC
								INNER JOIN car_types TCT ON TCT.id = TC.type_id
								INNER JOIN car_models TM ON TM.id = TC.model_id
								INNER JOIN car_brands TB ON TB.id = TM.brand_id
							ORDER BY TC.id";
			MySqlDataAdapter adapter = new MySqlDataAdapter();
			adapter.SelectCommand = new MySqlCommand(sql, GlobalData.connection);

			DataTable dt = new DataTable();
			adapter.Fill(dt); //dump danych odczytanych z bazy do oboiektu data teble.

			bSource.DataSource = dt;
			grid.DataSource = bSource;

		}

		private void FormCarList_Load(object sender, EventArgs e)
        {
			RefreshData();
			//dostosowanie nagłówków grida
			grid.Columns["id"].HeaderText = "ID";
			grid.Columns["brand"].HeaderText = "Marka";
			grid.Columns["model"].HeaderText = "Model";
			grid.Columns["car_type"].HeaderText = "Własność";
			grid.Columns["registration_plate"].HeaderText = "Nr rej.";

			grid.Columns["engine"].HeaderText = "Pojemność [cm3]";
			grid.Columns["engine"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

			grid.Columns["manufacturer_year"].HeaderText = "Rok produkcji";
			grid.Columns["manufacturer_year"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

			grid.Columns["avail"].HeaderText = "Dostępność";
			grid.Columns["fuel"].HeaderText = "Paliwo";


		}

        private void grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
			if (e.ColumnIndex == grid.Columns["avail"].Index)
            {

				e.Value = Convert.ToInt32(e.Value) == 1 ? "TAK" : "NIE";
            }
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
			RefreshData();
        }
    }
}
