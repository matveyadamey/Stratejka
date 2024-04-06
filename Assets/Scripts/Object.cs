using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Object : MonoBehaviour
{
    //структра объекта, который есть в магазине
    public Image Image;
    public string Name;
    public string Description;
    public int Cost;
    public GameObject ObjPrefab;
    public int x; //при добавлении на поле, обязательно указать
    public int y;

}
