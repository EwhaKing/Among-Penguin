using UnityEngine;

public class Npc_walk : MonoBehaviour
{
    Rigidbody2D rigid;
    public int nextMoveX;
    public int nextMoveY;
    SpriteRenderer spriteRenderer;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        Invoke("Think", 5);
    }


    void FixedUpdate()
    {
        Vector2 moveVec = new Vector2(nextMoveX, nextMoveY).normalized;
        rigid.linearVelocity = moveVec;
    }

    void Think() //Àç±ÍÇÔ¼ö
    {
        nextMoveX = Random.Range(-2, 3);
        nextMoveY = Random.Range(-2, 3);

        if (nextMoveX != 0)
        {
            spriteRenderer.flipX = nextMoveX == 1;
        }

        float nextThinkTime = Random.Range(1, 4);
        Invoke("Think", nextThinkTime);
    }

}
