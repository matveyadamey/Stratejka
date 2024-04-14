/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class MovementByClick : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Transform player;
    private float aids=5;

    private IEnumerator MoveObject(Vector3 target)
    {
        bool fly = false;
        while (Vector3.Distance(player.position, target) > 0.1f)
        {
            if (fly == false)
            {
                target.y += 0.1f;
                fly = true;
            }
            float speed = aids * Time.deltaTime;
            player.localPosition = Vector3.Lerp(player.localPosition, target, speed);

            yield return null;
        }
    }




    public void OnPointerClick(PointerEventData eventdata)
    {
        Vector3 target = new Vector3(transform.position.x, 0f, transform.position.z);
        if (Vector3.Distance(player.position, target) <= 1.3)
        {
            StartCoroutine(MoveObject(target));
        }
    } 
   
}*/