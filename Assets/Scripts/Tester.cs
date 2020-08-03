using UnityEngine;
using CodeOverload;

public class Tester : MonoBehaviour
{
    private void Start()
    {
        InputManager.SubscribeToAction1(Action1Callback);
        InputManager.SubscribeToAction2(Action2Callback);

        InputManager.SubscribeToPlayer1Forward(Player1Forward);
    }

    private void Action1Callback()
    {
        Debug.Log("Executing Action 1");
    }

    private void Action2Callback()
    {
        Debug.Log("Executing Action 2");

        InputManager.UnsubscribeFromAction1(Action1Callback);
    }

    private void Player1Forward()
    {
        Debug.Log("Player 1 Forward");
    }
}
