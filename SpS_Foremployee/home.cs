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
using Emgu.CV.OCR;
using Emgu.CV.Structure;
using Emgu.CV;
using System.Runtime.InteropServices;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;
using System;



namespace SpS_Foremployee
{
    public partial class home : Form
    {

        private FilterInfoCollection cameras;
        private VideoCaptureDevice cam;
        private VideoCaptureDevice camread;
        private VideoCaptureDevice camout;
        int historyid = 0;
        int newid = 0;
        string codesecurity;
        string codesecurityout;
        string idhis;
        string idCar;
        private VideoCapture _capture;
        private Tesseract _tesseract;
        private bool foundLicensePlate = false;




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
            _capture = new VideoCapture();
           
        }
        SqlConnection conn = new SqlConnection(@"Server=tcp:smartpackingsystem.database.windows.net,1433;Initial Catalog=SPSDB;Persist Security Info=False;User ID=adminsps;Password=Sps@12345;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30");


        private void button2_Click(object sender, EventArgs e)
        {
        }
        private void Form1_Load(object sender, EventArgs e)
        {

         
/*           StartCapture();*/

        }

        private void StartCapture()
        {
            // Đặt kích thước picture box hiển thị camera
            /*   pbcamerafontin.Width = 326;
               pbcamerafontin.Height = 430;*/

            // Bắt đầu quét từ camera
            
            Application.Idle += ProcessFrame;
            
          
        }

        private void StopCapture()
        {
            // Dừng quét từ camera
            Application.Idle -= ProcessFrame;
        }

        private void ProcessFrame(object sender, EventArgs e)
        {
            if (foundLicensePlate)
                return;

            Mat frame = _capture.QueryFrame();
            pbcamerafontin.SizeMode = PictureBoxSizeMode.Zoom;
            pbcamerafontin.Image = ConvertMatToBitmap(frame);

            Rectangle licensePlateRegion = FindLicensePlateRegion(frame);


            if (licensePlateRegion != Rectangle.Empty)
            {

                // Cắt vùng chứa bảng số xe từ khung hình gốc

                Bitmap licensePlateImage = ConvertMatToBitmap(frame).Clone(licensePlateRegion, ConvertMatToBitmap(frame).PixelFormat);

                // Hiển thị hình ảnh bảng số xe lên picture box
                pbreadcarplate.SizeMode = PictureBoxSizeMode.StretchImage;
                pbreadcarplate.Image = licensePlateImage;


                // Xử lý hình ảnh bảng số xe để đọc số
                string licensePlateNumber = ProcessLicensePlateImage(licensePlateImage);

                // Xuất số xe ra textbox
                tb_readcarplate.Text = licensePlateNumber;
            }
            else
            {
                // Nếu không tìm thấy vùng chứa bảng số xe, xóa hình ảnh trên picture box và xóa nội dung trong textbox
                pbreadcarplate.Image = null;
                tb_readcarplate.Text = "";
            }
            
        }

        private string ProcessLicensePlateImage(Bitmap licensePlateImage)
        {
            Mat frame = new Mat();
            BitmapToMat(licensePlateImage, frame);

            // Chuyển đổi hình ảnh sang ảnh xám
            Mat grayImage = new Mat();
            CvInvoke.CvtColor(frame, grayImage, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);

            // Tạo đối tượng Tesseract OCR
            using (var engine = new Tesseract("tessdata", "eng", OcrEngineMode.Default))
            {
                // Sử dụng phương thức SetImage để đặt hình ảnh đầu vào
                engine.SetImage(grayImage);

                // Sử dụng phương thức Recognize để nhận dạng số xe
                engine.Recognize();

                // Lấy kết quả nhận dạng
                string licensePlateNumber = engine.GetUTF8Text();

            
         

                return licensePlateNumber;
            }
        }


 
        private void BitmapToMat(Bitmap bitmap, Mat mat)
        {
            BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, bitmap.PixelFormat);
            try
            {
                int stride = bmpData.Stride;
                int bytesPerPixel = Bitmap.GetPixelFormatSize(bitmap.PixelFormat) / 8;
                IntPtr ptr = bmpData.Scan0;

                byte[] data = new byte[stride * bitmap.Height];
                Marshal.Copy(ptr, data, 0, data.Length);

                mat.Create(bitmap.Height, bitmap.Width, Emgu.CV.CvEnum.DepthType.Cv8U, bytesPerPixel);
                mat.SetTo(data);
            }
            finally
            {
                bitmap.UnlockBits(bmpData);
            }
        }


        private Rectangle FindLicensePlateRegion(Mat frame)
         {
             // Chuyển đổi khung hình sang ảnh xám để dễ dàng xử lý
             Mat grayImage = new Mat();
             CvInvoke.CvtColor(frame, grayImage, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);

             // Áp dụng bộ lọc và xử lý hình ảnh để tăng cường chất lượng và độ tương phản
             CvInvoke.GaussianBlur(grayImage, grayImage, new Size(5, 5), 0);
             CvInvoke.EqualizeHist(grayImage, grayImage);

             // Áp dụng thuật toán phát hiện biên (Canny) để tìm biên của các vật thể trong ảnh
             double cannyThreshold = CvInvoke.Threshold(grayImage, grayImage, 0, 255, Emgu.CV.CvEnum.ThresholdType.Otsu);
             CvInvoke.Canny(grayImage, grayImage, cannyThreshold * 0.5, cannyThreshold);

             // Áp dụng phép giãn ảnh để làm rõ các đặc trưng của biển số xe
             CvInvoke.Dilate(grayImage, grayImage, null, new Point(-1, -1), 1, Emgu.CV.CvEnum.BorderType.Default, new MCvScalar(1));

             // Tìm các đường viền trong ảnh
             VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
             CvInvoke.FindContours(grayImage, contours, null, Emgu.CV.CvEnum.RetrType.List, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);

             // Duyệt qua tất cả các đường viền và tìm vùng có hình dạng và kích thước tương thích với biển số xe
             for (int i = 0; i < contours.Size; i++)
             {
                 using (VectorOfPoint contour = contours[i])
                 {
                    Rectangle boundingRect = CvInvoke.BoundingRectangle(contour);
                    double aspectRatio = (double)boundingRect.Width / boundingRect.Height;
                    double area = CvInvoke.ContourArea(contour);

                    // Kiểm tra các yếu tố để xác định vùng có biển số xe
                    if (aspectRatio > 2 && aspectRatio < 8
                        && area > 1000 && area < 50000)
                    {
                        // Trả về vùng chứa biển số xe
                        return boundingRect;
                    }
                }
             }

             // Trả về Rectangle.Empty nếu không tìm thấy vùng chứa biển số xe
             return Rectangle.Empty;
         }

      







        private Bitmap ConvertMatToBitmap(Mat mat)
        {
            // Lấy thông tin kích thước và dữ liệu từ Mat
            int width = mat.Width;
            int height = mat.Height;
            byte[] data = new byte[width * height * mat.NumberOfChannels];
            Marshal.Copy(mat.DataPointer, data, 0, data.Length);

            // Tạo Bitmap mới từ dữ liệu
            PixelFormat pixelFormat = mat.NumberOfChannels == 1 ? PixelFormat.Format8bppIndexed : PixelFormat.Format24bppRgb;
            Bitmap bitmap = new Bitmap(width, height, pixelFormat);
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, pixelFormat);
            Marshal.Copy(data, 0, bitmapData.Scan0, data.Length);
            bitmap.UnlockBits(bitmapData);

            return bitmap;
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

        private void pbcamerafontin_Click(object sender, EventArgs e)
        {

        }
    }
}