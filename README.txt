
PACKAGE COMES WITH 3 WEAPON MODELS AND MULTIPLE OF EACH TYPE OF ATTACHMENT TO DEMONSTRATE HOW PACKAGE WORKS.

This package makes adding your own weapon models and attachments extremely easy. Simply follow the intstructions below.

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

2. You can reposition the slots at any time by moving them in the object prefab.

3. May need to edit scale of weapons to make them similar size.

4. If user you wants to add more weapon slots need to make new selection weapon function and make button on main menu

5. The canvas object that has everything attached to it needs to have the "WeaponCustomizationCanvas" tag.

6. Make sure any prefabs that you create for use have have all of their position values set to 0.

7. When saving a weapon, the prefab will save to the root "Asset" folder in your project.