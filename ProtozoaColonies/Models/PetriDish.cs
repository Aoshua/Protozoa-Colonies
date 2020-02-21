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
			newDish(size);
		}
		public void placeCell(int x, int y, string color)//update a cell on clicks
		{
			foreach (Cell cell in globalDish)
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
				string[] color = { "000000", "000000", "000000", "000000", "000000", "000000", "000000", "000000" };

				//if they are on the top, sides or bottom don't do anything
				if (cell.x == 0 || cell.x == size || cell.y == 0 || cell.y == size)
				{
					//these are the edge pieces we are ignoring.
				}
				//else go through the rules and save everything on the new dish.
				else
				{
					//////*******************************************************************************************

					//check top left 

					//check top

					//check top right

					//left
					
					//right

					//bottom left

					//bottom

					//bottom right
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