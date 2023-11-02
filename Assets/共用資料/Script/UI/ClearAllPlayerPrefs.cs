using UnityEngine;

namespace TwoD
{
    public class ClearAllPlayerPrefs : MonoBehaviour
    {
        public void Clear()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
