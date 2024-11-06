using UnityEngine;
using DG.Tweening; 

public class ObjectRotateOnClick : MonoBehaviour
{
    private void OnMouseDown()
    {
        RotateObject();
    }

    private void RotateObject()
    {
        float rotationDuration = 0.5f; 
        Vector3 rotationAxis = new Vector3(0, 0, 360);
        transform.DORotate(rotationAxis, rotationDuration, RotateMode.LocalAxisAdd)
                 .SetEase(Ease.Linear); 
    }
}
