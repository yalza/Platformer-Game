using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthText : MonoBehaviour
{
    public Vector3 moveSpeed = new Vector3(0, 75, 0);
    public float timeToFade = 1f;

    private float _timeElapsed = 0f;
    private Color _startColor;

    RectTransform textTransform;
    TextMeshProUGUI text;

    private void Awake()
    {
        textTransform = GetComponent<RectTransform>();
        text = GetComponent<TextMeshProUGUI>();
        _startColor = text.color;
    }

    private void Update()
    {
        textTransform.position += moveSpeed * Time.deltaTime;
        _timeElapsed += Time.deltaTime;

        if(_timeElapsed < timeToFade)
        {
            float fadeAlpha = _startColor.a * (1 - _timeElapsed / timeToFade);
            text.color = new Color(_startColor.r, _startColor.g,_startColor.b, fadeAlpha);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
