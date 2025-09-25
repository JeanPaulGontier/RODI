###### en cours, sera installé lors d'une prochaine MAJ
- nouveau : possibilité de créer des listes de contacts externes (optin & optout) pour les mailings et notifications de réunions (exemple : abonnés newsletter du clubs, prospects du clubs, etc.) avec utilisation de plateforme de mass mailing du club (brevo, mailjet, mail personnel du club)
- nouveau type de bloc permettant d'épingler une nouvelle district ou club
- nouveau : module d'affichage des messages pour les membres (club, autres clubs et district) (D1680)
- fonctionnalité permettant de récupérer les informations du club venant de my rotary à la demande (lieu de réunion, siège social, ...) (D1680 D1640)
- rendre accessible les paramètres cachés des réunions (limite nb inscrits, visibilité, etc.) (D1680)
- gestion des contrats jeunes rotariens (D1700)
- déplacement du sélecteur de club en en-tete de l'espace membre (D1680)
- fonctionnalité permettant de définir des champs/questions supplémentaire pour l'inscription aux réunions (D1680)
- ajouter une fonctionnalité pour exporter toutes factures du district dans un seul fichier ZIP par appel de cotisation (D1680 D1730)
- ajout d'informations complémentaires sur les statistiques clubs (D1760)
- nouvelle version de l'app mobile (gestion des notifications)
- choix du gabarit de mailing (message simple ou newsletter format RI) (D1680,D1790)
- fonctionnalité de récupération instantanée de l'historique des membres du club venant de my rotary pour les administrateurs du club (D1680)
- nouveau : tableau de bord club
- nouveau : module d'affichage des nouvelles (public / membres) sous forme d'agenda
- nouveau : module d'affichage de détail nouvelle avec fonction suivant / précédent
- nouvelle version du block nouvelles incorporant les nouvelles RI et la possibilité d'en voir plus que 3 (bouton en voir plus qui redirige vers la liste complète format agenda)
- ajout d'une fonctionnalité permettant aux clubs de définir qui a le droit d'administrer le club (bypass des règles standards) (D1680)
- ajout de l'anniversaire dans le trombinoscope (D1730)
- mettre a disposition de l'administration district la liste des membres terminés avec la raison maj tous les mois (D1770)
- champ date de fin d'inscription dans mail réunion
- ajouter un texte d'explication pour rappeler que les notifications ne sont pas envoyées aux membres déjà inscrits
- rendre visible les réunions passées pour les membres (D1680)
- ajout page de statistiques de connexion membres pour les administrateurs clubs (D1680 D1640)
- gestion des notifications dans l'espace membre

- dans le module form inscription MSPLA Nancy, le comité MSPLA peut maintenant exporter la liste des participants
  on peut aussi quand on est administrateur effacer tous les participants (D1790)
- correction d'un pb de lien autre que youtube dans le bloc de type vidéo (D1790)
- correction du pb de sauvegarde des blocs dans la page de présentation professionnelle d'un membre (D1700)
- ajout d'un bouton valider lors de la modification des informations professionnelles dans mon profil pour éviter les changements non sollicités (D1700)
- nouveau module pour exporter la fiche de renseignement du club pour la préparation de la visite du gouverneur (D1640)
- nouveau process (rpm) qui permet de réaffecter les photos de tous les membres après transfert depuis my rotary

###### 04/08/2025
- dans les paramètres de la compta club on peut maintenant personnaliser les lignes de facturation de cotisation
- suppression de la fonctionnalité d'export détaillé des membres clubs (conformité RGPD et Rotary International)
- correction d'un pb de création de dossier documents des clubs
- le module de stats des clubs affiche une information si un dossier club n'existe pas
- correction pb d'affichage anniversaire pour les années bissextiles, une personne née le 29 février verra son anniversaire le 28 février pour les années non bissextiles
- pour éviter toute confusion avec l'année de naissance, la date d'anniversaire n'affiche que le jour et le mois

###### 02/07/2025
- gestion de règles avancées pour la facturation district (D1680)
- changement de formalisme de n° de facture district maintenant le n° commence par 2 chiffres de l'année suivi de 4 chiffres
- ajout spécificité de facturation district D1680

###### 01/07/2025
- compta club v1
- ajout d'un lien pour ajouter une réunion au calendrier (format ical)

###### 23/06/2025 
- correction bug de sauvegarde du blockcontentclub apparu depuis maj du 18/06

###### 18/06/2025
- ajout d'un module razor de création de qr code (QRCodeGenerator) https://rodi.link reste toujours disponible
- correction de styles divers
- suppression de la date de naissance et de l'age dans la fiche membre (accessible uniquement aux admins du club) mais affichage de l'anniversaire à la place
- le texte expliquant la mise à jour des membres a été modifié pour plus de clarté
- dans le pop up contact de l'annuaire suppression des adresses postales, inutiles pour contacter le membre
- ajout d'un bouton supprimer le fanion dans les paramètres club et gestion clubs admin district
- suppression du module commité du club dans la page d'accueil du site de club, afin de laisser le choix au club d'afficher l'information ou pas
- le module d'affichage mailing district et archive mailing club affiche maintenant directement le message au lieu de l'éditeur pour que les liens fonctionnent
- l'annuaire de l'app mobile n'est plus accessible si on n'est pas loggué (préparation de l'arrivée de la nouvelle version pour tous les districts)
- ajout d'un lien espace membre dans l'entete de site de club pour permettre aux membres de trouver directement l'espace membre (simplifie l'usage quand un club possède un nom de domaine)
- on peut maintenant masquer le module de liste de nouvelles quand il n'y a pas de nouvelles afin d'éviter d'afficher un élément vide
- correction d'un bug de sauvegarde du blockcontent (ne concerne pas les nouvelles, mailings et réunions qui utilisent aussi blockcontent mais dont la sauvegarde est dépendante de la validation), dans certains cas les changements n'étaient pas bien sauvegardés, le popup d'enregistrement vert apparait en haut a droite de l'écran en cas d'erreur il est rouge
- correction d'un bug d'affichage sur le nouveau thème graphique en version mobile Rodi2025, notamment dans l'écran de connexion à l'espace membre
- nouveau gabarit de thème Rodi2025/Membres, qui permet d'utiliser la version complète du blockcontent y compris dans l'espace membre



