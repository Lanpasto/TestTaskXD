using UnityEngine;
using DG.Tweening;

public class ParticleOnClick : MonoBehaviour
{
    public ParticleSystem particlePrefab; 
    private ParticleSystem particleInstance;

    private void Start()
    {
        particleInstance = Instantiate(particlePrefab);
        particleInstance.Stop(); 

        particleInstance.transform.SetParent(transform);
    }

    private void OnMouseDown()
    {
        Vector3 spawnPosition = new Vector3(0, 0, 0); 
        particleInstance.transform.localPosition = spawnPosition;

        particleInstance.Play();

        ShakeObject();
    }

    private void ShakeObject()
    {
        float duration = 0.2f; 
        float strength = 0.1f; 
        int vibrato = 10;
        float randomness = 90f; 

        transform.DOShakePosition(duration, strength, vibrato, randomness, false, true);
    }
}
