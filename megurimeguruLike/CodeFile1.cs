using SixLabors.ImageSharp;

namespace CreateMap
{
    public class CreatePictures
    {
        public void CreateImage()
        {
            using (var image = new Image<Rgba32>(640, 480))
            {
                for (var y = 0; y < image.Height; y++)
                {
                    for (var x = 0; x < image.Width; x++)
                    {
                        // x, y座標に応じて色を変えて、グラデーションを描画
                        float r = (float)x / image.Width;
                        float g = (float)y / image.Height;
                        float b = 0;
                        image[x, y] = new Rgba32(r, g, b);
                    }
                }
                image.Save(@"C:\Users\A0216\Desktop\test.png");
            }
        }
    }
}