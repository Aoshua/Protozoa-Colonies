using System;

namespace ProtozoaColonies.Models
{
	public class Cell // object to keep track of the squares
	{
		public int x { get; set; }//where it is on the x axis
		public int y { get; set; }//where it is on the y axis
		public string color { get; set; }//what color it is.
		public Cell(int x, int y, string color) //if x and y we have to do a 2 d array on PitriDish.
		{
			this.x = x;
			this.y = y;
			this.color = color;
		}
	}
}