###### 12/05/2025
- réaffectation de l'utilisateur de connexion aux membres d'honneurs, afin qu'ils puissent continuer à accéder aux informations du club
- correction de styles sur le nouveau thème graphique 2025
- correction d'un bug d'affichage dans l'annuaire professionnel
- quand un membre choisi d'apparaitre dans l'espace professionnel et qu'il n'a pas créé de page de présentation, alors le module page de présentation disparait au lieu d'afficher 'le membre n'a pas créé de page de présentation'
- correction d'un pb d'enregistrement occasionnel du BlockContent, avec affichage d'un toast indiquant 'enregistré'
- on peut maintenant saisir les coordonnées gps du club dans l'écran de paramètres du club
- dans l'administration des cotisations de district, modification des textes d'aide pour plus de clarté, le tri par (payé) fonctionne correctement
- préparation déploiement compta club (en accès anticipé pour le groupe 'Commission Compta Club')
- ajout d'un bouton ouvrant la vidéo d'explication dans l'écran de connexion

###### 18/04/2025
- ajustement des styles blockcontent pour une meilleure compatibilité avec l'existant
###### 15/04/2025
- ajout d'un nouveau Rôle "Formateur Clubs" qui permet aux utilisateurs qu'on y ajoute d'administrer tous les clubs dans le but de les former, sans avoir besoin d'être Administrateur District
	Attention : il faut ajouter le rôle dans le module sélecteur de club pour qu'il apparaisse aux utilisateurs concernés
- ajout d'un module de statistiques d'usage des clubs
- changement de fonctionnement sur la sélection de club quand on est ADG, Formateur Club ou Administration district, quand un de ces utilisateurs se connecte, son club est automatiquement sélectionné pour que la rubrique mon club pointe vers le bon club.
	- correction bug apparu depuis la maj 23/03/2025 sur le mailing district, qui ne sélectionnait pas correctement les destinataires, le pb était lié au changement de fonctionnement de sélection de club.
- création de gabarits de compatibilité 2017 > 2025 pour permettre la transistion entre l'ancien thème et le nouveau
- le bloc liste de photos dispose maintenant d'une fonctionnalité de zoom plein écran sur la photo
- le bloc photo & texte contient maintenant plus de fonctionnalités et permet plus de variétés de mise en page (espace public et membre du district)

- l'année rotarienne sélectionnée dans l'organigramme district est conservée entre les différentes pages

- modification du nommage des photos des membres, avant il était composé du prénom + nom.jpg, maintenant il est un numéro de série basé sur le nim, prenom & nom afin d'éviter les conflits en cas d'homonymes dans le district
- un nouveau module razor : _CorrectionPhotoMembres.cshtml permet de convertir les photos des membres vers le nouveau format


- correction d'un bug d'affichage de l'état de la synchronisation Rotary>District dans l'écran membres des clubs qui affichait une information erronée quand le club n'avait pas encore autorisé RODI Association
sur myRotary

###### 23/03/2025
- ajout de fonctionnalités sur le module réunions clubs
	- on peut maintenant filtrer les réunions sur le critère 'prochaines' ou 'passées'
	- les paramètres de la liste de réunions (type et prochaines/passées) est conservé quand on rentre dans une réunion et qu'on revient sur la liste 
	- les membres du clubs ne voient maintenant que les réunions futures dont l'inscription est active
- correction bug de partage réseaux sociaux sur visualisation nouvelles clubs et district
- ajout d'une sécurité pour empécher la double exécution des traitements liés à la synchro RI > RODI, dans certains cas il pouvait apparaitre 2 fois les membres d'honneurs dans un club
- Ajout d'un nouveau thème graphique pour l'espace public du district Rodi2025
	- Le nouveau thème graphique ajoute de le concept de rédacteur de contenu, car un membre n'ayant pas un profil technique peut maintenant saisir du contenu facilement avec une mise en forme préparamétrée par des Graphistes
	- De nouveaux blocs sont maintenant disponible sur ce thème (Banner, Infos, NewsCards, Bulles, Cards, Boutons)
	- Le blockcontent est maintenant évolutif
- changement de comportement sur le mailing district
	- maintenant c'est le nom et l'email de l'utilisateur connecté qui est rempli automatiquement, afin de permettre aux destinataires de faire un reply to sur l'expéditeur et non vers le district
	- une signature automatique avec le logo du district est automatiquement ajoutée (elle peut être effacée ou remplacée) afin de permettre à l'utilisateur de ne pas oublier de mettre au moins une image et un lien pour le tracking de délivrabilité et suivi statistique des mailings

