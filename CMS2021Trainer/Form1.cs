using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace TwitchTrainerGuide
{
    public partial class CMS2021Trainer : Form
    {
        public CMS2021Trainer()
        {
            InitializeComponent();
        }
        GuideHacking gh = new GuideHacking();
        IntPtr hProc, modBase, healtAdres;

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] buf = new byte[24];
            Process proc = Process.GetProcessesByName("Car Mechanic Simulator 2021")[0];
            hProc = GuideHacking.OpenProcess(GuideHacking.ProcessAccessFlags.All, false, proc.Id);
            modBase = GuideHacking.GetModuleBaseAddress(proc.Id, "UnityPlayer.dll");
            healtAdres = GuideHacking.FindDMAAddy(hProc, (IntPtr)(modBase + 0x01A1C970), new int[] { 0x820, 0x318, 0x110, 0x150, 0x60, 0x28, 0xAD8 });
            GuideHacking.ReadProcessMemory(hProc, healtAdres, buf, 4, out _);
            int Reading = BitConverter.ToInt32(buf, 0);
            GuideHacking.WriteProcessMemory(hProc, healtAdres, Convert.ToInt32(textBox2.Text), 4, out _);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            byte[] buf = new byte[24];
            Process proc = Process.GetProcessesByName("Car Mechanic Simulator 2021")[0];
            hProc = GuideHacking.OpenProcess(GuideHacking.ProcessAccessFlags.All, false, proc.Id);
            modBase = GuideHacking.GetModuleBaseAddress(proc.Id, "GameAssembly.dll");
            healtAdres = GuideHacking.FindDMAAddy(hProc, (IntPtr)(modBase + 0x0267D578), new int[] { 0x80, 0x80, 0x18, 0xB8, 0x0, 0x90, 0x30 });
            GuideHacking.ReadProcessMemory(hProc, healtAdres, buf, 4, out _);
            int Reading = BitConverter.ToInt32(buf, 0);
            GuideHacking.WriteProcessMemory(hProc, healtAdres, Convert.ToInt32(textBox3.Text), 4, out _);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] buf = new byte[24];
            Process proc = Process.GetProcessesByName("Car Mechanic Simulator 2021")[0];
            hProc = GuideHacking.OpenProcess(GuideHacking.ProcessAccessFlags.All, false, proc.Id);
            modBase = GuideHacking.GetModuleBaseAddress(proc.Id, "GameAssembly.dll");
            healtAdres = GuideHacking.FindDMAAddy(hProc, (IntPtr)(modBase + 0x0272D150), new int[] { 0x40, 0x80, 0x110, 0x78, 0xB8, 0x2A0 });
            GuideHacking.ReadProcessMemory(hProc, healtAdres, buf, 4, out _);
            int Reading = BitConverter.ToInt32(buf, 0);
            GuideHacking.WriteProcessMemory(hProc, healtAdres, Convert.ToInt32(textBox1.Text), 4, out _);

        }
    }
}
