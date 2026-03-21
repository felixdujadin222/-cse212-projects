using System;
using System.Collections.Generic;

/// <summary>
/// Represents a Maze that a player can navigate through.
/// Each cell in the maze is represented by a tuple (x, y) and has
/// a bool array indicating which directions are open: [left, right, up, down].
/// </summary>
public class Maze
{
    // The maze map: key = (x, y) coordinates, value = array of directions [left, right, up, down]
    private readonly Dictionary<(int, int), bool[]> _mazeMap;

    // Current position of the player in the maze
    private int _currX = 1;
    private int _currY = 1;

    /// <summary>
    /// Constructs a Maze instance with a given map.
    /// </summary>
    /// <param name="mazeMap">Dictionary of maze cells with their open directions</param>
    public Maze(Dictionary<(int, int), bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    /// <summary>
    /// Move the player left if possible. Throws exception if blocked.
    /// </summary>
    public void MoveLeft()
    {
        if (_mazeMap[(_currX, _currY)][0]) // Check 'left' in the array
            _currX--;
        else
            throw new InvalidOperationException("Can't go that way!");
    }

    /// <summary>
    /// Move the player right if possible. Throws exception if blocked.
    /// </summary>
    public void MoveRight()
    {
        if (_mazeMap[(_currX, _currY)][1]) // Check 'right' in the array
            _currX++;
        else
            throw new InvalidOperationException("Can't go that way!");
    }

    /// <summary>
    /// Move the player up if possible. Throws exception if blocked.
    /// </summary>
    public void MoveUp()
    {
        if (_mazeMap[(_currX, _currY)][2]) // Check 'up' in the array
            _currY--;
        else
            throw new InvalidOperationException("Can't go that way!");
    }

    /// <summary>
    /// Move the player down if possible. Throws exception if blocked.
    /// </summary>
    public void MoveDown()
    {
        if (_mazeMap[(_currX, _currY)][3]) // Check 'down' in the array
            _currY++;
        else
            throw new InvalidOperationException("Can't go that way!");
    }

    /// <summary>
    /// Returns the current position of the player in a human-readable format.
    /// </summary>
    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}