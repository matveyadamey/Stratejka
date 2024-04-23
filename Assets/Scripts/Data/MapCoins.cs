using System;
public class MapCoins
{
    private int _size;
    public static Coin[,] _coinsNet;

    public Coin this[int i, int j]
    {
        get { return _coinsNet[i, j]; }
    }


    int GetLayerCount(Point p)
    {
        return Math.Min(Math.Min(p.x, p.y), Math.Min(_size - p.x - 1, _size - p.y - 1)) + 1;
    }

    public MapCoins(Point fieldSize)
    {
        _size = fieldSize.x;
        _coinsNet =new Coin[_size, _size];
        for (int i = 0; i < _size; i++)
        {
            for (int j = 0; j < _size; j++)
            {
                _coinsNet[i,j] = new Coin(GetLayerCount(new Point(i, j)));
            }
        }
    }

    private void DeleteCoin(Point Cord)
    {
        _coinsNet[Cord.x, Cord.y] = new Coin(0);
    }
}