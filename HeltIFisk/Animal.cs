using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeltIFisk
{
    public class Animal
    {
        private string name;
        private string length;
        private string weight;

        public string Name { get { return name; }}
        public string Length { get { return length; }}
        public string Weight { get { return weight; }}

        public Animal(string aName, string aLength, string aWeight)
        {
            name = aName;
            length = aLength;
            weight = aWeight;
        }
    }
}
