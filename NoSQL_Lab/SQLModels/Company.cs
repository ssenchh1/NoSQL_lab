using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoSQL_Lab
{
    class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Company()
        {
        }

        public Company(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Company(object[] company)
        {
            Id = (int)company[0];
            Name = (string)company[1];
        }

        public override string ToString()
        {
            return Id + "\t" + Name;
        }
    }
}