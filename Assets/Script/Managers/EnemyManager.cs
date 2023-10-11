using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour

{
    public Sprite enemy;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void Awake()
    {

        GameManager.Instance.gameRestart.AddListener(GameRestart);


    }

    void EnemyDeath()
    {
        gameObject.SetActive(false);
    }

    public void GameRestart()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<SpriteRenderer>().sprite = enemy;
            child.GetComponent<EnemyMovement>().GameRestart();
        }
    }
}
