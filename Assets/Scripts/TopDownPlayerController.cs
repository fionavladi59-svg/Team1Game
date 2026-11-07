using UnityEngine;
using UnityEngine.InputSystem;

public class TopDownPlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpSpeed = 4f;
    public float jumpDuration = 0.4f;

    Rigidbody2D rb;
    Animator anim;
    Vector2 move;
    float jumpTimer;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        var kb = Keyboard.current;
        if (kb == null) return;

        move = new Vector2(
            (kb.dKey.isPressed ? 1 : 0) - (kb.aKey.isPressed ? 1 : 0),
            (kb.wKey.isPressed ? 1 : 0) - (kb.sKey.isPressed ? 1 : 0)
        ).normalized;

        if (kb.spaceKey.wasPressedThisFrame && jumpTimer <= 0f)
            jumpTimer = jumpDuration;

        bool horizontal = Mathf.Abs(move.x) > Mathf.Abs(move.y);
        anim.SetBool("WalkRight", horizontal && move.x > 0);
        anim.SetBool("WalkLeft", horizontal && move.x < 0);
        anim.SetBool("WalkBack", !horizontal && move.y > 0);
        anim.SetBool("WalkFront", !horizontal && move.y < 0);
    }

    void FixedUpdate()
    {
        Vector2 velocity = move * speed;

        if (jumpTimer > 0f)
        {
            velocity.y += jumpTimer > jumpDuration / 2f ? jumpSpeed : -jumpSpeed;
            jumpTimer -= Time.fixedDeltaTime;
        }

        rb.linearVelocity = velocity;
    }
}