
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class BoxManager : MonoBehaviour
{
    public  int countmaxBox;
    [HideInInspector]
    public int countTrue=0;
    [HideInInspector]
    public int countFalse = 0;

    public static BoxManager Instance;

    public event Action AllBoxesUsed;
    [SerializeField] private GameObject nextLevelPanel;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        AllBoxesUsed += CheckCountBox;
    }

    private void OnDestroy()
    {
        AllBoxesUsed -= CheckCountBox;
    }
    private void CheckCountBox()
    {
        if (countTrue == countmaxBox)
        {
            nextLevelPanel.SetActive(true);
            SoundManager.instance.playSound(SoundManager.SoundType.RightColorBox);
            nextLevelPanel.transform.GetComponent<RectTransform>().DOAnchorPos(new Vector3(5, 7, 0), 0.8f).SetEase(Ease.InBack);
        }
    }

    public void BoxUsed(bool used)
    {
        if (used)
        {
            countTrue++;
        }
        else if (!used)
        {
            countFalse++;

        }
        if (countTrue == countmaxBox)
        {
            AllBoxesUsed?.Invoke();
        }
    }


}
