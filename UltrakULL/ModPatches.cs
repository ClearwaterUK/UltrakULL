using System.Collections;
using UnityEngine;

using static UltrakULL.CommonFunctions;

namespace UltrakULL
{
    public static class ModPatches
    {
        public static IEnumerator UltraTweakerPatch()
        {
            yield return new WaitForSeconds(0.5f);

            GameObject languageButton = GetGameObjectChild(GetGameObjectChild(GetInactiveRootObject("Canvas"), "OptionsMenu"),"Language");
            languageButton.transform.localPosition = new Vector3(450, 310, 0);
        }

    }
}
