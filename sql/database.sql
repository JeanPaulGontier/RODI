/****** Object:  Table [dbo].[ais_actions]    Script Date: 25/07/2022 17:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ais_actions](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cric] [int] NULL,
	[dt_update] [datetime] NULL,
	[id_user_update] [int] NULL,
	[dt_action] [datetime] NULL,
	[name_action] [varchar](250) NULL,
	[description] [varchar](max) NULL,
	[id_user_in_charge] [int] NULL,
	[goal] [varchar](max) NULL,
	[id_user_current] [int] NULL,
	[material_resources] [varchar](max) NULL,
	[description_phases] [varchar](max) NULL,
	[human_resources] [varchar](max) NULL,
	[remarks] [varchar](max) NULL,
	[results] [varchar](max) NULL,
	[geographical_area] [varchar](max) NULL,
	[portalid] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ais_archived_members]    Script Date: 25/07/2022 17:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ais_archived_members](
	[id] [int] NULL,
	[nim] [int] NULL,
	[honorary_member] [char](1) NULL,
	[surname] [varchar](255) NULL,
	[name] [varchar](255) NULL,
	[cric] [int] NULL,
	[active_member] [char](1) NULL,
	[civility] [varchar](4) NULL,
	[maiden_name] [varchar](255) NULL,
	[spouse_name] [varchar](255) NULL,
	[title] [varchar](255) NULL,
	[birth_year] [date] NULL,
	[year_membership_rotary] [date] NULL,
	[email] [varchar](255) NULL,
	[adress_1] [varchar](255) NULL,
	[adress_2] [varchar](255) NULL,
	[adress_3] [varchar](255) NULL,
	[zip_code] [varchar](50) NULL,
	[town] [varchar](255) NULL,
	[telephone] [varchar](50) NULL,
	[fax] [varchar](50) NULL,
	[gsm] [varchar](50) NULL,
	[country] [varchar](50) NULL,
	[job] [varchar](255) NULL,
	[industry] [varchar](255) NULL,
	[biography] [text] NULL,
	[base_dtupdate] [datetime] NULL,
	[professionnal_adress] [varchar](255) NULL,
	[professionnal_zip_code] [varchar](50) NULL,
	[professionnal_town] [varchar](255) NULL,
	[professionnal_tel] [varchar](50) NULL,
	[professionnal_fax] [varchar](50) NULL,
	[professionnal_mobile] [varchar](50) NULL,
	[professionnal_email] [varchar](255) NULL,
	[retired] [char](1) NULL,
	[removed] [char](1) NULL,
	[visible] [char](1) NULL,
	[district_id] [int] NULL,
	[club_name] [varchar](255) NULL,
	[userid] [int] NULL,
	[photo] [varchar](255) NULL,
	[year] [int] NULL,
	[month] [int] NULL,
	[portalid] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ais_attendance]    Script Date: 25/07/2022 17:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ais_attendance](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cric] [int] NULL,
	[year] [int] NULL,
	[month] [int] NULL,
	[day] [int] NULL,
	[nbm] [int] NULL,
	[nbp] [int] NULL,
	[nbc] [int] NULL,
	[nbe] [int] NULL,
	[nbd] [int] NULL,
	[nim] [int] NULL,
	[nbdp] [int] NULL,
	[name_surname] [varchar](150) NULL,
	[dt_input] [datetime] NULL,
	[dt_edit] [datetime] NULL,
	[portalid] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ais_clubs]    Script Date: 25/07/2022 17:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ais_clubs](
	[cric] [int] NOT NULL,
	[district_id] [int] NULL,
	[name] [varchar](255) NULL,
	[adress_1] [varchar](255) NULL,
	[adress_2] [varchar](255) NULL,
	[adress_3] [varchar](255) NULL,
	[zip] [varchar](50) NULL,
	[town] [varchar](255) NULL,
	[pennant] [varchar](255) NULL,
	[meetings] [text] NULL,
	[telephone] [varchar](50) NULL,
	[fax] [varchar](50) NULL,
	[email] [varchar](255) NULL,
	[web] [varchar](255) NULL,
	[text] [text] NULL,
	[seo] [varchar](255) NULL,
	[latitude] [varchar](255) NULL,
	[longitude] [varchar](255) NULL,
	[meeting_adr1] [varchar](255) NULL,
	[meeting_adr2] [varchar](255) NULL,
	[meeting_zip] [varchar](50) NULL,
	[meeting_town] [varchar](255) NULL,
	[former_presidents] [text] NULL,
	[type_club] [varchar](50) NULL,
	[roles] [varchar](max) NULL,
	[seo_mode] [varchar](1) NULL,
	[portalid] [int] NULL,
	[domaine] [varchar](500) NULL,
 CONSTRAINT [PK_ais_clubs] PRIMARY KEY CLUSTERED 
(
	[cric] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ais_clubs_dons]    Script Date: 25/07/2022 17:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ais_clubs_dons](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cric] [int] NULL,
	[url] [nvarchar](255) NULL,
 CONSTRAINT [PK_ais_clubs_dons] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ais_clubs_import]    Script Date: 25/07/2022 17:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ais_clubs_import](
	[cric] [int] NULL,
	[name] [varchar](255) NULL,
	[adress_1] [varchar](255) NULL,
	[adress_2] [varchar](255) NULL,
	[adress_3] [varchar](255) NULL,
	[zip] [varchar](50) NULL,
	[town] [varchar](255) NULL,
	[telephone] [varchar](50) NULL,
	[fax] [varchar](50) NULL,
	[email] [varchar](255) NULL,
	[former_presidents] [text] NULL,
	[portalid] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ais_commission]    Script Date: 25/07/2022 17:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ais_commission](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[job] [varchar](255) NULL,
	[memberName] [varchar](100) NULL,
	[rotary_year] [int] NULL,
	[portalid] [int] NULL,
 CONSTRAINT [PK_ais_commission] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ais_content]    Script Date: 25/07/2022 17:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ais_content](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_user] [int] NULL,
	[dt] [date] NULL,
	[type] [varchar](50) NULL,
	[title] [varchar](255) NULL,
	[announcementType] [varchar](50) NULL,
	[text] [text] NULL,
	[photo] [varchar](255) NULL,
	[URL] [varchar](255) NULL,
	[file] [varchar](255) NULL,
	[textFile] [varchar](255) NULL,
	[published] [char](1) NULL,
	[company] [varchar](255) NULL,
	[mode] [varchar](50) NULL,
	[portalid] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ais_domain]    Script Date: 25/07/2022 17:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ais_domain](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[domain] [varchar](50) NULL,
	[subdomain] [varchar](50) NULL,
	[wording] [varchar](255) NULL,
	[value] [varchar](255) NULL,
	[culture] [varchar](50) NULL,
	[order] [int] NULL,
	[parent] [int] NULL,
	[portalid] [int] NULL,
 CONSTRAINT [PK_ais_domaine] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ais_drya]    Script Date: 25/07/2022 17:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ais_drya](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nim] [int] NULL,
	[surname] [varchar](50) NULL,
	[name] [varchar](50) NULL,
	[job] [varchar](50) NULL,
	[cric] [int] NULL,
	[club] [varchar](50) NULL,
	[section] [varchar](50) NULL,
	[rank] [int] NULL,
	[rotary_year] [int] NULL,
	[description] [text] NULL,
	[portalid] [int] NULL,
 CONSTRAINT [PK_ais_architecture] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ais_error_rotary_import]    Script Date: 25/07/2022 17:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ais_error_rotary_import](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[dt] [datetime] NULL,
	[wording] [varchar](255) NULL,
	[portalid] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ais_import_ri]    Script Date: 25/07/2022 17:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ais_import_ri](
	[CRIC] [int] NULL,
	[NIM] [int] NULL,
	[MemberName] [varchar](255) NULL,
	[Email] [varchar](255) NULL,
	[FirstName] [varchar](255) NULL,
	[LastName] [varchar](255) NULL,
	[ClubName] [varchar](255) NULL,
	[Sexe] [varchar](50) NULL,
	[Admission] [date] NULL,
	[Telephone] [varchar](50) NULL,
	[Ad1] [varchar](255) NULL,
	[Ad2] [varchar](255) NULL,
	[Ad3] [varchar](255) NULL,
	[CP] [varchar](50) NULL,
	[Ville] [varchar](255) NULL,
	[Pays] [varchar](255) NULL,
	[portalid] [int] NULL,
	[Honneur] [bit] NULL,
	[Satellite] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ais_import_ri_affectations]    Script Date: 25/07/2022 17:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ais_import_ri_affectations](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[type] [nvarchar](50) NULL,
	[cric] [int] NULL,
	[role] [nvarchar](255) NULL,
	[nom] [nvarchar](255) NULL,
	[email] [nvarchar](255) NULL,
 CONSTRAINT [PK_ais_import_ri_affectations] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ais_Items]    Script Date: 25/07/2022 17:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ais_Items](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[uid] [char](36) NULL,
	[userid] [varchar](50) NULL,
	[dtlastupdate] [datetime] NULL,
	[version] [int] NULL,
	[name] [nvarchar](255) NULL,
	[value] [nvarchar](max) NULL,
	[portalid] [int] NULL,
 CONSTRAINT [PK_ais_Items] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ais_lerotarien_import]    Script Date: 25/07/2022 17:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ais_lerotarien_import](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[numero_district] [int] NULL,
	[nom_club] [varchar](255) NULL,
	[nom] [varchar](255) NULL,
	[prenom] [varchar](255) NULL,
	[adresse] [varchar](255) NULL,
	[complement1] [varchar](255) NULL,
	[complement2] [varchar](255) NULL,
	[codepostal] [varchar](255) NULL,
	[localite] [varchar](255) NULL,
	[email] [varchar](255) NULL,
	[activite] [varchar](255) NULL,
	[metier] [varchar](255) NULL,
	[fonctiondansleclub] [varchar](255) NULL,
	[portalid] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ais_meetings]    Script Date: 25/07/2022 17:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ais_meetings](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cric] [int] NULL,
	[name] [nvarchar](255) NULL,
	[guid] [uniqueidentifier] NULL,
	[active] [char](1) NULL,
	[type] [varchar](50) NULL,
	[periods] [nvarchar](max) NULL,
	[statutory] [char](1) NULL,
	[dtstart] [datetime] NULL,
	[dtend] [datetime] NULL,
	[dtrevision] [datetime] NULL,
	[templateguid] [uniqueidentifier] NULL,
	[mustnotify] [char](1) NULL,
	[dtnotif1] [datetime] NULL,
	[dtnotif2] [datetime] NULL,
	[notif1done] [char](1) NULL,
	[notif2done] [char](1) NULL,
	[dtlastupdate] [datetime] NULL,
	[portalid] [int] NULL,
	[link] [nvarchar](50) NULL,
	[nbusers] [int] NULL,
 CONSTRAINT [PK_ais_meeting] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ais_meetings_users]    Script Date: 25/07/2022 17:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ais_meetings_users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[guid] [uniqueidentifier] NULL,
	[meetingguid] [uniqueidentifier] NULL,
	[useridguid] [varchar](50) NULL,
	[firstname] [nvarchar](50) NULL,
	[lastname] [nvarchar](50) NULL,
	[comment] [nvarchar](1024) NULL,
	[dtlastupdate] [datetime] NULL,
 CONSTRAINT [PK_ais_meetings_users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ais_members]    Script Date: 25/07/2022 17:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ais_members](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nim] [int] NULL,
	[honorary_member] [char](1) NULL,
	[surname] [varchar](255) NULL,
	[name] [varchar](255) NULL,
	[cric] [int] NULL,
	[active_member] [char](1) NULL,
	[civility] [varchar](4) NULL,
	[maiden_name] [varchar](255) NULL,
	[spouse_name] [varchar](255) NULL,
	[title] [varchar](255) NULL,
	[birth_year] [date] NULL,
	[year_membership_rotary] [date] NULL,
	[email] [varchar](255) NULL,
	[adress_1] [varchar](255) NULL,
	[adress_2] [varchar](255) NULL,
	[adress_3] [varchar](255) NULL,
	[zip_code] [varchar](50) NULL,
	[town] [varchar](255) NULL,
	[telephone] [varchar](50) NULL,
	[fax] [varchar](50) NULL,
	[gsm] [varchar](50) NULL,
	[country] [varchar](50) NULL,
	[job] [varchar](255) NULL,
	[industry] [varchar](255) NULL,
	[biography] [text] NULL,
	[base_dtupdate] [datetime] NULL,
	[professionnal_adress] [varchar](255) NULL,
	[professionnal_zip_code] [varchar](50) NULL,
	[professionnal_town] [varchar](255) NULL,
	[professionnal_tel] [varchar](50) NULL,
	[professionnal_fax] [varchar](50) NULL,
	[professionnal_mobile] [varchar](50) NULL,
	[professionnal_email] [varchar](255) NULL,
	[retired] [char](1) NULL,
	[removed] [char](1) NULL,
	[district_id] [int] NULL,
	[club_name] [varchar](255) NULL,
	[userid] [int] NULL,
	[photo] [varchar](255) NULL,
	[visible] [char](1) NULL,
	[portalid] [int] NULL,
 CONSTRAINT [PK_ais_members] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ais_news]    Script Date: 25/07/2022 17:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ais_news](
	[id] [uniqueidentifier] NOT NULL,
	[cric] [int] NULL,
	[dt] [date] NULL,
	[dt_end] [date] NULL,
	[title] [nvarchar](1024) NULL,
	[abstract] [nvarchar](100) NULL,
	[text] [ntext] NULL,
	[url_text] [nvarchar](255) NULL,
	[url] [nvarchar](255) NULL,
	[photo] [nvarchar](255) NULL,
	[category] [nvarchar](50) NULL,
	[tag1] [nvarchar](50) NULL,
	[tag2] [nvarchar](50) NULL,
	[visible] [char](1) NULL,
	[club_type] [nvarchar](50) NULL,
	[adress] [nvarchar](50) NULL,
	[town] [nvarchar](50) NULL,
	[zip_code] [nvarchar](50) NULL,
	[dt_start_event] [date] NULL,
	[dt_end_event] [date] NULL,
	[ord] [int] NULL,
	[portalid] [int] NULL,
	[idpolaris] [int] NULL,
 CONSTRAINT [PK_ais_news] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ais_news_blocs]    Script Date: 25/07/2022 17:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ais_news_blocs](
	[id] [uniqueidentifier] NOT NULL,
	[news_id] [uniqueidentifier] NULL,
	[visible] [char](1) NULL,
	[type] [nvarchar](50) NULL,
	[ord] [int] NULL,
	[title] [nvarchar](255) NULL,
	[photo] [nvarchar](255) NULL,
	[content_type] [nvarchar](50) NULL,
	[content] [ntext] NULL,
	[portalid] [int] NULL,
 CONSTRAINT [PK_ais_news_blocs] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ais_news_test]    Script Date: 25/07/2022 17:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ais_news_test](
	[id] [uniqueidentifier] NOT NULL,
	[cric] [int] NULL,
	[dt] [date] NULL,
	[dt_end] [date] NULL,
	[title] [varchar](255) NULL,
	[abstract] [varchar](100) NULL,
	[text] [text] NULL,
	[url_text] [varchar](255) NULL,
	[url] [varchar](255) NULL,
	[photo] [varchar](255) NULL,
	[category] [varchar](50) NULL,
	[tag1] [varchar](50) NULL,
	[tag2] [varchar](50) NULL,
	[visible] [char](1) NULL,
	[club_type] [varchar](50) NULL,
	[adress] [varchar](50) NULL,
	[town] [varchar](50) NULL,
	[zip_code] [varchar](5) NULL,
	[dt_start_event] [date] NULL,
	[dt_end_event] [date] NULL,
	[ord] [int] NULL,
	[portalid] [int] NULL,
 CONSTRAINT [PK_ais_news_test] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ais_newsletters]    Script Date: 25/07/2022 17:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ais_newsletters](
	[id] [uniqueidentifier] NOT NULL,
	[cric] [int] NULL,
	[dt] [date] NULL,
	[title] [varchar](255) NULL,
	[text] [text] NULL,
	[recipient] [text] NULL,
	[status] [char](1) NULL,
	[sender_email] [varchar](255) NULL,
	[sender_name] [varchar](255) NULL,
	[club_type] [varchar](50) NULL,
	[portalid] [int] NULL,
 CONSTRAINT [PK_ais_newsletter] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ais_newsletters_error]    Script Date: 25/07/2022 17:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ais_newsletters_error](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[dt] [datetime] NULL,
	[reference] [varchar](255) NULL,
	[recipient] [varchar](255) NULL,
	[reason] [varchar](max) NULL,
	[portalid] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ais_newsletters_out]    Script Date: 25/07/2022 17:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ais_newsletters_out](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[newsletter_id] [uniqueidentifier] NULL,
	[nim] [int] NULL,
	[email] [varchar](255) NULL,
	[status] [char](1) NULL,
	[error] [varchar](max) NULL,
	[read] [char](1) NULL,
	[portalid] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ais_nouvelles]    Script Date: 25/07/2022 17:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ais_nouvelles](
	[id] [uniqueidentifier] NOT NULL,
	[cric] [int] NULL,
	[dt] [date] NULL,
	[titre] [varchar](255) NULL,
	[texte] [text] NULL,
	[url_texte] [varchar](255) NULL,
	[url] [varchar](255) NULL,
	[photo] [varchar](255) NULL,
	[categorie] [varchar](50) NULL,
	[tag1] [varchar](50) NULL,
	[tag2] [varchar](50) NULL,
	[visible] [char](1) NULL,
	[type_club] [varchar](50) NULL,
	[portalid] [int] NULL,
 CONSTRAINT [PK_ais_nouvelles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ais_orders]    Script Date: 25/07/2022 17:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ais_orders](
	[id] [int] IDENTITY(13000,1) NOT NULL,
	[guid] [uniqueidentifier] NULL,
	[id_payment] [uniqueidentifier] NULL,
	[cric] [int] NULL,
	[club] [varchar](255) NULL,
	[amount] [float] NULL,
	[rule] [char](1) NULL,
	[info_rule] [text] NULL,
	[type_rule] [varchar](50) NULL,
	[par_rule] [varchar](255) NULL,
	[dt_rule] [datetime] NULL,
	[dt] [datetime] NULL,
	[transaction_id] [int] NULL,
	[portalid] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ais_orders_details]    Script Date: 25/07/2022 17:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ais_orders_details](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_order] [int] NULL,
	[wording] [varchar](255) NULL,
	[amount] [float] NULL,
	[id_parent] [int] NULL,
	[unitary] [float] NULL,
	[quantity] [float] NULL,
	[portalid] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ais_payment]    Script Date: 25/07/2022 17:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ais_payment](
	[id] [uniqueidentifier] NULL,
	[dt] [date] NULL,
	[title] [varchar](255) NULL,
	[text] [text] NULL,
	[type] [char](1) NULL,
	[wording1] [varchar](255) NULL,
	[amount1] [float] NULL,
	[wording2] [varchar](255) NULL,
	[amount2] [float] NULL,
	[closing] [char](1) NULL,
	[model] [varchar](255) NULL,
	[options] [text] NULL,
	[portalid] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ais_paypal_ipn]    Script Date: 25/07/2022 17:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ais_paypal_ipn](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[dt] [datetime] NULL,
	[request] [varchar](max) NULL,
	[response] [varchar](max) NULL,
	[portalid] [int] NULL,
 CONSTRAINT [PK_ais_paypal_ipn] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ais_polaris_import]    Script Date: 25/07/2022 17:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ais_polaris_import](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[club] [nvarchar](255) NULL,
	[idpolaris] [int] NULL,
	[url] [nvarchar](1024) NULL,
	[type] [nvarchar](1024) NULL,
	[titre] [nvarchar](1024) NULL,
	[fichier] [nvarchar](1024) NULL,
	[image] [nvarchar](1024) NULL,
	[contenu] [ntext] NULL,
	[date] [date] NULL,
	[visibilite] [nvarchar](255) NULL,
 CONSTRAINT [PK_polaris_import] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ais_rotaract_clubs]    Script Date: 25/07/2022 17:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ais_rotaract_clubs](
	[cric] [int] NOT NULL,
	[district_id] [int] NULL,
	[name] [varchar](255) NULL,
	[adress_1] [varchar](255) NULL,
	[adress_2] [varchar](255) NULL,
	[adress_3] [varchar](255) NULL,
	[zip] [varchar](50) NULL,
	[town] [varchar](255) NULL,
	[pennant] [varchar](255) NULL,
	[meetings] [text] NULL,
	[telephone] [varchar](50) NULL,
	[fax] [varchar](50) NULL,
	[email] [varchar](255) NULL,
	[web] [varchar](255) NULL,
	[text] [text] NULL,
	[seo] [varchar](255) NULL,
	[latitude] [varchar](255) NULL,
	[longitude] [varchar](255) NULL,
	[meeting_adr1] [varchar](255) NULL,
	[meeting_adr2] [varchar](255) NULL,
	[meeting_zip] [varchar](50) NULL,
	[reunion_ville] [varchar](255) NULL,
	[former_presidents] [text] NULL,
	[type_club] [varchar](50) NULL,
	[portalid] [int] NULL,
 CONSTRAINT [PK_ais_clubs_rotaract] PRIMARY KEY CLUSTERED 
(
	[cric] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ais_rotaract_members]    Script Date: 25/07/2022 17:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ais_rotaract_members](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nim] [int] NULL,
	[honorary_member] [char](1) NULL,
	[surname] [varchar](255) NULL,
	[name] [varchar](255) NULL,
	[cric] [int] NULL,
	[active_member] [char](1) NULL,
	[civility] [varchar](4) NULL,
	[maiden_name] [varchar](255) NULL,
	[spouse_name] [varchar](255) NULL,
	[title] [varchar](255) NULL,
	[birth_year] [date] NULL,
	[year_membership_rotary] [date] NULL,
	[email] [varchar](255) NULL,
	[adress_1] [varchar](255) NULL,
	[adress_2] [varchar](255) NULL,
	[adress_3] [varchar](255) NULL,
	[zip_code] [varchar](50) NULL,
	[town] [varchar](255) NULL,
	[telephone] [varchar](50) NULL,
	[fax] [varchar](50) NULL,
	[gsm] [varchar](50) NULL,
	[country] [varchar](50) NULL,
	[job] [varchar](255) NULL,
	[industry] [varchar](255) NULL,
	[biography] [text] NULL,
	[base_dtupdate] [datetime] NULL,
	[professionnal_adress] [varchar](255) NULL,
	[professionnal_zip_code] [varchar](50) NULL,
	[professionnal_town] [varchar](255) NULL,
	[professionnal_tel] [varchar](50) NULL,
	[professionnal_fax] [varchar](50) NULL,
	[professionnal_mobile] [varchar](50) NULL,
	[professionnal_email] [varchar](255) NULL,
	[retired] [char](1) NULL,
	[removed] [char](1) NULL,
	[district_id] [int] NULL,
	[club_name] [varchar](255) NULL,
	[userid] [int] NULL,
	[photo] [varchar](255) NULL,
	[visible] [char](1) NULL,
	[portalid] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ais_rotary_import]    Script Date: 25/07/2022 17:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ais_rotary_import](
	[honorary_member] [char](1) NULL,
	[nim] [int] NULL,
	[surname] [varchar](255) NULL,
	[name] [varchar](255) NULL,
	[cric] [int] NULL,
	[active_member] [char](1) NULL,
	[civility] [varchar](4) NULL,
	[maiden_name] [varchar](255) NULL,
	[spouse_name] [varchar](255) NULL,
	[title] [varchar](255) NULL,
	[birth_year] [date] NULL,
	[year_membership_rotary] [date] NULL,
	[email] [varchar](255) NULL,
	[adress_1] [varchar](255) NULL,
	[adress_2] [varchar](255) NULL,
	[adress_3] [varchar](255) NULL,
	[zip_code] [varchar](50) NULL,
	[town] [varchar](255) NULL,
	[telephone] [varchar](50) NULL,
	[fax] [varchar](50) NULL,
	[gsm] [varchar](50) NULL,
	[country] [varchar](50) NULL,
	[job] [varchar](255) NULL,
	[industry] [varchar](255) NULL,
	[biography] [text] NULL,
	[base_dtupdate] [datetime] NULL,
	[professionnal_adress] [varchar](255) NULL,
	[professionnal_zip_code] [varchar](50) NULL,
	[professionnal_town] [varchar](255) NULL,
	[professionnal_tel] [varchar](50) NULL,
	[professionnal_fax] [varchar](50) NULL,
	[professionnal_mobile] [varchar](50) NULL,
	[professionnal_email] [varchar](255) NULL,
	[retired] [char](1) NULL,
	[removed] [char](1) NULL,
	[district_id] [int] NULL,
	[club_name] [varchar](255) NULL,
	[portalid] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ais_ry]    Script Date: 25/07/2022 17:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ais_ry](
	[rotary_year] [int] NULL,
	[cric] [int] NULL,
	[confirmed] [char](1) NULL,
	[portalid] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ais_rya]    Script Date: 25/07/2022 17:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ais_rya](
	[rotary_year] [int] NULL,
	[function] [varchar](50) NULL,
	[cric] [int] NULL,
	[nim] [int] NULL,
	[name] [varchar](255) NULL,
	[portalid] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ais_schedule_events]    Script Date: 25/07/2022 17:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ais_schedule_events](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_calendar] [int] NULL,
	[dt] [datetime] NULL,
	[topic] [varchar](50) NULL,
	[description] [text] NULL,
	[start] [datetime] NULL,
	[end] [datetime] NULL,
	[recur_rule] [text] NULL,
	[parent_guid] [varchar](50) NULL,
	[localization] [varchar](50) NULL,
	[recall] [text] NULL,
	[id_folder] [varchar](10) NULL,
	[guid] [varchar](50) NULL,
	[category] [varchar](50) NULL,
	[importance] [varchar](1) NULL,
	[all_day] [varchar](1) NULL,
	[portalid] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ais_subscription]    Script Date: 25/07/2022 17:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ais_subscription](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_user] [int] NULL,
	[id_order] [varchar](255) NULL,
	[id_content] [int] NULL,
	[type] [varchar](50) NULL,
	[dt_beginning] [datetime] NULL,
	[dt_end] [datetime] NULL,
	[active] [char](1) NULL,
	[amount] [float] NULL,
	[portalid] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ais_subscription2]    Script Date: 25/07/2022 17:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ais_subscription2](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_user] [int] NULL,
	[id_order] [varchar](255) NULL,
	[id_content] [int] NULL,
	[type] [varchar](50) NULL,
	[dt_beginning] [datetime] NULL,
	[dt_end] [datetime] NULL,
	[active] [char](1) NULL,
	[amount] [float] NULL,
	[portalid] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ais_testAndroid]    Script Date: 25/07/2022 17:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ais_testAndroid](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fonction] [varchar](100) NULL,
	[dt] [date] NULL,
	[portalid] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ais_ticketing]    Script Date: 25/07/2022 17:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ais_ticketing](
	[guid] [varchar](50) NOT NULL,
	[dt] [datetime] NULL,
	[name] [varchar](255) NULL,
	[parms] [xml] NULL,
	[portalid] [int] NULL,
 CONSTRAINT [PK_ais_ticketing] PRIMARY KEY CLUSTERED 
(
	[guid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ais_ticketing_emails]    Script Date: 25/07/2022 17:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ais_ticketing_emails](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ticketing_guid] [varchar](50) NULL,
	[name] [varchar](255) NULL,
	[email] [varchar](255) NULL,
	[subject] [varchar](255) NULL,
	[body] [text] NULL,
	[sentdatetime] [datetime] NULL,
	[error] [text] NULL,
	[portalid] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ais_ticketing_orders]    Script Date: 25/07/2022 17:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ais_ticketing_orders](
	[id] [int] IDENTITY(10000,1) NOT NULL,
	[ticketing_guid] [varchar](50) NULL,
	[guid] [varchar](50) NULL,
	[reference] [varchar](50) NULL,
	[dt] [datetime] NULL,
	[ip] [varchar](50) NULL,
	[firstname] [varchar](255) NULL,
	[lastname] [varchar](255) NULL,
	[email] [varchar](255) NULL,
	[phone] [varchar](50) NULL,
	[club] [varchar](255) NULL,
	[paid] [varchar](50) NULL,
	[payment_detail] [text] NULL,
	[payment_method] [varchar](50) NULL,
	[payment_transaction_id] [varchar](50) NULL,
	[description] [xml] NULL,
	[portalid] [int] NULL,
 CONSTRAINT [PK_ais_ticketing_orders] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ais_ticketing_ticket]    Script Date: 25/07/2022 17:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ais_ticketing_ticket](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ticket_date] [datetime] NULL,
	[guid] [varchar](50) NULL,
	[order_guid] [varchar](50) NULL,
	[item_guid] [varchar](50) NULL,
	[cancelation_date] [datetime] NULL,
	[checkin_date] [datetime] NULL,
	[portalid] [int] NULL,
 CONSTRAINT [PK_ais_ticketing_ticket] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ais_ticketing_vouchers]    Script Date: 25/07/2022 17:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ais_ticketing_vouchers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ticketing_guid] [varchar](50) NULL,
	[guid] [varchar](50) NULL,
	[surname] [varchar](255) NULL,
	[name] [varchar](255) NULL,
	[email] [varchar](255) NULL,
	[qty] [int] NULL,
	[price] [float] NULL,
	[item_label] [varchar](255) NULL,
	[item_description] [text] NULL,
	[order_guid] [varchar](50) NULL,
	[portalid] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ais_ws_stats]    Script Date: 25/07/2022 17:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ais_ws_stats](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[os] [nvarchar](50) NULL,
	[version] [nvarchar](50) NULL,
	[device] [nvarchar](max) NULL,
	[ip] [nvarchar](50) NULL,
	[datetime] [datetime] NULL,
	[duration] [float] NULL,
	[function] [nvarchar](50) NULL,
	[code] [nvarchar](10) NULL,
	[comment] [nvarchar](max) NULL,
	[username] [nvarchar](255) NULL,
	[portalid] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[ais_actions] ADD  DEFAULT ((0)) FOR [portalid]
GO
ALTER TABLE [dbo].[ais_archived_members] ADD  CONSTRAINT [DF_ais_membres_archives_annee]  DEFAULT (datepart(year,getdate())) FOR [year]
GO
ALTER TABLE [dbo].[ais_archived_members] ADD  CONSTRAINT [DF_ais_membres_archives_mois]  DEFAULT (datepart(month,getdate())) FOR [month]
GO
ALTER TABLE [dbo].[ais_archived_members] ADD  DEFAULT ((0)) FOR [portalid]
GO
ALTER TABLE [dbo].[ais_attendance] ADD  DEFAULT ((0)) FOR [portalid]
GO
ALTER TABLE [dbo].[ais_clubs] ADD  CONSTRAINT [DF_ais_clubs_district_id]  DEFAULT ((1730)) FOR [district_id]
GO
ALTER TABLE [dbo].[ais_clubs] ADD  CONSTRAINT [DF_ais_clubs_reunion_adr1]  DEFAULT ('') FOR [meeting_adr1]
GO
ALTER TABLE [dbo].[ais_clubs] ADD  CONSTRAINT [DF_ais_clubs_reunion_adr2]  DEFAULT ('') FOR [meeting_adr2]
GO
ALTER TABLE [dbo].[ais_clubs] ADD  CONSTRAINT [DF_ais_clubs_reunion_cp]  DEFAULT ('') FOR [meeting_zip]
GO
ALTER TABLE [dbo].[ais_clubs] ADD  CONSTRAINT [DF_ais_clubs_reunion_ville]  DEFAULT ('') FOR [meeting_town]
GO
ALTER TABLE [dbo].[ais_clubs] ADD  CONSTRAINT [DF_ais_clubs_type_club]  DEFAULT ('rotary') FOR [type_club]
GO
ALTER TABLE [dbo].[ais_clubs] ADD  DEFAULT ((0)) FOR [portalid]
GO
ALTER TABLE [dbo].[ais_clubs_import] ADD  DEFAULT ((0)) FOR [portalid]
GO
ALTER TABLE [dbo].[ais_commission] ADD  DEFAULT ((0)) FOR [portalid]
GO
ALTER TABLE [dbo].[ais_content] ADD  DEFAULT ((0)) FOR [portalid]
GO
ALTER TABLE [dbo].[ais_domain] ADD  DEFAULT ((0)) FOR [portalid]
GO
ALTER TABLE [dbo].[ais_drya] ADD  DEFAULT ((0)) FOR [portalid]
GO
ALTER TABLE [dbo].[ais_error_rotary_import] ADD  CONSTRAINT [DF_ais_import_rotarien_erreur_dt]  DEFAULT (getdate()) FOR [dt]
GO
ALTER TABLE [dbo].[ais_error_rotary_import] ADD  DEFAULT ((0)) FOR [portalid]
GO
ALTER TABLE [dbo].[ais_import_ri] ADD  DEFAULT ((0)) FOR [portalid]
GO
ALTER TABLE [dbo].[ais_lerotarien_import] ADD  DEFAULT ((0)) FOR [portalid]
GO
ALTER TABLE [dbo].[ais_members] ADD  DEFAULT ((0)) FOR [portalid]
GO
ALTER TABLE [dbo].[ais_news] ADD  CONSTRAINT [DF_ais_news_id]  DEFAULT (newid()) FOR [id]
GO
ALTER TABLE [dbo].[ais_news] ADD  CONSTRAINT [DF_ais_news_cric]  DEFAULT ((0)) FOR [cric]
GO
ALTER TABLE [dbo].[ais_news] ADD  CONSTRAINT [DF_ais_news_categorie]  DEFAULT ('') FOR [category]
GO
ALTER TABLE [dbo].[ais_news] ADD  CONSTRAINT [DF_ais_news_tag1]  DEFAULT ('') FOR [tag1]
GO
ALTER TABLE [dbo].[ais_news] ADD  CONSTRAINT [DF_ais_news_tag2]  DEFAULT ('') FOR [tag2]
GO
ALTER TABLE [dbo].[ais_news] ADD  CONSTRAINT [DF_ais_news_visible]  DEFAULT ('N') FOR [visible]
GO
ALTER TABLE [dbo].[ais_news] ADD  CONSTRAINT [DF__ais_news__portal__48317F57]  DEFAULT ((0)) FOR [portalid]
GO
ALTER TABLE [dbo].[ais_news_blocs] ADD  CONSTRAINT [DF_ais_news_blocs_id]  DEFAULT (newid()) FOR [id]
GO
ALTER TABLE [dbo].[ais_news_blocs] ADD  CONSTRAINT [DF_ais_news_blocs_ord]  DEFAULT ((0)) FOR [ord]
GO
ALTER TABLE [dbo].[ais_news_blocs] ADD  DEFAULT ((0)) FOR [portalid]
GO
ALTER TABLE [dbo].[ais_news_test] ADD  CONSTRAINT [DF_ais_news_test_id]  DEFAULT (newid()) FOR [id]
GO
ALTER TABLE [dbo].[ais_news_test] ADD  CONSTRAINT [DF_ais_news_test_cric]  DEFAULT ((0)) FOR [cric]
GO
ALTER TABLE [dbo].[ais_news_test] ADD  CONSTRAINT [DF_ais_news_test_categorie]  DEFAULT ('') FOR [category]
GO
ALTER TABLE [dbo].[ais_news_test] ADD  CONSTRAINT [DF_ais_news_test_tag1]  DEFAULT ('') FOR [tag1]
GO
ALTER TABLE [dbo].[ais_news_test] ADD  CONSTRAINT [DF_ais_news_test_tag2]  DEFAULT ('') FOR [tag2]
GO
ALTER TABLE [dbo].[ais_news_test] ADD  CONSTRAINT [DF_ais_news_test_visible]  DEFAULT ('N') FOR [visible]
GO
ALTER TABLE [dbo].[ais_news_test] ADD  DEFAULT ((0)) FOR [portalid]
GO
ALTER TABLE [dbo].[ais_newsletters] ADD  CONSTRAINT [DF_ais_newsletter_id]  DEFAULT (newid()) FOR [id]
GO
ALTER TABLE [dbo].[ais_newsletters] ADD  CONSTRAINT [DF_ais_newsletters_cric]  DEFAULT ((0)) FOR [cric]
GO
ALTER TABLE [dbo].[ais_newsletters] ADD  CONSTRAINT [DF_ais_newsletters_dt]  DEFAULT (getdate()) FOR [dt]
GO
ALTER TABLE [dbo].[ais_newsletters] ADD  CONSTRAINT [DF_ais_newsletters_dest]  DEFAULT ('') FOR [recipient]
GO
ALTER TABLE [dbo].[ais_newsletters] ADD  CONSTRAINT [DF_ais_newsletters_statut]  DEFAULT ('N') FOR [status]
GO
ALTER TABLE [dbo].[ais_newsletters] ADD  DEFAULT ((0)) FOR [portalid]
GO
ALTER TABLE [dbo].[ais_newsletters_error] ADD  DEFAULT ((0)) FOR [portalid]
GO
ALTER TABLE [dbo].[ais_newsletters_out] ADD  CONSTRAINT [DF_ais_newsletter_out_statut]  DEFAULT ('N') FOR [status]
GO
ALTER TABLE [dbo].[ais_newsletters_out] ADD  CONSTRAINT [DF_ais_newsletters_out_lu]  DEFAULT ('N') FOR [read]
GO
ALTER TABLE [dbo].[ais_newsletters_out] ADD  DEFAULT ((0)) FOR [portalid]
GO
ALTER TABLE [dbo].[ais_nouvelles] ADD  CONSTRAINT [DF_ais_nouvelles_id]  DEFAULT (newid()) FOR [id]
GO
ALTER TABLE [dbo].[ais_nouvelles] ADD  CONSTRAINT [DF_ais_nouvelles_cric]  DEFAULT ((0)) FOR [cric]
GO
ALTER TABLE [dbo].[ais_nouvelles] ADD  CONSTRAINT [DF_ais_nouvelles_categorie]  DEFAULT ('') FOR [categorie]
GO
ALTER TABLE [dbo].[ais_nouvelles] ADD  CONSTRAINT [DF_ais_nouvelles_tag1]  DEFAULT ('') FOR [tag1]
GO
ALTER TABLE [dbo].[ais_nouvelles] ADD  CONSTRAINT [DF_ais_nouvelles_tag2]  DEFAULT ('') FOR [tag2]
GO
ALTER TABLE [dbo].[ais_nouvelles] ADD  CONSTRAINT [DF_ais_nouvelles_visible]  DEFAULT ('N') FOR [visible]
GO
ALTER TABLE [dbo].[ais_nouvelles] ADD  DEFAULT ((0)) FOR [portalid]
GO
ALTER TABLE [dbo].[ais_orders] ADD  CONSTRAINT [DF_ais_commandes_guid]  DEFAULT (newid()) FOR [guid]
GO
ALTER TABLE [dbo].[ais_orders] ADD  CONSTRAINT [DF_ais_commande_regle]  DEFAULT ('N') FOR [rule]
GO
ALTER TABLE [dbo].[ais_orders] ADD  CONSTRAINT [DF_ais_commandes_transaction_id]  DEFAULT ((0)) FOR [transaction_id]
GO
ALTER TABLE [dbo].[ais_orders] ADD  DEFAULT ((0)) FOR [portalid]
GO
ALTER TABLE [dbo].[ais_orders_details] ADD  CONSTRAINT [DF_ais_commandes_detail_montant]  DEFAULT ((0)) FOR [amount]
GO
ALTER TABLE [dbo].[ais_orders_details] ADD  CONSTRAINT [DF_ais_commandes_detail_id_libelle_parent]  DEFAULT ((0)) FOR [id_parent]
GO
ALTER TABLE [dbo].[ais_orders_details] ADD  CONSTRAINT [DF_ais_commandes_detail_unitaire]  DEFAULT ((0)) FOR [unitary]
GO
ALTER TABLE [dbo].[ais_orders_details] ADD  CONSTRAINT [DF_ais_commandes_detail_quantite]  DEFAULT ((0)) FOR [quantity]
GO
ALTER TABLE [dbo].[ais_orders_details] ADD  DEFAULT ((0)) FOR [portalid]
GO
ALTER TABLE [dbo].[ais_payment] ADD  CONSTRAINT [DF_ais_reglements_id]  DEFAULT (newid()) FOR [id]
GO
ALTER TABLE [dbo].[ais_payment] ADD  CONSTRAINT [DF_ais_reglements_validation]  DEFAULT ('M') FOR [type]
GO
ALTER TABLE [dbo].[ais_payment] ADD  CONSTRAINT [DF_ais_reglements_cloture]  DEFAULT ('N') FOR [closing]
GO
ALTER TABLE [dbo].[ais_payment] ADD  DEFAULT ((0)) FOR [portalid]
GO
ALTER TABLE [dbo].[ais_paypal_ipn] ADD  DEFAULT ((0)) FOR [portalid]
GO
ALTER TABLE [dbo].[ais_rotaract_clubs] ADD  CONSTRAINT [DF_ais_clubs_rotaract_reunion_adr1]  DEFAULT ('') FOR [meeting_adr1]
GO
ALTER TABLE [dbo].[ais_rotaract_clubs] ADD  CONSTRAINT [DF_ais_clubs_rotaract_reunion_adr2]  DEFAULT ('') FOR [meeting_adr2]
GO
ALTER TABLE [dbo].[ais_rotaract_clubs] ADD  CONSTRAINT [DF_ais_clubs_rotaract_reunion_cp]  DEFAULT ('') FOR [meeting_zip]
GO
ALTER TABLE [dbo].[ais_rotaract_clubs] ADD  CONSTRAINT [DF_ais_clubs_rotaract_reunion_ville]  DEFAULT ('') FOR [reunion_ville]
GO
ALTER TABLE [dbo].[ais_rotaract_clubs] ADD  DEFAULT ((0)) FOR [portalid]
GO
ALTER TABLE [dbo].[ais_rotaract_members] ADD  DEFAULT ((0)) FOR [portalid]
GO
ALTER TABLE [dbo].[ais_rotary_import] ADD  DEFAULT ((0)) FOR [portalid]
GO
ALTER TABLE [dbo].[ais_ry] ADD  CONSTRAINT [DF_ais_ar_cric]  DEFAULT ((0)) FOR [cric]
GO
ALTER TABLE [dbo].[ais_ry] ADD  CONSTRAINT [DF_ais_ar_confirmee]  DEFAULT ('N') FOR [confirmed]
GO
ALTER TABLE [dbo].[ais_ry] ADD  DEFAULT ((0)) FOR [portalid]
GO
ALTER TABLE [dbo].[ais_rya] ADD  DEFAULT ((0)) FOR [portalid]
GO
ALTER TABLE [dbo].[ais_schedule_events] ADD  DEFAULT ((0)) FOR [portalid]
GO
ALTER TABLE [dbo].[ais_subscription] ADD  DEFAULT ((0)) FOR [portalid]
GO
ALTER TABLE [dbo].[ais_subscription2] ADD  DEFAULT ((0)) FOR [portalid]
GO
ALTER TABLE [dbo].[ais_testAndroid] ADD  DEFAULT ((0)) FOR [portalid]
GO
ALTER TABLE [dbo].[ais_ticketing] ADD  DEFAULT ((0)) FOR [portalid]
GO
ALTER TABLE [dbo].[ais_ticketing_emails] ADD  DEFAULT ((0)) FOR [portalid]
GO
ALTER TABLE [dbo].[ais_ticketing_orders] ADD  DEFAULT ((0)) FOR [portalid]
GO
ALTER TABLE [dbo].[ais_ticketing_ticket] ADD  DEFAULT ((0)) FOR [portalid]
GO
ALTER TABLE [dbo].[ais_ticketing_vouchers] ADD  CONSTRAINT [DF_ais_ticketing_coupons_qty]  DEFAULT ((1)) FOR [qty]
GO
ALTER TABLE [dbo].[ais_ticketing_vouchers] ADD  CONSTRAINT [DF_ais_ticketing_coupons_price]  DEFAULT ((0)) FOR [price]
GO
ALTER TABLE [dbo].[ais_ticketing_vouchers] ADD  DEFAULT ((0)) FOR [portalid]
GO
ALTER TABLE [dbo].[ais_ws_stats] ADD  DEFAULT ((0)) FOR [portalid]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'R: Role F: Fonction D: Departement A: Année rotarienne B: Bureau(président ou secrétaire) M: tous les membres(CRIC) Si pas de A: renseigné prendre l''année rotarienne N0 par defaut (sauf pour tous les membres et pour role)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ais_newsletters', @level2type=N'COLUMN',@level2name=N'recipient'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'N : normal
 P : préparation 
E : En cours d''envoi 
T : Terminée' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ais_newsletters', @level2type=N'COLUMN',@level2name=N'status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Stockage de la liste des règlements' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ais_payment', @level2type=N'COLUMN',@level2name=N'options'
GO
