using System.Collections;
using UnityEngine;
public class Movement : MonoBehaviour {

    private float _speed=10f;
    [SerializeField] private int playerNumber;
    [SerializeField] private int chipNumber;
    [SerializeField] private Raycaster raycaster;
    private IEnumerator MoveObject(Vector3 target)
    {
        while (Vector3.Distance(transform.position, target) > 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, target, _speed * Time.deltaTime);
            yield return null;
        }
    }
    private void move(Point target)
    {
        Vector3 _target = new Vector3(target.x, 1, target.y);
        Player player = Data.Players[playerNumber];
        if (player.CanMoveChip(chipNumber,target))
        {
            print("move");
            StartCoroutine(this.MoveObject(_target));
            player.MoveChip(chipNumber, target);
            CurrentPlayer.NextPlayer();
        }
        
    }

    void OnMouseDown()
    {
        print("click");
        Highlighter.HighlightOn(gameObject);
        Point lastClick = raycaster.LastClicks[playerNumber];
        move(lastClick);
        Highlighter.HighlightOff(gameObject);
    }
}
