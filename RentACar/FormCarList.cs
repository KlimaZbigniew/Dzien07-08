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

		private DataTable GetDataFromDB()
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
			return dt;
		}

		private void RefreshData()
        {

			//bSource.DataSource = dt;
			//grid.DataSource = bSource;

		}

		private void FormCarList_Load(object sender, EventArgs e)
        {
			
			DataTable dt = GetDataFromDB();
			bSource.DataSource = dt;


			DataGridViewCheckBoxColumn dgvCmb = new DataGridViewCheckBoxColumn(); //koilumna z checkboxem.
			dgvCmb.ValueType = typeof(bool);
			dgvCmb.Name = "avail-cb";
			dgvCmb.HeaderText = "Dostępność";
			grid.Columns.Add(dgvCmb);

			grid.DataSource = bSource;
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

			grid.Columns["avail-cb"].DisplayIndex = grid.Columns["avail"].DisplayIndex -1;
		}

        private void grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
			if (e.ColumnIndex == grid.Columns["avail"].Index)
            {

				e.Value = Convert.ToInt32(e.Value) == 1 ? "TAK" : "NIE";
            }

			//Wypełnienie checkboxa w zależnosci od wartosci avil
			grid.Rows[e.RowIndex].Cells["avail-cb"].Value =
			Convert.ToInt32(grid.Rows[e.RowIndex].Cells["avail"].Value) == 1 ? true : false;
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
			RefreshData();
        }

        private void tsbInsert_Click(object sender, EventArgs e)
        {
			FormAddCar form = new FormAddCar();
			form.ShowDialog();
        }
    }
}
