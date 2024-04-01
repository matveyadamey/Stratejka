using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Storage : MonoBehaviour
{
    //хранилище флагов и массива доступных объектов

    public static bool isMove; //двигаем объект или нет
    public static int[][] isСlicked; //нажатие на клетку [x][y]
    public Object[] objects;
    public static List<Object> inventory; //объекты для спавна
    

}
