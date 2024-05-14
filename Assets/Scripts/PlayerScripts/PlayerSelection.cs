using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerSelection : MonoBehaviour
{
    ICharacterFactory factory;
    PlayerManager currentPlayer;

    public static PlayerSelection Instance;

    public void Awake()
    {
        if (Instance == null)
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
        SelectPlayer(Pref.CurPlayerId);
        Debug.Log("id HIEN TAI " + Pref.CurPlayerId);
    }

    public void SelectPlayer(int playerNumber)
    {
        currentPlayer = gameObject.GetComponent<PlayerManager>();
        if (currentPlayer == null)
        {
            Debug.LogError("PlayerManager component is missing!");
            return;
        }
        

        switch (playerNumber)
        {
            case 0:
                factory = new RectangleFactory();
                break;
        }

        currentPlayer.SetFactory(factory);
        DestroyCurrentCharacter();
        currentPlayer.CreateCharacter();
    }

    void DestroyCurrentCharacter()
    {
        var childComponents = currentPlayer.GetComponentsInChildren<Component>();
        foreach (var childComponent in childComponents)
        {            if (childComponent is Character)
            {
                // Nếu có, hủy đối tượng
                Destroy(childComponent.gameObject);
            }
        }
    }
}