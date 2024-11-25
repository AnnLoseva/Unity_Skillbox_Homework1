using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffext : MonoBehaviour
{
    private float length;
    private float startPos;
    [SerializeField] private GameObject myCamera;
    [SerializeField] private float parallaxEffext;


    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void FixedUpdate()
    {
        float temp = (myCamera.transform.position.x * (1 - parallaxEffext));
        float dist = (myCamera.transform.position.x * parallaxEffext);

        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);

        if (temp > startPos + length) startPos += length;
        else if (temp < startPos - length) startPos -= length;
    }
}
