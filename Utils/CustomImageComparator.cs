using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Visualization;
using System.Drawing;

namespace VK_API.Utils
{
    public class CustomImageComparator
    {
        private readonly ImageComparator imageComparator;

        public CustomImageComparator(float defaultThreshold, int comparisonWidth, int comparisonHeight)
        {
            var visualizationConfiguration = new VisualizationConfiguration(defaultThreshold, comparisonWidth, comparisonHeight);
            imageComparator = new ImageComparator(visualizationConfiguration);
        }
        public float Compare(Image firstImage, Image secondImage, float? threshold = null)
        {
            return imageComparator.PercentageDifference(firstImage, secondImage, threshold);
        }
    }
    internal class VisualizationConfiguration : IVisualizationConfiguration
    {
        public float DefaultThreshold { get; }
        public int ComparisonWidth { get; }
        public int ComparisonHeight { get; }

        public string PathToDumps => throw new NotImplementedException();
        public ImageFormat ImageFormat => throw new NotImplementedException();
        public int MaxFullFileNameLength => throw new NotImplementedException();

        public VisualizationConfiguration(float defaultThreshold, int comparisonWidth, int comparisonHeight)
        {
            DefaultThreshold = defaultThreshold;
            ComparisonWidth = comparisonWidth;
            ComparisonHeight = comparisonHeight;
        }
    }
}
