using System;
using System.Text;
namespace integerSetV2
{
	public class IntergerSet
	{

        private int[] arr;
        // Default constructor

        public IntergerSet()
		{
            arr = new int[0];

		}
        // Constructor that takes an array of integers as input

        public IntergerSet(int[] input)
        {
            arr = uniqueElements(input);

        }
        // Constructor that takes a List of integers as input
        public IntergerSet(List<int> input)
        {
            var arraylength = 0;
            var reachEnd = false;

            while (!reachEnd)
            {
                try
                {
                    var val = input[arraylength];
                    arraylength++;


                }
                catch { reachEnd = true; }
            }
            // Create a new array with the calculated length

            var a = new int[arraylength];

            // Copy the elements from the input List to the new array

            for (var i= 0; i < arraylength; i++)
            {
                a[i] = input[i];
            }
            // Store the unique elements of the array in the class variable

            arr = uniqueElements(a);
        }
        // Prints the elements of the integer set

        public void print()
        {
            for(var i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
        // Returns the number of elements in the integer set

        public int magnitude()
        {
            return arr.Length;
        }
        // Checks if the integer set contains a specific value

        public bool contains(int value)
        {
            for (var i = 0; i < arr.Length; i++)
            {
                if (arr[i] == value)
                {
                    return true;

                }else if (arr[i] > value)
                {
                    return false;
                }
            }
            return false;
        }

        /**
   * This method is private and is used to help set up the set array. An integer
   * set is one in which the elements are unique (no duplicates) and are sorted.
   * 
   * @param arr
   *            The array that will be used to retrieve the unique elements from.
   * @return The new integer array that contains the unique elements from arr.
   */
        private int[] uniqueElements(int[] input)
        {
            //TO Do
            //Step 1
            var sorted = mergeSort(input);
            // Step 2 copy the uniqueElements in the array
            var newlength = 0;
            for(var i =0; i < input.Length; i++)
            {
                var currentValue = sorted[i];
                if(i + 1 >= input.Length)
                {
                    newlength++;
                    break;
                }
                var nextValue = sorted[i + 1];
                if(currentValue != nextValue)
                {
                    newlength++;
                }

            }
            var output = new int[newlength];
            var outputIndex = 0;
            for (var i = 0; i < input.Length; i++)
            {
                var currentValue = sorted[i];
                if (i + 1 >= input.Length)
                {
                  
   
                    output[outputIndex] = sorted[i];
                    outputIndex++;
                    break;
                }
                var nextValue = sorted[i + 1];
                if (currentValue != nextValue)
                {
                   
                    output[outputIndex] = sorted[i];
                    outputIndex++;
                }

            }

   
            return output;

        }
        /*
         Custom MergeSort 
         
         */

        public static int[] mergeSort(int[] input)
        {
            var length = input.Length;
            if(length <= 1)
            {
                return input;
            }
            else
            {
                var splitlength = length / 2;
                var arraya = mergeSort(input.Take(splitlength).ToArray());
                var arrayb = mergeSort(input.Skip(splitlength).ToArray());
                return merge(arraya, arrayb, length);
            }
        
        }
        private static int[] merge(int[]a, int[]b, int length)
        {
            var output = new int[length];
            var aindex = 0;
            var bindex = 0;
            for(var i = 0; i < length; i++)
            {
                if (a.Length > aindex && b.Length > bindex)
                {
                    if (a[aindex] < b[bindex])
                    {
                        output[i] = a[aindex];
                        aindex++;
                    }
                    else
                    {
                        output[i] = b[bindex];
                        bindex++;
                    }
                }
                else if(a.Length > aindex)
                {
                    output[i] = a[aindex];
                    aindex++;
                }
                else if (b.Length > bindex)
                {
                    output[i] = b[bindex];
                    bindex++;
                }
            }
            return output;
        }

                /**
         * A union of two sets is a new set that contains all elements from both sets.
         * This method takes another set and unions it with the set that calls this
         * method. A new IntegerSet is returned that contains the union of both sets.<br />
         * Example:
         * <pre>
         * 		IntegerSet is1 = new IntegerSet([1, 2, 3, 4]); 
         * 		IntegerSet is2 = new IntegerSet([3, 4, 5, 6, 7, 8]);
         * 		is1.union(is2) //returns new IntegerSet([1, 2, 3, 4, 5, 6, 7, 8]);
         * </pre>
         * 
         * @param otherSet
         *            The set to be unioned with.
         * @return A new IntegerSet that is the union of the calling set with the
         *         otherSet.
         */
        public IntergerSet union(IntergerSet otherSet)
        {
            //* A union of two sets is a new set that contains all elements from both sets.
            int[] unionArray = new int[arr.Length + otherSet.magnitude()];
            int index = 0;

            for (var i = 0; i < unionArray.Length; i++)
            {
                if(i < arr.Length)
                {
                    unionArray[i] = arr[i];

                }
                else
                {
                    unionArray[i] = otherSet.arr[index];
                    index++;
                }
            }
            return new IntergerSet(unionArray);



        }
        public string ToString()
        {
             StringBuilder sb = new StringBuilder();
            sb.Append("arr{ ");
            for(int i = 0; i < arr.Length; i++)
            {
                sb.Append(arr[i]);
                if(i < arr.Length -1)
                {
                    sb.Append(", ");
                }
            }
            sb.Append(" }");
            return sb.ToString();
        }
    }
}

