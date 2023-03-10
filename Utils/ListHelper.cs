namespace VK_API.Utils
{
    public static class ListHelper
    {
        public static bool CompareItemsInList(List<int> list, int id)
        {
            foreach (int item in list)
            {
                if (item == id) return true;
            }
            return false;
        }
    }
}
