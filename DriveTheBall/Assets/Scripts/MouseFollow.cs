using UnityEngine;
using UnityEngine.Tilemaps;

public class MouseFollow : MonoBehaviour
{
    Rigidbody2D rb;

    Vector3 mousePosition;
    public float moveSpeed = 0.1f;
    Vector2 position = new Vector2(0f, 0f);
    private float rotationSpeed = 100f;
    private float rotation = 0f;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);

        if (Input.GetKey(KeyCode.A))
        {
            rotation += rotationSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            rotation -= rotationSpeed * Time.deltaTime;
        }
        transform.rotation = Quaternion.Euler(0f, 0f, rotation);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(position);
    }

}