﻿using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UltrakULL.CommonFunctions;
using UltrakULL.json;
using System.Data;

namespace UltrakULL
{
	public static class MainMenu
	{

		//Patches all text strings in the title menu.
		private static void PatchMainMenu(GameObject mainMenu)
		{
			try
			{
				GameObject titleObject = GetGameObjectChild(mainMenu, "Main Menu (1)");

				//Early access tag
				TextMeshProUGUI earlyAccessText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(titleObject, "Title"), "Text"));
				earlyAccessText.text = "--" + LanguageManager.CurrentLanguage.frontend.mainmenu_earlyAccess + "--";

                //Halloween
                TextMeshProUGUI halloweenText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(titleObject, "Title"), "Text (Halloween)"));
				halloweenText.text = "<color=orange>--" + LanguageManager.CurrentLanguage.frontend.mainmenu_halloween + "--</color>";

                //Easter
                TextMeshProUGUI easterText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(titleObject, "Title"), "Text (Easter)"));
				easterText.text = "<color=magenta>--" + LanguageManager.CurrentLanguage.frontend.mainmenu_easter + "--</color>";

                //Christmas
                TextMeshProUGUI christmasText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(titleObject, "Title"), "Text (Christmas)"));
				christmasText.text = "<color=red>--" + LanguageManager.CurrentLanguage.frontend.mainmenu_christmas + "--</color>";

				//Play button
				TextMeshProUGUI playButtonText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(titleObject, "Continue"), "Text"));
				playButtonText.text = LanguageManager.CurrentLanguage.frontend.mainmenu_play;

				//Options button
				TextMeshProUGUI optionsButtontext = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(titleObject, "Options"), "Text"));
				optionsButtontext.text = LanguageManager.CurrentLanguage.frontend.mainmenu_options;

				//Credits button
				TextMeshProUGUI creditsButtontext = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(titleObject, "Credits"), "Text"));
				creditsButtontext.text = LanguageManager.CurrentLanguage.frontend.mainmenu_credits;

				//Quit button
				TextMeshProUGUI quitButtontext = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(titleObject, "Quit"), "Text"));
				quitButtontext.text = LanguageManager.CurrentLanguage.frontend.mainmenu_quit;

				//UMM buttons

				foreach (Transform a in titleObject.GetComponentsInChildren<Transform>())
				{
					if(a.name == "ModsButton")
					{
						Text modsButtonText = GetTextfromGameObject(GetGameObjectChild(a.gameObject,"Text"));
						modsButtonText.text = LanguageManager.CurrentLanguage.frontend.mainmenu_mods;
					}
					if(a.name == "RestartButton")
					{
						Text restartButtonText = GetTextfromGameObject(GetGameObjectChild(a.gameObject,"Text"));
						restartButtonText.text = LanguageManager.CurrentLanguage.frontend.mainmenu_restart;
					}
				}
			}
			catch (Exception e)
			{
				Logging.Error("An error occured while patching main menu. Check the console for details.");
				Logging.Error(e.ToString());
			}
		}
		
		public static void ChangeTitle(GameObject mainMenu)
		{
			try
            {
				Logging.Warn("Attempting to change the main menu's title image");
                GameObject trueMainMenu = GetGameObjectChild(mainMenu, "Main Menu (1)");

                if (Core.ArabicUltrakillLogo != null)
                {
                    GameObject TitleObject = GetGameObjectChild(trueMainMenu, "Title");
					if(GetGameObjectChild(trueMainMenu, "Title(Clone)") == null)
					{
						GameObject.Instantiate(TitleObject, TitleObject.transform.position, Quaternion.identity, trueMainMenu.transform);
                    }
                    GameObject titleObjectArabic = GetGameObjectChild(trueMainMenu, "Title(Clone)");
                    titleObjectArabic.GetComponent<Image>().sprite = Core.ArabicUltrakillLogo;
                    if (LanguageManager.CurrentLanguage.metadata.langName == "en-AR")
					{
						TitleObject.SetActive(false);
						titleObjectArabic.SetActive(true);
					}
					else
					{
						TitleObject.SetActive(true);
						titleObjectArabic.SetActive(false);
					}
                }
            }
            catch (Exception e)
            {
                Logging.Error("An error occured while switching the title. Check the console for details.");
                Logging.Error(e.ToString());
            }
        }

		//Patches all text strings in the difficulty selection menu.
		private static void PatchDifficultyMenu(GameObject frontEnd)
		{
			try
			{
				GameObject difficultyObject = GetGameObjectChild(frontEnd, "Difficulty Select (1)");

				//Difficulty header text (note: this can't fit much without reducing the default font size.)
				TextMeshProUGUI difficultyText = GetTextMeshProUGUI(difficultyObject.transform.Find("Title").gameObject);
				difficultyText.text = LanguageManager.CurrentLanguage.frontend.difficulty_title;

				//Easy header text
				GameObject easyObject = difficultyObject.transform.Find("Easy").gameObject;
                TextMeshProUGUI easyText = GetTextMeshProUGUI(easyObject);
				easyText.text =LanguageManager.CurrentLanguage.frontend.difficulty_easy;

                //Normal header text
                TextMeshProUGUI normalText = GetTextMeshProUGUI(difficultyObject.transform.Find("Normal").gameObject);
				normalText.text = LanguageManager.CurrentLanguage.frontend.difficulty_normal;

                //Hard header text
                TextMeshProUGUI hardText = GetTextMeshProUGUI(difficultyObject.transform.Find("Hard").gameObject);
				hardText.text = LanguageManager.CurrentLanguage.frontend.difficulty_hard;

				//Harmless header
				GameObject harmlessTextObject = GetGameObjectChild(difficultyObject, "Casual Easy");
                TextMeshProUGUI harmlessText = GetTextMeshProUGUI(harmlessTextObject.transform.Find("Name").gameObject);
				harmlessText.text = LanguageManager.CurrentLanguage.frontend.difficulty_harmless;

				//Lenient header
				GameObject lenientTextObject = GetGameObjectChild(difficultyObject, "Casual Hard");
                TextMeshProUGUI lenientText = GetTextMeshProUGUI(lenientTextObject.transform.Find("Name").gameObject);
				lenientText.text = LanguageManager.CurrentLanguage.frontend.difficulty_lenient;

				//Standard header
				GameObject standardTextObject = GetGameObjectChild(difficultyObject, "Standard");
                TextMeshProUGUI standardText = GetTextMeshProUGUI(standardTextObject.transform.Find("Name").gameObject);
				standardText.text = LanguageManager.CurrentLanguage.frontend.difficulty_standard;

				//Violent header
				GameObject violentTextObject = GetGameObjectChild(difficultyObject, "Violent");
                TextMeshProUGUI violentText = GetTextMeshProUGUI(violentTextObject.transform.Find("Name").gameObject);
				violentText.text = LanguageManager.CurrentLanguage.frontend.difficulty_violent;

				//Brutal header
				GameObject brutalTextObject = GetGameObjectChild(difficultyObject, "Brutal");
                TextMeshProUGUI brutalText = GetTextMeshProUGUI(brutalTextObject.transform.Find("Name").gameObject);
				brutalText.text = LanguageManager.CurrentLanguage.frontend.difficulty_brutal;

                		//UKMD header
                		GameObject umdTextObject = GetGameObjectChild(difficultyObject, "V1 Must Die");
						TextMeshProUGUI umdText = GetTextMeshProUGUI(umdTextObject.transform.Find("Name").gameObject);
                		umdText.text = LanguageManager.CurrentLanguage.frontend.difficulty_umd;

				//No need for UMD header yet as it's not in-game

				if (LanguageManager.IsRightToLeft)
				{
					RtlFixDifficultyButton(brutalTextObject, brutalText);
					RtlFixDifficultyButton(violentTextObject, violentText);
					RtlFixDifficultyButton(standardTextObject, standardText);
					RtlFixDifficultyButton(lenientTextObject, lenientText);
					RtlFixDifficultyButton(harmlessTextObject, harmlessText);
				}

				//Tooltip
				GameObject assistTip = GetGameObjectChild(difficultyObject, "Assist Tip");
				TextMeshProUGUI assistTipText = GetTextMeshProUGUI(assistTip);
				assistTipText.text = LanguageManager.CurrentLanguage.frontend.difficulty_tweakReminder;
			}
			catch (Exception e)
			{
				Logging.Error("Failed to patch difficulty menu.");
				Logging.Error(e.ToString());
			}
		}

		//Same as above.
		private static void PatchDifficultyDescriptors(GameObject frontEnd)
		{
			try
			{
				GameObject difficultyObject = GetGameObjectChild(frontEnd, "Difficulty Select (1)");

				//Harmless title
				GameObject harmlessObject = GetGameObjectChild(difficultyObject, "Harmless Info");
				TextMeshProUGUI harmlessTitle = GetTextMeshProUGUI(harmlessObject.transform.Find("Title (1)").gameObject);
				harmlessTitle.text = "--" + LanguageManager.CurrentLanguage.frontend.difficulty_harmless + "--";

                //Harmless descriptor
                TextMeshProUGUI harmlessDescriptor = GetTextMeshProUGUI(harmlessObject.transform.Find("Text").gameObject);
				harmlessDescriptor.text =
					LanguageManager.CurrentLanguage.frontend.difficulty_harmlessDescription1
					+ "\n\n"
					+ LanguageManager.CurrentLanguage.frontend.difficulty_harmlessDescription2
					+ "\n\n"
					+ "<color=green>" + LanguageManager.CurrentLanguage.frontend.difficulty_harmlessDescription3 + "</color>";

				//Lenient title
				GameObject lenientObject = GetGameObjectChild(difficultyObject, "Lenient Info");
                TextMeshProUGUI lenientTitle = GetTextMeshProUGUI(lenientObject.transform.Find("Title (1)").gameObject);
				lenientTitle.text = "--" + LanguageManager.CurrentLanguage.frontend.difficulty_lenient + "--";

                //Lenient descriptor
                TextMeshProUGUI lenientDescriptor = GetTextMeshProUGUI(lenientObject.transform.Find("Text").gameObject);
				lenientDescriptor.text =
					LanguageManager.CurrentLanguage.frontend.difficulty_lenientDescription1
					+ "\n\n"
					+ LanguageManager.CurrentLanguage.frontend.difficulty_lenientDescription2
					+ "\n\n"
					+ "<color=yellow>" + LanguageManager.CurrentLanguage.frontend.difficulty_lenientDescription3 + "</color>";

				//Standard title
				GameObject standardObject = GetGameObjectChild(difficultyObject, "Standard Info");
                TextMeshProUGUI standardTitle = GetTextMeshProUGUI(standardObject.transform.Find("Title (1)").gameObject);
				standardTitle.text = "--" + LanguageManager.CurrentLanguage.frontend.difficulty_standard + "--";

                //Standard descriptor
                TextMeshProUGUI standardDescriptor = GetTextMeshProUGUI(standardObject.transform.Find("Text").gameObject);
				standardDescriptor.text =
					LanguageManager.CurrentLanguage.frontend.difficulty_standardDescription1
					+ "\n\n"
					+ LanguageManager.CurrentLanguage.frontend.difficulty_standardDescription2
					+ "\n\n"
					+ "<color=orange>" + LanguageManager.CurrentLanguage.frontend.difficulty_standardDescription3 + "</color>";

				//Violent title
				GameObject violentObject = GetGameObjectChild(difficultyObject, "Violent Info");
                TextMeshProUGUI violentTitle = GetTextMeshProUGUI(violentObject.transform.Find("Title (1)").gameObject);
				violentTitle.text = "--" + LanguageManager.CurrentLanguage.frontend.difficulty_violent + "--";

                //Violent descriptor
                TextMeshProUGUI violentDescriptor = GetTextMeshProUGUI(violentObject.transform.Find("Text").gameObject);
				violentDescriptor.text =
                    LanguageManager.CurrentLanguage.frontend.difficulty_violentDescription1
					+ "\n\n"
					+ LanguageManager.CurrentLanguage.frontend.difficulty_violentDescription2
                    + "\n\n"
					+ "<color=red>" + LanguageManager.CurrentLanguage.frontend.difficulty_violentDescription3 + "</color>";

				//Brutal title
				GameObject brutalObject = GetGameObjectChild(difficultyObject, "Brutal Info");
                TextMeshProUGUI brutalTitle = GetTextMeshProUGUI(brutalObject.transform.Find("Title (1)").gameObject);
				brutalTitle.text = "--" + LanguageManager.CurrentLanguage.frontend.difficulty_brutal + "--";

                //Brutal descriptor
                TextMeshProUGUI brutalDescriptor = GetTextMeshProUGUI(brutalObject.transform.Find("Text").gameObject);
				brutalDescriptor.text =
					"<color=white>" + LanguageManager.CurrentLanguage.frontend.difficulty_brutalDescription1
                    + "\n\n"
                    + LanguageManager.CurrentLanguage.frontend.difficulty_brutalDescription2 + "</color>"
                    + "\n\n"
                    + "<b>" + LanguageManager.CurrentLanguage.frontend.difficulty_brutalDescription3 + "<b>";

                TextMeshProUGUI underConstructionText = GetTextMeshProUGUI(GetGameObjectChild(difficultyObject, "Under Construction"));
				underConstructionText.text = LanguageManager.CurrentLanguage.frontend.difficulty_underConstruction;

				// RTL
				if (LanguageManager.IsRightToLeft)
				{
					harmlessDescriptor.alignment = TextAlignmentOptions.TopRight;
					harmlessTitle.alignment = TextAlignmentOptions.MidlineRight;
					lenientDescriptor.alignment = TextAlignmentOptions.TopRight;
					lenientTitle.alignment = TextAlignmentOptions.MidlineRight;
					standardDescriptor.alignment = TextAlignmentOptions.TopRight;
					standardTitle.alignment = TextAlignmentOptions.MidlineRight;
					violentDescriptor.alignment = TextAlignmentOptions.TopRight;
					violentTitle.alignment = TextAlignmentOptions.MidlineRight;
				}

                //UMD stuff isn't in-game yet so the below is commmented out until the devs add them.

                /*UMD title - not in-game yet
				GameObject umdObject = GetGameObjectChild(difficultyObject, "UMD Info");
                TextMeshProUGUI umdTitle = GetTextMeshProUGUI(umdObject.transform.Find("Title (1)").gameObject);
				umdTitle.text = LanguageManager.CurrentLanguage.frontend.difficulty_umd;

                //UMD descriptor - not in-game yet
                TextMeshProUGUI brutalDescriptor = GetTextMeshProUGUI(umdObject.transform.Find("Text").gameObject);
				umdDescriptor.text = 
					LanguageManager.CurrentLanguage.frontend.difficulty_umdDescription1
					+ "\n\n"
					+ LanguageManager.CurrentLanguage.frontend.difficulty_umdDescription2
					+ "\n\n"
					+ "<color=red>" + LanguageManager.CurrentLanguage.frontend.difficulty_umdDescription3 + "</color>";
				*/

            }
            catch (Exception e)
			{
				Logging.Error("Failed to patch difficulty text.");
				Logging.Error(e.ToString());
			}

		}

		public static void RtlFixActButton(GameObject obj, TextMeshProUGUI txt)
		{
			RectTransform rect = txt.rectTransform;
			if (rect != null)
			{
				rect.anchorMax = new Vector2(1.0f, 0.5f);
				rect.anchorMin = new Vector2(1.0f, 0.5f);
				rect.anchoredPosition = new Vector3(-388f, 0f, 0f);
			}

			GameObject act1RankIcon = obj.transform.Find("RankPanel").gameObject;
			if (act1RankIcon != null)
			{
				Image rankImage = act1RankIcon.GetComponent<Image>();
				if (rankImage != null)
				{
					RectTransform rankRect = rankImage.rectTransform;
					rankRect.anchorMin = new Vector2(0.00f, 0.50f);
					rankRect.anchorMax = new Vector2(0.00f, 0.50f);
					rankRect.anchoredPosition = new Vector3(43f, 0f, 0f);
				}
			}
		}

		public static void RtlFixDifficultyButton(GameObject obj, TextMeshProUGUI txt)
		{
			RectTransform rect = txt.rectTransform;
			if (rect != null)
			{
				rect.anchorMax = new Vector2(1.0f, 0.5f);
				rect.anchorMin = new Vector2(1.0f, 0.5f);
				rect.anchoredPosition = new Vector3(-388f, 0f, 0f);
			}

			GameObject progressObject = obj.transform.Find("Progress").gameObject;
			if (progressObject != null)
			{
				Text progress = progressObject.GetComponent<Text>();
				if (progress != null)
				{
					progress.alignment = TextAnchor.MiddleLeft;
					RectTransform rectTrans = progress.rectTransform;
					if (rectTrans != null)
					{
						rectTrans.anchoredPosition = new Vector2(380.0f - 60.0f, 0.0f);
					}
				}
				else
				{
				}
			}

			GameObject act1RankIcon = obj.transform.Find("RankPanel").gameObject;
			if (act1RankIcon != null)
			{
				Image rankImage = act1RankIcon.GetComponent<Image>();
				if (rankImage != null)
				{
					RectTransform rankRect = rankImage.rectTransform;
					if (rankRect != null)
					{
						rankRect.anchorMin = new Vector2(0.00f, 0.50f);
						rankRect.anchorMax = new Vector2(0.00f, 0.50f);
						rankRect.anchoredPosition = new Vector3(43f, 0f, 0f);
					}
				}
			}


		}

		private static void PatchChapterSelect(GameObject frontEnd)
		{
			GameObject chapterObject = GetGameObjectChild(frontEnd, "Chapter Select");
            TextMeshProUGUI chapterText = GetTextMeshProUGUI(chapterObject.transform.Find("Title (1)").gameObject);
			chapterText.text = "--" + LanguageManager.CurrentLanguage.frontend.chapter_title + "--";

			GameObject preludeObject = GetGameObjectChild(chapterObject, "Prelude");
            TextMeshProUGUI preludeText = GetTextMeshProUGUI(preludeObject.transform.Find("Name").gameObject);
			preludeText.text = LanguageManager.CurrentLanguage.frontend.chapter_prelude;

			GameObject act1Object = GetGameObjectChild(chapterObject, "Act I");
            TextMeshProUGUI act1Text = GetTextMeshProUGUI(act1Object.transform.Find("Name").gameObject);
			act1Text.text = LanguageManager.CurrentLanguage.frontend.chapter_act1;

			GameObject act2Object = GetGameObjectChild(chapterObject, "Act II");
            TextMeshProUGUI act2Text = GetTextMeshProUGUI(act2Object.transform.Find("Name").gameObject);
			act2Text.text = LanguageManager.CurrentLanguage.frontend.chapter_act2;

			GameObject act3Object = GetGameObjectChild(chapterObject, "Act III");
            TextMeshProUGUI act3Text = GetTextMeshProUGUI(act3Object.transform.Find("Name").gameObject);
			act3Text.text = LanguageManager.CurrentLanguage.frontend.chapter_act3;

			GameObject primeObject = GetGameObjectChild(chapterObject, "Prime");
            TextMeshProUGUI primeText = GetTextMeshProUGUI(primeObject.transform.Find("Name").gameObject);
			primeText.text = LanguageManager.CurrentLanguage.frontend.chapter_prime;

			GameObject cgObject = GetGameObjectChild(chapterObject, "The Cyber Grind");
            TextMeshProUGUI cgText = GetTextMeshProUGUI(cgObject.transform.Find("Name").gameObject);
			cgText.text = LanguageManager.CurrentLanguage.frontend.chapter_cyberGrind;

			GameObject sandboxObject = GetGameObjectChild(chapterObject, "Sandbox");
			TextMeshProUGUI sandboxText = GetTextMeshProUGUI(sandboxObject.transform.Find("Name").gameObject);
			sandboxText.text = LanguageManager.CurrentLanguage.frontend.chapter_sandbox;

			if (LanguageManager.IsRightToLeft)
			{
				RtlFixActButton(preludeObject, preludeText);
				RtlFixActButton(act1Object, act1Text);
				RtlFixActButton(act2Object, act2Text);
				RtlFixActButton(act3Object, act3Text);
				RtlFixActButton(sandboxObject, sandboxText);
				RtlFixActButton(cgObject, cgText);
				RtlFixActButton(primeObject, primeText);
            }
        }

		private static void PatchLevelSelectPrelude(GameObject frontEnd)
		{
			GameObject lsPreludeObject = GetGameObjectChild(frontEnd, "Level Select (Prelude)");
			
			GameObject preludeHeader = GetGameObjectChild(GetGameObjectChild(lsPreludeObject,"Overture"),"Header");

            //Prelude title
            TextMeshProUGUI preludeTitleText = GetTextMeshProUGUI(GetGameObjectChild(preludeHeader,"Text"));
			preludeTitleText.text = LanguageManager.CurrentLanguage.frontend.layer_prelude;
			preludeTitleText.fontSize = 36;

            //Prelude secret mission title
            TextMeshProUGUI secretText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(preludeHeader, "Secret Mission"), "Text").gameObject);
			secretText.text = LanguageManager.CurrentLanguage.frontend.chapter_secretMission;
			

			GameObject preludeObject = GetGameObjectChild(GetGameObjectChild(lsPreludeObject, "Overture"),"Level Row");
			
			//0-1 challenge
			GameObject firstObject = GetGameObjectChild(preludeObject, "0-1 Panel");
            TextMeshProUGUI firstChallenge = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(firstObject,"Panel"), "Text"));
			firstChallenge.text = PreludeStrings.GetLevelChallenge("Level 0-1");

			//0-2 challenge
			GameObject secondObject = GetGameObjectChild(preludeObject, "0-2 Panel");
            TextMeshProUGUI secondChallenge = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(secondObject, "Panel (2)"), "Text"));
			secondChallenge.text = PreludeStrings.GetLevelChallenge("Level 0-2");

			//0-3 challenge
			GameObject thirdObject = GetGameObjectChild(preludeObject, "0-3 Panel");
            TextMeshProUGUI thirdChallenge = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(thirdObject, "Panel (4)"), "Text"));
			thirdChallenge.text = PreludeStrings.GetLevelChallenge("Level 0-3");

			//0-4 challenge
			GameObject fourthObject = GetGameObjectChild(preludeObject, "0-4 Panel");
            TextMeshProUGUI fourthChallenge = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(fourthObject, "Panel (6)"), "Text"));
			fourthChallenge.text = PreludeStrings.GetLevelChallenge("Level 0-4");

			//0-5 challenge
			GameObject fifthObject = GetGameObjectChild(preludeObject, "0-5 Panel");

            TextMeshProUGUI fifthChallenge = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(fifthObject, "Panel (6)"), "Text"));
			fifthChallenge.text = PreludeStrings.GetLevelChallenge("Level 0-5");
			
			//Full intro panel why this is not using the TMPro
			GameObject fullIntroObject = GetGameObjectChild(GetGameObjectChild(lsPreludeObject, "FullIntroPopup"), "Panel");

            Text fullIntroText = GetTextfromGameObject(fullIntroObject.transform.Find("Text").gameObject);
			fullIntroText.text = LanguageManager.CurrentLanguage.frontend.level_fullIntroPrompt;

            Text fullIntroYesText = GetTextfromGameObject(GetGameObjectChild(fullIntroObject, "Button (1)").transform.Find("Text").gameObject);
			fullIntroYesText.text = LanguageManager.CurrentLanguage.frontend.level_fullIntroPromptYes;

            Text fullIntroNoText = GetTextfromGameObject(GetGameObjectChild(fullIntroObject, "Button").transform.Find("Text").gameObject);
			fullIntroNoText.text = LanguageManager.CurrentLanguage.frontend.level_fullIntroPromptNo;

            Text fullIntroCancelText = GetTextfromGameObject(GetGameObjectChild(fullIntroObject, "Button (2)").transform.Find("Text").gameObject);
			fullIntroCancelText.text = LanguageManager.CurrentLanguage.frontend.level_fullIntroPromptCancel;
		}

		//Patches all text strings in the Act 1 menu.
		private static void PatchLevelSelectAct1(GameObject frontEnd)
		{
			GameObject act1Object = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(frontEnd, "Level Select (Act I)"), "Scroll Rect"), "Contents");

			GameObject limboObject = GetGameObjectChild(act1Object, "Layer 1 Limbo");
			GameObject lustObject = GetGameObjectChild(act1Object, "Layer 2 Lust");
			GameObject gluttonyObject = GetGameObjectChild(act1Object, "Layer 3 Gluttony");

			//Layer 1 - Limbo
			GameObject limboHeader = GetGameObjectChild(limboObject,"Header");

            TextMeshProUGUI limboTitle = GetTextMeshProUGUI(GetGameObjectChild(limboHeader, "Text"));
			limboTitle.text = LanguageManager.CurrentLanguage.frontend.layer_limbo;

            TextMeshProUGUI limboSecretMissionText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(limboHeader, "Secret Mission"), "Text"));
			limboSecretMissionText.text = LanguageManager.CurrentLanguage.frontend.chapter_secretMission;
	
			//Main levels
			GameObject limboContent = GetGameObjectChild(limboObject,"Level Row");

            TextMeshProUGUI limboFirstChallenge = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(limboContent, "1-1 Panel"), "Panel"), "Text"));
			limboFirstChallenge.text = Act1Strings.GetLevelChallenge("Level 1-1");

            TextMeshProUGUI limboSecondChallenge = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(limboContent, "1-2 Panel"), "Panel (2)"), "Text"));
			limboSecondChallenge.text = Act1Strings.GetLevelChallenge("Level 1-2");

            TextMeshProUGUI limboThirdChallenge = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(limboContent, "1-3 Panel"), "Panel (4)"), "Text"));
			limboThirdChallenge.text = Act1Strings.GetLevelChallenge("Level 1-3");

            TextMeshProUGUI limboClimaxChallenge = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(limboContent, "1-4 Panel"), "Panel (6)"), "Text"));
			limboClimaxChallenge.text = Act1Strings.GetLevelChallenge("Level 1-4");

			//Layer 2 - Lust
			GameObject lustHeader = GetGameObjectChild(lustObject,"Header");

            TextMeshProUGUI lustTitle = GetTextMeshProUGUI(GetGameObjectChild(lustHeader, "Text"));
			lustTitle.text = LanguageManager.CurrentLanguage.frontend.layer_lust;

            TextMeshProUGUI lustSecretMissionText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(lustHeader, "Secret Mission"), "Text"));
			lustSecretMissionText.text = LanguageManager.CurrentLanguage.frontend.chapter_secretMission;
			
			GameObject lustContent = GetGameObjectChild(lustObject,"Level Row");

            //Main levels
            TextMeshProUGUI lustFirstChallenge = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(lustContent, "2-1 Panel"),  "Panel"), "Text"));
			lustFirstChallenge.text = Act1Strings.GetLevelChallenge("Level 2-1");

            TextMeshProUGUI lustSecondChallenge = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(lustContent, "2-2 Panel"), "Panel (2)"), "Text"));
			lustSecondChallenge.text = Act1Strings.GetLevelChallenge("Level 2-2");

            TextMeshProUGUI lustThirdChallenge = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(lustContent, "2-3 Panel"), "Panel (4)"), "Text"));
			lustThirdChallenge.text = Act1Strings.GetLevelChallenge("Level 2-3");

            TextMeshProUGUI lustClimaxChallenge = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(lustContent, "2-4 Panel"), "Panel (6)"), "Text"));
			lustClimaxChallenge.text = Act1Strings.GetLevelChallenge("Level 2-4");

			//Layer 3 - Gluttony
			GameObject gluttonyHeader = GetGameObjectChild(gluttonyObject,"Header");

            TextMeshProUGUI gluttonyTitle = GetTextMeshProUGUI(GetGameObjectChild(gluttonyHeader, "Text"));
			gluttonyTitle.text = LanguageManager.CurrentLanguage.frontend.layer_gluttony;
			
			//Main levels
			GameObject gluttonyContent = GetGameObjectChild(gluttonyObject,"Level Row");

            TextMeshProUGUI gluttonyFirstChallenge = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(gluttonyContent, "3-1 Panel"), "Panel"), "Text"));
			gluttonyFirstChallenge.text = Act1Strings.GetLevelChallenge("Level 3-1");

            TextMeshProUGUI gluttonySecondChallenge = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(gluttonyContent, "3-2 Panel"),"Panel (2)"), "Text"));
			gluttonySecondChallenge.text = Act1Strings.GetLevelChallenge("Level 3-2");

		}

		private static void PatchLevelSelectAct2(GameObject frontEnd)
		{
			GameObject act2Object = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(frontEnd, "Level Select (Act II)"), "Scroll Rect"), "Contents");

			GameObject greedObject = GetGameObjectChild(act2Object, "Layer 4 Greed");
			GameObject wrathObject = GetGameObjectChild(act2Object, "Layer 5 Wrath");
			GameObject heresyObject = GetGameObjectChild(act2Object, "Layer 6 Heresy");

			//Layer 4 - Greed
			GameObject greedHeader = GetGameObjectChild(greedObject,"Header");

            TextMeshProUGUI greedTitle = GetTextMeshProUGUI(GetGameObjectChild(greedHeader, "Text"));
			greedTitle.text = LanguageManager.CurrentLanguage.frontend.layer_greed;

            TextMeshProUGUI greedSecretMissionText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(greedHeader, "Secret Mission"), "Text"));
			greedSecretMissionText.text = LanguageManager.CurrentLanguage.frontend.chapter_secretMission;
			
			//Main levels
			GameObject greedContent = GetGameObjectChild(greedObject,"Level Row");


            TextMeshProUGUI greedFirstChallenge = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(greedContent, "4-1 Panel"), "Panel"), "Text"));
			greedFirstChallenge.text = Act2Strings.GetLevelChallenge("Level 4-1");

            TextMeshProUGUI greedSecondChallenge = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(greedContent, "4-2 Panel"), "Panel (2)"), "Text"));
			greedSecondChallenge.text = Act2Strings.GetLevelChallenge("Level 4-2");

            TextMeshProUGUI greedThirdChallenge = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(greedContent, "4-3 Panel"), "Panel (4)"), "Text"));
			greedThirdChallenge.text = Act2Strings.GetLevelChallenge("Level 4-3");

            TextMeshProUGUI greedClimaxChallenge = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(greedContent, "4-4 Panel"), "Panel (6)"), "Text"));
			greedClimaxChallenge.text = Act2Strings.GetLevelChallenge("Level 4-4");

			
			//Layer 5 - Wrath
			GameObject wrathHeader =  GetGameObjectChild(wrathObject, "Header");

            TextMeshProUGUI wrathTitle = GetTextMeshProUGUI(GetGameObjectChild(wrathHeader, "Text"));
			wrathTitle.text = LanguageManager.CurrentLanguage.frontend.layer_wrath;

            TextMeshProUGUI wrathSecretMissionText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(wrathHeader, "Secret Mission"), "Text"));
			wrathSecretMissionText.text = LanguageManager.CurrentLanguage.frontend.chapter_secretMission;
			
			//Main levels
			GameObject wrathContent = GetGameObjectChild(wrathObject,"Level Row");

            TextMeshProUGUI wrathFirstChallenge = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(wrathContent, "5-1 Panel"), "Panel"), "Text"));
			wrathFirstChallenge.text = Act2Strings.GetLevelChallenge("Level 5-1");

            TextMeshProUGUI wrathSecondChallenge = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(wrathContent, "5-2 Panel"),"Panel (2)"), "Text"));
			wrathSecondChallenge.text = Act2Strings.GetLevelChallenge("Level 5-2");

            TextMeshProUGUI wrathThirdChallenge = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(wrathContent, "5-3 Panel"), "Panel (4)"), "Text"));
			wrathThirdChallenge.text = Act2Strings.GetLevelChallenge("Level 5-3");

            TextMeshProUGUI wrathFourthChallenge = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(wrathContent, "5-4 Panel"),"Panel (6)"), "Text"));
			wrathFourthChallenge.text = Act2Strings.GetLevelChallenge("Level 5-4");


			//Layer 6 - Heresy
			GameObject heresyHeader = GetGameObjectChild(heresyObject,"Header");

            TextMeshProUGUI heresyTitle = GetTextMeshProUGUI(GetGameObjectChild(heresyHeader, "Text"));
			heresyTitle.text = LanguageManager.CurrentLanguage.frontend.layer_heresy;
			
			//Main levels
			GameObject heresyContent = GetGameObjectChild(heresyObject,"Level Row");


            TextMeshProUGUI heresyFirstChallenge = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(heresyContent, "1-1 Panel"), "Panel"), "Text"));
			heresyFirstChallenge.text = Act2Strings.GetLevelChallenge("Level 6-1");

            TextMeshProUGUI heresySecondChallenge = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(heresyContent, "1-2 Panel"), "Panel (2)"), "Text"));
			heresySecondChallenge.text = Act2Strings.GetLevelChallenge("Level 6-2");
		}
		
		private static void PatchLevelSelectAct3(GameObject frontEnd)
		{
			GameObject act3Object = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(frontEnd, "Level Select (Act III)"), "Scroll Rect"), "Contents");

			GameObject violenceObject = GetGameObjectChild(act3Object, "Layer 7 Violence");
			GameObject fraudObject = GetGameObjectChild(act3Object, "Layer 8 Fraud");
			GameObject treacheryObject = GetGameObjectChild(act3Object, "Layer 9 Treachery");

			//Layer 7 - Violence
			GameObject violenceHeader = GetGameObjectChild(violenceObject,"Header");

            TextMeshProUGUI violenceTitle = GetTextMeshProUGUI(GetGameObjectChild(violenceHeader, "Text"));
			violenceTitle.text = LanguageManager.CurrentLanguage.frontend.layer_violence;

            TextMeshProUGUI violenceSecretMissionText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(violenceHeader, "Secret Mission"), "Text"));
			violenceSecretMissionText.text = LanguageManager.CurrentLanguage.frontend.chapter_secretMission;
			
			//Main levels
			GameObject violenceContent = GetGameObjectChild(violenceObject,"Level Row");


            TextMeshProUGUI violenceFirstChallenge = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(violenceContent, "7-1 Panel"), "Panel"), "Text"));
			violenceFirstChallenge.text = Act3Strings.GetLevelChallenge("Level 7-1");

            TextMeshProUGUI violenceSecondChallenge = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(violenceContent, "7-2 Panel"), "Panel (2)"), "Text"));
			violenceSecondChallenge.text = Act3Strings.GetLevelChallenge("Level 7-2");

            TextMeshProUGUI violenceThirdChallenge = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(violenceContent, "7-3 Panel"), "Panel (4)"), "Text"));
			violenceThirdChallenge.text = Act3Strings.GetLevelChallenge("Level 7-3");

            TextMeshProUGUI violenceClimaxChallenge = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(violenceContent, "7-4 Panel"), "Panel (6)"), "Text"));
			violenceClimaxChallenge.text = Act3Strings.GetLevelChallenge("Level 7-4");

			
			//Layer 8 - Fraud
			GameObject fraudHeader = GetGameObjectChild(fraudObject,"Header");

            TextMeshProUGUI fraudTitle = GetTextMeshProUGUI(GetGameObjectChild(fraudHeader, "Text"));
			fraudTitle.text = LanguageManager.CurrentLanguage.frontend.layer_fraud;

            TextMeshProUGUI fraudSecretMissionText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(fraudHeader, "Secret Mission"), "Text"));
			fraudSecretMissionText.text = LanguageManager.CurrentLanguage.frontend.chapter_secretMission;
			
			//Main levels
			GameObject fraudContent = GetGameObjectChild(fraudObject,"Level Row");


            TextMeshProUGUI fraudFirstChallenge = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(fraudContent, "8-1 Panel"), "Panel"), "Text"));
			fraudFirstChallenge.text = Act3Strings.GetLevelChallenge("Level 8-1");

            TextMeshProUGUI fraudSecondChallenge = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(fraudContent, "8-2 Panel"), "Panel (2)"), "Text"));
			fraudSecondChallenge.text = Act3Strings.GetLevelChallenge("Level 8-2");

            TextMeshProUGUI fraudThirdChallenge = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(fraudContent, "8-3 Panel"), "Panel (4)"), "Text"));
			fraudThirdChallenge.text = Act3Strings.GetLevelChallenge("Level 8-3");

            TextMeshProUGUI fraudClimaxChallenge = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(fraudContent, "8-4 Panel"), "Panel (6)"), "Text"));
			fraudClimaxChallenge.text = Act3Strings.GetLevelChallenge("Level 8-4");


			//Layer 9 - Treachery
			GameObject treacheryHeader = GetGameObjectChild(treacheryObject,"Header");

            TextMeshProUGUI treacheryTitle = GetTextMeshProUGUI(GetGameObjectChild(treacheryHeader, "Text"));
			treacheryTitle.text = LanguageManager.CurrentLanguage.frontend.layer_treachery;
			
			//Main levels
			GameObject treacheryContent = GetGameObjectChild(treacheryObject,"Level Row");


            TextMeshProUGUI treacheryFirstChallenge = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(treacheryContent, "9-1 Panel"), "Panel"), "Text"));
			treacheryFirstChallenge.text = Act3Strings.GetLevelChallenge("Level 9-1");

            TextMeshProUGUI treacherySecondChallenge = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(treacheryContent, "9-2 Panel"), "Panel (2)"), "Text"));
			treacherySecondChallenge.text = Act3Strings.GetLevelChallenge("Level 9-2");
		}

		private static void PatchLevelSelectPrime(GameObject frontEnd)
		{
			GameObject primeObject = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(frontEnd, "Level Select (Prime)"), "Prime Sanctums"),"Header");
            TextMeshProUGUI primeTitle = GetTextMeshProUGUI(GetGameObjectChild(primeObject, "Text"));
			primeTitle.text = LanguageManager.CurrentLanguage.frontend.layer_prime;
		}
		

		public static void Patch(GameObject frontEnd)
		{
			try
			{
				PatchMainMenu(frontEnd);
				ChangeTitle(frontEnd);
				PatchDifficultyMenu(frontEnd);
				PatchDifficultyDescriptors(frontEnd);

				PatchChapterSelect(frontEnd);
				PatchLevelSelectPrelude(frontEnd);
				PatchLevelSelectAct1(frontEnd);
				PatchLevelSelectAct2(frontEnd);
				PatchLevelSelectAct3(frontEnd);
				PatchLevelSelectPrime(frontEnd);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}

		}

	}
}
