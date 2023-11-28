using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovementScript : MonoBehaviour
{
    public float speed = 5f;
    public float deadZone = -30f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(-1, 0, 0) * speed * Time.deltaTime;
        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
