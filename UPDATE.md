###### en cours
- blockcontent est maintenant utilisation comme module a part entiere ce qui permet de le mettre sur une page sans donner les droits d'administration
- correction des styles sur l'affichage des nouvelles  
- correction bug sur la programmation des réunions periodiques, quand on changeait l'heure d'une réunion générée elle était regénérée des 10aines de fois
- l'import des membres RI au niveau district n'affecte plus les données des membres existants (sauf pour le changement de club) et ne sert plus qu'a ajouter ou supprimer les membres avant l'appel de cotisation de district
- correction pb de droits sur module pied de page du site de club
- le redirecteur de site web de club de l'espace membre redirige aussi si on est en mode carte de visite de club
- la carte visite de club dispose maintenant d'un design horizontal
- changement d'ordre d'affichage du nom du membre dans le module d'affectation du club, le nom est en premier et trié par nom ascendant


###### 01/03/2023
- les adg peuvent de nouveau gérer les nouvelles des clubs de leur groupe
- correction d'un style dans le popup contact membre
- nouveau script administrateur pour voir les clubs qui n'ont pas de fonctionnalité Documents
- dans la gestion des clubs district on peut voir des informations complémentaires dans la liste (Type, Role de groupe et présentation : carte de visite, site ou site avec domaine)
- correction d'un bug dans la gestion des fanions
- correction bug module "ais news liste" 
- modification libellé de visibilité dans l'admin des news : de Rotariens à Membres du district
- amélioration du processus d'import et saisie membres dans les clubs 
	- quand on change l'email d'un membre ca ne recrée plus un utilisateur il peut continuer a utiliser le meme mot de passe
	- mes administrateurs district et webmaster peuvent maintenant modifier localement toutes les données membres afin de pouvoir aider un membre dans la saisie des données ou le changement de mail (exemple un membre a bien changé son mail sur le RI et veut le changer tout de suite pour accéder au district mais son responsable club ne peut pas le faire immédiatement, l'admin district peut alors l'aider)
	- les explications sont plus explicites
	- la civilité et la date d'admission sont redevenues modifiables localement

Nouveaux modules : 
- Admin Membre Page Pro : ce module permet à un membre de créer et modifier sa page professionnelle, il permet aussi de définir si on affiche ou pas la page afin de pouvoir la préparer tranquillement avant de la rendre visible

MAJ BDD : ALTER TABLE ais_members ADD presentation CHAR(1) NULL 

- PDF Flipbook : qui permet d'afficher un fichier pdf sous forme de magazine a feuilleter


###### 13/02/2023
- correction d'un pb d'envoi d'email avec le formulaire de contact membre vers google
- remplacement du libellé nom d'utilisateur par email pour l'ecran d'identification et de réinitialisation du mot de passe afin d'éviter toute ambiguité, le texte de réinitialisation indique plus clairement qu'il s'agit de l'email déclaré au niveau du RI
- ajout du sous titre logo dans l'entete du club (Exemple : district 1640 Normandie)
- ajout de l'affichage de l'image d'accroche pour une nouvelle club quand il n'y a pas de contenu détaillé
- ajout de l'option (image en dessous du texte) dans l'editeur blockcontent
- ajout de la possibilité de modifier le type de club dans l'admin des clubs district
- correction des urls de clubs sans accent (exemple : alençon)
- correction sur site de club avec nom de domaine
	- Pb de bouton connexion qui ne restait pas sur le site
	- Pb de redirection des popup d'édition de contenu
	- Pb de chargement de l'editeur html dans les popup
	- Pb des liens vers espace membre
