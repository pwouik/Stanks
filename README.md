# Stanks

**Stanks** est un jeu vidéo de combat de chars d’assaut en 1 contre 1, conçu pour Android. Testez vos compétences stratégiques et de visée dans un environnement immersif, où chaque tir compte. Ce projet est développé sous Unity.

---

## Table des matières

- [Description](#description)
- [Fonctionnalités](#fonctionnalités)
- [Structure du projet](#structure-du-projet)
- [Contributeurs](#contributeurs)
- [Licence](#licence)

---

## Description

Dans **Stanks**, deux joueurs s'affrontent dans une bataille intense où chaque mouvement et tir peut décider du résultat. Le jeu est optimisé pour les appareils Android et offre des graphismes captivants avec des contrôles intuitifs.

---

## Fonctionnalités

- **Multijoueur local** : Affrontez un ami en mode 1 contre 1.
- **Contrôles tactiles** : Utilisation d'un joystick virtuel pour le mouvement et un bouton de tir.
- **Environnement dynamique** : Des biomes variés comme de la neige, du sable ou de l’herbe.
- **Effets visuels immersifs** : Particules d’explosion, fumée, et matériaux réalistes.

---

## Structure du projet

Voici une vue d’ensemble des principaux dossiers et fichiers du projet :

### Matériaux

Les matériaux pour les terrains et objets du jeu sont disponibles dans le dossier [`Assets/Materials`](Assets/Materials). Voici quelques exemples :
- [`Cobblestone.mat`](Assets/Materials/Cobblestone.mat) : Couche inférieure du sol.
- [`Water/Water.mat`](Assets/Materials/Water/Water.mat) : Surfaces aquatiques.
- [`Snow/Snow.mat`](Assets/Materials/Snow/Snow.mat) : Neige.

### Préfabriqués

Les objets réutilisables sont stockés dans [`Assets/prefab`](Assets/prefab) :
- [`Attack.prefab`](Assets/prefab/Attack.prefab) : Préfabriqué pour l'attaque des tanks.
- [`Explosion.prefab`](Assets/prefab/Explosion.prefab) : Préfabriqué pour les explosions.
- [`Joystick.prefab`](Assets/prefab/Joystick.prefab) : Préfabriqué pour les contrôles tactiles.

### Scènes

Les différentes cartes et environnements sont stockés dans [`Assets/Scenes`](Assets/Scenes) :
- [`alexis.unity`](Assets/Scenes/alexis.unity) : Scène principale.

### Scripts

Les comportements du jeu sont gérés par les scripts dans [`Assets/Scripts`](Assets/Scripts) :
- [`FollowerCamera.cs`](Assets/Scripts/FollowerCamera.cs) : Gère la caméra dynamique qui suit les tanks.
- [`TankController.cs`](Assets/Scripts/TankController.cs) : Script principal pour le contrôle des tanks.
- [`StickController.cs`](Assets/Scripts/StickController.cs) : Gère les mouvements du joystick.

---

## Contributeurs

- **Alexis** : Développeur.
- **Bolamigo** : Développeur.
- **Pwouik** : Développeur.

---

## Licence

TODO

---

## Aperçu

Des captures d’écran et vidéos seront ajoutées prochainement !

---