using System;


namespace Cells
{
	public PitriDish globalDish;
	public int globalSize;

	public class PitriDish  //object to keep track of the board
	{
		private Cell[] dish { get; set; }
		public newDish(int size) //create a new board of i x values and i y values. work on this.
		{
			List<Cell> dish = new List<Cell>();
			
			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
					dish.Add(new Cell { i, j, "000000" });
				}
			}
			globalDish = dish;
			globalSize = size;
		}
		public cleanDish() //wipe the board
		{
			newDish(publicDish.Size());
		}
		public placeCell(int x, int y, string color)//update a cell on clicks
		{
			foreach (Cell cell in globalDish)
				if (globalDish.GetValue.x = x && globalDish.GetValue.y)
				{
					globalDish.GetValue.color = color;
					break;
				}
		}
		public checkDish(PitriDish dish)//go to next state
		{
			size = dish.size();
			//create new dish to return.
			newDish = new PitriDish(size);

			// loop through the whole table ( x and y)
			foreach (Cell cell in globalDish)
			{
				int adjAlive = 0;
				string[8] color = { "000000", "000000", "000000", "000000", "000000", "000000", "000000", "000000" };

				//if they are on the top, sides or bottom don't do anything
				if (i == 0 || i == size || j == 0 || j == size)
				{
					//these are the edge pieces we are ignoring.
				}
				//else go through the rules and save everything on the new dish.
				else
				{
					//////*******************************************************************************************
					//get list size and square root it to get how biga row is.
					int size = sqrt(globalDish.size());

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
		public shareDish()//give dish back.
		{
			return globalDish;
		}
	}
}