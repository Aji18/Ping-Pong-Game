using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    

    public Ball ball;
    public Paddle paddle;

    public static Vector2 BottomLeft;
    public static Vector2 TopRight;

    // Start is called before the first frame update
    void Start()
    {
        

        BottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        TopRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        Instantiate(ball);

        Paddle paddle1 = Instantiate(paddle) as Paddle;
        Paddle paddle2 = Instantiate(paddle) as Paddle;
        paddle1.Init (true);
        paddle2.Init (false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
