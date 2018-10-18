using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessengerApp
{
    public partial class FormMessenger : Form
    {
        public string username { get; set; }

        NamedPipeClientStream pipe;
        StreamReader streamReader;
        StreamWriter streamWriter;

        public FormMessenger()
        {
            InitializeComponent();
        }

        // Upon load
        private void FormMessenger_Load(object sender, EventArgs e)
        {
            // New client pipe has name from username
            pipe = new NamedPipeClientStream
                (".", username, PipeDirection.InOut, PipeOptions.Asynchronous);

            // Connect to server
            pipe.Connect(500);
            streamReader = new StreamReader(pipe);
            streamWriter = new StreamWriter(pipe);

            MessageListener();
        }

        // Asynchronously detects if server sent a message
        private async Task MessageListener()
        {
            string message = await streamReader.ReadLineAsync();
            textBoxMessenger.AppendText(" " + DateTime.Now.ToShortTimeString() + "  |  " + message + "\r\n");

            // Run task again, loop forever
            MessageListener();
        }

        // Send message from button click
        private void buttonSend_Click(object sender, EventArgs e)
        {
            string message = textBoxMessage.Text;

            try
            {
                if (!string.IsNullOrEmpty(message))
                {
                    // Write message
                    streamWriter.WriteLine(message);
                    streamWriter.Flush();
                }
                else if (string.IsNullOrEmpty(message)) MessageBox.Show("Text field must not be empty");

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        // Exit
        private void buttonExit_Click(object sender, EventArgs e)
        {
            pipe.Close();
            Application.Exit();
        }
    }
}
