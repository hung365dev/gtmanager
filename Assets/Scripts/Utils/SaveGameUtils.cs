// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using System;
using System.Collections.Generic;


namespace Utils
{
	public class SaveGameUtils
	{
		public const string SAVED_GAME_NAME = "d";
		public static int USING_INDEX = 0;
		public SaveGameUtils ()
		{
		}

		public static bool HasSavedGameAtIndex(int aIndex) {
			if(ES2.Exists(SAVED_GAME_NAME+aIndex)) {
				return true;
			}
			return false;
		}

		public static void save(List<string> aData) {
			ES2.Save(aData,SAVED_GAME_NAME+USING_INDEX);
		}
		
		public static string headlineGameInfo(int aIndex) {
			if(ES2.Exists(SAVED_GAME_NAME+aIndex)) {
				List<string> list = ES2.LoadList<string>(SAVED_GAME_NAME+aIndex);
				return list[(int) ESavedGameSetup.SavedGameHeadline];
			}
			return "";
		}
	}
}

