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
                    Highlighter.HighlightOn(click);
                    LastClicks[CurrentPlayer.CurrentPlayerNumber] = click;
                }
            }
        }
    }
}
