using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonLevel : MonoBehaviour
{
    [SerializeField] private int levelIndex;

    public void OnButtonClick()
    {

        if (levelIndex >= GameData.levelIndex)
        {
            GameData.levelIndex = levelIndex + 1;
        }

        SceneManager.LoadScene(levelIndex);

    }

    private void Start()
    {
        Button button = GetComponent<Button>();
        if (button.gameObject.name == "Continue")
        {
            levelIndex = GameData.levelIndex -1;
            if(levelIndex <= 1 )
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
