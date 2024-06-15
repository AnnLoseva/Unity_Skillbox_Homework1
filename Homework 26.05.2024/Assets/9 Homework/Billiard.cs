using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billiard : MonoBehaviour
{
    [SerializeField] private Transform[] cueStickpoints;
    [SerializeField] private GameObject[] balls;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float power = 5f;


    private bool animationPlaying;
    private Transform currentCueStickPoint;
    private int pointCounter;
    private Vector3[] ballpoints;


    

    // Start is called before the first frame update
    void Start()
    {
        currentCueStickPoint = transform;
        ballpoints = new Vector3[balls.Length];
        for(int i = 0; i< ballpoints.Length; i++)
        {
            ballpoints[i] = balls[i].transform.position;
            

            Debug.Log(ballpoints[i]);

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (animationPlaying) 
        {
            CueStickAnimation();
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

        Debug.Log(rb);

        rb.AddForce(transform.forward * power);
    }


    private void CueStickAnimation()
    {
        transform.position = Vector3.MoveTowards(transform.position, cueStickpoints[pointCounter].position, speed * Time.deltaTime);
        //transform.position = Vector3.Lerp(transform.position, cueStickpoints[pointCounter].position, speed);

        if(transform.position == cueStickpoints[pointCounter].position)
        {
            if (pointCounter < cueStickpoints.Length-1)
            {
                pointCounter++;
            }
            else
            {
                pointCounter = 0;
                transform.position = cueStickpoints[1].position;
                animationPlaying = false;
            }
        }
        
    }

    public void PlayAnimation()
    {
        animationPlaying = true;
    }

    public void Reset()
    {
        currentCueStickPoint = cueStickpoints[0];
        transform.position = currentCueStickPoint.position;
        transform.rotation = currentCueStickPoint.rotation;

        pointCounter = 0;

        for( int i = 0; i < balls.Length; i++)
        {
            balls[i].transform.position = ballpoints[i];

            Rigidbody rb = balls[i].GetComponent<Rigidbody>();
            rb.velocity = new Vector3(0,0,0);
        }

    }
}
