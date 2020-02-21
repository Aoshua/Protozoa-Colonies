using System;

public class Cell // object to keep track of the squares
{
	private int x { get; set; }
	private int y { get; set; }
	private string color { get; set; }
	private Cell(int x, int y, string color) //if x and y we have to do a 2 d array on PitriDish.
    {
		this.x = x;
		this.y = y;
		this.color = color;
    }
}

public class PitriDish  //object to keep track of the board
{
	private Cell[] dish { get; set; }
	private int size { get; set; }
	public PitriDish newDish(int i) //create a new board of i x values and i y values.
	{
		dish = new Cell[i, i];
		return dish;
	}
	public PitriDish cleanDish(PitriDish dish) //wipe the board
    {
		size = dish.size();
		cleanedDish = new Cell[size, size];
		return cleanedDish;
    }
	public PitriDish placeCell(PitriDish dish, int x, int y, string color)//update a cell on clicks
    {
		dish[x, y].color = color;
		return dish;
    }
	public PitriDish checkDish(PitriDish dish)//go to next state
	{
		size = dish.size();
		//create new dish to return.
		newDish = new PitriDish(size);

		// loop through the whole table ( x and y)
		for (int i = 0; i < size; s++)
		{
			for (int j = 0; j < size; j++)
			{
				//if they are on the top, sides or bottom don't do anything
				if(i==0 || i==size || j==0 || j == size)
                {
					//these are the edge pieces we are ignoring.
                }
                //else go through the rules and save everything on the new dish.
                else
                {

                }

			}
		}
		//once this is done overwrite the old dish and clear the new dish.
		return newDish;
    }
	public PitriDish shareDish()//give dish back.
    {
		return dish;
    }
}
