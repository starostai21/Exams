using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exams.Model
{
    interface IDataProvider
    {
        IEnumerable<Patient> GetPatients();
        IEnumerable<PatientType> GetPatientTypes();
    }
}
