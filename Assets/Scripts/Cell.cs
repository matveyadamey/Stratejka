using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Cell : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public int CountCoin = 0;
    public Dictionary<string, int> ObjectsOnCell = new Dictionary<string, int>();

    public int x;
    public int y;
    [SerializeField] private GameObject _player;

    public void SetCellMaterial(Material mat)
    {
        GetComponent<Renderer>().material = mat;
    }

    // поднимаем флаг нажатия на клетку
    public void OnPointerDown(PointerEventData ev)
    {
        Storage.IsСlicked[(int)transform.position.x][(int)transform.position.z] = true;
        Debug.Log(Storage.IsСlicked[(int)transform.position.x][(int)transform.position.z]);
    }
    public void OnPointerUp(PointerEventData ev)
    {
        Storage.IsСlicked[(int)transform.position.x][(int)transform.position.z] = false;
        Debug.Log(Storage.IsСlicked[(int)transform.position.x][(int)transform.position.z]);
    }
}
