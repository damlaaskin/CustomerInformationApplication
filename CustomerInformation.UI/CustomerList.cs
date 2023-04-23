using Customer.Information.Query.Responses;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerInformation.UI
{
    public partial class CustomerList : Form
    {
        public CustomerList()
        {
            InitializeComponent();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            var client = new RestClient("https://localhost:5001/CustomerInformation/listcustomerinformation");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            //            var body = @"{
            //" + "\n" +
            //            @"    ""FirstName"": ""Ali"",
            //" + "\n" +
            //            @"    ""LastName"": ""Ceylan"",
            //" + "\n" +
            //            @"    ""IdentificationNumber"": 33668400370,
            //" + "\n" +
            //            @"    ""DateOfBirth"": ""1993-01-01"",
            //" + "\n" +
            //            @"    ""CustomerRef"": 2
            //" + "\n" +
            //            @"}";

            var body = new
            {
                FirstName = txtAd.Text,
                LastName = txtSoyad.Text,
                IdentificationNumber = txtTCKN.Text

            };

            request.AddParameter("application/json", JsonConvert.SerializeObject(body), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                ListCustomerInformationResponse list = JsonConvert.DeserializeObject<ListCustomerInformationResponse>(response.Content);
                dataGridView1.DataSource = list.Data;
            }
        }




        private void txtTCKN_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
              (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void CustomerList_Load(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn refKolonu = new DataGridViewTextBoxColumn();
            refKolonu.HeaderText = "Müşteri No";
            refKolonu.DataPropertyName = "CustomerRef";
            dataGridView1.Columns.Add(refKolonu);

            DataGridViewTextBoxColumn adKolonu = new DataGridViewTextBoxColumn();
            adKolonu.HeaderText = "Ad";
            adKolonu.DataPropertyName = "FirstName";
            dataGridView1.Columns.Add(adKolonu);

            // Soyad kolonu
            DataGridViewTextBoxColumn soyadKolonu = new DataGridViewTextBoxColumn();
            soyadKolonu.HeaderText = "Soyad";
            soyadKolonu.DataPropertyName = "LastName";
            dataGridView1.Columns.Add(soyadKolonu);

            // TCKN kolonu
            DataGridViewTextBoxColumn tcknKolonu = new DataGridViewTextBoxColumn();
            tcknKolonu.HeaderText = "TCKN";
            tcknKolonu.DataPropertyName = "IdentificationNumber";
            dataGridView1.Columns.Add(tcknKolonu);

            // Doğum Tarihi kolonu
            DataGridViewTextBoxColumn dogumTarihiKolonu = new DataGridViewTextBoxColumn();
            dogumTarihiKolonu.HeaderText = "Doğum Tarihi";
            dogumTarihiKolonu.DataPropertyName = "DateOfBirth";
            dataGridView1.Columns.Add(dogumTarihiKolonu);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            CustomerInformation ci = new CustomerInformation();
            ci.Show();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];

                //string rowData = "";
                //foreach (DataGridViewCell cell in row.Cells)
                //{
                //    rowData += cell.Value.ToString() + " ";
                //}

                //MessageBox.Show(rowData);

                int customerRef = Convert.ToInt32(row.Cells[0].Value);


                CustomerInformationUpdate ciu = new CustomerInformationUpdate(customerRef);
                ciu.Show();


                dataGridView1.ClearSelection();
            }
        }
    }
}
