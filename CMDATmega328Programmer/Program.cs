using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProgTest
{
    class Program
    {
        // STK Definitions
        static byte STK_OK = 0x10;
        static byte STK_INSYNC = 0x14;
        static byte STK_NOSYNC = 0x15;

        //Original fuses:
        //Fuse low: 0x62
        //Fuse high: 0xD9
        //Lock: 0xFF
        //Calibration: 0x97

        const int Atmega328_EEPROMSize = 1024;
        const int Atmega328_FlashSize = 1024 * 32;

        enum MemoryType : byte
        {
            EEPROM = (byte)'E',
            Flash = (byte)'F'
        }

        enum STKResult
        {
            OutOfSync,
            OK
        }

        struct STKVersion
        {
            public byte HWVER;
            public byte SWMAJ;
            public byte SWMIN;
            public bool IsSerial;
        }

        static SerialPort _port;

        static void Main(string[] args)
        {
            _port = new SerialPort("COM10", 9600);
            _port.Open();
            _port.DtrEnable = true;

            Console.WriteLine("Atmega328P-PU programmer v0.1");
            Console.WriteLine();

            STKResult res;
            res = STK_Signon(); //Poll the reader
            Console.WriteLine("Programmer poll: " + res.ToString());

            if (res == STKResult.OK)
            {
                string isp;
                res = STK_GetISPName(out isp);
                Console.WriteLine("ISP: \"" + isp + "\"");

                res = STK_StartProgramming();
                if (res == STKResult.OK)
                {
                    Console.WriteLine("Programmer mode stared.");

                    byte[] sig;
                    res = STK_ReadSignature(out sig);
                    Console.ForegroundColor = ((sig[0] == 0x1E && sig[1] == 0x95 && sig[2] == 0x0F) ? ConsoleColor.Green : ConsoleColor.Red);
                    Console.WriteLine("CPU signature: 0x" + sig[0].ToString("X2") + sig[1].ToString("X2") + sig[2].ToString("X2"));
                    Console.ForegroundColor = ConsoleColor.Gray;

                    while (!CMDMenu()) ;

                    Console.WriteLine();
                    res = STK_EndProgramming();
                    if (res == STKResult.OK)
                        Console.WriteLine("Programmer mode exited.");
                    else
                        Console.WriteLine("Failed to exit programmer mode.");
                }
                else
                {
                    Console.WriteLine("Failed to start programming mode.");
                }
            }

            _port.Close();

            Console.WriteLine("Press any key to exit the tool.");
            Console.ReadKey();
        }

        #region Command menu
        static bool CMDMenu()
        {
            Console.WriteLine("[poll] Poll programmer.");
            Console.WriteLine("[wf] Write fuses as \"Arduino Nano w/ ATmega328\".");
            Console.WriteLine("[rf] Read CPU fuses.");
            Console.WriteLine("[rs] Read CPU signature (Use to check if the CPU is responding).");
            Console.WriteLine("[edc] Dump EEPROM to console.");
            Console.WriteLine("[ewa] Write EEPROM address.");
            Console.WriteLine("[era] Read EEPROM address.");
            Console.WriteLine("[fra] Read program FLASH address.");
            Console.WriteLine("[cih] Check Intel HEX file.");
            Console.WriteLine("[flash] Write Intel HEX to program flash.");
            Console.WriteLine("[dfb] Dump bootloader section of flash.");
            Console.WriteLine("[er] Erase chip.");
            Console.WriteLine("[exit] Exit.");

            STKResult res;
            bool ok = false;
            do
            {
                Console.Write(">");
                string cmd = Console.ReadLine();
                Console.WriteLine();

                ok = true;
                switch (cmd)
                {
                    //Tools (fuses, etc)
                    #region Read fuses
                    case "rf":
                        {
                            byte fuseByte = STK_ReadFuseByte();
                            Console.WriteLine("Fuse byte: 0x" + fuseByte.ToString("X2"));

                            fuseByte = STK_ReadFuseHighByte();
                            Console.WriteLine("Fuse high byte: 0x" + fuseByte.ToString("X2"));

                            fuseByte = STK_ReadExtendedFuseBits();
                            Console.WriteLine("Fuse extended byte: 0x" + fuseByte.ToString("X2"));

                            fuseByte = STK_ReadLockBits();
                            Console.WriteLine("Lock bits: 0x" + fuseByte.ToString("X2"));

                            fuseByte = STK_ReadCalibrationByte();
                            Console.WriteLine("Calibration byte: 0x" + fuseByte.ToString("X2"));
                        }
                        break;
                    #endregion
                    #region Write fuses to "Ardunio nano \w Atmega328"
                    case "wf":
                        {
                            const byte FuseLowByte = 0xFF;
                            const byte FuseHighByte = 0xDA;
                            const byte ExtendedFuses = 0x05;

                            //Make sure
                            Console.WriteLine("Are you sure want to set the fuses? Type \"Yes\".");
                            Console.WriteLine("FuseLow: 0x" + FuseLowByte.ToString("X2") + ", FuseHigh: 0x" + FuseHighByte.ToString("X2") + ", Extended: 0x" + ExtendedFuses.ToString("X2"));
                            if (Console.ReadLine() == "Yes")
                            {
                                Console.Write("Writing low fuse bits... ");
                                res = STK_WriteFuseLowBits(FuseLowByte);
                                Console.WriteLine(res.ToString());

                                Console.Write("Writing high fuse bits... ");
                                res = STK_WriteFuseHighBits(FuseHighByte);
                                Console.WriteLine(res.ToString());

                                Console.Write("Writing extended fuse bits... ");
                                res = STK_WriteExtendedFuseBits(ExtendedFuses);
                                Console.WriteLine(res.ToString());

                                Console.WriteLine("Verifying fuses.");

                                byte fuse = STK_ReadFuseByte();
                                Console.Write("Fuse low bits: ");
                                Console.ForegroundColor = (FuseLowByte == fuse ? ConsoleColor.Green : ConsoleColor.Red);
                                Console.WriteLine(FuseLowByte == fuse ? "OK" : "Mismatch (0x" + fuse.ToString("X2") + " != 0x" + FuseLowByte.ToString("X2") + ")");
                                Console.ForegroundColor = ConsoleColor.Gray;

                                fuse = STK_ReadFuseHighByte();
                                Console.Write("Fuse high bits: ");
                                Console.ForegroundColor = (FuseHighByte == fuse ? ConsoleColor.Green : ConsoleColor.Red);
                                Console.WriteLine(FuseHighByte == fuse ? "OK" : "Mismatch (0x" + fuse.ToString("X2") + " != 0x" + FuseHighByte.ToString("X2") + ")");
                                Console.ForegroundColor = ConsoleColor.Gray;

                                fuse = STK_ReadExtendedFuseBits();
                                Console.Write("Fuse extended bits: ");
                                Console.ForegroundColor = (ExtendedFuses == fuse ? ConsoleColor.Green : ConsoleColor.Red);
                                Console.WriteLine(ExtendedFuses == fuse ? "OK" : "Mismatch (0x" + fuse.ToString("X2") + " != 0x" + ExtendedFuses.ToString("X2") + ")");
                                Console.ForegroundColor = ConsoleColor.Gray;

                                if (ExtendedFuses != fuse)
                                {
                                    Console.WriteLine("Extended fuse bits set the brown-out detection voltage, failure is not that big of a deal.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Did nothing.");
                            }
                        }
                        break;
                    #endregion
                    #region Read CPU signature
                    case "rs":
                        {
                            byte[] sig;
                            res = STK_ReadSignature(out sig);
                            Console.ForegroundColor = ((sig[0] == 0x1E && sig[1] == 0x95 && sig[2] == 0x0F) ? ConsoleColor.Green : ConsoleColor.Red);
                            Console.WriteLine("CPU signature: 0x" + sig[0].ToString("X2") + sig[1].ToString("X2") + sig[2].ToString("X2"));
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine("Atmega328P is  0x1E950F");
                        }
                        break;
                    #endregion
                    #region Poll
                    case "poll":
                        {
                            res = STK_Signon(); //Poll the reader
                            Console.Write("Programmer poll: ");
                            Console.ForegroundColor = (res == STKResult.OK ? ConsoleColor.Green : ConsoleColor.Red);
                            Console.WriteLine(res.ToString());
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        break;
                    #endregion
                    #region Erase chip
                    case "er":
                        {
                            Console.WriteLine("Are you sure want to erase the chip (EEPROM, Flash)? Type \"Yes\"");
                            if (Console.ReadLine() == "Yes")
                            {
                                Console.Write("Erasing chip... ");
                                res = STK_ChipErase();
                                Console.ForegroundColor = (res == STKResult.OK ? ConsoleColor.Green : ConsoleColor.Red);
                                Console.WriteLine((res == STKResult.OK) ? "OK" : "Failed");
                                Console.ForegroundColor = ConsoleColor.Gray;
                            }
                        }
                        break;
                    #endregion
                    #region Dump bootloader section
                    case "dfb":
                        {
                            int sizeInWords = 1024;
                            int sizeInBytes = sizeInWords * 2;
                            int start = 0x3C00;
                            int end = 0x3FFF;

                            using (FileStream bd = File.OpenWrite("bootloader_dump.bin"))
                            {
                                for (int x = start; x < end; x++)
                                {
                                    byte lo;
                                    byte hi;

                                    res = STK_ReadFlashLowByte(x, out lo);
                                    if (res != STKResult.OK)
                                    {
                                        Console.WriteLine("An error ocurred while reading!");
                                        break;
                                    }

                                    res = STK_ReadFlashHighByte(x, out hi);
                                    if (res != STKResult.OK)
                                    {
                                        Console.WriteLine("An error ocurred while reading!");
                                        break;
                                    }

                                    bd.WriteByte(lo);
                                    bd.WriteByte(hi);
                                }
                            }

                            Console.WriteLine("Done!");
                        }
                        break;
                    #endregion

                    //EEPROM
                    #region Dump eeprom to console
                    case "edc":
                        {
                            Console.Write("Reading EEPROM (0x" + Atmega328_EEPROMSize.ToString("X2") + " bytes)...");

                            byte[] eeprom;
                            res = STK_ReadEEPROM(out eeprom, Atmega328_EEPROMSize);

                            Console.ForegroundColor = (res == STKResult.OK ? ConsoleColor.Green : ConsoleColor.Red);
                            Console.WriteLine(res == STKResult.OK ? "OK" : "Error");
                            Console.ForegroundColor = ConsoleColor.Gray;

                            if (res == STKResult.OK)
                            {
                                Console.WriteLine("Dump:");
                                HexDump(eeprom);
                            }
                        }
                        break;
                    #endregion
                    #region Write EEPROM address
                    case "ewa":
                        {
                            Console.Write("Address? ");
                            int adr = ReadInt();
                            if (adr == -1 || adr < 0 || adr >= Atmega328_EEPROMSize)
                            {
                                Console.WriteLine("Invalid address!");
                            }
                            else
                            {
                                Console.Write("Data? ");
                                int data = ReadInt();
                                if (data == -1 || data < 0 || data > 255)
                                {
                                    Console.WriteLine("Invalid byte!");
                                }
                                else
                                {
                                    Console.WriteLine("Writing EEPROM at 0x" + adr.ToString("X2") + " to 0x" + data.ToString("X2") + "...");
                                    res = STK_WriteEEPROMByte((ushort)adr, (byte)data);
                                    Console.ForegroundColor = (res == STKResult.OK ? ConsoleColor.Green : ConsoleColor.Red);
                                    Console.WriteLine((res == STKResult.OK) ? "OK" : "Failed");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                }
                            }
                        }
                        break;
                    #endregion
                    #region Read EEPROM address
                    case "era":
                        {
                            Console.Write("Address? ");
                            int adr = ReadInt();
                            if (adr == -1 || adr < 0 || adr >= Atmega328_EEPROMSize)
                            {
                                Console.WriteLine("Invalid address!");
                            }
                            else
                            {
                                byte data;
                                res = STK_ReadEEPROMByte((ushort)adr, out data);
                                if (res == STKResult.OK)
                                {
                                    Console.WriteLine("EEPROM data at 0x" + adr.ToString("X2") + " = 0x" + data.ToString("X2"));
                                }
                                else
                                {
                                    Console.WriteLine("Failed to read eeprom!");
                                }
                            }
                        }
                        break;
                    #endregion

                    //Program flash
                    #region Read FLASH address
                    case "fra":
                        {
                            Console.Write("Address? ");
                            int adr = ReadInt();
                            if (adr == -1 || adr < 0 || adr >= Atmega328_FlashSize)
                            {
                                Console.WriteLine("Invalid address!");
                            }
                            else
                            {
                                byte dataHigh;
                                byte dataLow;
                                res = STK_ReadFlashHighByte((ushort)adr, out dataHigh);
                                if (res == STKResult.OK)
                                {
                                    res = STK_ReadFlashLowByte((ushort)adr, out dataLow);
                                    if (res == STKResult.OK)
                                    {
                                        Console.WriteLine("Program flash data at 0x" + adr.ToString("X2") + " = L: 0x" + dataLow.ToString("X2") + " H: 0x" + dataHigh.ToString("X2"));
                                    }
                                    else
                                    {
                                        Console.WriteLine("Failed to read flash!");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Failed to read flash!");
                                }
                            }
                        }
                        break;
                    #endregion
                    #region Write Intel HEX to Flash
                    case "flash":
                        {
                            Console.Write("File path? ");
                            string file = Console.ReadLine();

                            if (File.Exists(file))
                            {
                                IntelHEX ih = new IntelHEX();
                                if (ih.ParseFile(file))
                                {
                                    Console.WriteLine("File loaded OK!");
                                    Console.WriteLine("Record count: " + ih.Records.Count.ToString());
                                    Console.WriteLine("File seems valid!");

                                    Console.Write("Do you want to flash the code? Type \"Yes\" >");
                                    if (Console.ReadLine() == "Yes")
                                    {
                                        int pSize = ih.GetDataLength(); //Words
                                        int bootStart = 0x3C00; //Document page 277

                                        Console.WriteLine("Program size: 0x" + pSize.ToString("X2"));
                                        Console.WriteLine("Bootloader length: 0x" + pSize.ToString("X2") + " bytes");
                                        Console.WriteLine("Bootloader base address: 0x" + bootStart.ToString("X2"));

                                        int wordsPerPage = 64;

                                        int pages = (int)Math.Ceiling((float)pSize / wordsPerPage);
                                        Console.WriteLine("Pages to flash: " + pages.ToString());

                                        //int address = (int)bootStart;

                                        Console.WriteLine("Flashing...");

                                        for (int ri = 0; ri < ih.Records.Count; ri++)
                                        {
                                            IntelHEX.Record rec = ih.Records[ri];
                                            if (rec.Type != IntelHEX.RecordType.Data)
                                                continue;

                                            int pos = rec.Address / 2;
                                            int words = rec.ByteCount / 2;

                                            for (int x = 0; x < words; x++)
                                            {
                                                int adr = pos + x;

                                                byte[] buffer = new byte[2];
                                                buffer[0] = rec.Data[x * 2];
                                                buffer[1] = rec.Data[(x * 2) + 1];

                                                res = STK_LoadProgramLowByte(adr, buffer[0]);
                                                if (res != STKResult.OK)
                                                {
                                                    Console.WriteLine("An error ocurred while flashing!");
                                                    break;
                                                }

                                                res = STK_LoadProgramHighByte(adr, buffer[1]);
                                                if (res != STKResult.OK)
                                                {
                                                    Console.WriteLine("An error ocurred while flashing!");
                                                    break;
                                                }

                                                res = STK_WriteProgramMemoryPage(adr);
                                                if (res != STKResult.OK)
                                                {
                                                    Console.WriteLine("An error ocurred while flashing!");
                                                    break;
                                                }

                                                Thread.Sleep(5); //Wait a little

                                                //Verify
                                                byte lo;
                                                byte hi;

                                                res = STK_ReadFlashLowByte(adr, out lo);
                                                res = STK_ReadFlashHighByte(adr, out hi);

                                                if (lo != buffer[0] || hi != buffer[1])
                                                {
                                                    Console.WriteLine("Buffer error!");
                                                }

                                                Console.CursorLeft = 0;
                                                Console.Write("                          ");
                                                Console.CursorLeft = 0;
                                                Console.Write(ri.ToString() + "/" + ih.Records.Count.ToString());
                                            }
                                        }

                                        //using (MemoryStream code = ih.GetRawData())
                                        //{
                                        //    code.Position = 0;

                                        //    byte[] buffer = new byte[2];

                                        //    int words = 0;
                                        //    while(code.Position < code.Length)
                                        //    {
                                        //        int rd = code.Read(buffer, 0, buffer.Length);
                                        //        if(rd != 2)
                                        //        {
                                        //            Console.WriteLine("Buffer error");
                                        //        }

                                        //        res = STK_LoadProgramLowByte(address, buffer[0]);
                                        //        if (res != STKResult.OK)
                                        //        {
                                        //            Console.WriteLine("An error ocurred while flashing!");
                                        //            break;
                                        //        }

                                        //        res = STK_LoadProgramHighByte(address, buffer[1]);
                                        //        if (res != STKResult.OK)
                                        //        {
                                        //            Console.WriteLine("An error ocurred while flashing!");
                                        //            break;
                                        //        }

                                        //        res = STK_WriteProgramMemoryPage(address);
                                        //        if (res != STKResult.OK)
                                        //        {
                                        //            Console.WriteLine("An error ocurred while flashing!");
                                        //            break;
                                        //        }

                                        //        //Verify
                                        //        byte lo;
                                        //        byte hi;

                                        //        res = STK_ReadFlashLowByte(address, out lo);
                                        //        res = STK_ReadFlashHighByte(address, out hi);

                                        //        if(lo != buffer[0] || hi != buffer[1])
                                        //        {
                                        //            Console.WriteLine("Buffer error!");
                                        //        }

                                        //        address++;
                                        //        words++;

                                        //        Console.CursorLeft = 0;
                                        //        Console.Write("                          ");
                                        //        Console.CursorLeft = 0;
                                        //        Console.Write(code.Position.ToString("X2") + "/" + code.Length.ToString("X2"));
                                        //    }
                                        //}

                                        //byte[] mem;
                                        //using (MemoryStream code = ih.GetRawData())
                                        //{
                                        //    mem = code.ToArray();
                                        //    code.Position = 0;

                                        //    byte[] pageBuffer = new byte[wordsPerPage * 2]; //Each word is 2 bytes
                                        //    int readCount;

                                        //    int currentPage = 0;

                                        //    while ((readCount = code.Read(pageBuffer, 0, pageBuffer.Length)) > 0)
                                        //    {
                                        //        int words = readCount / 2;

                                        //        for (int x = 0; x < words; x++)
                                        //        {
                                        //            res = STK_LoadProgramLowByte(x, pageBuffer[x * 2]);
                                        //            if (res != STKResult.OK)
                                        //            {
                                        //                Console.WriteLine("An error ocurred while flashing!");
                                        //                break;
                                        //            }

                                        //            res = STK_LoadProgramHighByte(x, pageBuffer[(x * 2) + 1]);
                                        //            if (res != STKResult.OK)
                                        //            {
                                        //                Console.WriteLine("An error ocurred while flashing!");
                                        //                break;
                                        //            }
                                        //        }

                                        //        int pageAddress = (int)(address & 0xFFFFFFE0);

                                        //        res = STK_WriteProgramMemoryPage(pageAddress);
                                        //        if (res != STKResult.OK)
                                        //        {
                                        //            Console.WriteLine("An error ocurred while flashing!");
                                        //            break;
                                        //        }

                                        //        address += words;

                                        //        currentPage++;
                                        //        Console.WriteLine("Page written " + currentPage.ToString() + "/" + pages.ToString());
                                        //    }
                                        //}

                                        //Console.WriteLine("Verify...");
                                        //int pos = 0;
                                        //for (int x = bootStart; x < bootStart + (mem.Length / 2); x++)
                                        //{
                                        //    byte lo;
                                        //    byte hi;

                                        //    res = STK_ReadFlashLowByte(x, out lo);
                                        //    res = STK_ReadFlashHighByte(x, out hi);

                                        //    if(lo != mem[pos] || hi != mem[pos+1])
                                        //    {

                                        //    }
                                        //    pos += 2;
                                        //}
                                    }
                                    else
                                    {
                                        Console.WriteLine("Did nothing.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Failed to parse file!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Failed not found!");
                            }
                        }
                        break;
                    #endregion

                    //Intel HEX
                    #region Check Intel HEX
                    case "cih":
                        {
                            Console.Write("File path? ");
                            string path = Console.ReadLine();

                            if (File.Exists(path))
                            {
                                IntelHEX ih = new IntelHEX();
                                if (ih.ParseFile(path))
                                {
                                    Console.WriteLine("File loaded OK!");
                                    Console.WriteLine("Record count: " + ih.Records.Count.ToString());
                                    Console.WriteLine("Data start: 0x" + ih.GetDataStart().ToString("X2"));
                                    Console.WriteLine("Data length: 0x" + ih.GetDataLength().ToString("X2") + " words");
                                }
                                else
                                {
                                    Console.WriteLine("Failed to parse file!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("File not found! \"" + path + "\"");
                            }
                        }
                        break;
                    #endregion

                    case "e":
                    case "exit":
                    case "quit":
                        return true;
                    default:
                        ok = false;
                        break;
                }
            } while (!ok);

            Console.WriteLine();
            Console.WriteLine("Press any key to return to the menu.");
            Console.ReadKey();
            Console.Clear();

            return false;
        }
        #endregion

        #region Direct commands
        #region FLASH
        static STKResult STK_WriteProgramMemoryPage(int address)
        {
            int hi = (address >> 8) & 0xFF;
            int lo = address & 0xFF;

            byte temp;

            return STK_Universal(0x4C, (byte)hi, (byte)lo, 0x0, out temp);
        }

        static STKResult STK_LoadProgramLowByte(int address, byte lowByte)
        {
            int hi = (address >> 8) & 0xFF;
            int lo = address & 0xFF;

            byte temp;

            return STK_Universal(0x40, (byte)hi, (byte)lo, lowByte, out temp);
        }

        static STKResult STK_LoadProgramHighByte(int address, byte highByte)
        {
            int hi = (address >> 8) & 0xFF;
            int lo = address & 0xFF;

            byte temp;

            return STK_Universal(0x48, (byte)hi, (byte)lo, highByte, out temp);
        }

        static STKResult STK_ReadFlashHighByte(int address, out byte data)
        {
            int hi = (address >> 8) & 0xFF;
            int lo = address & 0xFF;

            return STK_Universal(0x28, (byte)hi, (byte)lo, 0x0, out data);
        }

        static STKResult STK_ReadFlashLowByte(int address, out byte data)
        {
            int hi = (address >> 8) & 0xFF;
            int lo = address & 0xFF;

            return STK_Universal(0x20, (byte)hi, (byte)lo, 0x0, out data);
        }
        #endregion

        #region EEPROM
        static STKResult STK_WriteEEPROMByte(ushort address, byte data)
        {
            byte tmp;

            int hi = (address >> 8) & 0xFF;
            int lo = address & 0xFF;

            return STK_Universal(0xC0, (byte)hi, (byte)lo, data, out tmp);
        }

        static STKResult STK_ReadEEPROMByte(ushort address, out byte data)
        {
            int hi = (address >> 8) & 0xFF;
            int lo = address & 0xFF;

            return STK_Universal(0xA0, (byte)hi, (byte)lo, 0x0, out data);
        }
        #endregion

        #region Write fuses
        static STKResult STK_WriteFuseLowBits(byte fuse)
        {
            byte temp;

            return STK_Universal(0xAC, 0xA0, 0x00, fuse, out temp);
        }

        static STKResult STK_WriteFuseHighBits(byte fuse)
        {
            byte temp;

            return STK_Universal(0xAC, 0xA8, 0x00, fuse, out temp);
        }

        static STKResult STK_WriteExtendedFuseBits(byte fuse)
        {
            byte temp;

            return STK_Universal(0xAC, 0xA4, 0x00, fuse, out temp);
        }
        #endregion

        #region Read fuses
        static byte STK_ReadCalibrationByte()
        {
            byte res;

            STK_Universal(0x38, 0x00, 0x00, 0x00, out res);

            return res;
        }

        static byte STK_ReadLockBits()
        {
            byte res;

            STK_Universal(0x58, 0x00, 0x00, 0x00, out res);

            return res;
        }

        static byte STK_ReadExtendedFuseBits()
        {
            byte res;

            STK_Universal(0x50, 0x08, 0x00, 0x00, out res);

            return res;
        }

        static byte STK_ReadFuseHighByte()
        {
            byte res;

            STK_Universal(0x58, 0x08, 0x00, 0x00, out res);

            return res;
        }

        static byte STK_ReadFuseByte()
        {
            byte res;

            STK_Universal(0x50, 0x00, 0x00, 0x00, out res);

            return res;
        }
        #endregion

        #region Misc (ChipErase)
        static STKResult STK_ChipErase()
        {
            byte n;

            return STK_Universal(0xAC, 0x80, 0x00, 0x00, out n); 
        }
        #endregion

        #region STK universal
        static STKResult STK_Universal(byte a1, byte a2, byte a3, byte a4, out byte result)
        {
            result = 0x0;

            SendChar('V');
            SendBytes(new byte[] { a1, a2, a3, a4 });
            SendChar(' ');

            byte rd = ReadByte();
            if(rd == STK_INSYNC)
            {
                result = ReadByte();

                rd = ReadByte();

                return (rd == STK_OK ? STKResult.OK : STKResult.OutOfSync);
            }

            return STKResult.OutOfSync;
        }
        #endregion
        #endregion

        #region STK programmer based commands
        static STKResult STK_ReadEEPROM(out byte[] data, int length)
        {
            data = new byte[length];

            SendByte(0x74);

            byte[] l = BitConverter.GetBytes((ushort)length);
            SendByte(l[1]);
            SendByte(l[0]);

            SendByte((byte)MemoryType.EEPROM);

            SendChar(' ');

            byte read = ReadByte();
            if(read == STK_INSYNC)
            {
                for(int x = 0;x<length;x++)
                {
                    data[x] = ReadByte();
                }

                read = ReadByte();

                return (read == STK_OK ? STKResult.OK : STKResult.OutOfSync);
            }

            return STKResult.OutOfSync;
        }

        static STKResult STK_SetParameters(byte deviceCode, byte revision, byte progtype, byte parmode, byte polling, byte selftimed, byte lockbytes, byte fusebytes, byte flashpoll, ushort eeprompoll, ushort pagesize, ushort eepromsize, uint flashsize)
        {
            SendChar('B');

            SendByte(deviceCode); //0
            SendByte(revision); //1
            SendByte(progtype); //2
            SendByte(parmode); //3
            SendByte(polling); //4
            SendByte(selftimed); //5
            SendByte(lockbytes); //6
            SendByte(fusebytes); //7
            SendByte(flashpoll); //8

            SendByte(0x0); //UWOT //9

            SendReversedBytes(BitConverter.GetBytes(eeprompoll)); //10-11
            SendReversedBytes(BitConverter.GetBytes(pagesize)); //12-13
            SendReversedBytes(BitConverter.GetBytes(eepromsize)); //14-15

            SendReversedBytes(BitConverter.GetBytes(flashsize)); //16-17-18-19

            SendChar(' ');

            byte b = ReadByte();
            if(b == STK_INSYNC)
            {
                return (ReadByte() == STK_OK ? STKResult.OK : STKResult.OutOfSync);
            }

            return STKResult.OutOfSync;
        }

        static STKResult STK_WriteEEPROM(byte[] data)
        {
            if(_port.BytesToRead > 0)
            {
                //WAT
            }

            SendByte(0x64);

            SendByte((byte)(data.Length / 256));
            SendByte((byte)(data.Length % 256));

            SendByte((byte)MemoryType.EEPROM);

            _port.Write(data, 0, data.Length);

            byte[] bs = new byte[_port.BytesToRead];
            _port.Read(bs, 0, bs.Length);
            string str = Encoding.UTF8.GetString(bs);

            SendChar(' ');

            byte b = ReadByte();
            if (b == STK_INSYNC)
            {
                byte result = ReadByte();

                return (result == STK_OK ? STKResult.OK : STKResult.OutOfSync);
            }

            return STKResult.OutOfSync;
        }

        /// <summary>
        /// EEPROM
        /// </summary>
        static STKResult STK_SetProgData(byte data)
        {
            SendByte(0x61);
            SendByte(data);
            SendChar(' ');

            return ((ReadByte() == STK_INSYNC && ReadByte() == STK_OK) ? STKResult.OK : STKResult.OutOfSync);
        }

        static STKResult STK_SetAddress(ushort addr)
        {
            SendChar('U');

            SendByte((byte)(addr % 256));
            SendByte((byte)(addr / 256));

            SendChar(' ');

            byte read = ReadByte();
            if(read == STK_INSYNC)
            {
                read = ReadByte();
                return (read == STK_OK ? STKResult.OK : STKResult.OutOfSync);
            }

            return STKResult.OutOfSync;
        }

        static STKResult STK_StartProgramming()
        {
            SendText("P ");

            return ((ReadByte() == STK_INSYNC && ReadByte() == STK_OK) ? STKResult.OK : STKResult.OutOfSync);
        }

        static STKResult STK_EndProgramming()
        {
            SendText("Q ");

            return ((ReadByte() == STK_INSYNC && ReadByte() == STK_OK) ? STKResult.OK : STKResult.OutOfSync);
        }

        static STKResult STK_ReadSignature(out byte[] sig)
        {
            sig = new byte[3];

            STKResult res = STK_Universal(0x30, 0x00, 0x00, 0x00, out sig[0]);
            if (res != STKResult.OK)
                return STKResult.OutOfSync;

            res = STK_Universal(0x30, 0x00, 0x01, 0x00, out sig[1]);
            if (res != STKResult.OK)
                return STKResult.OutOfSync;

            res = STK_Universal(0x30, 0x00, 0x02, 0x00, out sig[2]);
            if (res != STKResult.OK)
                return STKResult.OutOfSync;

            return res;
        }

        static STKResult STK_GetProgrammerVersion(out STKVersion ver)
        {
            ver = new STKVersion();

            if (ReadSTKByte(out ver.HWVER, 'A', 0x80) == STKResult.OutOfSync)
                return STKResult.OutOfSync;
            if (ReadSTKByte(out ver.SWMAJ, 'A', 0x81) == STKResult.OutOfSync)
                return STKResult.OutOfSync;
            if (ReadSTKByte(out ver.SWMIN, 'A', 0x82) == STKResult.OutOfSync)
                return STKResult.OutOfSync;

            byte br = 0;
            if (ReadSTKByte(out br, 'A', 0x93) == STKResult.OutOfSync)
                return STKResult.OutOfSync;

            ver.IsSerial = (br == (byte)'S');

            return STKResult.OK;
        }

        static STKResult STK_GetISPName(out string ispName)
        {
            SendText("1 ");

            ispName = string.Empty;

            byte b1 = ReadByte();
            if (b1 == STK_INSYNC)
            {
                ispName = Encoding.ASCII.GetString(ReadBytes(7));

                b1 = ReadByte();

                return (b1 == STK_OK ? STKResult.OK : STKResult.OutOfSync);
            }
            else
            {
                return STKResult.OutOfSync;
            }
        }

        static STKResult STK_Signon()
        {
            SendText("0 ");

            STKResult res = STKResult.OutOfSync;
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
                    res = (hasSync ? STKResult.OK : STKResult.OutOfSync);

                    break;
                }
            }

            return res;
        }
        
        static STKResult ReadSTKByte(out byte b, char pre, byte data)
        {
            b = 0x0;

            SendChar(pre);
            SendByte(data);
            SendChar(' ');

            byte read = ReadByte();
            if(read == STK_INSYNC)
            {
                b = ReadByte();

                return (ReadByte() == STK_OK ? STKResult.OK : STKResult.OutOfSync);
            }

            return STKResult.OutOfSync;
        }
        #endregion

        #region COM I/O
        static byte ReadByte()
        {
            return (byte)_port.ReadByte();
        }

        static byte[] ReadBytes(int l)
        {
            while (_port.BytesToRead < l)
                Thread.Yield();

            byte[] buf = new byte[l];

            _port.Read(buf, 0, l);

            return buf;
        }

        static void SendText(string s)
        {
            _port.Write(s);
        }

        static void SendReversedBytes(byte[] b)
        {
            Array.Reverse(b);

            _port.Write(b, 0, b.Length);
        }

        static void SendBytes(byte[] b)
        {
            _port.Write(b, 0, b.Length);
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

        #region Tools
        static int ReadInt()
        {
            int i;
            if (Int32.TryParse(Console.ReadLine(), out i))
                return i;

            return -1;
        }

        static void HexDump(byte[] data)
        {
            int line = 0;
            string lineStr = "";
            for(int x = 0; x < data.Length; x++)
            {
                Console.Write(data[x].ToString("X2") + " ");

                char chr = (char)data[x];
                if ((char.IsDigit(chr) || char.IsLetter(chr)) && (byte)chr <= 128)
                    lineStr += chr;
                else
                    lineStr += ".";

                line++;
                if (line == 8)
                    Console.Write(" ");
                if(line == 16)
                {
                    line = 0;
                    Console.WriteLine(" " + lineStr);
                    lineStr = "";
                }
            }
        }
        #endregion
    }
}
