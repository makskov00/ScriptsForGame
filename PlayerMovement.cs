using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Uduino;
 
public class PlayerMovement : MonoBehaviour
{ 
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim;
    private bool Grounded;
    public int EMGvalueAbove = 150;
    private void Awake()
    {//Grab references for rigidbody and animator from object
        body = GetComponent<Rigidbody2D>();
        
        
      anim= GetComponent<Animator>();


    UduinoManager.Instance.pinMode(AnalogPin.A1, PinMode.Input);

    }
 
    private void Update()
    {

          int EMGvalue = UduinoManager.Instance.analogRead(AnalogPin.A1);


         transform.Translate(Vector2.right * (Time.deltaTime * speed ));


//Flip player when moving left-right
if (speed > 0.01f)
    transform.localScale = Vector3.one;

else if (speed < -0.01f)
    transform.localScale = new Vector3(-1, 1, 1);
                            
if (Input.GetKey (KeyCode.Space) && Grounded) //jump only when grounded
jump();

if (EMGvalue > EMGvalueAbove && Grounded)
{
    jump();
}

if(Input.GetKeyDown(KeyCode.U))
{
    EMGvalueAbove = EMGvalueAbove + 50;
}
if(Input.GetKeyDown(KeyCode.I))
{
    EMGvalueAbove = EMGvalueAbove -50;
}
    
//Set animator parameters
    anim.SetBool("Run", speed != 0); //is 0 not equal to 0? = false , Run = False . is 1 not equal to 0? = true means run
    anim.SetBool("Grounded", Grounded); //is player grounded
    
    }
    private void jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        anim.SetTrigger("Jump");
        Grounded=false;

    }
    private void OnCollisionEnter2D(Collision2D collision)
     {
        if(collision.gameObject.tag == "Ground")
        Grounded=true;
            
        }

        
    }
