using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    const int SIZE=10;
    GameObject[][] coordNet=new GameObject[SIZE][];
    [SerializeField] private GameObject cubes;
    private void Start()
    {
        for (int i = 0; i < SIZE; i++)
        {
            coordNet[i] = new GameObject[SIZE];
            for (int j = 0; j < SIZE; j++)
            {
                coordNet[i][j] = cubes.transform.GetChild(i).gameObject.transform.GetChild(j).gameObject;
            }
        }
    }
    public GameObject getObjectByCoord(int x,int y)
    {
        return coordNet[x][y];
    }

}
