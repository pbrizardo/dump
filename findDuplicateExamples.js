//////////////////////////////////////////////////////////
// Algorithms for finding duplicates
//
//

/* 1. Using javascript arrays only. 
	
	A versatile method where the goal is to dump all elements into
	a sorted array. The adjacent elements will be compared and
	duplicates are spliced out of the array. Not sure how it would 
	perform with large data sets.
*/

var arr1 = [ 'hello', 'kitty', 'a', 'b', 'd', 'off', 'on' ];
var arr2 = [ 'kitty', 'c', 'clutch' ];

for (var i = 0; i < arr2.length; i++) { arr1.push(arr2[i]); }
arr1.sort();

console.log('Sorted array: ' + arr1);

// Run through the array
var cursor = 1;
while(cursor < arr1.length) {
	if (arr1[cursor] === arr1[cursor-1]) { arr1.splice(cursor,1); }
	else { cursor++; }
}

console.log('Duplicates removed: ' + arr1);

/* 2. Using ECMA 6 Set object

	Used only in the scenario if you don't want to add duplicates to
	a current set. Unfortunately, this has cross-browser issues. *cough* IE < 11 *cough*.	
*/

arr1 = [ 'hello', 'kitty', 'a', 'b', 'd', 'off', 'on' ];
arr2 = [ 'kitty', 'c', 'clutch' ];

var set = new Set(arr1);
console.log('Set before:');
console.log(set);

for (var i = 0; i < arr2.length; i++) { set.add(arr2[i]); }
console.log('Set after:');
console.log(set);