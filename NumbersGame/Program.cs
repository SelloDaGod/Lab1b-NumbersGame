namespace NumbersGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                StartSequence();
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Format Exception: {ex.Message}");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine($"Overflow Exception: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Program completed.");
            }
        }
        static void StartSequence()
        {
            Console.WriteLine("Entr a number greater than zero:");

            int size = Convert.ToInt32(Console.ReadLine());
            int[] numbers = new int[size];
            Populate(numbers);

            int sum = GetSum(numbers);
            int product = GetProduct(numbers, sum);
            decimal quotient = GetQuotient(product);

            Console.WriteLine($"Sum: {sum}\nProduct: {product}\nQuotient: {quotient}");
        }
        static void Populate(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write($"Please enter number {i + 1}/{numbers.Length}: ");
                numbers[i] = Convert.ToInt32(Console.ReadLine());
            }
        }
        static int GetSum(int[] numbers)
        {
            int sum = 0;
            foreach (int number in numbers)
                sum += number;

            if (sum < 20)
                throw new Exception($"Value of {sum} is too low");

            return sum;
        }
        static int GetProduct(int[] numbers, int sum)
        {
            Console.WriteLine("Select a random number between 1 and the length of the array:");
            int randomNumber = Convert.ToInt32(Console.ReadLine());

            if (randomNumber < 1 || randomNumber > numbers.Length)
                throw new IndexOutOfRangeException("Index out of range");

            return sum * numbers[randomNumber - 1];
        }

        static decimal GetQuotient(int product)
        {
            Console.WriteLine($"Enter a number to divide the product ({product}) by: ");
            int divisor = Convert.ToInt32(Console.ReadLine());

            if (divisor == 0)
            {
                Console.WriteLine("Divide by zero exception");
                return 0;
            }

            return decimal.Divide(product, divisor);
        }
    }
}


        