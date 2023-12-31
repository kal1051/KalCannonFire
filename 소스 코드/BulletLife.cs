﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLife : MonoBehaviour
{
    public AudioClip clipBomb;
    public GameObject flame;
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        Destroy(gameObject, 10.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //string tag = collision.gameObject.tag;
        if (collision.gameObject.tag == "Player") return;
        else if (collision.gameObject.tag == "Ball") // µæÁ¡
        {
            Destroy(collision.gameObject, 0.05f); // BallÀ» ÆÄ±«
            gameManager.incScore();
        }
        else if (collision.gameObject.tag == "Bilon") // µæÁ¡
        {
            Destroy(collision.gameObject, 0.05f); // BallÀ» ÆÄ±«
            gameManager.superincScore();
        }
        else if (collision.gameObject.tag == "Floor") // °¨Á¡
        {
            gameManager.decScore();
        }
        Instantiate(flame, transform.position, transform.rotation);
        playBomb();
        Destroy(gameObject, 0.05f); // BulletÀ» ÆÄ±«
        Debug.Log(gameManager.getScore());
    }

    void playBomb()
    {
        AudioSource audioSource = FindObjectOfType<AudioSource>();
        //audioSource.volume = 1.0f;
        audioSource.PlayOneShot(clipBomb, 1.0f);
    }
}