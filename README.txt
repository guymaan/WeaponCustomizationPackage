
PACKAGE COMES WITH 3 WEAPON MODELS AND MULTIPLE OF EACH TYPE OF ATTACHMENT TO DEMONSTRATE HOW PACKAGE WORKS.

This package can either be installed via the "Add package from disk" or the "Add package from Git URL" in the Unity Package Manager screen.

Git URL: https://github.com/guymaan/WeaponCustomizationPackage.git

This package makes adding your own weapon models and attachments easy. Simply follow the intstructions below.

---- Adding new weapons

1. User must add their weapon to scene.

2. Create empty GameObject and parent the weapon model to it.

3. Equip parent object with "Weapon" tag in inspector.

4. Equip parent with empty gameobjects, these are the slots for each attachment the weapon will have.

5. Move slots to desired locations in the weapon - where you want each attachment to be.

6. Equip each slot with the related tag - for example, the slot for barrel attachments, equip "BarrelSlot" tag.

7. Add "WeaponScript" script to the parent.

8. Tick each option for the slots that the weapon has in inspector.

9. Enter number of attachments slots the weapon has - Drag attachment slot gameobjects into the "Attachment Slots" section in inspector.

10. Make a prefab of the parent with everything attached to it.

11. On "PackageManager" gameobject, drag weapon prefab into one of the "Canvas Controller" scripts weapon slots.

---- Adding new attachments

1. Add attachment model to scene and add the "AttachmentScript" script.

2. Drag attachment into relevant attatchment folder to make it a prefab - for example, a supressor attachment will go in the "BarrelAttachments" folder.

---- Notes

1. To resize attachments for different weapons, simply change the size of the "AttachmentSlot" gameobject on each prefab.

2. Attachment slots can be repositioned at any time by moving them in the object prefab.

3. User may need to edit scale of weapons to make them similar size.

4. Once package is installed, as the user will not be able to open the downloaded scene. They simply need to move it into their projects "Scenes" folder.

5. The user must have some form of Git software installed as is the norm for any packages installed when using Git. - Here is a suitable version to useL https://git-scm.com/download/win

6. If user wants to add more weapons to choose from need to make new weapon selection function as well as new buttons on main menu. - The current weapon selection functions can simply be copy/pasted with minor editing in order to work.

