using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

/*
#################################################################
#                             _`				                #
#                          _ooOoo_				                #
#                         o8888888o				                #
#                         88" . "88				                #
#                         (| -_- |)				                #
#                         O\  =  /O				                #
#                      ____/`---'\____				            #
#                    .'  \\|     |//  `.			            #
#                   /  \\|||  :  |||//  \			            #
#                  /  _||||| -:- |||||_  \			            #
#                  |   | \\\  -  /'| |   |			            #
#                  | \_|  `\`---'//  |_/ |			            #
#                  \  .-\__ `-. -'__/-.  /			            #
#                ___`. .'  /--.--\  `. .'___			        #
#             ."" '<  `.___\_<|>_/___.' _> \"".			        #
#            | | :  `- \`. ;`. _/; .'/ /  .' ; |		        #
#            \  \ `-.   \_\_`. _.'_/_/  -' _.' /		        #
#=============`-.`___`-.__\ \___  /__.-'_.'_.-'=================#
                           `= --= -'                    

            TRỜI PHẬT PHÙ HỘ CODE CON KHÔNG BI BUG

          _.-/`)
         // / / )
      .=// / / / )
     //`/ / / / /
     // /     ` /
   ||         /
    \\       /
     ))    .'
         //    /
         /

*/

namespace UAV
{
    public partial class Drone : Form
    {
        private UdpClient udpClient;
        private UdpClient udpSender = new UdpClient();
        const int udpPort = 8080; // Cổng UDP

        // Mảng lưu dữ liệu nhận
        double[] angleValues = new double[7];
        double[] rateValues = new double[7];

        // Mảng lưu dữ liệu gửi
        double[] SPpacket = new double[6];
        double[] PIDangle = new double[8];
        double[] PIDrate = new double[9];
        double[] emergency = new double[1];
        double[] calibrate = new double[2];

        int flag = 0;
        double TickStart;

        public Drone()
        {
            InitializeComponent();

            // Khởi tạo Roll ZedGraph
            GraphPane rollPane = ChartRoll.GraphPane;
            rollPane.Title.Text = "Roll Chart";
            rollPane.XAxis.Title.Text = "Time (s)";
            rollPane.YAxis.Title.Text = "Roll";

            RollingPointPairList rollSetPoint = new RollingPointPairList(60000);
            RollingPointPairList rollResponse = new RollingPointPairList(60000);
            LineItem setRoll = rollPane.AddCurve("Roll SP", rollSetPoint, Color.Red, SymbolType.None);
            LineItem responseRoll = rollPane.AddCurve("Response Roll", rollResponse, Color.Blue, SymbolType.None);

            rollPane.XAxis.Scale.Min = 0;
            rollPane.XAxis.Scale.Max = 20;
            rollPane.XAxis.Scale.MinorStep = 1;
            rollPane.XAxis.Scale.MajorStep = 1;

            rollPane.YAxis.Scale.Min = 0;
            rollPane.YAxis.Scale.Max = 40;
            rollPane.YAxis.Scale.MinorStep = 1;
            rollPane.YAxis.Scale.MajorStep = 5;

            rollPane.AxisChange();

            // Khởi tạo Pitch ZedGraph
            GraphPane pitchPane = ChartPitch.GraphPane;
            pitchPane.Title.Text = "Pitch Chart";
            pitchPane.XAxis.Title.Text = "Time (s)";
            pitchPane.YAxis.Title.Text = "Pitch";

            RollingPointPairList pitchSetPoint = new RollingPointPairList(60000);
            RollingPointPairList pitchResponse = new RollingPointPairList(60000);
            LineItem setPitch = pitchPane.AddCurve("Pitch SP", pitchSetPoint, Color.Red, SymbolType.None);
            LineItem responsePitch = pitchPane.AddCurve("Response Pitch", pitchResponse, Color.Blue, SymbolType.None);

            pitchPane.XAxis.Scale.Min = 0;
            pitchPane.XAxis.Scale.Max = 20;
            pitchPane.XAxis.Scale.MinorStep = 1;
            pitchPane.XAxis.Scale.MajorStep = 1;

            pitchPane.YAxis.Scale.Min = 0;
            pitchPane.YAxis.Scale.Max = 40;
            pitchPane.YAxis.Scale.MinorStep = 1;
            pitchPane.YAxis.Scale.MajorStep = 5;

            pitchPane.AxisChange();

            // Khởi tạo Yaw ZedGraph
            GraphPane yawPane = ChartYaw.GraphPane;
            yawPane.Title.Text = "Yaw Chart";
            yawPane.XAxis.Title.Text = "Time (s)";
            yawPane.YAxis.Title.Text = "Yaw";

            RollingPointPairList yawSetPoint = new RollingPointPairList(60000);
            RollingPointPairList yawResponse = new RollingPointPairList(60000);
            LineItem setYaw = yawPane.AddCurve("Yaw SP", yawSetPoint, Color.Red, SymbolType.None);
            LineItem responseYaw = yawPane.AddCurve("Response Yaw", yawResponse, Color.Blue, SymbolType.None);

            yawPane.XAxis.Scale.Min = 0;
            yawPane.XAxis.Scale.Max = 20;
            yawPane.XAxis.Scale.MinorStep = 1;
            yawPane.XAxis.Scale.MajorStep = 1;

            yawPane.YAxis.Scale.Min = 0;
            yawPane.YAxis.Scale.Max = 40;
            yawPane.YAxis.Scale.MinorStep = 1;
            yawPane.YAxis.Scale.MajorStep = 5;

            yawPane.AxisChange();

            TickStart = Environment.TickCount;
        }

