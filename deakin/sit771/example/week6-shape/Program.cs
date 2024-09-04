using System;

namespace week6_shape
{
    public class Program
    {
        public static void Main()
        {
            Shape s1 = new Retangle();
            Shape s2 = new Ellipse();
            Retangle r = new Retangle();
            Ellipse e = new Ellipse();

            s1.Draw();
            s2.Draw();
            e.Draw();
            r.DrawRetangle();
            r.Draw();
        }
    }

    public class Shape{

        public Shape(){

        }

        public Shape(int x,int y){
            Console.WriteLine("Shape"+ x+"   "+y);
        }

        public virtual void Draw(){
            Console.WriteLine("Shape draw");
        }
    }

    
    public class Retangle:Shape{

        public override void Draw(){
            Console.WriteLine("Retangle draw");
        }

        public  void DrawRetangle(){
            Console.WriteLine("Retangle DrawRetangle");
        }
    }

    
    public class Ellipse:Shape{

        public override void Draw(){
            Console.WriteLine("Ellipse draw");
        }
    }
}
