using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;         
    private Vector3 targetPosition;  
    private bool moving = false;     

    private Animator animator;

    void Start()
    {
        targetPosition = transform.position; 
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;
            targetPosition = mousePos;
            moving = true;
        }

        if (moving)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
            
            // Hareket animasyonuna geç
            animator.SetBool("isMoving", true);

            // Hedefe ulaşıldıysa hareketi sonlandır
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                moving = false;
            }
        }
        else
        {
            // Hareket yoksa animasyon idle olacak
            animator.SetBool("isMoving", false);
        }
    }
}