        private void StartUdpListener()
        {
            udpClient = new UdpClient(udpPort);
            udpClient.BeginReceive(new AsyncCallback(ReceiveCallback), null);
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, udpPort);
                byte[] receivedBytes = udpClient.EndReceive(ar, ref remoteEndPoint);

                // Chuyển đổi dữ liệu từ byte[] sang float[]
                float[] receivedData = new float[receivedBytes.Length / 4];
                for (int i = 0; i < receivedData.Length; i++)
                {
                    receivedData[i] = BitConverter.ToSingle(receivedBytes, i * 4);
                }

                // Lấy packetID
                float packetID = receivedData[0];

                // Phân loại dữ liệu dựa trên packetID
                if (packetID == 1)
                {
                    Array.Copy(receivedData, angleValues, 7);
                }
                else if (packetID == 2)
                {
                    Array.Copy(receivedData, rateValues, 7);
                }

                // Lắng nghe tiếp
                udpClient.BeginReceive(new AsyncCallback(ReceiveCallback), null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void connectButt_Click(object sender, EventArgs e)
        {
            StartUdpListener();
            connectButt.Enabled = false;
        }

        private void exitButt_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void angleButt_Click(object sender, EventArgs e)
        {
            flag = 1;
            angleButt.Enabled = false;
            rateButt.Enabled = true;
        }
        private void rateButt_Click(object sender, EventArgs e)
        {
            flag = 2;
            rateButt.Enabled = false;
            angleButt.Enabled = true;
        }
        private void sendButt_Click(object sender, EventArgs e)
        {
            float kpRollPitchAngle, kiRollPitchAngle, kdRollPitchAngle, kpYawAngle, kiYawAngle, kdYawAngle, kpRollPitchRate, kiRollPitchRate, kdRollPitchRate, kpYawRate, kiYawRate, kdYawRate;

            // Kiểm tra dữ liệu hợp lệ từ các TextBox
            if (!ValidateFloatInput(kpRollPitchAngleBox, out kpRollPitchAngle) ||
                !ValidateFloatInput(kiRollPitchAngleBox, out kiRollPitchAngle) ||
                !ValidateFloatInput(kdRollPitchAngleBox, out kdRollPitchAngle) ||
                !ValidateFloatInput(kpYawAngleBox, out kpYawAngle) ||
                !ValidateFloatInput(kiYawAngleBox, out kiYawAngle) ||
                !ValidateFloatInput(kdYawAngleBox, out kdYawAngle) ||
                !ValidateFloatInput(kpRollPitchRateBox, out kpRollPitchRate) ||
                !ValidateFloatInput(kiRollPitchRateBox, out kiRollPitchRate) ||
                !ValidateFloatInput(kdRollPitchRateBox, out kdRollPitchRate) ||
                !ValidateFloatInput(kpYawRateBox, out kpYawRate) ||
                !ValidateFloatInput(kiYawRateBox, out kiYawRate) ||
                !ValidateFloatInput(kdYawRateBox, out kdYawRate))
            {
                return; // Dừng thực hiện nếu có lỗi
            }

            // Nếu tất cả hợp lệ, gán giá trị

            PIDangle[0] = 2;
            PIDangle[1] = kpRollPitchAngle;
            PIDangle[2] = kiRollPitchAngle;
            PIDangle[3] = kdRollPitchAngle;
            PIDangle[4] = kpYawAngle;
            PIDangle[5] = kiYawAngle;
            PIDangle[6] = kdYawAngle;

            PIDrate[0] = 3;
            PIDrate[1] = kpRollPitchRate;
            PIDrate[2] = kiRollPitchRate;
            PIDrate[3] = kdRollPitchRate;
            PIDrate[4] = kpYawRate;
            PIDrate[5] = kiYawRate;
            PIDrate[6] = kdYawRate;

            try
            {
                // Gửi PIDangle
                byte[] pidAngleData = ConvertDoubleArrayToByteArray(PIDangle);
                udpSender.Send(pidAngleData, pidAngleData.Length, EspIP.Text, Convert.ToInt16(EspPort.Text));

                // Gửi PIDrate
                byte[] pidRateData = ConvertDoubleArrayToByteArray(PIDrate);
                udpSender.Send(pidRateData, pidRateData.Length, EspIP.Text, Convert.ToInt16(EspPort.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Địa chỉ IP hoặc cổng Port không hợp lệ", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
        }

        private void sendSPButt_Click(object sender, EventArgs e)
        {
            float roll, pitch, yaw, throttle;

            // Kiểm tra dữ liệu hợp lệ từ các TextBox
            if (!ValidateFloatInput(rollBox, out roll) ||
                !ValidateFloatInput(pitchBox, out pitch) ||
                !ValidateFloatInput(yawBox, out yaw) ||
                !ValidateFloatInput(throttleBox, out throttle))
            {
                return; // Dừng thực hiện nếu có lỗi
            }

            // Nếu tất cả hợp lệ, gán giá trị
            SPpacket[0] = 1;
            SPpacket[1] = roll;
            SPpacket[2] = pitch;
            SPpacket[3] = yaw;
            SPpacket[4] = throttle;

            try
            {
                // Gửi SPpacket
                byte[] spData = ConvertDoubleArrayToByteArray(SPpacket);
                udpSender.Send(spData, spData.Length, EspIP.Text, Convert.ToInt16(EspPort.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Địa chỉ IP hoặc cổng Port không hợp lệ", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
        }

        private void emerButt_Click(object sender, EventArgs e)
        {
            // Nếu tất cả hợp lệ, gán giá trị
            emergency[0] = 4;

            try
            {
                // Gửi SPpacket
                byte[] emerData = ConvertDoubleArrayToByteArray(emergency);
                udpSender.Send(emerData, emerData.Length, EspIP.Text, Convert.ToInt16(EspPort.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Địa chỉ IP hoặc cổng Port không hợp lệ", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
        }
        private void calibButt_Click(object sender, EventArgs e)
        {
            // Nếu tất cả hợp lệ, gán giá trị
            calibrate[0] = 5;

            try
            {
                // Gửi SPpacket
                byte[] calibData = ConvertDoubleArrayToByteArray(calibrate);
                udpSender.Send(calibData, calibData.Length, EspIP.Text, Convert.ToInt16(EspPort.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Địa chỉ IP hoặc cổng Port không hợp lệ", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
        }

        private bool ValidateFloatInput(System.Windows.Forms.TextBox textBox, out float value)
        {
            // Kiểm tra xem nội dung trong TextBox có thể chuyển sang float hay không
            if (float.TryParse(textBox.Text, out value))
            {
                return true; // Dữ liệu hợp lệ
            }
            else
            {
                MessageBox.Show($"Dữ liệu nhập vào ô '{textBox.Name}' không hợp lệ. Vui lòng nhập số thực.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox.Focus();
                return false; // Dữ liệu không hợp lệ
            }
        }

        // Hàm chuyển đổi mảng double thành byte array
        private byte[] ConvertDoubleArrayToByteArray(double[] array)
        {
            int byteSize = array.Length * sizeof(double); // 8 bytes mỗi double
            byte[] byteArray = new byte[byteSize];

            Buffer.BlockCopy(array, 0, byteArray, 0, byteSize); // Chuyển đổi đúng dữ liệu

            return byteArray;
        }

        private void Drone_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Đóng UDP khi đóng form
            udpClient?.Close();
        }

        private void Draw_Set_Point(ZedGraphControl zedGraph, double setpoint)
        {
            if (zedGraph.GraphPane.CurveList.Count <= 0) return;

            LineItem SetPointCurve = zedGraph.GraphPane.CurveList[0] as LineItem;

            if (SetPointCurve == null) return;

            IPointListEdit SetPointList = SetPointCurve.Points as IPointListEdit;

            if (SetPointList == null) return;

            double time = (Environment.TickCount - TickStart) / 1000.0;
            SetPointList.Add(time, setpoint);

            Scale xScale = zedGraph.GraphPane.XAxis.Scale;
            Scale yScale = zedGraph.GraphPane.YAxis.Scale;

            // Tự động Scale theo trục x
            if (time > xScale.Max - xScale.MajorStep)
            {
                xScale.Max = time + xScale.MajorStep;
                xScale.Min = xScale.Max - 10.0;
            }

            // Tự động Scale theo trục y
            if (setpoint > yScale.Max - yScale.MajorStep)
            {
                yScale.Max = setpoint + yScale.MajorStep;
            }
            else if (setpoint < yScale.Min + yScale.MajorStep)
            {
                yScale.Min = setpoint - yScale.MajorStep;
            }

            zedGraph.AxisChange();
            zedGraph.Invalidate();
        }

        private void Draw_Response(ZedGraphControl zedGraph, double response)
        {
            if (zedGraph.GraphPane.CurveList.Count <= 0) return;

            LineItem distanceCurve = zedGraph.GraphPane.CurveList[1] as LineItem;

            if (distanceCurve == null) return;

            IPointListEdit DistanceList = distanceCurve.Points as IPointListEdit;

            if (DistanceList == null) return;

            double time = (Environment.TickCount - TickStart) / 1000.0;
            DistanceList.Add(time, response);

            Scale xScale = zedGraph.GraphPane.XAxis.Scale;
            Scale yScale = zedGraph.GraphPane.YAxis.Scale;

            // Tự động Scale theo trục x
            if (time > xScale.Max - xScale.MajorStep)
            {
                xScale.Max = time + xScale.MajorStep;
                xScale.Min = xScale.Max - 10.0;
            }

            // Tự động Scale theo trục y
            if (response > yScale.Max - yScale.MajorStep)
            {
                yScale.Max = response + yScale.MajorStep;
            }
            else if (response < yScale.Min + yScale.MajorStep)
            {
                yScale.Min = response - yScale.MajorStep;
            }

            zedGraph.AxisChange();
            zedGraph.Invalidate();
        }

        void Draw(double[] data_Draw_Chart)
        {
            Draw_Set_Point(ChartRoll, data_Draw_Chart[1]);
            Draw_Response(ChartRoll, data_Draw_Chart[4]);

            Draw_Set_Point(ChartPitch, data_Draw_Chart[2]);
            Draw_Response(ChartPitch, data_Draw_Chart[5]);

            Draw_Set_Point(ChartYaw, data_Draw_Chart[3]);
            Draw_Response(ChartYaw, data_Draw_Chart[6]);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                Draw(angleValues);
            } else if (flag == 2)
            {
                Draw(rateValues);
            }
        }
    }
}
