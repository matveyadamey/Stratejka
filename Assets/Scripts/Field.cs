using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    [SerializeField] private GameObject _confObj;
    protected const int Size = Config.SIZE;// размер поля
    private Material[] _materials;
    private Cell[][] _coordNet = new Cell[Size][];

    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private Transform _cubeField;

    // возвращает номер контура
    public int GetLayer(int x, int y)
    {
        return Mathf.Min(Mathf.Min(x, Size - x - 1), Mathf.Min(y, Size - y - 1));
    }

    // возвращает класс игровой клетки по координатам
    public Cell GetObject(int x, int y)
    {
        return _coordNet[x][y];
    }

    // устанавливает материал клетки по её координатам
    public void SetMaterial(int x, int y, Material mat)
    {
        GetObject(x, y).SetMaterial(mat);
    }


    //элементы на клетке

    //получить словарь с количеством объекта каждого типа
    public Dictionary<string, int> GetDict(int x, int y)
    {
        return GetObject(x, y).Elements;
    }

    //возвращает количество элементов в клетке
    public int CountElements(int x, int y, string type)
    {
        if (GetDict(x, y).ContainsKey(type))
        {
            GetDict(x, y).TryGetValue(type, out int count);
            return count;
        }
        return -1;

    }

    //добавить элемент на клетку
    public void AddElementToCell(int x, int y, GameObject obj, Transform parent, int high)
    {
        if (CountElements(x, y, obj.tag) > 0)
        {
            GetDict(x, y)[obj.tag]++;
        }
        else GetDict(x, y).Add(obj.tag, 1);
        Instantiate(obj, new Vector3(x, high, y), Quaternion.identity, parent);
    }

    //удалить элемент с клетки
    public void DeleteElementFromCell(int x, int y, string type)
    {
        int count = CountElements(x, y, type);
        GetObject(x, y).Elements.Add(type, count--);
        Destroy(GameObject.FindGameObjectWithTag(type));
    }

    // создание поля
    private void _fieldSpawn()
    {
        for (int i = 0; i < Size; i++)
        {
            _coordNet[i] = new Cell[Size];
            for (int j = 0; j < Size; j++)
            {
                GameObject cube = Instantiate(_cubePrefab, new Vector3(i, 0, j), Quaternion.identity, _cubeField);
                _coordNet[i][j] = cube.GetComponent<Cell>();
                SetMaterial(i, j, _materials[GetLayer(i, j)]);
            }
        }
    }



    // СОЗДАНИЕ ПОЛЯ и ЗАПОЛНЕНИЕ МОНЕТКАМИ
    void Awake()
    {
        _materials = _confObj.GetComponent<Config>().Materials;
        _fieldSpawn();
    }

}
