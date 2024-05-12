using UnityEngine;
public class Player
{
    public int CountCoins = 0;
    private Point[] _coordChip;
    private int _playerNumber;


    public Player(int playerNumber)
    {
        _coordChip = new Point[2] { new Point(-1,-1), new Point(-1,-1) };
        _playerNumber = playerNumber;
    }
    public void SetCoordChip(int chipNumber, Point coord)
    {
        if (_coordChip[chipNumber] == new Point(-1, -1));
        {
            _coordChip[chipNumber] = coord;
        }
    }

    public bool CanMoveChip(int ind, Point p)
    {
        return !MapObject.IsDealtDamage(p, _playerNumber) && (p.GetDistSquared(_coordChip[ind]) == 1);
    }
    public void MoveChip(int ind, Point p)
    {
        _coordChip[ind].x = p.x;
        _coordChip[ind].y = p.y;
        CountCoins += MapCoins.GetCoinValue(p);
        Debug.Log(CountCoins);
        MapCoins.DeleteCoin(p);
    }

    public bool CanBuyObject(Object type, Point p)
    {
        return CountCoins >= type.Cost && MapObject._map[p.x, p.y] == null;
    }
    public void BuyObject(Object type, Point p)
    {
        CountCoins -= type.Cost;
        MapObject._map[p.x, p.y] = type;
    }
}