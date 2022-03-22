using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TileMap_March_2022
{
    static class MapReader //This is a static class - that means we don't need to create an instance of it
    {
        //A property to be able to set and get the map size (only currently works on square maps!)
        public static int MapSize { get; set; }

        //A class-only scope tileArray which will be used to return to the calling class
        public static char[,] tileArray;

        //Read the data from the .txt file
        public static char[,] ReadFile(string inFileName)
        {
            //Use a streamreader to read the file and pass it the filepath
            StreamReader sRead = new StreamReader(@"\Content\" + inFileName + ".txt");
            //String to store each line from the .txt file
            string line = "";
            //Create the temporary map size (This MUST match the size of out .txt file - so 10x10 today)
            tileArray = new char[10, 10];
            //A counter to help us keep track of where we are in the line of the text file (which character in the line)
            int counter = 0;

            //Iterate throught
            do
            {
                //Grab a line of text and store into the variable
                line = sRead.ReadLine();

                //Iterate through every character in that line
                for (int i = 0; i < line.Length; i++)
                {
                    //Store the character into the tileArray (the value of the character)
                    tileArray[i, counter] = line[i];
                }

                //If the counter is less than the length of the line
                if (counter < line.Length - 1)
                {
                    //Increase the counter to move to the next character
                    counter++;
                }

            } while (!sRead.EndOfStream);//Do this until we hit the end of the file (no more lines left)

            sRead.Close(); //Make sure you close the streamReader
            return tileArray;//Return the array to the calling class
        }

    }
}
