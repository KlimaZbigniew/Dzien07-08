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
        public int RowId { get; set; } //Id wiersza do edycji

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

            //JEśli rowId to jesteśmy w edycji rlordu
            if (RowId > 0)
            {                
                MySqlDataReader data = GetRekord(RowId);
                
                if (data!=null &&  data.HasRows)
                {
                    data.Read();  //inicjalne pobranie rekordu z danymi 
                    numEngine.Value = Convert.ToInt32(data["engine"]);
                    numYear.Value = Convert.ToInt32(data["manufacturer_year"]);
                    tbRegPlate.Text = data["registration_plate"].ToString();

                    cbBrands.SelectedValue = data["brand_id"];
                    cbModels.SelectedValue = data["model_id"];
                    cbTypes.SelectedValue = data["type_id"];

                    cbFuel.SelectedIndex = cbFuel.Items.IndexOf(data["fuel"]);

                    if (!(data["image"] is DBNull))
                    {
                        byte[] b = (byte[])data["image"];
                        using (MemoryStream ms = new MemoryStream(b))
                        {
                            picCar.Image = Image.FromStream(ms);
                        }
                        
                    }

                    data.Close();
                }
            }
        }

        private MySqlDataReader GetRekord(int rowId)
        {
            string sql = @"SELECT model_id, type_id, registration_plate, `ENGINE`, manufacturer_year, image,fuel, TM.brand_id
                            FROM cars TC 
	                            INNER JOIN car_models TM ON TM.id = TC.model_id
                            WHERE TC.id = @id";
            MySqlCommand cmd = new MySqlCommand(sql, GlobalData.connection);
            cmd.Parameters.AddWithValue("@id", rowId);

            MySqlDataReader result = cmd.ExecuteReader();
            return result;
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
                pictureFileName = "";
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

            string sql = null;
            string cPic = RowId>0 && pictureFileName == null? "": " image = @image, ";

            if (RowId == 0)
                sql = @"INSERT INTO cars (model_id, type_id, registration_plate, `ENGINE`, manufacturer_year, image,fuel)
                           VALUES (@model_id, @type_id, @reg_plate, @engine, @year, @image, @fuel)";
            else
                sql = $@"UPDATE cars SET
                            model_id = @model_id, 
                            type_id = @type_id, 
                            registration_plate = @reg_plate,
                            `engine` = @engine,
                            manufacturer_year = @year, 
                            {cPic}                             
                           fuel = @fuel
                        WHERE
                            id = @id";

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
            if (!string.IsNullOrEmpty(pictureFileName))
                cmd.Parameters["@image"].Value = File.ReadAllBytes(pictureFileName);
            else
                cmd.Parameters["@image"].Value = null;
            
            if (RowId > 0)
                cmd.Parameters.AddWithValue("@id", RowId);

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
