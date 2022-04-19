using UnityEngine;

public class Bunny : Player
{
    private float jumpHeight = 5.5f;

    // Start is called before the first frame update
    void Start()
    {
        this.prefab = FindObjectOfType<Bunny>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        performAbility();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag != "WoodenWall") return;

        Vector3 move = (transform.forward + transform.right) * 1.5f;
        controller.Move(move);
    }

    public override void performAbility()
    {
        if (!Input.GetKeyDown(KeyCode.Space))   return;
        if (!isGrounded)    return;
        
        velocity.y = Mathf.Sqrt(-2*jumpHeight*gravity);
        controller.Move(velocity * Time.deltaTime);
    }
}
