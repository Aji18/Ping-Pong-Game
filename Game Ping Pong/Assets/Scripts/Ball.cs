using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private float Speed;

    private float Radius;
    

    private Vector2 Direction;

    private int ScoreLeft;
    private int ScoreRight;

    [SerializeField]
    private Text ScoreTextLeft;
    [SerializeField]
    private Text ScoreTextRight;


    // Start is called before the first frame update
    void Start()
    {
        Direction = Vector2.one.normalized;
        Radius = transform.localScale.x / 2;
        ScoreLeft = 0;
        ScoreRight = 0;

        ScoreTextLeft.text = "Player Left Score:";
        ScoreTextRight.text = "Player Right Score:";

        
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Direction * Speed * Time.deltaTime);

        if (transform.position.y < GameManager.BottomLeft.y + Radius && Direction.y <0)
        {
            Direction.y = -Direction.y;
        }
        if (transform.position.y > GameManager.TopRight.y - Radius && Direction.y > 0)
        {
            Direction.y = -Direction.y;
        }

        if (transform.position.x < GameManager.BottomLeft.x + Radius && Direction.x < 0)
        {
            Debug.Log(ScoreRight);
            
            ScoreRight = ScoreRight + 1;
            SetScoreRight();
            ResetBall();
            //Time.timeScale = 0;
        }
        if(transform.position.x > GameManager.TopRight.x - Radius && Direction.x > 0)
        {
            Debug.Log(ScoreLeft);
            
            ScoreLeft = ScoreLeft + 1;
            SetScoreLeft();
            ResetBall();
            //Time.timeScale = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Paddle")
        {
            bool IsRight = other.GetComponent<Paddle>().IsRight;

            if( IsRight== true && Direction.x > 0)
            {
                Direction.x = -Direction.x;
            }
            if(IsRight == false && Direction.x < 0)
            {
                Direction.x = -Direction.x;
            }
        }
    }

    private void ResetBall()
    {
        transform.position = new Vector2(0, 0);
    }

    private void SetScoreLeft()
    {
        ScoreTextLeft.text = "Player Left Score: " + ScoreLeft.ToString();
        
    }

    private void SetScoreRight()
    {
        ScoreTextRight.text = "Player Right Score: " + ScoreRight.ToString();
    }
}
