using System;
using System.IO;

namespace Histogram
{
    public class Program
    {   

        public static char[,] createHistogramMatrix(string[] words){
            
            int largestStatement = Int32.MinValue;

            for(int i = 0; i < words.Length; i++)
            {
                if(words[i].Length > largestStatement){
                    largestStatement = words[i].Length;
                }
            }

            char[,] histogramMatrix = new char[largestStatement,words.Length];

            for(int i = 0; i < words.Length; i++)
            {
                for(int j = 0; j < words[i].Length; j++)
                {
                    histogramMatrix[j,i] = '*';
                }
            }

            return histogramMatrix;

        }

        public static void Main(string[] args)
        {

            string[] lines = System.IO.File.ReadAllLines("prog3.IN");
            int nHistograms = Int32.Parse(lines[0]);
            string[][] hgWords = new string[nHistograms][];
            int actCol = 0;

            for(int i = 1; i < lines.Length; i++)
            {
                int nWords = Int32.Parse(lines[i]);
                hgWords[actCol] = new string[nWords];

                int j = i+1;

                for(int z = 0; z < nWords; z++,j++)
                {
                    string statement = lines[j];
                    hgWords[actCol][z] = statement;                                     
                }

                i = j-1;
                
                actCol++;
                if(actCol == nHistograms){
                    break;
                }

            }

            StreamWriter sw = new StreamWriter(new FileStream("prog3.OUT",FileMode.Create));

            for(int i = 0; i < nHistograms; i++)
            {
                char[,] histogram = createHistogramMatrix(hgWords[i]);
                sw.WriteLine("Histograma "+(i+1));
                for(int j = histogram.GetLength(0) - 1; j >= 0; j--)
                {
                    for(int k = 0; k < histogram.GetLength(1); k++)
                    {
                        sw.Write(histogram[j,k]);
                    }
                    sw.WriteLine();
                }
            }

            sw.Dispose();

        }
    }
}
