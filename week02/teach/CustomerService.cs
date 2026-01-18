/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService
{
    public static void Run()
    {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: Create queue with valid max size and add customers 
        // Expected Result: Customers added successfully, queue sizes increases correctly
        Console.WriteLine("Test 1");
        Console.WriteLine("Creating queue with max sixe of 3");
        var cs1 = new CustomerService(3);
        Console.WriteLine(cs1);

        //Manually add three customers
        Console.WriteLine("Adding Customer 1");
        cs1._queue.Add(new Customer("Ben", "B001", "Unable to login"));
        Console.WriteLine($"After add 1: {cs1}");

        Console.WriteLine("Adding Customer 2");
        cs1._queue.Add(new Customer("Daniel", "DOO4", "Password reset"));
        Console.WriteLine($"After add 2: {cs1}");

        Console.WriteLine("Adding Customer 3");
        cs1._queue.Add(new Customer("Victor", "V006", "System crash"));
        Console.WriteLine($"After add 3: {cs1}");

        // Defect(s) Found: None found for this tests

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Try to add customer when queue is full
        // Expected Result: An error message will be displayed, "Customer not added"
        Console.WriteLine("Test 2");
        Console.WriteLine("Attempting to add a 4th customer to the queue");

        // This should fail because the queue is supposde to have a max of 3
        cs1._queue.Add(new Customer("Shawn", "S008", "Refund request"));
        Console.WriteLine($"After trying add 4: {cs1}");

        // Defect(s) Found: This found that I have to use >= instead of just > in the AddNewCustomer

        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize)
    {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer
    {
        public Customer(string name, string accountId, string problem)
        {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString()
        {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    public void AddNewCustomer()
    {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize)
        {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer()
    {
        _queue.RemoveAt(0);
        var customer = _queue[0];
        Console.WriteLine(customer);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString()
    {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}