- création d'un nouveau module de gestion des membres pour prendre en compte la nouvelle méthode :
	- Nous ne pourrons plus ajouter ou supprimer des membres sur le district
	- Seule la modification des données membres ne venant pas du RI (photo, classification, page personnelle pro, etc.) seront modifiable sur le district
	- Le bouton ajouter un membre dans la rubrique mon club / gestion / membres conduira a une page d’explications qui indiquera comment aller ajouter un membre sur le RI puis comment mettre a jour les membre du district a partir d’un export excel du RI
	- Le terme « importer les membres » va être remplacé par « mettre a jour les membres » afin d’éviter toute confusion
	- La page de modification des données des membres, est scindée en deux avec une partie les infos non modifiables venant du RI (comme l’email, le tel, l’adresse, le n°nim) et un texte d’explication indiquera qu’il faut modifier le RI puis demander a un responsable du club d’appliquer la mise a jour a partir du fichier venant du RI
	- L’autre partie de l’écran de modification d’un membre continue de fonctionner comme avant
- modification de l'import RI au niveau du district (l'adresse locale du membre n'est plus affectée par l'import RI)
- possibilité de personnaliser les catégories de nouvelles clubs et districts par le panneau de paramètres
- remise en place de la spécificité du D1770 sur l'import des membres RI
- modification module visualisation de réunion
	- ajout d'un bouton d'export excel des participants
	- visualisation sur fond grisé des membres ayant répondu non présent
- correction d'un pb d'affichage du fanion club lors du changement de l'image
- uniformisation style bandeau droit nos actions dans page des clubs avec l'affichage des actions des clubs dans le district


###### 11/01/2023
- remise en place d'une temporisation sur les menus pour plus de confort d'utilisation
- correction bug bloc html dans blockcontent 
- améliorations sur les thèmes graphiques public, club et membres 
- ajout de la possibilité de mettre un titre district ainsi qu'un texte a droite du logo district
- correction du pb d'envoi de mail par le popup membre quand on utilise mailjet

###### 11/12/2022
- le controller de nouvelles permet de gérer d'autres modes que district et clubs, ce qui permet de faire des visualisations et administrations de nouvelles personnalisées par District (exemple la minute rotarienne).

###### 07/12/2022
- changement de comportement pour les nouvelles club et district, maintenant quand on publie une nouvelle dans contenu détaillé, c'est l'image d'accroche qui est affichée dans le détail de la nouvelle (comme avec l'ancien module de nouvelles en fait), ce qui permet de mettre 2 fois la meme image si on a pas de contenu détaillé

###### 06/12/2022

- mise a jour de DNN version 9.9.1 -> 9.10.2
- preparation suppression d'anciennes dépendences (ex: Telerik)
- séparation de la tache plannifiée de génération des réunions auto et de l'envoi des notifications :
o MeetingScheduler	ne gere plus que la programmation des réunions auto
o MeetingNotifications	nouvelle tache programmable pour l'envoi des notifications aux membres (va être interfacée avec le système de notifications prochainement), tient compte du nouveau paramètre NOTIFICATIONS_DEBUG_DEST qui permet de spécifier un mail de bypass pour tester les notifs
- le texte de notification de réunion a été complété d'un lien partageable à un tiers 
- les notifications ne se font plus pour des réunions inactives 
- la gestion des notifications de réunion à changé et permet maintenant de différer une notification et de choisir les destinataires (membre satellite ou pas)
- on peut maintenant désactiver la génération automatique de réunion périodiques, les notifications auto des notifications périodiques ont été supprimées
- l'écran de saisie de réunion a été réorganisé pour plus de clarté
- les administrateurs de clubs peuvent maintenant inscrire et désinscrires des participants aux réunions
- on peut imprimer la liste des participants à une réunion
- l'impression du trombinoscope n'ouvre plus de fenetre
- retrait de la temporisation dans les menus déroulants


###### 02/11/2022

- on peut maintenant spécifier manuellement si un membre est dans un club satellite ou pas
- dans la liste des membres un icone apparait sur chaque membre faisant partie d'un club satellite
- modification taille des titres (ex: nom du district a coté du logo)
- la mention mini a été retirée de la rubrique mini site dans la gestion des clubs, car il ne s'agit plus de mini sites mais de sites complets pour les clubs hébergés par le district
- dans l'affichage des réunions, le nom apparait maintenant avant le prénom
- les administrateurs et administrateurs district peuvent maintenant gérer les nouvelles des clubs


