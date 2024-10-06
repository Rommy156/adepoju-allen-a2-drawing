// Include code libraries you need below (use the namespace).
using System;
using System.Numerics;

// The namespace your code is in.
namespace Game10003
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:


        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetSize(800, 600);
            Window.SetTitle("2D Interactive");
            Window.TargetFPS = 40;
            //lets set background color
            //lets set an array
            string text = "DRIVER";
            Console.WriteLine(text[0]);
            Console.WriteLine(text[1]);
            Console.WriteLine(text[2]);
            Console.WriteLine(text[3]);
            Console.WriteLine(text[4]);
            Console.WriteLine(text[5]);

         
            
                

        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            
            Window.ClearBackground(Color.Gray);


            //lets draw the bodyframe of the car
            Draw.PolyLine(100, 300, 100, 200, 200, 100, 500, 100, 600, 200, 750, 220, 750, 300, 100, 300);
            Draw.Quad(100, 200, 200, 100, 500, 100, 600, 200);

            Draw.FillColor = Color.OffWhite;
            Draw.LineColor = Color.Black;










        }
    }
}