###### 22/02/2025
- correction de fausse erreur affichée sur la page d'inscription à une réunion
- modification du comportement des modules news detail club et district, maintenant ils n'affichent plus que les nouvelles visibles mais aussi celles pour les membres du club sinon il redirige vers le login
- modification dans la gestion des blocks listes images et fichiers, on peut maintenant envoyer plusieurs images et fichiers d'un coup en en sélectionnant plusieurs. On peut aussi changer l'ordre des fichiers et images. Cette modification est appliquée dans tous les modules qui utilisent le bloc content : nouvelles, mailing, etc.
- ajout d'une fonctionnalité de correction d'orientation automatique dans l'ajout de photo sur le blockcontent, exemple : photo prise a l'iphone qui pouvaient être à l'envers ou inclinée
- ajout d'une sécurité lors de la synchro des données RI qui empeche l'effacement des membres si le RI est en erreur
- correction d'un pb dans le module Admin maj aar, quand le login d'un membre était dans la corbeille, il n'était pas restauré donc l'utilisateur ne pouvait pas se logger à l'espace membre
- correction bug synchro date de naissance RI > RODI dans certains cas la date de naissance ne se synchronisait pas
- correction bug synchro quand un membre était dans un rotaract et dans un rotary club, maintenant le club prioritaire est bien le rotary club, il faut mettre le membre en membre d'honneur dans le rotaract pour qu'il y apparaisse
- simplification des logs de la synchro RI, on affiche seulement les erreurs au lieu d'afficher tout ce qui s'est bien passé

Nouveau paramètre global :
<add key="RotarySynchroLog" value="true" /> active les logs de synchro
<add key="RotarySynchroLogEmail" value=".@." /> email de la personne qui surveille les erreurs de synchro necessite que les logs soient activés

<add key="RotarySynchroFullLog" value="true"/>  active le détail complet des logs de synchro

###### 17/01/2025
- correction d'un pb qui mettait fin de la synchro quand un club n'existe plus dans myrotary
- correction d'un pb de doublons de membres d'honneurs pendant la synchro
- le module news visu sélectionne automatiquement la 1ere news si aucune n'est sélectionnée
- ajout du n° cric du club dans les factures PDF 
- les nouveaux membres ainsi que les membres d'honneurs ne sont plus visible par défaut dans l'annuaire public
- un texte d'explication pour le message de notification a été ajouté dans l'écran de réunion
- un texte RGPD a été ajouté sur l'export des données membres
- nouveau service RotaryScheduler (puu) qui purge les anciens logins inutilisés et résout le pb des membres qui se connectaient encore avec un ancien login et ne voyaient plus leurs clubs, attention, c'est l'email principal du rotary.org qui est utilisé comme login membre dans rodi
###### 17/12/2024
- nouveau module Form Inscription
- lors de la synchro RI des membres d'honneurs, si une photo existait quand le membre était actif alors elle est affichée
- correction de l'affectation des fonctions lors de la synchro, quand un membre changeait de fonction en court d'année il y avait un pb
- les rotaracts peuvent maintenant éditer les cartes de membres avec la charte graphique rotaract (logo + couleurs)
- l'email pro est de nouveau editable dans RODI car on en peut pas le récupérer du RI
- nouveau module qui permet de visualiser la liste des nouveaux membres sur le dernier mois 
	/espace-membre/administration-district/gestion/nouveaux-entrants
- ajout des options de partages réseaux sociaux sur la page détail nouvelle district
- on peut maintenant limiter le nb d'élément à afficher dans l'agenda du gouverneur
- ajout de la possibilité de trier les colonnes dans l'écran suivi cerfa et dans l'écran bénéficiaire
- l'import de fichier RI manuel n'est plus nécessaire pour les années n+1 et se fait lors de la synchro RI
- ajout de nouveaux champs pour l'email d'appel de cotisation district : 
	- #id# pour le n° de facture
	- #cric# pour le cric du club
	- #montant# pour le montant a payer

MAJ BDD : 

CREATE TABLE [dbo].[ais_form_inscription](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Nom] [nvarchar](255) NULL,
	[Prenom] [nvarchar](255) NULL,
	[Mail] [nvarchar](255) NULL,
	[Telephone] [nvarchar](255) NULL,
	[Club] [nvarchar](255) NULL,
	[Creneaux] [nvarchar](255) NULL,
	[DtLastUpdate] [datetime] NULL,
	[ModuleId] [int] NULL,
	[PortalId] [int] NULL,
 CONSTRAINT [PK_ais_form_inscription] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


###### 25/11/2024
- le panneau de gestion des membres du club tient compte des nouveautés concernant la synchro RI
- correction bug génération qrcode dans les nouvelles
- nouveaux paramètres admin club district synchronisation RI > RODI
	- non : pas de synchro même si le club a autorisé RODI sur my Rotary
	- analyse : montre les changements sans mettre à jour les données du club (membres & commités)
	- auto : mets à jour les données du clubs reçues du RI
	

Nouveaux services :
- RotaryScheduler (clubs)	1J 5J logs : synchronisation des clubs RI > RODI
- RotaryScheduler (officers) 1J 5J logs : synchronisation des clubs Officers RI > RODI
- RotaryScheduler (members) 1J 5J logs : synchronisation des membres des clubs RI > RODI
utiliser RotaryScheduler (clubs,members,officers) dans une même tâche plannifiée

- RotaryScheduler (ucm) 1J 5J logs : Update Clubs Members (mise à jour des données membres rapide : ajout, modif & suppressions)
- RotaryScheduler (uco) 1J 5J logs : Update Clubs Officers (mise à jour des commités des clubs)
- RotaryScheduler (ump) 1J 5J logs: Update Members Profiles (mise à jour des profils complets des membres : adresses, mails, téléphones)
- RotaryScheduler (couu) 1H 1J logs: Create or Update Users
- RotaryScheduler (mac) 1H 1J logs: Mise à jour des affectations clubs


Nouveau paramètre global :
<add key="RotarySynchroAllowUpdate" value="true"/>  active ou pas la mise à jour des données de synchro de manière globale

