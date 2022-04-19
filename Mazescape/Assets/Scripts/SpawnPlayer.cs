using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] GameObject[] prefabs;
    private GameObject player;
    private GameObject playerBody;

    public int choice = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) return;

        // choice = 0;
        playerBody = Instantiate(prefabs[choice]);
        player.transform.SetParent(playerBody.transform);
    }
}
