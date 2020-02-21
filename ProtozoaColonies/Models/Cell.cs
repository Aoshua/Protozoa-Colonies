using System;

namespace Cells
{
	public class Cell // object to keep track of the squares
	{
		public int x { get; set; }
		public int y { get; set; }
		public string color { get; set; }
		public Cell(int x, int y, string color) //if x and y we have to do a 2 d array on PitriDish.
		{
			this.x = x;
			this.y = y;
			this.color = color;
		}
	}
}
