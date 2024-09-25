using System;
using SplashKitSDK;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace TemperatureVisualisation
{
  public class Program
  {
    public static void Main()
    {
      Station stationData = new Station("CSVData.csv") {ViewFrom = 0};

      if ( ! stationData.HasData )
      {
        Console.WriteLine("Station has no data");
        return;
      }

      stationData.WriteData();
      stationData.WriteRange(30);

      Window w = new Window("My Graph", 1000, 800);

      while ( ! w.CloseRequested )
      {
        SplashKit.ProcessEvents();

        if ( SplashKit.KeyDown(KeyCode.LeftKey) )
        {
          stationData.ViewFrom--;
        }

        if ( SplashKit.KeyDown(KeyCode.RightKey) )
        {
          stationData.ViewFrom++;
        }

        if ( SplashKit.KeyDown(KeyCode.SpaceKey) )
        {
          stationData.Sort();
        }

        w.Clear(SplashKit.RGBColor(236, 240, 241));
        stationData.DrawGraph();
        w.Refresh(60);
      }
      w.Close();
    }
  }

  public class Station
  {
    private string _stationNumber;
    private int _viewFrom;

    public int ViewFrom
    {
      get { return _viewFrom; }
      set
      {
        if (value > 0) _viewFrom = value;
      }
    }
    private List<TemperatureData> _temperatures = new List<TemperatureData>();

    public Station(string filename)
    {
      ReadData(filename);
    }

    public void Sort()
    {

      for ( int j = 0; j < _temperatures.Count; j++)
      {
        for( int i = 0; i < _temperatures.Count-1; i++)
        {
          if ( _temperatures[i].Temperature > _temperatures[i + 1].Temperature)
          {
            TemperatureData temp = _temperatures[i+1];
            _temperatures[i+1] = _temperatures[i];
            _temperatures[i] = temp;

            SplashKit.ClearScreen(Color.White);
            DrawGraph();
            SplashKit.RefreshScreen();
            SplashKit.ProcessEvents();
          }
        }
      }
    }

    public bool HasData
    {
      get { return _temperatures.Count > 0; }
    }

    public void WriteData()
    {
      for (int i = 0; i < _temperatures.Count; i++)
      {
       Console.WriteLine($"Day {i} is {_temperatures[i].Temperature}" );
      }
      Console.WriteLine("Max is: " + MaxTemperature);
    }

    public void WriteRange(int num)
    {
      for (int i = ViewFrom; i < _temperatures.Count && i < ViewFrom + num; i++)
      {
       Console.WriteLine($"Day {i} is {_temperatures[i].Temperature}" );
      }
    }

    public double MaxTemperature
    {
      get
      {
        if (_temperatures.Count == 0) throw new Exception("No temperatures recorded for this station");

        double temporaryMaximum = _temperatures[0].Temperature;
        foreach (TemperatureData data in _temperatures)
        {
          if (data.Temperature > temporaryMaximum)
          {
            temporaryMaximum = data.Temperature;
          }
        }
        return temporaryMaximum;
      }
    }

    public double AverageTemperature
    {
      get
      {
        if (_temperatures.Count == 0) throw new Exception("No temperatures recorded for this station");

        double sum = 0;
        foreach (TemperatureData data in _temperatures)
        {
          sum += data.Temperature;
        }
        return sum / _temperatures.Count;
      }
    }

    public void DrawGraph()
    {
      const double MAX_DRAW_TEMP = 50;
      const int NUM_TO_DRAW = 100;

      double barwidth = SplashKit.ScreenWidth() / (double)NUM_TO_DRAW;
      double yScale = SplashKit.ScreenHeight() / MAX_DRAW_TEMP;
      int range = ViewFrom + NUM_TO_DRAW;
      int count = 0;

      for (int i = ViewFrom; i <_temperatures.Count && i < range; i++)
      {
        _temperatures[i].DrawAt(count * barwidth, barwidth, yScale);
        count++;
      }

      double maxLineY = SplashKit.ScreenHeight() - MaxTemperature * yScale;
      double avgLineY = SplashKit.ScreenHeight() - AverageTemperature * yScale;

      SplashKit.DrawLine(
        Color.DarkRed,
        0, maxLineY,
        SplashKit.ScreenWidth(), maxLineY);

      SplashKit.DrawLine(
        Color.DarkGreen,
        0, avgLineY,
        SplashKit.ScreenWidth(), avgLineY);
    }

    private void ReadData(string filename)
    {
      string[] splitLine;
      int year, month, day;
      string stationNumber;
      DateTime date;
      double temperature = 0;
      List<string> data = new List<string>();

      try
      {
        data = File.ReadAllLines(filename).ToList();
        data.RemoveAt(0);
        _stationNumber = data.First().Split(',').First();
      }
      catch(Exception e)
      {
        Console.WriteLine("Unable to open file");
        Console.WriteLine(e.Message);
        return;
      }

      foreach (string line in data)
      {
        try
        {
          splitLine = line.Split(',');
          stationNumber = splitLine[1];
          year = Convert.ToInt32(splitLine[2]);
          month = Convert.ToInt32(splitLine[3]);
          day = Convert.ToInt32(splitLine[4]);
          temperature = Convert.ToDouble(splitLine[5]);

          date = new DateTime(year, month, day);
          _temperatures.Add(new TemperatureData { Date = date, Temperature = temperature});
        }
        catch(Exception e)
        {
          Console.WriteLine(e.Message);
        }
      }
    }
  }

  public struct TemperatureData
  {
    public void DrawAt(double x, double barwidth, double yScale)
    {
      SplashKit.FillRectangle(
        SplashKit.RGBColor(231, 76, 60),
        x, SplashKit.ScreenHeight() - Temperature * yScale,
        barwidth, Temperature * yScale + 1);

      SplashKit.DrawRectangle(
        SplashKit.RGBColor(44, 62, 80),
        x, SplashKit.ScreenHeight() - Temperature * yScale,
        barwidth, Temperature * yScale + 1);
    }

    public DateTime Date {get; set;}
    public double Temperature {get; set;}

    public override string ToString()
    {
      return Temperature.ToString();
    }
  }
}
