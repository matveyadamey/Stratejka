using System;

public class MapObject
{
    private Point _fieldSize;
    private int _radiusOfDefeat;
    private static Object[,] _map;

    public Object this[int i, int j] 
    {
        get { return _map[i, j]; }
        set
        {
            if (!CheckCoord(new Point(i, j)) || _map[i, j] != null)
            {
                throw new ArgumentOutOfRangeException();
            }
            _map[i, j] = value;
        }
    }

    public MapObject(Point fieldSize, int radiusOfDefeat)
    {
        _fieldSize = fieldSize;
        _radiusOfDefeat = radiusOfDefeat;
        _map = new Object[_fieldSize.x, _fieldSize.y];
        _map[0, 0] = new Chip(0);
        _map[_fieldSize.x - 1, _fieldSize.y - 1] = new Chip(0);
        _map[_fieldSize.x - 1, 0] = new Chip(1);
        _map[0, _fieldSize.y - 1] = new Chip(1);
    }

    private bool CheckCoord(Point p)
    {
        return 0 <= p.x && p.x < _fieldSize.x && 0 <= p.y && p.y < _fieldSize.y;
    }

    public bool IsDealtDamage(Point p, int ind)
    {
        if (!CheckCoord(p))
        {
            throw new ArgumentOutOfRangeException();
        }
        for (int i = -_radiusOfDefeat; i <= _radiusOfDefeat; i++)
        {
            for (int j = -_radiusOfDefeat; j <= _radiusOfDefeat; j++)
            {
                Point checkСell = new Point(p.x - i, p.y - j);
                if (!CheckCoord(checkСell) || _map[checkСell.x, checkСell.y] == null || _map[checkСell.x, checkСell.y].PlayerNumber != ind) 
                {
                    continue;
                }
                Point localCoord = p - checkСell;
                if(_map[checkСell.x, checkСell.y].IsDealtDamage(localCoord))
                { 
                    return true; 
                }
            }
        }
        return false;
    }
}
