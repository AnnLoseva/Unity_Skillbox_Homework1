using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonLevel : MonoBehaviour
{
    [SerializeField] private int levelIndex;

    public void OnButtonClick()
    {
        SceneManager.LoadScene(levelIndex);
        Debug.Log("pressed");
    }

    private void Start()
    {
        Button button = GetComponent<Button>();
        if (button.gameObject.name == "Continue")
        {
            levelIndex = GameData.levelIndex;
            if(levelIndex == 0 )
            {
                button.interactable = false;
            }
        }
        if(GameData.levelIndex < levelIndex)
        {
           button.interactable = false;
        }
    }
}
