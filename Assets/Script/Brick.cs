using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public AudioSource CoinAudio;
    public AudioClip CoinSpawned;
    public Animator brickAnimator;
    public SpringJoint2D springJoint;


    [System.NonSerialized]
    public bool spawned = false;
    // Start is called before the first frame update
    void Start()
    {

    }
    void OnCollisionEnter2D(Collision2D col)
    {

        if (spawned == false && col.gameObject.CompareTag("Player"))
        {
            Debug.Log("hello");
            brickAnimator.SetTrigger("BrickCollision");
            brickAnimator.Play("Coin-flipping-bricks");
            CoinAudio.PlayOneShot(CoinSpawned);
            spawned = true;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
