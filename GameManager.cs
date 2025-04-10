using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class GameManager : MonoBehaviour
{

    private static GameManager instance;
    public bool correct;
    public string buttonName;
    public string noteTexName;
    public int noteGameScore = 0;
    public int noteGameStreak = 0;
   

    #region CoolANd(not)Stolen
    public static GameManager Instance
    {
        get
        {

            if (instance == null)
            {
                Debug.Log("game manager full");
            }
            return instance;

        }
    }
    private void Awake()
    {
        if(instance)
            Destroy(gameObject);
        else
            instance = this;
        DontDestroyOnLoad(this);
    }
    #endregion


}


