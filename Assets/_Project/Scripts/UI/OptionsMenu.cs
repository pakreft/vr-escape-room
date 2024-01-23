using Autohand;
using UnityEngine;

namespace EchoShellVR.UI
{
    public class OptionsMenu : MonoBehaviour
    {
        [SerializeField] private AutoHandPlayer player;

        public void SetRotationType(int value)
        {
            player.rotationType = (RotationType)value;
        }
    }
}
