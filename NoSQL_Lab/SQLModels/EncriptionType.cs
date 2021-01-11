using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoSQL_Lab
{
    class EncriptionType
    {
        public int Id { get; set; }
        public string EncryptionName { get; set; }

        public EncriptionType()
        {
        }

        public EncriptionType(int id, string name)
        {
            Id = id;
            EncryptionName = name;
        }

        public override string ToString()
        {
            return Id + "\t" + EncryptionName;
        }
    }
}
