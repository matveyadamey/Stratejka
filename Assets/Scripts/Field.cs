using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{

    protected const int Size = Config.SIZE;// размер поля
    private Material[] _materials;
    private Cell[][] _coordNet = new Cell[Size][];

    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private Transform _cubeField;

    protected int GetCellLayer(int x, int y)
    {
        return Mathf.Min(Mathf.Min(x, Size - x - 1), Mathf.Min(y, Size - y - 1));
    }

    protected Cell GetCell(int x, int y)
    {
        return _coordNet[x][y];
    }

    private void SetCellMaterial(int x, int y, Material mat)
    {
        GetCell(x, y).SetCellMaterial(mat);
    }

    private Dictionary<string, int> GetObjectsOnCell(int x, int y)
    {
        return GetCell(x, y).ObjectsOnCell;
    }

  
    private int CountObjectsOnCell(int x, int y, string type)
    {
        if (GetObjectsOnCell(x, y).ContainsKey(type))
        {
            GetObjectsOnCell(x, y).TryGetValue(type, out int count);
            return count;
        }
        return -1;

    }

    public void AddElementToCell(int x, int y, GameObject obj, Transform parent, int high)
    {
        if (CountObjectsOnCell(x, y, obj.tag) > 0)
        {
            GetObjectsOnCell(x, y)[obj.tag]++;
        }
        else
        {
            GetObjectsOnCell(x, y).Add(obj.tag, 1);
        }
        Instantiate(obj, new Vector3(x, high, y), Quaternion.identity, parent);
    }

    public void DeleteElementFromCell(int x, int y, string type)
    {
        int count = CountObjectsOnCell(x, y, type);
        GetCell(x, y).ObjectsOnCell.Add(type, count--);
        Destroy(GameObject.FindGameObjectWithTag(type));
    }

    private void _fieldSpawn()
    {
        for (int i = 0; i < Size; i++)
        {
            _coordNet[i] = new Cell[Size];
            for (int j = 0; j < Size; j++)
            {
                GameObject cube = Instantiate(_cubePrefab, new Vector3(i, 0, j), Quaternion.identity, _cubeField);
                _coordNet[i][j] = cube.GetComponent<Cell>();
                SetCellMaterial(i, j, _materials[GetCellLayer(i, j)]);
            }
        }
    }


    [SerializeField] private GameObject _confObj;
    void Awake()
    {
        _materials = _confObj.GetComponent<Config>().Materials;
        _fieldSpawn();
    }

}
