using System;


namespace FirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Title: C# Odd/Even Sorter Practice
            //Purpose: allows user to enter 10 values and sort them by odd and even values
            //print output one after another meaning first all odds then all evens
            //Author: Oleg Eremeev
            //Date: 13 Aug 2020
          
            int runApp;
            do                   //do loop to run main method which prompts user to enter 0 to Exit or any other number to restart the program
            {

            Console.WriteLine("This program will allow to enter intigers from 1-10 \n and then it will sort them by even and odd numbers");
            int[] myNumbers = new int[10];

            PopulateArray(myNumbers);

            // foreach is useful for shorthand output but CANNOT edit array items, they will be marked as readonly.
                foreach(int number in myNumbers)  
            {
                //Console.WriteLine(number);
                if (number % 2 == 0)
                {
                    Console.Write("EVEN: " + number+ "   ");
                    
                }
                else if (number % 2 != 0)
                { 
                    Console.Write("ODD: " + number + "\n");
                    
                }
            }                           
                        
            /*
            int[] evenDig = new int[5];  // Help advise provided by (Aaron Barthel Aug 13)  from here              
            int[] oddDig = new int[5];
            int evenIndex = 0;
            int oddIndex = 0;                
            
            foreach(int number in myNumbers)  
            {
                Console.WriteLine(number);
                if (number % 2 == 0)
                {
                    evenDig[evenIndex] = number;
                    evenIndex++;
                }
                else 
                { 
                   oddDig[oddIndex] = number;
                   oddIndex++;
                }
            }                           // to here (Aaron Barthel Aug 13)

            Array.Sort(evenDig, 0, 5); // https://docs.microsoft.com/en-us/dotnet/api/system.array.sort?view=netcore-3.1#System_Array_Sort_System_Array_
            Array.Sort(oddDig, 0, 5);  
         
            int [] jointArray = new int[oddDig.Length + evenDig.Length]; //JointArray variable 
            Array.Copy(oddDig, jointArray, oddDig.Length); // Array.Copy 
            Array.Copy(evenDig, 0, jointArray, oddDig.Length, evenDig.Length);
            Console.WriteLine("[{0}]", string.Join(", ", jointArray)); //string.format method, string.Join method
            */

            Console.WriteLine("Press \"0\" to EXIT or any other number to restrart the Application");
            runApp = int.Parse(Console.ReadLine());
            }
            while (runApp != 0); //EXIT App if user press 0

            /*
            The above loop is exactly the same as this:
            for (int i = 0; i < myNumbers.Length; i++)
            {
                Console.WriteLine(myNumbers[i]);
            }
            */
        }
        // No return type due to the array being passed by reference (memory address) so any edits will affect the original.
        static void PopulateArray(int[] theArray)
        {
            for(int i = 0; i < theArray.Length; i++)
            {
                theArray[i] = GetValidInt($"Please enter equal amount of odd and even numbers integers #{i+1}: ", 1, 100);
            }
        }

        static int GetValidInt(string prompt, int min, int max)
        {
            bool valid = false;
            int myInt = -1;

            do
            {
                Console.Write(prompt);
                try
                {
                    myInt = int.Parse(Console.ReadLine());
                    if (myInt < min || myInt > max)
                    {
                        throw new Exception("Provided integer was outside of the bounds specified.");
                    }
                    valid = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Parse failed: {ex.Message}");
                }
            } while (!valid);

            return myInt;
        }
    }
}