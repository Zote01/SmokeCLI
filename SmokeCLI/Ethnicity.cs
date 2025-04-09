using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmokeCLI
{
    internal class Ethnicity
    {
        public Ethnicity(int ethniID, string ethniName)
        {
            EthniID = ethniID;
            EthniName = ethniName;
        }

        public int EthniID { get; set; }
        public string EthniName { get; set; }
    }
}
