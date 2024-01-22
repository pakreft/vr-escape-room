using UnityEngine;

namespace EchoShellVR.Utils
{
    public class Utils : MonoBehaviour
    {
        [Tooltip("Game object to toggle active.")]
        [SerializeField] private GameObject go;

        public void ToggleGameObjectActive()
        {
            go.SetActive(!go.activeSelf);
        }
    }
}
