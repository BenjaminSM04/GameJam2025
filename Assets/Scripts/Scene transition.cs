using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scenetransition : MonoBehaviour
{
    public string sceneToLoad;
    public Vector2 playerPosition;
    public VectorValue playerStorage;
    public GameObject fadeinpanel;
    public GameObject fadeoutpanel;
    public float fadewait;
    private void Awake()
    {
        if (fadeinpanel != null)
        {
            GameObject panel = Instantiate(fadeinpanel, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1);
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            playerStorage.initialValue = playerPosition;
            StartCoroutine(FadeCo());
          
        }
    }
    public IEnumerator FadeCo()
    {
        if (fadeoutpanel != null)
        {
            Instantiate(fadeoutpanel, Vector3.zero, Quaternion.identity);
        } 
            yield return new WaitForSeconds(fadewait);
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad);
            while (!asyncOperation.isDone) {
                yield return null;
            }
        }   
    }
