# L5R mobile charactersheet
A simple character sheet for Legend of the 5 Rings RPG. Reads character data serialized as json files from a folder (downloads by default).

This project does **not** contain a character generator or game content (rules, etc). Note taking features are intentionally limited - this is intended to be used as a supplement to a more robust note taking app.

Editing a character sheet json is tedious and may be expanded in the future.

Icons can be inlined into text for distinctions and techniques. These include:

* $strife
* $opportunity
* $critical
* $none
* $success
* $air
* $earth
* $fire
* $water
* $void

## TODO
* support cherry blossom app by importing xml files
* damage/destroy equipment, damage rings
* build some external editor to create/update character data files
* consider some internal editor? personally don't want to edit big +technical text files on a phone. pastebin, gist? load character from url?
* consider experience spend tracker page (school skills/abilities, out of school spends)
* consider 'combat' page to quickly track status effects, list actions

## Version 1.0 changes
* add version number
* fix directory save sometimes not including final '/'
* aggressively save (after any text field has changed)
* add xp fields to item canvas
* larger buttons
* skills canvas centered

## Version 1.1 changes
* UX for dice
* fade skills with no levels