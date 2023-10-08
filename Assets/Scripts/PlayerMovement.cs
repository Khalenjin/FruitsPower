using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    public GameObject Player;
    public GameObject PinkMan;
    public GameObject NinjaFrog;
    public GameObject MaskMan;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    private float moveSpeed = 7f;
    private float jumpForce = 14f;

    private enum MovementState { idle, running, jumping, falling }

    [SerializeField] private AudioSource jumpSoundEffect;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        // PlayerPrefs'ten seçilen karakteri al

        // Karaktere göre özelleþtirilmiþ kodlarý burada ayarla
        string selectedCharacter = PlayerPrefs.GetString("SelectedCharacter");

        if (selectedCharacter == "MaskMan")
        {
            MaskMan.SetActive(true);
        }
        else if (selectedCharacter == "NinjaFrog")
        {
            NinjaFrog.SetActive(true);
        }
        else if (selectedCharacter == "PinkMan")
        {
            PinkMan.SetActive(true);
        }
        else if (selectedCharacter == "Player")
        {
            Player.SetActive(true);
        }

    }

    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
