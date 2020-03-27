using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace ProtozoaColonies.Models
{
	
	public class PitriDish  //object to keep track of the board
	{
		private List<Cell> globalDish { get; set; }
		private const string BLANK_COLOR = "FFFFFF";

		//private List (System.Collections.Generic.IEnumerable<Cell> globalDish);
		private int size { get; set; }

		public void NewDish(int size) //create a new board of i x values and i y values. work on this.
		{
			List<Cell> dish = new List<Cell>();
			size += 2;
			
			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
					dish.Add(new Cell(j, i, BLANK_COLOR));
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
				cell.color = BLANK_COLOR;
			}
		}

		public void PlaceCell(int x, int y, string color)//update a cell on clicks
		{
			x = x + 1;
			y = y + 1;
			int offset = (y * size) + x;
			globalDish[offset].color = color;
			
		}

		public void CheckDish()//go to next state
		{
			//create new dish to return.
			List<Cell> newDish = new List<Cell>(/*globalDish */);

			//add new cells into new dish that are the same as the global dish.
			foreach (Cell cell in globalDish)
			{
				newDish.Add(new Cell(cell.x, cell.y, cell.color));
			}

			int TrueOffset = 0;

			// loop through the whole table ( x and y)
			foreach (Cell cell in globalDish)
			{
				
				int adjAlive = 0;
				string[] color = { BLANK_COLOR, BLANK_COLOR, BLANK_COLOR, BLANK_COLOR, BLANK_COLOR, BLANK_COLOR, BLANK_COLOR, BLANK_COLOR };

				//if they are on the top, sides or bottom don't do anything
				if (!(cell.x == 0 || cell.x == (size - 1) || cell.y == 0 || cell.y == (size - 1)))
				{ 

					string Testcolor = BLANK_COLOR;

					//check top left 
					Testcolor = globalDish[(TrueOffset-(size+1))].color;
					if (Testcolor != BLANK_COLOR)
					{
						color[adjAlive] = Testcolor;
						adjAlive += 1;
						Testcolor = BLANK_COLOR;
					}
					//check top
					Testcolor = globalDish[(TrueOffset-size)].color;
					if (Testcolor != BLANK_COLOR)
					{
						color[adjAlive] = Testcolor;
						adjAlive += 1;
						Testcolor = BLANK_COLOR;
					}
					//check top right
					Testcolor = globalDish[(TrueOffset-(size-1))].color;
					if (Testcolor != BLANK_COLOR)
					{
						color[adjAlive] = Testcolor;
						adjAlive += 1;
						Testcolor = BLANK_COLOR;
					}
					//left
					Testcolor = globalDish[(TrueOffset-1)].color;
					if (Testcolor != BLANK_COLOR)
					{
						color[adjAlive] = Testcolor;
						adjAlive += 1;
						Testcolor = BLANK_COLOR;
					}
					//right
					Testcolor = globalDish[(TrueOffset+1)].color;
					if (Testcolor != BLANK_COLOR)
					{
						color[adjAlive] = Testcolor;
						adjAlive += 1;
						Testcolor = BLANK_COLOR;
					}
					//bottom left
					Testcolor = globalDish[(TrueOffset+(size-1))].color;
					if (Testcolor != BLANK_COLOR)
					{
						color[adjAlive] = Testcolor;
						adjAlive += 1;
						Testcolor = BLANK_COLOR;
					}
					//bottom
					Testcolor = globalDish[(TrueOffset+(size))].color;
					if (Testcolor != BLANK_COLOR)
					{
						color[adjAlive] = Testcolor;
						adjAlive += 1;
						Testcolor = BLANK_COLOR;
					}
					//bottom right
					Testcolor = globalDish[(TrueOffset+(size+1))].color;
					if (Testcolor != BLANK_COLOR)
					{
						color[adjAlive] = Testcolor;
						adjAlive += 1;
						Testcolor = BLANK_COLOR;
					}
				}
				//if cell has 0-1 it dies
				if (adjAlive <= 1)
				{
					newDish[TrueOffset].color = BLANK_COLOR;
				}
				//if > 3 it dies
				else if (adjAlive > 3)
				{
					newDish[TrueOffset].color = BLANK_COLOR;
				}
				//otherwise lives
				else
				{
					//if not populated && 3 neighbors, comes to life.
					if(adjAlive == 3 && newDish[TrueOffset].color == BLANK_COLOR)
					{

						//calculate the color and set it into the cell.
						newDish[TrueOffset].color = CalcColor(color); 

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
			List<Cell> sharedDish = new List<Cell>();

			//add new cells into new dish that are the same as the global dish.
			foreach (Cell cell in globalDish)
			{
				if (!(cell.x == 0 || cell.x == (size - 1) || cell.y == 0 || cell.y == (size - 1)))
				{
					sharedDish.Add(new Cell((cell.x-1), (cell.y-1), cell.color));
				}
			}

			string json = JsonConvert.SerializeObject(sharedDish, Formatting.None);
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

			R = R / 3;
			G = G / 3;
			B = B / 3;

			//convert back to hex
			string nHR = Convert.ToString(R, 16);
			string nHG = Convert.ToString(G, 16);
			string nHB = Convert.ToString(B, 16);
			
			if (nHR.Length == 1) nHR = "0" + nHR;
			if (nHG.Length == 1) nHG = "0" + nHG;
			if (nHB.Length == 1) nHB = "0" + nHB;

			//take answer and move it back into the format RGB
			string newColor = nHR + nHG + nHB;

			return newColor;
		}
	}
}