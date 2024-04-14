using System;
using System.Collections.Generic;

public class Player
{
    public int CountCoins = 0;
    private Point[] _coordChip;
    public Dictionary<string, int> inventory { get; }
    private MapObject _mapObject;
    private MapCoins _mapCoins;
    private int _playerNumber;


    public Player(Point fieldSize, MapObject mapObject, MapCoins mapCoins, int playerNumber)
    {
        _coordChip = new Point[2];
        _coordChip[0] = new Point(0, 0);
        _coordChip[1] = new Point(fieldSize.x - 1, fieldSize.y);
        _mapObject = mapObject;
        _mapCoins = mapCoins;
        _playerNumber = playerNumber;
    }

    public bool CanMoveChip(int ind, Point p)
    {
        return !_mapObject.IsDealtDamage(p, _playerNumber) && (p.GetDistSquared(_coordChip[ind]) == 1);
    }
    public void MoveChip(int ind, Point p)
    {
        _coordChip[ind].x = p.x;
        _coordChip[ind].y = p.y;
    }
    public void BuyObject(Object type)
    {
        if (inventory.ContainsKey(type.Type))
        {
            inventory[type.Type]++;
        }
        else
        {
            inventory.Add(type.Type, 1);
        }
        CountCoins -= type.Cost;
    }
    public void SetObject(string type)
    {
        inventory[type]--;
    }

}