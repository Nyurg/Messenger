using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessengerApp
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        // Login button
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;

            if (!string.IsNullOrEmpty(username))
            {
                try
                {
                    // Sends the username to the server
                    NamedPipeClientStream sendUsernamePipeClient = new NamedPipeClientStream
                        (".", "sendUsername", PipeDirection.Out, PipeOptions.Asynchronous);

                    sendUsernamePipeClient.Connect(7500);
                    StreamWriter writeUsername = new StreamWriter(sendUsernamePipeClient);
                    writeUsername.WriteLine(username);
                    writeUsername.Flush();
                    sendUsernamePipeClient.Close();

                    // Opens the main form and closes the login
                    FormMessenger formMessenger = new FormMessenger();
                    formMessenger.username = username;
                    formMessenger.Show();
                    this.Hide();
                }
                catch(Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
            else if (string.IsNullOrEmpty(username)) MessageBox.Show("Cannot enter empty username");
        }
    }
}
