using System;
					
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
	
	var boardArr = new string[LENGTH]; // stores board values
	var arr = new int[LENGTH];         // stores mine count values
	var count = 0;
	var row = 0;
	
	for (var i = 0; i < LENGTH; i++) {
	
	   // detect of row
       var isEndOfLine = (count == MAX_ARR_X);
		
	   // randomly generate value
	   var val = (rnd.Next(1,50)%5 == 1);
	   board[i] = val;
       var c = val ? "X" : "O";
	   boardArr[i] = c;
	   Console.Write(c);
		
	   // print out padding
	   if (i < LENGTH) {
	      Console.Write(" ");
	   }

	   // print next line if end of row, and reset count
	   if (isEndOfLine) Console.Write('\n');
	   count = (isEndOfLine) ? 0 : count + 1;
		
	   // edge detection valdiation
	   var isLeftEdge = (i == row*MAX_X);
	   var isTopEdge = (i <= MAX_ARR_X);
	   var isRightEdge = (i == row*MAX_ARR_X);
	   var isBottomEdge = i >= LENGTH-1 - MAX_X;
		
	   if (val) {
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
		
	   row++;
	}	
	
	Console.WriteLine("");
	
	// print mine count
	count = 0;
	for (var i = 0; i < LENGTH; i++) {
		var isEndOfLine = (count == MAX_ARR_X);
		Console.Write(arr[i]);
		if (i < LENGTH) {
           Console.Write(" ");
		}
		
		if (isEndOfLine) Console.Write('\n');
		count = (isEndOfLine) ? 0 : count + 1;
	}
}
}
