using UnityEngine;

namespace TopDownShooter
{
    public class ChestComponent : MonoBehaviour
    {
        [SerializeField]
        private int _numberHealthPoints;
        private Animation _animation;
        private Collider _collider;

        [SerializeField]
        private ChestCanvasComponent _chestCanvas;

        private PlayerManager _playerManager;

        private void Start()
        {
            _chestCanvas.HideCanvas();
            _animation = GetComponent<Animation>();
            _collider = GetComponent<Collider>();
        }

        private void OnEnable()
        {
            _chestCanvas.OnValueCorrect += OpenChest;
        }

        private void OnDisable()
        {
            _chestCanvas.OnValueCorrect -= OpenChest;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out PlayerManager player))
            {
                _playerManager = player;
                _chestCanvas.ShowCanvas();
            }
        }

        private void OnTriggerExit(Collider other)
        {

            if (other.gameObject.TryGetComponent(out PlayerManager player))
            {
                _chestCanvas.HideCanvas();
            }
        }

        private void OpenChest()
        {
            _playerManager?.GiveHealthPoints(_numberHealthPoints);
            _animation.Play();
            this.enabled = false;
            _chestCanvas.HideCanvas();
            _chestCanvas.enabled = false;
            _collider.enabled = false;
        }
    }
}