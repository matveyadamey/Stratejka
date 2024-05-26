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
            MapObject.SetObject(new Chip(_playerNumber), coord);
        }
    }

    public bool CanMoveChip(int ind, Point p)
    {
        return !MapObject.IsDealtDamage(p, _playerNumber) && 
               (p.GetDistSquared(_coordChip[ind]) == 1) &&
               MapObject.GetObject(p) == null;
    }
    public void MoveChip(int ind, Point p)
    {
        MapObject.DeleteObject(_coordChip[ind]);
        _coordChip[ind] = p;
        MapObject.SetObject(new Chip(_playerNumber), _coordChip[ind]);

        CountCoins += MapCoins.GetCoinValue(p);
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