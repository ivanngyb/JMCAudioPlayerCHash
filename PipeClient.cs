using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32.SafeHandles;

namespace JMCAudioPlayer
{
    class PipeClient
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern SafeFileHandle CreateFile(
           String pipeName,
           uint dwDesiredAccess,
           uint dwShareMode,
           IntPtr lpSecurityAttributes,
           uint dwCreationDisposition,
           uint dwFlagsAndAttributes,
           IntPtr hTemplate);

        //Event handling for message receving and server disconnection
        public delegate void MessageReceivedHandler(byte[] message);

        public event MessageReceivedHandler MessageReceived;

        public delegate void ServerDisconnectedHandler();

        public event ServerDisconnectedHandler ServerDisconnected;

        const int BUFFER_SIZE = 4096;

        FileStream stream;
        SafeFileHandle handle;
        Thread readThread;

        public bool Connected { get; private set; }

        public string PipeName { get; private set; }

        public bool Connect(string pipename)
        {
            if (Connected)
                throw new Exception("Already connected to pipe server.");

            PipeName = "\\\\.\\pipe\\" + pipename;

            handle =
               CreateFile(
                  PipeName,
                  0xC0000000, // GENERIC_READ | GENERIC_WRITE = 0x80000000 | 0x40000000
                  0,
                  IntPtr.Zero,
                  3, // OPEN_EXISTING
                  0x40000000, // FILE_FLAG_OVERLAPPED
                  IntPtr.Zero);


            if (handle.IsInvalid)
            {
                return false;
            }

            Connected = true;

            //Start listening for messages
            readThread = new Thread(Read)
            {
                IsBackground = true
            };
            readThread.Start();
            return true;
        }

        public void Disconnect()
        {
            if (!Connected)
                return;

            // Disconnected from server
            Connected = false;
            PipeName = null;

            //Cleans up stream
            if (stream != null)
                stream.Close();
            handle.Close();

            stream = null;
            handle = null;
        }

        //Reading thread for awaiting messages
        void Read()
        {
            stream = new FileStream(handle, FileAccess.ReadWrite, BUFFER_SIZE, true);
            byte[] readBuffer = new byte[BUFFER_SIZE];

            while (true)
            {
                int bytesRead = 0;

                using (MemoryStream ms = new MemoryStream())
                {
                    try
                    {
                        // Read the stream size
                        int totalSize = stream.Read(readBuffer, 0, 4);

                        // If client has disconnected
                        if (totalSize == 0)
                            break;

                        totalSize = BitConverter.ToInt32(readBuffer, 0);

                        do
                        {
                            int numBytes = stream.Read(readBuffer, 0, Math.Min(totalSize - bytesRead, BUFFER_SIZE));

                            ms.Write(readBuffer, 0, numBytes);

                            bytesRead += numBytes;

                        } while (bytesRead < totalSize);

                    }
                    catch
                    {
                        break;
                    }

                    //Client disconnected
                    if (bytesRead == 0)
                        break;

                    //Firsts message received event
                    if (MessageReceived != null)
                        MessageReceived(ms.ToArray());
                }
            }


            if (Connected)
            {
                //Cleans up stream
                stream.Close();
                handle.Close();

                stream = null;
                handle = null;

                // Not connected anymore
                Connected = false;
                PipeName = null;

                if (ServerDisconnected != null)
                    ServerDisconnected();
            }
        }

        public bool SendMessage(byte[] message)
        {
            try
            {
                // write the entire stream length
                stream.Write(BitConverter.GetBytes(message.Length), 0, 4);

                stream.Write(message, 0, message.Length);
                stream.Flush();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
