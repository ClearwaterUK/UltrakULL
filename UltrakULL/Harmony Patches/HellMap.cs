using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using TMPro;
using UltrakULL.json;
using UnityEngine;

using static UltrakULL.CommonFunctions;

namespace UltrakULL.Harmony_Patches
{
	[HarmonyPatch(typeof(HellMap), "Start")]
	public static class HellMap_AwakePatch
	{
		private static char FastHinduNumeral(char numeral)
		{
			switch ((ushort)numeral) {
				case 0x0030:
					return (char)0x0660;
				case 0x0031:
					return (char)0x0661;
				case 0x0032:
					return (char)0x0662;
				case 0x0033:
					return (char)0x0663;
				case 0x0034:
					return (char)0x0664;
				case 0x0035:
					return (char)0x0665;
				case 0x0036:
					return (char)0x0666;
				case 0x0037:
					return (char)0x0667;
				case 0x0038:
					return (char)0x0668;
				case 0x0039:
					return (char)0x0669;
				default:
					return numeral;
			}
		}

		private static void RtlFixLevel(GameObject root, string levelName, bool useHinduNumerals)
		{
			char cAct = levelName[0];
			int iAct = 0;
			switch (cAct)
			{
				case '1':
				case '2':
				case '3':
					iAct = 1;
					break;
				case '4':
				case '5':
				case '6':
					iAct = 2;
					break;
				case '7':
				case '8':
				case '9':
					iAct = 3;
					break;
				default:
					iAct = 4;
					break;
			}

			GameObject actHellMap = GetGameObjectChild(root, $"Hellmap Act {iAct}");
			if (actHellMap == null)
			{
				Logging.Message($"Hellmap RtlFixLevel is FUCKED!!");
				return;
			}

			GameObject levelObject = GetGameObjectChild(actHellMap, levelName);
			if (levelObject == null)
			{
				Logging.Message($"Hellmap RtlFixLevel is FUCKED!!");
				return;
			}

			RectTransform rectTransform = levelObject.GetComponent<RectTransform>();
			if (rectTransform == null)
			{
				return;
			}

			rectTransform.anchorMax = new Vector2(0.50f, 1.00f);

			if (useHinduNumerals)
			{
				GameObject textObject = GetGameObjectChild(levelObject, "Text");
				if (textObject == null)
				{
					return;
				}
				TextMeshProUGUI textMesh = GetTextMeshProUGUI(textObject);
				if (textMesh == null)
				{
					return;
				}
				char[] chars = levelName.ToCharArray();
				chars[0] = FastHinduNumeral(levelName[2]);
				chars[2] = FastHinduNumeral(levelName[0]);
				textMesh.text = new string(chars);
			}
		}

		[HarmonyPrefix]
		public static void Prefix(HellMap __instance)
		{
			bool isRTL = LanguageManager.IsRightToLeft;
			bool isHinduNumeral = LanguageManager.CurrentLanguage.metadata.langHinduNumbers;

			if (isRTL)
			{
				GameObject root = __instance.gameObject;

				for (int layer = 0; layer < 9; layer++)
				{
					for (int mission = 0; mission < 4; mission++)
					{
						int l = layer + 1;
						int m = mission + 1;

						if (m % 3 == 0)
						{
							if (mission > 2)
							{
								break;
							}
						}

						RtlFixLevel(root, $"{l}-{m}", isHinduNumeral);
					}
				}
			}
		}
	}
}
