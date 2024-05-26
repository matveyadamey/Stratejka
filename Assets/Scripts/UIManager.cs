using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _blockPrefab;
    [SerializeField] private GameObject _turretPrefab;
    [SerializeField] private int blockCost;
    [SerializeField] private int turretCost;

    public void BuyButton(int cost, GameObject prefab)
    {
        int playerNumber = CurrentPlayer.CurrentPlayerNumber;
        Player player = PlayersContainer.Players[playerNumber];
        if (player.CountCoins >= cost)
        {
            player.CountCoins -= cost;
            CurrentPlayer.OperatingMode = "buy_object";
            CurrentPlayer.PurchasedObject = prefab;
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
