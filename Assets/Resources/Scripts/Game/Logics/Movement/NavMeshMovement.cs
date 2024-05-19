using Game.Services.InputHandler;
using Game.Services.Locator;
using UnityEngine;
using UnityEngine.AI;

namespace Game.Logics.Movement
{
    public class NavMeshMovement : MonoBehaviour, IInjectServices
    {
        [field: SerializeField] public float Speed { get; private set; }

        [SerializeField] LayerMask _movementLaers;

        NavMeshAgent _agent;
        Camera _camera;
        PlayerInput _playerInput;

        public void Inject(IServiceLocator locator)
        {
            _playerInput = locator.GetService<PlayerInput>();
        }

        private void Awake()
        {
            _camera = Camera.main;
            _agent = GetComponent<NavMeshAgent>();

            if (_agent == null)
            {
                _agent = gameObject.AddComponent<NavMeshAgent>();
            }

            _agent.speed = Speed;
        }

        void Update()
        {
            if (_playerInput != null && _playerInput.OnRightMouseDown())
            {
                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out var hitResult, 150.0f, _movementLaers))
                {
                    _agent.SetDestination(hitResult.point);
                }
            }
        }

        public void StopMovement()
        {
            _agent.ResetPath();
        }

        public void EnabledMovement()
        {
            _agent.enabled = true;
            _agent.isStopped = false;
        }

        public void DisabledMovement()
        {
            _agent.isStopped = true;
            _agent.enabled = false;
        }
    }
}
