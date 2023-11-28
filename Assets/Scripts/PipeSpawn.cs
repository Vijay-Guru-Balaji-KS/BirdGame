using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawn : MonoBehaviour
{
    public GameObject pipe;
    public float spawntime = 2f;
    private float timer = 0f;
    public float heightoffset = 10f;

    public GameObject coinpipe;

    int count = 0;


    // Start is called before the first frame update
    void Start()
    {
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if( timer < spawntime )
        {
            timer+=Time.deltaTime;
        }
        else
        {
            spawnPipe();
            timer = 0;
        }
    }

    void spawnPipe()
    {
        if (count == 8)
        {
            spawncoinpipe();
        }
        else
        {
            float heighestpoint = transform.position.y + heightoffset;
            float lowestpoint = transform.position.y - heightoffset;
            Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestpoint, heighestpoint), transform.position.z), transform.rotation);
            count++;
        }
    }

    void spawncoinpipe()
    {
        float heighestpoint = transform.position.y + heightoffset;
        float lowestpoint = transform.position.y - heightoffset;
        Instantiate(coinpipe, new Vector3(transform.position.x, Random.Range(lowestpoint, heighestpoint), transform.position.z), transform.rotation);
        count = 0;
    }
}
