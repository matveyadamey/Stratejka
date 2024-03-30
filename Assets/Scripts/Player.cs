using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float Speed;
    private IEnumerator MoveObject(Vector3 target)
    {
        while (Vector3.Distance(transform.position, target) > 0.1f)
        {
            float speed = Speed * Time.deltaTime;
            transform.localPosition = Vector3.Lerp(transform.localPosition, target, speed);

            yield return null;
        }
    }
    public void move(Vector3 direction)
    {
        StartCoroutine(MoveObject(direction));
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
