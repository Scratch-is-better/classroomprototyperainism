using UnityEngine;


namespace Valve.VR.InteractionSystem.Sample
{
    public class ButtonExample : MonoBehaviour
    {

        int num = 0;
        public void OnButtonDown(Hand fromHand)
        {
            GameManager gameManager = GameManager.Instance;
            gameManager.buttonName = gameObject.name;

            Debug.Log("button is " + gameObject.name);
            Debug.Log("note is " + gameManager.noteTexName);

            if (gameObject.name == gameManager.noteTexName)
            {
                gameManager.correct = true;
                gameManager.noteGameScore += 10;
                gameManager.noteGameStreak++;
                ColorSelf(Color.green);
                Debug.Log(gameManager.noteGameScore);
                Debug.Log(gameManager.noteGameStreak);

            }
            else
            {
                ColorSelf(Color.red);
                gameManager.noteGameScore -= 10;
                gameManager.noteGameStreak = 0;
                if (gameManager.noteGameScore < 0) gameManager.noteGameScore = 0;
                Debug.Log(gameManager.noteGameScore);
                Debug.Log(gameManager.noteGameStreak);

            }
        }

        public void OnButtonUp(Hand fromHand)
        {
            ColorSelf(Color.white);
        }

        private void ColorSelf(Color newColor)
        {
            Renderer[] renderers = this.GetComponentsInChildren<Renderer>();
            for (int childCount = 0; childCount < renderers.Length; childCount++)
            {
                renderers[childCount].material.color = newColor;
            }
        }
    }

}