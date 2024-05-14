
using UnityEngine;
using UnityEngine.UI;

public class soundBtn : MonoBehaviour
{
    public Sprite onImg;
    public Sprite offImg;
    [SerializeField] private  Button button;
    private bool isClick = false;

    void Start()
    {
       
        button = GetComponent<Button>();

        button.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        isClick = !isClick;

        Image buttonImage = button.image;

        if (isClick)
        {
            buttonImage.sprite = offImg;
            SoundManager.instance.stopSound(SoundManager.SoundType.BackgroundMusic);
        }

        else
        {
            buttonImage.sprite = onImg;
            SoundManager.instance.playSound(SoundManager.SoundType.BackgroundMusic);
        }
    }

}
