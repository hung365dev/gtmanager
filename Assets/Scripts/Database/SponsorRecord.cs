using System;
using GoogleFu;
using UnityEngine;
using System.Collections.Generic;


namespace Database
{
	[System.Serializable]
	public class SponsorRecord
	{
		public int id;
		public string name;
		public int positionDemanded;
		public int startPayPerRace;
		public string sponsorLogo;
		public int requiredReputation;
		public string description;
		public static List<Sprite> sponsorTextures;
		public SponsorRecord (SponsorLibraryRow aRow)
		{
			id = aRow._id;
			name = aRow._sponsorname;
			positionDemanded = Convert.ToInt32(aRow._positiondemanded);
			startPayPerRace = Convert.ToInt32(aRow._startpayperrace);
			sponsorLogo = aRow._sponsorlogo;
			requiredReputation = Convert.ToInt32(aRow._becomeinterestedatreputation);
		}
		
		public Sprite logo {
			get {
				//	prefabName = "GolfWhite";
				if(sponsorTextures==null||sponsorTextures.Count==0) {
					sponsorTextures = new List<Sprite>();
					UnityEngine.Object[] o = Resources.LoadAll("Sponsors/sponsorspritesheet");
					for(int i = 1;i<o.Length;i++) {
						if(o[i].name.StartsWith("logo_")) {
							sponsorTextures.Add((Sprite) o[i]);
						}
					}
				}
				
				for(int i = 0;i<sponsorTextures.Count;i++) {
					if(sponsorTextures[i].name==this.sponsorLogo) {
						return sponsorTextures[i];
					}
				}
				return sponsorTextures[0];
			} 
		}
	}
}

