using UltrakULL.audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using static UltrakULL.CommonFunctions;

namespace UltrakULL
{
    class PrimeSanctum
    {
        private void PatchSecretText(PrimeSanctumStrings strings)
        {
            GameObject bossRoom = GetInactiveRootObject("3 - Fuckatorium");

            Text secretText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(bossRoom, "3 Stuff"),"End"),"FinalRoom Prime"),"Testament Shop"),"Canvas"),"Border"),"TipBox"),"Panel"),"Scroll View"),"Viewport"),"Content"),"Text (1)"));
            secretText.fontSize = 18;
            secretText.text = strings.GetSecretText();
        }

        public PrimeSanctum(ref GameObject level)
        {
            string currentLevel = SceneManager.GetActiveScene().name;

            if (currentLevel.Contains("P-1"))
            {
                PrimeSanctumStrings primeSanctumChallengeStrings = new PrimeSanctumStrings();
                string levelname = primeSanctumChallengeStrings.GetLevelName();
                PatchResultsScreen(levelname, "");
                
                PatchSecretText(primeSanctumChallengeStrings);
                AudioSwapper.AudioSwap(SceneManager.GetActiveScene().name);
            }
        }
    }
}
