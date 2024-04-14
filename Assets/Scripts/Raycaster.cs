using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    private GameObject _chosenChip;

    private Movement _movement;

    private void Start()
    {
        _movement = GetComponent<Movement>();
    }
    private void FixedUpdate()
    {
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                GameObject clickedObject = hit.collider.gameObject;

                if (clickedObject.tag == "Chip")
                {
                    if(_chosenChip != null)
                    {
                        Highlighter.HighlightOff(_chosenChip);
                    }
                    _chosenChip = clickedObject;
                    Highlighter.HighlightOn(clickedObject);
                }

                if (_chosenChip!=null && clickedObject.tag=="Cell")
                {

                    Highlighter.HighlightOn(clickedObject);
                    _movement.move(clickedObject.transform.position, _chosenChip);
                    Highlighter.HighlightOff(clickedObject);
                    Highlighter.HighlightOff(_chosenChip);
                    _chosenChip = null;
                }
            }
        }
    }
}
