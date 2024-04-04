using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Storage : MonoBehaviour
{
    protected const int Size = Config.SIZE;// размер поля
    //хранилище флагов и массива доступных объектов
<<<<<<< Updated upstream

    public static bool isMove; //двигаем объект или нет
    public static int[][] isСlicked; //нажатие на клетку [x][y]
    public Object[] objects;
    public static List<Object> inventory; //объекты для спавна
    
=======
    public bool IsMove = true; //двигаем объект или нет
    public bool[,] IsСlicked = new bool[Size, Size]; //нажатие на клетку [x][y]
    public Object[] Objects;
    public static List<Object> Inventory; //объекты для спавна
>>>>>>> Stashed changes

    private void Start()
    {
        for(int i = 0; i < Size; i++) 
        { 
            for(int j = 0; j < Size; j++)
            {
                IsСlicked[i, j] = false;
            }
        }
    }
}
