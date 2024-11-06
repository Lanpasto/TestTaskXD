using UnityEngine;

public class TriggerAnimationOnClick : MonoBehaviour
{
    public Animator animator; 
        public string triggerName = "WakeUp"; 

    private void OnMouseDown()
    {
        if (animator != null)
        {
            animator.SetTrigger(triggerName);
        }
    }
}
