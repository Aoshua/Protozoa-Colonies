using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace ProtozoaColonies.Models
{
	
	public class PitriDish  //object to keep track of the board
	{
		private List<Cell> globalDish { get; set; }
		private int size { get; set; }

		public void NewDish(int size) //create a new board of i x values and i y values. work on this.
		{
			List<Cell> dish = new List<Cell>();
			
			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
					dish.Add(new Cell(j, i, "FFFFFF"));
				}
			}
			globalDish = dish;
			this.size = size;
		}

		public void CleanDish() //wipe the board
		{
			//newDish(size);
			foreach(Cell cell in globalDish)
			{
				cell.color = "FFFFFF";
			}
		}

		public void PlaceCell(int x, int y, string color)//update a cell on clicks
		{
			//foreach (Cell cell in globalDish)
			int offset = (y * size) + x;
				globalDish[offset].color = color;
				/*if (globalDish.GetValue.x = x && globalDish.GetValue.y)
				{
					globalDish.GetValue.color = color;
					break;
				}*/
		}

		public void CheckDish()//go to next state
		{
			//create new dish to return.
			List<Cell> newDish = new List<Cell>(globalDish);
			//newDish.AddRange(globalDish);
			//List<Cell> oldDish = new List<Cell>(globalDish);
			//globalDish.RemoveRange(0, (size*size));
			int TrueOffset = 0;

			// loop through the whole table ( x and y)
			foreach (Cell cell in globalDish)
			{
				
				int adjAlive = 0;
				string[] color = { "FFFFFF", "FFFFFF", "FFFFFF", "FFFFFF", "FFFFFF", "FFFFFF", "FFFFFF", "FFFFFF" };

				//if they are on the top, sides or bottom don't do anything
				if (!(cell.x == 0 || cell.x == (size - 1) || cell.y == 0 || cell.y == (size - 1)))
				{ 
					//int lat = cell.x;
					//int lon = cell.y;
					string Testcolor = "FFFFFF";
					//int offset = (y * size) + x;
					
					//newDish[TrueOffset].color = cell.color;
					//////*******************************************************************************************

					//check top left 
					Testcolor = globalDish[(TrueOffset-(size+1))].color;
					if (Testcolor != "FFFFFF")
					{
						color[adjAlive] = Testcolor;
						adjAlive += 1;
						Testcolor = "FFFFFF";
					}
					//check top
					Testcolor = globalDish[(TrueOffset-size)].color;
					if (Testcolor != "FFFFFF")
					{
						color[adjAlive] = Testcolor;
						adjAlive += 1;
						Testcolor = "FFFFFF";
					}
					//check top right
					Testcolor = globalDish[(TrueOffset-(size-1))].color;
					if (Testcolor != "FFFFFF")
					{
						color[adjAlive] = Testcolor;
						adjAlive += 1;
						Testcolor = "FFFFFF";
					}
					//left
					Testcolor = globalDish[(TrueOffset-1)].color;
					if (Testcolor != "FFFFFF")
					{
						color[adjAlive] = Testcolor;
						adjAlive += 1;
						Testcolor = "FFFFFF";
					}
					//right
					Testcolor = globalDish[(TrueOffset+1)].color;
					if (Testcolor != "FFFFFF")
					{
						color[adjAlive] = Testcolor;
						adjAlive += 1;
						Testcolor = "FFFFFF";
					}
					//bottom left
					Testcolor = globalDish[(TrueOffset+(size-1))].color;
					if (Testcolor != "FFFFFF")
					{
						color[adjAlive] = Testcolor;
						adjAlive += 1;
						Testcolor = "FFFFFF";
					}
					//bottom
					Testcolor = globalDish[(TrueOffset+(size))].color;
					if (Testcolor != "FFFFFF")
					{
						color[adjAlive] = Testcolor;
						adjAlive += 1;
						Testcolor = "FFFFFF";
					}
					//bottom right
					Testcolor = globalDish[(TrueOffset+(size+1))].color;
					if (Testcolor != "FFFFFF")
					{
						color[adjAlive] = Testcolor;
						adjAlive += 1;
						Testcolor = "FFFFFF";
					}
				}
				//if cell has 0-1 it dies
				if (adjAlive <= 1)
				{
					newDish[TrueOffset].color = "FFFFFF";
				}
				//if > 3 it dies
				else if (adjAlive > 3)
				{
					newDish[TrueOffset].color = "FFFFFF";
				}
				//otherwise lives
				else
				{
					//if not populated && 3 neighbors, comes to life.
					if(adjAlive == 3 && newDish[TrueOffset].color == "FFFFFF")
					{

						//calculate the color and set it into the cell.
						newDish[TrueOffset].color = CalcColor(color); //this is assigning the globalDish as well as newDish, even when I did oldDish and wiped the globalDish clean?????

					}
				}
				TrueOffset += 1;
			}

			//once this is done overwrite the old dish and clear the new dish.
			globalDish = newDish;
		}

		/*public List<Cell> ShareDish()//give dish back.******************************This returns the list of cells**********************
		{
			return globalDish;
		}*/

		/*public string ShareDish()//give dish back*******************************This returns a jsonString of comma seperated hex values**********************
		{
			string colors = "";
			colors = globalDish[0].color;

			for(int i =1; i<(size*size); i++)
			{
				string addon = ", " + globalDish[i].color;
				colors += addon;
			}
			string jsonString;
			jsonString = JsonSerializer.Serialize(colors);
			return jsonString;
		}*/
		public string ShareDish()//give dish back**********************************This returns a jsonString? of originally an array of Cell Objects********
		{
			string json = JsonConvert.SerializeObject(globalDish, Formatting.None);
			// {
			//   "x": 5,
			//   "y": 5,
			//   "Color": "FFFFFF",
			// }

			return json;
		}

		private string CalcColor(string [] color)
        {
			//something to save the colors into
			int R = 0;
			int G = 0;
			int B = 0;
			//loop through color doing:
			for (int i = 0; i < 3; i++)
			{
				//seperate the hex to be R G B instead of RGB
				//get color out of hex.
				string hR = color[i].Substring(0, 2);
				string hG = color[i].Substring(2, 2);
				string hB = color[i].Substring(4, 2);
				//sum all the R's the G's and B's
				R += int.Parse(hR, System.Globalization.NumberStyles.HexNumber);
				G += int.Parse(hG, System.Globalization.NumberStyles.HexNumber);
				B += int.Parse(hB, System.Globalization.NumberStyles.HexNumber);
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

			//convert back to hex
			string nHR = Convert.ToString(R, 16);
			string nHG = Convert.ToString(G, 16);
			string nHB = Convert.ToString(B, 16);
			if (nHR == "0" || nHR == "1" || nHR == "2" || nHR == "3" || nHR == "4" || nHR == "5" || nHR == "6" || nHR == "7" || nHR == "8" || nHR == "9") nHR = "0" + nHR;
			if (nHG == "0" || nHG == "1" || nHG == "2" || nHG == "3" || nHG == "4" || nHG == "5" || nHG == "6" || nHG == "7" || nHG == "8" || nHG == "9") nHG = "0" + nHG;
			if (nHB == "0" || nHB == "1" || nHB == "2" || nHB == "3" || nHB == "4" || nHB == "5" || nHB == "6" || nHB == "7" || nHB == "8" || nHB == "9") nHB = "0" + nHB;

			//take answer and move it back into the format RGB
			string newColor = nHR + nHG + nHB;

			return newColor;
		}
	}
}