using System;
	using System.Globalization;

	static class ToStringExt
	{
		static string[] _cache =
		{
		"0",
		"1",
		"2",
		"3",
		"4",
		"5",
		"6",
		"7",
		"8"};
		
		const byte _top = 8;

		public static string ToStringLookup(this byte value)
		{

			if (value >= 0 &&
				value <= _top)
			{
				return _cache[value];
			}

			return value.ToString(CultureInfo.InvariantCulture);
		}
	}
		
public class Program
{
public void Main()
{
	var ROWS = 100;            // amount of horizontal tiles
	var COLS = 100;            // amount of vertical tiles
	var LAST_ROW_INDEX = ROWS - 1;  // last element index in column
	var LAST_COL_INDEX = COLS - 1;  // last element index in row
	
	var board = new bool[ROWS,COLS]; // stores mines using True and False
	var arr = new byte[ROWS,COLS];   // stores mine count values
	
	Random rnd = new Random();
	
	for (var a = 0; a < ROWS; a++) {
		for (var b = 0; b < COLS; b++) {
			
			// place bomb in element
			var val = (rnd.Next(1,50)%5 == 1);
			board[a,b] = val;
			
			// print out 'X' for bomb and 'O' for empty space
			var c = val ? 'X' : 'O';
			Console.Write(c);
			
			// pad the output
			if (b < LAST_COL_INDEX) {
				Console.Write(' ');
			}
			
			// edge detect
			var isLeftEdge = (b == 0);
	  		var isTopEdge = (a == 0);
	   	    var isRightEdge = (b == LAST_ROW_INDEX);
	   	    var isBottomEdge = (a == LAST_COL_INDEX);
			
			// increment bomb counts
			if (val) {				   			
				
		      // check left
		      if (!isLeftEdge) { arr[a,b-1]++; }
			  if (!isTopEdge) { arr[a-1,b]++; }
			  if (!isRightEdge) { arr[a,b+1]++; }
		      if (!isBottomEdge) { arr[a+1,b]++; }
				   
			  // check diagnals
			  if (!isLeftEdge && !isTopEdge) { arr[a-1,b-1]++;}
		      if (!isLeftEdge && !isBottomEdge) { arr[a+1,b-1]++;}
			  if (!isRightEdge && !isTopEdge) { arr[a-1,b+1]++;}
			  if (!isRightEdge && !isBottomEdge) { arr[a+1,b+1]++;}
			}
			
		}
		Console.WriteLine();
	}
	
	Console.WriteLine();

	for (var a = 0; a < ROWS; a++) {
		for (var b = 0; b < COLS; b++) {
			if (board[a,b]) {
				Console.Write('B');
			} else {
				Console.Write(arr[a,b].ToStringLookup());
			}
			
			if (b < LAST_COL_INDEX) {
				Console.Write(' ');
			}
		}
		Console.WriteLine();
	}
}
}
