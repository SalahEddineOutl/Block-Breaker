using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBlock : MonoBehaviour
{
    [SerializeField] AudioClip Breaksound;
    [SerializeField] GameObject blockSparklesVFX;
   
    [SerializeField] int timeHits;
    [SerializeField] Sprite[] HitSprite;
 
    Level level;
    Gamestatus gamestatus;

    private void Start()
    {
        CounBreakableBlocks();
    }

    private void CounBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
        gamestatus = FindObjectOfType<Gamestatus>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(Breaksound, Camera.main.transform.position);
        if (tag == "Breakable")
        {
            timeHits++;
            int MaxHits = HitSprite.Length + 1;
            if (timeHits >= MaxHits)
            {
                Destroy(gameObject);
                level.BlockDestroyed();
                gamestatus.AddToScore();
                TriggerSparklesVFX();
            }
            else
            {
                ShowNextSprite();
            }
           
        }
       
    }

    private void ShowNextSprite()
    {
        int spriteIndex = timeHits - 1;
        if (HitSprite[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = HitSprite[spriteIndex];
        }
        else
        {
            Debug.LogError("The Sprite Is missing"+ gameObject.name);
        }
               

    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 0.2f);
    }

    
}