###### 19/11/2024
- correction pb de sélection destinataire mailing district par rôles pour les utilisateurs non membres
- ajout possibilité de tri sur les entêtes de colonnes dans l'écran suivi des factures clubs
- modification du skin club, ce qui permet de supprimer le module bureau de la page d'accueil du club
- dans l'administration club on peut maintenant autoriser la synchro RI
- l'écran de synchro RI contient de nouvelles fonctionnalités  
- le moteur de synchronisation des membres et des roles est maintenant fonctionnel et peut être activé si tous les clubs ont autorisé RODI Association comme prestataire de gestion des clubs au niveau de my Rotary
- les membres d'honneurs des clubs récupérés du RI seront géré séparément et ne seront plus modifiables dans le district, ce qui permettra d'avoir un membre dans un club et le même membre d'honneur d'un autre club


MAJ BDD :

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ais_ri_club_member]') AND type in (N'U'))
DROP TABLE [dbo].[ais_ri_club_member]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ri_club]') AND type in (N'U'))
DROP TABLE [dbo].[ri_club]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ri_member]') AND type in (N'U'))
DROP TABLE [dbo].[ri_member]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ri_officer]') AND type in (N'U'))
DROP TABLE [dbo].[ri_officer]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ais_ri_club]') AND type in (N'U'))
DROP TABLE [dbo].[ais_ri_club]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ais_ri_member]') AND type in (N'U'))
DROP TABLE [dbo].[ais_ri_member]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ais_ri_officer]') AND type in (N'U'))
DROP TABLE [dbo].[ais_ri_officer]
GO

