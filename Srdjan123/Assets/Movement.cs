using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public int Yincrement;
    public float speed;
    public float maxHeight;
    public float minHeight;
    private Vector2 targetPos;


    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxHeight)
        {

            Moving(+3);
            /*targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);
            transform.position = targetPos;
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);*/
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minHeight)
        {
            Moving(-3);
            /*targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);
            transform.position = targetPos; 
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);*/
        }

         
    }

    void Moving(int broj)
    {

        targetPos = new Vector2(transform.position.x, transform.position.y + broj);
        //transform.position = targetPos;
    }

}
