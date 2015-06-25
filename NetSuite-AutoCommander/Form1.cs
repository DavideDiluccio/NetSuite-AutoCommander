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
        List<String> listAccount;
        NetSuiteService service;
        ILogger logger;
        List<ICommand> listCommand;

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
            lblError.Text = "";
            lblStatusConnection.Text = "Non Connesso";

            //Istanza lista Account
            listAccount = new List<string>();

            //init logger proxy
            logger = new TextBoxLoggerProxy(rtbLogCommand);

            //Lettura Account
            readAccountFile();

            //Caricamento Combobox
            for (int i = 0; i < listAccount.Count; i++)
            {
                cmbAccount.Items.Add(listAccount[i]);
            }

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            //Se non si è loggati si connette
            if (!logged)
            {
                //Messaggio Connessione
                lblError.Text = "";
                lblStatusConnection.Text = "Log-in in corso...";

                service = new NetSuiteService();

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
                    lblError.Text = "Errore Log In!";

                    lblStatusConnection.Text = "Connessione non riuscita! " + ex.Message;
                }
            }
            else
            {
                //Logout NetSuite
                service.logout();
                //Disabilito comandi Programma se non Connesso
                DisableControls(this);

                lblStatusConnection.Text = "Non Connesso";

                logged = false;
                panelLogin.BackColor = Color.Transparent;

                btnConnect.Text = "Connect";
                txtEmail.Text = "";
                txtPassword.Text = "";
                cmbAccount.SelectedItem = null;
            }
            
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {            
            if (logged)
            {
                lblStatusConnection.Text = "Log out in corso....";
                //Logout NetSuite
                service.logout();
            }
            
        }

        private void leggiJSON(string filename)
        {
            listCommand = new List<ICommand>();
            ICommand c;

            StreamReader r = new StreamReader(filename);
            string sampleJson = r.ReadToEnd();
            // Parse JSON into dynamic object, convenient!
            JObject results = JObject.Parse(sampleJson);

            // Process each employee
            foreach (var result in results["cmd"])
            {
                // this can be a string or null
                string commandText = (string)result["command"];

                c = new DefaultCommand(commandText);
                listCommand.Add(c);
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

            leggiJSON(openFileDialog.FileName);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <  listCommand.Count; i++)
            {
                //rtbLogCommand.Text += "" + listCommand[i].executeCommand() + "\n";
                //logger.Log(listCommand[i].executeCommand());
                listCommand[i].Execute(logger);
            }
        }
    }
}
