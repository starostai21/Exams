using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exams.Model
{
    [Serializable]
    public class Patient
    {
        public Patient() { }
        public string Name { get; set;}
        public int Age { get; set; }
        public DateTime ReceiptDate { get; set; }
        public double SumOfTreatment { get; set; }
        public string TreatmentType { get; set; }
    }
}
