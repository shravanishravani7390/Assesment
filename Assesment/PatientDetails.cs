using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFrameWork.Assesment
{

    class Patient
    {
        public int id { get; set; }
        public String name { get; set; }
        

    }

    class Diease
    {
        public int id { get; set; }
        public String  PatientName { get; set; }

        public String diease { get; set; }
        public String severity { get; set; }
        public string  symptom { get; set; }

        public String discription { get; set; }
       
    }

    class RepoDiease
    {
        private Diease[] _dieases = null;
        private int size = 0;
        public RepoDiease(int size)
        {
            this.size = size;
            _dieases = new Diease[this.size];
        }

        public void AddDieases(Diease diease)
        {
            for (int i = 0; i < this.size; i++)
            {
                _dieases[i] = new Diease { id = diease.id, PatientName = diease.PatientName };
                return;

            }
        }
        public void AddSymptoms(Diease diease)
        {
            for (int i = 0; i <this.size; i++)
            {
                _dieases[i] = new Diease { id = diease.id, PatientName = diease.PatientName };
                return;

            }
        }
        public void CheckPatient(int patientId)
        {
            for (int i = 0; i <this.size; i++)
            {
                if(_dieases[i] != null && _dieases[i].id == patientId)
                {
                    _dieases[i] = null;
                    return;
                 

                }
            }
            throw new Exception("no patients to check");
        }

        class MedicalRecords
        {
            public static RepoDiease repo = null;
            internal static  void DisplayMenu(string file)
            {
                int size = Utilities.GetNumber("enter size");
                repo = new RepoDiease(size);
                bool processing = true;
                string menu = File.ReadAllText(file);
                do
                {
                    int choice = Utilities.GetNumber(menu);
                    processing = PatientList(choice);
                } while (processing);
            }

            private static bool PatientList(int choice)
            {
                switch (choice)
                {
                    case 1:
                        addingDieases();
                        break;
                    case 2:
                        addingSymptomps();
                        break;
                    case 3:
                        checkingPatients();
                        break;
                    case 4:
                        throw new Exception("All are Healthy");
                    default:
                        return false;
                }
                return true;
                
            }

            private static void addingDieases()
            {
                int id = Utilities.GetNumber("enter Id of the patient to add dieases");
                string name = Utilities.Prompt("Enter the Name of the Patient");
                Diease diease = new Diease { id = id, PatientName = name };
                repo.AddDieases(diease);
                Utilities.Prompt("press enter to clear the screen");
                Console.Clear();
            }

            private static void addingSymptomps()
            {
                int id = Utilities.GetNumber("enter Id of the patient to add dieases");
                string name = Utilities.Prompt("Enter the Name of the Patient");
                Diease diease = new Diease { id = id, PatientName = name };
                repo.AddSymptoms(diease);
                Utilities.Prompt("press enter to clear the screen");
                Console.Clear();
            }
            private static void  checkingPatients()
            {
                int PatientId = Utilities.GetNumber("Enter the ID of the patient to check ");
                try
                {
                    Diease diease = repo.CheckPatient(PatientId);
                    Console.WriteLine("The Details of the patient  are as follows:");
                    string content = $"The Name: {diease.PatientName}\n Patient Diease: {diease.diease}\n Sympotom :{diease.symptom}\n discription : {diease.diease}\nSeverity : {diease.severity}\n";
                    Console.WriteLine(content);
                    Utilities.Prompt("Press Enter to clear the Screen");
                    Console.Clear();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }

     

        class MainClass
        {
            static void Main(string[] args)
            {
                Patient patient = new Patient { id = 1, name = "xyz" };
            }
        }

    }

    internal class Utilities
    {
        internal static int GetNumber(string v)
        {
            throw new NotImplementedException();
        }

        internal static string Prompt(string v)
        {
            throw new NotImplementedException();
        }
    }
}
