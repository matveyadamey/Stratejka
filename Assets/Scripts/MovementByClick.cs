using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class MovementByClick : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Transform player;
    private float aids=5;

    private IEnumerator MoveObject(Vector3 target)
    {
        while (Vector3.Distance(player.position, target) > 0.1f)
        {
            float speed = aids * Time.deltaTime;
            player.localPosition = Vector3.Lerp(player.localPosition, target, speed);

            yield return null;
        }
    }




    public void OnPointerClick(PointerEventData eventdata)
    {//777
        StartCoroutine(MoveObject(new Vector3(transform.position.x,1, transform.position.z)));
    } 
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}