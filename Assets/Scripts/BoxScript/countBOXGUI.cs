
using UnityEngine;
using TMPro;
using System;
public class countBOXGUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countTrue;
    [SerializeField] private TextMeshProUGUI countFalse;

    // Start is called before the first frame update
    private void Update()
    {
        countTrue.text=BoxManager.Instance.countTrue.ToString();
        countFalse.text=BoxManager.Instance.countFalse.ToString();
    }
}
