using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using ZXing.Datamatrix;
using ZXing.Maxicode;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using Newtonsoft.Json;
using System.Data;
using Microsoft.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace SpS_Foremployee
{
    public partial class home : Form
    {

        private FilterInfoCollection cameras;
        private VideoCaptureDevice cam;
        private VideoCaptureDevice camout;
        int historyid = 0;
        int newid = 0;
        string codesecurity;
        string codesecurityout;
        string idhis;
        string idCar;


        public home()
        {
            InitializeComponent();
            cameras = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo info in cameras)
            {
                comboBox1.Items.Add(info.Name);
                comboBox3.Items.Add(info.Name);
            }
            comboBox1.SelectedIndex = 0;
            comboBox3.SelectedIndex = 1;
        }
        SqlConnection conn = new SqlConnection(@"Server=tcp:smartpackingsystem.database.windows.net,1433;Initial Catalog=SPSDB;Persist Security Info=False;User ID=adminsps;Password=Sps@12345;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30");

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cam != null && cam.IsRunning)
            {
                cam.Stop();
            }
            cam = new VideoCaptureDevice(cameras[comboBox1.SelectedIndex].MonikerString);
            cam.NewFrame += Cam_NewFrame;
            cam.Start();
        }
        private void Cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();

            Result result = ReadQRCode(bitmap);

            if (result != null)
            {
                string json = result.Text;
                ProcessJsonData(json);
                /*                Invoke((MethodInvoker)(() => textBox1.Text = result.Text));
                 *                
                */
                string carPlate, Codesecurity;
                carPlate = textBox1.Text;
                Codesecurity = codesecurity;
                String querry = "SELECT * FROM tb_Car WHERE carPlate = '" + textBox1.Text + "' AND securityCode = '" + Codesecurity + "'";


                // String querryupdate = "INSERT INTO tb_History(historyID,time_In) VALUES(@historyID, @time_in)";
                SqlDataAdapter sda = new SqlDataAdapter(querry, conn);
                /*  SqlDataAdapter sdainsert = new SqlDataAdapter(querryupdate, conn);*/

                DataTable dtable = new DataTable();
                sda.Fill(dtable);
                if (dtable.Rows.Count > 0)
                {
                    carPlate = textBox1.Text;
                    Codesecurity = codesecurity;
                    GetID();
                    GetCarID(textBox1.Text);
                    String querryupdate = "INSERT INTO tb_History(historyID,time_In,carPlate,carID,username) VALUES(@historyId,@timein,@carPlate,@carid,@Username)";
                    using (SqlCommand command = new SqlCommand(querryupdate, conn))
                    {
                        command.Parameters.AddWithValue("@historyId", newid);
                        command.Parameters.AddWithValue("@timein", tb_datetime.Text);
                        command.Parameters.AddWithValue("@carPlate", textBox1.Text);
                        command.Parameters.AddWithValue("@carid", idCar);
                        command.Parameters.AddWithValue("@Username", tb_username.Text);
                        command.ExecuteNonQuery();
                        conn.Close();
                    }
                    String querrycar = "UPDATE tb_Car SET historyID=@historyID WHERE carPlate = @carplate";
                    using (SqlCommand cm = new SqlCommand(querrycar, conn))
                    {
                        cm.Parameters.AddWithValue("@historyID", newid);
                        cm.Parameters.AddWithValue("@carplate", textBox1.Text);
                        conn.Open();
                        cm.ExecuteNonQuery();
                        conn.Close();
                    }
                    String querrycarcode = "UPDATE tb_Car SET securityCode=@securitycode WHERE carPlate = @carplate";
                    using (SqlCommand cm = new SqlCommand(querrycarcode, conn))
                    {
                        cm.Parameters.AddWithValue("@securitycode", "");
                        cm.Parameters.AddWithValue("@carplate", textBox1.Text);
                        conn.Open();
                        cm.ExecuteNonQuery();
                        conn.Close();
                    }

                    MessageBox.Show("Success welcome to parking ", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);

                }
                else
                {
                    MessageBox.Show("Please generate a new QRCode and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            pictureBox1.Image = bitmap;

        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            if (cam != null && cam.IsRunning)
            {
                cam.Stop();

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private Result ReadQRCode(Bitmap bitmap)
        {
            try
            {
                MemoryStream memoryStream = new MemoryStream();
                bitmap.Save(memoryStream, ImageFormat.Bmp);
                byte[] byteArray = memoryStream.GetBuffer();
                ZXing.LuminanceSource source = new RGBLuminanceSource(byteArray, bitmap.Width, bitmap.Height);
                var binarizer = new HybridBinarizer(source);
                var binBitmap = new BinaryBitmap(binarizer);
                QRCodeReader qrCodeReader = new QRCodeReader();
                Result str = qrCodeReader.decode(binBitmap);
                return str;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                Console.WriteLine("Lỗi quét mã QR: " + ex.Message);
                return null;
            }

        }
        private void ProcessJsonData(string json)
        {
            try
            {
                dynamic jsonData = JsonConvert.DeserializeObject(json);
                string carPlate = jsonData.carPlate;
                string datetime = jsonData.datetime;
                string username = jsonData.username;
                codesecurity = jsonData.securityCode;


                textBox1.Invoke(new Action(() => textBox1.Text = jsonData.carPlate));
                tb_datetime.Invoke(new Action(() => tb_datetime.Text = jsonData.datetime));
                tb_username.Invoke(new Action(() => tb_username.Text = jsonData.username));



            }
            catch (Exception ex) { }
        }

        private void btcamout_Click(object sender, EventArgs e)
        {

            if (camout != null && camout.IsRunning)
            {
                camout.Stop();
            }
            camout = new VideoCaptureDevice(cameras[comboBox3.SelectedIndex].MonikerString);
            camout.NewFrame += Cam_NewFrame1;
            camout.Start();
        }

        private void Cam_NewFrame1(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();

            Result result = ReadQRCode(bitmap);

            if (result != null)
            {
                string json = result.Text;
                ProcessJsonDataout(json);

                String carplate, Codesecurity;
                carplate = tb_carplateout.Text;
                Codesecurity = codesecurityout;
                String querry = "SELECT * FROM tb_Car WHERE carPlate = '" + tb_carplateout.Text + "' AND securityCode = '" + Codesecurity + "'";
                SqlDataAdapter sda = new SqlDataAdapter(querry, conn);

                DataTable dtable = new DataTable();
                sda.Fill(dtable);
                if (dtable.Rows.Count > 0)
                {
                    carplate = tb_carplateout.Text;
                    codesecurityout = Codesecurity;

                    String querrycarcode = "UPDATE tb_Car SET securityCode=@securitycode WHERE carPlate = @carplate";
                    using (SqlCommand cm = new SqlCommand(querrycarcode, conn))
                    {
                        cm.Parameters.AddWithValue("@securitycode", "");
                        cm.Parameters.AddWithValue("@carplate", tb_carplateout.Text);
                        conn.Open();
                        cm.ExecuteNonQuery();
                        conn.Close();
                    }
                    GetouthisID(tb_carplateout.Text);
                    String updatehis = "UPDATE tb_History SET time_Out=@timeout WHERE historyID = @HistoryID";
                    using (SqlCommand cm = new SqlCommand(updatehis, conn))
                    {
                        cm.Parameters.AddWithValue("@timeout", tb_timeout.Text);
                        cm.Parameters.AddWithValue("@HistoryID", idhis);

                        cm.ExecuteNonQuery();
                        conn.Close();
                    }
                    String querrycar = "UPDATE tb_Car SET historyID=@historyID WHERE carPlate = @carplate";
                    using (SqlCommand cm = new SqlCommand(querrycar, conn))
                    {
                        cm.Parameters.AddWithValue("@historyID", "");
                        cm.Parameters.AddWithValue("@carplate", tb_carplateout.Text);
                        conn.Open();
                        cm.ExecuteNonQuery();
                        conn.Close();
                    }
                    MessageBox.Show("Thank you and see you again", "Sussecc", MessageBoxButtons.OK, MessageBoxIcon.None);


                }
                else
                {
                    MessageBox.Show("invalid login detail", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
            pictureBox2.Image = bitmap;

        }

        private void ProcessJsonDataout(string json)
        {
            try
            {
                dynamic jsonData = JsonConvert.DeserializeObject(json);
                string carPlate = jsonData.carPlate;
                string datetime = jsonData.datetime;
                string username = jsonData.username;
                codesecurityout = jsonData.securityCode;

                tb_carplateout.Invoke(new Action(() => tb_carplateout.Text = jsonData.carPlate));
                tb_timeout.Invoke(new Action(() => tb_timeout.Text = jsonData.datetime));
                tb_usernameout.Invoke(new Action(() => tb_usernameout.Text = jsonData.username));



            }
            catch (Exception ex) { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /* try
             {
                 string id = "1";
                 string name = "minh phuong";
                 String querryupdate = "UPDATE tb_History  SET username= @Username WHERE historyID = @id";
                 using (SqlCommand command = new SqlCommand(querryupdate, conn))
                 {

                     command.Parameters.AddWithValue("@Username", tb_username.Text);
                     command.Parameters.AddWithValue("@id", id);
                     conn.Open();
                     command.ExecuteNonQuery();

                 }
             }
             catch
             {
                 MessageBox.Show("invalid login detail", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

             }*/
        }

        private void GetID()
        {
            List<int> iddata = new List<int>();
            String querrygetid = "SELECT historyID FROM tb_History";
            using (SqlCommand command = new SqlCommand(querrygetid, conn))
            {
                conn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string data = reader.GetString(0);
                        iddata.Add(Int32.Parse(data));
                        for (var u = 0; u < iddata.Count(); u++)
                        {
                            if (iddata[u] > newid)
                            {
                                newid = iddata[u];
                            }
                        }

                    }
                }


            }
            newid += 1;

        }
        private string GetouthisID(String Carplate)
        {
            List<int> iddata = new List<int>();
            String querrygetid = "SELECT historyID FROM tb_Car WHERE carPlate=@carplate";
            using (SqlCommand command = new SqlCommand(querrygetid, conn))
            {
                command.Parameters.AddWithValue("@carplate", Carplate);
                conn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        idhis = reader.GetString(0);

                    }
                }
            }
            return idhis;
        }
        private string GetCarID(String Carplate)
        {
            List<int> iddata = new List<int>();
            String querrygetid = "SELECT carID FROM tb_Car WHERE carPlate=@carplate";
            using (SqlCommand command = new SqlCommand(querrygetid, conn))
            {
                command.Parameters.AddWithValue("@carplate", Carplate);
                
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        idCar = reader.GetString(0);

                    }
                }
            }
            return idCar;
        }

    }
}