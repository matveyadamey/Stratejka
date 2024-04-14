/*using UnityEngine;

public class MapCoins : MonoBehaviour
{
    privat
    [SerializeField] private Coin[][] CoinsNet = new Coin[Size][];

    private int GetCoinCount(int x, int y)
    {
        return CoinsNet[x][y].coinCount;
    }

    private void SetCoinField()
    {
        for (int i = 0; i < Size; i++)
        {
            CoinsNet[i] = new Coin[Size];
            for (int j = 0; j < Size; j++)
            {
                CoinsNet[i][j] = new Coin(Mathf.Min(Mathf.Min(i, j), Mathf.Min(Size - i - 1, Size - j - 1)) + 1);
            }
        }
    }

    private void DeleteCoin(int x, int y)
    {
        CoinsNet[x][y] = new Coin(0);
    }

    private void Awake()
    {
        SetCoinField();
    }
}*/