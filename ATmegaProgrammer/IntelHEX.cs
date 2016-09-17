using System;
using System.Collections.Generic;
using System.IO;

namespace ATmegaProgrammer
{
    class IntelHEX
    {
        public enum RecordType : byte
        {
            Data = 0x0,
            EOF = 0x1,
            ExtendedAddressBase = 0x2,
            StartingSegmentAddress = 0x3,
            ExtendedLinearAddress = 0x4,
            LinearAddressBase = 0x5
        }

        public struct Record
        {
            public int ByteCount;
            public ushort Address;
            public RecordType Type;
            public byte[] Data;
            public byte Checksum;
        }

        private List<Record> _records;
        public List<Record> Records
        {
            get { return _records; }
        }

        public IntelHEX()
        {
            _records = new List<Record>();
        }

        public bool ParseFile(string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    int lineIDX = 0;
                    while(!sr.EndOfStream)
                    {
                        line = sr.ReadLine();
                        lineIDX++;
                        if (string.IsNullOrEmpty(line))
                            continue;
                        if(!line.StartsWith(":"))
                        {
                            throw new Exception("Invalid line at " + lineIDX.ToString());
                        }
                        else
                        {
                            byte[] linebytes = ConvertLine(line);

                            Record rec = new Record();

                            rec.ByteCount = linebytes[0];

                            byte[] addressBytes = new byte[2];
                            Array.Copy(linebytes, 1, addressBytes, 0, 2);
                            Array.Reverse(addressBytes);
                            rec.Address = BitConverter.ToUInt16(addressBytes, 0);

                            rec.Type = (RecordType)linebytes[3];

                            rec.Data = new byte[rec.ByteCount];
                            Array.Copy(linebytes, 4, rec.Data, 0, rec.ByteCount);

                            rec.Checksum = linebytes[linebytes.Length - 1];

                            //Validate checksum
                            if(rec.Type == RecordType.Data)
                            {
                                byte sum = 0;
                                for (int x = 0; x < linebytes.Length; x++)
                                    sum += linebytes[x];

                                if(sum != 0)
                                {
                                    throw new Exception("Invalid checksum at line " + lineIDX.ToString());
                                }
                            }

                            _records.Add(rec);
                        }
                    }
                }

                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Failed to read file: " + ex.Message);
            }

            return false;
        }

        private byte[] ConvertLine(string line)
        {
            byte[] data = new byte[(line.Length - 1) / 2];

            int dataIndex = 0;
            for(int x = 1;x<line.Length;x+=2)
            {
                string sub = line.Substring(x, 2);
                data[dataIndex] = Convert.ToByte(sub, 16);

                dataIndex++;
            }

            return data;
        }

        public int GetDataLength()
        {
            int addressStart = int.MaxValue;
            int addressEnd = 0;
            foreach (Record rec in _records)
            {
                if (rec.Type != RecordType.Data)
                    continue;

                if (rec.Address < addressStart)
                    addressStart = rec.Address;
                if (rec.Address + rec.ByteCount > addressEnd)
                    addressEnd = rec.Address + rec.ByteCount;
            }

            return (addressEnd - addressStart) / 2; //High + low bytes = 2 byte -> 1 word
        }

        public int GetDataStart()
        {
            int addressStart = int.MaxValue;
            foreach (Record rec in _records)
            {
                if (rec.Type != RecordType.Data)
                    continue;

                if (rec.Address < addressStart)
                    addressStart = rec.Address;
            }

            return addressStart;
        }

        public MemoryStream GetRawData()
        {
            MemoryStream ms = new MemoryStream();

            int addressStart = int.MaxValue;
            int addressEnd = 0;
            foreach(Record rec in _records)
            {
                if (rec.Type != RecordType.Data)
                    continue;

                if (rec.Address < addressStart)
                    addressStart = rec.Address;
                if (rec.Address + rec.ByteCount > addressEnd)
                    addressEnd = rec.Address + rec.ByteCount;
            }

            {
                byte[] fillBuffer = new byte[addressEnd - addressStart];
                ms.Write(fillBuffer, 0, fillBuffer.Length);
                ms.Position = 0;
            }

            foreach (Record rec in _records)
            {
                if (rec.Type != RecordType.Data)
                    continue;

                int relPosition = rec.Address - addressStart;

                ms.Position = relPosition;
                ms.Write(rec.Data, 0, rec.Data.Length);
            }

            ms.Position = 0;

            return ms;
        }
    }
}
