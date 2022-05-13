using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    internal class StudentData
    {
        
        private static List<Student> _testStudents = new List<Student>();
        public static List<Student> TestStudents
        {
            get {
                if(_testStudents.Count == 0 )
                studentsData();
                    return _testStudents; }
            set { }
        }

        public static void studentsData()
        {
            _testStudents.Add(new Student());
            _testStudents[0].firstName = "Vladimir";
            _testStudents[0].middleName = "Ivov";
            _testStudents[0].lastName = "Kanin";
            _testStudents[0].faculty = "FCST";
            _testStudents[0].speciality = "KSI";
            _testStudents[0].degree = "Bachelor's";
            _testStudents[0].status = "alive";
            _testStudents[0].facultyNumber = "121219005";
            _testStudents[0].course = 3;
            _testStudents[0].stream = 1;
            _testStudents[0].group = 30;

            _testStudents.Add(new Student());
            _testStudents[1].firstName = "Ivan";
            _testStudents[1].middleName = "Ivanonv";
            _testStudents[1].lastName = "Petrov";
            _testStudents[1].faculty = "FCST";
            _testStudents[1].speciality = "KSI";
            _testStudents[1].degree = "Master's";
            _testStudents[1].status = "alive";
            _testStudents[1].facultyNumber = "121219006";
            _testStudents[1].course = 3;
            _testStudents[1].stream = 1;
            _testStudents[1].group = 30;

        }
    }
}
