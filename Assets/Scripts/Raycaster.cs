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
                if (click.tag == "Cell")
                {
                    if (CurrentPlayer.OperatingMode == "movement_chip")
                    {
                        Vector3 clickPosition = click.transform.position;
                        Point lastClick = new Point((int)clickPosition.x, (int)clickPosition.z);
                        CurrentPlayer.MovementChip.Move(lastClick);
                    }

                    if (CurrentPlayer.OperatingMode == "buy_object")
                    {
                        // ?????????????????????????????????????????
                    }

                    /*
                    if (LastClicks[CurrentPlayer.CurrentPlayerNumber])
                    {
                        Highlighter.HighlightOff(LastClicks[CurrentPlayer.CurrentPlayerNumber]);
                    }
                    Highlighter.HighlightOn(click);
                    LastClicks[CurrentPlayer.CurrentPlayerNumber] = click;
                    */
                }
            }
        }
    }
}
