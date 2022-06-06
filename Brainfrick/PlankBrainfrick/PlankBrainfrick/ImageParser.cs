using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PlankBrainfrick
{
    public class ImageParser
    {
        public string path { get; set; }

        public ImageParser(string imagePath) 
        {
            path = imagePath;
        }
        
        public string[] GetPixels() 
        {
            List<string> pixels = new List<string>();

            if (File.Exists(path))
            {
                var bitmap = new Bitmap(path);

                for (int x = 0; x < bitmap.Width; x++)
                {
                    for (int y = 0; y < bitmap.Height; y++)
                    {
                        var pixel = bitmap.GetPixel(y, x);
                        string pixelData = ColorTranslator.ToHtml(pixel);
                        pixels.Add(pixelData);
                    }
                }
            }
            else 
            {
                throw new FileNotFoundException("Could not find a file at path " + path);
            }

            return pixels.ToArray();
        }

        public string GetCommandBuffer()
        {
            string[] pixels = GetPixels();
            string commandBuffer = "";

            for (int i = 0; i < pixels.Length; i++)
            {
                switch (pixels[i])
                {
                    case "#000000":
                        commandBuffer += ".";
                        break;
                    case "#888888":
                        commandBuffer += ",";
                        break;
                    case "#0000FF":
                        commandBuffer += "+";
                        break;
                    case "#FF0000":
                        commandBuffer += "-";
                        break;
                    case "#FF00FF":
                        commandBuffer += "<";
                        break;
                    case "#00FF00":
                        commandBuffer += ">";
                        break;
                    case "#00FFCC":
                        commandBuffer += "[";
                        break;
                    case "#FF8800":
                        commandBuffer += "]";
                        break;
                }
            }
            
            return commandBuffer;
        }
    }
}
