// 8.6 Towers of Hanoi:
// In the classic problem of the Towers of Hanoi, you have 3 towers and N disks of different
// sizes which can slide onto any tower. The puzzle starts with disks sorted in ascending
// order of size from top to bottom (i.e., each disk sits on top of an even larger one).
// You have the following constraints:
// (1) Only one disk can be moved at a time.
// (2) A disk is slid off the top of one tower onto another tower.
// (3) A disk cannot be placed on top of a smaller disk.

// Write a program to move the disks from the first tower to the last using stacks.



//							    "a to b"
//							   /		\
//							/				\
//					   "a to c"		 		"c to b"
//					/			\		 	  /		\
//				"a to b"	"b to c"	"c to a"	"a to b"

// Output:
// Move disk from A To B
// Move disk from A To C
// Move disk from B To C
// Move disk from A To B
// Move disk from C To A
// Move disk from C To B
// Move disk from A To B

// The solution is to perform an inorder traverse. Since we are doing Console.WriteLine(a + " To " + b) we need to match the variables 'a' and 'b' with the order of the parameters.
// Eg. First step for a 2 disk is "a to c".
// Root node is "a to b".
// Left node is "a to c". Hence I switch paramters for b and c. From SolveTowers(n - 1, a, b, c) to SolveTowers(n - 1, a, c, b);
// Right node is "c to b". Notice, b remains the same but a changes to c, hence we move from SolveTowers(n - 1, a, b, c) to SolveTowers(n - 1, c, b, a).
// Tree height is equal to number of disks minus 1. Because 1 disk is only one node, hence height of 0.

 so I want to order the paramters such that I get the variables in the WriteLine(a + "to" + b) a to match with a since write
static void Main(string[] args)
{
	char a = 'A'; // start tower in output
	char b = 'B'; // end tower in output
	char c = 'C'; // temporary tower in output
	int Disks = 3; // number of disks

	SolveTowers(Disks, a, b, c);
}
public static void SolveTowers(int n, char a, char b, char c)
{
	if(n <= 0) return;

	SolveTowers(n - 1, a, c, b);
	Console.WriteLine("Move disk from " + a + " To " + b);
	SolveTowers(n - 1, c, b, a);
}

