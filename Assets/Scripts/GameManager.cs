using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    bool inGame = false;
    [SerializeField] GameObject playerObject = null;
    int killCount = 0;
    [SerializeField] Text killCountText = null;

    private void Awake()
    {
        Application.targetFrameRate = 60;

        bool titleSceneLoaded = false;

        foreach (Scene s in SceneManager.GetAllScenes())
        {
            if (s.name == "TitleScene")
                titleSceneLoaded = true;
        }
        if (!titleSceneLoaded)
            SceneManager.LoadScene("TitleScene", LoadSceneMode.Additive);

        Koma_Rotate.EndRotate();
        Player_Move.EndGame();
    }

    public void StartGame()
    {
        this.inGame = true;
        Camera_Animation.Instance.SetCameraState(1);
        Enemy_Chase.SetTargetPlayer(this.playerObject);
        EnemySpawner.Instance.StartGame();
        Player_Move.StartGame();
        SoundController.Instance.PlayBGM("Battle");
    }

    public void EndGame()
    {
        this.inGame = false;
        Koma_Rotate.EndRotate();
        Player_Move.EndGame();
        SceneManager.LoadScene("MainScene");
    }

    public void KillCountUp()
    {
        this.killCount += 1;
        killCountText.text = $"x {killCount}";
    }
}
