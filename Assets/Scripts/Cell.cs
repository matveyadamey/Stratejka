using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Cell : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private const int Size = Config.SIZE;

    public int CountCoin = 0;
    public Dictionary<string, int> Elements = new Dictionary<string, int>();

    public int x;
    public int y;
    [SerializeField] private GameObject _player;

    // устанавливает материал клетки по её координатам
    public void setMaterial(Material mat)
    {
        GetComponent<Renderer>().material = mat;
    }

    // поднимаем флаг нажатия на клетку
    public void OnPointerDown(PointerEventData ev)
    {
        Storage.IsСlicked[(int)transform.position.x][(int)transform.position.z] = true;
        Debug.Log(1);
    }
    public void OnPointerUp(PointerEventData ev)
    {
        Storage.IsСlicked[(int)transform.position.x][(int)transform.position.z] = false;
        Debug.Log(0);
    }
}
