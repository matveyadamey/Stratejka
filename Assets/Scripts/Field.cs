using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    const int SIZE=10;
    GameObject[][] coordNet = new GameObject[SIZE][];
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private Material[] materials;
    [SerializeField] private Transform field;
    public GameObject getObject(int x, int y)
    {
        return coordNet[x][y];
    }
    Material GetMaterial(int x,int y)
    {
        int matInd=Mathf.Min(Mathf.Min(x, SIZE-x-1),Mathf.Min(y,SIZE-y-1));
        return materials[matInd];

    }
    public void setColor(int x, int y, Material mat)
    {
        getObject(x, y).GetComponent<Renderer>().material = mat;
    }
    void Start()
    {
        for (int i = 0; i < SIZE; i++)
        {
            coordNet[i] = new GameObject[SIZE];
            for (int j = 0; j < SIZE; j++)
            {
                GameObject cube = Instantiate(cubePrefab, new Vector3(i, 0, j), Quaternion.identity,field);
                coordNet[i][j] = cube;
                Material mat = GetMaterial(i, j);
                setColor(i, j, mat);
            }
        }

    }

}
