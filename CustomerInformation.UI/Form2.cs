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
    public partial class CustomerInformationUpdate : Form
    {
        public CustomerInformationUpdate()
        {
            InitializeComponent();
        }
        public int CustomerRef { get; set; }
       
        public CustomerInformationUpdate(int customerRef)
        {
            CustomerRef = customerRef;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CustomerInformationUpdate_Load(object sender, EventArgs e)
        {
            var client = new RestClient("https://localhost:5001/CustomerInformation/getcustomerinformation/" + CustomerRef);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");

            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                GetCustomerInformationResponse data = JsonConvert.DeserializeObject<GetCustomerInformationResponse>(response.Content);

                txtAd.Text = data.Data.FirstName;
                txtSoyad.Text = data.Data.LastName;
                txtTCKN.Text = data.Data.IdentificationNumber;
                txtBirthDate.Text = data.Data.DateOfBirth;
                

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var client = new RestClient("https://localhost:5001/CustomerInformation/deletecustomerinformation");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);

            var body = new
            {
                CustomerRef = CustomerRef
            };

            request.AddParameter("application/json", JsonConvert.SerializeObject(body), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                dynamic errorObject = JsonConvert.DeserializeObject(response.Content);
                if (errorObject != null && errorObject.isSuccess == false)
                {
                    MessageBox.Show(errorObject.message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else if (errorObject != null && errorObject.isSuccess == true)
                {
                    MessageBox.Show("Silme işlemi başarılı");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var client = new RestClient("https://localhost:5001/CustomerInformation/updatecustomerinformation");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);

            var body = new
            {
                CustomerRef = CustomerRef,
                FirstName= txtAd.Text,
                LastName=txtSoyad.Text,
                DateOfBirth=txtBirthDate.Text,
                IdentificationNumber= txtTCKN.Text
            };

            request.AddParameter("application/json", JsonConvert.SerializeObject(body), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                dynamic errorObject = JsonConvert.DeserializeObject(response.Content);
                if (errorObject != null && errorObject.isSuccess == false)
                {
                    MessageBox.Show(errorObject.message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else if (errorObject != null && errorObject.isSuccess == true)
                {
                    MessageBox.Show("Güncelleme işlemi başarılı");
                }
            }

        }
    }
}
