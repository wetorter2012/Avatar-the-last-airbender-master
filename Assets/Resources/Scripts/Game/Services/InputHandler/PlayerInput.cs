using UnityEngine;

namespace Game.Services.InputHandler
{
    public class PlayerInput
    {
        public bool OnLeftMouseDown() => Input.GetMouseButtonDown(0);
        public bool OnRightMouseDown() => Input.GetMouseButtonDown(1);
        public Vector3 MousePosition() => Input.mousePosition;
        public bool OnKeyDown(KeyCode keyCode) => Input.GetKeyDown(keyCode);
    }
}
