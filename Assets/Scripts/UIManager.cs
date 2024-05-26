using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _blockPrefab;
    [SerializeField] private GameObject _turretPrefab;
    [SerializeField] private int blockCost;
    [SerializeField] private int turretCost;
    [SerializeField] private Text Money1;
    [SerializeField] private Text Money2;

    private void Update()
    {
        Player player1 = PlayersContainer.Players[0];
        Player player2 = PlayersContainer.Players[1];
        Money1.text = player1.CountCoins.ToString();
        Money2.text = player2.CountCoins.ToString();
    }

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
