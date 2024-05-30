using UnityEngine;

public class Raycaster : MonoBehaviour
{
    Vector3 clickPosition;
    bool hasPlaceForTurretChosen = false;

    void ifTurret(GameObject click)
    {
        if (hasPlaceForTurretChosen)
        {
            float y_angle = Vector3.Angle(Vector3.right, clickPosition - click.transform.position);
            Quaternion rotation = Quaternion.Euler(0, y_angle, 0);
            ObjectSpawner.SpawnObject(CurrentPlayer.TypePurchasedObject, CurrentPlayer.PurchasedObject, clickPosition, rotation);
        }
        else
        {
            print("выберите направление турели");
            clickPosition = click.transform.position;
            hasPlaceForTurretChosen = true;
        }
    }
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

        ObjectSpawner.SpawnObject(CurrentPlayer.TypePurchasedObject, CurrentPlayer.PurchasedObject, place, Quaternion.identity);
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

        CurrentPlayer.OperatingMode = "expectation";
        CurrentPlayer.TypePurchasedObject = null;
        CurrentPlayer.PurchasedObject = null;
        CurrentPlayer.NextPlayer();
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

                if (click.transform.position != clickPosition)
                {

                    if (CurrentPlayer.TypePurchasedObject.Type == "turret")
                    {
                        ifTurret(click);
                    }

                    else if (click.tag == "Cell")
                    {
                        clickPosition = click.transform.position;
                        OnClick();
                    }
                }
            }
        }
    }

}
