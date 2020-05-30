using System.Collections.Generic;

namespace AppResolution.Models
{
    public class Resoltion
    {
        public Resoltion(int width, int height)
        {
            this.Height = height;
            this.Width = width;

            var dimension = new Dictionary<string, int>();
            dimension.Add("Height", height);
            dimension.Add("Width", width);

            this.Dimensions = dimension;
        }

        public int Height { get; set; }

        public int Width { get; set; }

        public Dictionary<string, int> Dimensions { get; set; }
    }
}
