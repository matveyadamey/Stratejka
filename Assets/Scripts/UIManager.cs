using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _blockPrefab;
    [SerializeField] private GameObject _turretPrefab;
    [SerializeField] private int blockCost;
    [SerializeField] private int turretCost;

    public static void SpawnObject(GameObject prefab, Vector3 place)
    {
        _SpawnObject.SpawnObject(prefab,place);
        CurrentPlayer.PurchasedObject= null;
    }
    public void BuyButton(int cost, GameObject prefab)
    {
        int playerNumber = CurrentPlayer.CurrentPlayerNumber;
        Player player = PlayersContainer.Players[playerNumber];
        if (player.CountCoins >= cost)
        {
            player.CountCoins -= cost;
            if (CurrentPlayer.CurrentPlayerNumber == playerNumber)
            {
                if (CurrentPlayer.OperatingMode == "buy_object" && CurrentPlayer.PurchasedObject == prefab)
                {
                    CurrentPlayer.OperatingMode = "expectation";
                    CurrentPlayer.PurchasedObject = null;
                }
                else
                {
                    CurrentPlayer.OperatingMode = "buy_object";
                    CurrentPlayer.PurchasedObject = prefab;
                }
            }
        }
    }
    public void BuyTurretButton()
    {
        BuyButton(turretCost, _turretPrefab);
    } 
    
    public void BuyBlockButton()
    {
        BuyButton(blockCost, _blockPrefab);
    } 

}
