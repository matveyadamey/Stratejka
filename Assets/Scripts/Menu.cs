using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Baton : MonoBehaviour
{
    [SerializeField] private GameObject Menu;
    [SerializeField] private Image BanScreen;
    /*[SerializeField]*/ public GameObject Player;
    [SerializeField] private GameObject can;
    private bool isHaveMenu = false;
    private GameObject adress;
    private Button Button1;
    private Button Button2;
    private Image img;
    private int banTime = 0;

    private void Start()
    {
        Player = GameObject.Find("ReallyPlayer");
        can = GameObject.Find("Canvas");
        img = Instantiate(BanScreen, new Vector3(200, 200, 0), Quaternion.identity, can.transform);
        img.gameObject.SetActive(false);
    }


    //Считаю время до закрытия бана
    private void FixedUpdate()
    {
        if (banTime == 2)
        {
            img.gameObject.SetActive(false);
        }
        if (banTime > 0) banTime -= 2;
    }

    //Вывод меню
    private void PrintMenu()
    {
        
        GameObject Text;
        if (!isHaveMenu)
        {
            Text = Instantiate(Menu, new Vector3(200, 200, 0), Quaternion.identity, can.transform);
            Button1 = Text.transform.GetChild(0).GetComponent<Button>();
            Button2 = Text.transform.GetChild(1).GetComponent<Button>();
            adress = Text;
            isHaveMenu = true;
        }
        else
        {
            Destroy(adress);
            isHaveMenu = false;
        }
    }

    //Обработка нажатия
    public void OnClick()
    {
        PrintMenu();
    }

    //Покупка блока
    public void Buy1()
    {
        if (Player.GetComponent<Player>().coins >= 5)
        {
            Player.GetComponent<Player>().coins -= 5;
            Player.GetComponent<Player>().inventory["Turret"]++;
        }
        else
        {
            img.gameObject.SetActive(true);
            banTime = 50;
        }
        Debug.Log("KPop");

    }

    //Покупка турельки
    public void Buy2()
    {
        if (Player.GetComponent<Player>().coins >= 3)
        {
            Player.GetComponent<Player>().coins -= 3;
            Player.GetComponent<Player>().inventory["Block"]++;
        }
        else
        {
            img.gameObject.SetActive(true);
            banTime = 50;
        }
        Debug.Log("K");
    }
}
