using UnityEngine;

public class Player3D : MonoBehaviour
{
    public Animator animator;
    public CharacterController characterController;
    public float speed = 1f;    
    public float turnSpeed = 1f;    
    public float gravity = 9.8f;  

    [Header("Jump Setup")]
    private float vSpeed = 0f;    
    public float jumpSpeed = 15f;
    public KeyCode jumpKeyCode = KeyCode.Space;

    [Header("Run Setup")]    
     public KeyCode keyRun = KeyCode.LeftShift;    
     public float speedRun = 1.5f;

    void Update()    
    {        
        transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0); 
                   
        var inputAxisVertical = Input.GetAxis("Vertical");        
        var speedVector = transform.forward * inputAxisVertical * speed; 

        if(characterController.isGrounded)        
        {            
            vSpeed = 0;            
            if(Input.GetKeyDown(jumpKeyCode))            
            {                
                vSpeed = jumpSpeed;            
            }        
        }     

        vSpeed  -= gravity * Time.deltaTime;        
        speedVector.y = vSpeed;

        var isWalking = inputAxisVertical != 0;        
        if(isWalking)        
        {            
            if(Input.GetKey(keyRun))            
            {                
                speedVector *= speedRun;                
                animator.speed = speedRun;            
            }            
            else            
            {               
                animator.speed = 1;            
            }        
        }        

        characterController.Move(speedVector * Time.deltaTime);

        animator.SetBool("Run", inputAxisVertical != 0);     

    }
}
