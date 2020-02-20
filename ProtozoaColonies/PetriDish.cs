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

	public newDish(int x, int y) //create a new board
	{
		dish = new Cell[x, y];
	}
	public cleanDish() //wipe the board
    {
		int i = dish.GetLength();
		dish = new Cell[i];
    }
	public placeCell(int x, int y, string color)//update a cell on clicks
    {
		dish[x, y].color = color;
    }
	public checkDish()//go to next state
    {
		//create new dish to return.

		//if they are on the top, sides or bottom don't do anything

		//else go through the rules and save everything on the new dish.

		//once this is done overwrite the old dish and clear the new dish.
    }
	public shareDish()//give dish back.
    {
		return dish;
    }
}
