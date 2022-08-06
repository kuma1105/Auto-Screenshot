using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

namespace ScreenCapture
{
    public partial class Form1 : Form
    {
        int Year = DateTime.Now.Year;      // 년
        int Month = DateTime.Now.Month;    // 월
        int Day = DateTime.Now.Day;        // 일

        int Hour = DateTime.Now.Hour;      // 시
        int Minute = DateTime.Now.Minute;  // 분
        int Second = DateTime.Now.Second;  // 초
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {



        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Interval = 100; //타이머 간격 100ms
            timer1.Start();  //타이머 시작 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Stop(); //타이머 중지
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            int Year = DateTime.Now.Year;      // 년
            int Month = DateTime.Now.Month;    // 월
            int Day = DateTime.Now.Day;        // 일

            int Hour = DateTime.Now.Hour;      // 시
            int Minute = DateTime.Now.Minute;  // 분
            int Second = DateTime.Now.Second;  // 초

            // label1에 현재날짜시간 표시, F:자세한 전체 날짜/시간
            label1.Text = DateTime.Now.ToString("F");

            if ((Minute == 1 && Second == 0) || (Minute == 50 && Second == 0))
            {
                Screen scr = Screen.PrimaryScreen; // 주 모니터 화면

                Rectangle rect = scr.Bounds;

                Bitmap bmp = new Bitmap(rect.Width, rect.Height); // 화면 크기만큼의 비트맵을 만든다.

                Graphics g = Graphics.FromImage(bmp); // 이미지를 변경 또는 수정하기 위한 객체
                g.CopyFromScreen(rect.Left, rect.Top, 0, 0, rect.Size);
                g.Dispose(); // 더 이상 사용하지 않으므로 해제

                string folderPath = @"C:\Users\K_Digital\" + $"{Year}" + "년" + $"{Month}" + "월" + $"{Day}" + "일";

                DirectoryInfo di = new DirectoryInfo(folderPath);
                if (!di.Exists)
                {
                    di.Create();
                }

                bmp.Save(folderPath + "\\" + $"{Year}" + "년" + $"{Month}" + "월" + $"{Day}" + "일" + $"{Hour}" + "시" + $"{Minute}" + "분" + ".png");
                bmp.Dispose();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Screen scr = Screen.PrimaryScreen; // 주 모니터 화면

            Rectangle rect = scr.Bounds;

            Bitmap bmp = new Bitmap(rect.Width, rect.Height); // 화면 크기만큼의 비트맵을 만든다.
            
            Graphics g = Graphics.FromImage(bmp); // 이미지를 변경 또는 수정하기 위한 객체
            g.CopyFromScreen(rect.Left, rect.Top, 0, 0, rect.Size);
            g.Dispose(); // 더 이상 사용하지 않으므로 해제

            int Year = DateTime.Now.Year;
            int Month = DateTime.Now.Month;
            int Day = DateTime.Now.Day;
            int Hour = DateTime.Now.Hour;
            int Minute = DateTime.Now.Minute;

            string folderPath = @"C:\Users\K_Digital\" + $"{Year}" + "년" + $"{Month}" + "월" + $"{Day}" + "일";

            DirectoryInfo di = new DirectoryInfo(folderPath);
            if (!di.Exists)
            {
                di.Create();
            }

            bmp.Save(folderPath + "\\" + $"{Year}" + "년" + $"{Month}" + "월" + $"{Day}" + "일" + $"{Hour}" + "시" + $"{Minute}" + "분" + ".png");
            bmp.Dispose();
        }
    }
}
