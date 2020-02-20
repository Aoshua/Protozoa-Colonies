using System;
using System.Collections;
using System.Collections.Generic;


namespace UpdateSquares
{
    static void UpdateSquares()
    {
        //connect to database

        bool q = false;
        //always be updating
        do
        {
            //make variables to store stuff for the process.
            string[8] colors;
            int adjAlive = 0;
            //get info from database

            //assign it into an array.
            string[10000] data; //hold R for red, G for Green, and B for blue\

            //loop through the whole grid
            for (int i = 0; i < 10000; i++)
            {
                //if i < 100 ignore above cubes.
                if (i < 100)
                {
                    //if mod 100 = 1 ignore left side.
                    if ((i % 100) == 1)
                    {
                        //check right.
                        if (data[(i + 1)] != 0)
                        {
                            colors[adjAlive] = data[(i + 1)];
                            adjAlive++;
                        }
                        //bottom right
                        if (data[(i + 101)] != 0)
                        {
                            colors[adjAlive] = data[(i + 1)];
                            adjAlive++;
                        }
                        //bottom
                        if (data[(i + 100)] != 0)
                        {
                            colors[adjAlive] = data[(i + 1)];
                            adjAlive++;
                        }
                    }
                    //if modd 100 = 0 ignore right side
                    else if ((i % 100) == 0)
                    {
                        //check left.
                        if (data[(i - 1)] != 0)
                        {
                            colors[adjAlive] = data[(i + 1)];
                            adjAlive++;
                        }
                        //bottom left
                        if (data[(i + 99)] != 0)
                        {
                            colors[adjAlive] = data[(i + 1)];
                            adjAlive++;
                        }
                        //bottom
                        if (data[(i + 100)] != 0)
                        {
                            colors[adjAlive] = data[(i + 1)];
                            adjAlive++;
                        }

                    }
                    //else look at both sides.
                    else
                    {
                        //check left.
                        if (data[(i - 1)] != 0)
                        {
                            colors[adjAlive] = data[(i + 1)];
                            adjAlive++;
                        }
                        //check right.
                        if (data[(i + 1)] != 0)
                        {
                            colors[adjAlive] = data[(i + 1)];
                            adjAlive++;
                        }
                        //bottom left
                        if (data[(i + 99)] != 0)
                        {
                            colors[adjAlive] = data[(i + 1)];
                            adjAlive++;
                        }
                        //bottom
                        if (data[(i + 100)] != 0)
                        {
                            colors[adjAlive] = data[(i + 1)];
                            adjAlive++;
                        }
                        //bottom right
                        if (data[(i + 101)] != 0)
                        {
                            colors[adjAlive] = data[(i + 1)];
                            adjAlive++;
                        }
                    }

                }
                //if i > 9,900 ignore bottom cubes.
                else if (i > 9900)
                {
                    //if mod 100 = 1 ignore left side.
                    if ((i % 100) == 1)
                    {
                        //check top
                        if (data[(i - 100)] != 0)
                        {
                            colors[adjAlive] = data[(i + 1)];
                            adjAlive++;
                        }
                        //check top right
                        if (data[(i - 99)] != 0)
                        {
                            colors[adjAlive] = data[(i + 1)];
                            adjAlive++;
                        }
                        //check right.
                        if (data[(i + 1)] != 0)
                        {
                            colors[adjAlive] = data[(i + 1)];
                            adjAlive++;
                        }
                    }
                    //if modd 100 = 0 ignore right side
                    else if ((i % 100) == 0)
                    {
                        //check top left
                        if (data[(i - 101)] != 0)
                        {
                            colors[adjAlive] = data[(i + 1)];
                            adjAlive++;
                        }
                        //check top
                        if (data[(i - 100)] != 0)
                        {
                            colors[adjAlive] = data[(i + 1)];
                            adjAlive++;
                        }
                        //check left
                        if (data[(i - 1)] != 0)
                        {
                            colors[adjAlive] = data[(i + 1)];
                            adjAlive++;
                        }
                    }
                    //else look at both sides.
                    else
                    {
                        //check top left
                        if (data[(i - 101)] != 0)
                        {
                            colors[adjAlive] = data[(i + 1)];
                            adjAlive++;
                        }
                        //check top
                        if (data[(i - 100)] != 0)
                        {
                            colors[adjAlive] = data[(i + 1)];
                            adjAlive++;
                        }
                        //check top right
                        if (data[(i - 99)] != 0)
                        {
                            colors[adjAlive] = data[(i + 1)];
                            adjAlive++;
                        }
                        //check left.
                        if (data[(i - 1)] != 0)
                        {
                            colors[adjAlive] = data[(i + 1)];
                            adjAlive++;
                        }
                        //check right.
                        if (data[(i + 1)] != 0)
                        {
                            colors[adjAlive] = data[(i + 1)];
                            adjAlive++;
                        }
                    }
                }
                //else check above and bellow
                else
                {
                    //if mod 100 = 1 ignore left side.
                    if ((i % 100) == 1)
                    {
                        //check top
                        if (data[(i - 100)] != 0)
                        {
                            colors[adjAlive] = data[(i + 1)];
                            adjAlive++;
                        }
                        //check top right
                        if (data[(i - 99)] != 0)
                        {
                            colors[adjAlive] = data[(i + 1)];
                            adjAlive++;
                        }
                        //check right
                        if (data[(i + 1)] != 0)
                        {
                            colors[adjAlive] = data[(i + 1)];
                            adjAlive++;
                        }
                        //check bottom
                        if (data[(i + 100)] != 0)
                        {
                            colors[adjAlive] = data[(i + 1)];
                            adjAlive++;
                        }
                        //check bottom right
                        if (data[(i + 101)] != 0)
                        {
                            colors[adjAlive] = data[(i + 1)];
                            adjAlive++;
                        }
                    }
                    //if modd 100 = 0 ignore right side
                    else if ((i % 100) == 0)
                    {
                        //check top left
                        if (data[(i - 101)] != 0)
                        {
                            colors[adjAlive] = data[(i + 1)];
                            adjAlive++;
                        }
                        //check top
                        if (data[(i - 100)] != 0)
                        {
                            colors[adjAlive] = data[(i + 1)];
                            adjAlive++;
                        }
                        //check left
                        if (data[(i - 1)] != 0)
                        {
                            colors[adjAlive] = data[(i + 1)];
                            adjAlive++;
                        }
                        //check bottom left
                        if (data[(i + 99)] != 0)
                        {
                            colors[adjAlive] = data[(i + 1)];
                            adjAlive++;
                        }
                        //check bottom
                        if (data[(i + 100)] != 0)
                        {
                            colors[adjAlive] = data[(i + 1)];
                            adjAlive++;
                        }
                    }
                    //else look at both sides.
                    else
                    {
                        //check top left
                        if (data[(i - 101)] != 0)
                        {
                            colors[adjAlive] = data[(i + 1)];
                            adjAlive++;
                        }
                        //check top
                        if (data[(i - 100)] != 0)
                        {
                            colors[adjAlive] = data[(i + 1)];
                            adjAlive++;
                        }
                        //check top right
                        if (data[(i - 99)] != 0)
                        {
                            colors[adjAlive] = data[(i + 1)];
                            adjAlive++;
                        }
                        //check left
                        if (data[(i - 1)] != 0)
                        {
                            colors[adjAlive] = data[(i + 1)];
                            adjAlive++;
                        }
                        //check right
                        if (data[(i + 1)] != 0)
                        {
                            colors[adjAlive] = data[(i + 1)];
                            adjAlive++;
                        }
                        //check bottom left
                        if (data[(i + 99)] != 0)
                        {
                            colors[adjAlive] = data[(i + 1)];
                            adjAlive++;
                        }
                        //check bottom
                        if (data[(i + 100)] != 0)
                        {
                            colors[adjAlive] = data[(i + 1)];
                            adjAlive++;
                        }
                        //check bottom right
                        if (data[(i + 101)] != 0)
                        {
                            colors[adjAlive] = data[(i + 1)];
                            adjAlive++;
                        }
                    }
                }


            }

            //if one or no neighbor, square dies
            if (adjAlive <= 1)
            {
                data[i] = 0;
            }
            //else if 4 or more neighbors, square dies
            else if (adjAlive >= 4)
            {
                data[i] = 0;
            }
            //else 2-3 survives
            else
            {
                //if square not populated, and 3 then populate.
                if (data[i] == 0 && adjAlive == 3)
                {
                    //populate on color based
                    int R = 0;
                    int B = 0;
                    int G = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        if (colors[i] == "R")
                        {
                            R++;
                        }
                        else if (colors[i] == "B")
                        {
                            B++;
                        }
                        else
                        {
                            G++;
                        }
                    }
                    if (R > 2)
                    {
                        //insert into database new color R
                    }
                    else if (B > 2)
                    {
                        //insert into database new color B
                    }
                    else
                    {
                        //insert into database new color G
                    }
                }
            }
        }
        while (q == false);
    }
}