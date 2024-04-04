using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Cell : MonoBehaviour,IPointerClickHandler
{
    private const int SIZE = Config.SIZE;

    public int CountCoin = 0;
    public Dictionary<string,int> Elements=new Dictionary<string, int>();
    public int x;
    public int y;
    [SerializeField] private GameObject _player;

    // устанавливает материал клетки по её координатам
    public void SetMaterial(Material mat)
    {
        GetComponent<Renderer>().material = mat;
    }
    public void OnPointerClick(PointerEventData ev)
    {
        GameObject.Find("Player").GetComponent<Player>().move(new Vector3(transform.position.x,1,transform.position.z));
    }
}
