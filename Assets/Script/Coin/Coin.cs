using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float hauteur = 2f;
    [SerializeField] private float animation = 1f;
    private bool collected = false;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !collected)
        {
            collected = true;
            GameManager.Instance.AddScore(1);
            StartCoroutine(CollectCoin());
        }
    }
    private IEnumerator CollectCoin()
    {
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = startPosition + Vector3.up * hauteur;
        float elapsedTime = 0f;

        while (elapsedTime < animation)
        {
            float t = elapsedTime / animation;
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            transform.Rotate(Vector3.up * 360f * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }
}
