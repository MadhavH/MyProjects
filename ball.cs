using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ball : MonoBehaviour {
    
    [SerializeField]Paddle p;
    Vector2 paddletoballvector;
    Boolean hasstarted = false;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;
    Rigidbody2D myRigidBody;
    AudioSource myAudio;
	// Use this for initialization
	void Start () {

        paddletoballvector = transform.position - p.transform.position;
        myAudio = GetComponent<AudioSource>();
        myRigidBody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (hasstarted == false)
        {
            lockpaddle();
            Launch();
        }
        

    }

    private void Launch()
    {
      if(Input.GetMouseButton(0))
        {
            myRigidBody.velocity = new Vector2(2f, 15f);
            hasstarted = true;
        }
    }

    private void lockpaddle()
    {
        Vector2 paddlepos = new Vector2(p.transform.position.x, p.transform.position.y);
        transform.position = paddlepos + paddletoballvector;
    } 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocitytweak = new Vector2(UnityEngine.Random.Range(0f, randomFactor), UnityEngine.Random.Range(0f, randomFactor));
        if (hasstarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0,ballSounds.Length)];
            myAudio.PlayOneShot(clip);
        }
        myRigidBody.velocity += velocitytweak;
    }

}
