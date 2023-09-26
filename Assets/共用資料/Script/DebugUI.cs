using TMPro;
using TwoD;
using UnityEngine;

public class DebugUI : MonoBehaviour
{
    public GameObject player;
    public TMP_Text textMeshPro;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player_Idle");
        textMeshPro.text = "123";
    }

    // Update is called once per frame
    void Update()
    {
        textMeshPro.text = player.transform.GetChild(1).GetChild(0).GetComponent<DamageSystem>().damage.ToString();
    }
}
