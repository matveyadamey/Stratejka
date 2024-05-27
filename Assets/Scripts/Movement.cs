using System.Collections;
using System.Drawing;
using UnityEngine;
public class Movement : MonoBehaviour {

    private float _speed=10f;
    [SerializeField] private int playerNumber;
    [SerializeField] private int chipNumber;
    [SerializeField] private Raycaster raycaster;
    private IEnumerator MoveObject(Vector3 target)
    {
        Vector3 pos = gameObject.transform.position;
        Point point = new Point((int)pos.x, (int)pos.z);
        while (Vector3.Distance(transform.position, target) > 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, target, _speed * Time.deltaTime);
            yield return null;
        }
        transform.position = target;
        yield return null;
        CurrentPlayer.OperatingMode = "expectation";
        CurrentPlayer.MovementChip = null;
        Highlighter.HighlightOff(gameObject);
        Highlighter.CanMoveChipOff(point);
    }
    public void Move(Point target)
    {
        Vector3 _target = new Vector3(target.x, 1, target.y);
        Player player = PlayersContainer.Players[playerNumber];
        if (player.CanMoveChip(chipNumber,target))
        {
            StartCoroutine(this.MoveObject(_target));
            player.MoveChip(chipNumber, target);
            CurrentPlayer.NextPlayer();
        }
    }

    void OnMouseDown()
    {
        Vector3 pos = gameObject.transform.position;
        Point point = new Point((int)pos.x, (int)pos.z);
        if (CurrentPlayer.CurrentPlayerNumber == playerNumber)
        {
            if(CurrentPlayer.OperatingMode == "movement_chip" && CurrentPlayer.MovementChip == this)
            {
                CurrentPlayer.OperatingMode = "expectation";
                CurrentPlayer.MovementChip = null;
                Highlighter.HighlightOff(gameObject);
                Highlighter.CanMoveChipOff(point);
            }
            else
            {
                if(CurrentPlayer.MovementChip != null)
                {
                    GameObject prevObject = CurrentPlayer.MovementChip.gameObject;
                    Highlighter.HighlightOff(prevObject);
                    Highlighter.CanMoveChipOff(point);
                }

                CurrentPlayer.OperatingMode = "movement_chip";
                CurrentPlayer.MovementChip = this;
                Highlighter.HighlightOn(gameObject);
                Highlighter.CanMoveChipOn(point);
            }
        }
    }
}
