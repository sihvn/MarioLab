using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBox : MonoBehaviour
{
    public AudioSource CoinAudio;
    public AudioClip CoinSpawned;
    public Animator boxAnimator;

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
            //boxAnimator.SetTrigger("IsCollided");
            Debug.Log("test");
            boxAnimator.Play("coin-flipping");
            CoinAudio.PlayOneShot(CoinSpawned);
            spawned = true;
        }

    }
    // void coinFlip()
    // {
    //     // SpriteRenderer boxSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
    //     // boxSprite.sprite = newBoxSprite;
    //     Debug.Log("test2");
    // }
    void changeBox()
    {
        springJoint.frequency = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // if (spawned)
        // {

        //     //springJoint.enabled = false;
        // }
    }

}
