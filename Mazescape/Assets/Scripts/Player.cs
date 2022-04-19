using UnityEngine;

public abstract class Player : MonoBehaviour
{
    public GameObject prefab;
    private int crystals;

    #region Movement
        protected CharacterController controller;
        private bool canMove;
        [SerializeField] protected float speed = 10f;
        protected float gravity = -9.81f;

        private float groundDistance = 1f;
        private Transform groundCheck;
        private LayerMask groundMask;
        protected bool isGrounded;
        protected Vector3 velocity;

        public void Move()
        {
            if (!canMove)   return;

            isGrounded = Physics.CheckSphere(groundCheck.position,groundDistance,groundMask);
            if (isGrounded && velocity.y < 0)   
                velocity.y = -2f;

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            // Move
            Vector3 move = transform.right * x + transform.forward * z;
            controller.Move(move*speed*Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
    #endregion

    void Awake()
    {
        this.crystals = 0;
        this.canMove  = true;
        groundCheck   = GameObject.FindGameObjectWithTag("GroundCheck").transform;
        groundMask    = LayerMask.GetMask("Ground");
        controller    = GetComponent<CharacterController>();
    }

    public void AddCrystal(){ this.crystals++; }
    public void SetCanMove(bool canMove){ this.canMove = canMove; }
    public bool GetCanMove(){ return canMove; }
    
    public abstract void performAbility();
}