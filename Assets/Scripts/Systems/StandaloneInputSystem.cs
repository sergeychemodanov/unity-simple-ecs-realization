using UnityEngine;

namespace SurvivalExample
{
    public class StandaloneInputSystem : BaseSystem
    {
        private readonly EventManager _eventManager;

        public StandaloneInputSystem(EventManager eventManager)
        {
            _eventManager = eventManager;
        }

        public override void Update()
        {
            base.Update();
            CheckMoveInput();
        }

        private void CheckMoveInput()
        {
            var direction = Vector3.zero;

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                direction += Vector3.forward;

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                direction += Vector3.left;

            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                direction += Vector3.back;

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                direction += Vector3.right;

            var playerMoveEvent = new PlayerMoveEvent(direction);
            _eventManager.Publish(playerMoveEvent);
        }
    }
}