using UnityEngine;
using DG.Tweening;

public class ObjectShakeOnClick : MonoBehaviour
{
    private void OnMouseDown()
    {
        ShakeObject();
    }

    private void ShakeObject()
    {
        float duration = 0.5f; 
        float strength = 0.2f; 
        int vibrato = 10; 
        float randomness = 90f;

        transform.DOShakePosition(duration, strength, vibrato, randomness, false, true);
    }
}