###### 31/10/2022

Mise a jour module billetterie district :
- Certains libellés ont été changés pour éviter les confusions : début et fin d’ouverture, validation au lieu de paiement
- Quand l’inscription est gratuite le reçu n’est plus visible
- Les informations sont automatiquement saisies avec le profil de l’utilisateur actuellement identifié afin de faciliter l’inscription
- Le rôle lecture seule fonctionnement maintenant comme prévu : export des commandes et inscrits sans possibilité de modifier les paramètres de la billetterie
- Panneau de paramétrage de la billetterie
o Correction d’un pb de valeurs initiales quand on ajoute le module
o Des listes déroulantes permettent de choisir les rôles admin et lecture seule 
o Les url billetterie, ticket et reçu se remplissent automatiquement


###### 23/10/2022

- modification de la liste des rôles rotariens pour l'administration des clubs, chaque district peut maintenant définir quels rôles sont des admins de clubs, avant la liste était commune aux districts (par exemple le protocole peut maintenant organiser les réunions)

- modification du module d'administration des appels de cotisations district, renommage des libellés pour être plus conforme aux usages



###### 17/10/2022

- modification des libellés dans l'édition de réunion
- active signifie inscription active
- ajout d'une désactivation automatique de l'inscription quand la date de fin est passée
- ajout d'un bouton de notification pour le cas ou la notification automatique n'est pas activée
- une nouvelle réunion est positionné sur ne pas notifier automatiquement 
- ajout de la mise à jour automatique de l'heure +1 pour l'heure de fin dans la gestion des périodes
- la visu publique de la réunion a été modifiée afin de laisser apparaitre la réunion meme si l'inscription n'est plus active

###### 04/10/2022

- correction pb d'affichage en tete espace membre sur mobile suite a modification des informations affichées
- correction du positionnement du menu en version mobile quand la barre d'admin dnn est affichée

###### 03/10/2022

- ajout d'informations complémentaires dans l'export excel des factures district

###### 23/09/2022

- mise à jour des modules de visu des nouvelles club et district pour supporter le nouveau format de nouvelles
- modification de l'éditeur de blocks qui ne met plus de titre par défaut ('image & texte', etc.) car les utilisateurs ne pensaient pas forcément a remplacer le texte par un vrai titre

###### 12/09/2022

- correction pb de changement ordre des affectations dans l'organigrame district et augmentation de la zone de fonction
- modification importation des affectations rotarienne du RI (secretaire executif -> administration)

###### 11/09/2022

- modification de l'url du service blockcontent
- ajout d'une fonctionnalité de conversion des nouvelles de l'ancien vers le nouveau format

###### 10/09/2022

- modification du module de sélection de club pour les ADG, maintenant quand un ADG n'est pas dans le groupe de club qu'il gère le nom de son club apparait dans la liste de sélection

###### 22/08/2022

- correction selection de l'action par défaut du site de club (rubrique nos actions)

###### 17/08/2022

- ajout du nom du club dans le titre des pages des sites de clubs

###### 16/08/2022

- ajout d'un provider qui ajoute les urls des clubs dans le sitemap du site

###### 10/08/2022

- modification du module d'affectation des rôles rotariens, maintenant seuls les présidents, secrétaire et adjoints, webmaster et adjoints obtiennent les droits d'administrer les données du club, publier des informations et gérer le site du club

###### 01/08/2022

- suite au changement de gestion des url pour un meilleur référencement (plus d'accents dans les url) le module de création de lettre du gouverneur buggait sur les mois avec accent, pb corrigé

###### 30/07/2022

- ajout d'informations sur la modification d'une fiche membre, notamment sur les champs affectés lors de la synchronisation avec le RI


###### 29/07/2022

- ajout de la possibilité d'imprimer le trombinoscope club 
	il faut créer une page print a la racine et insérer le script razor print.cshtml
- lorsqu'un adg se loggue, son club est automatiquement sélectionné
- ajout de la possibilité d'indiquer qu'on est absent a une réunion