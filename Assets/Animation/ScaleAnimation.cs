using UnityEngine;
using DG.Tweening; 

public class ScaleAnimation : MonoBehaviour
{
    public float scaleDuration = 0.3f;
    public Vector3 targetScale = new Vector3(1.2f, 1.2f, 1f);
    public float resetScaleDuration = 0.3f; 
    public int loopCount = -1; 

    private void Start()
    {
        AnimateScaleLoop();
    }

    public void AnimateScaleLoop()
    {
        transform.DOScale(targetScale, scaleDuration)
            .SetLoops(loopCount, LoopType.Yoyo) 
            .SetEase(Ease.InOutQuad);  
    }
}
