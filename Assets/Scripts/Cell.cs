using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Cell : MonoBehaviour,IPointerClickHandler
{
    private const int SIZE = Config.SIZE;

    public int countCoin = 0;
    public Dictionary<string,int> elements;
    public int x;
    public int y;
    public Material material;

    void Start()
    {
        GetComponent<Renderer>().material = material;
    }
    public void OnPointerClick(PointerEventData ev)
    {
        Player player = new Player();
        player.move(ev.position);
    }
}
