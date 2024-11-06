using UnityEngine;
using DG.Tweening;

public class WalkFrog : MonoBehaviour
{
    [SerializeField] private Transform targetPoint; 
    [SerializeField] private float moveDuration = 3f; 
    [SerializeField] private Animator animator;

    private bool isMoving = false; 

    void Update()
    {
        if (isMoving)
        {
            if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
            {
                StopMoving();
            }
        }
    }

    public void StartMoving()
    {
        if (targetPoint != null)
        {
            isMoving = true;
            animator.SetBool("isWalking", true); 

            transform.DOMove(targetPoint.position, moveDuration).SetEase(Ease.Linear).OnComplete(StopMoving);
        }
        else
        {
            Debug.LogWarning("YOUR POINT NONE");
        }
    }

    private void StopMoving()
    {
        isMoving = false;
        animator.SetBool("isWalking", false); 
    }

    void OnMouseDown()
    {
        if (!isMoving)
        {
            StartMoving();
        }
    }
}
