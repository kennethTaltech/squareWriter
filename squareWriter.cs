
namespace Exc4
{
    class NumericSquareWriter
    {
        public static void WriteNumericSquareToFile(int number, string filePath)
        {

            // To append, use ", append: true" in streamWriter arguments
            using (StreamWriter sw = new StreamWriter(filePath)) {

                // Write the same line 'number' times
                for (int i = 0; i < number; i++)
                {
                    // Create a single line for the square, using new string
                    // 
                    // This is super optimized because we don't even use
                    // any lists or arrays, which helps us save memory. It also
                    // helps save time
                    sw.WriteLine(new string(number.ToString()[0], number));
                }

            }

            Console.WriteLine($"Numeric square of {number}*{number} written to file: {filePath}");

        }

        static void Main()
        {
            // Ask the user for a number
            Console.Write("Enter a number for the square size: ");
            string input = Console.ReadLine();

            // Try to parse the input to an integer
            if (int.TryParse(input, out int number) && number > 0)
            {
                // Check if the folder exists
                if (!Directory.Exists("outputs"))
                {
                    // If the folder doesn't exist, create it
                    Directory.CreateDirectory("outputs");
                    Console.WriteLine("Folder created: " + "outputs");
                }

                // Change the file path to a known location
                string filePath = "outputs/numeric_square.txt";

                // Generate the numeric square
                WriteNumericSquareToFile(number, filePath);

                // Display current directory for better user experience
                Console.WriteLine("Current Directory: " + Directory.GetCurrentDirectory());
            }
            else
            {
                Console.WriteLine("Please enter a valid positive integer.");
            }
        }
    }

}


