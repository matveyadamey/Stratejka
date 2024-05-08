using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _blockPrefab;
    [SerializeField] private GameObject _turretPrefab;

    public void BuyButton(int cost, GameObject prefab)
    {
        int number = CurrentPlayer.CurrentPlayerNumber;
        Player pl = PlayersContainer.Players[number];
        if (pl.CountCoins >= cost)
        {
            pl.CountCoins -= cost;
            _SpawnObject.SpawnObject(prefab, new Vector3(Raycaster.LastClicks[number].transform.position.x, 1, Raycaster.LastClicks[number].transform.position.z));
        }
    }
    public void BuyTurretButton()
    {
        BuyButton(3, _turretPrefab);
    } 
    
    public void BuyBlockButton()
    {
        BuyButton(3, _blockPrefab);
    } 

}
