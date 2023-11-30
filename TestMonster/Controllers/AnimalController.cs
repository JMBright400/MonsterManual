using Microsoft.AspNetCore.Mvc;
using TestMonster.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace TestMonster.Controllers
{
	public class AnimalsController : Controller
	{
		private readonly AnimalRepository _animalRepo;

		public AnimalsController(AnimalRepository animalRepo)
		{
			_animalRepo = animalRepo;
		}

		
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Search(string monsterName)
		{
			var animals = await _animalRepo.GetAllAnimalsAsync();
			var animal = animals.FirstOrDefault(a => a.MonsterName.Equals(monsterName, System.StringComparison.OrdinalIgnoreCase));

			if (animal != null)
			{
				return View("Details", animal);
			}
			else
			{
				ViewBag.Message = "Hmm... it appears the creature you seek eludes my current knowledge. Perhaps another monster captures your interest?";
				return View("Index");
			}
		}
        public IActionResult PopulatePage()
        {
            return View();
        }

        public IActionResult PurgePage()
        {
            return View();
        }
        public async Task<IActionResult> PurgeDatabase()
        {
            await _animalRepo.DeleteAllAnimalsAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> PopulateDatabase()
		{
			var animalsList = new List<Animal>
			{
				new Animal {
					MonsterName = "Ankheg", //good
					MonsterDescription = "A huge segmented insect with slender legs, each ending with a sharp claw. A tough chitinous brown shell covers its body.",
					Environment = "Plains",
					HitPoints = 28,
					ArmorClass = 18,
					Size = "Large",
					CreatureType = "Magical Beast",
					Alignment = "Neutral",
					Speed = "30 ft. base/20ft. burrowing",
					Saves = "Fort +6, Ref +6, Will +2",
					Feats = "Alertness, Toughness",
					ChallengeRating = 3,
					BaseAttack = "+3",
					Grapple = "+12",
					FullAttack = "Bite: +7 melee (2d6+7 plus 1d4 acid)",
					SpecialAttack = "Spit Acid: 30ft. line, once every 6 hours; damage 4d4 acid, Reflex DC 14.",
					ImageUrl = "https://images.squarespace-cdn.com/content/v1/5bd88db093a6320f071b1a50/1618453235670-RJGB7UQ4PAT5SFKJ2F94/3e_MM_Ankheg.jpg?format=2500w"
                },
				new Animal {
                    MonsterName = "Bugbear", //good
                    MonsterDescription = "This muscular, savage humanoid stands 7 feet tall. Coarse hair covers most of its body. It has a mouth full of jagged teeth, and a nose much like that of a bear.",
                    Environment = "Mountains",
                    HitPoints = 16,
                    ArmorClass = 17,
                    Size = "Medium",
                    CreatureType = "Humanoid",
                    Alignment = "Chaotic Evil",
                    Speed = "30ft.",
                    Saves = "Fort +2, Ref +4, Will +1",
                    Feats = "Alertness, Weapon Focus (morningstar)",
                    ChallengeRating = 2,
                    BaseAttack = "+2",
                    Grapple = "+4",
                    FullAttack = "Morninigstar: +5 melee (1d8+2) or javelin: +3 ranged (1d6+2) 20ft. range.",
                    SpecialAttack = "None.",
                    ImageUrl = "https://4.bp.blogspot.com/-1eZeihPYG7c/VeCH-9zeQaI/AAAAAAAAAXM/vTiCNxkvujI/s1600/Bugbear.jpg"
                },
                new Animal {
                    MonsterName = "Bulette", //good
                    MonsterDescription = "A terrible, armor plated creature with a huge snapping mouth and short, yet powerful legs.",
                    Environment = "Caves and Hills",
                    HitPoints = 94,
                    ArmorClass = 22,
                    Size = "Huge",
                    CreatureType = "Magical Beast",
                    Alignment = "Neutral",
                    Speed = "40 ft. base/10ft. burrowing",
                    Saves = "Fort +11, Ref +8, Will +6",
                    Feats = "Alertness, Iron Will, Track, Weapon Focus (bite)",
                    ChallengeRating = 7,
                    BaseAttack = "+9",
                    Grapple = "+25",
                    FullAttack = "Bite: +16 melee (2d8+8) and 2 claws: +10 melee (2d6+4)",
                    SpecialAttack = "None.",
                    ImageUrl = "https://images.squarespace-cdn.com/content/v1/5bd88db093a6320f071b1a50/1620878210512-OLLLRL18A6KIJXMZVN8O/3e_MM_Bulette.jpg"
                },
                new Animal {
                    MonsterName = "Carrion Crawler", //good
                    MonsterDescription = "The stench of rot surrounds this ten foot long, pale green worm. Eight long tentacles protrude from the head of the worm, circling a tooth filled maw.",
                    Environment = "Dungeons and Underground",
                    HitPoints = 19,
                    ArmorClass = 17,
                    Size = "Large",
                    CreatureType = "Aberration",
                    Alignment = "Neutral",
                    Speed = "30ft. base/15ft. climbing",
                    Saves = "Fort +3, Ref +3, Will +5",
                    Feats = "Alertness, Combat Reflexes, Track",
                    ChallengeRating = 4,
                    BaseAttack = "+2",
                    Grapple = "+8",
                    FullAttack = "8 Tentacles: +3 melee (paralysis) and bite: -2 melee (1d4+1)",
                    SpecialAttack = "Paralysis: Those hit by a tentacle attack must succeed as DC 13 Fortitude save or be paralyzed for 2d4 rounds.",
                    ImageUrl = "https://64.media.tumblr.com/b9b463f2ab0f44615153bddf164cc0ae/tumblr_inline_od63d5KUo61r0zz7o_640.jpg"
                },
                new Animal {
                    MonsterName = "Centaur", //good
                    MonsterDescription = "This creature has the upper torso of a humanoid and the lower body of a large horse. They are normally accompanied with a bow, ready to loose an arrow at the first hint of danger.",
                    Environment = "Forests",
                    HitPoints = 26,
                    ArmorClass = 14,
                    Size = "Large",
                    CreatureType = "Monstrous Humanoid",
                    Alignment = "Neutral Good",
                    Speed = "50ft.",
                    Saves = "Fort +3, Ref +6, Will +5",
                    Feats = "Dodge, Weapon Focus (hoof)",
                    ChallengeRating = 3,
                    BaseAttack = "+4",
                    Grapple = "+12",
                    FullAttack = "Longsword: +7 melee (2d6+6/19-20) and 2 hooves: +3 melee (1d6+2); or composite long bow: +5 ranged (2d6+4/x3) 90ft. range.",
                    SpecialAttack = "None.",
                    ImageUrl = "https://i.pinimg.com/originals/d2/cd/cf/d2cdcf17bddd1d73c919cafb6ed6f4de.png"
                },
                new Animal
                {
                    MonsterName = "Chimera", //good
                    MonsterDescription = "This creature has the hindquartes of a big goat and the forequarters of a lion. It has dragon wings and three heads: A horned goat, a lion, and a fierce dragon.",
                    Environment = "Hills and Mountains",
                    HitPoints = 76,
                    ArmorClass = 19,
                    Size = "Large",
                    CreatureType = "Magical Beast",
                    Alignment = "Chaotic Evil",
                    Speed = "30ft. base/50ft. flying",
                    Saves = "Fort +9, Ref +7, Will +6",
                    Feats = "Alertness, Hover, Iron Will, Multiattack",
                    ChallengeRating = 7,
                    BaseAttack = "+9",
                    Grapple = "+17",
                    FullAttack = "Bite: +12 melee (2d6+4) and bite: +12 melee (1d8+4) and 2 claws: +10 melee (1d6+2)",
                    SpecialAttack = "Breath Weapon: A Chimera's breath weapon depends on the color of its dragon head. Black: 40ft. Line of Acid. Blue: 40ft. Line of lightning. Green: 20ft. Cone of Gas. Red: 20ft. Cone of Fire. White: 20ft. Cone of Cold.",
                    ImageUrl = "https://images.squarespace-cdn.com/content/v1/5bd88db093a6320f071b1a50/1606367218229-X5THYB2I4TO3MM66OWCE/image-asset.jpeg?format=2500w"
                },
                new Animal
                {
                    MonsterName = "Cloaker", //good
                    MonsterDescription = "This creature has dark blue wings and a bony, whiplike tail. It seems to almost glide through the cavern with it's raylike body. Above it's razor-tooth maw are two piercing red eyes and ",
                    Environment = "Underground",
                    HitPoints = 45,
                    ArmorClass = 19,
                    Size = "Large",
                    CreatureType = "Aberration",
                    Alignment = "Chaotic Neutral",
                    Speed = "10ft. base/40ft. flying",
                    Saves = "Fort +5, Ref +5, Will +7",
                    Feats = "Alertness, Combat Reflexes, Improved Initiative",
                    ChallengeRating = 5,
                    BaseAttack = "+4",
                    Grapple = "+13",
                    FullAttack = "Tail Slap: +8 melee (1d6+5) and bite: +3 melee (1d4+2)",
                    SpecialAttack = "Engulf: The Cloaker attempts a grapple on a small or medium creature that does not provide an attack of opportunity.If the Cloaker wins the grapple check it gets a +4 on a bite attack against the victim.",
                    ImageUrl = "https://www.dndbeyond.com/avatars/thumbnails/30767/348/1000/1000/638061293461506894.png"
                },
                new Animal
                {
                    MonsterName = "Cockatrice", //good
                    MonsterDescription = "This avian beast is the size of a large goose. It has a head and body of a cockerel, bat wings, and the tail of a lizard. This is a very dangerous chicken, in short.",
                    Environment = "Plains",
                    HitPoints = 27,
                    ArmorClass = 14,
                    Size = "Small",
                    CreatureType = "Magical Beast",
                    Alignment = "Neutral",
                    Speed = "20ft. base/60ft. flying",
                    Saves = "Fort +4, Ref +7, Will +2",
                    Feats = "Alertness, Dodge, Weapon Finesse",
                    ChallengeRating = 3,
                    BaseAttack = "+5",
                    Grapple = "-1",
                    FullAttack = "Bite: +9 melee (1d4-2 plus petrification)",
                    SpecialAttack = "Petrification: Creatures hit by a Cockatrice's bite must succeed a DC 12 Fortitude save or instantly turn into stone.",
                    ImageUrl = "https://images.squarespace-cdn.com/content/v1/5bd88db093a6320f071b1a50/4df4c365-c8d1-404c-89d9-34ec3ba320d9/3e_MM_Cockatrice.jpg?format=2500w"
                },
                new Animal
                {
                    MonsterName = "Couatl", //good
                    MonsterDescription = "This great serpent with colorful-feathered wings appears radiant, powerful, and totally aware of everything around it.",
                    Environment = "Forests",
                    HitPoints = 58,
                    ArmorClass = 21,
                    Size = "Large",
                    CreatureType = "Outsider",
                    Alignment = "Lawful Good",
                    Speed = "20ft. base/60ft. flying",
                    Saves = "Fort +8, Ref +9, Will +10",
                    Feats = "Dodge, Empower Spell, Eschew Materials, Hover, Improved Initiative",
                    ChallengeRating = 10,
                    BaseAttack = "+9",
                    Grapple = "+17",
                    FullAttack = "Bite: +12 melee (1d3+6 plus poison)",
                    SpecialAttack = "Constrict: A Coutal deals 2d8+6 damage with a succesful grapple check. Poison: Creatures hit with a bite attack must succeed a DC 16 Fortitude save or be dealt 2d4 damage to Strength.",
                    ImageUrl = "https://images.squarespace-cdn.com/content/v1/5bd88db093a6320f071b1a50/1607539219365-816Z340146WR8SLVQ0FY/3e_MM_Couatl.jpg?format=2500w"
                },
                new Animal
                {
                    MonsterName = "Displacer Beast", //good
                    MonsterDescription = "This creatures body resembles a slender panther with black-blue fur, six legs and a pair of tentacles sprout from it's shoulders. The tentacles end in sharp, jagged barbs.",
                    Environment = "Hills and Caves",
                    HitPoints = 51,
                    ArmorClass = 16,
                    Size = "Large",
                    CreatureType = "Magical Beast",
                    Alignment = "Lawful Evil",
                    Speed = "40ft.",
                    Saves = "Fort +8, Ref +7, Will +3",
                    Feats = "Alertness, Dodge, Stealthy",
                    ChallengeRating = 4,
                    BaseAttack = "+6",
                    Grapple = "+14",
                    FullAttack = "2 Tentacles: +9 melee (1d6+4) and bite: +4 melee (1d8+2)",
                    SpecialAttack = "Displacement: Not a Special Attack but more an ability to be weary of. Any attack against the Displacer Beast has a 50% miss rate unless the attacker can locate the beast by some means other than sight.",
                    ImageUrl = "https://images.squarespace-cdn.com/content/v1/5bd88db093a6320f071b1a50/1577329597611-7ABIYQD2F2IBKGQBU7WJ/image-asset.png?format=2500w"
                },
                new Animal
                {
                    MonsterName = "Doppelganger", //good
                    MonsterDescription = "This gaunt, grey humanoid has long gangly limbs and a bulbous head with large octopoid eyes. Its face is otherwise blank and featureless.",
                    Environment = "Any",
                    HitPoints = 22,
                    ArmorClass = 15,
                    Size = "Medium",
                    CreatureType = "Monstrous Humanoid",
                    Alignment = "Neutral",
                    Speed = "30ft.",
                    Saves = "Fort +4, Ref +5, Will +6",
                    Feats = "Dodge, Great Fortitude",
                    ChallengeRating = 3,
                    BaseAttack = "+4",
                    Grapple = "+5",
                    FullAttack = "Slam: +5 melee (1d6+1)",
                    SpecialAttack = "Change Shape: Not a Special Attack but more an ability to be weary of. A Doppelganger can assume the shape of any small or medium humanoid.",
                    ImageUrl = "https://images.squarespace-cdn.com/content/v1/5bd88db093a6320f071b1a50/3e462f81-bcc9-4c79-bc6b-d1f1aee1e070/3e_MM_Doppelganger.jpg?format=2500w"
                },
                new Animal
                {
                    MonsterName = "Black Dragon", //good
                    MonsterDescription = "This ebony scaled monstrosity has two forward-curving horns and spinal crest that peaks just behind the head. An acidic smell surrounds the dragon.",
                    Environment = "Marshes",
                    HitPoints = 253,
                    ArmorClass = 29,
                    Size = "Huge",
                    CreatureType = "Dragon",
                    Alignment = "Chaotic Evil",
                    Speed = "60ft. base/60ft. swimming/150ft. flying",
                    Saves = "Fort +18, Ref +13, Will +15",
                    Feats = "Immunity to Acid, Water Breathing",
                    ChallengeRating = 14,
                    BaseAttack = "+22",
                    Grapple = "+38",
                    FullAttack = "Bite: +28 melee (2d6+6) 2 claws: +24 melee (1d8+3) ",
                    SpecialAttack = "Breath Weapon: The Black Dragon sprays a line of acid dealing 14d4 acid damage. DC 26 Reflex required to take half damage. 100ft. range.",
                    ImageUrl = "https://media-waterdeep.cursecdn.com/avatars/thumbnails/0/13/1000/1000/636238871029832086.jpeg"
                }, 
                new Animal
                {
                    MonsterName = "Blue Dragon", //good
                    MonsterDescription = "This beast has a single massive horn emerging from its snout. The smell of ozone lingers in the air near the dragon, whose azure scales glitter in the sun.",
                    Environment = "Deserts",
                    HitPoints = 276,
                    ArmorClass = 31,
                    Size = "Huge",
                    CreatureType = "Dragon",
                    Alignment = "Lawful Evil",
                    Speed = "40ft. base/20ft. burrowing/150ft. flying",
                    Saves = "Fort +19, Ref +14, Will +17",
                    Feats = "Create/Destroy Water, Immunity to electricity, Sound Imitation",
                    ChallengeRating = 16,
                    BaseAttack = "+24",
                    Grapple = "+41",
                    FullAttack = "Bite: +31 melee (2d8+9) 2 claws: +29 melee (2d6+4)",
                    SpecialAttack = "Breath Weapon: The Blue Dragon jolts out a line of electricity dealing 14d8 electric damage. DC 27 Reflex required to take half damage. 100ft. range.",
                    ImageUrl = "https://media-waterdeep.cursecdn.com/avatars/thumbnails/0/131/1000/1000/636252756020185006.jpeg"
                },
                new Animal
                {
                    MonsterName = "Green Dragon", //good
                    MonsterDescription = "This dragon has a toothy, curved jaw and rows of hornlets over the eyes.The odor of chlorine seems to cling to the dragon. The scales radiate with a glowing emerald shine.",
                    Environment = "Forests",
                    HitPoints = 264,
                    ArmorClass = 30,
                    Size = "Huge",
                    CreatureType = "Dragon",
                    Alignment = "Lawful Evil",
                    Speed = "40ft. base/40ft. swimming/150ft. flying",
                    Saves = "Fort +18, Ref +13, Will +16",
                    Feats = "Immunity to Acid, Water Breathing",
                    ChallengeRating = 16,
                    BaseAttack = "+23",
                    Grapple = "+40",
                    FullAttack = "Bite: +28 melee (3d8+9) 2 claws: +26 melee (2d6+4)",
                    SpecialAttack = "Breath Weapon: The Green Dragon releases a cone of acidic gas dealing 14d6 acid damage. DC 25 Reflex required to take half damage. 50ft. range.",
                    ImageUrl = "https://media-waterdeep.cursecdn.com/avatars/thumbnails/0/141/1000/1000/636252757319464533.jpeg"
                },
                new Animal
                {
                    MonsterName = "Red Dragon", //good
                    MonsterDescription = "The colossal dragon has two long horns extending back over the neck. A frill begins behind the head and runs to the tip of the tail. The crimson beast reeks of sulfur and smoke.",
                    Environment = "Caves and Mountains",
                    HitPoints = 312,
                    ArmorClass = 32,
                    Size = "Huge",
                    CreatureType = "Dragon",
                    Alignment = "Chaotic Evil",
                    Speed = "40ft. base/150ft. flying",
                    Saves = "Fort +20, Ref +14, Will +18",
                    Feats = "Immunity to Fire, Locate Object",
                    ChallengeRating = 18,
                    BaseAttack = "+25",
                    Grapple = "+44",
                    FullAttack = "Bite: +34 melee (4d6+10) 2 claws: +30 melee (2d8+5)",
                    SpecialAttack = "Breath Weapon: The Red Dragon unleashes a cone of fire dealing 14d10 fire damage. DC 31 Reflex required to take half damage. 60ft. range.",
                    ImageUrl = "https://media-waterdeep.cursecdn.com/avatars/thumbnails/0/147/1000/1000/636252758629652181.jpeg"
                },
                new Animal
                {
                    MonsterName = "White Dragon", //good
                    MonsterDescription = "This beast has a beaked nose, spiny dewlaps, and a crest supported by a single, back-curving spine. A chill seems to emit from this dragon, whose scales glisten like snow.",
                    Environment = "Mountains and Tundras",
                    HitPoints = 241,
                    ArmorClass = 28,
                    Size = "Huge",
                    CreatureType = "Dragon",
                    Alignment = "Chaotic Evil",
                    Speed = "60ft. base/30ft. burrowing/60ft. swimming/200ft. flying",
                    Saves = "Fort +17, Ref +12, Will +13",
                    Feats = "Icewalking, Immunity to Cold",
                    ChallengeRating = 12,
                    BaseAttack = "+21",
                    Grapple = "+37",
                    FullAttack = "Bite: +27 melee (2d6+5) 2 claws: +22 melee (1d6+2)",
                    SpecialAttack = "Breath Weapon: The White Dragon exhales a cone of frost dealing 7d6 cold damage. DC 20 Reflex required to take half damage. 40ft. range.",
                    ImageUrl = "https://i.pinimg.com/originals/28/f0/3b/28f03b1373d27117204b05f8e5de5aa6.png"
                },
                new Animal
                {
                    MonsterName = "Brass Dragon", //good
                    MonsterDescription = "The head of this dragon is adorned with bladelike horns. A frill runs the length of the neck and the dragon has mantalike wings. The scales glisten like polished brass.",
                    Environment = "Deserts",
                    HitPoints = 253,
                    ArmorClass = 29,
                    Size = "Huge",
                    CreatureType = "Dragon",
                    Alignment = "Chaotic Good",
                    Speed = "60ft. base/30ft. burrowing/200ft. flying",
                    Saves = "Fort +18, Ref +13, Will +16",
                    Feats = "Immunity to Fire, Speak with Animals",
                    ChallengeRating = 15,
                    BaseAttack = "+22",
                    Grapple = "+38",
                    FullAttack = "Bite: +28 melee (2d6+6) 2 claws: +23 melee (1d6+3)",
                    SpecialAttack = "Breath Weapon: The Brass Dragon spits a line of fire dealing 7d6 fire damage. DC 24 Reflex required to take half damage. 50ft. range.",
                    ImageUrl = "https://media-waterdeep.cursecdn.com/avatars/thumbnails/0/18/1000/1000/636238885681129014.jpeg"
                },
                new Animal
                {
                    MonsterName = "Bronze Dragon", //good
                    MonsterDescription = "This dragon has a fluted crest that sweeps back from its face. A segmented frill runs down the neck and tail of the beast. The scent of the sea surronds this dragon, whose scales shimmer a goldish-brown.",
                    Environment = "Hills",
                    HitPoints = 276,
                    ArmorClass = 31,
                    Size = "Huge",
                    CreatureType = "Dragon",
                    Alignment = "Lawful Good",
                    Speed = "40ft. base/60ft. swimming/150ft. flying",
                    Saves = "Fort +19, Ref +14, Will +19",
                    Feats = "Immunnity to Electricity, Speak with Animals, Water Breathing",
                    ChallengeRating = 17,
                    BaseAttack = "+24",
                    Grapple = "+41",
                    FullAttack = "Bite: +31 melee (2d8+10) 2 claws: +29 melee (1d8+5)",
                    SpecialAttack = "Breath Weapon: The Bronze Dragon shoots forth a line of electricy dealing 14d6 electric damage. DC 27 Reflex required to take half damage. 60ft. range.",
                    ImageUrl = "https://www.aidedd.org/dnd/images/bronze-dragon.jpg"
                },
                new Animal
                {
                    MonsterName = "Copper Dragon", //good
                    MonsterDescription = "The dragon has a short face and broad, smooth brow plates jutting over the eyes. Layers of triangular blades point down from the chin. The reddish scales have a metallic shine.",
                    Environment = "Hills",
                    HitPoints = 264,
                    ArmorClass = 30,
                    Size = "Huge",
                    CreatureType = "Dragon",
                    Alignment = "Chaotic Good",
                    Speed = "40ft. base/150ft. flying",
                    Saves = "Fort +18, Ref +13, Will +17",
                    Feats = "Immunity to Acid, Spider Climb",
                    ChallengeRating = 16,
                    BaseAttack = "+23",
                    Grapple = "+39",
                    FullAttack = "Bite: +29 melee (2d6+8) 2 claws: +26 melee (1d6+4)",
                    SpecialAttack = "Breath Weapon: The Copper Dragon releases a line of acid dealing 14d4 acid damage. DC 26 Reflex required to take half damage. 60ft. range.",
                    ImageUrl = "https://media-waterdeep.cursecdn.com/avatars/thumbnails/0/137/1000/1000/636252756714896878.jpeg"
                }, 
                new Animal
                {
                    MonsterName = "Gold Dragon", //good
                    MonsterDescription = "This glorious beast has large, twin horns. Long whiskers extend from the chin and face of this dragon. Across the body are two saillike wings. The pleasent aroma of incense emits from the bright gold dragon.",
                    Environment = "Plains",
                    HitPoints = 325,
                    ArmorClass = 33,
                    Size = "Huge",
                    CreatureType = "Dragon",
                    Alignment = "Lawful Good",
                    Speed = "60ft. base/60ft. swimming/200ft. flying",
                    Saves = "Fort +21, Ref +15, Will +20",
                    Feats = "Alternate Form, Immunity to Fire, Water Breathing",
                    ChallengeRating = 19,
                    BaseAttack = "+26",
                    Grapple = "+46",
                    FullAttack = "Bite: +36 melee (2d8+13) 2 claws: +31 melee (2d6+6)",
                    SpecialAttack = "Breath Weapon: The Gold Dragon blows a cone of fire dealing 14d10 fire damage. DC 29 Reflex required to take half damage. 60ft. range.",
                    ImageUrl = "https://media-waterdeep.cursecdn.com/avatars/thumbnails/7/516/1000/1000/636285466148376212.jpeg"
                },  
                new Animal  
                {
                    MonsterName = "Silver Dragon", //good
                    MonsterDescription = "A smooth shiny plate forms the dragon's face. A frill rises high over its head and continues all the way to the tail. The dragon has the scent of rain, and its scales gleam like liquid metal.",
                    Environment = "Mountains",
                    HitPoints = 287,
                    ArmorClass = 32,
                    Size = "Huge",
                    CreatureType = "Dragon",
                    Alignment = "Lawful Good",
                    Speed = "40ft. base/150ft. flying",
                    Saves = "Fort +19, Ref +14, Will +19",
                    Feats = "Alternate Form, Immunity to Acid and Cold, Cloudwalking",
                    ChallengeRating = 18,
                    BaseAttack = "+25",
                    Grapple = "+42",
                    FullAttack = "Bite: +32 melee (3d6+12) 2 claws: +29 melee (2d8+6)",
                    SpecialAttack = "Breath Weapon: The Silver Dragon exhales a cone of frost dealing 14d8 cold damage. DC 27 Reflex required to take half damage. 60ft. range.",
                    ImageUrl = "https://media-waterdeep.cursecdn.com/avatars/thumbnails/0/123/1000/1000/636252753945133025.jpeg"
                },
                new Animal 
                {
                    MonsterName = "Drider", //good
                    MonsterDescription = "This strange being has the head and torso of a dark elf and the legs and lower body of a giant spider.",
                    Environment = "Underground",
                    HitPoints = 45,
                    ArmorClass = 17,
                    Size = "Large",
                    CreatureType = "Aberration",
                    Alignment = "Chaotic Evil",
                    Speed = "30ft. base/15ft. climbing",
                    Saves = "Fort +5, Ref +4, Will +8",
                    Feats = "Combat Casting, Two-Weapon Fighting, Weapon Focus (bite)",
                    ChallengeRating = 7,
                    BaseAttack = "+4",
                    Grapple = "+10",
                    FullAttack = "Dagger: +3 melee (1d6+2/19–20) and bite: +1 melee (1d4+1 plus poison)",
                    SpecialAttack = "Poison: Creatures hit by a Drider's bite must succeed a DC 16 Fortitude save or be dealt 1d6 Strength damage.",
                    ImageUrl = "https://64.media.tumblr.com/908d495ead0af79b1a5cada460aa6b5a/cf33843ccfe8f243-54/s1280x1920/1381daa5263202e8593383ae637645aba44198ed.png"
                },
                new Animal
                {
                    MonsterName = "Dryad", //good
                    MonsterDescription = "This creature has a wild, unfathomable look in her almond-shaped eyes, and her hair has a leafy texture, while her skin looks like burnished wood.",
                    Environment = "Forests",
                    HitPoints = 14,
                    ArmorClass = 17,
                    Size = "Medium",
                    CreatureType = "Fey",
                    Alignment = "Chaotic Good",
                    Speed = "30ft.",
                    Saves = "Fort +3, Ref +8, Will +6",
                    Feats = "Great Fortitude, Weapon Finesse",
                    ChallengeRating = 3,
                    BaseAttack = "+2",
                    Grapple = "+2",
                    FullAttack = "Dagger: +6 melee (1d4/19–20) or masterwork longbow: +7 ranged (1d8/×3) 100ft. range.",
                    SpecialAttack = "Wild Empathy: This power works like the druid’s wild empathy class feature, except that the Dryad has a +6 racial bonus on the check.",
                    ImageUrl = "https://images.squarespace-cdn.com/content/v1/5bd88db093a6320f071b1a50/1594266963495-8N4OB4RQL6M7BKKTADJZ/image-asset.jpeg?format=2500w"
                },
                new Animal 
                {
                    MonsterName = "Dwarf", //good
                    MonsterDescription = "Stocky, broad of body and extremely muscular, this short figure is no other than a Dwarf. Typically adorned with a long beard and an axe in hand.",
                    Environment = "Mountains and Underground",
                    HitPoints = 6,
                    ArmorClass = 16,
                    Size = "Medium",
                    CreatureType = "Humanoid",
                    Alignment = "Lawful or Chaotic Good",
                    Speed = "20ft.",
                    Saves = "Fort +4, Ref +0, Will -1",
                    Feats = "Weapon Focus (dwarven waraxe) ",
                    ChallengeRating = .5,
                    BaseAttack = "+1",
                    Grapple = "+2",
                    FullAttack = "Dwarven Waraxe: +3 melee (1d10+1/×3) or shortbow: +1 ranged (1d6/×3) 70ft. range.",
                    SpecialAttack = "None.",
                    ImageUrl = "https://cdna.artstation.com/p/assets/images/images/000/218/950/medium/adrian-smith-fw-dwarf-warrior.jpg?1443927084"
                },
                new Animal 
                {
                    MonsterName = "Air Elemental", //good
                    MonsterDescription = "This creature appears to be an amorphous, shifting cloud surrounded by fast-moving currents of air. Darker bits of twirling vapor form the suggestion of two eyes and a mouth.",
                    Environment = "Correlated Elemental Plane",
                    HitPoints = 26,
                    ArmorClass = 18,
                    Size = "Medium",
                    CreatureType = "Elemental",
                    Alignment = "Neutral",
                    Speed = "100ft. flying",
                    Saves = "Fort +3, Ref +9, Will +1",
                    Feats = "Dodge, Flyby Attack, Improved Initiative, Weapon Finesse",
                    ChallengeRating = 3,
                    BaseAttack = "+3",
                    Grapple = "+4",
                    FullAttack = "Slam: +8 melee (1d6+1)",
                    SpecialAttack = "Air Mastery: Airborne creatures take a –1 penalty on attack and damage rolls against an Air Elemental.",
                    ImageUrl = "https://www.dndbeyond.com/avatars/thumbnails/30783/689/1000/1000/638062015555039371.png"
                },
                new Animal 
                {
                    MonsterName = "Earth Elemental", //good
                    MonsterDescription = "Like a walking hill, the creature plods about on two featureless legs of rock and earth, its clublike arms of jagged stone swinging at its sides.",
                    Environment = "Correlated Elemental Plane",
                    HitPoints = 30,
                    ArmorClass = 18,
                    Size = "Medium",
                    CreatureType = "Elemental",
                    Alignment = "Neutral",
                    Speed = "20ft.",
                    Saves = "Fort +7, Ref +0, Will +1",
                    Feats = "Cleave, Power Attack",
                    ChallengeRating = 3,
                    BaseAttack = "+3",
                    Grapple = "+8",
                    FullAttack = "Slam: +8 melee (1d8+7)",
                    SpecialAttack = "Earth Mastery: An Earth Elemental gains a +1 bonus on attack and damage rolls if both it and its foe are touching the ground.",
                    ImageUrl = "https://www.dndbeyond.com/avatars/thumbnails/30783/692/1000/1000/638062015664899420.png"
                },
                new Animal 
                {
                    MonsterName = "Fire Elemental", //good
                    MonsterDescription = "A mass of ambulatory flame, seeming to flicker and spark from a central, humanoid-shaped conflagration. A living inferno that emits immense heat.",
                    Environment = "Correlated Elemental Plane",
                    HitPoints = 26,
                    ArmorClass = 16,
                    Size = "Medium",
                    CreatureType = "Elemental",
                    Alignment = "Neutral",
                    Speed = "50ft.",
                    Saves = "Fort +3, Ref +7, Will +1",
                    Feats = "Dodge, Improved Initiative, Mobility, Weapon Finesse",
                    ChallengeRating = 3,
                    BaseAttack = "+3",
                    Grapple = "+4",
                    FullAttack = "Slam: +6 melee (1d6+1 plus 1d6 fire)",
                    SpecialAttack = "Burn: Those hit by a Fire Elemental‘s slam attack must succeed a DC 14 Reflex save or catch on fire. The flame burns for 1d4 rounds.",
                    ImageUrl = "https://www.dndbeyond.com/avatars/thumbnails/30783/695/1000/1000/638062015772259390.png"
                },
                new Animal 
                {
                    MonsterName = "Water Elemental", //good
                    MonsterDescription = "A vortex of water that never seems to crash or lose its shape. The waves cascade and storm around a central, humanoid-shaped whirlpool.",
                    Environment = "Correlated Elemental Plane",
                    HitPoints = 30,
                    ArmorClass = 20,
                    Size = "Medium",
                    CreatureType = "Elemental",
                    Alignment = "Neutral",
                    Speed = "20ft. base/90ft. swimming",
                    Saves = "Fort +7, Ref +2, Will +1",
                    Feats = "Cleave, Power Attack",
                    ChallengeRating = 3,
                    BaseAttack = "+3",
                    Grapple = "+6",
                    FullAttack = "Slam: +6 melee (1d8+4)",
                    SpecialAttack = "Drench: The Water Elemental’s touch puts out torches, campfires, exposed lanterns, and other open flames of nonmagical origin.",
                    ImageUrl = "https://www.dndbeyond.com/avatars/thumbnails/30783/698/1000/1000/638062015886859442.png"
                },
                new Animal 
                {
                    MonsterName = "Elf", //good
                    MonsterDescription = "Slender and slightly shorter than a human, pale skin and dark hair, pointed ears grace the sides of its head. This is indeed an Elf, typically brandishing a bow or curved sword.",
                    Environment = "Forests",
                    HitPoints = 4,
                    ArmorClass = 15,
                    Size = "Medium",
                    CreatureType = "Humanoid",
                    Alignment = "Lawful or Chaotic Good",
                    Speed = "30ft.",
                    Saves = "Fort +2, Ref +1, Will -1",
                    Feats = "Weapon Focus (longbow)",
                    ChallengeRating = .5,
                    BaseAttack = "+1",
                    Grapple = "+2",
                    FullAttack = "Longsword: +2 melee(1d8+1/19–20) or longbow: +3 ranged (1d8/×3) 100ft. range.",
                    SpecialAttack = "None.",
                    ImageUrl = "https://i.ebayimg.com/images/g/oTAAAOSweppj-SJg/s-l1200.webp"
                },
                new Animal 
                {
                    MonsterName = "Dark Elf", //good
                    MonsterDescription = "This humanoid is slender and shorter than a human. It has jet black skin and snow white hair. A Dark Elf, or as some refer to it, a Drow, is a vicious creature compared to its surface-dwelling counterparts.",
                    Environment = "Underground",
                    HitPoints = 4,
                    ArmorClass = 16,
                    Size = "Medium",
                    CreatureType = "Humanoid",
                    Alignment = "Neutral Evil",
                    Speed = "30ft.",
                    Saves = "Fort +2, Ref +1, Will -1",
                    Feats = "Weapon Focus (rapier)",
                    ChallengeRating = 1,
                    BaseAttack = "+1",
                    Grapple = "+2",
                    FullAttack = "Rapier: +3 melee (1d6+1/18–20) or hand crossbow: +2 ranged (1d4/19–20) 60ft. range.",
                    SpecialAttack = "Poison: An opponent hit by a Drow’s poisoned weapon must succeed on a DC 13 Fortitude save or fall unconscious.",
                    ImageUrl = "https://db4sgowjqfwig.cloudfront.net/campaigns/236146/assets/1060677/drow.png?1595380544"
                },
                new Animal
                {
                    MonsterName = "Ettin", //good
                    MonsterDescription = "This hulking giant has two heads. Each head has a porcine face with a shovel jaw and protruding lower canines like a boar’s tusks.",
                    Environment = "Hills",
                    HitPoints = 65,
                    ArmorClass = 18,
                    Size = "Large",
                    CreatureType = "Giant",
                    Alignment = "Chaotic Evil",
                    Speed = "30ft.",
                    Saves = "Fort +9, Ref +2, Will +5",
                    Feats = "Alertness,Improved Initiative,Iron Will, Power Attack",
                    ChallengeRating = 6,
                    BaseAttack = "+7",
                    Grapple = "+17",
                    FullAttack = "2 Morningstars: +12/+7 melee (2d6+6) or 2 javelins: +5 ranged (1d8+6) 30ft. range.",
                    SpecialAttack = "None.",
                    ImageUrl = "https://www.dndbeyond.com/avatars/thumbnails/30783/726/1000/1000/638062016402079484.png"
                },
                new Animal
                {
                    MonsterName = "Frost Worm", //good
                    MonsterDescription = "This long, blue-white creature has nhuge mandibles and a strange nodule atop its head from which it generates a trilling sound.",
                    Environment = "Mountains and Tundras",
                    HitPoints = 147,
                    ArmorClass = 18,
                    Size = "Huge",
                    CreatureType = "Magical Beast",
                    Alignment = "Neutral",
                    Speed = "30ft. base/10ft. burrowing",
                    Saves = "Fort +14, Ref +9, Will +6",
                    Feats = "Alertness, Improved Initiative, Improved Natural Attack (bite), Iron Will, Weapon Focus (bite)",
                    ChallengeRating = 12,
                    BaseAttack = "+14",
                    Grapple = "+30",
                    FullAttack = "Bite: +21 melee (2d8+12 plus 1d8 cold)",
                    SpecialAttack = "Trill: This sonic mind-affecting compulsion affects all creatures within a 100-foot radius. Creatures must succeed on a DC 17 Will save or be stunned for 1d4 rounds.",
                    ImageUrl = "https://media-waterdeep.cursecdn.com/avatars/thumbnails/9170/25/1000/1000/637199798879244898.jpeg"
                },
                new Animal 
                {
                    MonsterName = "Gargoyle", //good
                    MonsterDescription = "This creature looks like a grotesque, winged humanoid with a horned head and a stony hide.",
                    Environment = "Any",
                    HitPoints = 37,
                    ArmorClass = 16,
                    Size = "Medium",
                    CreatureType = "Monstrous Humanoid",
                    Alignment = "Chaotic Evil",
                    Speed = "40ft. base/60ft. flying",
                    Saves = "Fort +5, Ref +6, Will +4",
                    Feats = "Multiattack, Toughness",
                    ChallengeRating = 4,
                    BaseAttack = "+4",
                    Grapple = "+6",
                    FullAttack = "2 Claws: +6 melee (1d4+2) and bite: +4 melee (1d6+1) and gore: +4 melee (1d6+1)",
                    SpecialAttack = "Freeze: A Gargoyle can hold itself so still it appears to be a statue. An observer must succeed on a DC 20 Spot check to notice the Gargoyle is alive.",
                    ImageUrl = "https://www.dndbeyond.com/avatars/thumbnails/30783/892/1000/1000/638062022959460682.png"
                }, 
                new Animal 
                {
                    MonsterName = "Ghoul", //good
                    MonsterDescription = "This foul undead appears more or less humanoid, but has decaying flesh drawn tight across clearly visible bones. It is mostly hairless and has eyes that burn like hot coals in sunken sockets.",
                    Environment = "Any",
                    HitPoints = 13,
                    ArmorClass = 14,
                    Size = "Medium",
                    CreatureType = "Undead",
                    Alignment = "Chaotic Evil",
                    Speed = "30ft.",
                    Saves = "Fort +0, Ref +2, Will +5",
                    Feats = "Multiattack",
                    ChallengeRating = 1,
                    BaseAttack = "+1",
                    Grapple = "+2",
                    FullAttack = "Bite: +2 melee (1d6+1 plus disease) and 2 claws: +0 melee (1d3)",
                    SpecialAttack = "Ghoul Fever: Any living creature hit by a Ghoul's bite must succeed a Fortitude save DC 15 or take 1d3 Con and 1d3 Dex damage for a day.",
                    ImageUrl = "https://images.squarespace-cdn.com/content/v1/5bd88db093a6320f071b1a50/1603945779391-06FIYNQKF4DZYQDPAFYR/3e_MM_Ghoul.jpg?format=2500w"
                },
                new Animal
                {
                    MonsterName = "Giant", //good
                    MonsterDescription = "This large creature has an oddly simian appearance, with overlong arms, stooped shoulders, a low forehead,and thick, powerful limbs.",
                    Environment = "Hills",
                    HitPoints = 102,
                    ArmorClass = 20,
                    Size = "Large",
                    CreatureType = "Giant",
                    Alignment = "Chaotic Evil",
                    Speed = "30ft.",
                    Saves = "Fort +12, Ref +3, Will +4",
                    Feats = "Cleave, Improved Bull Rush, Power Attack, Improved Sunder, Weapon Focus (greatclub)",
                    ChallengeRating = 7,
                    BaseAttack = "+9",
                    Grapple = "+20",
                    FullAttack = "Greatclub: +16/+11 melee (2d8+10) or 2 slams: +15 melee (1d4+7)",
                    SpecialAttack = "Rock Throw: +8 ranged (2d6+7) 120ft. range.",
                    ImageUrl = "https://www.dndbeyond.com/avatars/thumbnails/30783/933/1000/1000/638062024048160808.png"
                },
                new Animal
                {
                    MonsterName = "Githyanki", //good
                    MonsterDescription = "This tall, gaunt humanoid has rough, yellow skin and russet hair pulled into a pair of topknots. Its eyes have a sinister gleam, and its ears are pointed and serrated in back.",
                    Environment = "Astral Plane",
                    HitPoints = 6,
                    ArmorClass = 16,
                    Size = "Medium",
                    CreatureType = "Humanoid",
                    Alignment = "Lawful or Chaotic Evil",
                    Speed = "20ft.",
                    Saves = "Fort +4, Ref +1, Will -2",
                    Feats = "Weapon Focus (greatsword)",
                    ChallengeRating = 1,
                    BaseAttack = "+1",
                    Grapple = "+2",
                    FullAttack = "Masterwork greatsword: +4 melee (2d6+1/19–20)",
                    SpecialAttack = "Psionics: Dependent on the Githyanki's level it will be able to utilize different psionic abilities and attacks.",
                    ImageUrl = "https://images.squarespace-cdn.com/content/v1/5bd88db093a6320f071b1a50/1614836381731-B0QARTRA8GSJBRMKLY0B/3e_MM_Githyanki.jpg?format=2500w"
                },
                new Animal
                {
                    MonsterName = "Gnoll", //good
                    MonsterDescription = "This unsightly humanoid is taller than a human. It has gray skin, a furry body, and a head like a hyena’s, with a reddish-gray mane.",
                    Environment = "Plains",
                    HitPoints = 11,
                    ArmorClass = 15,
                    Size = "Medium",
                    CreatureType = "Humanoid",
                    Alignment = "Chaotic Evil",
                    Speed = "30ft.",
                    Saves = "Fort +4, Ref +0, Will +0",
                    Feats = "Power Attack",
                    ChallengeRating = 1,
                    BaseAttack = "+1",
                    Grapple = "+3",
                    FullAttack = "Spear: +3 melee (1d8+2/×3)",
                    SpecialAttack = "None.",
                    ImageUrl = "https://images.squarespace-cdn.com/content/v1/5bd88db093a6320f071b1a50/1597868444057-UCDLFAD85VRO0EJNP9ZB/Gnoll_MM_5e.jpeg?format=2500w"
                },
                new Animal
                {
                    MonsterName = "Gnome", //good
                    MonsterDescription = "This humanoid stands a little more than half as high as a human. It has a compact build, dark tan skin, fair hair, and large eyes.",
                    Environment = "Hills or Forests",
                    HitPoints = 6,
                    ArmorClass = 16,
                    Size = "Small",
                    CreatureType = "Humanoid",
                    Alignment = "Neutral Good",
                    Speed = "20ft.",
                    Saves = "Fort +4, Ref +0, Will -1",
                    Feats = "Weapon Focus (light crossbow)",
                    ChallengeRating = .5,
                    BaseAttack = "+1",
                    Grapple = "-3",
                    FullAttack = "Shortsword: +2 melee (1d6/19–20) or shortbow: +3 ranged (1d6/19–20) 70ft. range.",
                    SpecialAttack = "None.",
                    ImageUrl = "https://netstorage-tuko.akamaized.net/images/a9b3517cb302c63a.jpg"
                },
                new Animal
                {
                    MonsterName = "Goblin", //good
                    MonsterDescription = "This small humanoid has a flat face, broad nose, pointed ears, wide mouth, and tiny, sharp fangs. If you think the Kobold is annoying, wait until you meet one of these.",
                    Environment = "Plains",
                    HitPoints = 5,
                    ArmorClass = 15,
                    Size = "Small",
                    CreatureType = "Humanoid",
                    Alignment = "Neutral Evil",
                    Speed = "30ft.",
                    Saves = "Fort +3, Ref +1, Will -1",
                    Feats = " Alertness",
                    ChallengeRating = .33,
                    BaseAttack = "+1",
                    Grapple = "-3",
                    FullAttack = "Spear: +2 melee (1d6)",
                    SpecialAttack = "None.",
                    ImageUrl = "https://koboldpress.com/wp-content/uploads/2018/08/dust-goblin.jpg"
                },
                new Animal
                {
                    MonsterName = "Griffon", //good
                    MonsterDescription = "This beast’s body resembles that of a muscular lion. Its head and front legs are those of a great eagle, and it has a pair of large, golden wings.",
                    Environment = "Hills",
                    HitPoints = 59,
                    ArmorClass = 17,
                    Size = "Large",
                    CreatureType = "Magical Beast",
                    Alignment = "Neutral",
                    Speed = "30ft. base/80ft. flying",
                    Saves = "Fort +8, Ref +7, Will +5",
                    Feats = "Iron Will, Multiattack, Weapon Focus (bite)",
                    ChallengeRating = 4,
                    BaseAttack = "+7",
                    Grapple = "+15",
                    FullAttack = "Bite +11 melee (2d6+4) and 2 claws +8 melee (1d4+2)",
                    SpecialAttack = "Rake: Attack bonus +8 melee, damage 1d6+2.",
                    ImageUrl = "https://2e.aonprd.com/Images/Monsters/Griffon.png?AspxAutoDetectCookieSupport=1"
                },
                new Animal 
                {
                    MonsterName = "Hag", //good
                    MonsterDescription = "This creature looks like an ancient female human. It has sickly green skin and filthy black hair. A Hags love for evil is equaled only by their ugliness.",
                    Environment = "Marshes",
                    HitPoints = 49,
                    ArmorClass = 22,
                    Size = "Medium",
                    CreatureType = "Monstrous Humanoid",
                    Alignment = "Chaotic Evil",
                    Speed = "30ft. base/30ft. swimming",
                    Saves = "Fort +6, Ref +7, Will +7",
                    Feats = "Alertness, Blind-Fight, Combat Casting, Great Fortitude",
                    ChallengeRating = 5,
                    BaseAttack = "+9",
                    Grapple = "+13",
                    FullAttack = "2 Claws: +13 melee (1d4+4)",
                    SpecialAttack = "Spell-Like Abilities: At will—dancing lights, disguise self, and ghost sound. The stronger the Hag the more abilities it will have.",
                    ImageUrl = "https://images.squarespace-cdn.com/content/v1/5bd88db093a6320f071b1a50/b60c194c-706c-4298-951a-461c5488ff9e/3e_MM_GreenHag.PNG?format=2500w"
                },
                new Animal
                {
                    MonsterName = "Halfling",  //good
                    MonsterDescription = "This humanoid stands about half as high as a human. It has an athletic build, ruddy skin, straight black hair, and dark eyes.",
                    Environment = "Hills and Plains",
                    HitPoints = 5,
                    ArmorClass = 16,
                    Size = "Small",
                    CreatureType = "Humanoid",
                    Alignment = "Neutral",
                    Speed = "20ft.",
                    Saves = "Fort +4, Ref +2, Will +0",
                    Feats = "Weapon Focus (longsword)",
                    ChallengeRating = .5,
                    BaseAttack = "+1",
                    Grapple = "-3",
                    FullAttack = "Longsword +3 melee (1d6/19–20)",
                    SpecialAttack = "None.",
                    ImageUrl = "https://149844032.v2.pressablecdn.com/wp-content/uploads/2021/03/halfing-fighter.png"
                },
                new Animal
                {
                    MonsterName = "Harpy", //good
                    MonsterDescription = "This creature looks like an evil-faced old human with the lower body, legs, and wings of a reptilian monster. Its hair is tangled, filthy, and crusted with blood.",
                    Environment = "Marshes",
                    HitPoints = 31,
                    ArmorClass = 13,
                    Size = "Medium",
                    CreatureType = "Monstrous Humanoid",
                    Alignment = "Chaotic Evil",
                    Speed = "20ft. base/80ft. flying",
                    Saves = "Fort +2, Ref +7, Will +6",
                    Feats = "Dodge, Flyby Attack, Persuasive ",
                    ChallengeRating = 4,
                    BaseAttack = "+7",
                    Grapple = "+7",
                    FullAttack = "Club +7/+2 melee (1d6) and 2 claws +2 melee (1d3)",
                    SpecialAttack = "Captivating Song: All creatures within a 300-foot spread must succeed on a DC 16 Will save or become captivated. This is a sonic mind-affecting charm effect.",
                    ImageUrl = "https://images.squarespace-cdn.com/content/v1/5bd88db093a6320f071b1a50/1619669633707-Z54DYX5KK80KIILF089Z/3e_MM_Harpy.jpg?format=2500w"
                },
                new Animal
                {
                    MonsterName = "Hobgoblin", //good
                    MonsterDescription = "This burly humanoid stands over 6 feet tall. It has hairy skin, feral eyes, and a flat nose and chin.",
                    Environment = "Hills",
                    HitPoints = 6,
                    ArmorClass = 15,
                    Size = "Medium",
                    CreatureType = "Humanoid",
                    Alignment = "Lawful Evil",
                    Speed = "30ft.",
                    Saves = "Fort +4, Ref +1, Will -1",
                    Feats = "Alertness",
                    ChallengeRating = .5,
                    BaseAttack = "+1",
                    Grapple = "+2",
                    FullAttack = "Longsword +2 melee (1d8+1/19–20)",
                    SpecialAttack = "None.",
                    ImageUrl = "https://db4sgowjqfwig.cloudfront.net/campaigns/165353/assets/792603/b0af790c909753781b1557f1b50e7f0c.jpg?1508815667"
                },
                new Animal
                {
                    MonsterName = "Hydra", //good
                    MonsterDescription = "This beast resembles some great reptile with a veritable forest of heads on long, slender necks. Each six heads equipped with a mouth full of wicked teeth.",
                    Environment = "Marshes",
                    HitPoints = 66,
                    ArmorClass = 16,
                    Size = "Huge",
                    CreatureType = "Magical Beast",
                    Alignment = "Neutral",
                    Speed = "20ft. base/20ft. swimming",
                    Saves = "Fort +10, Ref +6, Will +4",
                    Feats = "Combat Reflexes, Iron Will, Toughness, Weapon Focus (bite)",
                    ChallengeRating = 5,
                    BaseAttack = "+6",
                    Grapple = "+17",
                    FullAttack = "6 Bites: +8 melee (1d10+3)",
                    SpecialAttack = "None.",
                    ImageUrl = "https://www.dndbeyond.com/avatars/thumbnails/30830/759/1000/1000/638063796594944128.png"
                },
                new Animal
                {
                    MonsterName = "Kobold", //good
                    MonsterDescription = "This creature is about the size of a gnome. It has a scaly hide, a ratlike tail, and a doglike head with two small horns. Slightly less annoying then a Goblin.",
                    Environment = "Caves and Forests",
                    HitPoints = 4,
                    ArmorClass = 15,
                    Size = "Small",
                    CreatureType = "Humanoid",
                    Alignment = "Lawful Evil",
                    Speed = "30ft.",
                    Saves = "Fort +2, Ref +1, Will -1",
                    Feats = "Alertness",
                    ChallengeRating = .25,
                    BaseAttack = "+1",
                    Grapple = "-4",
                    FullAttack = "Spear +1 melee (1d6–1/×3) or sling: +3 ranged (1d3) 25ft. range.",
                    SpecialAttack = "None.",
                    ImageUrl = "https://images.squarespace-cdn.com/content/v1/5bd88db093a6320f071b1a50/1552683651343-I3WZLIU5QGD64X2CBN46/Kobold3e.jpg?format=2500w"
                },
                new Animal
                {
                    MonsterName = "Krenshar", //good
                    MonsterDescription = "This creature seems to combine the worst features of a wolf and a hyena. It has a shaggy, spotted coat, a bristling mane, and a long, bushy tail. Did I mention its face can peel back?",
                    Environment = "Forests",
                    HitPoints = 11,
                    ArmorClass = 15,
                    Size = "Medium",
                    CreatureType = "Magical Beast",
                    Alignment = "Neutral",
                    Speed = "40ft.",
                    Saves = "Fort +3, Ref +5, Will +1",
                    Feats = "Multiattack, Track",
                    ChallengeRating = 1,
                    BaseAttack = "+2",
                    Grapple = "+2",
                    FullAttack = "Bite: +2 melee (1d6) and 2 claws: +0 melee (1d4)",
                    SpecialAttack = "Scare: As a standard action, a Krenshar can pull the skin back from its head. A DC 13 Will save is required or the foe is forced to flee.",
                    ImageUrl = "https://i.pinimg.com/736x/13/9d/1f/139d1f5437be4da1f5ae0e02d0e1eda0.jpg"
                },
                new Animal
                {
                    MonsterName = "Lich", //good
                    MonsterDescription = "This skeletal creature wears the rotting, rich robes of a mighty wizard long dead. Hateful crimson light dances in its empty eye sockets.",
                    Environment = "Caves and Dungeons",
                    HitPoints = 74,
                    ArmorClass = 23,
                    Size = "Medium",
                    CreatureType = "Undead",
                    Alignment = "Neutral Evil",
                    Speed = "30ft.",
                    Saves = "Fort +4, Ref +7, Will +10",
                    Feats = "Combat Casting, Craft Wondrous Item, Quicken Spell,Scribe Scroll, Silent Spell, Spell Focus (evocation), Still Spell, Toughness",
                    ChallengeRating = 13,
                    BaseAttack = "+5",
                    Grapple = "+5",
                    FullAttack = "Touch: +5 melee (1d8+5 negative energy plus paralysis) or quarterstaff: +5 melee (1d6)",
                    SpecialAttack = "Spells: A Lich has an arsenal of spells at its disposal. The spells the Lich can use are equivalent to the spells it could once cast as a Wizard.",
                    ImageUrl = "https://qph.cf2.quoracdn.net/main-qimg-2bab2e11e168a22315f57c33f730e625"
                },
                new Animal
                {
                    MonsterName = "Lizardfolk", //good
                    MonsterDescription = "This tall humanoid looks like a cross between a powerfully built human and a lizard. It has clawed hands, a long tail, and toothy jaws.",
                    Environment = "Marshes",
                    HitPoints = 11,
                    ArmorClass = 15,
                    Size = "Medium",
                    CreatureType = "Humanoid",
                    Alignment = "Neutral",
                    Speed = "30ft.",
                    Saves = "Fort +1, Ref +3, Will +0",
                    Feats = "Multiattack",
                    ChallengeRating = 1,
                    BaseAttack = "+1",
                    Grapple = "+2",
                    FullAttack = "2 Claws: +2 melee (1d4+1) and bite: +0 melee (1d4); or club: +2 melee (1d6+1) and bite: +0 melee (1d4)",
                    SpecialAttack = "None.",
                    ImageUrl = "https://images.squarespace-cdn.com/content/v1/5bd88db093a6320f071b1a50/1587003569460-913W1RF7E7VX0S5X6O8M/Poison_MM3_3e.png?format=2500w"
                },
                new Animal
                {
                    MonsterName = "Manticore", //good
                    MonsterDescription = "This creature is a monster in every sense of the word. It has the head of a vaguely humanoid beast, the body of a lion, and the wings of a dragon. Its long tail ends in a cluster of deadly spikes.",
                    Environment = "Marshes",
                    HitPoints = 57,
                    ArmorClass = 17,
                    Size = "Large",
                    CreatureType = "Magical Beast",
                    Alignment = "Lawful Evil",
                    Speed = "30ft. base/50ft. flying",
                    Saves = "Fort +9, Ref +7, Will +3",
                    Feats = " Flyby Attack, Multiattack, Track, Weapon Focus (spikes)",
                    ChallengeRating = 7,
                    BaseAttack = "+6",
                    Grapple = "+15",
                    FullAttack = "2 Claws: +10 melee (2d4+5) and bite: +8 melee (1d8+2)",
                    SpecialAttack = "Spikes: With a snap of its tail, a manticore can loose a volley of spikes. 6 Spikes: +8 ranged (1d8+2/19–20) 180ft. range and all targets must be within 30 ft. of each other.",
                    ImageUrl = "https://images.squarespace-cdn.com/content/v1/5bd88db093a6320f071b1a50/f93447d9-c552-4e09-b668-f22b363996aa/5e_MM_Manticore.png?format=2500w"
                },
                new Animal
                {
                    MonsterName = "Medusa", //good
                    MonsterDescription = "At first glance this creature appears to be a well-proportioned human, a closer look reveals a hideous face crowned with writhing, hissing snakes instead of hair and scaly earth-colored skin.",
                    Environment = "Caves and Marshes",
                    HitPoints = 33,
                    ArmorClass = 15,
                    Size = "Medium",
                    CreatureType = "Monstrous Humanoid",
                    Alignment = "Lawful Evil",
                    Speed = "30ft.",
                    Saves = "Fort +3, Ref +7, Will +6",
                    Feats = "Point Blank Shot, Precise Shot, Weapon Finesse",
                    ChallengeRating = 7,
                    BaseAttack = "+6",
                    Grapple = "+6",
                    FullAttack = " Shortbow: +8/+3 ranged (1d6/×3) 70ft. range; or dagger: +8/+3 melee (1d4/19–20) and snakes +3 melee (1d4)",
                    SpecialAttack = "Petrifying Gaze: Turn to stone permanently, 30 feet, Fortitude DC 15 negates.",
                    ImageUrl = "https://images.squarespace-cdn.com/content/v1/5bd88db093a6320f071b1a50/1612411475450-7UDD65Y0PKRAPD8OGQRH/4e_Medusa_MV.jpg?format=2500w"
                },
                new Animal
                {
                    MonsterName = "Mimic", //good
                    MonsterDescription = "What you and your adventuring group thought to be payday could become a fight for your life. This creature can perfectly imitate the appearance of any object, most of the time a treasure chest.",
                    Environment = "Dungeons and Underground",
                    HitPoints = 52,
                    ArmorClass = 15,
                    Size = "Large",
                    CreatureType = "Aberration",
                    Alignment = "Neutral",
                    Speed = "10ft.",
                    Saves = "Fort +5, Ref +5, Will +6",
                    Feats = " Alertness, Lightning Reflexes, Weapon Focus (slam)",
                    ChallengeRating = 4,
                    BaseAttack = "+5",
                    Grapple = "+13",
                    FullAttack = "2 Slams: +9 melee (1d8+4)",
                    SpecialAttack = "Crush: A mimic deals 1d8+4 points of damage with a successful grapple check.",
                    ImageUrl = "https://images.squarespace-cdn.com/content/v1/5bd88db093a6320f071b1a50/1554344739094-83NY3U8PG4M1CQD9NX3M/Mimic_3e.jpg?format=2500w"
                },
                new Animal
                {
                    MonsterName = "Mind Flayer", //good
                    MonsterDescription = "This strange being stands about as tall as a human. Its flesh is rubbery and greenish, glistening with slime. The head looks like a four-tentacled octopus, made all the more horrible by a pair of bloated white eyes.",
                    Environment = "Underground",
                    HitPoints = 44,
                    ArmorClass = 15,
                    Size = "Medium",
                    CreatureType = "Aberration",
                    Alignment = "Lawful Evil",
                    Speed = "30ft.",
                    Saves = "Fort +3, Ref +4, Will +9",
                    Feats = "Combat Casting, Improved Initiative, Weapon Finesse",
                    ChallengeRating = 8,
                    BaseAttack = "+6",
                    Grapple = "+7",
                    FullAttack = "4 Tentacles: +8 melee (1d4+1) ",
                    SpecialAttack = "Mind Blast: This psionic attack is a cone 60 feet long. Anyone caught in this cone must succeed on a DC 17 Will save or be stunned for 3d4 rounds.",
                    ImageUrl = "https://www.belloflostsouls.net/wp-content/uploads/2020/05/alhoon.jpg"
                },
                new Animal
                {
                    MonsterName = "Minotaur", //good
                    MonsterDescription = "The creature looks like an incredibly tall, powerfully muscled man, covered in fur, with the head of a bull. The dark eyes of the brute gleam with savage fury.",
                    Environment = "Dungeons and Underground",
                    HitPoints = 39,
                    ArmorClass = 14,
                    Size = "Large",
                    CreatureType = "Monstrous Humanoid",
                    Alignment = "Chaotic Evil",
                    Speed = "30ft.",
                    Saves = "Fort +6, Ref +5, Will +5",
                    Feats = "Great Fortitude, Power Attack, Track ",
                    ChallengeRating = 4,
                    BaseAttack = "+6",
                    Grapple = "+14",
                    FullAttack = "Greataxe: +9/+4 melee (3d6+6/×3) and gore: +4 melee (1d8+2)",
                    SpecialAttack = "Powerful Charge: A charging attack with a +9 attack bonus that deals 4d6+6 points of damage.",
                    ImageUrl = "https://i.pinimg.com/736x/0d/70/07/0d700720bccb4c145c7ba57fb34fc766.jpg"
                },
                new Animal
                {
                    MonsterName = "Mummy", //good
                    MonsterDescription = "This creature looks like a withered and desiccated corpse, with features hidden beneath centuries-old funereal wrappings. It moves with a slow, shambling gait.",
                    Environment = "Dungeons and Underground",
                    HitPoints = 55,
                    ArmorClass = 20,
                    Size = "Medium",
                    CreatureType = "Undead",
                    Alignment = "Lawful Evil",
                    Speed = "20ft.",
                    Saves = "Fort +4, Ref +2, Will +8",
                    Feats = "Alertness, Great Fortitude, Toughness",
                    ChallengeRating = 5,
                    BaseAttack = "+4",
                    Grapple = "+11",
                    FullAttack = "Slam +11 melee (1d6+10 plus mummy rot)",
                    SpecialAttack = "Mummy Rot: Supernatural disease—slam, Fortitude DC 16, incubation period 1 minute; damage 1d6 to Constitution.",
                    ImageUrl = "https://images.squarespace-cdn.com/content/v1/5bd88db093a6320f071b1a50/1570044093737-ZCEJA92552JTQ909ZT3I/5e_Mummy.jpeg?format=2500w"
                },
                new Animal
                {
                    MonsterName = "Nightmare", //good
                    MonsterDescription = "This creature looks like a large, powerful horse with a jetblack coat. A closer look, however, reveals its true nature. Flames wreathe its steely hooves, and smolder in the depths of its dark eyes.",
                    Environment = "The Gray Waste",
                    HitPoints = 45,
                    ArmorClass = 24,
                    Size = "Large",
                    CreatureType = "Outsider",
                    Alignment = "Neutral Evil",
                    Speed = "40ft. base/90ft. flying",
                    Saves = "Fort +8, Ref +7, Will +6",
                    Feats = "Alertness, Improved Initiative, Run",
                    ChallengeRating = 5,
                    BaseAttack = "+6",
                    Grapple = "+14",
                    FullAttack = "2 Hooves: +9 melee (1d8+4 plus 1d4 fire) and bite: +4 melee (1d8+2)",
                    SpecialAttack = "Smoke: Anyone in the 15ft. cone must succeed on a DC 16 Fortitude save or take a –2 penalty on all attack and damage rolls.",
                    ImageUrl = "https://www.dndbeyond.com/avatars/thumbnails/30833/688/1000/1000/638063870454021777.png"
                },
                new Animal
                {
                    MonsterName = "Nymph", //good
                    MonsterDescription = "This being’s beauty exceeds mere words; she is captivating and dangerous because of the emotions she inspires. She has long, copper hair, perfect skin, large eyes, and long, swept-back ears.",
                    Environment = "Forests",
                    HitPoints = 27,
                    ArmorClass = 17,
                    Size = "Medium",
                    CreatureType = "Fey",
                    Alignment = "Chaotic Good",
                    Speed = "30ft.",
                    Saves = "Fort +7, Ref +12, Will +12",
                    Feats = "Combat Casting, Dodge, Weapon Finesse ",
                    ChallengeRating = 7,
                    BaseAttack = "+3",
                    Grapple = "+3",
                    FullAttack = "Dagger: +6 melee (1d4/19–20)",
                    SpecialAttack = "Blinding Beauty: Affects all humanoids within 30 feet of a Nymph. Any who look directly at a Nymph must succeed on a DC 17 Fortitude save or be temporarily blinded.",
                    ImageUrl = "https://images.squarespace-cdn.com/content/v1/5bd88db093a6320f071b1a50/1594266638954-VG5VFR9LC87QXP9XU5HZ/Dryad_MM_3e.jpg?format=2500w"
                },
                new Animal
                {
                    MonsterName = "Ogre", //good
                    MonsterDescription = "This hulking brute appears to be at least 9 feet tall. It has a thick hide covered in dark, warty bumps, it wears smelly skins, and its hair is long, and greasy.",
                    Environment = "Hills and Marshes",
                    HitPoints = 29,
                    ArmorClass = 16,
                    Size = "Large",
                    CreatureType = "Giant",
                    Alignment = "Chaotic Evil",
                    Speed = "30ft.",
                    Saves = "Fort +6, Ref +0, Will +1",
                    Feats = "Toughness, Weapon Focus (greatclub)",
                    ChallengeRating = 3,
                    BaseAttack = "+3",
                    Grapple = "+12",
                    FullAttack = "Greatclub: +8 melee (2d8+7)",
                    SpecialAttack = "None.",
                    ImageUrl = "https://i0.wp.com/www.hipstersanddragons.com/wp-content/uploads/2020/12/large-monsters-dnd-5e.jpg?resize=629%2C818&ssl=1"
                },
                new Animal
                {
                    MonsterName = "Black Pudding", //good
                    MonsterDescription = "This creature resembles nothing so much as a roundish blob of inky black goo. If you see such a thing slowly creeping towards you, it would be wise to leave.",
                    Environment = "Underground",
                    HitPoints = 115,
                    ArmorClass = 3,
                    Size = "Huge",
                    CreatureType = "Ooze",
                    Alignment = "Neutral",
                    Speed = "20ft. base/20ft. climbing",
                    Saves = "Fort +9, Ref -2, Will -2",
                    Feats = "None",
                    ChallengeRating = 7,
                    BaseAttack = "+7",
                    Grapple = "+18",
                    FullAttack = "Slam: +8 melee (2d6+4 plus 2d6 acid) ",
                    SpecialAttack = "Constrict: A Black Pudding deals automatic slam and acid damage with a successful grapple check.",
                    ImageUrl = "https://www.dndbeyond.com/avatars/thumbnails/30834/144/1000/1000/638063882400735307.png"
                },
                new Animal
                {
                    MonsterName = "Gelatinous Cube", //good
                    MonsterDescription = "This creature looks like a thick wall of quivering, transparent protoplasm. If you see bones or weapons floating inside this ooze, that means a poor soul fell victim not too long ago.",
                    Environment = "Dungeons and Underground",
                    HitPoints = 54,
                    ArmorClass = 3,
                    Size = "Huge",
                    CreatureType = "Ooze",
                    Alignment = "Neutral",
                    Speed = "15ft.",
                    Saves = "Fort +9, Ref -4, Will -4",
                    Feats = "None",
                    ChallengeRating = 3,
                    BaseAttack = "+3",
                    Grapple = "+11",
                    FullAttack = "Slam: +1 melee (1d6 plus 1d6 acid)",
                    SpecialAttack = "Engulf: Although it moves slowly, a gelatinous cube can simply mow down Large or smaller creatures. The target must succeed on a DC 13 Reflex save or be engulfed.",
                    ImageUrl = "https://www.dndbeyond.com/avatars/thumbnails/30834/149/1000/1000/638063882505895317.png"
                },
                new Animal
                {
                    MonsterName = "Orc", //good
                    MonsterDescription = "This creature looks like a primitive human with gray skin and coarse hair.It has a stooped posture, low forehead, and a piglike face.",
                    Environment = "Caves and Hills",
                    HitPoints = 5,
                    ArmorClass = 13,
                    Size = "Medium",
                    CreatureType = "Humanoid",
                    Alignment = "Chaotic Evil",
                    Speed = "30ft.",
                    Saves = "Fort +3, Ref +0, Will -2",
                    Feats = "Alertness",
                    ChallengeRating = .5,
                    BaseAttack = "+1",
                    Grapple = "+4",
                    FullAttack = "Falchion: +4 melee (2d4+4/18–20)",
                    SpecialAttack = "None.",
                    ImageUrl = "https://i.pinimg.com/736x/08/53/6c/08536cd5271946a7784a798758b215a2.jpg"
                },
                new Animal
                {
                    MonsterName = "Owlbear", //good
                    MonsterDescription = "This creature has a thick, shaggy coat of feathers and fur. Its body is like a bear’s, but it has an avian head with big, round eyes and a hooked beak.",
                    Environment = "Forests and Tundras",
                    HitPoints = 52,
                    ArmorClass = 15,
                    Size = "Large",
                    CreatureType = "Magical Beast",
                    Alignment = "Neutral",
                    Speed = "30ft.",
                    Saves = "Fort +9, Ref +5, Will +2",
                    Feats = "Alertness, Track",
                    ChallengeRating = 4,
                    BaseAttack = "+5",
                    Grapple = "+14",
                    FullAttack = " 2 Claws: +9 melee (1d6+5) and bite: +4 melee (1d8+2)",
                    SpecialAttack = "Improved Grab: To use this attack, an Owlbear must hit with a claw attack. It can then attempt a grapple as a free action without provoking an attack of opportunity.",
                    ImageUrl = "https://images.squarespace-cdn.com/content/v1/5bd88db093a6320f071b1a50/1589318790814-4C6K7YMLQQVERP088M5L/image-asset.jpeg?format=2500w"
                },
                new Animal
                {
                    MonsterName = "Pegasus", //good
                    MonsterDescription = "This creature looks like a horse but has two large, feathered wings. Its coat and wings are pure white. It is said one of these creatures served as a mount for a great champion.",
                    Environment = "Forests",
                    HitPoints = 34,
                    ArmorClass = 14,
                    Size = "Large",
                    CreatureType = "Magical Beast",
                    Alignment = "Chaotic Good",
                    Speed = "60ft. base/120ft. flying",
                    Saves = "Fort +7, Ref +6, Will +4",
                    Feats = "Flyby Attack, Iron Will",
                    ChallengeRating = 3,
                    BaseAttack = "+4",
                    Grapple = "+12",
                    FullAttack = "2 Hooves: +7 melee (1d6+4) and bite: +2 melee (1d3+2)",
                    SpecialAttack = "None.",
                    ImageUrl = "https://www.dndbeyond.com/avatars/thumbnails/30834/674/1000/1000/638063894663528037.png"
                },
                new Animal
                {
                    MonsterName = "Phase Spider", //good
                    MonsterDescription = "This creature resembles a giant wolf spider, except with a larger head and variegated markings in white, and blue over the legs and back. Its eight eyes are silver-white.",
                    Environment = "Caves and Hills",
                    HitPoints = 42,
                    ArmorClass = 15,
                    Size = "Large",
                    CreatureType = "Magical Beast",
                    Alignment = "Neutral",
                    Speed = "40ft. base/20ft. climbing",
                    Saves = "Fort +7, Ref +7, Will +2",
                    Feats = "Ability Focus (poison), Improved Initiative",
                    ChallengeRating = 5,
                    BaseAttack = "+5",
                    Grapple = "+12",
                    FullAttack = "Bite +7 melee (1d6+4 plus poison)",
                    SpecialAttack = "Ethereal Jaunt: A Phase Spider can shift from the Ethereal Plane to the Material Plane as a free action, and shift back again as a move action.",
                    ImageUrl = "https://www.dndbeyond.com/avatars/thumbnails/30849/305/1000/1000/638064499219616973.png"
                },
                new Animal
                {
                    MonsterName = "Pseudodragon", //good
                    MonsterDescription = "This dragon is quite tiny, slightly smaller than a housecat. It is red-brown in color, has fine scales, sharp horns and teeth. Its stinger tail is about twice as long as its body.",
                    Environment = "Caves and Forests",
                    HitPoints = 15,
                    ArmorClass = 18,
                    Size = "Tiny",
                    CreatureType = "Dragon",
                    Alignment = "Neutral Good",
                    Speed = "15ft. base/60ft. flying",
                    Saves = "Fort +4, Ref +5, Will +4",
                    Feats = "Weapon Finesse",
                    ChallengeRating = 1,
                    BaseAttack = "+2",
                    Grapple = "-8",
                    FullAttack = "Sting: +4 melee (1d3–2 plus poison) and bite –1 melee (1d1)",
                    SpecialAttack = "Poison: Injury, Fortitude DC 14, initial damage sleep for 1 minute, secondary damage sleep for 1d3 hours.",
                    ImageUrl = "https://www.dndbeyond.com/avatars/thumbnails/30834/696/1000/1000/638063895061837826.png"
                },
                new Animal
                {
                    MonsterName = "Purple Worm", //good
                    MonsterDescription = "This creature looks like a massive worm covered with plates of dark purple, chitinous armor. Its toothy maw is as wide as a human is tall.",
                    Environment = "Underground",
                    HitPoints = 200,
                    ArmorClass = 19,
                    Size = "Gargantuan",
                    CreatureType = "Magical Beast",
                    Alignment = "Neutral",
                    Speed = "20ft. base/20ft. burrowing/10ft. swimming",
                    Saves = "Fort +17, Ref +8, Will +4",
                    Feats = "Awesome Blow, Cleave, Improved Bull Rush, Power Attack, Weapon Focus (bite), Weapon Focus (sting) ",
                    ChallengeRating = 12,
                    BaseAttack = "+16",
                    Grapple = "+40",
                    FullAttack = "Bite: +25 melee (2d8+12) and sting: +20 melee (2d6+6 plus poison)",
                    SpecialAttack = "Poison: Injury, Fortitude DC 25, initial damage 1d6 Str, secondary damage 2d6 Str.",
                    ImageUrl = "https://www.dndbeyond.com/avatars/thumbnails/30834/702/1000/1000/638063895243217798.png"
                },
                new Animal
                {
                    MonsterName = "Rakshasa", //good
                    MonsterDescription = "This being looks like a humanoid tiger garbed in expensive clothes. The body seems mostly human except for a luxurious coat of tiger’s fur and its tiger head.",
                    Environment = "Marshes",
                    HitPoints = 52,
                    ArmorClass = 21,
                    Size = "Medium",
                    CreatureType = "Outsider",
                    Alignment = "Lawful Evil",
                    Speed = "40ft.",
                    Saves = "Fort +8, Ref +7, Will +6",
                    Feats = "Alertness, Combat Casting, Dodge",
                    ChallengeRating = 10,
                    BaseAttack = "+7",
                    Grapple = "+8",
                    FullAttack = "2 Claws: +8 melee (1d4+1) and bite: +3 melee (1d6)",
                    SpecialAttack = "Spells: A Rakshasa can casts spells as a 7th-level sorcerer.",
                    ImageUrl = "https://www.dndbeyond.com/avatars/thumbnails/30834/971/1000/1000/638063901618639290.png"
                },
                new Animal
                {
                    MonsterName = "Roc", //good
                    MonsterDescription = "If the sun is suddenly blackened out, do not fear; it is only a Roc overhead. Unless it's hungry, then you should be very afraid. The Roc is an enormous bird.",
                    Environment = "Mountains and Plains",
                    HitPoints = 207,
                    ArmorClass = 17,
                    Size = "Gargantuan",
                    CreatureType = "Animal",
                    Alignment = "Neutral",
                    Speed = "20ft. base/80ft. flying",
                    Saves = "Fort +18, Ref +13, Will +9",
                    Feats = " Alertness, Flyby Attack, Iron Will, Multiattack, Power Attack, Snatch, Wingover",
                    ChallengeRating = 9,
                    BaseAttack = "+13",
                    Grapple = "+37",
                    FullAttack = "2 talons +21 melee (2d6+12) and bite +19 melee (2d8+6)",
                    SpecialAttack = "None.",
                    ImageUrl = "https://www.aidedd.org/dnd/images/roc.jpg"
                },
                new Animal
                {
                    MonsterName = "Rust Monster", //good
                    MonsterDescription = "This creature seems to be about the size of a pony. It has four insectlike legs and a squat, humped body protected by a thick, lumpy hide. This creature has an insatiable appetite for all metal.",
                    Environment = "Caves and Underground",
                    HitPoints = 27,
                    ArmorClass = 18,
                    Size = "Medium",
                    CreatureType = "Aberration",
                    Alignment = "Neutral",
                    Speed = "40ft.",
                    Saves = "Fort +2, Ref +4, Will +5",
                    Feats = "Alertness, Track",
                    ChallengeRating = 3,
                    BaseAttack = "+3",
                    Grapple = "+3",
                    FullAttack = "Antennae: touch attack +3 melee (rust) and bite: –2 melee (1d3)",
                    SpecialAttack = "Rust: A successful antennae attack causes the target metal to corrode, falling to pieces. Magical metal items must succeed a DC 17 Reflex to avoid being rusted.",
                    ImageUrl = "https://i0.wp.com/jacobpeyton.com/wp-content/uploads/2019/08/rust-monster.jpeg?fit=877%2C642&ssl=1"
                },
                new Animal
                {
                    MonsterName = "Satyr", //good
                    MonsterDescription = "This being might best be described as a horned man with the legs of a goat. Legend says one of these creatures once trained a great champion.",
                    Environment = "Forests",
                    HitPoints = 22,
                    ArmorClass = 15,
                    Size = "Medium",
                    CreatureType = "Fey",
                    Alignment = "Chaotic Good or Chaotic Neutral",
                    Speed = "40ft.",
                    Saves = "Fort +2, Ref +5, Will +5",
                    Feats = "Alertness, Dodge, Mobility",
                    ChallengeRating = 2,
                    BaseAttack = "+2",
                    Grapple = "+2",
                    FullAttack = "Head butt: +2 melee (1d6) and dagger: –3 melee (1d4/19–20)",
                    SpecialAttack = "None.",
                    ImageUrl = "https://i.pinimg.com/1200x/a0/ed/e0/a0ede02cc3facb262b337a4122a4098e.jpg"
                },
                new Animal
                {
                    MonsterName = "Skeleton", //good 
                    MonsterDescription = "This creature appears to be nothing but a set of animated bones. Pinpoints of red light smolder in its empty eye sockets.",
                    Environment = "Dungeons and Plains",
                    HitPoints = 6,
                    ArmorClass = 15,
                    Size = "Medium",
                    CreatureType = "Undead",
                    Alignment = "Neutral Evil",
                    Speed = "30ft.",
                    Saves = "Fort +0, Ref +1, Will +2",
                    Feats = "Improved Initiative",
                    ChallengeRating = .33,
                    BaseAttack = "+0",
                    Grapple = "+1",
                    FullAttack = "Scimitar: +1 melee (1d6+1/18–20) or 2 claws: +1 melee (1d4+1)",
                    SpecialAttack = "None.",
                    ImageUrl = "https://www.dndbeyond.com/avatars/thumbnails/30835/849/1000/1000/638063922565505819.png"
                },
                new Animal
                {
                    MonsterName = "Spectre", //good
                    MonsterDescription = "This ghostly entity looks like a human, but with a diaphanous and faintly luminous body. Spectres disdain sunlight, as it leaves them powerless.",
                    Environment = "Any",
                    HitPoints = 45,
                    ArmorClass = 15,
                    Size = "Medium",
                    CreatureType = "Undead",
                    Alignment = "Lawful Evil",
                    Speed = "40ft. base/80ft. flying",
                    Saves = "Fort +2, Ref +5, Will +7",
                    Feats = "Alertness, Blind-Fight, Improved Initiative",
                    ChallengeRating = 7,
                    BaseAttack = "+3",
                    Grapple = "Cannot grapple or be grappled.",
                    FullAttack = "Incorporeal Touch: +6 melee (1d8 plus energy drain)",
                    SpecialAttack = "Energy Drain: Living creatures hit by a incorporeal touch attack gain two negative levels. DC is 15 Fortitude save to remove a negative level.",
                    ImageUrl = "https://i.imgur.com/oEfFP6K.png"
                },
                new Animal
                {
                    MonsterName = "Tarrasque", //good
                    MonsterDescription = "This scaly monstrosity is as tall as a five-story building. It carries itself like a bird of prey, leaning well forward and using its powerful, lashing tail for balance. The head of this great destroyer is crowned by two horns.",
                    Environment = "Any",
                    HitPoints = 858,
                    ArmorClass = 35,
                    Size = "Colossal",
                    CreatureType = "Magical Beast",
                    Alignment = "Neutral",
                    Speed = "20ft.",
                    Saves = "Fort +38, Ref +29, Will +20",
                    Feats = "Alertness, Awesome Blow, Blind-Fight, Cleave, Combat Reflexes, Dodge, Great Cleave, Improved Bull Rush, Improved Initiative, Iron Will, Power Attack, Toughness",
                    ChallengeRating = 20,
                    BaseAttack = "+48",
                    Grapple = "+81",
                    FullAttack = " Bite: +57 melee (4d8+17/18–20/×3) and 2 horns: +52 melee (1d10+8) and 2 claws: +52 melee (1d12+8)",
                    SpecialAttack = "Rush: Once per minute, the normally slow-moving tarrasque can move at a speed of 150 feet.",
                    ImageUrl = "https://images.squarespace-cdn.com/content/v1/5bd88db093a6320f071b1a50/e964864a-a818-427b-b867-288a86444519/3e_MM_Tarrasque.jpg?format=2500w"
                },
                new Animal
                {
                    MonsterName = "Treant", //good
                    MonsterDescription = "This tall being looks much like an animated tree. Its skin is thick and brown, with a barklike texture. Its arms are gnarled like branches, and its legs look like the split trunk of a tree.",
                    Environment = "Forests",
                    HitPoints = 66,
                    ArmorClass = 20,
                    Size = "Huge",
                    CreatureType = "Plant",
                    Alignment = "Neutral Good",
                    Speed = "30ft.",
                    Saves = "Fort +10, Ref +1, Will +7",
                    Feats = "Improved Sunder, Iron Will, Power Attack ",
                    ChallengeRating = 8,
                    BaseAttack = "+5",
                    Grapple = "+22",
                    FullAttack = "2 Slams: +12 melee (2d6+9) ",
                    SpecialAttack = "Animate Trees: Double damage against objects, trample 2d6+13.",
                    ImageUrl = "https://www.dndbeyond.com/avatars/thumbnails/30836/130/1000/1000/638063929302059775.png"
                },
                new Animal
                {
                    MonsterName = "Troll",//good
                    MonsterDescription = "This big creature is about one and a half times as tall as a human but very thin. It has long arms and legs. The legs end in great three-toed feet, the arms in powerful hands with sharpened claws.",
                    Environment = "Marshes and Mountains",
                    HitPoints = 63,
                    ArmorClass = 16,
                    Size = "Large",
                    CreatureType = "Giant",
                    Alignment = "Chaotic Evil",
                    Speed = "30ft.",
                    Saves = "Fort +11, Ref +4, Will +3",
                    Feats = "Alertness, Iron Will, Track",
                    ChallengeRating = 5,
                    BaseAttack = "+4",
                    Grapple = "+14",
                    FullAttack = "2 Claws: +9 melee (1d6+6) and bite: +4 melee (1d6+3)",
                    SpecialAttack = "Rend: If both claw attacks hit then Rend automatically deals an additional 2d6+9 points of damage.",
                    ImageUrl = "https://www.dndbeyond.com/avatars/thumbnails/30836/144/1000/1000/638063929586218907.png"
                },
                new Animal
                {
                    MonsterName = "Umber Hulk", //good
                    MonsterDescription = "This massive, powerfully built creature looks something like a cross between a great ape and a beetle. A large pair of mandibles and rows of triangular teeth dominate the facial features of this beast.",
                    Environment = "Underground",
                    HitPoints = 71,
                    ArmorClass = 18,
                    Size = "Large",
                    CreatureType = "Aberration",
                    Alignment = "Chaotic Evil",
                    Speed = "20ft. base/20ft. burrowing",
                    Saves = "Fort +8, Ref +3, Will +6",
                    Feats = "Great Fortitude, Multiattack, Toughness",
                    ChallengeRating = 7,
                    BaseAttack = "+6",
                    Grapple = "+16",
                    FullAttack = "2 Claws: +11 melee (2d4+6) and bite: +9 melee (2d8+3)",
                    SpecialAttack = "Confusing Gaze: Target of Confusing Gaze must succeed a Will DC 15 or become confused. 30ft. range.",
                    ImageUrl = "https://www.aidedd.org/dnd/images/umber-hulk.jpg"
                },
                new Animal
                {
                    MonsterName = "Unicorn", //good
                    MonsterDescription = "This powerful, equine creature has a gleaming white coat. Long, silky white hair hangs down in a mane. An ivory horn, about 2 feet long, grows from the center of the forehead.",
                    Environment = "Forests",
                    HitPoints = 42,
                    ArmorClass = 18,
                    Size = "Large",
                    CreatureType = "Magical Beast",
                    Alignment = "Chaotic Good",
                    Speed = "60ft.",
                    Saves = "Fort +9, Ref +7, Will +6",
                    Feats = "Alertness, Skill Focus (Survival) ",
                    ChallengeRating = 3,
                    BaseAttack = "+4",
                    Grapple = "+13",
                    FullAttack = "Horn: +11 melee (1d8+8) and 2 hooves: +3 melee (1d4+2)",
                    SpecialAttack = "Wild Empathy: This power works like the druid’s wild empathy class feature, except that a Unicorn has a +6 racial bonus on the check.",
                    ImageUrl = "https://i0.wp.com/nerdarchy.com/wp-content/uploads/2018/02/unicorn.jpeg?fit=1000%2C804&ssl=1"
                },
                new Animal
                {
                    MonsterName = "Vampire", //good
                    MonsterDescription = "This sinister-looking warrior has pale skin, haunting red eyes, and a feral cast to his features. It is said the father of Vampires resides in the darkest parts of Ravenloft.",
                    Environment = "Caves and Plains",
                    HitPoints = 32,
                    ArmorClass = 23,
                    Size = "Medium",
                    CreatureType = "Undead",
                    Alignment = "Lawful or Chaotic Evil",
                    Speed = "30ft.",
                    Saves = "Fort +4, Ref +6, Will +4",
                    Feats = "Alertness, Blind-Fight, Combat Reflexes, Dodge, Exotic Weapon Proficiency (spiked chain), Improved Initiative, Lightning Reflexes, Mobility, Power Attack",
                    ChallengeRating = 7,
                    BaseAttack = "+5",
                    Grapple = "+11",
                    FullAttack = " Slam: +11 melee (1d6+9 plus energy drain) or spiked chain: +13 melee (2d4+12)",
                    SpecialAttack = "Energy Drain: Any living creature hit by a Vampire’s slam attack gains two negative levels. For each negative level bestowed, the Vampire gains 5 temporary hit points.",
                    ImageUrl = "https://static.miraheze.org/criticalrolewiki/thumb/4/4e/Vampire.png/800px-Vampire.png"
                },
                new Animal
                {
                    MonsterName = "Wight", //good
                    MonsterDescription = "This creature resembles a human corpse. Its wild, frantic eyes burn with malevolence. Its teeth have grown into sharp, jagged needles.",
                    Environment = "Any",
                    HitPoints = 26,
                    ArmorClass = 15,
                    Size = "Medium",
                    CreatureType = "Undead",
                    Alignment = "Lawful Evil",
                    Speed = "30ft.",
                    Saves = "Fort +1, Ref +2, Will +5",
                    Feats = "Alertness, Blind-Fight",
                    ChallengeRating = 3,
                    BaseAttack = "+2",
                    Grapple = "+3",
                    FullAttack = " Slam +3 melee (1d4+1 plus energy drain)",
                    SpecialAttack = "Energy Drain: Living creatures hit by a Wight’s slam attack gain one negative level. The DC is 14 for the Fortitude save to remove a negative level.",
                    ImageUrl = "https://images.squarespace-cdn.com/content/v1/5bd88db093a6320f071b1a50/be7109ee-9199-4cd8-8535-c3030edcaff1/3e_MM_Wight_WayneReynolds.jpg?format=2500w"
                },
                new Animal
                {
                    MonsterName = "Will-O'-Wisp", //good
                    MonsterDescription = "This creature seems to be nothing but a harmless glowing sphere of light. However, that couldn't be any further from reality. These faintly lit spheres have a very sinister motive.",
                    Environment = "Dungeons and Marshes",
                    HitPoints = 40,
                    ArmorClass = 29,
                    Size = "Small",
                    CreatureType = "Aberration",
                    Alignment = "Chaotic Evil",
                    Speed = "50ft. flying",
                    Saves = "Fort +3, Ref +12, Will +9",
                    Feats = "Alertness, Blind-Fight, Dodge, Improved Initiative, Weapon Finesse",
                    ChallengeRating = 6,
                    BaseAttack = "+6",
                    Grapple = "-3",
                    FullAttack = "Shock: +16 melee touch (2d8 electricity)",
                    SpecialAttack = "Immunity to Magic: A Will-O’-Wisp is immune to most spells or spell-like abilities that allow spell resistance, except magic missile.",
                    ImageUrl = "https://www.dndbeyond.com/avatars/thumbnails/16/585/1000/1000/636376363763232290.jpeg"
                },
                new Animal
                {
                    MonsterName = "Winter Wolf", //good
                    MonsterDescription = "This creature looks like a white wolf with icy blue eyes. It stands as tall asma horse, and its breath smokes with cold.",
                    Environment = "Tundras",
                    HitPoints = 51,
                    ArmorClass = 15,
                    Size = "Large",
                    CreatureType = "Magical Beast",
                    Alignment = "Neutral Evil",
                    Speed = "50ft.",
                    Saves = "Fort +8, Ref +6, Will +3",
                    Feats = "Alertness, Improved Initiative, Track",
                    ChallengeRating = 5,
                    BaseAttack = "+6",
                    Grapple = "+14",
                    FullAttack = "Bite: +9 melee (1d8+6 plus 1d6 cold)",
                    SpecialAttack = "Breath Weapon: 15-foot cone, once every 1d4 rounds, damage 4d6 cold, Reflex DC 16 to take half damage.",
                    ImageUrl = "https://1.bp.blogspot.com/-x-ceW_wO5ng/WoMDFUa2XAI/AAAAAAAAVlM/2AmzcGefW3I8LCQhJenErhiJ1xi3-WMXACK4BGAYYCw/s1600/winterWolf.jpg"
                },
                new Animal
                {
                    MonsterName = "Wraith", //good
                    MonsterDescription = "This creature is a sinister, spectral figure robed in darkness. It has no visible features or appendages, except for the glowing red pinpoints of its eyes.",
                    Environment = "Any",
                    HitPoints = 32,
                    ArmorClass = 15,
                    Size = "Medium",
                    CreatureType = "Undead",
                    Alignment = "Lawful Evil",
                    Speed = "60ft. flying",
                    Saves = "Fort +1, Ref +4, Will +6",
                    Feats = "Alertness, Blind-Fight, Combat Reflexes, Improved Initiative",
                    ChallengeRating = 5,
                    BaseAttack = "+2",
                    Grapple = "Cannot grapple or be grappled",
                    FullAttack = "Incorporeal touch +5 melee (1d4 plus Constitution damage)",
                    SpecialAttack = "Constitution Drain: Living creatures hit by a Wraith’s incorporeal touch attack must succeed on a DC 14 Fortitude save or take 1d6 Constitution damage.",
                    ImageUrl = "https://images.squarespace-cdn.com/content/v1/5bd88db093a6320f071b1a50/1579570761145-K46SQ6IKWJTXYKO3IP0F/image-asset.png?format=2500w"
                },
                new Animal
                {
                    MonsterName = "Wyvern", //good
                    MonsterDescription = "This reptilian monstrosity has a long tail tipped with a thick knot of cartilage from which a stinger protrudes. It has leathery bat wings and huge jaws filled with bladelike teeth.",
                    Environment = "Hills",
                    HitPoints = 59,
                    ArmorClass = 18,
                    Size = "Large",
                    CreatureType = "Dragon",
                    Alignment = "Neutral",
                    Speed = "20ft. base/60ft. flying",
                    Saves = "Fort +7, Ref +6, Will +6",
                    Feats = "Ability Focus (poison), Alertness, Flyby Attack, Multiattack",
                    ChallengeRating = 6,
                    BaseAttack = "+7",
                    Grapple = "+15",
                    FullAttack = "Sting: +10 melee (1d6+4 plus poison) and bite: +8 melee (2d8+4) and 2 talons: +8 melee (2d6+4)",
                    SpecialAttack = "Poison: If the Sting attack hits, Fortitude DC 17, initial and secondary damage 2d6 Con.",
                    ImageUrl = "https://images.squarespace-cdn.com/content/v1/5bd88db093a6320f071b1a50/1631757173991-QQ5L1VRMJ4W96EJZR43S/5e_MM_Wyvern.png?format=2500w"
                },
                new Animal
                {
                    MonsterName = "Yaun-Ti", //good
                    MonsterDescription = "This creature looks like a big serpent, except that its eyes betray a baleful intelligence and it has two burly, humanoid arms.",
                    Environment = "Forests",
                    HitPoints = 67,
                    ArmorClass = 22,
                    Size = "Large",
                    CreatureType = "Monstrous Humanoid",
                    Alignment = "Chaotic Evil",
                    Speed = "30ft. base/20ft. climbing/20ft. swimming",
                    Saves = "Fort +6, Ref +7, Will +11",
                    Feats = "Alertness, Blind-Fight, Combat Expertise, Dodge, Improved Initiative, Mobility",
                    ChallengeRating = 7,
                    BaseAttack = "+9",
                    Grapple = "+17",
                    FullAttack = "Masterwork Scimitar: +13/+8 melee (1d8+4/18–20) and bite: +7 melee (2d6+3 plus poison)",
                    SpecialAttack = "Poison: If the Bite attack hits, Fortitude DC 17, initial and secondary damage 1d6 Con.",
                    ImageUrl = "https://4.bp.blogspot.com/-67AMUrK4P7E/UEYqVDG8nrI/AAAAAAAADTk/_Gw9xD9q8Qw/s1600/tumblr_m7swqs2mH91qzv4gao4_400.jpg"
                },
                new Animal
                {
                    MonsterName = "Zombie", //good
                    MonsterDescription = "Corpses reanimated through dark and sinister magic. These mindless automatons shamble about, doing their creator’s bidding without fear or hesitation.",
                    Environment = "Any",
                    HitPoints = 16,
                    ArmorClass = 11,
                    Size = "Medium",
                    CreatureType = "Undead",
                    Alignment = "Neutral Evil",
                    Speed = "30ft.",
                    Saves = "Fort +0, Ref -1, Will +3",
                    Feats = "Toughness",
                    ChallengeRating = .5,
                    BaseAttack = "+1",
                    Grapple = "+2",
                    FullAttack = "Slam: +2 melee (1d6+1) or club: +2 melee (1d6+1)",
                    SpecialAttack = "None.",
                    ImageUrl = "https://www.seekpng.com/png/detail/317-3179017_undead-png-transparent-image-dungeons-and-dragons-zombie.png"
                }
                
                // Add more montsters here in the future
            };

			foreach (var animal in animalsList)
			{
				await _animalRepo.AddAnimalAsync(animal);
			}

			return Ok("Database populated");
		}
	}
}
