using UnityEngine;

public class Raycaster : MonoBehaviour
{
    public Point[] LastClicks=new Point[2];

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Vector3 click = hit.collider.gameObject.transform.position;
                Point clickPosition = new Point((int)click.x, (int)click.z);
                print(CurrentPlayer.CurrentPlayerNumber);
                LastClicks[CurrentPlayer.CurrentPlayerNumber]=clickPosition;
            }
        }
    }
}
