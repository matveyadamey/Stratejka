using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : Field
{
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private Transform _coinField;
   

    private int GetCoinsCount(int x, int y)
    {
        return GetCell(x, y).CountCoin;
    }
    private void SetCoinCount(int x, int y, int count)
    {
        GetCell(x, y).CountCoin = count;
    }
    private void DeleteCoin(int x, int y, int cost)
    {
        int count = GetCoinsCount(x, y);
        if (count >= cost)
        {
            SetCoinCount(x, y, count - cost);
        }
    }
    private bool _cantPlaceCoin(int i,int j)
    {
        return (i == 0 && j == 0) || (i == Size - 1 && j == 0) ||
            (i == 0 && j == Size - 1) || (i == Size - 1 && j == Size - 1) || GetCellLayer(i, j) == 4;
    }
   
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
                SetCoinCount(i, j, GetCellLayer(i, j));
            }
        }
    }
    void Start()
    {
        _coinsSpawn();
    }
}
