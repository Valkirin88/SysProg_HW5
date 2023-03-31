using UnityEngine;
using UnityEngine.Networking;
public class Player : NetworkBehaviour
{
    [SerializeField]
    private GameObject playerPrefab;
    private GameObject playerCharacter;

    private void Start()
    {
        DontDestroyOnLoad(this);
        SpawnCharacter();
    }
    private void SpawnCharacter()
    {
        if (!isServer)
        {
            return;
        }
        playerCharacter = Instantiate(playerPrefab);
        NetworkServer.SpawnWithClientAuthority(playerCharacter,
        connectionToClient);
    }
}
