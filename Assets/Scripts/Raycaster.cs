using UnityEngine;

public class Raycaster : MonoBehaviour
{
    //public static GameObject[] LastClicks=new GameObject[2];

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                GameObject click = hit.collider.gameObject;
                //Debug.Log(click.tag);
                if (click.tag == "Cell" || click.tag == "coin")
                {
                    Vector3 clickPosition = click.transform.position;
                    if (CurrentPlayer.OperatingMode == "movement_chip")
                    {
                        Point lastClick = new Point((int)clickPosition.x, (int)clickPosition.z);
                        CurrentPlayer.MovementChip.Move(lastClick);
                    }

                    if (CurrentPlayer.OperatingMode == "buy_object")
                    {
                        Vector3 place = new Vector3(clickPosition.x, 1, clickPosition.z);
                        _SpawnObject.SpawnObject(CurrentPlayer.PurchasedObject, place);
                        CurrentPlayer.OperatingMode = "expectation";
                        CurrentPlayer.PurchasedObject = null;
                        CurrentPlayer.NextPlayer();
                    }
                }
            }
        }
    }
}
