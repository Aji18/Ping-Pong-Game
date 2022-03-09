using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    [SerializeField] private float Speed;
    private float Heigt;

    private string input;
    public bool IsRight;
    // Start is called before the first frame update
    void Start()
    {
        Heigt = transform.localScale.y;
        Speed = 5f;
    }

    public void Init(bool IsRightPaddle)
    {
        IsRight = IsRightPaddle;

        Vector2 pos = Vector2.zero;

        if (IsRightPaddle)
        {
            pos = new Vector2(GameManager.TopRight.x, 0);
            pos -= Vector2.right * transform.localScale.x;

            input = "PaddleRight";
        }
        else
        {
            pos = new Vector2(GameManager.BottomLeft.x, 0);
            pos += Vector2.right * transform.localScale.x;

            input = "PaddleLeft";
        }

        transform.position = pos;
    }
    // Update is called once per frame
    void Update()
    {
        float Move = Input.GetAxis(input) * Time.deltaTime * Speed;

        if(transform.position.y < GameManager.BottomLeft.y + Heigt / 2 && Move < 0)
        {
            Move = 0;
        }
        if (transform.position.y > GameManager.TopRight.y - Heigt / 2 && Move > 0)
        {
            Move = 0;
        }

        transform.Translate(Move * Vector2.up);
    }


}
