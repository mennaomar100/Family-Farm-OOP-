using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2.7f;

    private Vector2 moveInput;
    private float rightBoundary = 8.5f;
    private float topBoundary = 4.5f;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        HandleInput();
        Move();
        UpdateAnimator();
    }

    private void HandleInput()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput = moveInput.normalized;
    }

    private void Move()
    {
        transform.position += (Vector3)moveInput * moveSpeed * Time.deltaTime;
        SetBoundaries();
    }

    private void SetBoundaries()
    {
        Vector3 pos = transform.position;  //we store current pos first so we don't alter the transform directly

        pos.x = Mathf.Clamp(pos.x, -rightBoundary, rightBoundary);  // Mathf.Clamp: bounds value between two numbers
        pos.y = Mathf.Clamp(pos.y, -topBoundary, topBoundary);

        transform.position = pos; //apply alternation to our transform
    }
    private void UpdateAnimator()
    {
        animator.SetFloat("MoveX", moveInput.x);
        animator.SetFloat("MoveY", moveInput.y);

        bool isMoving = moveInput.sqrMagnitude > 0;
        animator.SetBool("IsMoving", isMoving);

        if (moveInput.x < 0)
            spriteRenderer.flipX = true;
        else if (moveInput.x > 0)
            spriteRenderer.flipX = false;
    }
}