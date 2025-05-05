using DAL.Repositories;

namespace BUS.Helpers
{
    public static class IDGenerator
    {
        public static string GenerateID(string prefix, int length, string maxId)
        {
            if (string.IsNullOrEmpty(maxId))
            {
                return prefix + "00001";
            }
            else
            {
                int currentNumber = int.Parse(maxId.Substring(prefix.Length));
                int newNumber = currentNumber + 1;
                return prefix + newNumber.ToString("D" + (length - prefix.Length));
            }
        }
    }
}
