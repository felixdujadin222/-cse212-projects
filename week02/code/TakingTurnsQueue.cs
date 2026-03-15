using System;
using System.Collections.Generic;

public class TakingTurnsQueue
{
    private readonly List<Person> _queue = new();  // Stores people in order
    private int _currentIndex = 0;                 // Tracks whose turn it is

    public int Length => _queue.Count;

    public void AddPerson(string name, int turns)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException("Name cannot be empty.");

        _queue.Add(new Person(name, turns));
    }

    public Person GetNextPerson()
    {
        if (_queue.Count == 0)
            throw new InvalidOperationException("No one in the queue.");

        // Wrap index if out of bounds
        if (_currentIndex >= _queue.Count)
            _currentIndex = 0;

        var person = _queue[_currentIndex];

        // Only decrement positive turns
        if (person.Turns > 0)
        {
            person.Turns--;

            // Remove if turns reach 0
            if (person.Turns == 0)
            {
                _queue.RemoveAt(_currentIndex);
                // Do NOT increment _currentIndex; next person automatically shifts into this index
                return person;
            }
        }

        // Infinite turns (zero or negative) or person still has turns
        // Move index forward for the next call
        _currentIndex = (_currentIndex + 1) % _queue.Count;

        return person;
    }
}