CREATE TABLE [dbo].[ais_ri_club](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ClubId] [int] NULL,
	[ClubType] [nvarchar](50) NULL,
	[ClubSubType] [nvarchar](50) NULL,
	[ClubName] [nvarchar](255) NULL,
	[ClubCountry] [nvarchar](50) NULL,
	[DistrictId] [int] NULL,
	[MemberCount] [int] NULL,
	[HonoraryMemberCount] [int] NULL,
	[DtLastUpdate] [datetime] NULL,
 CONSTRAINT [PK_ri_club] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ais_ri_member](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[MemberId] [int] NULL,
	[MemberType] [nvarchar](50) NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Suffix] [nvarchar](50) NULL,
	[IsHonoraryMember] [bit] NULL,
	[IsSatelliteMember] [bit] NULL,
	[DtLastUpdate] [datetime] NULL,
	[Profile] [ntext] NULL,
	[ClubId] [int] NULL
 CONSTRAINT [PK_ri_member] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[ais_ri_officer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[MemberId] [int] NULL,
	[ClubId] [int] NULL,
	[OfficerRole] [nvarchar](50) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[ClubName] [nvarchar](255) NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[MiddleName] [nvarchar](50) NULL,
	[Suffix] [nvarchar](50) NULL,
	[key] [nvarchar](50) NULL,
	[LastUpdated] [datetime] NULL,
	[DtLastUpdate] [datetime] NULL,
 CONSTRAINT [PK_ri_officer] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



ALTER TABLE [dbo].[ais_clubs]
ADD rotary_agreement_date datetime NULL;
ALTER TABLE [dbo].[ais_clubs]
ADD rotary_agreement_type [nvarchar](50) NULL;

ALTER TABLE [dbo].[ais_clubs]
ADD cric_satellite int NULL;

ALTER TABLE [dbo].[ais_ri_member]
ADD ClubId int NULL;

###### 23/10/2024
- moteur de synchronisation Clubs, Membres & Officers club RI -> RODI

pour activer la synchronisation des clubs, les responsables des clubs doivent aller
individuellement sur my Rotary et choisir RODI Association comme prestataire de gestion de club


MAJ BDD:

ALTER TABLE [dbo].[ri_club]
ADD DtLastUpdate datetime NULL;


CREATE TABLE [dbo].[ri_member](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[MemberId] [int] NULL,
	[MemberType] [nvarchar](50) NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Suffix] [nvarchar](50) NULL,
	[AdmissionDate] [nvarchar](50) NULL,
	[DtLastUpdate] [datetime] NULL,
	[Profile] [ntext] NULL,
 CONSTRAINT [PK_ri_member] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[ri_officer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[MemberId] [int] NULL,
	[ClubId] [int] NULL,
	[OfficerRole] [nvarchar](50) NULL,
	[StartDate] [nvarchar](50) NULL,
	[EndDate] [nvarchar](50) NULL,
	[ClubName] [nvarchar](255) NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[MiddleName] [nvarchar](50) NULL,
	[Suffix] [nvarchar](50) NULL,
	[key] [nvarchar](50) NULL,
	[LastUpdated] [datetime] NULL,
	[DtLastUpdate] [datetime] NULL,
 CONSTRAINT [PK_ri_officer] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



###### 07/10/2024
- nouvel écran de paramétrage de la synchronisation RI > RODI
/espace-membre/administration-district/technique/synchro-ri
- correction bug ajout de réunion club


MAJ BDD:
CREATE TABLE [dbo].[ri_club](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ClubId] [int] NULL,
	[ClubType] [nvarchar](50) NULL,
	[ClubSubType] [nvarchar](50) NULL,
	[ClubName] [nvarchar](255) NULL,
	[ClubCountry] [nvarchar](50) NULL,
	[DistrictId] [int] NULL,
	[MemberCount] [int] NULL,
	[HonoraryMemberCount] [int] NULL,
 CONSTRAINT [PK_ri_club] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


###### 30/09/2024
- changement de calcul sur les dates de l'agenda du gouverneur pour qu'il corresponde bien à l'heure locale
- ajout de la profession du membre dans le trombinoscope club
- nouveau moduble permettant de gérer les listes de contacts club
- les listes contacts club peuvent être utilsées dans les mailings et notifications de réunions
- ajout du statut dans la liste mailing du district

MAJ BDD:
CREATE TABLE [dbo].[ais_contacts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cric] [int] NULL,
	[guid] [uniqueidentifier] NULL,
	[title] [nvarchar](255) NULL,
	[contacts] [ntext] NULL,
	[dt_update] [datetime] NULL,
 CONSTRAINT [PK_ais_contacts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


###### 09/08/2024
- nouveau module DNNFormAndListExportExcel qui permet d'exporter directement en Excel les inscriptions faites sur un formulaire
- modification fonctionnement des réunions périodiques maintenant il faut spécifier le jour dans le mois (par exemple : 1er jeudi)
- le sujet du message de notification d'une réunion est maintenant le nom de la réunion, on peut maintenant modifier le message de notification par réunion
- on peut définir une date de clôture des inscriptions antérieure à la date de début
- une nouvelle fonctionnalité permet maintenant de créer une nouvelle de type bulletin à partir d'une réunion (la liste des présents et absents est automatiquement générée)

MAJ BDD:
ALTER TABLE [ais_meetings]
ADD dtendactive datetime NULL;

ALTER TABLE [ais_meetings]
ADD notificationmsg nvarchar(max) NULL

###### 25/07/2024
- ajout d'un nouveau module razor qui affiche la liste des nouvelles district déjà passées 
- ajout d'url courtes avec QR code pour les nouvelles clubs et district 
	- le QR Code peut être téléchargé sous forme d'image et permet d'être inséré dans un flyer de présentation d'un évènement 
	- on peut maintenant visualiser directement la nouvelle à partir de l'administration des nouvelles clubs & district

###### 18/04/2024
- ajout de nouveaux containers titresansfond, titreh1sansfond, titreh2sansfond permettant de positionner des modules sur des fonds de couleurs
- correction d'un pb de changement de mot de passe dans la page espace membre/mon profil
- les blockscontents de la page d'accueil des sites des clubs peuvent maintenant être modifiés par les Administrateurs Districts, ce qui permet aux admins district d'aider un club pour la mise en page de son site
- ajout d'un message dans le module d'abonnement aux mailings pour le profil membre, afin d'expliquer pourquoi le club du membre n'apparait pas dans la liste
- correction d'un pb d'affichage quand le module agenda du gouverneur n'arrivait plus à joindre le serveur d'agenda
- correction d'un pb lors de l'export excel organigramme district lorsqu'un membre était à la fois rotaract et rotarien
- correction d'un bug d'affichage de la professionnelle membre
- des Rotariens nous ont posé la question sur la conformité RGPD de la plateforme RODI, nous avons donc mis un message en pied de page des districts sur la date de mise en conformité, qui date du 1er jour de mise en place du RGPD en 2018, nous n'avions pas pensé a l'indiquer tellement ca nous semblait évident que RODI respecte la loi...

###### 12/03/2024
- Mise à disposition sur rodi-platform.org d'une page publique de déclaration de confidentialité pour plus de clarté pour les visiteurs, pour chaque district le visiteur peut par le lien /privacy consulter la politique de confidentialité RODI commune a tous les districts :
https://www.rodi-platform.org/district/declaration-de-confidentialite-rodi
- Le format d'export Excel des bureaux actuels et futurs est maintenant le même que celui des présidents
- Changement du libellé d'aide dans le panneau d'importation des affections RI pour indiquer qu'un rôle inexistant RI ne remplace pas un rôle déjà défini dans RODI
- Lorsqu’on importait les rôles d’une année à partir du RI, les présidents étaient positionnés comme présidents élus pour l’année n-1, mais dans certains cas ils pouvaient être insérés en double, ce n'est plus le cas
- La fonction publier, dans la lettre du gouverneur, permet maintenant de rendre la page visible dans le menu
- Amélioration de l'ergonomie du blockcontent club et district, maintenant le blockcontent est en mode visualisation mê  me quand on a le droit de modifier le contenu. Il faut cliquer sur le crayon en haut a droite du module pour passer en modification. Ce nouveau mode de fonctionnement permet d'éviter d'avoir à ouvrir un 2e navigateur pour visualiser le résultat final.
- Ajout d'un rôle Président Club dans le cms mis à jour automatiquement à partir des fonctions de présidents des membres (permet notamment de mettre à disposition du contenu spécifiques aux présidents, exemple : SFPE)
- Ajout d'un module d'affichage du flux RSS de nouvelles du Rotary International (Razor : RotaryInternationalRSS.cshtml)
- Dans le module news panel de la lettre du gouverneur, on peut maintenant définir une url de détail pour l'article, (exemple : page de détail RYLA avec formulaire d'inscription, ou url externe au site)
- Correction d'un bug du module mailing district, lorsqu'on sélectionnait l'année le filtrage pouvait bugger dans certains cas, et amélioration de l'affichage de l'année

###### 06/02/2024
- les blocs vidéo supportent maintenant les vidéos "SHORT" de youtube
- modification du module agenda du gouverneur, qui permet maintenant d'avoir plusieurs agendas différents sur la même page
- correction d'un bug de redimensionnement automatique des vidéos youtube dans module news panel et club news panel
- ajout du choix de présentation dans le bloc de type 'liste d'images' liste, galerie ou caroussel, pour les nouvelles, les clubs, le contenu du site mais pas pour les mailings
- changement des libellés d'options de visibilité pour les nouvelles 
- amélioration de l'ergonomie de la gestion des listes d'images
- correction bug de mise à jour de mot de passe membre


###### 13/01/2024
- ajout du choix du calendrier dans le module agenda du gouverneur (ce qui permet la synchronisation avec un Agenda Google)
- quand on crée un site de club avec domaine sur RODI, le mini site est désactivé, c'est la carte de club qui prend le pas, ce qui évite un double référencement du site : nom de domaine district/club et le domaine du club, pour activer la redirection du district /nomclub vers le domaine du club il faut ajouter l'url du site dans site web externe ce qui permet alors de rediriger vers le site du club et plus vers la carte de visite
- modifications et correction module création lettre du gouverneur
    - correction pb de création de lettre quand on renommait la lettre (exemple : lettres de la gouverneure), les pages se créaient à la racine au lieu de correctement se créer sous la page principale
    - ajout d'une fonction dans les réglages du module permettant de remettre les paramètres par défaut
    - ajout de fonctions pour publier ou dépublier directement une lettre sans avoir besoin de la barre d'administration DNN ce qui permet à un rédacteur de la lettre de la publier directement
    - l'affichage dans l'annuaire des membres tient compte du formatage des n°
- modification de l'affectation du rôle rotarien Club Executive Secretary/Director(Facultatif) lors de l'import des affectations RI maintenant ce rôle devient en français : Secrétaire Exécutif, avant c'était Administration
- création de fonctionnalités de normalisation des n° de téléphones mal formés (surtout issus du RI) afin de rendre les n° utilisables pour une numérotation directe (exemple : dans le cas de l'app mobile)
    - n° Français : 0000000000 (sans le +33 devant)
    - n° Etranger : +0000000000
    - un n° de moins de 10 chiffres est remplacé par une chaine vide
    - tout caractère non numérique est supprimé (il y a parfois des adresses emails dans les n° venant du RI !!!)
- la fonctionnalité de normalisation est utilisée dans les cas suivants :
    - lors de l'import membres district et clubs
    - par l'écran outil webmaster (pour faire une correction immédiate sur tous les membres)
    - dans l'écran de saisie / modification des informations d'un membre
- le module d'affichage de la liste des nouvelles clubs, utilisé dans les sites de clubs, affiche maintenant toutes les nouvelles publiques et plus seulement les actions, il est conseillé de renommer la page "Nos actions" en "Nouvelles", et le titre du module liste en "Nouvelles du club", ceci permet d'étendre les possibilités pour le public et rend plus compréhensible la page 
- ajout d'un lien vers les sites de club dans la page d'administration district : /Espace-Membre/Administration-District/Gestion/Les-clubs
- ajout d'un sélection d'appel de cotisation de district : /Espace-Membre/Administration-District/Comptabilité/Suivi-des-factures-des-clubs, permettant de sélectionner un des 6 derniers appels de cotisations de district, donc les 3 dernières années (par défaut, l'écran se positionne sur l'appel le plus récent)
- correction d'un pb de lien dans les nouvelles pour les partages réseaux sociaux quand le site de club est sur un nom de domaine indépendant du district, et ajout d'information dans les paramètres schema.org pour un meilleur référencement
- quand on télécharge une facture club, le nom de fichier devient Facture.####.pdf au lieu de Commande...

- nouvelles fonctionnalités pour la gestion de l'organigramme district
    - Possibilité d'importer l'organigramme à partir d'un fichier Excel (Pour avoir le modèle il suffit d'exporter l'organigramme actuel)
    - Les membres affectés aux sections se voient attribuer le rôle DNN automatiquement pour l'année rotarienne en cours
    - Lors de l'import du fichier excel, si le n° nim du membre n'est pas renseigné alors la recherche du membre pour affectation de rôle se fait sur le prénom et le nom
    - pour copier l'organigramme d'une année à l'autre il suffit d'exporter en fichier Excel, procéder aux éventuelles modifications puis réimporter le fichier après avoir sélectionné la nouvelle année
    - un bouton permet maintenant de mettre a jour automatiquement les affectations de rôles pour les membres (attention, il faut utiliser cette fonction pour chaque nouvelle année rotarienne)

MAJ BDD : ALTER TABLE ais_drya ADD role NVARCHAR(500) NULL 

- Nouveau type de bloc pour les pages d'accueil des sites de clubs
    - permet de visualiser les nouvelles passées ou futures
    - possibilité de combiner les paramètres (afficher la photo, juste le titre)
    - le bloc disparait s'il n'y a pas de nouvelle pour les critères
    - ATTENTION : il faut que la page qui affiche les nouvelles s'appelle bien /Nouvelles et pas /Nos Actions



###### 12/12/2023
- les membres d'honneur ne sont plus affichés dans l'annuaire de l'app mobile
- suppression de la compatibilité avec les vieux navigateurs
- correction du bouton remonter vers le haut qui apparait 
- ajout liens de partage réseaux sociaux dans détail nouvelle club
- sur la page d'accueil d'un club, les modules de blockcontent se masquent tous seuls s'il n'y a rien dedans
- le formulaire de contact club envoie maintenant les messages en html pour plus de lisibilité
- ajout des fonctions rotariennes d'un membres dans la liste des membres du club (suppression du n° nim afin de garder une mise en page correcte)
- correction d'un bug aléatoire lors de l'envoi final d'un mailing club qui pouvait empecher l'envoi lors du click et revenait à l'écran mailing sans rien faire
- nouvelles fonctionnalités dans le gestionnaire de blocs (nouvelles, mailing, reunion, accueil club) 
	- quand on ajoute un nouveau bloc il s'ouvre directement en édition pour enlever une étape (avant il fallait cliquer sur edit sur le bloc ajouté)
	- dans la liste de fichiers, le click sur le lien ouvre le fichier au lieu de proposer le téléchargement, un nouveau bouton télécharger a été ajouté
	- quand on doit sélectionner une image et qu'on choisit un PDF, la 1ere page est automatiquement convertie en image (attention, le rendu de l'image peut différer du pdf original, par exemple différence de polices de caractères) ce principe est aussi appliqué aux images d'accroche des nouvelles club et district

###### 15/11/2023
- correction d'un bug d'affichage des bloc de type html pour les nouvelles club (exemple : google map ou helloasso)
- nouveau module permettant de recadrer les images dans les blocs (images et texte & accroche des nouvelles) utilisable pour : 
	- les mailings clubs
	- les nouvelles
	- les réunions
	- le contenu libre blockcontent dans les clubs et le district
- ajout d'une fonction de duplication de message dans le module mailing
- correction du bug de multiplication des réunions périodiques
- ajout d'un rechargement de la liste des réunions et des nouvelles quand la liste change (exemple quand on modifie une reunion périodique qui entraine la création automatique quelques secondes après de la réunion, maintenant la liste se rafraichit automatiquement ce qui évite d'avoir à recharger la page plusieurs fois jusqu'à ce qu'elle apparaisse)
- ajout de la gestion de la taille dynamique des images pour les accroches des nouvelles de l'app mobile
- correction du bug de reautentification sur l'app mobile (perte de l'état loggué et non renouvellement du jeton de sécurité au bout d'une heure)
- ajouts sur l'app mobile : 
	- lien rodi platform
	- lien vers site district
	- s'il n'y a pas d'image d'accroche dans une nouvelle le logo du district est affiché pour la nouvelle
	- ajout du nom du club dans le détail de fiche membre
	- affichage de tous les types de nouvelles publiques dans l'app mobile 
	- ajout d'un bouton pour accéder à la réinitialisation du mot de passe sur le site de district
	- ajout d'une information dans le détail d'un membre qui indique qu'il faut être identifié pour voir le contenu détaillé
- création d'un nouveau module d'envoi de mail qui résout le pb du nom d'expéditeur qui affichait systématiquement le nom du district au lieux du nom du club et pouvait entrainer la confusion auprès des destinataires (avec le module standard du CMS il n'était pas possible de résoudre ce pb) ceci concerne les mailings, contacts mais aussi les notifications de réunions

