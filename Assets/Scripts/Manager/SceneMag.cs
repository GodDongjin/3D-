using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneMag : MonoBehaviour
{
    [SerializeField]
    private Button button;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(OnClickArmorButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickArmorButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
