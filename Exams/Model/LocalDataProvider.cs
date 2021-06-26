using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exams.Model
{
    public class LocalDataProvider : IDataProvider
    {
        public IEnumerable<Patient> GetPatients()
        {
            return new Patient[]{
            new Patient{Age=19,TreatmentType = "Стационарное", SumOfTreatment = 2154.6, Name="Евгений", ReceiptDate = new DateTime(2021,4,21)},
            new Patient{Age=23,TreatmentType = "Амбулаторное", SumOfTreatment = 3579.8, Name="Антонина", ReceiptDate = new DateTime(2021,2,11)},
            new Patient{Age=34,TreatmentType = "Амбулаторное", SumOfTreatment = 1291.17, Name="Григорий", ReceiptDate= new DateTime(2021,1,16) }
        };
        }
        public IEnumerable<PatientType> GetPatientTypes()
        {
            return new PatientType[] {
        new PatientType{ Title="Стационарное" },
        new PatientType{ Title="Амбулаторное" },
        };
        }
    }
}
