/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    private const int size = Config.SIZE;
    private int xcord;
    private int ycord;

    [SerializeField] private GameObject Field;
    [SerializeField] private GameObject _objectPrefab;
    [SerializeField] private Transform _objectParent;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            xcord = Random.Range(0, size);
            ycord = Random.Range(0, size);
            Field.GetComponent<Field>().AddElementToCell(xcord,ycord, _objectPrefab, _objectParent,1);
        }
    }
}
*/