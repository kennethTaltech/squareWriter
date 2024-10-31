
namespace Exc3
{
    class IDCodeMatcher
    {
        static void Main()
        {

            // File paths (you can change these paths to match your files' locations)
            string beginningsFilePath = "outputs/beginnings.txt";
            string endingsFilePath = "outputs/endings.txt";

            string restoredFilePath = "outputs/restored_ids.txt";

            // Read the beginnings and endings from their respective files
            List<string> beginnings = File.ReadAllLines(beginningsFilePath).ToList();
            List<string> endings = File.ReadAllLines(endingsFilePath).ToList();

            // Create a list to store the restored IDs
            List<string> restoredIds = new List<string>();

            // Iterate through each beginning to find a matching ending
            foreach (string beginning in beginnings)
            {
                foreach (string ending in endings)
                {
                    // Check if the total length is 11
                    if (beginning.Length + ending.Length == 11)
                    {
                        // Combine the beginning and ending to form the complete ID
                        string restoredId = beginning + ending;
                        restoredIds.Add(restoredId);
                        // Remove the matched ending to prevent re-use
                        endings.Remove(ending);
                        break; // Break inner loop to move to the next beginning
                    }
                }
            }

            // Save the restored IDs to a new file
            File.WriteAllLines(restoredFilePath, restoredIds);

            Console.WriteLine("Restored IDs have been saved to: " + restoredFilePath);
        }
    }
}


