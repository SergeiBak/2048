# 2048
<img width="276.48" height="155.52" src="https://github.com/SergeiBak/PersonalWebsite/blob/master/images/2048.png?raw=true">

## Table of Contents
* [Overview](#Overview)
* [Test The Project!](#test-the-project)
* [Code](#Code)
* [Technologies](#Technologies)
* [Resources](#Resources)
* [Donations](#Donations)

## Overview
This project is a recreation of a certain childhood game I used to play on Cool Math Games called 2048. This solo project was developed in Unity using C# as part of my minigames series where I utilize various resources to remake simple games in order to further my learning as well as to have fun!

2048 consists of a 4x4 grid, in which you can move all of the blocks on the grid in one direction using keyboard input. Combine blocks to increase your score! If you run out of space on the grid you lose.

## Test The Project!
In order to play this version of 2048, follow the [link](https://sergeibak.github.io/PersonalWebsite/2048.html) to a in-browser WebGL build (No download required!).

## Code
A brief description of all of the classes is as follows:
- The ```Cell``` class is the slots in the board. They are not the tiles themselves. Since the cells never move, this class is used for much of the tile movement logic.
- The ```Fill``` class involves the tiles themselves that move around the board. The logic for doubling the block value as well as displayed value and color is handled here.
- The ```GameController``` class is used in the game scene itself for user input and tracking the game state, as well as to keep track of and update high scores for player stats. 
- The ```MenuController``` class is used in the menu scene for transitioning between various panels, loading player stats, and transitioning to the game scene.

## Technologies
- Unity
- Visual Studio
- GitHub
- GitHub Desktop

## Resources
- Credit goes to [Info Gamer](https://www.youtube.com/channel/UCyoayn_uVt2I55ZCUuBVRcQ/playlists) for the helpful base game tutorial!
- For the saving stats system, I made use of playprefs, here is some [helpful scripting documentation](https://docs.unity3d.com/ScriptReference/PlayerPrefs.html) on how that works!

## Donations
This game, like many of the others I have worked on, is completely free and made for fun and learning! If you would like to support what I do, you can donate at my metamask wallet address: ```0x32d04487a141277Bb100F4b6AdAfbFED38810F40```. Thank you very much!
