using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour,IGet
{
    private const int SIZE = Config.SIZE;// ������ ����
    Cell[][] coordNet = new Cell[SIZE][];

    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private Transform cubeField;
    [SerializeField] private Transform coinField;
    [SerializeField] private Material[] materials;
    // ���������� ����� �������
    public int getLevel(int x, int y)
    {
        return Mathf.Min(Mathf.Min(x, SIZE - x - 1), Mathf.Min(y, SIZE - y - 1));
    }

    // ���������� ����� ������� ������ �� �����������
    public Cell getObject(int x, int y)
    {
        return coordNet[x][y];
    }

    // ������������� �������� ������ �� � �����������
    public void setMaterial(int x, int y, Material mat)
    {
        getObject(x, y).material = mat;
    }

    // ��������� ���������� ����� � ������ �� �����������
    public int getCoinsCount(int x, int y)
    {
        return getObject(x, y).countCoin;
    }
    //������� ����
    public void deleteCoin(int x, int y,int cost)
    {
        int count = getCoinsCount(x, y);
        if (count >=cost) setCoinCount(x, y, count-cost);
    }
    public void setCoinCount(int x,int y,int count)
    {
        getObject(x, y).countCoin=count;
    }


    //�������� �� ������

    //�������� ������� � ����������� ������� ������� ����
    public Dictionary<string,int> getDict(int x,int y)
    {
        return getObject(x, y).elements;
    }

    //���������� ���� �� ������� � ������
    public bool isElementInCell(int x, int y, string type)
    {
        return getDict(x,y).ContainsKey(type);
    }
    
    //���������� ���������� ��������� � ������
    public int countElements(int x, int y, string type)
    {
        if (isElementInCell(x, y, type)) {
            getDict(x, y).TryGetValue(type, out int count);
            return count;
        }
        return -1;

    }

    //�������� ������� �� ������
    public void addElementToCell(int x,int y,string type)
    {
        if(countElements(x,y,type)>0)
        {
            getDict(x, y)[type]++;
        }
        else getDict(x, y).Add(type, 1);
        
    }

    //������� ������� � ������
    public void deleteElementFromCell(int x, int y, string type)
    {
        int count = countElements(x, y, type);
        getObject(x, y).elements.Add(type,count--);
    }


    // �������� ���� � ���������� ���������
    void Start()
    {
        // �������� ����
        for (int i = 0; i < SIZE; i++) 
        {
            coordNet[i] = new Cell[SIZE];
            for (int j = 0; j < SIZE; j++)
            {
                GameObject cube = Instantiate(cubePrefab, new Vector3(i, 0, j), Quaternion.identity, cubeField);
                coordNet[i][j] = cube.GetComponent<Cell>();
                //setColor(i, j, mat);
            }
        }

        // �������� �������
        for (int i = 0; i < SIZE; i++)
        {
            for (int j = 0; j < SIZE; j++)
            {
                if((i == 0 && j == 0) || (i == SIZE - 1 && j == 0) || 
                    (i == 0 && j == SIZE - 1) || (i == SIZE - 1 && j == SIZE - 1) ||
                    getLevel(i, j) == 4)
                {
                    setCoinCount(i,j,0);
                    continue;
                }
                Instantiate(coinPrefab, new Vector3(i, 1f, j), Quaternion.Euler(new Vector3(-60, 30, 0)), coinField);
                addElementToCell(i, j, "coin");
                setCoinCount(i,j,getLevel(i, j));
            }
        }
    }

}
