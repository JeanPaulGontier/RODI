
CREATE TABLE [dbo].[ais_ticketing](
	[guid] [varchar](50) NOT NULL,
	[dt] [datetime] NULL,
	[name] [varchar](255) NULL,
	[parms] [xml] NULL,
 CONSTRAINT [PK_ais_ticketing] PRIMARY KEY CLUSTERED 
(
	[guid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[ais_ticketing_emails](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ticketing_guid] [varchar](50) NULL,
	[name] [varchar](255) NULL,
	[email] [varchar](255) NULL,
	[subject] [varchar](255) NULL,
	[body] [text] NULL,
	[sentdatetime] [datetime] NULL,
	[error] [text] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[ais_ticketing_ticket](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ticket_date] [datetime] NULL,
	[guid] [varchar](50) NULL,
	[order_guid] [varchar](50) NULL,
	[item_guid] [varchar](50) NULL,
	[cancelation_date] [datetime] NULL,
	[checkin_date] [datetime] NULL,
 CONSTRAINT [PK_ais_ticketing_ticket] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
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
	[description] [xml] NULL,
 CONSTRAINT [PK_ais_ticketing_orders] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
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
	[order_guid] [varchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[ais_ticketing_vouchers] ADD  CONSTRAINT [DF_ais_ticketing_coupons_qty]  DEFAULT ((1)) FOR [qty]
GO

ALTER TABLE [dbo].[ais_ticketing_vouchers] ADD  CONSTRAINT [DF_ais_ticketing_coupons_price]  DEFAULT ((0)) FOR [price]
GO


