#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class RectanglePlayer : Character
{
    GameObject RectanglePrefab;
           private Animator animator;

    private string prefabPath = "Player/RectanglePrefab";
    public float gridSize;
    public RectanglePlayer(float speed) : base(speed)
    {
        Debug.Log("nothing");
        LoadAndInstantiatePrefab();
    }
    void Start()
    {
        base.Start();
        speed = 5.0f;
        animator = GetComponent<Animator>();
        gridSize = 0.1f;
    }

    private void FixedUpdate()
    {
        Movement();
    }
    private void LoadAndInstantiatePrefab()
    {
        // Load prefab from the Resources folder
        RectanglePrefab = Resources.Load<GameObject>(prefabPath);

        // Instantiate the prefab
        if (RectanglePrefab != null)
        {
            Instantiate(RectanglePrefab);
        }
        else
        {
            Debug.LogError("Failed to load RectanglePrefab. Make sure it exists in the Resources folder.");
        }
    }

    public override void bulletClick()
    {
        Debug.Log("Khong co gi ");
    }
    public override void Movement()
    {
        if (variableJoystick == null || !variableJoystick.isActiveAndEnabled)
            variableJoystick = FindObjectOfType<VariableJoystick>();
        Vector2 dir = new Vector2(variableJoystick.Horizontal, variableJoystick.Vertical);

        if (dir != Vector2.zero)
        {
            if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
            {
                if (dir.x > 0)
                    animator.SetInteger("Direction", 2); // Phải
                else
                    animator.SetInteger("Direction", 3); // Trái
            }
            else
            {
                // Xác định hướng dọc
                if (dir.y > 0)
                    animator.SetInteger("Direction", 1); // Lên
                else
                    animator.SetInteger("Direction", 0); // Xuống
            }
        }

        animator.SetBool("IsMoving", dir.magnitude > 0);

        GetComponent<Rigidbody2D>().velocity = speed * dir;



    }
}
