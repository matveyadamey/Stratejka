using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _SpawnObject : MonoBehaviour
{
    //[SerializeField] private GameObject _blockPrefab;
    //[SerializeField] private GameObject _turretPrefab;

    public static void SpawnObject(Object type, GameObject prefab, Vector3 pos)
    {
        Instantiate(prefab, pos, Quaternion.identity);

        Player player = PlayersContainer.Players[CurrentPlayer.CurrentPlayerNumber];
        player.BuyObject(type, new Point((int)pos.x, (int)pos.z));
    }
}
