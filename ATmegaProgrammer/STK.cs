using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ATmegaProgrammer
{
    //STK kind of protocol implementation, most of the commands are not implemented because they aren't required
    class STK
    {
        #region Vars
        static byte STK_OK = 0x10;
        static byte STK_INSYNC = 0x14;
        static byte STK_NOSYNC = 0x15;

        private static SerialPort _port;
        #endregion

        #region STK
        public static bool Poll()
        {
            SendText("0 ");

            bool hasSync = false;
            while (true)
            {
                byte r = ReadByte();
                if (r == STK_NOSYNC)
                {
                    break;
                }
                else if (r == STK_INSYNC)
                {
                    hasSync = true;
                }
                else if (r == STK_OK)
                {
                    return hasSync;
                }
            }

            return false;
        }

        public static string GetISPName()
        {
            SendText("1 ");

            if (ReadByte() == STK_INSYNC)
            {
                string name = Encoding.ASCII.GetString(ReadBytes(7));

                return (ReadByte() == STK_OK ? name : "*ERROR*");
            }
            else
            {
                return "*ERROR*";
            }
        }

        public static string GetISPVersion()
        {
            string verTxt = "";

            byte ver;
            if (!ReadSTKByte(out ver, 'A', 0x80))
                return "*ERROR*";
            verTxt += ver.ToString() + ".";

            if (!ReadSTKByte(out ver, 'A', 0x81))
                return "*ERROR*";
            verTxt += ver.ToString() + ".";

            if (!ReadSTKByte(out ver, 'A', 0x82))
                return "*ERROR*";
            verTxt += ver.ToString();

            if (!ReadSTKByte(out ver, 'A', 0x93))
                return "*ERROR*";
            verTxt += (ver == (byte)'S' ? " Serial" : " Parallel");

            return verTxt;
        }

        #endregion

        #region STK IO
        static bool ReadSTKByte(out byte b, char pre, byte data)
        {
            b = 0x0;

            SendChar(pre);
            SendByte(data);
            SendChar(' ');

            byte read = ReadByte();
            if (read == STK_INSYNC)
            {
                b = ReadByte();

                return (ReadByte() == STK_OK ? true : false);
            }

            return false;
        }
        #endregion

        #region COM I/O
        public static void Init(SerialPort serial)
        {
            _port = serial;
        }

        static byte ReadByte()
        {
            return (byte)_port.ReadByte();
        }

        static void SendText(string s)
        {
            _port.Write(s);
        }

        static byte[] ReadBytes(int l)
        {
            while (_port.BytesToRead < l)
                Thread.Yield();

            byte[] buf = new byte[l];

            _port.Read(buf, 0, l);

            return buf;
        }

        static void SendByte(byte b)
        {
            _port.Write(new byte[] { b }, 0, 1);
        }

        static void SendChar(char c)
        {
            _port.Write(new byte[] { (byte)c }, 0, 1);
        }
        #endregion
    }
}
