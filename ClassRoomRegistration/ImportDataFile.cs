using System;
using System.Collections.Generic;
//ing System.Linq;
using System.Text;
using System.IO;

namespace ClassRoomRegistration
{
    public class Student
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Major { get; set; }
    }

    public class ImportDataFile
    {
        public string Year { get; set; }
        public string Term { get; set; }
        public string SubjectID { get; set; }
        public string SubjectName { get; set; }
        public string LectureID { get; set; }
        public string LabID { get; set; }
        public List<Student> Students { get; set; }

        public ImportDataFile(string file)
        {
            Students = new List<Student>();
            ParseCSVFile(file);
        }

        private void ParseCSVFile(string file)
        {
            string line;
            string[] cols;

            StreamReader sr = new StreamReader(file);
            
            // Flush
            line = sr.ReadLine();
            
            // Get year
            line = sr.ReadLine();
            cols = line.Split(',');
            Year = cols[0].Substring(cols[0].IndexOf("25"), 4);

            // Get term
            line = line.Replace("รายงานผลการลงทะเบียนประจำ", "");
            cols = line.Split(' ');
            Term = cols[0];
            
            // Get Subject code and Subject Name
            line = sr.ReadLine();
            cols = line.Split(',');

            bool bSubject = true;
            string[] words = cols[0].Split(' ');
            for(int i=0; i<words.Length; i++)
            {
                if (i == 0)
                {
                    continue;
                }

                if (i == 1)
                {
                    SubjectID = words[i];
                    continue;
                }

                if (words[i] == "จำนวน")
                {
                    bSubject = false;
                    continue;
                }

                if (words[i] == "หมู่บรรยาย")
                {
                    LectureID = words[i + 1];
                    continue;
                }

                if (words[i] == "หมู่ปฏิบัติ")
                {
                    LabID = words[i + 1];
                    continue;
                }

                if (bSubject == true)
                {
                    SubjectName += words[i] + " ";
                }
            }
            
            //// Get student
            line = sr.ReadLine();
            while (sr.EndOfStream == false)
            {
                line = sr.ReadLine();
                string[] cell = line.Split(',');
                string stdID = cell[1];
                string stdName = cell[2];
                string stdMajor = cell[3];
                stdName = stdName.Replace("นาย", "");
                stdName = stdName.Replace("นางสาว", "");
                Students.Add(new Student { ID = stdID, Name = stdName, Major = stdMajor });
            }

            sr.Close();
        }
    }
}
