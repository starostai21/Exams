using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Exams.Model
{
    public class DataProvider : IDataProvider
    {
        private Patient[] ArrayOfPatient;
        public DataProvider(string fileName)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Patient[]));
            using (FileStream PatientsList = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                ArrayOfPatient = (Patient[])formatter.Deserialize(PatientsList);
            }
        }



        public IEnumerable<PatientType> GetPatientTypes()
        {
            return new PatientType[]
            {
                new PatientType { Title="Cтационарное"},
                new PatientType { Title="Амбулаторное"},
            };
        }

        public IEnumerable<Patient> GetPatients()
        {
            return ArrayOfPatient;
        }
    }
}
