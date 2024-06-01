using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public static void SpawnObject(Object type,GameObject prefab, Vector3 pos, Quaternion rotation)
    {
        Instantiate(prefab, pos, rotation);

        Player player = PlayersContainer.Players[CurrentPlayer.CurrentPlayerNumber];
        player.BuyObject(type, new Point((int)pos.x, (int)pos.z));
    }
}
