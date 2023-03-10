using System.Drawing;

namespace VK_API.Utils
{
    public class ImagesComparator
    {
        public static bool CheckThatActualAndExpectedImagesAreTheSame(string expectedImageResourse, float customThresholdValue, string modelImageResourses)
        {
            var expectedImage = Image.FromFile(expectedImageResourse);
            var modelOfImage = Image.FromFile(modelImageResourses);
            CustomImageComparator customImageComparator = new CustomImageComparator(customThresholdValue, modelOfImage.Width, modelOfImage.Height);
            return customImageComparator.Compare(modelOfImage, expectedImage) == 0;
        }
    }
}
