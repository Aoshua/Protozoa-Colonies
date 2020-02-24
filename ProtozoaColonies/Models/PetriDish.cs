using System;
using System.Collections.Generic;


namespace Cells
{
	
	public class PitriDish  //object to keep track of the board
	{
		public List<Cell> globalDish { get; set; }
		public int size { get; set; }
		public void newDish(int size) //create a new board of i x values and i y values. work on this.
		{
			List<Cell> dish = new List<Cell>();
			
			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
					dish.Add(new Cell(i, j, "ffffff"));
				}
			}
			globalDish = dish;
			int globalSize = size;
		}
		public void cleanDish() //wipe the board
		{
			//newDish(size);
			foreach(Cell cell in globalDish)
			{
				cell.color = "FFFFFF";
			}
		}
		public void placeCell(int x, int y, string color)//update a cell on clicks
		{
			//foreach (Cell cell in globalDish)
				globalDish[(x * y)].color = color;
				/*if (globalDish.GetValue.x = x && globalDish.GetValue.y)
				{
					globalDish.GetValue.color = color;
					break;
				}*/
		}
		public void checkDish(PitriDish dish)//go to next state
		{
			//create new dish to return.
			List<Cell> newDish = new List<Cell>();

			// loop through the whole table ( x and y)
			foreach (Cell cell in globalDish)
			{
				int adjAlive = 0;
				string[] color = { "ffffff", "ffffff", "ffffff", "ffffff", "ffffff", "ffffff", "ffffff", "ffffff" };

				//if they are on the top, sides or bottom don't do anything
				if (cell.x == 0 || cell.x == size || cell.y == 0 || cell.y == size)
				{
					//these are the edge pieces we are ignoring.
				}
				//else go through the rules and save everything on the new dish.
				else
				{
					int lat = cell.x;
					int lon = cell.y;
					string Testcolor = "ffffff";
					//////*******************************************************************************************

					//check top left 
					Testcolor = globalDish[((lat - 1) * (lon - 1))].color;
					if (Testcolor != "ffffff")
					{
						color[adjAlive] = Testcolor;
						adjAlive += 1;
						Testcolor = "ffffff";
					}
					//check top
					Testcolor = globalDish[((1) * (lon - 1))].color;
					if (Testcolor != "ffffff")
					{
						color[adjAlive] = Testcolor;
						adjAlive += 1;
						Testcolor = "ffffff";
					}
					//check top right
					Testcolor = globalDish[((lat + 1) * (lon - 1))].color;
					if (Testcolor != "ffffff")
					{
						color[adjAlive] = Testcolor;
						adjAlive += 1;
						Testcolor = "ffffff";
					}
					//left
					Testcolor = globalDish[((lat - 1) * (lon))].color;
					if (Testcolor != "ffffff")
					{
						color[adjAlive] = Testcolor;
						adjAlive += 1;
						Testcolor = "ffffff";
					}
					//right
					Testcolor = globalDish[((lat) * (lon - 1))].color;
					if (Testcolor != "ffffff")
					{
						color[adjAlive] = Testcolor;
						adjAlive += 1;
						Testcolor = "ffffff";
					}
					//bottom left
					Testcolor = globalDish[((lat - 1) * (lon + 1))].color;
					if (Testcolor != "ffffff")
					{
						color[adjAlive] = Testcolor;
						adjAlive += 1;
						Testcolor = "ffffff";
					}
					//bottom
					Testcolor = globalDish[((lat) * (lon + 1))].color;
					if (Testcolor != "ffffff")
					{
						color[adjAlive] = Testcolor;
						adjAlive += 1;
						Testcolor = "ffffff";
					}
					//bottom right
					Testcolor = globalDish[((lat + 1) * (lon + 1))].color;
					if (Testcolor != "ffffff")
					{
						color[adjAlive] = Testcolor;
						adjAlive += 1;
						Testcolor = "ffffff";
					}
				}
				//if cell has 0-1 it dies
				if (adjAlive == 0 || adjAlive == 1)
				{
					cell.color = "ffffff";
				}
				//if > 3 it dies
				else if (adjAlive > 3)
				{
					cell.color = "ffffff";
				}
				//otherwise lives
				else
				{
					//if not populated && 3 neighbors, comes to life.
					if(adjAlive == 3 && cell.color == "ffffff")
					{
						int R = 0;
						int G = 0;
						int B = 0;
						//loop through color doing:
						for (int i = 0; i < 3; i++)
						{
							//get the color out of the hex.
							//seperate the hex to be R G B instead of RGB

							//sum all the R's the G's and B's

						}

						//devide by 3 for R G and B.
						if (R != 0)
						{
							R = R / 3;
						}
						if (G != 0)
						{
							G = G / 3;
						}
						if (B != 0)
						{
							B = B / 3;
						}

						//take answer and move it back into the format RGB

					}
				}
			}

			//once this is done overwrite the old dish and clear the new dish.
			globalDish = newDish;
		}
		public List<Cell> shareDish()//give dish back.
		{
			return globalDish;
		}
	}
}