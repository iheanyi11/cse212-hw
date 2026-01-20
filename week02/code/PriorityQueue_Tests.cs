using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with different priorities and dequeue them.
    //           Items with higher priorities should be dequeued first.
    // Expected Result: High priority (5), Medium priority (3), Low priority (1)
    // Defect(s) Found: Comparison used >= instead of > breaking the priority order.
    //                  Also the loop condition was incorrect causing the last item to be ignored.
    //                  Items were not removed from the queue after dequeuing.                    

    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low priority", 1);
        priorityQueue.Enqueue("Medium priority", 3);
        priorityQueue.Enqueue("High priority", 5);

        // Should dequeue in order of priority
        Assert.AreEqual("High priority", priorityQueue.Dequeue());
        Assert.AreEqual("Medium priority", priorityQueue.Dequeue());
        Assert.AreEqual("Low priority", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the same highest priority and try to dequeue them.
    //           When priorities are equal, items should be dequeued using the FIFO order
    // Expected Result: First, Second, Third (in the order they were added with equal priority)
    // Defect(s) Found: Comparison operator used >= causing later items to be chosen instead of FIFO order.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("First", 5);
        priorityQueue.Enqueue("Second", 5);
        priorityQueue.Enqueue("Third", 5);

        //Should return in FIFO order when priorities are equal
        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
    }

    // Add more test cases as needed below.

    [TestMethod]

    //Scenario: Try to dequque from an empty queue.
    //Expected Result: InvalidOperationException is thrown.
    //Defect(s) Found: None, the exception handling is corretly implemented.

    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown for empty queue.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(string.Format("Incorrect exception type {0} caught: {1}", e.GetType(), e.Message));
        }
    }

    [TestMethod]

    //Scenario: Enqueue one item, dequeue it. Then try to dequeue again.
    //          Tests that items are actually removed from the queue.
    //Expected Result: First dequeue succeeds, second dequeue throws an exception
    //Defect(s) Found: Items were not removed from the queue after dequeuing.
    //                 Second dequeue returned same item instead of throwing exception.

    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Only Item", 1);

        // First dequeue should succeed
        Assert.AreEqual("Only Item", priorityQueue.Dequeue());

        // Second dequeue should throw exception
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown for empty queue.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}