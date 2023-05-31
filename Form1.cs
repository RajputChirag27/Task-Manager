using System.Diagnostics;

namespace TaskManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Process[] proc;
        void GetAllProcess()
        {
            proc = Process.GetProcesses();
            listBox1.Items.Clear();

            foreach (Process p in proc)
            {
                listBox1.Items.Add(p.ProcessName);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                proc[listBox1.SelectedIndex].Kill();
                GetAllProcess();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetAllProcess();
        }



        private void runNewTaskToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            using (frmRunTask frm = new frmRunTask())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    GetAllProcess();
                }
            }
        }
    }
}