using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _SpawnObject : MonoBehaviour
{
    public static void SpawnObject(GameObject prefab, Vector3 pos)
    {
        Instantiate(prefab, pos, Quaternion.identity);
    }
}
