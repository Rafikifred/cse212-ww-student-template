using System;
using System.Collections.Generic;

public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    /// <summary>
    /// Check to see if you can move left.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveLeft()
    {
        if (!_mazeMap.ContainsKey((_currX, _currY)))
            throw new InvalidOperationException("Can't go that way!");

        if (_mazeMap[(_currX, _currY)][0])
            _currX--; // Move left
        else
            throw new InvalidOperationException("Can't go that way!");
    }

    /// <summary>
    /// Check to see if you can move right.
    /// </summary>
    public void MoveRight()
    {
        if (!_mazeMap.ContainsKey((_currX, _currY)))
            throw new InvalidOperationException("Can't go that way!");

        if (_mazeMap[(_currX, _currY)][1])
            _currX++; // Move right
        else
            throw new InvalidOperationException("Can't go that way!");
    }

    /// <summary>
    /// Check to see if you can move up.
    /// </summary>
    public void MoveUp()
    {
        if (!_mazeMap.ContainsKey((_currX, _currY)))
            throw new InvalidOperationException("Can't go that way!");

        if (_mazeMap[(_currX, _currY)][2])
            _currY--; // Move up
        else
            throw new InvalidOperationException("Can't go that way!");
    }

    /// <summary>
    /// Check to see if you can move down.
    /// </summary>
    public void MoveDown()
    {
        if (!_mazeMap.ContainsKey((_currX, _currY)))
            throw new InvalidOperationException("Can't go that way!");

        if (_mazeMap[(_currX, _currY)][3])
            _currY++; // Move down
        else
            throw new InvalidOperationException("Can't go that way!");
    }

    /// <summary>
    /// Return current location in the maze.
    /// </summary>
    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}
