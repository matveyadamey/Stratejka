using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Baton : MonoBehaviour
{
    [SerializeField] private GameObject Menu;
    [SerializeField] private Canvas can;
    private bool isHaveMenu = false;
    private GameObject adress;
    private void PrintMenu()
    {
        GameObject Text;
        Debug.Log("Siiiiiiiiiu");
        if (!isHaveMenu)
        {
            Text = Instantiate(Menu, new Vector3(200, 200, 0), Quaternion.identity, can.transform);
            adress = Text;
            isHaveMenu = true;
        }
        else
        {
            Destroy(adress);
            isHaveMenu = false;
        }
    }
    public void OnClick()
    {
        Debug.Log("Siu");
        PrintMenu();
    }
    
}
