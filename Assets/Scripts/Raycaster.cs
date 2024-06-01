using UnityEngine;

public class Raycaster : MonoBehaviour
{
    Vector3 clickPosition;

    /*
    bool hasPlaceForTurretChosen = false;
    void ifTurret(Vector3 click)
    {
        if (hasPlaceForTurretChosen)
        {
            float y_angle = Vector3.Angle(Vector3.right, clickPosition - click);
            Quaternion rotation = Quaternion.Euler(0, y_angle, 0);
            ObjectSpawner.SpawnObject(CurrentPlayer.TypePurchasedObject, CurrentPlayer.PurchasedObject, clickPosition, rotation);
        }
        else
        {
            print("выберите направление турели");
            clickPosition = click;
            hasPlaceForTurretChosen = true;
        }
    }
    */

    void moveChip()
    {
        Point lastClick = new Point((int)clickPosition.x, (int)clickPosition.z);
        CurrentPlayer.MovementChip.Move(lastClick);
    }
    void buyObject()
    {
        Vector3 place = new Vector3(clickPosition.x, 1, clickPosition.z);

        Player player = PlayersContainer.Players[CurrentPlayer.CurrentPlayerNumber];
        Point p = new Point((int)place.x, (int)place.z);

        if (!player.CanBuyObject(CurrentPlayer.TypePurchasedObject, p))
        {
            return;
        }

        Field.DeleteCoin(p);

        ObjectSpawner.SpawnObject(CurrentPlayer.TypePurchasedObject, CurrentPlayer.PurchasedObject, place, Quaternion.identity);

        CurrentPlayer.OperatingMode = "expectation";
        CurrentPlayer.TypePurchasedObject = null;
        CurrentPlayer.PurchasedObject = null;
        CurrentPlayer.NextPlayer();
    }
    void OnClick()
    {
        switch (CurrentPlayer.OperatingMode)
        {
            case "movement_chip":
                moveChip();
                break;

            case "buy_object":
                buyObject();
                break;

        }
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                GameObject click = hit.collider.gameObject;
                if ((CurrentPlayer.PurchasedObject != null & CurrentPlayer.TypePurchasedObject != null) || CurrentPlayer.MovementChip != null)
                {
                    if (click.transform.position != clickPosition)
                    {
                        if (click.tag == "Cell")
                        {
                            clickPosition = click.transform.position;
                            OnClick();
                        }
                    }
                }
            }
        }
    }

}
