using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue and Dequeue single item
    // Expected Result: Dequeue returns the same item
    public void TestPriorityQueue_SingleItem()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Alice", 1);
        Assert.AreEqual("Alice", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from empty queue
    // Expected Result: Throws InvalidOperationException
    public void TestPriorityQueue_EmptyQueue()
    {
        var pq = new PriorityQueue();
        var ex = Assert.ThrowsException<InvalidOperationException>(() => pq.Dequeue());
        Assert.AreEqual("The queue is empty.", ex.Message);
    }

    [TestMethod]
    // Scenario: Multiple items with different priorities
    // Expected Result: Highest priority dequeued first
    public void TestPriorityQueue_HighestPriorityFirst()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Bob", 2);
        pq.Enqueue("Sue", 5);
        pq.Enqueue("Tim", 3);

        Assert.AreEqual("Sue", pq.Dequeue()); // highest priority 5
        Assert.AreEqual("Tim", pq.Dequeue()); // next highest priority 3
        Assert.AreEqual("Bob", pq.Dequeue()); // last
    }

    [TestMethod]
    // Scenario: Multiple items with same highest priority
    // Expected Result: FIFO among ties
    public void TestPriorityQueue_FIFOAmongTies()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Alice", 3);
        pq.Enqueue("Bob", 3);
        pq.Enqueue("Charlie", 2);

        Assert.AreEqual("Alice", pq.Dequeue()); // first of highest priority
        Assert.AreEqual("Bob", pq.Dequeue());   // second of highest priority
        Assert.AreEqual("Charlie", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Mixed priorities
    // Expected Result: Highest priority dequeued first, ties follow FIFO
    public void TestPriorityQueue_MixedPriorities()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 3);
        pq.Enqueue("C", 2);
        pq.Enqueue("D", 3);
        pq.Enqueue("E", 1);

        Assert.AreEqual("B", pq.Dequeue()); // highest priority 3, first of two
        Assert.AreEqual("D", pq.Dequeue()); // next highest priority 3
        Assert.AreEqual("C", pq.Dequeue()); // priority 2
        Assert.AreEqual("A", pq.Dequeue()); // priority 1, first of two
        Assert.AreEqual("E", pq.Dequeue()); // last
    }
}