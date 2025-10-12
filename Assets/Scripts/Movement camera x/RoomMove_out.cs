using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class RoomMove_out : MonoBehaviour
{
    public Vector2 cameraChangeMax;
    public Vector2 cameraChangeMin;
    public Vector3 pos;
    private CameraMovement cam;
    public bool needtext;
    public string placeName;
    public GameObject text;
    public Text placetext;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cam.minPosition.x = cameraChangeMin.x;
            cam.maxPosition.x = cameraChangeMax.x;
            cam.minPosition.y = cameraChangeMin.y;
            cam.maxPosition.y = cameraChangeMax.y;

            other.transform.position = pos;
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