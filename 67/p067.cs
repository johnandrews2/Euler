void Main()
{
	Stopwatch clock = Stopwatch.StartNew();
	
	string filename = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\p067_input.txt";
    int[,] inputTriangle = readInput(filename);
	
	int lines = inputTriangle.GetLength(0);
	int cols = inputTriangle.GetLength(1);
	for (int i=lines-2; i >= 0; i--)
	{
		cols --;
		for (int j=0; j < cols; j++)
		{
			inputTriangle[i,j] = inputTriangle[i, j] + Math.Max(inputTriangle[i+1, j], inputTriangle[i+1, j+1]);
		}
	}
	
	clock.Stop();       
	Console.WriteLine("The largest sum through the triangle is: {0}", inputTriangle[0,0]);
	Console.WriteLine("Solution took {0} ms", clock.ElapsedMilliseconds);
}

// Define other methods and classes here


private int[,] readInput(string filename) {
            string line;
            string[] linePieces;
            int lines = 0; 
           
            StreamReader r = new StreamReader(filename);
            while ((line = r.ReadLine()) != null) {
                lines++;
            }           

            int[,]  inputTriangle = new int[lines, lines];
            r.BaseStream.Seek(0, SeekOrigin.Begin);

            int j = 0;
            while ((line = r.ReadLine()) != null) {
                linePieces = line.Split(' ');
                for (int i = 0; i < linePieces.Length; i++) {
                    inputTriangle[j, i] = int.Parse(linePieces[i]);
                }
                j++;
            }

            r.Close();

            return inputTriangle;
        }
