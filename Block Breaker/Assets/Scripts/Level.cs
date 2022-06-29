using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableblocks;

    SceneLoader sceneloader;

    private void Start()
    {
        sceneloader = FindObjectOfType<SceneLoader>();
    }
    public void CountBlocks()
    {
        breakableblocks++;
    }
    public void BlockDestroyed()
    {
        breakableblocks--;
        if (breakableblocks <= 0)
        {
            sceneloader.LoadNextScene();
        }
    }
}
