using System;
using System.IO;

namespace FileReading
{
  public class Program
  {
    public static void Main()
    {
      double sum = 0, averageTemperature = 0, temperature;
      string line, stationNumber, year, month, day;
      string[] splitLine;
      int count = 0, errors = 0;

      try
      {
        using (StreamReader reader = new StreamReader(new FileStream("csvData.csv", FileMode.Open)))
        {
          // Read first line to skip the first line
          reader.ReadLine();

          line = reader.ReadLine();
          while (line != null)
          {
            count++;
            try
            {
              splitLine = line.Split(',');
              stationNumber = splitLine[1];
              year = splitLine[2];
              month = splitLine[3];
              day = splitLine[4];
              temperature = Convert.ToDouble(splitLine[5]);

              sum = sum + temperature;

              Console.Write($"Line {count}--->\t");
              Console.Write($"stationNumber: {stationNumber}\t");
              Console.Write($"({day}/{month}/{year})\t");
              Console.WriteLine($"{temperature}\x00B0c");
            }
            catch (Exception e)
            {
              errors++;
              Console.Write("Error on line " + count + ": ");
              Console.WriteLine(e.Message);
            }
            line = reader.ReadLine();
          }
          averageTemperature = sum / (count - errors);
          Console.WriteLine($"\nThe average temperature is {averageTemperature}\x00B0c");
          Console.WriteLine(errors + " error/s in the data");
        }
      }
      catch
      {
        Console.WriteLine("Unable to open file");
      }
    }
  }
}
