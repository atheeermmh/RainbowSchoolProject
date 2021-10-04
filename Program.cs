using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Rainbow
{

    class teacher
    {
        public int id { get; set; }
        public string name { get; set; }
        public int class1 { get; set; }
        public string section { get; set; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            

            char ch = ' '; //for stop enter datax
            int num = 0;   //for selction switch


            List<teacher> listofteacher = new List<teacher>();

            Console.WriteLine("Welcom in Rainbow school");
            Console.WriteLine("-------------------------------------------------");
            
            do {
               
                Console.Write("Please select what you want\n1-Store Data \n2-Retrieve Data \n3-Updat Data\nEnter the number: ");
                num = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("-------------------------------------------------");


                switch (num) {

                case 1:  //store teacher data
                    do
                    {

                        Console.Write("Enter your ID number: ");
                        int id1 = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter your name: ");
                        string name1 = Console.ReadLine();

                        Console.Write("Enter your class number: ");

                        int class2 = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter your section name: ");
                        string section1 = Console.ReadLine();

                        Console.Write("You want add other teacher. Enter [y/n]: ");
                        ch = Convert.ToChar(Console.ReadLine());

                        // Add data to the list.
                        listofteacher.Add(new teacher { id = id1, name = name1, class1 = class2, section = section1 });

                    } while (ch != 'n');

                    // Add data to the text file.
                    using (var writData = new StreamWriter(@"teacherdata.txt"))
                    {
                        foreach (var items in listofteacher)
                        {
                            writData.WriteLine($"ID: {items.id} , Name: {items.name} , Class number: {items.class1} , Section name: {items.section}");

                        }
                    }
                    break;

                case 2:  //Retrieve teacher data

                        var filepath = @"teacherdata.txt";
                        string[] teacherData = File.ReadAllLines(filepath);
                        foreach (string retrieveData in teacherData)
                        {
                            Console.WriteLine(retrieveData);
                        }
                        break;

                case 3: //update teacher data

          
                        Console.Write("Plese enter ID whos want update it: ");
                        string updateID = Convert.ToString(Console.ReadLine());

                        Console.WriteLine("What is the data you want update : name , class or section");
                        string update = Console.ReadLine();


                        if (update == "name")
                        {
                            Console.Write("Please enter old name: ");
                            string oldName = Console.ReadLine();

                            Console.Write("Enter the new name: ");
                            string newName = Console.ReadLine();

                            var filepath_1 = @"teacherdata.txt";
                            string[] rows = File.ReadAllLines(filepath_1);

                            for (int i = 0; i < rows.Length; i++)
                            {
                                if (rows[i].Contains(updateID))
                                {
                                    rows[i] = rows[i].Replace(oldName, newName);

                                }

                                File.WriteAllText(@"teacherdata.txt", rows[i]);
                            }

                        }
                        else if (update == "class")
                        {
                            Console.Write("Please enter old class number: ");
                            string oldClass = Convert.ToString(Console.ReadLine());

                            Console.Write("Enter the new class number: ");
                            string newClass = Convert.ToString(Console.ReadLine());

                            var filepath_1 = @"teacherdata.txt";
                            string[] rows = File.ReadAllLines(filepath_1);

                            for (int i = 0; i < rows.Length; i++)
                            {
                                if (rows[i].Contains(updateID))
                                {
                                    rows[i] = rows[i].Replace(oldClass, newClass);

                                }
                                File.WriteAllText(@"teacherdata.txt", rows[i]);
                            }

                        }
                        else if (update == "section")
                        {
                            Console.Write("Please enter old section name: ");
                            string oldSection = Console.ReadLine();

                            Console.Write("Enter the new section name: ");
                            string newSection = Console.ReadLine();

                            var filepath_1 = @"teacherdata.txt";
                            string[] rows = File.ReadAllLines(filepath_1);

                            for (int i = 0; i < rows.Length; i++)
                            {
                                if (rows[i].Contains(updateID))
                                {
                                    rows[i] = rows[i].Replace(oldSection, newSection);

                                }
                               
                                File.WriteAllText(@"teacherdata.txt", rows[i]);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Unfortunately, the search dose not match.");
                        }

                        break;

                    default:
                        Console.WriteLine("Error choese");
                    break;
                }

                Console.Write("Do you want to continue. Enter[y/n]: ");
                ch = Convert.ToChar(Console.ReadLine());

            } while (ch != 'n');

        }
    }
}
