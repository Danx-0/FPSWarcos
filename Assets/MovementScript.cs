using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Video;

public class MovementScript: MonoBehaviour
{
  [SerializeField]
  InputAction movementInput;
  CharacterController controller;
    [SerializeField]
    InputAction jumpInput;

    private float playerSpeed = 5.0f;
    private float gravityValue = -9.81f;


    private Vector3 playerVelocity;
    private bool grounded;//

    private void Awake()//siempre va primero que Start
    {
        controller = GetComponent<CharacterController>();   
    }
    private void OnEnable()
    {
        movementInput.Enable();
        jumpInput.Enable();
    }
    private void OnDisable()
    {
        movementInput.Disable();
        jumpInput.Disable();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
       
    {


        if (GameManager.instance.isPlaying == true)
        {



            grounded = controller.isGrounded;
            if (grounded)
            {
                if (playerVelocity.y < -2)
                {
                    playerVelocity.y = -1;//nuca en 0 ya que si es cero se queda volando el player ya que no tiene una atraccion 
                }

            }
            Vector2 Movement = movementInput.ReadValue<Vector2>();//vector2 por que nadamas esta en ejey y ejex 
            Vector3 direction = transform.right * Movement.x + transform.forward * Movement.y;
            direction = Vector3.ClampMagnitude(direction, 1);

            if (grounded && jumpInput.triggered)
            {
                //print("hola");
                playerVelocity.y = Mathf.Sqrt(1 * -2 * gravityValue);
            }

            playerVelocity.y += gravityValue * Time.deltaTime;

            Vector3 finalMove = direction * playerSpeed + Vector3.up * playerVelocity.y;



            controller.Move(finalMove * Time.deltaTime);//deltaTime es el tiempo entre frame y frame 
        }
    }
}
