using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Object : MonoBehaviour
{
    //структра объекта, который есть в магазине
    public Image Image;
    public TMP_Text Name;
    public TMP_Text Description; //описание
    public int Cost;
    public GameObject ObjPrefab;
    public int x; //при добавлении на поле, обязательно указать
    public int y;
}
