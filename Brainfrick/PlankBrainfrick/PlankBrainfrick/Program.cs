using System;

namespace PlankBrainfrick
{
	class MainClass
	{
        //public static string textpath = "C:/Users/Keagan/Documents/Plank/Brainfrick/code.txt";
		public static string imagepath =
			"C:/Users/Keagan/Documents/Plank/Brainfrick/Scripts/helloworld_disorganised_16.png";

		public static void Main(string[] args)
		{
			Console.WriteLine("Getting Command Buffer...");
            /*
			string commandBuffer = File.ReadAllText(textpath).Trim().Replace("\n", string.Empty);
            commandBuffer = commandBuffer.Replace(" ", string.Empty);
            */
            ImageParser imageParser = new ImageParser(imagepath);
            string commandBuffer = imageParser.GetCommandBuffer();
            Console.WriteLine("Command buffer:\n" + commandBuffer + "\n");

            RunCode(commandBuffer);
        }

		public static void RunCode(string commandBuffer) 
		{
			Console.WriteLine("Output:\n");

			int[] memory = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
			int memoryPointer = 0;
			string result = "";

			for (int i = 0; i < commandBuffer.Length; ++i)
			{
				if (commandBuffer[i] == ',')
				{
					Console.Clear();
					Console.Write("Provide input: ");
					string input = Console.ReadLine();
					memory[memoryPointer] = Convert.ToInt32(input);
				}
				else if (commandBuffer[i] == '.')
				{
					Console.Write(Convert.ToChar(memory[memoryPointer]));
					result += Convert.ToChar(memory[memoryPointer]);
				}
				else if (commandBuffer[i] == '<')
				{
					memoryPointer--;
				}
				else if (commandBuffer[i] == '>')
				{
					memoryPointer++;
				}
				else if (commandBuffer[i] == '+')
				{
					memory[memoryPointer] += 1;
				}
				else if (commandBuffer[i] == '-')
				{
					memory[memoryPointer] -= 1;
				}
				else if (commandBuffer[i] == '[')
				{
					if (memory[memoryPointer] == 0)
					{
						int skip = 0;
						int ptr = i + 1;
						while (commandBuffer[ptr] != ']' || skip > 0)
						{
							if (commandBuffer[ptr] == '[')
							{
								skip += 1;
							}
							else if (commandBuffer[ptr] == ']')
							{
								skip -= 1;
							}
							ptr += 1;
							i = ptr;
						}
					}
				}
				else if (commandBuffer[i] == ']')
				{
					if (memory[memoryPointer] != 0)
					{
						int skip = 0;
						int ptr = i - 1;
						while (commandBuffer[ptr] != '[' || skip > 0)
						{
							if (commandBuffer[ptr] == ']')
							{
								skip += 1;
							}
							else if (commandBuffer[ptr] == '[')
							{
								skip -= 1;
							}
							ptr -= 1;
							i = ptr;
						}
					}
				}
			}

            Console.WriteLine("\n\nProgram finished.");
        }
	}
}
