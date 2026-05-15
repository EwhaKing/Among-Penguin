using UnityEngine;

public class Player_walk : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    [SerializeField] private float moveForce = 1f;
    [SerializeField] private float maxSpeed = 5f;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }
    private void Update()
    {
        if (Input.GetButtonUp("Horizontal")) // Stop Speed
        {
            rigid.linearVelocity = new Vector2(rigid.linearVelocity.normalized.x * 0.01f, rigid.linearVelocity.y);
        }

        if (Input.GetButtonUp("Vertical"))
        {
            rigid.linearVelocity = new Vector2(rigid.linearVelocity.x, rigid.linearVelocity.normalized.y * 0.01f);
        }

        if (Input.GetButtonDown("Horizontal")) //캐릭터 방향 전환
        {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 dir = new Vector2(x, y).normalized;

        // 이동
        rigid.AddForce(dir * moveForce, ForceMode2D.Impulse);

        // 최대 속도 제한
        if (rigid.linearVelocity.magnitude > maxSpeed)
        {
            rigid.linearVelocity = rigid.linearVelocity.normalized * maxSpeed;
        }
    }



}
