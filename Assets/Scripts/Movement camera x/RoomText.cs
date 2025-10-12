using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomText : MonoBehaviour
{
    public bool needtext;
    public string placeName;
    public GameObject text;
    public Text placetext;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            if (needtext)
            {

                StartCoroutine(placeNameCo());
            }
        }
    }
        private IEnumerator placeNameCo()
        {
            text.SetActive(true);
            placetext.text = placeName;
            yield return new WaitForSeconds(4f);
            text.SetActive(false);
            needtext = false;

        }
    }
