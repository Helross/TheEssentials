using UnityEngine;
using System;

namespace CodeOverload
{
    public class InputManager : MonoBehaviour
    {
        private static InputManager _instance;

        [SerializeField] private KeyCode _action1Key;
        [SerializeField] private KeyCode _action1KeyAlternate;
        [SerializeField] private KeyCode _action2Key;
        [SerializeField] private KeyCode _action2KeyAlternate;

        private event Action Action1Event;
        private event Action Action2Event;

        [SerializeField] private PlayerInput _player1Controls;
        [SerializeField] private PlayerInput _player2Controls;

        private void Awake() => _instance = this;

        private void Update()
        {
            if (Input.GetKeyDown(_action1Key) || Input.GetKeyDown(_action1KeyAlternate)) Action1Event?.Invoke();
            if (Input.GetKeyDown(_action2Key) || Input.GetKeyDown(_action2KeyAlternate)) Action2Event?.Invoke();

            if (Input.GetKeyDown(_player1Controls._moveForward)) _player1Controls.InvokeForward();
        }

        public static void SubscribeToAction1(Action callback) => _instance.Action1Event += callback;
        public static void UnsubscribeFromAction1(Action callback) => _instance.Action1Event -= callback;
        public static void SubscribeToAction2(Action callback) => _instance.Action2Event += callback;
        public static void UnsubscribeFromAction2(Action callback) => _instance.Action2Event -= callback;

        public static void SubscribeToPlayer1Forward(Action callback) => _instance._player1Controls.MoveForwardEvent += callback;
        public static void UnsubscribeFromPlayer1Forward(Action callback) => _instance._player1Controls.MoveForwardEvent -= callback;
    }

    [Serializable]
    public class PlayerInput
    {
        public KeyCode _moveForward;
        public KeyCode _moveBackwards;

        public event Action MoveForwardEvent;
        public event Action MoveBackwardsEvent;

        public void InvokeForward() => MoveForwardEvent?.Invoke();
        public void InvokeBackwards() => MoveBackwardsEvent?.Invoke();
    }
}
