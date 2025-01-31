USE [cntt3_serminar]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 4/17/2024 12:42:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[product] [nvarchar](100) NOT NULL,
	[img] [varchar](250) NOT NULL,
	[price] [money] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([id], [product], [img], [price]) VALUES (1, N'Chuồn chuồn khuếch tán tinh dầu - Silver V.2 - Dragonfly Balance Aroma Diffuser Silver', N'https://product.hstatic.net/1000069970/product/12_4c25a81a218f48b7bb3b639924791b20_large.png', 1200.0000)
INSERT [dbo].[Product] ([id], [product], [img], [price]) VALUES (2, N'Đồng Hồ Để Bàn Tự Lật Phong Cách Cổ Điển', N'https://product.hstatic.net/1000069970/product/son01109_copy_2_8f2d3f5df5264b70b4e310b6f7d31e9b_large.jpg', 890.0000)
INSERT [dbo].[Product] ([id], [product], [img], [price]) VALUES (3, N'Đèn treo màn hình máy tính Yeelight LED Screen Light Bar - Pro Limited 2022', N'https://product.hstatic.net/1000069970/product/yeelight2_308d735c50714d40a8bbd8b78eb9fe90_large.png', 2250.0000)
INSERT [dbo].[Product] ([id], [product], [img], [price]) VALUES (5, N'Eilik - Robot tương tác tích hợp trí thông minh cảm xúc', N'https://product.hstatic.net/1000069970/product/8_e867c43091474496b80aee91430e3f75_large.png', 6990.0000)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
