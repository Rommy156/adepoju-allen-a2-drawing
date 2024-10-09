// Include code libraries you need below (use the namespace).
using System;
using System.ComponentModel.Design;
using System.Drawing;
using System.Numerics;
using System.Reflection;
using System.Security.Cryptography;
using System.Text.Json.Serialization.Metadata;

// The namespace your code is in.
namespace Game10003
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {

        Vector2 paintPos = new(100, 50);
        // Place your variables here:
        //lets define radius and position of wheel
        float[] wheelRadius = { 50, 30 };

        Vector2[] tireRims =
        {
          new  (250,300),
          new (550,300)
        };


        
        float line1X = 100;
        float line2X = 350;
        float line3X = 600;

        int laneLineSpeed = 2;
        int laneLinePostionX = 100;
        int laneLineSizeX = 150;
        int laneLineSizeY = 50;


        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetSize(800, 600);
            Window.SetTitle("2D Interactive");
            Window.TargetFPS = 10;
            //lets set background properties
            //lets set an array
            string text = "DRIVER";
            Console.Write(text[0]);
            Console.Write(text[1]);
            Console.Write(text[2]);
            Console.Write(text[3]);
            Console.Write(text[4]);
            Console.Write(text[5]);





        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        { //lets set window background colour
            Window.ClearBackground(Color.Gray);
            //lets draw the sun
            Draw.LineSize = 0; Draw.Circle(750, 50, 35);

            Draw.FillColor = new Color(10, 15, 25);
            Draw.LineColor = Color.Yellow;

            Draw.LineColor = Color.Black;
            Draw.LineSize = 8;
            //lets draw the bodyframe of the car
            Draw.PolyLine(100, 300, 100, 200, 200, 100, 500, 100, 600, 200, 750, 220, 750, 300, 100, 300);

            Draw.Quad(100, 200, 200, 100, 500, 100, 600, 200);

            Draw.FillColor = Color.OffWhite;
            Draw.LineColor = Color.Black;
            Draw.LineSize = 2;


            //lets loop our speed and a message
            {

                string[] message = ["Hello Driver", "Drive Safe"];
                foreach (string name in message)
                    Console.WriteLine(name);
                bool condition = false;
                while (condition) { Console.WriteLine("Obey Traffic Rules"); }
                {

                }

            }
            {




                //lets draw the road
                Draw.FillColor = Color.DarkGray;
                Draw.Rectangle(0, 350, 800, 600);

                Draw.FillColor = Color.Yellow;

                // lets move the lines 10 pixels per second
                /*float lineSpeed = 50f;
                line1X -= lineSpeed * Time.DeltaTime;
                Draw.Rectangle(line1X, 450, 150, 50);

                line2X -= lineSpeed * Time.DeltaTime;
                Draw.Rectangle(line2X, 450, 150, 50);

                line3X -= lineSpeed * Time.DeltaTime;
                Draw.Rectangle(line3X, 450, 150, 50);
               */
                DrawLaneLine(0);
                DrawLaneLine(350);
                DrawLaneLine(600);
            }

            Vector2 PaintPos = new Vector2();
            PaintPos += new Vector2(0, 20f * (float)Math.Sin(Time.SecondsElapsed));
            PaintPos = Vector2.Normalize(PaintPos);

            //lets declare  wheel1

            Vector2 wheel1Pos = new Vector2(200, 300);
            Vector2 radiusLine = new Vector2(1, 0);
            radiusLine.X = 10f * (float)Math.Cos(Time.SecondsElapsed);
            radiusLine.Y = 10f * (float)Math.Sin(Time.SecondsElapsed);

            //lets declare wheel2
            Vector2[] line = new Vector2[2];
            Vector2 vector2 = new Vector2();

            Vector2 wheel2Pos = new Vector2(300, 300);
            Vector2 radiusLine1 = new Vector2(1, 0);
            radiusLine1.X = 10f * (float)Math.Cos(Time.SecondsElapsed);
            radiusLine1.Y = 10f * (float)Math.Sin(Time.SecondsElapsed);

            Draw.LineSize = 8;







            // lets get mouse input data
            float x = Input.GetMouseX();
            float y = Input.GetMouseY();

            //lets make the left mouse click to restart wheel 
            {
                if (Input.IsMouseButtonPressed(MouseInput.Left)) ++Time.SecondsElapsed;
                Draw.FillColor = Random.Color();
                Draw.Circle(550, 300, 50);
            }
            //lets make the space button on the keyboard go fast

            if (Input.IsKeyboardKeyDown(KeyboardInput.Space)) ++Time.SecondsElapsed;

            Draw.Circle(250, 300, 50);

            for (int i = 50; i < 60; i++)


                Draw.FillColor = Color.Clear;
            if (Input.IsKeyboardKeyDown(KeyboardInput.Space))
            {
                Draw.Circle(550, 300, 30);
                Draw.Circle(250, 300, 30);

                Draw.Circle(550, 300, 50);
                Draw.Circle(550, 300, 50);
                Draw.FillColor = Random.Color();


                //air resistance
                Draw.LineSize = 1.5f;
                Draw.Line(200, 100, 0, 150);
                Draw.Line(100, 200, 0, 225);
                Draw.Line(100, 300, 0, 305);
                Draw.LineSize = 8; Draw.FillColor = Color.Yellow;

                for (int i = 40; i <= 60; i++)
                    Console.WriteLine($"{i}km/ph");
            }
            else
            {
                Draw.Circle(550, 300, 50);
                Draw.Circle(250, 300, 50);
                Draw.Circle(550, 300, 30);
                Draw.Circle(250, 300, 30);
                Draw.LineSize = 8;
                Draw.FillColor = new Color(255, 164, 1);


            }

            //lets draw rotating rim 1 
            //got some help with the rotating line from Jon-Marc
            DrawWheel(250, 300);
            DrawWheel(550, 300);
           



            //Rotating rim 2

          

           

            Draw.LineColor = Color.Black;
        }

        void DrawWheel(int positionX, int positionY)
        {
            Vector2 linePosition1 = new Vector2(positionX, positionY);
            Vector2 linePosition2 = new Vector2(positionX, positionY);
            float radius = 50;
            Draw.LineColor = Color.Blue;

            linePosition2.X = (radius * (float)Math.Cos(2 * Time.SecondsElapsed) + linePosition2.X);
            linePosition2.Y = (radius * (float)Math.Sin(2 * Time.SecondsElapsed) + linePosition2.Y);
            Draw.Line(linePosition1, linePosition2);
        }


        void DrawLaneLine(int offset)
        {
            laneLinePostionX -= laneLineSpeed;

            if (laneLinePostionX < 0 - laneLineSizeX)
            {
                laneLinePostionX = Window.Width;
            }

            Draw.Rectangle(laneLinePostionX + offset, 400, laneLineSizeX, laneLineSizeY);
        }
    }









}











