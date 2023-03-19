using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuCloud : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private float speed;

    [Header("References")]
    private RectTransform cloudRect;


    private void Start()
    {
        cloudRect = GetComponent<RectTransform>();
    }

    void Update()
    {
        cloudRect.anchoredPosition = new Vector2(Mathf.MoveTowards(cloudRect.anchoredPosition.x, -300, Time.deltaTime * speed), cloudRect.anchoredPosition.y);

        if (cloudRect.anchoredPosition.x == -300)
        {
            cloudRect.anchoredPosition = new Vector2(2500, cloudRect.anchoredPosition.y);
        }
    }
}
