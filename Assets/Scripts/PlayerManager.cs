using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Range(2, 4)] public int NumberOfPlayers = 2; //contains the number of players that will be controlled by how many controllers. NEVER less than 4
    [Range(100, 1000)] public float PlayerMovementSpeed = 750f;

    public GameObject PlayerControllerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i <= NumberOfPlayers; i++)
        {
            GameObject controller = Instantiate(PlayerControllerPrefab);
            PlayerController controllerComponent = controller.GetComponent<PlayerController>();
            controllerComponent.PlayerNumber = i;
            controllerComponent.movementSpeed = PlayerMovementSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
