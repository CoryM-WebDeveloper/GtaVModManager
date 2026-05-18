# GtaVModManager

GTA V Essential Mod Manager & INTRODUCTION
=
This is a custom built mod manager for the game GTA V. To the best of my knowledge, all such mod managers are either incompatible with the newest version of GTA V, incompetent, or no longer supported. This project is to rectify shortcomings and meet a need for the community at large.

BADGES
=
Currently no status badges for build, coverage, or version from services like GitHub Actions or Codecov.

INSTALLATION & USAUGE
=
The mod manager is not currently available.

* Status: {In Development}

Once available:
To INSTALL the Mod Manager:
1. Download the GTAVEssentialModManager.exe from the downloads page.
2. Move .exe to desired directory for your modded game.
3. Run the .exe file to open the mod manager.

How to Use the Mod Manager:
* This section will be completed after the first iteration of the mod manager is complete.

FEATURES & FUNCTINALITY
=
* This mod manager will allow the user to install mods within the GTA V directory without worrying about permanently disabling an install. Instead, each mod will be loaded in when enabled and when unenabled will be removed from the game directory.
* Users will create a folder labled with whatever they are naming the mod they are installing. For example, if I'm installing the mod LSPDFR, I could label the mod folder "Police Mod", or something similar. This label is for the user's purpose within the mod manager itself.
* Within the custom labeled mod folder will be a mimiced root game directory setup. All folders and files within this mimiced root game directory will be symlinked into the root game directory when enabled. When disabled, the symlinked files will no longer appear in the root game directory.
* An alternative kill switch can disable all mods by selecting, "Prepare Game for Online Play." Once this is activated, all mods will be unenabled and no symlink folders or files will appear in the root game directory.
* All Mod folders will have an overwrite process. Whichever mod appear directly underneath a prior mod, if there are any folder or files changed by the lower mod, the lower mod will overwrite the upper mods' files. This allows for clean ordering of mods and easy troubleshooting.
* If you have a set of mods that work well together, you can also elect to combine those mods into a single mod plugin like "Essentials" or "Core" or "Visual", etc.
* The user may also further break original mods apart by pulling portions and custom labeling another folder
  * OR the user may decide to keep the original mod unchanged but only add a change later in the mod order. This is especially useful for plugin updates like the "RAGEPlugin".

TECHNOLOGY STACK
=
This program is developed in C# using dotnet 10.0.

LICENSE
=
This project is licensed under GNU GENERAL PUBLIC LICENSE Version 3. A copy of the License is provided in this project. See LICENSE for the full breakdown.

ACKNOWLEDGE & CONTACT
=
Contributors:
Cory Marth (Lead Developer)

Contact Information:
If you would like to get involved in this project or support this project in any way, you are welcome to. Additionally, if you need to report a bug, offer a fix suggestion or other recommendation, or have any other inquiry, send an email to hello@corymarth.com.

Related Projects:
Currently, there are no related projects.
