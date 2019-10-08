using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxscript : MonoBehaviour {
    //config paramaters
    [SerializeField]AudioClip breakSound;
    [SerializeField] GameObject blockSparkles;
    [SerializeField] int maxhits;
    [SerializeField] Sprite[] damagelevels;
    // cached reference
    level level;
    //state Variables
    [SerializeField] int timeshit;
    GameSession game;
    // Use this for initialization
    public void Start()
    {
        level = FindObjectOfType<level>();
        game = FindObjectOfType<GameSession>();
        if (tag == "Breakable")
        {
            level.CountBreakableBlocks();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            timeshit++;
            if (timeshit >= maxhits)
            {
                DestroyBlock();
            }
            else
            {
                ShowNextHitSprites();
            }
        }

    }

    private void ShowNextHitSprites()
    {
        int spriteIndex = timeshit - 1;
        if (damagelevels[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = damagelevels[spriteIndex];
        }
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        game.addToScore();
        Destroy(gameObject);
        TriggerSparkles();
       
        level.minusbreakableblocks();
    }
    private void TriggerSparkles()
    {
        GameObject sparkles = Instantiate(blockSparkles, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
