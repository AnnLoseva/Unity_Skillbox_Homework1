using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{

    [SerializeField] private Sprite nextSprite;

    private Image image;
    private Sprite temp;
    private Sprite currentSprite;


    private void Start()
    {

        image = GetComponent<Image>();
        currentSprite = image.sprite;
    }

    public void ChangeImageButton()
    {
        image.sprite = nextSprite;
        temp = currentSprite;
        currentSprite = nextSprite;
        nextSprite = temp;
        
    }


}
