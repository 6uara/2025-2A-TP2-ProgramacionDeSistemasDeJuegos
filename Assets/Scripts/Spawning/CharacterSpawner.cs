using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    private static CharacterSpawner _instance;
    public static CharacterSpawner Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<CharacterSpawner>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject("CharacterSpawner");
                    _instance = obj.AddComponent<CharacterSpawner>();
                }
            }
            return _instance;
        }
    }

    private ICharacterFactory _factory = new CharacterFactory();

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void Spawn(CharacterSO player)
    {
        _factory.CreateCharacter(player, transform.position, transform.rotation);
    }
}
