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