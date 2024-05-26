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
        transform.position = target;
        yield return null;
        CurrentPlayer.OperatingMode = "expectation";
        CurrentPlayer.MovementChip = null;
        Highlighter.HighlightOff(gameObject);
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
        if (CurrentPlayer.CurrentPlayerNumber == playerNumber)
        {
            if(CurrentPlayer.OperatingMode == "movement_chip" && CurrentPlayer.MovementChip == this)
            {
                CurrentPlayer.OperatingMode = "expectation";
                CurrentPlayer.MovementChip = null;
                Highlighter.HighlightOff(gameObject);
            }
            else
            {
                if(CurrentPlayer.MovementChip != null)
                {
                    GameObject prevObject = CurrentPlayer.MovementChip.gameObject;
                    Highlighter.HighlightOff(prevObject);
                }

                CurrentPlayer.OperatingMode = "movement_chip";
                CurrentPlayer.MovementChip = this;
                Highlighter.HighlightOn(gameObject);
            }

            /*
            GameObject clickedObject = Raycaster.LastClicks[playerNumber];
            Highlighter.HighlightOn(gameObject);
            Vector3 clickPosition = clickedObject.transform.position;
            Point lastClick = new Point((int)clickPosition.x, (int)clickPosition.z);
            move(lastClick);
            Highlighter.HighlightOff(clickedObject);
            */
        }
    }
}
