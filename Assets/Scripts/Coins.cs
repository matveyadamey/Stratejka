using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : Field
{
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private Transform _coinField;
    // возращает количество монет в клетке по координатим
    public int GetCoinsCount(int x, int y)
    {
        return GetObject(x, y).CountCoin;
    }
    public void SetCoinCount(int x, int y, int count)
    {
        GetObject(x, y).CountCoin = count;
    }
    //удалить коин
    public void DeleteCoin(int x, int y, int cost)
    {
        int count = GetCoinsCount(x, y);
        if (count >= cost) SetCoinCount(x, y, count - cost);
    }
    private bool _cantPlaceCoin(int i,int j)
    {
        //true если не можем
        return (i == 0 && j == 0) || (i == Size - 1 && j == 0) ||
            (i == 0 && j == Size - 1) || (i == Size - 1 && j == Size - 1) || GetLayer(i, j) == 4;
    }
    // создание монеток
    private void _coinsSpawn()
    {
        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                if (_cantPlaceCoin(i,j))
                {
                    SetCoinCount(i, j, 0);
                    continue;
                }
                AddElementToCell(i, j, _coinPrefab, _coinField, 1);
                SetCoinCount(i, j, GetLayer(i, j));
            }
        }
    }
    void Start()
    {
        _coinsSpawn();
    }
}
