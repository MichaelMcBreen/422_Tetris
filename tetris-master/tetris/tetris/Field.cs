//Field.cs
//Written by Scott Porcaro, 2011
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tetris
{
    public class Field
    {

        //field class: this contains functions and items that
        //pertain to the field:  bounds/collision checking,
        //dimensions, etc.
        private int width, height;
        public int fieldWidth
        {
            get { return this.width; }
        }
        public int fieldHeight
        {
            get { return this.height; }
        }

        private int[,] field;
        public int[,] fieldArray
        {
            get { return this.field; }
        }


        public Field(int w = Globals.FIELD_WIDTH, int h = Globals.FIELD_HEIGHT)
        {
            if (w <= 0)
            {
                // Minimum width of 1
                //add two to width for border (left side, right side)
                this.width = 1 + 2;
            }
            else
            {
                //add two to width for border (left side, right side)
                this.width = w + 2;
            }
            
            if (h <= 0)
            {
                //add one to height for border (bottom)
                this.height = 1 + Globals.PADDING + 1;
            }
            else
            {
                //add one to height for border (bottom)
                this.height = h + Globals.PADDING + 1;
            }
            
            field = new int[height,width];

            //add border numbers (9) to left most and right most edges
            for (int i = 0; i < height-1; i++)
            {
                field[i, 0] = 9;
                field[i, width - 1] = 9;
            }
            //border on bottom
            for (int i = 0; i < width; i++)
                field[height-1, i] = 9;
        }

        public bool placePiece(int[,] shape, Globals.coords location)
        {
            //adds the tetronimo object to the field array
            //similar to checkPiece, this performs the actual write

            // Invalid Location (must be positive and less than height, width)
            if (location.x < -1 || location.x > this.width)
                return false;
            if (location.y < -1 || location.y > this.height)
                return false;

            int tempX = location.x;
            for (int i = 0; i < Globals.PIECE_HEIGHT; i++)
            {
                //checking to see if there's a row
                if (shape[i, 0] + shape[i, 1] + shape[i, 2] + shape[i, 3] > 0)
                {
                    for (int j = 0; j < Globals.PIECE_WIDTH; j++)
                    {
                        //checking to see if there's a shape to draw, and there's nothing in the way
                        if (shape[i, j] > 0)
                        {
                            if (field[location.y, tempX] == 0)
                            {
                                field[location.y, tempX] = shape[i, j];
                            }
                            else
                            {
                                return false;
                            }
                        }
                        tempX++;
                    }
                    location.y++;
                    tempX = location.x;
                }
                else
                {
                    location.y++;
                }
                
            }
            return true;
        }


        public bool checkPiece(int[,] shape, Globals.coords location)
        {
            // Invalid Location (must be positive and less than height, width)
            if (location.x < -1 || location.x > this.width)
                return false;
            if (location.y < -1 || location.y > this.height)
                return false;

            int tempX = location.x;
            int tempY = location.y;

            //collision/bounds checking
            for (int i = 0; i < Globals.PIECE_HEIGHT; i++)
            {
                //checking to see if there's a row
                if (shape[i, 0] + shape[i, 1] + shape[i, 2] + shape[i, 3] > 0)
                {
                    for (int j = 0; j < Globals.PIECE_WIDTH; j++)
                    {
                        //checking to see if there's a shape to draw, and there's nothing in the way
                        if (shape[i, j] > 0)
                        {
                            if (field[tempY, tempX] > 0)
                            {
                                return false;
                            }
                        }
                        tempX++;
                    }
                    tempY++;
                    tempX = location.x;
                }
                else
                {
                    tempY++;
                }
            }
            return true;
        }

        public int checkLines()
        {
            int lineCount = 0;
            bool line = true;
            //-2, compensating for the bottom row always being full of 9's
            for (int i = height - 2; i >= 0; i--)
            {
                for (int j = 1; j <= Globals.FIELD_WIDTH; j++)
                {
                    if (field[i, j] == 0)
                    {
                        line = false;
                        break;
                    }
                    line = true;
                }
                if (line == false)
                    continue;

                lineCount++;

                for (int k = i; k >= 1; k--)
                {
                    for (int l = 1; l <= Globals.FIELD_WIDTH; l++)
                    {
                        field[k, l] = field[k - 1, l];
                    }
                }
                i++;
            }
                        
            return lineCount;
        }

        public Globals.coords getHardDrop(int[,] shape, Globals.coords location)
        {
            do
            {
                location.y++;
            } while (checkPiece(shape, location));

            location.y--;

            return location;
        }
    }
}
