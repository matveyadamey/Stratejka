using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Storage : MonoBehaviour
{
    //хранилище флагов и массива доступных объектов

    public static bool IsMove; //двигаем объект или нет
    public static int[][] IsСlicked; //нажатие на клетку [x][y]
    public Object[] Objects;
    public static List<Object> Inventory; //объекты для спавна
    

}
