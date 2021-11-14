using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class HeroMovement : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Rigidbody2D rigidbody2D;
    [SerializeField] private CircleCollider2D heroCollider;    
    private GameObject currnetPlatform;
    private InputService _inputService;
    private float speed = 3.5f;
    private float screenXBorder;
    private bool isStartPlatform = true;
    private int jumpCount = 0;
    private bool isActive = true;

    #region events
    public delegate void HeroLanding();
    public event HeroLanding OnHeroLandedNewPlatform;

    public delegate void HeroDeath();
    public event HeroDeath OnHeroDeath;
#endregion    
    

    [Inject]
    private void Construct(InputService inputService)
    {
        _inputService = inputService;             
    }
    private void Awake() 
    {
        screenXBorder = GetScreenWidthBorder(heroCollider.radius);    
        _inputService.OnJumpPressed += HeroJump;
    }

    private void OnDestroy() 
    {
        _inputService.OnJumpPressed -= HeroJump;
    }    

    private void Update() 
    {   
        if(!isActive) return;

        HeroHorizontalMovement();
        if(Mathf.Abs(transform.position.x - screenXBorder) < 0.15f)
        {
            SwitchMovementDirection();
        }
    }

    public void StopMovement()
    {
        isActive = false;
        rigidbody2D.isKinematic = true;
        _inputService.DisableInput(); 
        OnHeroDeath?.Invoke();       
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

    private void HeroHorizontalMovement()
    {
        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
    }

    private void HeroJump()
    {        
        if(jumpCount > 1) return;
        var velocity = rigidbody2D.velocity;
        velocity.y  = 5.5f;
        rigidbody2D.velocity = velocity;
        jumpCount++;
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        PlatformHolder platform;
        other.gameObject.TryGetComponent<PlatformHolder>(out platform);        

        if(platform!= null)
        {
            if(isStartPlatform)
            {
                currnetPlatform = other.gameObject;
                isStartPlatform = false;
            }
            if(transform.position.y >= other.gameObject.transform.position.y + 0.26f)
            {
                jumpCount = 0;
                if(currnetPlatform != other.gameObject)
                {
                    currnetPlatform = other.gameObject;                    
                    OnHeroLandedNewPlatform?.Invoke();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        other.GetComponent<ITrigger>().DOReaction(this);        
    }
}
