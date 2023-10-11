using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPowerup : BasePowerup
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start(); // call base class Start()
        this.type = PowerupType.Coin;
    }

    // Update is called once per frame
    void Update()
    {

    }
    // void OnCollisionEnter2D(Collision2D col)
    // {
    //     if (col.gameObject.CompareTag("Player") && spawned)
    //     {
    //         // TODO: do something when colliding with Player
    //         //PowerupManager.Instance.powerupCollected.Invoke(this);
    //         // then destroy powerup (optional)
    //         DestroyPowerup();

    //     }
    //     else if (col.gameObject.layer == 10) // else if hitting Pipe, flip travel direction
    //     {
    //         if (spawned)
    //         {
    //             goRight = !goRight;
    //             rigidBody.AddForce(Vector2.right * 3 * (goRight ? 1 : -1), ForceMode2D.Impulse);

    //         }
    //     }
    // }

    // interface implementation
    public override void SpawnPowerup()
    {
        spawned = true;
        AudioSource source = this.GetComponent<AudioSource>();
        source.PlayOneShot(source.clip);
        //PowerupManager.Instance.powerupCollected.Invoke(this);
    }
    public new void DestroyPowerup()
    {

    }


    // interface implementation
    public override void ApplyPowerup(MonoBehaviour i)
    {
        // TODO: do something with the object
        GameManager mario;
        bool result = i.TryGetComponent<GameManager>(out mario);
        if (result)
        {
            mario.IncreaseScore(1);
        }

    }

}
