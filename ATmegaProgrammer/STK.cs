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

        public static bool EnterProgramming()
        {
            SendText("P ");

            return ((ReadByte() == STK_INSYNC && ReadByte() == STK_OK));
        }

        public static bool EndProgramming()
        {
            SendText("Q ");

            return ((ReadByte() == STK_INSYNC && ReadByte() == STK_OK));
        }

        public static bool IsReady()
        {
            return (STK_Universal(0xF0, 0x00, 0x00, 0x00) == 254);
        }

        public static byte[] ReadSignature()
        {
            byte[] sig = new byte[3];

            sig[0] = STK_Universal(0x30, 0x00, 0x00, 0x00);
            sig[1] = STK_Universal(0x30, 0x00, 0x01, 0x00);
            sig[2] = STK_Universal(0x30, 0x00, 0x02, 0x00);

            return sig;
        }

        public static byte ReadLockBits()
        {
            return STK_Universal(0x58, 0x00, 0x00, 0x00);
        }

        public static byte ReadExtendedFuseBits()
        {
            return STK_Universal(0x50, 0x08, 0x00, 0x00);
        }

        public static byte ReadFuseBitsHigh()
        {
            return STK_Universal(0x58, 0x08, 0x00, 0x00);
        }

        public static byte ReadFuseBitsLow()
        {
            return STK_Universal(0x50, 0x00, 0x00, 0x00);
        }

        public static bool WriteFuseLowBits(byte fuse)
        {
            return (STK_Universal(0xAC, 0xA0, 0x00, fuse) == 0x0);
        }

        public static bool WriteFuseHighBits(byte fuse)
        {
            return (STK_Universal(0xAC, 0xA8, 0x00, fuse) == 0x0);
        }

        public static bool WriteExtendedFuseBits(byte fuse)
        {
            return (STK_Universal(0xAC, 0xA4, 0x00, fuse) == 0x0);
        }

        public static bool ChipErase()
        {
            return (STK_Universal(0xAC, 0x80, 0x00, 0x00) == 0x0);
        }

        public static bool WriteProgramMemoryPage(int address)
        {
            int hi = (address >> 8) & 0xFF;
            int lo = address & 0xFF;

            return (STK_Universal(0x4C, (byte)hi, (byte)lo, 0x0) == lo);
        }

        public static bool LoadProgramLowByte(int address, byte lowByte)
        {
            int hi = (address >> 8) & 0xFF;
            int lo = address & 0xFF;

            return (STK_Universal(0x40, (byte)hi, (byte)lo, lowByte) == lo);
        }

        public static bool LoadProgramHighByte(int address, byte highByte)
        {
            int hi = (address >> 8) & 0xFF;
            int lo = address & 0xFF;

            return (STK_Universal(0x48, (byte)hi, (byte)lo, highByte) == lo);
        }

        public static byte ReadFlashHighByte(int address)
        {
            int hi = (address >> 8) & 0xFF;
            int lo = address & 0xFF;

            return STK_Universal(0x28, (byte)hi, (byte)lo, 0x0);
        }

        public static byte ReadFlashLowByte(int address)
        {
            int hi = (address >> 8) & 0xFF;
            int lo = address & 0xFF;

            return STK_Universal(0x20, (byte)hi, (byte)lo, 0x0);
        }
        #endregion

        #region STK IO
        static byte STK_Universal(byte a1, byte a2, byte a3, byte a4)
        {
            byte result = 0x0;

            SendChar('V');
            SendBytes(new byte[] { a1, a2, a3, a4 });
            SendChar(' ');

            byte rd = ReadByte();
            if (rd == STK_INSYNC)
            {
                result = ReadByte();

                rd = ReadByte();

                return (rd == STK_OK ? result : (byte)0);
            }

            return result;
        }

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

        static void SendBytes(byte[] b)
        {
            _port.Write(b, 0, b.Length);
        }
        #endregion
    }
}
