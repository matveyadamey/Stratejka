using UnityEngine;

public class Raycaster : MonoBehaviour
{
    public static GameObject[] LastClicks=new GameObject[2];

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
                    if (LastClicks[CurrentPlayer.CurrentPlayerNumber])
                    {
                        Highlighter.HighlightOff(LastClicks[CurrentPlayer.CurrentPlayerNumber]);
                    }

                    Highlighter.HighlightOn(click);
                    LastClicks[CurrentPlayer.CurrentPlayerNumber] = click;
                }
            }
        }
    }
}
