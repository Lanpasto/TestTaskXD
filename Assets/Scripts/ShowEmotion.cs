using UnityEngine;
using DG.Tweening; 

public class ShowEmotion : MonoBehaviour
{
    public GameObject objectToShow; 
    [SerializeField] private float fadeDuration = 0.3f; 
    [SerializeField] private float fadeOutDelay = 1f;

    private void Start()
    {
        if (objectToShow != null)
        {
            objectToShow.SetActive(false);
            CanvasGroup canvasGroup = objectToShow.GetComponent<CanvasGroup>();
            if (canvasGroup == null)
            {
                canvasGroup = objectToShow.AddComponent<CanvasGroup>();
            }
            canvasGroup.alpha = 0f;
        }
    }

    void OnMouseDown()
    {
        if (objectToShow != null)
        {
            CanvasGroup canvasGroup = objectToShow.GetComponent<CanvasGroup>();

            if (canvasGroup.alpha == 0f)
            {
                objectToShow.SetActive(true);
                canvasGroup.DOFade(0.5f, fadeDuration); 
                
                canvasGroup.DOFade(0f, fadeDuration).SetDelay(fadeOutDelay).OnKill(() => objectToShow.SetActive(false));
            }
        }
    }
}
