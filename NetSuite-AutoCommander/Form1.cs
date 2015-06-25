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
using NSClientCRM.com.netsuite.webservices;
using System.Web.Services.Protocols;
using Newtonsoft.Json.Linq;
using NetSuite_Commands.Contracts;
using NetSuite_DefaultImplementations;


namespace NetSuite_AutoCommander
{  
    public partial class FormMain : Form
    {
        //Lista codici Account NetSuite
        List<String> listAccount;
        //Lista Comandi letti da JSON
        List<ICommand> listCommand;
        //Servizio collegamento NetSuite
        NetSuiteService service;
        //Oggetto logging -> RichTextbox
        ILogger logger;

        //Variabile stato log in
        bool logged;

        public FormMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Lettura File di Testo contenente codici Account NetSuite
        /// </summary>
        private void readAccountFile()
        {
            if (System.IO.File.Exists("codAccount.txt") == true)
            {
                StreamReader sr = new StreamReader("codAccount.txt");
                String line;
                line = sr.ReadLine();
                int index = 0;
                while (line != null)   //al posto sr.endofstrem==true
                {
                    listAccount.Add(line);
                    line = sr.ReadLine();
                    index++;
                }
                sr.Close();
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //Disabilito comandi Programma se non Connesso
            DisableControls(this);            

            logged = false;

            //Nascondo lbl  
            lblStatusConnection.Text = "Non Connesso";

            //Istanza lista Account
            listAccount = new List<string>();

            //init logger proxy
            logger = new TextBoxLoggerProxy(rtbLogCommand);

            //Lettura File con Codici Account
            readAccountFile();

            //Caricamento Combobox con Codici Account NetSuite
            for (int i = 0; i < listAccount.Count; i++)
            {
                cmbAccount.Items.Add(listAccount[i]);
            }


            //Dati di test
            txtEmail.Text = "davide.diluccio@vallauri.edu";
            txtPassword.Text = "A12_ch3yuSD80";
            cmbAccount.SelectedIndex = 0;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            //Se non si è loggati si connette
            if (!logged)
            {
                if (cmbAccount.SelectedItem != null)
                {
                    //Messaggio Connessione
                    lblStatusConnection.Text = "Login in corso...";

                    //Istanza Servizio NetSuite
                    service = new NetSuiteService();

                    //Lettura Credenziali
                    string account = cmbAccount.SelectedItem.ToString();
                    string email = txtEmail.Text;
                    string password = txtPassword.Text;

                    //Ricerca Url WebService
                    DataCenterAwareNetSuiteService DataCenter_Url = new DataCenterAwareNetSuiteService(account);
                    service.Url = DataCenter_Url.Url;
                    service.AllowAutoRedirect = true;
                    service.CookieContainer = new System.Net.CookieContainer();

                    //Connessione
                    Passport passport = new Passport();
                    passport.account = account;
                    passport.email = email;
                    passport.password = password;
                    try
                    {
                        Status status = service.login(passport).status;

                        //Connessione Riuscita Con Successo
                        panelLogin.BackColor = Color.LightGreen;

                        logged = true;

                        lblStatusConnection.Text = "Connesso";

                        btnConnect.Text = "Disconnect";

                        //Abilito Comandi Programma
                        EnableControls(this);
                        btnStart.Enabled = false;
                    }
                    catch (SoapException ex)
                    {
                        panelLogin.BackColor = Color.Red;
                        lblStatusConnection.Text = "Connessione non riuscita! " + ex.Message;
                    }
                }
                else
                    MessageBox.Show("Seleziona l'Account !");
            }
            else
            {
                //Logout NetSuite
                service.logout();
                //Disabilito comandi Programma se non Connesso
                DisableControls(this);                

                logged = false;
                panelLogin.BackColor = Color.Transparent;

                btnConnect.Text = "Connect";
                lblStatusConnection.Text = "Non Connesso";
                txtEmail.Text = "";
                txtPassword.Text = "";
                cmbAccount.SelectedItem = null;
            }
            
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {      
            //Se si è loggati si slogga
            if (logged)
            {
                lblStatusConnection.Text = "Log out in corso....";
                //Logout NetSuite
                service.logout();
            }
            
        }

        /// <summary>
        /// Lettura File JSON con Comandi Eseguibili
        /// </summary>
        /// <param name="filename">Filename del file da leggere</param>
        private void leggiJSON(string filename)
        {
            listCommand = new List<ICommand>();
            ICommand c;

            StreamReader r = new StreamReader(filename);
            string sampleJson = r.ReadToEnd();
            //Trasformo il JSON in un oggetto
            JObject results = JObject.Parse(sampleJson);
            //Per ogni comando trovato nel file mi salvo il nome
            foreach (var result in results["cmd"])
            {
                string commandText = (string)result["command"];

                c = new DefaultCommand(commandText);

                MessageBox.Show(commandText);
                //Inserimento Comando all'interno della Lista Comandi
                listCommand.Add(c);

                listBoxCommands.Items.Add(c.Commandtext);
            }
        }

        /// <summary>
        /// Disabilita Controlli Programma se non Connesso
        /// </summary>
        /// <param name="con"></param>
        private void DisableControls(Control con)
        {
            foreach (Control c in con.Controls)
            {
                DisableControls(c);
            }
            con.Enabled = false;

            EnableControls(panelLogin);
        }

        /// <summary>
        /// Abilita Pannello Log-in
        /// </summary>
        /// <param name="con"></param>
        private void EnableControls(Control con)
        {
            if (con != null)
            {
                con.Enabled = true;
                this.Enabled = true;

                foreach (Control c in con.Controls)
                {
                    c.Enabled = true;
                }
            }

            statusBarConnection.Enabled = true;
        }

        private void btnLoadCommands_Click(object sender, EventArgs e)
        {
            //Proprietà OpenFileDialog 
            openFileDialog.InitialDirectory = Application.StartupPath;
            openFileDialog.Filter = "JSON Files|*.json;";
            openFileDialog.FileName = "JSONcommands.json";
            openFileDialog.ShowDialog();         
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            //Abilito btn per eseguire i comandi
            btnStart.Enabled = true;

            //Lettura file JSON con Comandi
            leggiJSON(openFileDialog.FileName);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (listBoxCommands.SelectedItem != null)
            {
                //Scrittura Comando nel RichTextBox
                listCommand[listBoxCommands.SelectedIndex].Execute(logger);
            }
            else
                MessageBox.Show("Seleziona un Comando!");
                
            
        }
    }
}
