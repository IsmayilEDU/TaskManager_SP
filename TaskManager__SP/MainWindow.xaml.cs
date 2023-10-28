using System;
using System.Collections.Generic;
using System.Windows;
using System.Diagnostics;
using System.Linq;

namespace TaskManager__SP
{
    public partial class MainWindow : Window
    {
        public List<Process> Processes { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Processes = new List<Process>();
            Processes = Process.GetProcesses().ToList();
        }

        private void btn_CreateProcess_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtBox_ProcessName.Text == "") throw new Exception("Process Name can not be empty!");

                var CreatedProcess = Process.Start(txtBox_ProcessName.Text.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_EndProcess_Click(object sender, RoutedEventArgs e)
        {
            Process SelectedProcess = listView_Processes.SelectedItem as Process;
            SelectedProcess!.Kill();
        }
    }
}
