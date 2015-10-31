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
	var MAX_X = 100; 
	var MAX_ARR_X = MAX_X - 1;
	var MAX_Y = 100; 
	var LENGTH = MAX_X*MAX_Y;
	bool[] board = new bool[LENGTH];
	
	Random rnd = new Random();
	
	var arr = new byte[LENGTH];         // stores mine count values
	var count = 0;
	var row = 0;
	var begIndex = 0;
	var endIndex = 0;
	
	for (var i = 0; i < LENGTH; i++) {
	
	   // detect of row
	   var isBeginning = (count == 0);
       var isEndOfLine = (count == MAX_ARR_X);
	   
		if (isBeginning) {
		  begIndex = i;
		  endIndex = i + MAX_ARR_X;
		}
		
	   // randomly generate value
	   var val = (rnd.Next(1,50)%5 == 1);
	   board[i] = val;
		
	   // print value
       var c = val ? "X" : "O";
	   Console.Write(c);
		
	   // print out padding
	   if (i < LENGTH) {
	      Console.Write(" ");
	   }

	   // print next line if end of row, and reset count
	   if (isEndOfLine) Console.Write('\n');
	   count = (isEndOfLine) ? 0 : count + 1;
	   
	   // edge detection valdiation
	   
	   var isLeftEdge = (i == begIndex);
	   var isTopEdge = (i <= MAX_ARR_X);
	   var isRightEdge = (i == endIndex);
	   var isBottomEdge = (i >= LENGTH-1 - MAX_X);
	   
		
	   if (val) {
		   // increm bomb pos
		   arr[i]++;
		   
	       // check left
		   if (!isLeftEdge) { arr[i-1]++; }
		   if (!isTopEdge) { arr[i-MAX_X]++; }
		   if (!isRightEdge) { arr[i+1]++; }
		   if (!isBottomEdge) { arr[i+MAX_X]++; }
		   
		   // check diagnals
		   if (!isLeftEdge && !isTopEdge) { arr[(i-MAX_X-1)]++;}
		   if (!isLeftEdge && !isBottomEdge) { arr[(i+MAX_X-1)]++;}
		   if (!isRightEdge && !isTopEdge) { arr[(i-MAX_X+1)]++;}
		   if (!isRightEdge && !isBottomEdge) { arr[(i+MAX_X+1)]++;}
	   }
		
	   // increm row count
	   if (isEndOfLine) { row++; }
	}	
	
	Console.WriteLine("");
	
	// print mine count
	count = 0;
	for (var i = 0; i < LENGTH; i++) {
		var isEndOfLine = (count == MAX_ARR_X);
		if (board[i]) {
			Console.Write("0");
		} else {
			Console.Write(arr[i].ToStringLookup());
		}
									
		if (i < LENGTH) {
           Console.Write(" ");
		}
		
		if (isEndOfLine) Console.Write('\n');
		count = (isEndOfLine) ? 0 : count + 1;
	}
}
}
