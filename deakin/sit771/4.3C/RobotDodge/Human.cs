using System.Collections;
using System.Drawing;

namespace RobotDodge
{
    public class Test{
        public static void Main(string[] args){
            string name = "John";
            double height =170.00;
            double weight = 140.00;
            List<Eye> eyes = new List<Eye>(2);
            eyes.Add(new Eye(Color.Brown));
            eyes.Add(new Eye(Color.Brown));
            Hair hair =new Hair(Color.Black);
            Human John = new Human(name,height,weight,eyes,hair);
            John.Walk();
            John.Dance();
            John.Speak();
        }
    }
    public class Human{
        private string _Name;
        private double _Height;
        private double _Weight;

        private List<Eye> _Eyes;

        private Hair _Hair;

        public Human(string name,double height,double weight,List<Eye> eyes, Hair hair){
            _Name = name;
            _Height =  height;
            _Weight = weight;
            _Eyes = eyes;
            _Hair = hair;
        }

        public void Walk(){
            Console.WriteLine($"{_Name} is walking");
        }


        public void Dance(){
            Console.WriteLine($"{_Name} is dancing");
        }
        
        public void Speak(){
            Console.WriteLine($"{_Name} is Speaking");
        }
    }

    public class Eye{
        private Color _Color;

        public Eye(Color color){
            _Color = color;
        }
    }

    public class Hair{
        private Color _Color;
        
        public Hair(Color color){
            _Color = color;
        }
    }
}