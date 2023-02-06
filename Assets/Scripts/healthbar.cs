using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class healthbar : MonoBehaviour
{
    public RectTransform barRect;

    public RectMask2D mask;

    float newHealth = 0;

    Vector4 padding;
    // Start is called before the first frame update
    void Start()
    {

        
        padding = mask.padding;
    }
    

    public void SetValue(float newValue)
    {
        newHealth = (100 - newValue)*4;
        padding.z = newHealth;
        mask.padding = padding;
    }
}
