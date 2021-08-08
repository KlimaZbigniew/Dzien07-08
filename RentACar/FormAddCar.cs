using MySql.Data.MySqlClient;
using RentACar.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentACar
{
    public partial class FormAddCar : Form
    {
        public FormAddCar()
        {
            InitializeComponent();
        }

        BindingSource bsBrands = new BindingSource();
        BindingSource bsModels = new BindingSource();
        BindingSource bsTypes = new BindingSource();
        private void LoadDictionaries()
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            string sql = "SELECT * FROM car_brands";

            adapter.SelectCommand = new MySqlCommand(sql, GlobalData.connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            bsBrands.DataSource = dt;
            cbBrands.DataSource = bsBrands;
            cbBrands.DisplayMember = "name";
            cbBrands.ValueMember = "id";

            cbBrands.SelectedIndex = -1;
            cbBrands.SelectedIndexChanged += CbBrands_SelectedIndexChanged;


            //models
            adapter = new MySqlDataAdapter();
            sql = "SELECT * FROM car_models";

            adapter.SelectCommand = new MySqlCommand(sql, GlobalData.connection);
            dt = new DataTable();
            adapter.Fill(dt);

            bsModels.DataSource = dt;
            cbModels.DataSource = bsModels;
            cbModels.DisplayMember = "name";
            cbModels.ValueMember = "id";

            cbModels.SelectedIndex = -1;
            cbModels.Enabled = false;


            //types
            adapter = new MySqlDataAdapter();
            sql = "SELECT * FROM car_types";

            adapter.SelectCommand = new MySqlCommand(sql, GlobalData.connection);
            dt = new DataTable();
            adapter.Fill(dt);

            bsTypes.DataSource = dt;
            cbTypes.DataSource = bsTypes;
            cbTypes.DisplayMember = "name";
            cbTypes.ValueMember = "id";

            cbTypes.SelectedIndex = -1;


        }

        private void CbBrands_SelectedIndexChanged(object sender, EventArgs e)
        {
         if (cbBrands.SelectedIndex >- 1)
            {
                bsModels.Filter = $"brand_id = {cbBrands.SelectedValue}";
                cbModels.DataSource = bsModels;
                if (bsModels.Count > 0 )
                {
                    cbModels.Enabled = true;
                    cbModels.SelectedIndex = -1;
                }
            }
        }

        private void FormAddCar_Load(object sender, EventArgs e)
        {
            LoadDictionaries();
            numYear.Value = DateTime.Now.Year;
            numYear.Maximum = DateTime.Now.Year;
        }

        private string pictureFileName = null;
        private void btnLoadPic_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                picCar.Image = new Bitmap(dialog.FileName);
                pictureFileName = dialog.FileName;
            }
        }

        private void btnDelPic_Click(object sender, EventArgs e)
        {
            if (picCar.Image != null)
            {
                picCar.Image.Dispose();
                picCar.Image = null;
                pictureFileName = null;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!ValidateData())
            {
                DialogHelper.E("Podaj wszystkie paramerty!!!");
                return;
            }

            try
            {
                SaveData();
            }
            catch (Exception ex)
            {

                DialogHelper.E(ex.Message);
            }
            
            
            
        }

        private void SaveData()
        {
            string sql = @"INSERT INTO cars (model_id, type_id, registration_plate, `ENGINE`, manufacturer_year, image,fuel)
                           VALUES (@model_id, @type_id, @reg_plate, @engine, @year, @image, @fuel)";

            //Deklaracja parametyrów do zapytania
            MySqlCommand cmd = new MySqlCommand(sql, GlobalData.connection);
            cmd.Parameters.Add("@model_id", MySqlDbType.Int32);
            cmd.Parameters.Add("@type_id", MySqlDbType.Int32);
            cmd.Parameters.Add("@reg_plate", MySqlDbType.VarChar, 8);
            cmd.Parameters.Add("@engine", MySqlDbType.Int32);
            cmd.Parameters.Add("@year", MySqlDbType.Int32);
            cmd.Parameters.Add("@fuel", MySqlDbType.VarChar, 3);
            cmd.Parameters.Add("@image", MySqlDbType.LongBlob);


            //Załadowanie wartosći do kontrolek parametrów SQL
            cmd.Parameters["@model_id"].Value = cbModels.SelectedValue;
            cmd.Parameters["@type_id"].Value = cbTypes.SelectedValue;
            cmd.Parameters["@reg_plate"].Value = tbRegPlate.Text;
            cmd.Parameters["@engine"].Value = numEngine.Value;
            cmd.Parameters["@year"].Value = numYear.Value;
            cmd.Parameters["@fuel"].Value = cbFuel.SelectedItem;
            if (pictureFileName != null)
                cmd.Parameters["@image"].Value = File.ReadAllBytes(pictureFileName);
            else
                cmd.Parameters["@image"].Value = null;

            cmd.ExecuteNonQuery();
            DialogResult = DialogResult.OK;
            Close();
            
            
        }

        private bool ValidateData()
        {
            if (cbBrands.SelectedIndex >-1
                && cbTypes.SelectedIndex >-1
                && cbFuel.SelectedIndex > -1
                && !string.IsNullOrWhiteSpace(tbRegPlate.Text))
            return true;

            return false;
        }
    }
}
