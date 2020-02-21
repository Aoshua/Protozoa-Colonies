using System;

namespace Cells
{
	public class Cell // object to keep track of the squares
	{
		protected int x { get; set; }
		protected int y { get; set; }
		protected string color { get; set; }
		private Cell(int x, int y, string color) //if x and y we have to do a 2 d array on PitriDish.
		{
			this.x = x;
			this.y = y;
			this.color = color;
		}
	}
}
