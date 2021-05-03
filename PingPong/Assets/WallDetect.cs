using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetect : MonoBehaviour
{
    public SoundManager sManager;

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            sManager.PlaySound("wall");
        }
    }
}
