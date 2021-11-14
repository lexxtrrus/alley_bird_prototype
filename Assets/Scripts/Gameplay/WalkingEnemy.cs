using UnityEngine;


public class WalkingEnemy : MonoBehaviour, ITrigger, IMovable 
{    
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private CircleCollider2D enemyCollider;   
    private float speed = 2.5f;
    private float screenXBorder;
    public void DOReaction(HeroMovement heroMovement)
    {
        heroMovement.StopMovement();
    }

    private void Awake() 
    {
        screenXBorder = GetScreenWidthBorder(enemyCollider.radius);    
    }

    private void Update() 
    {   
        Move();
        if(Mathf.Abs(transform.position.x - screenXBorder) < 0.15f)
        {
            SwitchMovementDirection();
        }
    }

    public float GetScreenWidthBorder(float colliderWidth)
    {
        var screenEdge = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f));
        return screenEdge.x - colliderWidth * 0.5f;
    }

    private void SwitchMovementDirection()
    {
        screenXBorder *= -1f;
        speed *= -1f;
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }

    public void Move()
    {
        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
    }
}