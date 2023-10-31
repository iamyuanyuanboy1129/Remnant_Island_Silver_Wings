using UnityEngine;

namespace TwoD
{
    public class PlayerRevive : MonoBehaviour
    {
        public void SetPlayerPos()
        {
            if(PlayerPrefs.GetString("PositionSaved") != "")
            {
                print(PlayerPrefs.GetString("PositionSaved"));
                GameObject.FindGameObjectWithTag("Player").transform.position = StringToV3(PlayerPrefs.GetString("PositionSaved"));
            }
        }
        public Vector3 StringToV3(string posStr)
        {
            if (posStr.StartsWith("(") && posStr.EndsWith(")"))
            {
                posStr = posStr.Substring(1, posStr.Length - 2);
            }
            string[] newPosArr = posStr.Split(",");

            Vector3 newPos = new Vector3(float.Parse(newPosArr[0]) + 1, float.Parse(newPosArr[1]), float.Parse(newPosArr[2]));

            return newPos;
        }
    }
}
