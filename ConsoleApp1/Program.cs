namespace ConsoleApp1
{
    internal class Program
    {
        public int[] productExceptSelf(int[] nums)
        {
            int n = nums.Length;
            int[] res = new int[n];

            int left = 1;
            int right = 1;

            for (int i = 0; i < n; i++)
            {
                res[i] = left;
                left *= nums[i];
            }

            for (int i = n - 1; i >= 0; i--)
            {
                res[i] *= right;
                right *= nums[i];
            }

            return res;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