###### 24/10/2023
- nouveau module de gestion des abonnements membres pour le mailing
- 
###### 16/10/2023
- news panel (informations club, lettre du gouverneur, nouvelles clubs et district) :
	- ajout de boutons de déplacement pour les blocs tout en haut / tout en bas
	- on peut maintenant masquer le lien lire la suite pour n'utiliser qu'une image cliquable pour voir le détail de la nouvelle
	- correction d'un pb de déplacement dans certains cas qui mettait le bloc tout en bas
- suppression du champ password inutile dans la fonctionnalité mailing, les password ne sont plus récupérables depuis longtemps, cette fonctionnalité ne pouvait plus fonctionner.
- correction d'un bug d'affichage dans la lettre du gouverneur apparu à la dernière maj
- nouveau module de mailing club
- nouveau moteur d'envoi de mailing intégré au planificateur de taches DNN (MailingScheduler)
- modification des styles des icones blockcontent afin de les rendre plus discrets

###### 07/09/2023
- ajout de paramétrages pour permettre aux districts qui gèrent les clubs satellites de manière indépendante des clubs parents, d'affecter automatiquement les membres aux clubs correspondants, auparavant ce traitement était spécifique au D1770
- l'import membre district et club s'adapte a ce fonctionnement, en verrouillant l'import pour les clubs satellites, seuls les clubs parents peuvent importer le fichier membre du RI et les membres sont alors affectés aux clubs satellites correspondants
- dans la gestion des membres d'un club, l'import des membres est désactivée pour les clubs satellites, le club parent doit importer les membres pour le club parent et satellite car les données sont dans le même fichier venant du RI
- on peut déplacer le membre du club parent au club satellite et vice versa en modifiant sa fiche  et en cochant la case membre d'un club satellite, lors de l'import des membres au niveau du club, comme l'information de club satellite du membre n'existe pas dans le fichier du ri, on se base sur ce qui a été coché en local dans RODI, ce qui fait que les membres restent dans le bon club lors de l'import, en cas d'import suite à l'ajout d'un nouveau membre sur le RI pour le club satellite alors il faut ajuster son positionnement après import dans le club parrain
- ajout des 2 nouvelles affectations venant du RI
	-	Libellé RI	> 	Libellé RODI
	-	Club Learning Facilitator	>	Responsable Formation
	-	Club Vice President		> 	Vice Président

