using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
public class Field : MonoBehaviour
{
    private const int Size = 10;
    private GameObject[][] _coordNet = new GameObject[Size][];
    [SerializeField] private Material[] _materials;
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private Transform _cubeField;

    /*private Field(int _size)
    {
        Size = _size;
    }*/
    protected int GetCellLayer(Point point)
    {
        return Mathf.Min(Mathf.Min(point.x, Size - point.x - 1), Mathf.Min(point.y, Size - point.y - 1));
    }
    private void SetCellMaterial(Point point, Material material)
    {
        _coordNet[point.x][point.y].GetComponent<Renderer>().material = material;
    }

    private void _fieldSpawn()
    {
        for (int i = 0; i < Size; i++)
        {
            _coordNet[i] = new GameObject[Size];
            for (int j = 0; j < Size; j++)
            {
                GameObject cube = Instantiate(_cubePrefab, new Vector3(i, 0, j), Quaternion.identity, _cubeField);
                _coordNet[i][j] = cube;
                SetCellMaterial(new Point(i,j), _materials[GetCellLayer(new Point(i,j))]);
            }
        }
    }


    void Awake()
    {   
        _fieldSpawn();
    }

}