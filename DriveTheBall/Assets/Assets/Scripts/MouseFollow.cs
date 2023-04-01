using UnityEngine;
using UnityEngine.Tilemaps;

public class MouseFollow : MonoBehaviour
{
    Rigidbody2D rb;
    Renderer renderer;
    TilemapCollider2D tc;
    BoxCollider2D bc;
    Material material;

    Vector3 mousePosition;
    public float moveSpeed = 0.1f;
    Vector2 position = new Vector2(0f, 0f);
    float opacity = 0.5f;
    bool start = false;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        tc = GetComponent<TilemapCollider2D>();
        tc.enabled = false;

        renderer = GetComponent<Renderer>();
        material = new Material(renderer.material);
        Color color = material.color;
        color.a = opacity;
        material.color = color;
        renderer.material = material;
    }

    private void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);

        if (start == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Mouse Clicked");
                Color color = material.color;
                color.a = 1f;
                material.color = color;
                renderer.material = material;
                tc.enabled = true;
                start = true;
            }
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(position);
    }

}