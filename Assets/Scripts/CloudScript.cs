using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour
{
    private Vector3 startPos;
    [SerializeField] private Transform endPos;
    [SerializeField] private float speed = 0.01f;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        offset = Vector3.zero;
        offset.x = speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (endPos != null) 
        {
            transform.Translate(offset * Time.fixedDeltaTime);
            if (transform.position.x > endPos.position.x) 
            {
                transform.position = startPos;
            }
        }
    }
}