- modification des droits sur l'admin mailing district, maintenant un membre rotaract admin district peut utiliser le mailing district normalement
- correction du ratio vidéo dans le détail d'un article quand on masque le panneau des articles (exemple : personnalisation du courrier du district 1730 et 1760)
- l'agenda du gouverneur n'affiche maintenant que les éléments à partir de la date du jour
- correction d'un problème d'affichage sur le module d'agenda district en liste
- lors de l'import de nouveaux membres dans l'import des membres clubs, la visibilité publique dans l'annuaire est maintenant a définir, alors qu'avant elle était sur Oui par défaut
- ajout de la biographie dans le popup contact membre, le pop fait maintenant 80% de la largeur de la fenêtre pour éviter d'avoir à le retailler


###### 02/08/2023
- correction affichage annuaire détaillé quand on est identifié dans l'app mobile, lors du déploiement de l'app mobile on avait regroupé la récupération des membres pour les anonymes et les rotariens dans une seule fonction, mais le module n'avait pas été déployé en prod donc ca entrainait un disfonctionnement de l'app mobile n'affichant jamais les membres non visible public
- modification import RI global, ajout de textes d'explications et modification import pour importer l'email d'un membre existant s'il n'y en avait pas au préalable dans le district
- création d'un nouveau module Razor qui affiche un bouton pour accéder directement à la dernière lettre du gouverneur et un lien vers toutes les lettres
- modification de l'affichage de la liste des nouvelles dans la rubrique "nos actions" sur les clubs pour masquer l'image
- un administrateur district peut maintenant voir les nouvelles masquées dans les nouvelles district et clubs
- ajout de boutons d'export dans le module admin district export fichiers pour exporter les bureaux  et clubs n'ayant pas déclarés de bureau pour l'année en cours
- le changement de mot de passe prend en compte tous les caractères spéciaux (la même regle de validation que le cms est appliquée)
- mise en place du cache client sur les médias (images, documents) pour 365 jours
- mise en place du moteur de notification pour préparer l'arrivée des nouvelles fonctionnalités de septembre
- ajout d'un lien en bas de page espace membre pour voir la liste des mises à jour RODI sur Github
- ajout du numéro de version RODI installée
- correction du nom de l'expediteur lors de l'envoi de mailing, malgré le nom saisi dans le panneau de mailing celui du district apparassait systématiquement (le reply-to était bon)
- le nom d'expediteur et email est celui du club ou celui du district selon l'usage (dans le cas ou un club n'aurait pas de mail, c'est celui de l'utilisateur connecté qui est prérempli)

###### 12/07/2023
- on peut maintenant définir au niveau admin district des remises pour les clubs avec des nb à virgules pour tenir compte des remises spécifiques aux districts (exemple : jeune rotarien de moins de 2 ans qui paie 50% de cotisation ou gratuité pour le conjoint pour les couples)
- comptabilité district:
	- ajout de la possibilité de marquer une facture comme non réglée
	- ajout de l'email expéditeur en replyto pour que les personnes qui répondent ne répondent pas à l'admin du district mais au trésorier
	- le bouton suppression des factures pour les admins fonctionne correctement
	- on peut revalider le texte de l'email même quand les mails ont déjà été envoyés, on peut donc utiliser l'envoi de mail en changeant le texte pour faire des relances, les emails ne sont envoyées qu'aux clubs qui n'ont pas encore réglé leur facture.
- correction d'un pb d'affichage dans le détail des nouvelles qui empêchait de voir l'image d'accroche quand aucun détail n'était spécifié
- ajout du nom du club dans le détail de la news avec lien vers le club 
- ajout d'un bouton retour dans le module détail article pour revenir à la liste des articles
- ajout d'un filtre supplémentaire sur les noms des fichiers uploadés pour les images et fichiers dans les articles pour résoudre le pb d'accent sur Mac


Publication de la nouvelle application mobile sur Android (Google Play Store & Apple App Store) :
- District 1640 & 1760 (liens vers les différents stores visibles dans la page d'accueil de l'espace membre)
- des qr codes ont été ajoutés dans les pages d'accueil espace membre de différents districts pour faciliter l'accès aux app mobile directement sur smartphone



###### 29/06/2023
- correction bug billetterie quand on revalidait les options lors d'une inscription les données choisies étaient perdues
- correction d'un bug sur le popup de saisie des 4 cadres bleus de pied de page club (la modification ne reprenait pas les données déjà saisies)
- ajout de fonctionnalités dans l'api mobile pour la nouvelle application mobile de district
- ajout du module de suivi des factures des clubs au niveau district (Développement spécifique du 1770 offerts aux autres districts)
- tri des inscrits aux réunions par ordre croissant de nom
- désactivation de l'affichage du popup cookie consent quand on regarde les news de l'app mobile
- modification du module d'import des rôles rotariens des clubs (current et incoming) pour supporter toutes les variations du fichier venant du RI
- correction d'un pb d'export de l'organigramme district en format Excel
- modification admin club 
                - réorganisation panneau de paramètres
                - ajout du nb d'exonéré de cotisation de district
                - définition du type de paiement par défaut
- ajout de fonctionnalités sur le module d'appel de cotisation de district
                - gestion des prélèvements
                - possibilité pour les admins d'effacer les factures
                - dans la fonctionnalité règlement on peut changer le montant effectivement réglé (permet de corriger après coup la facture)
                - prise en compte du nb de membres exonérés
                - prise en compte du type de règlement par défaut des clubs (exemple : pour les prélèvements SEPA)

Publication de la nouvelle application mobile sur Android (Google Play Store) :
- District 1780 & 1670 (liens vers les différents stores visibles dans la page d'accueil de l'espace membre)



###### 29/05/2023
- correction import des affectations clubs au niveau du district du au changement de format du fichier RI
- nouvelle API serveur pour la nouvelle App mobile de district
- ajout d'une fonctionnalité pour les administrateurs qui permet de créer les dossiers documents des clubs manquants 
- correction des conteneurs graphiques qui ne fonctionnaient plus depuis la maj de DNN
- changement de l'ordre d'affichage des membres dans l'annuaire afin que le tri se fasse sur le nom au lieu du prénom


###### 11/04/2023
- blockcontent est maintenant utilisation comme module a part entiere ce qui permet de le mettre sur une page sans donner les droits d'administration
- correction des styles sur l'affichage des nouvelles  
- correction bug sur la programmation des réunions periodiques, quand on changeait l'heure d'une réunion générée elle était regénérée des 10aines de fois
- l'import des membres RI au niveau district n'affecte plus les données des membres existants (sauf pour le changement de club) et ne sert plus qu'a ajouter ou supprimer les membres avant l'appel de cotisation de district
- correction pb de droits sur module pied de page du site de club
- le redirecteur de site web de club de l'espace membre redirige aussi si on est en mode carte de visite de club
- la carte visite de club dispose maintenant d'un design horizontal
- changement d'ordre d'affichage du nom du membre dans le module d'affectation du club, le nom est en premier et trié par nom ascendant
- affichage des n° de téléphones dans le trombinoscope


La nouvelle version de l'application mobile du district est disponible et va être déployée dans les districts concernés
prévision de disponibilité (dépend de l'acceptation des magasins d'application Apple & Android)
1780 - avril (version de test) puis juin 2023
1640 & 1670 - juillet 2023
1730 & 1770 - septembre 2023


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