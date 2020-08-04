using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Net;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Net.Sockets;

namespace SBiiXpress
{
    /// <summary>
    /// Classe de la form Securite, cette form n'est pas utilisée pour le moment
    /// </summary>
    public partial class Securite : Form
    {
        /// <summary>
        /// Cette liste contient tous les ports ouverts sur l'ordinateur
        /// </summary>
        List<Port> ListPort;

        /// <summary>
        /// Constructeur de la classe
        /// Cette form est pour le moment désactivée
        /// </summary>
        public Securite()
        {
            InitializeComponent();
            dataGridView1.ScrollBars = ScrollBars.Vertical;
            ColumnCheckBox.TrueValue = true;
            ColumnCheckBox.FalseValue = false;
        }

        private void btn_Fermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Analyse_Click(object sender, EventArgs e)
        {
            List<Port> ListPort = GetNetStatPorts();
            dataGridView1.Rows.Clear();
            foreach (Port p in ListPort)
            {
                dataGridView1.Rows.Add(false,p.process_name, p.port_number, p.name);
            }
        }
        /// <summary>
        /// Cette méthode permet de récupérer la liste de tous les ports ouverts sur l'ordinateur et les stockés dans une liste
        /// </summary>
        /// <returns></returns>
        public static List<Port> GetNetStatPorts()
        {
            var Ports = new List<Port>();

            try
            {
                using (Process p = new Process())
                {

                    ProcessStartInfo ps = new ProcessStartInfo();
                    ps.Arguments = "-a -n -o";
                    ps.FileName = "netstat.exe";
                    ps.UseShellExecute = false;
                    ps.WindowStyle = ProcessWindowStyle.Hidden;
                    ps.RedirectStandardInput = true;
                    ps.RedirectStandardOutput = true;
                    ps.RedirectStandardError = true;

                    p.StartInfo = ps;
                    p.Start();

                    StreamReader stdOutput = p.StandardOutput;
                    StreamReader stdError = p.StandardError;

                    string content = stdOutput.ReadToEnd() + stdError.ReadToEnd();
                    string exitStatus = p.ExitCode.ToString();

                    if (exitStatus != "0")
                    {
                        // Command Errored. Handle Here If Need Be
                    }

                    //Get The Rows
                    string[] rows = Regex.Split(content, "\r\n");
                    foreach (string row in rows)
                    {
                        //Split it baby
                        string[] tokens = Regex.Split(row, "\\s+");
                        if (tokens.Length > 4 && (tokens[1].Equals("UDP") || tokens[1].Equals("TCP")))
                        {
                            string localAddress = Regex.Replace(tokens[2], @"\[(.*?)\]", "1.1.1.1");
                            Ports.Add(new Port
                            {
                                protocol = localAddress.Contains("1.1.1.1") ? String.Format("{0}v6", tokens[1]) : String.Format("{0}v4", tokens[1]),
                                port_number = localAddress.Split(':')[1],
                                process_name = tokens[1] == "UDP" ? LookupProcess(Convert.ToInt16(tokens[4])) : LookupProcess(Convert.ToInt16(tokens[5]))
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Ports;
        }
        /// <summary>
        /// Permet de connaître le nom d'un processus en cours grâce à son ID
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public static string LookupProcess(int pid)
        {
            string procName;
            try { procName = Process.GetProcessById(pid).ProcessName; }
            catch (Exception) { procName = "-"; }
            return procName;
        }

        /// <summary>
        /// Classe Port
        /// </summary>
        public class Port
        {
            /// <summary>
            /// Variable qui contient le nom du port
            /// </summary>
            public string name
            {
                get
                {
                    return string.Format("{0} ({1} port {2})", this.process_name, this.protocol, this.port_number);
                }
                set { }
            }
            /// <summary>
            /// Variable qui contient le numéro du port 
            /// </summary>
            public string port_number { get; set; }
            /// <summary>
            /// Variable qui contient le nom du processus
            /// </summary>
            public string process_name { get; set; }
            /// <summary>
            /// Variable qui contient le protocole
            /// </summary>
            public string protocol { get; set; }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dataGridView1.Rows[e.RowIndex].Cells[0];

            if (chk.Value == chk.TrueValue)
            {
                dataGridView1.Rows[e.RowIndex].Cells[0].Value = chk.FalseValue;
            }
            else
            {
                dataGridView1.Rows[e.RowIndex].Cells[0].Value = chk.TrueValue;
            }
        }
        
        private void btn_FermerPort_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow d in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(d.Cells[ColumnCheckBox.Name].Value) == true)
                {
                    try
                    {
                        TcpClient server = new TcpClient("localhost", Convert.ToInt16(ListPort[d.Index].port_number));
                        NetworkStream stream = server.GetStream();
                        stream.Flush();
                        stream.Close();
                        server.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Une erreur s'est produite", "SBiiXpress - Erreur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
        }

        private void btn_Rafraichir_Click(object sender, EventArgs e)
        {
            btn_Analyse_Click(sender, e);
        }
    }
}
