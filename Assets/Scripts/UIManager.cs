using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _blockPrefab;
    [SerializeField] private GameObject _turretPrefab;
    [SerializeField] private Text Money1;
    [SerializeField] private Text Money2;

    private void Update()
    {
        Player player1 = PlayersContainer.Players[0];
        Player player2 = PlayersContainer.Players[1];
        Money1.text = player1.CountCoins.ToString();
        Money2.text = player2.CountCoins.ToString();
    }

    public void BuyButton(Object type, GameObject prefab, int playerNumber)
    {
        if (playerNumber != CurrentPlayer.CurrentPlayerNumber) return;

        Player player = PlayersContainer.Players[playerNumber];
        if (player.CountCoins >= type.Cost)
        {
            GameObject prevObject = CurrentPlayer.MovementChip.gameObject;
            Vector3 prevPos = prevObject.transform.position;
            Highlighter.HighlightOff(prevObject);
            Highlighter.CanMoveChipOff(new Point((int)prevPos.x, (int)prevPos.z));

            CurrentPlayer.OperatingMode = "buy_object";
            CurrentPlayer.TypePurchasedObject = type;
            CurrentPlayer.PurchasedObject = prefab;
        }
    }
    public void BuyTurretButton(int playerNumber)
    {
        Object turret = new Turret(playerNumber, new Point(0, 1));
        BuyButton(turret, _turretPrefab, playerNumber);
    } 
    
    public void BuyBlockButton(int playerNumber)
    {
        Object block = new Block(playerNumber);
        BuyButton(block, _blockPrefab, playerNumber);
    } 

}
