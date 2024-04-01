using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Object : MonoBehaviour
{
    //структра объекта, который есть в магазине
    public Image image;
    public TMP_Text name;
    public TMP_Text description; //описание
    public int cost;
    public GameObject objPrefab;
    public int x; //при добавлении на поле, обязательно указать
    public int y;
}
