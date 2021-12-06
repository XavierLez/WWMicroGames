using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
    private int ballNbTick;
    [SerializeField] private float speed;
    private float yOffset;

    private float xStartPos;

    public bool canMove = false;

    private void Start()
    {
        xStartPos = -40;
    }

    private Vector3 newPos;
    private void Update()
    {

        if (canMove)
        {
            xStartPos += Time.deltaTime * speed * Ticker.gameSpeed;

            newPos = new Vector3(xStartPos, (float)-(xStartPos * xStartPos * 0.02) + yOffset, 0);
            transform.position = newPos;
        }

    }

    public void SetYOffset(float yOffset) 
    {
        this.yOffset = yOffset;
    }

    public void SetCanMove(bool canMove) 
    {
        this.canMove = canMove;
    }
}
