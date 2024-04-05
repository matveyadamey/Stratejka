using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Player : MonoBehaviour
{
    protected const int Size = Config.SIZE;

    // координаты фишки
    private int _x = 0;
    private int _y = 0;

    // возможные ходы
    private static int[][] _moveAdd = new[] {
        new[] { 1, 0 },
        new[] { 0, 1 },
        new[] { -1, 0 },
        new[] { 0, -1 }
    };

    // скорость передвижения фишки 
    private float _speed = 10;


/*    private IEnumerator MoveObject(Vector3 target)
    {
        while (Vector3.Distance(transform.position, target) > 0.1f)
        {
            float speed = _speed * Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, target, speed);
            yield return null;
        }
    }*/
    public void Update()
    {
        if (Storage.IsMove)
        {
            foreach (int[] add in _moveAdd)
            {
                // находим координаты клеток, в которые можем пойти
                int newX = _x + add[0];
                int newY = _y + add[1];
                if (Mathf.Min(newX, newY) < 0 || Size <= Mathf.Max(newX, newY)) continue;

                // если клетка выбрана
                if (Storage.IsСlicked[newX][newY])
                {
                    //StartCoroutine(MoveObject(new Vector3(newX, 1, newY)));
                    transform.position = new Vector3(newX, 1, newY);
                    _x = newX;
                    _y = newY;
                }
            }
        }

    }
}
