public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // My plan to solve this problem is as follows:

        // First, create an array of doubles with the size 'length'.
        // This array will store all the multiples we calculate.
        // For example if we have a length of 5, we will create an array that has 5 empty slots.

        // Secondly, loop through each position in the array using a for loop.
        // The loop will run from index 0 to index length -1.
        // The loop counter i, will represent the current array index.

        // Third, Calculate the multiple for each index position.
        // This will be done by multiplying the number by (i + 1).
        // We use (i + 1) because when i = 0, we want the first multiple to be number x 1, and when i = 1, we want the second multiple to be number x 2, and so on.

        // Fourth, store the calculated multiple from the third step in the array at position i.
        // After the loop finishes, all positions in the array will be filled.
        // Return the array with the multiples.


        // First step: Create an array to hold all the multiples
        double[] multiples = new double[length];

        // Second step: Loop through each index of the array
        for (int i = 0; i < length; i++)
        {
            // Third step: Calculate the multiple for the current position
            // Use (i + 1) to get the multiplier number
            double multiple = number * (i + 1);

            // Fouth step: Store the calculated number in the array at index i
            multiples[i] = multiple;
        }

        //Lastly: Return the completed array with all multiples
        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // My plan to solve this problem is as follows:
        // Step 1; Calculate the point where the split will happen.
        // We will do this by subtracting the amount from the total elements in the list.
        // That is if we have a list with 6 elements and we want to rotate by 2, we will split at index 4 (6 - 2 = 4).

        // Step 2; Extract the right part that would be moved to the front.
        // We wil do this by using the getRange method, with the starting index as the split point and the count as the amount.

        // Step 3; Extract the left part that will remain after the rotation.
        // We will do this by using the getRange method, with the starting index as 0 and the count as the split point.

        // Step 4; Clear the original list so we can build the list in the rotated order.

        // Step 5; Add the right part to the front of the list.
        // We will use the AddRange method to add all elements from the right part.

        // Step 6; Add the left part to the end of the list.
        // We will use the AddRange method to add all elements from the left part.

        //Step 1: Calculate the split point
        int splitPoint = data.Count - amount;

        //Step 2: Extract the right part to be moved to the front
        List<int> rightPart = data.GetRange(splitPoint, amount);

        //Step 3: Extract the left part that will remain after rotation
        List<int> leftPart = data.GetRange(0, splitPoint);

        //Step 4: Clear the original list
        data.Clear();

        //Step 5: Rebuild the list with the right part at the front
        data.AddRange(rightPart);

        //Step 6: Add the left part to the end of the new list
        data.AddRange(leftPart);
    }
}
