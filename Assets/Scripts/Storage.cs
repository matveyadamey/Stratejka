using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Storage : MonoBehaviour
{
    protected const int Size = Config.SIZE;// размер поля
    //хранилище флагов и массива доступных объектов

    public static bool IsMove = true; //двигаем объект или нет
    public static bool[][] IsСlicked=new bool[Size][];  //нажатие на клетку [x][y]
    public static Object[] Objects;
    public static List<Object> Inventory; //объекты для спавна

    
private void Start()
    {
        for(int i = 0; i < Size; i++) 
        {
            IsСlicked[i] = new bool[Size];
            for(int j = 0; j < Size; j++)
            {
                IsСlicked[i][j] = false;
            }
        }
    }
}
