using System;

private class Cell // object to keep track of the squares
{
	private int x { get; set; }
	private int y { get; set; }
	private string color { get; set; }
	private Cell(int x, int y, string color)
    {
		this.x = x;
		this.y = y;
		this.color = color;
    }
}

public class PitriDish  //object to keep track of the board
{
	private Cell[] dish { get; set; }

	public newDish(int num) //create a new board
	{
		dish = new Cell[num];
	}
	public cleanDish() //wipe the board
    {
		int i = dish.GetLength();
		dish = new Cell[i];
    }
	public placeCell(int x, int y, string color)//update a cell on clicks
    {
		dish[i].x = x;
		dish[i].y = y;
		dish[i].color = color;
    }
	public checkDish()//go to next state
    {

    }
	public shareDish()//give dish back.
    {

    }
}
