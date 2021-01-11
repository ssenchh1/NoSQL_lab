using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoSQL_Lab
{
    class Router
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public int CompanyName { get; set; }
        public int AntennaAmount { get; set; }
        public string MAC_Adress { get; set; }
        public int ManufacturerCountry { get; set; }
        public int EncryptionType { get; set; }

        public Router(string name, int compname, int antennas, string mac, int manufacturercountry, int encryption)
        {
            Name = name;
            CompanyName = compname;
            AntennaAmount = antennas;
            MAC_Adress = mac;
            ManufacturerCountry = manufacturercountry;
            EncryptionType = encryption;
        }

        public Router(uint id, string name, int compname, int antennas, string mac, int manufacturercountry, int encryption)
        {
            Id = id;
            Name = name;
            CompanyName = compname;
            AntennaAmount = antennas;
            MAC_Adress = mac;
            ManufacturerCountry = manufacturercountry;
            EncryptionType = encryption;
        }


        public override string ToString()
        {
            return $"Router info: Id: {Id},\n name: {Name},\n company: {CompanyName},\n antennas: {AntennaAmount},\n MAC: {MAC_Adress},\n enryption: {EncryptionType},\n made in {ManufacturerCountry}";
        }

    }
}
