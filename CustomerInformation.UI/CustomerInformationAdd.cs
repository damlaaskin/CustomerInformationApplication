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
    public partial class CustomerInformation : Form
    {
        public CustomerInformation()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void Kaydet_Click(object sender, EventArgs e)
        {
            var user = new
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                DateOfBirth = txtBirthYear.Text,
                IdentificationNumber = txtTCKN.Text
            };
            var client = new RestClient("https://localhost:5001/CustomerInformation/createcustomerinformation");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");

            var body = new
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                IdentificationNumber = txtTCKN.Text,
                DateOfBirth = txtBirthYear.Text

            };

            request.AddParameter("application/json", JsonConvert.SerializeObject(body), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);



            if (!string.IsNullOrEmpty(response.Content))
            {
                dynamic errorObject = JsonConvert.DeserializeObject(response.Content);
                if (errorObject != null && errorObject.isSuccess==false)
                {
                    MessageBox.Show(errorObject.message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else if (errorObject != null && errorObject.isSuccess==true)
                {
                    MessageBox.Show("Kayıt başarılı");
                }
            }
            else
            {
                MessageBox.Show("Hata oluştu, yanıt içeriği boş.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void txtTCKN_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtTCKN_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
