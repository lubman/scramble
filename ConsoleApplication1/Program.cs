using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace ImportFile
{
    class Program
    {


        public const int Cellline = 3;
        public const int Compound = 19;
        public const int ShortCompoundID = 20;
        public const int LNumberOnly = 21;

        static void Main(string[] args)
        {
            

     
            
            
            //FileStream fileStream = new FileStream(@"C:\Users\lubman\Documents\HC Profiler\GFP_PivotTable.txt", FileMode.Open);
            try
            {
                Console.WriteLine("Would you like to go forward? (Y/N)");
                if ((Console.Read() == 'y') || (Console.Read() == 'Y'))
                    ReadTextFile();
                
                // read from file or write to file
            }
            finally
            {
                //fileStream.Close();
            }

        }

      

             public static void ReadTextFile()
                {
                    String line, newline;
                    int iCellline = 0, iCompound = 0, iShortCompoundID = 0, iLNumberOnly = 0, iRowNum = 0;
                    Dictionary<string,string> Previous = new Dictionary<string,string>();
                    Dictionary<string, string> Scrambles = new Dictionary<string, string>();

                    try
                    {
                        // Process the file.
                        StreamWriter new_file = new StreamWriter(@"C:\Users\lubman\Documents\HC Profiler\GFP_PivotTable2.txt");
                        using (StreamReader file = new StreamReader(@"C:\Users\lubman\Documents\HC Profiler\GFP_PivotTable.txt"))
                        {
                            while ((line = file.ReadLine()) != null)
                            {


                                char[] delimiters = new char[] { '\t' };
                                string[] fields = line.Split(delimiters, StringSplitOptions.None);
                                string[] new_fields = new string[fields.Count()];
                                fields.CopyTo(new_fields, 0);

                                if (iRowNum == 0)
                                {
                                    newline = String.Join("\t",fields);
                                }
                                else
                                {
                                    if (!fields[Cellline].Equals(Previous["Cellline"]))
                                    {
                                        if (Scrambles.ContainsKey(fields[Cellline]))
                                        {
                                            new_fields[Cellline] = "Cellline" + Scrambles[fields[Cellline]];
                                        }
                                        else
                                        {
                                            iCellline++;
                                            Scrambles.Add(fields[Cellline], iCellline.ToString());
                                            new_fields[Cellline] = "Cellline" + iCellline.ToString();
                                        }
                                        
                                    }
                                    

                                    if (!fields[Compound].Equals(Previous["Compound"]))
                                    {
                                        if (Scrambles.ContainsKey(fields[Compound]))
                                        {
                                            new_fields[Compound] = "Compound" + Scrambles[fields[Compound]];
                                        }
                                        else
                                        {
                                            iCompound++;
                                            Scrambles.Add(fields[Compound], iCompound.ToString());
                                            new_fields[Cellline] = "Cellline" + iCellline.ToString();
                                        }

                                    }
                                    
                                    if (!fields[ShortCompoundID].Equals(Previous["ShortCompoundID"]))
                                    {
                                        if (Scrambles.ContainsKey(fields[Cellline]))
                                        {
                                            new_fields[Cellline] = "Cellline" + Scrambles[fields[Cellline]];
                                        }
                                        else
                                        {
                                            iCellline++;
                                            Scrambles.Add(fields[Cellline], iCellline.ToString());
                                            new_fields[Cellline] = "Cellline" + iCellline.ToString();
                                        }

                                    }
                                    
                                    if (!fields[LNumberOnly].Equals(Previous["LNumberOnly"]))
                                    {
                                        if (Scrambles.ContainsKey(fields[Cellline]))
                                        {
                                            new_fields[Cellline] = "Cellline" + Scrambles[fields[Cellline]];
                                        }
                                        else
                                        {
                                            iCellline++;
                                            Scrambles.Add(fields[Cellline], iCellline.ToString());
                                            new_fields[Cellline] = "Cellline" + iCellline.ToString();
                                        }

                                    }
                                    

                                    newline = String.Join("\t", new_fields) + Environment.NewLine ;

                                }

                                new_file.Write(newline);
                                

                                Previous.Clear();
                                Previous.Add("Cellline", fields[Cellline]);
                                Previous.Add("Compound", fields[Compound]);
                                Previous.Add("ShortCompoundID", fields[ShortCompoundID]);
                                Previous.Add("LNumberOnly", fields[LNumberOnly]);

                                iRowNum++;



                            }

                            file.Close();
                            new_file.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        // Catch the exception that is unhandled in TryCast.
                        Console.WriteLine("Error happened: " + ex.Message);
                    }
                    finally
                    { 
                        
                    
                    }

                 // Suspend the screen.
                     
                }

        }
    }

