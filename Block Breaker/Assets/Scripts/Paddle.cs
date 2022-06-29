using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 1f;
    [SerializeField] float ScreenFloat = 16f;

    Gamestatus gamestatus;
    BAll ball;
    
    void Start()
    {
        gamestatus = FindObjectOfType<Gamestatus>();
        ball= FindObjectOfType<BAll>();
    }

    // Update is called once per frame
    void Update()
    {
   // float MousePositioninUnits = Input.mousePosition.x/ Screen.width*ScreenFloat; fash tbghi t7iyd AutoPlay rdha w 7iyd GetXPos() Wdir hadi Blastha
        Vector2 Padlle = new Vector2(transform.position.x, transform.position.y);
        Padlle.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = Padlle;

    }

    private float GetXPos() 
    {
        if (gamestatus.IsAutoPlayEnabled())
        {
            return ball.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * ScreenFloat;
        }
    }
}
