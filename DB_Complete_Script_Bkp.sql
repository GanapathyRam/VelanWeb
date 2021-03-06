USE [VV]
GO
/****** Object:  Table [dbo].[ScreenAccess]    Script Date: 09/27/2015 17:14:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ScreenAccess](
	[ScreenAccessID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[MenuName] [nvarchar](50) NOT NULL,
	[MenuID] [int] NULL,
	[ParentMenuName] [nvarchar](50) NULL,
	[ParentMenuID] [int] NULL,
	[HasAccess] [bit] NOT NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](50) NOT NULL,
	[UpdatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_ScreenAccess] PRIMARY KEY CLUSTERED 
(
	[ScreenAccessID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductionReleaseNew]    Script Date: 09/27/2015 17:14:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductionReleaseNew](
	[ProdReleaseID] [int] IDENTITY(1,1) NOT NULL,
	[OrderNum] [int] NOT NULL,
	[LineNum] [nvarchar](50) NOT NULL,
	[Pos] [int] NOT NULL,
	[ProdOrderNo] [nvarchar](50) NOT NULL,
	[SerialNo] [nvarchar](50) NULL,
	[ProdReleaseQty] [int] NOT NULL,
	[BalanceQty] [int] NULL,
	[ProdDeliveryDate] [nvarchar](50) NULL,
	[ProdComplDate] [nvarchar](50) NULL,
	[ProdRemarks] [nvarchar](50) NULL,
	[TPIOfferDate] [nvarchar](50) NULL,
	[QCRemarks] [nvarchar](50) NULL,
	[IRNComplDate] [nvarchar](50) NULL,
	[SCNComplDate] [nvarchar](50) NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[UpdatedOn] [datetime] NULL,
 CONSTRAINT [PK_ProductionReleaseNew] PRIMARY KEY CLUSTERED 
(
	[ProdReleaseID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MISSalesInput]    Script Date: 09/27/2015 17:14:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MISSalesInput](
	[MISSalesInputID] [int] IDENTITY(1,1) NOT NULL,
	[OrderNo] [int] NOT NULL,
	[LineNum] [nvarchar](50) NOT NULL,
	[Pos] [int] NOT NULL,
	[SAPCode] [nvarchar](50) NULL,
	[StockCode] [nvarchar](50) NULL,
	[O2] [nvarchar](50) NULL,
	[H2] [nvarchar](50) NULL,
	[IBR] [nvarchar](50) NULL,
	[ASU] [nvarchar](50) NULL,
	[TAGNo] [nvarchar](50) NULL,
	[GADNo] [nvarchar](50) NULL,
	[QCINo] [nvarchar](50) NULL,
	[RelDate] [nvarchar](50) NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](50) NOT NULL,
	[UpdatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_MISSalesInput] PRIMARY KEY CLUSTERED 
(
	[MISSalesInputID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MISOrderStatus]    Script Date: 09/27/2015 17:14:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MISOrderStatus](
	[OrderType] [nvarchar](50) NOT NULL,
	[OrderNo] [int] NOT NULL,
	[CustomerName] [nvarchar](150) NOT NULL,
	[CustomerOrderNo] [nvarchar](150) NOT NULL,
	[LineNum] [nvarchar](50) NOT NULL,
	[Pos] [int] NOT NULL,
	[Item] [nvarchar](200) NULL,
	[Description] [nvarchar](250) NULL,
	[ItemGroup] [nvarchar](50) NULL,
	[SalesOrderRevision] [int] NULL,
	[RevisionDate] [datetime] NULL,
	[Area] [int] NULL,
	[OrderDate] [datetime] NULL,
	[OriginalPromDate] [datetime] NULL,
	[PlannedDelDate] [datetime] NULL,
	[OrderQty] [int] NOT NULL,
	[BalanceQty] [int] NOT NULL,
	[Amount] [float] NOT NULL,
	[InvoicedQty] [int] NULL,
	[FGQty] [int] NULL,
	[WIPQty] [int] NULL,
	[RelDate] [datetime] NULL,
	[ProdCompletionDate] [datetime] NULL,
	[ProdRemarks] [nvarchar](250) NULL,
	[PlanWeek] [int] NULL,
	[WIPWeek] [int] NULL,
	[FGWeek] [int] NULL,
	[ToReleaseQty] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MISFinanceInput]    Script Date: 09/27/2015 17:14:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MISFinanceInput](
	[MISFinanceInputID] [int] IDENTITY(1,1) NOT NULL,
	[OrderNo] [int] NOT NULL,
	[LineNum] [nvarchar](50) NOT NULL,
	[Pos] [int] NOT NULL,
	[ABG] [nvarchar](50) NOT NULL,
	[PBG] [nvarchar](50) NOT NULL,
	[RP] [nvarchar](50) NOT NULL,
	[ITP] [nvarchar](50) NULL,
	[ApprovedITP] [nvarchar](50) NULL,
	[GAD] [nvarchar](50) NULL,
	[ApprovedGAD] [nvarchar](50) NULL,
	[Inspection1] [nvarchar](50) NULL,
	[Inspection2] [nvarchar](50) NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](50) NOT NULL,
	[UpdatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_MISFinanceInput] PRIMARY KEY CLUSTERED 
(
	[MISFinanceInputID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MISFinal]    Script Date: 09/27/2015 17:14:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MISFinal](
	[OrderType] [nvarchar](50) NOT NULL,
	[OrderNo] [int] NOT NULL,
	[CustomerName] [nvarchar](150) NOT NULL,
	[CustomerOrderNo] [nvarchar](150) NOT NULL,
	[LineNum] [nvarchar](50) NOT NULL,
	[Pos] [int] NOT NULL,
	[Item] [nvarchar](200) NULL,
	[Description] [nvarchar](250) NULL,
	[ItemGroup] [nvarchar](50) NULL,
	[SalesOrderRevision] [int] NULL,
	[RevisionDate] [datetime] NULL,
	[Area] [int] NULL,
	[OrderDate] [datetime] NULL,
	[OriginalPromDate] [datetime] NULL,
	[PlannedDelDate] [datetime] NULL,
	[OrderQty] [int] NOT NULL,
	[BalanceQty] [int] NOT NULL,
	[Amount] [float] NOT NULL,
	[InvoicedQty] [int] NULL,
	[FGQty] [int] NULL,
	[WIPQty] [int] NULL,
	[RelDate] [datetime] NULL,
	[ProdCompletionDate] [datetime] NULL,
	[ProdRemarks] [nvarchar](250) NULL,
	[PlanWeek] [int] NULL,
	[WIPWeek] [int] NULL,
	[FGWeek] [int] NULL,
	[ToReleaseQty] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Login]    Script Date: 09/27/2015 17:14:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](50) NOT NULL,
	[UpdatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK__Login__1788CCAC023D5A04] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IV_Complete]    Script Date: 09/27/2015 17:14:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IV_Complete](
	[InvoiceID] [int] IDENTITY(1,1) NOT NULL,
	[CustID] [int] NOT NULL,
	[SearchKey] [nvarchar](150) NOT NULL,
	[OrderType] [nvarchar](50) NOT NULL,
	[OrderNo] [int] NOT NULL,
	[LV] [nchar](10) NOT NULL,
	[LineNum] [nvarchar](50) NOT NULL,
	[Pos] [int] NOT NULL,
	[SQ] [int] NULL,
	[ST] [int] NULL,
	[PrTy] [int] NULL,
	[ItemType] [nvarchar](50) NULL,
	[Proj] [nvarchar](50) NULL,
	[ItemCode] [nvarchar](50) NULL,
	[WRH] [int] NULL,
	[DelQty] [nvarchar](50) NULL,
	[ForwAgent] [nvarchar](50) NULL,
	[BillLading] [int] NULL,
	[ValueINR] [float] NULL,
	[InvoiceDate] [nvarchar](50) NULL,
	[Type] [nvarchar](50) NULL,
	[InvoiceNo] [nvarchar](50) NULL,
	[TrackingNo] [nvarchar](50) NULL,
	[WayBillNo] [nvarchar](50) NULL,
	[ChargeAmount] [nvarchar](50) NULL,
	[IsSuccess] [bit] NOT NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](50) NOT NULL,
	[UpdatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED 
(
	[InvoiceID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemGroupMapping]    Script Date: 09/27/2015 17:14:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemGroupMapping](
	[ItemGroup] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](150) NOT NULL,
	[Product] [nvarchar](50) NOT NULL,
	[X] [nvarchar](50) NOT NULL,
	[MappingCode] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_Split]    Script Date: 09/27/2015 17:14:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  FUNCTION [dbo].[fn_Split](@text varchar(8000), @delimiter varchar(20) = ' ')
RETURNS @Strings TABLE
(   
  position int IDENTITY PRIMARY KEY,
  value varchar(8000)  
)
AS
BEGIN
 
DECLARE @index int
SET @index = -1
 
WHILE (LEN(@text) > 0)
  BEGIN 
    SET @index = CHARINDEX(@delimiter , @text) 
    IF (@index = 0) AND (LEN(@text) > 0) 
      BEGIN  
        INSERT INTO @Strings VALUES (@text)
          BREAK 
      END 
    IF (@index > 1) 
      BEGIN  
        INSERT INTO @Strings VALUES (LEFT(@text, @index - 1))  
        SET @text = RIGHT(@text, (LEN(@text) - @index)) 
      END 
    ELSE
      SET @text = RIGHT(@text, (LEN(@text) - @index))
    END
  RETURN
END
GO
/****** Object:  Table [dbo].[tblInvoice]    Script Date: 09/27/2015 17:14:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblInvoice](
	[InvoiceID] [int] IDENTITY(1,1) NOT NULL,
	[OrderNo] [int] NOT NULL,
	[LineNum] [nvarchar](50) NOT NULL,
	[Pos] [int] NOT NULL,
	[DelQty] [nvarchar](50) NULL,
	[InvoiceDate] [nvarchar](50) NULL,
	[InvoiceNumber] [nvarchar](50) NOT NULL,
	[IsSuccess] [int] NOT NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](50) NOT NULL,
	[UpdatedOn] [datetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[spUpdateTPIOffering]    Script Date: 09/27/2015 17:14:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateTPIOffering]

/******************************************************************************
** Program Property of ArunKumar Amarnath
** Filename	  	 		: spUpdateTPIOffering.sql
** Database Object Name	 		: spUpdateTPIOffering
** Author		 		: ArunKumar Amarnath
** Create Date		 		: 12/07/2015
** Project/System	 		: Velan Valves
** Subproject/Subsystem	 		: BaaN Management
** Purpose/Description	 		: For Updating the  TPI Offer Date, QC Remarks & IRN Comp Date
** Input Parameters	 		: OrderNum, LineNum, Pos, ProdOrderNo, SerialNo, TPIOfferDate, QCRemarks, IRNCompDate, UpdatedBy, UpdatedOn
**					  
** Output Parameters	 		: Updated Status
** Database		 		: VV
** Other Databases Accessed 		: N/A
** Tables		 		: ProductionReleaseNew
** Rerunable				: Yes
****************************************************************************** 
** Modifications:
** Date				Name			Description
** -----------	------------------	---------------
** 12/07/2015	ArunKumar Amarnath	Initial Version
******************************************************************************/
/*Declare all the Input Parameters*/

	@OrderNum int,
	@LineNum nvarchar(50),
	@Pos int,
	@ProdOrderNo nvarchar(50),
	@SerialNo nvarchar(50),
	@TPIOfferDate nvarchar(50),
	@QCRemarks nvarchar(50),
	@IRNCompDate nvarchar(50),
	@UpdatedBy nvarchar(50),
	@UpdatedOn DateTime
AS
BEGIN
	DECLARE @RetVal			INT  		/*RetVal from called SP. =0 for success;<>0 for failure*/              
		, @ErrMsg		VARCHAR(2048)    /*Error Message*/            
		, @ErrorSeverity	INT             /*Error Number*/   
		, @RowCount		INT		/*Row Count*/

BEGIN TRY

	UPDATE
		ProductionReleaseNew
	SET
		TPIOfferDate = @TPIOfferDate,
		QCRemarks = @QCRemarks,
		IRNComplDate = @IRNCompDate,
		UpdatedBy = @UpdatedBy,
		UpdatedOn = @UpdatedOn
	WHERE
		OrderNum = @OrderNum AND
		LineNum = @LineNum AND
		Pos = @Pos AND
		ProdOrderNo = @ProdOrderNo AND
		SerialNo = @SerialNo;

END TRY 
	BEGIN CATCH 
		SELECT @ErrMsg = ERROR_MESSAGE(),
		           @ErrorSeverity = ERROR_SEVERITY();

		RAISERROR(@ErrMsg, @ErrorSeverity, 1) 
		SELECT @RetVal = 9999
		RETURN 9999
	END CATCH 

	RETURN @RetVal
    
END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateScreenAccess]    Script Date: 09/27/2015 17:14:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateScreenAccess]

/******************************************************************************
** Program Property of ArunKumar Amarnath
** Filename	  	 		: spUpdateScreenAccess.sql
** Database Object Name	 		: spUpdateScreenAccess
** Author		 		: ArunKumar Amarnath
** Create Date		 		: 08/08/2015
** Project/System	 		: Velan Valves
** Subproject/Subsystem	 		: BaaN Management
** Purpose/Description	 		: For Updating the  Screen Access
** Input Parameters	 		: @HasAccess, @ScreenAccessID, @UserInfo, @UpdatedDateTime
**					  
** Output Parameters	 		: Updated Status
** Database		 		: VV
** Other Databases Accessed 		: N/A
** Tables		 		: ScreenAccess
** Rerunable				: Yes
****************************************************************************** 
** Modifications:
** Date				Name			Description
** -----------	------------------	---------------
** 08/08/2015	ArunKumar Amarnath	Initial Version
******************************************************************************/
/*Declare all the Input Parameters*/

	@HasAccess bit, 
	@ScreenAccessID int, 
	@UserInfo nvarchar(50), 
	@UpdatedDateTime datetime
AS
BEGIN
	DECLARE @RetVal			INT  		/*RetVal from called SP. =0 for success;<>0 for failure*/              
		, @ErrMsg		VARCHAR(2048)    /*Error Message*/            
		, @ErrorSeverity	INT             /*Error Number*/   
		, @RowCount		INT		/*Row Count*/

BEGIN TRY

	UPDATE 
		ScreenAccess
	SET
		HasAccess = @HasAccess,
		UpdatedBy = @UserInfo,
		UpdatedOn = @UpdatedDateTime
	WHERE
		ScreenAccessID = @ScreenAccessID

END TRY 
	BEGIN CATCH 
		SELECT @ErrMsg = ERROR_MESSAGE(),
		           @ErrorSeverity = ERROR_SEVERITY();

		RAISERROR(@ErrMsg, @ErrorSeverity, 1) 
		SELECT @RetVal = 9999
		RETURN 9999
	END CATCH 

	RETURN @RetVal
    
END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateSCNInput]    Script Date: 09/27/2015 17:14:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateSCNInput]

/******************************************************************************
** Program Property of ArunKumar Amarnath
** Filename	  	 		: spUpdateSCNInput.sql
** Database Object Name	 		: spUpdateSCNInput
** Author		 		: ArunKumar Amarnath
** Create Date		 		: 12/07/2015
** Project/System	 		: Velan Valves
** Subproject/Subsystem	 		: BaaN Management
** Purpose/Description	 		: For Updating the  SCN Comp Date
** Input Parameters	 		: OrderNum, LineNum, Pos, ProdOrderNo, SerialNo, SCNCompDate, UpdatedBy, UpdatedOn
**					  
** Output Parameters	 		: Updated Status
** Database		 		: VV
** Other Databases Accessed 		: N/A
** Tables		 		: ProductionReleaseNew
** Rerunable				: Yes
****************************************************************************** 
** Modifications:
** Date				Name			Description
** -----------	------------------	---------------
** 12/07/2015	ArunKumar Amarnath	Initial Version
******************************************************************************/
/*Declare all the Input Parameters*/

	@OrderNum int,
	@LineNum nvarchar(50),
	@Pos int,
	@ProdOrderNo nvarchar(50),
	@SerialNo nvarchar(50),
	@SCNCompDate nvarchar(50),
	@UpdatedBy nvarchar(50),
	@UpdatedOn DateTime
AS
BEGIN
	DECLARE @RetVal			INT  		/*RetVal from called SP. =0 for success;<>0 for failure*/              
		, @ErrMsg		VARCHAR(2048)    /*Error Message*/            
		, @ErrorSeverity	INT             /*Error Number*/   
		, @RowCount		INT		/*Row Count*/

BEGIN TRY

	UPDATE
		ProductionReleaseNew
	SET
		SCNComplDate = @SCNCompDate,
		UpdatedBy = @UpdatedBy,
		UpdatedOn = @UpdatedOn
	WHERE
		OrderNum = @OrderNum AND
		LineNum = @LineNum AND
		Pos = @Pos AND
		ProdOrderNo = @ProdOrderNo AND
		SerialNo = @SerialNo;

END TRY 
	BEGIN CATCH 
		SELECT @ErrMsg = ERROR_MESSAGE(),
		           @ErrorSeverity = ERROR_SEVERITY();

		RAISERROR(@ErrMsg, @ErrorSeverity, 1) 
		SELECT @RetVal = 9999
		RETURN 9999
	END CATCH 

	RETURN @RetVal
    
END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateProdRelease]    Script Date: 09/27/2015 17:14:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateProdRelease]

/******************************************************************************
** Program Property of ArunKumar Amarnath
** Filename	  	 		: spUpdateProdRelease.sql
** Database Object Name	 		: spUpdateProdRelease
** Author		 		: ArunKumar Amarnath
** Create Date		 		: 02/07/2015
** Project/System	 		: Velan Valves
** Subproject/Subsystem	 		: BaaN Management
** Purpose/Description	 		: For Updating the  BAL Qty
** Input Parameters	 		: OrderNum, LineNum, Pos, ProdOrderNo, SerialNo, BalanceQty
**					  
** Output Parameters	 		: Updated Status
** Database		 		: VV
** Other Databases Accessed 		: N/A
** Tables		 		: ProductionReleaseNew
** Rerunable				: Yes
****************************************************************************** 
** Modifications:
** Date				Name			Description
** -----------	------------------	---------------
** 02/07/2015	ArunKumar Amarnath	Initial Version
******************************************************************************/
/*Declare all the Input Parameters*/

	@OrderNum int,
	@LineNum nvarchar(50),
	@Pos int,
	@ProdOrderNo nvarchar(50),
	@SerialNo nvarchar(50),
	@BalanceQty int
AS
BEGIN
	DECLARE @RetVal			INT  		/*RetVal from called SP. =0 for success;<>0 for failure*/              
		, @ErrMsg		VARCHAR(2048)    /*Error Message*/            
		, @ErrorSeverity	INT             /*Error Number*/   
		, @RowCount		INT		/*Row Count*/

BEGIN TRY

IF (COALESCE( @SerialNo, '' ) = '')
	UPDATE
		ProductionReleaseNew
	SET
		BalanceQty = @BalanceQty
	WHERE
		OrderNum = @OrderNum AND
		LineNum = @LineNum AND
		Pos = @Pos AND
		ProdOrderNo = @ProdOrderNo;

ELSE
	UPDATE
		ProductionReleaseNew
	SET
		BalanceQty = @BalanceQty
	WHERE
		OrderNum = @OrderNum AND
		LineNum = @LineNum AND
		Pos = @Pos AND
		ProdOrderNo = @ProdOrderNo AND
		SerialNo = @SerialNo;
END TRY 
	BEGIN CATCH 
		SELECT @ErrMsg = ERROR_MESSAGE(),
		           @ErrorSeverity = ERROR_SEVERITY();

		RAISERROR(@ErrMsg, @ErrorSeverity, 1) 
		SELECT @RetVal = 9999
		RETURN 9999
	END CATCH 

	RETURN @RetVal
    
END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateProdCompletion]    Script Date: 09/27/2015 17:14:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateProdCompletion]

/******************************************************************************
** Program Property of ArunKumar Amarnath
** Filename	  	 		: spUpdateProdCompletion.sql
** Database Object Name	 		: spUpdateProdCompletion
** Author		 		: ArunKumar Amarnath
** Create Date		 		: 12/07/2015
** Project/System	 		: Velan Valves
** Subproject/Subsystem	 		: BaaN Management
** Purpose/Description	 		: For Updating the  Prod Delivery Date, Prod COmpletion Date & Prod Remarks
** Input Parameters	 		: OrderNum, LineNum, Pos, ProdOrderNo, SerialNo, ProdDeliveryDate, ProdComplDate, ProdRemarks, UpdatedBy, UpdatedOn
**					  
** Output Parameters	 		: Updated Status
** Database		 		: VV
** Other Databases Accessed 		: N/A
** Tables		 		: ProductionReleaseNew
** Rerunable				: Yes
****************************************************************************** 
** Modifications:
** Date				Name			Description
** -----------	------------------	---------------
** 12/07/2015	ArunKumar Amarnath	Initial Version
******************************************************************************/
/*Declare all the Input Parameters*/

	@OrderNum int,
	@LineNum nvarchar(50),
	@Pos int,
	@ProdOrderNo nvarchar(50),
	@SerialNo nvarchar(50),
	@ProdDeliveryDate nvarchar(50),
	@ProdComplDate nvarchar(50),
	@ProdRemarks nvarchar(50),
	@UpdatedBy nvarchar(50),
	@UpdatedOn DateTime
AS
BEGIN
	DECLARE @RetVal			INT  		/*RetVal from called SP. =0 for success;<>0 for failure*/              
		, @ErrMsg		VARCHAR(2048)    /*Error Message*/            
		, @ErrorSeverity	INT             /*Error Number*/   
		, @RowCount		INT		/*Row Count*/

BEGIN TRY

	UPDATE
		ProductionReleaseNew
	SET
		ProdDeliveryDate = @ProdDeliveryDate,
		ProdComplDate = @ProdComplDate,
		ProdRemarks = @ProdRemarks,
		UpdatedBy = @UpdatedBy,
		UpdatedOn = @UpdatedOn
	WHERE
		OrderNum = @OrderNum AND
		LineNum = @LineNum AND
		Pos = @Pos AND
		ProdOrderNo = @ProdOrderNo AND
		SerialNo = @SerialNo;

END TRY 
	BEGIN CATCH 
		SELECT @ErrMsg = ERROR_MESSAGE(),
		           @ErrorSeverity = ERROR_SEVERITY();

		RAISERROR(@ErrMsg, @ErrorSeverity, 1) 
		SELECT @RetVal = 9999
		RETURN 9999
	END CATCH 

	RETURN @RetVal
    
END
GO
/****** Object:  StoredProcedure [dbo].[spUpdatePassword]    Script Date: 09/27/2015 17:14:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdatePassword]

/******************************************************************************
** Program Property of ArunKumar Amarnath
** Filename	  	 		: spUpdatePassword.sql
** Database Object Name	 		: spUpdatePassword
** Author		 		: ArunKumar Amarnath
** Create Date		 		: 08/08/2015
** Project/System	 		: Velan Valves
** Subproject/Subsystem	 		: BaaN Management
** Purpose/Description	 		: For Updating the  Password
** Input Parameters	 		: @NewPassword, @UserInfo, @UpdatedDateTime
**					  
** Output Parameters	 		: Updated Status
** Database		 		: VV
** Other Databases Accessed 		: N/A
** Tables		 		: Login
** Rerunable				: Yes
****************************************************************************** 
** Modifications:
** Date				Name			Description
** -----------	------------------	---------------
** 08/08/2015	ArunKumar Amarnath	Initial Version
******************************************************************************/
/*Declare all the Input Parameters*/

	@NewPassword nvarchar(50), 
	@UserInfo nvarchar(50), 
	@UpdatedDateTime datetime
AS
BEGIN
	DECLARE @RetVal			INT  		/*RetVal from called SP. =0 for success;<>0 for failure*/              
		, @ErrMsg			VARCHAR(2048)    /*Error Message*/            
		, @ErrorSeverity	INT             /*Error Number*/   
		, @RowCount			INT		/*Row Count*/

BEGIN TRY

	UPDATE 
		Login
	SET
		Password = @NewPassword,
		UpdatedBy = @UserInfo,
		UpdatedOn = @UpdatedDateTime
	WHERE
		UserName = @UserInfo

END TRY 
	BEGIN CATCH 
		SELECT @ErrMsg = ERROR_MESSAGE(),
		           @ErrorSeverity = ERROR_SEVERITY();

		RAISERROR(@ErrMsg, @ErrorSeverity, 1) 
		SELECT @RetVal = 9999
		RETURN 9999
	END CATCH 

	RETURN @RetVal
    
END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateMISSalesInput]    Script Date: 09/27/2015 17:14:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateMISSalesInput]

/******************************************************************************
** Program Property of ArunKumar Amarnath
** Filename	  	 		: spUpdateMISSalesInput.sql
** Database Object Name : spUpdateMISSalesInput
** Author		 		: ArunKumar Amarnath
** Create Date		 	: 25/06/2015
** Project/System	 	: Velan Valves
** Subproject/Subsystem	: BaaN Management
** Purpose/Description	: For Updating the data from the MISSalesInput for the chosen Record
** Input Parameters	 	: @OrderNum, @LineNum, @Pos, @SAPCode, @StockCode, @O2, @H2, @IBR, @ASU, @TAGNo, @GADNo, @QCINo, @ReleaseDate
** Output Parameters	: --
** Database		 		: VV
** Other Databases Accessed 		: N/A
** Tables		 		: MISSalesInput
** Rerunable			: Yes
****************************************************************************** 
** Modifications:
** Date				Name			Description
** -----------	------------------	---------------
** 21/06/2015	ArunKumar Amarnath	Initial Version
** 15/07/2015	ArunKumar Amarnath	Added 4 more additonal input params
******************************************************************************/

	@OrderNum int,
	@LineNum nvarchar(50),
	@Pos int,
	@SAPCode nvarchar(50), 
	@StockCode nvarchar(50), 
	@O2 nvarchar(50), 
	@H2 nvarchar(50), 
	@IBR nvarchar(50), 
	@ASU nvarchar(50),
	@TAGNo nvarchar(50),
	@GADNo nvarchar(50),
	@QCINo nvarchar(50),
	@ReleaseDate nvarchar(50),
	@UserInfo nvarchar(50),
	@CreatedDateTime datetime

AS
BEGIN

	DECLARE @RetVal			INT  		/*RetVal from called SP. =0 for success;<>0 for failure*/              
		, @ErrMsg		VARCHAR(2048)    /*Error Message*/            
		, @ErrorSeverity	INT             /*Error Number*/   
		, @RowCount		INT		/*Row Count*/

BEGIN TRY

    UPDATE
		MISSalesInput
	SET
	 	SAPCode = @SAPCode,
		StockCode = @StockCode,
		O2 = @O2,
		H2 = @H2,
		IBR = @IBR,
		ASU = @ASU,
		TAGNo= @TAGNo,
		GADNo = @GADNo,
		QCINo = @QCINo,
		RelDate = @ReleaseDate,
		UpdatedBy = @UserInfo,
		UpdatedOn = @CreatedDateTime
	WHERE
		ORDERNo = @OrderNum
		AND LINENUM = @LineNum
		AND POS = @Pos

END TRY 
	BEGIN CATCH 
		SELECT @ErrMsg = ERROR_MESSAGE(),
		           @ErrorSeverity = ERROR_SEVERITY();

		RAISERROR(@ErrMsg, @ErrorSeverity, 1) 
		SELECT @RetVal = 9999
		RETURN 9999
	END CATCH 

	RETURN @RetVal
    
END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateMISForInvoice]    Script Date: 09/27/2015 17:14:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateMISForInvoice]

/******************************************************************************
** Program Property of ArunKumar Amarnath
** Filename	  	 		: spUpdateMISForInvoice.sql
** Database Object Name	 		: spUpdateMISForInvoice
** Author		 		: ArunKumar Amarnath
** Create Date		 		: 02/07/2015
** Project/System	 		: Velan Valves
** Subproject/Subsystem	 		: BaaN Management
** Purpose/Description	 		: For Updating the  FG, Balance, Invoice Qty
** Input Parameters	 		: OrderNum, LineNum, Pos, FGQty, BalanceQty, InvoicedQty
**					  
** Output Parameters	 		: Updated Status
** Database		 		: VV
** Other Databases Accessed 		: N/A
** Tables		 		: MISOrderStatus
** Rerunable				: Yes
****************************************************************************** 
** Modifications:
** Date				Name			Description
** -----------	------------------	---------------
** 02/07/2015	ArunKumar Amarnath	Initial Version
******************************************************************************/
/*Declare all the Input Parameters*/

	@OrderNum int,
	@LineNum nvarchar(50),
	@Pos int,
	@FGQty int,
	@BalanceQty int,
	@InvoicedQty int
AS
BEGIN
	DECLARE @RetVal			INT  		/*RetVal from called SP. =0 for success;<>0 for failure*/              
		, @ErrMsg		VARCHAR(2048)    /*Error Message*/            
		, @ErrorSeverity	INT             /*Error Number*/   
		, @RowCount		INT		/*Row Count*/

BEGIN TRY

	UPDATE
		MISOrderStatus
	SET
		BalanceQty = @BalanceQty,
		FGQty = @FGQty,
		InvoicedQty = @InvoicedQty
	WHERE
		OrderNo = @OrderNum AND
		LineNum = @LineNum AND
		Pos = @Pos;

END TRY 
	BEGIN CATCH 
		SELECT @ErrMsg = ERROR_MESSAGE(),
		           @ErrorSeverity = ERROR_SEVERITY();

		RAISERROR(@ErrMsg, @ErrorSeverity, 1) 
		SELECT @RetVal = 9999
		RETURN 9999
	END CATCH 

	RETURN @RetVal
    
END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateMISFinanceInputForITP]    Script Date: 09/27/2015 17:14:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateMISFinanceInputForITP]

/******************************************************************************
** Program Property of ArunKumar Amarnath
** Filename	  	 		: spUpdateMISFinanceInputForITP.sql
** Database Object Name : spUpdateMISFinanceInputForITP
** Author		 		: ArunKumar Amarnath
** Create Date		 	: 11/07/2015
** Project/System	 	: Velan Valves
** Subproject/Subsystem	: BaaN Management
** Purpose/Description	: For Updating the data from the MISFinanceInput for the chosen Record
** Input Parameters	 	: @OrderNum, @LineNum, @Pos, @ITP, @ApprovedITP, @GAD, @ApprovedGAD, @Inspection1, @Inspection2, @UserInfo, @CreatedDateTime
** Output Parameters	: --
** Database		 		: VV
** Other Databases Accessed 		: N/A
** Tables		 		: MISFinanceInput
** Rerunable			: Yes
****************************************************************************** 
** Modifications:
** Date				Name			Description
** -----------	------------------	---------------
** 11/07/2015	ArunKumar Amarnath	Initial Version
******************************************************************************/

	@OrderNum int,
	@LineNum nvarchar(50),
	@Pos int,
	@ITP nvarchar(50), 
	@ApprovedITP nvarchar(50), 
	@GAD nvarchar(50), 
	@ApprovedGAD nvarchar(50), 
	@Inspection1 nvarchar(50), 
	@Inspection2 nvarchar(50),
	@UserInfo nvarchar(50),
	@CreatedDateTime datetime

AS
BEGIN

	DECLARE @RetVal			INT  		/*RetVal from called SP. =0 for success;<>0 for failure*/              
		, @ErrMsg		VARCHAR(2048)    /*Error Message*/            
		, @ErrorSeverity	INT             /*Error Number*/   
		, @RowCount		INT		/*Row Count*/

BEGIN TRY

    UPDATE
		MISFinanceInput
	SET
	 	ITP = @ITP, 
		ApprovedITP = @ApprovedITP, 
		GAD = @GAD, 
		ApprovedGAD = @ApprovedGAD, 
		Inspection1 = @Inspection1, 
		Inspection2 = @Inspection2,
		UpdatedBy = @UserInfo,
		UpdatedOn = @CreatedDateTime
	WHERE
		ORDERNo = @OrderNum
		AND LINENUM = @LineNum
		AND POS = @Pos

END TRY 
	BEGIN CATCH 
		SELECT @ErrMsg = ERROR_MESSAGE(),
		           @ErrorSeverity = ERROR_SEVERITY();

		RAISERROR(@ErrMsg, @ErrorSeverity, 1) 
		SELECT @RetVal = 9999
		RETURN 9999
	END CATCH 

	RETURN @RetVal
    
END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateMISFinanceInput]    Script Date: 09/27/2015 17:14:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateMISFinanceInput]

/******************************************************************************
** Program Property of ArunKumar Amarnath
** Filename	  	 		: spUpdateMISFinanceInput.sql
** Database Object Name : spUpdateMISFinanceInput
** Author		 		: ArunKumar Amarnath
** Create Date		 	: 25/06/2015
** Project/System	 	: Velan Valves
** Subproject/Subsystem	: BaaN Management
** Purpose/Description	: For Updating the data from the MISFinanceInput for the chosen Record
** Input Parameters	 	: @OrderNum, @LineNum, @Pos, @ABG, @PBG, @RP, @ITP, @ApprovedITP, @GAD, @ApprovedGAD, @Inspection1, @Inspection2, @UserInfo, @CreatedDateTime
** Output Parameters	: --
** Database		 		: VV
** Other Databases Accessed 		: N/A
** Tables		 		: MISFinanceInput
** Rerunable			: Yes
****************************************************************************** 
** Modifications:
** Date				Name			Description
** -----------	------------------	---------------
** 25/06/2015	ArunKumar Amarnath	Initial Version
** 11/07/2015	ArunKumar Amarnath	Added 6 more Input cols
** 02/08/2015	ArunKumar Amarnath	Removed the Line#,Pos from the where condition
******************************************************************************/

	@OrderNum int,
	@LineNum nvarchar(50),
	@Pos int,
	@ABG nvarchar(50), 
	@PBG nvarchar(50), 
	@RP nvarchar(50),
	@ITP nvarchar(50), 
	@ApprovedITP nvarchar(50), 
	@GAD nvarchar(50), 
	@ApprovedGAD nvarchar(50), 
	@Inspection1 nvarchar(50), 
	@Inspection2 nvarchar(50),
	@UserInfo nvarchar(50),
	@CreatedDateTime datetime

AS
BEGIN

	DECLARE @RetVal			INT  		/*RetVal from called SP. =0 for success;<>0 for failure*/              
		, @ErrMsg		VARCHAR(2048)    /*Error Message*/            
		, @ErrorSeverity	INT             /*Error Number*/   
		, @RowCount		INT		/*Row Count*/

BEGIN TRY

    UPDATE
		MISFinanceInput
	SET
	 	ABG = @ABG,
		PBG = @PBG,
		RP = @RP,
		ITP = @ITP, 
		ApprovedITP = @ApprovedITP, 
		GAD = @GAD, 
		ApprovedGAD = @ApprovedGAD, 
		Inspection1 = @Inspection1, 
		Inspection2 = @Inspection2,
		UpdatedBy = @UserInfo,
		UpdatedOn = @CreatedDateTime
	WHERE
		ORDERNo = @OrderNum
		--AND LINENUM = @LineNum
		--AND POS = @Pos

END TRY 
	BEGIN CATCH 
		SELECT @ErrMsg = ERROR_MESSAGE(),
		           @ErrorSeverity = ERROR_SEVERITY();

		RAISERROR(@ErrMsg, @ErrorSeverity, 1) 
		SELECT @RetVal = 9999
		RETURN 9999
	END CATCH 

	RETURN @RetVal
    
END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateLogicForWIPToFG]    Script Date: 09/27/2015 17:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateLogicForWIPToFG]

/******************************************************************************
** Program Property of ArunKumar Amarnath
** Filename	  	 		: spUpdateLogicForWIPToFG.sql
** Database Object Name	 		: spUpdateLogicForWIPToFG
** Author		 		: ArunKumar Amarnath
** Create Date		 		: 21/06/2015
** Project/System	 		: Velan Valves
** Subproject/Subsystem	 		: BaaN Management
** Purpose/Description	 		: For Updating the  FGQty, WIPQty
** Input Parameters	 		: OrderType, OrderNum, LineNum, Pos, FGQty, WIPQty
**					  
** Output Parameters	 		: Updated Status
** Database		 		: VV
** Other Databases Accessed 		: N/A
** Tables		 		: MISOrderStatus
** Rerunable				: Yes
****************************************************************************** 
** Modifications:
** Date				Name			Description
** -----------	------------------	---------------
** 21/06/2015	ArunKumar Amarnath	Initial Version
******************************************************************************/
/*Declare all the Input Parameters*/

	@OrderType nvarchar(50),
	@OrderNum int,
	@LineNum nvarchar(50),
	@Pos int,
	@FGQty int,
	@WIPQty int
AS
BEGIN
	DECLARE @RetVal			INT  		/*RetVal from called SP. =0 for success;<>0 for failure*/              
		, @ErrMsg		VARCHAR(2048)    /*Error Message*/            
		, @ErrorSeverity	INT             /*Error Number*/   
		, @RowCount		INT		/*Row Count*/

BEGIN TRY

	UPDATE
		MISOrderStatus
	SET
		FGQty = @FGQty,
		WIPQty = @WIPQty
	WHERE
		OrderType = @OrderType AND
		OrderNo = @OrderNum AND
		LineNum = @LineNum AND
		Pos = @Pos;

END TRY 
	BEGIN CATCH 
		SELECT @ErrMsg = ERROR_MESSAGE(),
		           @ErrorSeverity = ERROR_SEVERITY();

		RAISERROR(@ErrMsg, @ErrorSeverity, 1) 
		SELECT @RetVal = 9999
		RETURN 9999
	END CATCH 

	RETURN @RetVal
    
END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateLogicForProdRelease]    Script Date: 09/27/2015 17:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateLogicForProdRelease]

/******************************************************************************
** Program Property of ArunKumar Amarnath
** Filename	  	 		: spUpdateLogicForProdRelease.sql
** Database Object Name	 		: spUpdateLogicForProdRelease
** Author		 		: ArunKumar Amarnath
** Create Date		 		: 21/06/2015
** Project/System	 		: Velan Valves
** Subproject/Subsystem	 		: BaaN Management
** Purpose/Description	 		: For Updating the  ToReleaseQty, WIPQty
** Input Parameters	 		: OrderType, OrderNum, LineNum, Pos, ToReleaseQty, WIPQty
**					  
** Output Parameters	 		: Updated Status
** Database		 		: VV
** Other Databases Accessed 		: N/A
** Tables		 		: MISOrderStatus
** Rerunable				: Yes
****************************************************************************** 
** Modifications:
** Date				Name			Description
** -----------	------------------	---------------
** 21/06/2015	ArunKumar Amarnath	Initial Version
******************************************************************************/
/*Declare all the Input Parameters*/

	@OrderType nvarchar(50),
	@OrderNum int,
	@LineNum nvarchar(50),
	@Pos int,
	@ToReleaseQty int,
	@WIPQty int
AS
BEGIN
	DECLARE @RetVal			INT  		/*RetVal from called SP. =0 for success;<>0 for failure*/              
		, @ErrMsg		VARCHAR(2048)    /*Error Message*/            
		, @ErrorSeverity	INT             /*Error Number*/   
		, @RowCount		INT		/*Row Count*/

BEGIN TRY

	UPDATE
		MISOrderStatus
	SET
		ToReleaseQty = @ToReleaseQty,
		WIPQty = @WIPQty
	WHERE
		OrderType = @OrderType AND
		OrderNo = @OrderNum AND
		LineNum = @LineNum AND
		Pos = @Pos;

END TRY 
	BEGIN CATCH 
		SELECT @ErrMsg = ERROR_MESSAGE(),
		           @ErrorSeverity = ERROR_SEVERITY();

		RAISERROR(@ErrMsg, @ErrorSeverity, 1) 
		SELECT @RetVal = 9999
		RETURN 9999
	END CATCH 

	RETURN @RetVal
    
END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateBaanDataInMISOrderStatus]    Script Date: 09/27/2015 17:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateBaanDataInMISOrderStatus]

/******************************************************************************
** Program Property of ArunKumar Amarnath
** Filename	  	 			: spUpdateBaanDataInMISOrderStatus.sql
** Database Object Name	 	: spUpdateBaanDataInMISOrderStatus
** Author		 			: ArunKumar Amarnath
** Create Date		 		: 02/08/2015
** Project/System	 		: Velan Valves
** Subproject/Subsystem	 	: BaaN Management
** Purpose/Description	 	: For Updating the  Item, Description, ItemGroup, DiffQtyToBeUpdated, PlanWeek, WIPWeek, FGWeek
** Input Parameters	 		: OrderNum, LineNum, Pos, @Item, @Description, @ItemGroup, @DiffQtyToBeUpdated, @PlanWeek, @WIPWeek, @FGWeek
**					  
** Output Parameters	 	: Updated Status
** Database		 			: VV
** Other Databases Accessed : N/A
** Tables		 			: MISOrderStatus
** Rerunable				: Yes
****************************************************************************** 
** Modifications:
** Date				Name			Description
** -----------	------------------	---------------
** 02/08/2015	ArunKumar Amarnath	Initial Version
** 27/09/2015	ArunKumar Amarnath	Started Updating the Amount value (Amount/BalQty) sent from the C# code
******************************************************************************/
/*Declare all the Input Parameters*/

	@OrderNum int,
	@LineNum nvarchar(50),
	@Pos int,
	@Item nvarchar(50),
	@Description nvarchar(50),
	@ItemGroup nvarchar(50),
	@DiffQtyToBeUpdated int,
	@PlanWeek int,
	@WIPWeek int,
	@FGWeek int,
	@UpdatedAmount float
	
AS
BEGIN
	DECLARE @RetVal			INT  		/*RetVal from called SP. =0 for success;<>0 for failure*/              
		, @ErrMsg		VARCHAR(2048)    /*Error Message*/            
		, @ErrorSeverity	INT             /*Error Number*/   
		, @RowCount		INT		/*Row Count*/

BEGIN TRY

	IF (@DiffQtyToBeUpdated > 0)
		BEGIN
			UPDATE
				MISOrderStatus
			SET
				Item = @Item,
				Description = @Description,
				ItemGroup = @ItemGroup,
				PlanWeek = @PlanWeek,
				WIPWeek = @WIPWeek,
				FGWeek = @FGWeek,
				OrderQty = OrderQty + @DiffQtyToBeUpdated,
				BalanceQty = BalanceQty + @DiffQtyToBeUpdated,
				ToReleaseQty = ToReleaseQty + @DiffQtyToBeUpdated,
				Amount = @UpdatedAmount
			WHERE
				OrderNo = @OrderNum AND
				LineNum = @LineNum AND
				Pos = @Pos
		END
	ELSE
		BEGIN
			UPDATE
				MISOrderStatus
			SET
				Item = @Item,
				Description = @Description,
				ItemGroup = @ItemGroup,
				PlanWeek = @PlanWeek,
				WIPWeek = @WIPWeek,
				FGWeek = @FGWeek
			WHERE
				OrderNo = @OrderNum AND
				LineNum = @LineNum AND
				Pos = @Pos
		END

END TRY 
	BEGIN CATCH 
		SELECT @ErrMsg = ERROR_MESSAGE(),
		           @ErrorSeverity = ERROR_SEVERITY();

		RAISERROR(@ErrMsg, @ErrorSeverity, 1) 
		SELECT @RetVal = 9999
		RETURN 9999
	END CATCH 

	RETURN @RetVal
    
END
GO
/****** Object:  StoredProcedure [dbo].[spInsProductionRelease]    Script Date: 09/27/2015 17:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spInsProductionRelease]
/************************************************************************************************************************
** Program Property of ArunKumar Amarnath
** Filename	  	 		: spInsProductionRelease.sql
** Database Object Name	: spInsProductionRelease
** Author		 		: ArunKumar Amarnath
** Create Date		 	: 21/06/2015
** Project/System	 	: Velan Valves
** Subproject/Subsystem	: BaaN Management
** Purpose/Description	: For Inserting the Record
** Input Parameters	 	: @OrderNum, @LineNum, @Pos, @ProdOrderNo, @SerialNo, @ProdReleaseQty, @BalanceQty, @CreatedBy, @CreatedOn, @UpdatedBy, @UpdatedOn
**					  
** Output Parameters	: Inserted Status
** Database		 		: VV
** Other Databases Accessed 		: N/A
** Tables		 		: ProductionReleaseNew
** Rerunable			: Yes
****************************************************************************** 
** Modifications:
** Date				Name			Description
** -----------	------------------	---------------
** 21/06/2015	ArunKumar Amarnath	Initial Version
** 02/07/2015	ArunKumar Amarnath	Added @BalanceQty as Input
** 12/07/2015	ArunKumar Amarnath	Added Column Names to the Input, so as to avoid the error
** **********************************************************************************************************************/
--Declare all the Input Parameters

	@OrderNum int,
	@LineNum nvarchar(50),
	@Pos int,
	@ProdOrderNo nvarchar(50),
	@SerialNo nvarchar(50),
	@ProdReleaseQty int,
	@BalanceQty int,
	@CreatedBy nvarchar(50),
	@CreatedOn datetime,
	@UpdatedBy nvarchar(50),
	@UpdatedOn datetime
AS
BEGIN

	DECLARE @RetVal			INT  		 /*RetVal from called SP. =0 for success;<>0 for failure*/              
		, @ErrMsg		VARCHAR(2048)    /*Error Message*/            
		, @ErrorSeverity	INT          /*Error Number*/   
		, @RowCount		INT		         /*Row Count*/
	
	SELECT @RetVal = 0

	BEGIN TRY 
    -- Insert statements for procedure here
		INSERT INTO 
			ProductionReleaseNew 
			(
				OrderNum,
				LineNum,
				Pos,
				ProdOrderNo,
				SerialNo,
				ProdReleaseQty,
				BalanceQty,
				CreatedBy,
				CreatedOn,
				UpdatedBy,
				UpdatedOn
			)
		VALUES
			(
				@OrderNum, 
				@LineNum, 
				@Pos, 
				@ProdOrderNo, 
				@SerialNo, 
				@ProdReleaseQty,
				@BalanceQty,
				@CreatedBy,
				@CreatedOn,
				@UpdatedBy,
				@UpdatedOn
			)

	END TRY 
	BEGIN CATCH 

		SELECT @ErrMsg = ERROR_MESSAGE(),
		           @ErrorSeverity = ERROR_SEVERITY();

		RAISERROR(@ErrMsg, @ErrorSeverity, 1) 
		SELECT @RetVal = 9999
		RETURN 9999
	END CATCH 

	RETURN @RetVal
END

SET ANSI_NULLS OFF
GO
/****** Object:  StoredProcedure [dbo].[spInsInvoice]    Script Date: 09/27/2015 17:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spInsInvoice]

/******************************************************************************
** Program Property of ArunKumar Amarnath
** Filename	  	 		: spInsInvoice.sql
** Database Object Name : spInsInvoice
** Author		 		: ArunKumar Amarnath
** Create Date		 	: 25/06/2015
** Project/System	 	: Velan Valves
** Subproject/Subsystem	: BaaN Management
** Purpose/Description	: For Inserting the data into the Invoice Table
** Input Parameters	 	: @OrderNum, @LineNum, @Pos, @DelQty, @InvoiceDate, @InvoiceNo, @IsSuccess, @UserInfo, @CreatedDateTime
** Output Parameters	: --
** Database		 		: VV
** Other Databases Accessed 		: N/A
** Tables		 		: tblInvoice
** Rerunable			: Yes
****************************************************************************** 
** Modifications:
** Date				Name			Description
** -----------	------------------	---------------
** 25/06/2015	ArunKumar Amarnath	Initial Version
******************************************************************************/

	@OrderNum int,
	@LineNum nvarchar(50),
	@Pos int,
	@DelQty nvarchar(50), 
	@InvoiceDate nvarchar(50), 
	@InvoiceNo nvarchar(50), 
	@IsSuccess int, 
	@UserInfo nvarchar(50),
	@CreatedDateTime datetime

AS
BEGIN

	DECLARE @RetVal			INT  		/*RetVal from called SP. =0 for success;<>0 for failure*/              
		, @ErrMsg		VARCHAR(2048)    /*Error Message*/            
		, @ErrorSeverity	INT             /*Error Number*/   
		, @RowCount		INT		/*Row Count*/

BEGIN TRY

    INSERT INTO
		tblInvoice 
	(
		OrderNo,
		LineNum,
		Pos,
		DelQty,
		InvoiceDate,
		InvoiceNumber,
		IsSuccess,
		CreatedBy,
		CreatedOn,
		UpdatedBy,
		UpdatedOn
	)
	VALUES
	(
		@OrderNum,
		@LineNum,
		@Pos,
	 	@DelQty,
		@InvoiceDate,
		@InvoiceNo,
		@IsSuccess,
		@UserInfo,
		@CreatedDateTime,
		@UserInfo,
		@CreatedDateTime
	)

END TRY 
	BEGIN CATCH 
		SELECT @ErrMsg = ERROR_MESSAGE(),
		           @ErrorSeverity = ERROR_SEVERITY();

		RAISERROR(@ErrMsg, @ErrorSeverity, 1) 
		SELECT @RetVal = 9999
		RETURN 9999
	END CATCH 

	RETURN @RetVal
    
END
GO
/****** Object:  StoredProcedure [dbo].[spInsertUserLogin]    Script Date: 09/27/2015 17:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spInsertUserLogin]

/******************************************************************************
** Program Property of ArunKumar Amarnath
** Filename	  	 		: spInsertUserLogin.sql
** Database Object Name : spInsertUserLogin
** Author		 		: ArunKumar Amarnath
** Create Date		 	: 25/06/2015
** Project/System	 	: Velan Valves
** Subproject/Subsystem	: BaaN Management
** Purpose/Description	: For Creating New User
** Input Parameters	 	: @UserName, @Password, @UserInfo, @CreatedDateTime
** Output Parameters	: --
** Database		 		: VV
** Other Databases Accessed 		: N/A
** Tables		 		: UserLogin
** Rerunable			: Yes
****************************************************************************** 
** Modifications:
** Date				Name			Description
** -----------	------------------	---------------
** 08/08/2015	ArunKumar Amarnath	Initial Version
******************************************************************************/

	@UserName nvarchar(50), 
	@Password nvarchar(50),
	@UserInfo nvarchar(50),
	@CreatedDateTime datetime

AS
BEGIN

	DECLARE @RetVal			INT  		/*RetVal from called SP. =0 for success;<>0 for failure*/              
		, @ErrMsg		VARCHAR(2048)    /*Error Message*/            
		, @ErrorSeverity	INT             /*Error Number*/   
		, @RowCount		INT		/*Row Count*/

BEGIN TRY

	INSERT INTO
		Login 
		(
			UserName,
			Password,
			CreatedBy,
			CreatedOn,
			UpdatedBy,
			UpdatedOn
		)
	VALUES
		(
			@UserName,
			@Password,
			@UserInfo,
			@CreatedDateTime,
			@UserInfo,
			@CreatedDateTime
		)

END TRY 
	BEGIN CATCH 
		SELECT @ErrMsg = ERROR_MESSAGE(),
		           @ErrorSeverity = ERROR_SEVERITY();

		RAISERROR(@ErrMsg, @ErrorSeverity, 1) 
		SELECT @RetVal = 9999
		RETURN 9999
	END CATCH 

	RETURN @RetVal
    
END
GO
/****** Object:  StoredProcedure [dbo].[spInsertScreenAccess]    Script Date: 09/27/2015 17:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spInsertScreenAccess]

/******************************************************************************
** Program Property of ArunKumar Amarnath
** Filename	  	 		: spInsertScreenAccess.sql
** Database Object Name : spInsertScreenAccess
** Author		 		: ArunKumar Amarnath
** Create Date		 	: 25/06/2015
** Project/System	 	: Velan Valves
** Subproject/Subsystem	: BaaN Management
** Purpose/Description	: For Creating Screen Access for the User
** Input Parameters	 	: @UserName, @UserInfo, @CreatedDateTime
** Output Parameters	: --
** Database		 		: VV
** Other Databases Accessed 		: N/A
** Tables		 		: Screen Access
** Rerunable			: Yes
****************************************************************************** 
** Modifications:
** Date				Name			Description
** -----------	------------------	---------------
** 08/08/2015	ArunKumar Amarnath	Initial Version
******************************************************************************/

	@UserName nvarchar(50), 
	@UserInfo nvarchar(50),
	@CreatedDateTime datetime

AS
BEGIN

	DECLARE @RetVal			INT  		/*RetVal from called SP. =0 for success;<>0 for failure*/              
		, @ErrMsg		VARCHAR(2048)    /*Error Message*/            
		, @ErrorSeverity	INT             /*Error Number*/   
		, @RowCount		INT		/*Row Count*/

BEGIN TRY

	INSERT INTO ScreenAccess VALUES (@UserName,'Import From BaaN',0,'Planning',1,0,@UserInfo,@CreatedDateTime,@UserInfo,@CreatedDateTime);
	INSERT INTO ScreenAccess VALUES (@UserName,'Production Release',1,'Planning',1,0,@UserInfo,@CreatedDateTime,@UserInfo,@CreatedDateTime);
	INSERT INTO ScreenAccess VALUES (@UserName,'Invoiced Data Importing',2,'Planning',1,0,@UserInfo,@CreatedDateTime,@UserInfo,@CreatedDateTime);
	INSERT INTO ScreenAccess VALUES (@UserName,'Freeze Plan',3,'Planning',1,0,@UserInfo,@CreatedDateTime,@UserInfo,@CreatedDateTime);
	INSERT INTO ScreenAccess VALUES (@UserName,'Release Plan',4,'Planning, Plan Review',1,0,@UserInfo,@CreatedDateTime,@UserInfo,@CreatedDateTime);
	INSERT INTO ScreenAccess VALUES (@UserName,'FG Plan',5,'Planning, Plan Review',1,0,@UserInfo,@CreatedDateTime,@UserInfo,@CreatedDateTime);
	INSERT INTO ScreenAccess VALUES (@UserName,'Sales Plan',6,'Planning, Plan Review',1,0,@UserInfo,@CreatedDateTime,@UserInfo,@CreatedDateTime);
	INSERT INTO ScreenAccess VALUES (@UserName,'Order Status Report',7,'Planning, Reports',1,0,@UserInfo,@CreatedDateTime,@UserInfo,@CreatedDateTime);
	INSERT INTO ScreenAccess VALUES (@UserName,'ToRelease Report',8,'Planning, Reports',1,0,@UserInfo,@CreatedDateTime,@UserInfo,@CreatedDateTime);
	INSERT INTO ScreenAccess VALUES (@UserName,'SO Backlog Report',9,'Planning, Reports',1,0,@UserInfo,@CreatedDateTime,@UserInfo,@CreatedDateTime);
	INSERT INTO ScreenAccess VALUES (@UserName,'WIP To FG',0,'Production',2,0,@UserInfo,@CreatedDateTime,@UserInfo,@CreatedDateTime);
	INSERT INTO ScreenAccess VALUES (@UserName,'Prod Completion',1,'Production',2,0,@UserInfo,@CreatedDateTime,@UserInfo,@CreatedDateTime);
	INSERT INTO ScreenAccess VALUES (@UserName,'WIP Report',2,'Production',2,0,@UserInfo,@CreatedDateTime,@UserInfo,@CreatedDateTime);
	INSERT INTO ScreenAccess VALUES (@UserName,'TPI Offering',0,'Quality',3,0,@UserInfo,@CreatedDateTime,@UserInfo,@CreatedDateTime);
	INSERT INTO ScreenAccess VALUES (@UserName,'TPI Pending Report',1,'Quality',3,0,@UserInfo,@CreatedDateTime,@UserInfo,@CreatedDateTime);
	INSERT INTO ScreenAccess VALUES (@UserName,'ITP GAD Info',0,'Sales',4,0,@UserInfo,@CreatedDateTime,@UserInfo,@CreatedDateTime);
	INSERT INTO ScreenAccess VALUES (@UserName,'Stock Code Tag No Import',1,'Sales',4,0,@UserInfo,@CreatedDateTime,@UserInfo,@CreatedDateTime);
	INSERT INTO ScreenAccess VALUES (@UserName,'SCN Input',2,'Sales',4,0,@UserInfo,@CreatedDateTime,@UserInfo,@CreatedDateTime);
	INSERT INTO ScreenAccess VALUES (@UserName,'Commercial',3,'Sales',4,0,@UserInfo,@CreatedDateTime,@UserInfo,@CreatedDateTime);
	INSERT INTO ScreenAccess VALUES (@UserName,'QR And QA',4,'Sales',4,0,@UserInfo,@CreatedDateTime,@UserInfo,@CreatedDateTime);
	INSERT INTO ScreenAccess VALUES (@UserName,'QR And QA Sales Summary',5,'Sales',4,0,@UserInfo,@CreatedDateTime,@UserInfo,@CreatedDateTime);
	INSERT INTO ScreenAccess VALUES (@UserName,'Commercial',6,'Sales',4,0,@UserInfo,@CreatedDateTime,@UserInfo,@CreatedDateTime);
	INSERT INTO ScreenAccess VALUES (@UserName,'Assembly Order Processing',0,'Print',5,0,@UserInfo,@CreatedDateTime,@UserInfo,@CreatedDateTime);
	INSERT INTO ScreenAccess VALUES (@UserName,'Create New User',0,'System Utility',6,0,@UserInfo,@CreatedDateTime,@UserInfo,@CreatedDateTime);
	INSERT INTO ScreenAccess VALUES (@UserName,'Update Role Access',1,'System Utility',6,0,@UserInfo,@CreatedDateTime,@UserInfo,@CreatedDateTime);
	INSERT INTO ScreenAccess VALUES (@UserName,'Change Password',2,'System Utility',6,0,@UserInfo,@CreatedDateTime,@UserInfo,@CreatedDateTime);


END TRY 
	BEGIN CATCH 
		SELECT @ErrMsg = ERROR_MESSAGE(),
		           @ErrorSeverity = ERROR_SEVERITY();

		RAISERROR(@ErrMsg, @ErrorSeverity, 1) 
		SELECT @RetVal = 9999
		RETURN 9999
	END CATCH 

	RETURN @RetVal
    
END
GO
/****** Object:  StoredProcedure [dbo].[spInsertMISSalesInput]    Script Date: 09/27/2015 17:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spInsertMISSalesInput]

/******************************************************************************
** Program Property of ArunKumar Amarnath
** Filename	  	 		: spInsertMISSalesInput.sql
** Database Object Name : spInsertMISSalesInput
** Author		 		: ArunKumar Amarnath
** Create Date		 	: 25/06/2015
** Project/System	 	: Velan Valves
** Subproject/Subsystem	: BaaN Management
** Purpose/Description	: For Inserting the data into the MISSalesInput for the chosen Record
** Input Parameters	 	: @OrderNum, @LineNum, @Pos, @SAPCode, @StockCode, @O2, @H2, @IBR, @ASU, @UserInfo, @CreatedDateTime, @TAGNo, @GADNo, @QCINo, @ReleaseDate
** Output Parameters	: --
** Database		 		: VV
** Other Databases Accessed 		: N/A
** Tables		 		: MISSalesInput
** Rerunable			: Yes
****************************************************************************** 
** Modifications:
** Date				Name			Description
** -----------	------------------	---------------
** 25/06/2015	ArunKumar Amarnath	Initial Version
** 15/07/2015	ArunKumar Amarnath	Added 4 more additonal input params
******************************************************************************/

	@OrderNum int,
	@LineNum nvarchar(50),
	@Pos int,
	@SAPCode nvarchar(50), 
	@StockCode nvarchar(50), 
	@O2 nvarchar(50), 
	@H2 nvarchar(50), 
	@IBR nvarchar(50), 
	@ASU nvarchar(50),
	@TAGNo nvarchar(50),
	@GADNo nvarchar(50),
	@QCINo nvarchar(50),
	@ReleaseDate nvarchar(50),
	@UserInfo nvarchar(50),
	@CreatedDateTime datetime

AS
BEGIN

	DECLARE @RetVal			INT  		/*RetVal from called SP. =0 for success;<>0 for failure*/              
		, @ErrMsg		VARCHAR(2048)    /*Error Message*/            
		, @ErrorSeverity	INT             /*Error Number*/   
		, @RowCount		INT		/*Row Count*/

BEGIN TRY

    INSERT INTO
		MISSalesInput 
	(
		OrderNo,
		LineNum,
		Pos,
		SAPCode,
		StockCode,
		O2,
		H2,
		IBR,
		ASU,
		TAGNo,
		GADNo,
		QCINo,
		RelDate,
		CreatedBy,
		CreatedOn,
		UpdatedBy,
		UpdatedOn
	)
	VALUES
	(
		@OrderNum,
		@LineNum,
		@Pos,
	 	@SAPCode,
		@StockCode,
		@O2,
		@H2,
		@IBR,
		@ASU,
		@TAGNo,
		@GADNo,
		@QCINo,
		@ReleaseDate,
		@UserInfo,
		@CreatedDateTime,
		@UserInfo,
		@CreatedDateTime
	)

END TRY 
	BEGIN CATCH 
		SELECT @ErrMsg = ERROR_MESSAGE(),
		           @ErrorSeverity = ERROR_SEVERITY();

		RAISERROR(@ErrMsg, @ErrorSeverity, 1) 
		SELECT @RetVal = 9999
		RETURN 9999
	END CATCH 

	RETURN @RetVal
    
END
GO
/****** Object:  StoredProcedure [dbo].[spInsertMISFinanceInput]    Script Date: 09/27/2015 17:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spInsertMISFinanceInput]

/******************************************************************************
** Program Property of ArunKumar Amarnath
** Filename	  	 		: spInsertMISFinanceInput.sql
** Database Object Name : spInsertMISFinanceInput
** Author		 		: ArunKumar Amarnath
** Create Date		 	: 25/06/2015
** Project/System	 	: Velan Valves
** Subproject/Subsystem	: BaaN Management
** Purpose/Description	: For Inserting the data into the MISFinanceInput for the chosen Record
** Input Parameters	 	: @OrderNum, @LineNum, @Pos, @ABG, @PBG, @RP, @ITP, @ApprovedITP, @GAD, @ApprovedGAD, @Inspection1, @Inspection2, @UserInfo, @CreatedDateTime
** Output Parameters	: --
** Database		 		: VV
** Other Databases Accessed 		: N/A
** Tables		 		: MISFinanceInput
** Rerunable			: Yes
****************************************************************************** 
** Modifications:
** Date				Name			Description
** -----------	------------------	---------------
** 25/06/2015	ArunKumar Amarnath	Initial Version
** 11/07/2015	ArunKumar Amarnath	Added 6 more Input cols
******************************************************************************/

	@OrderNum int,
	@LineNum nvarchar(50),
	@Pos int,
	@ABG nvarchar(50), 
	@PBG nvarchar(50), 
	@RP nvarchar(50), 
	@ITP nvarchar(50), 
	@ApprovedITP nvarchar(50), 
	@GAD nvarchar(50), 
	@ApprovedGAD nvarchar(50), 
	@Inspection1 nvarchar(50), 
	@Inspection2 nvarchar(50),
	@UserInfo nvarchar(50),
	@CreatedDateTime datetime

AS
BEGIN

	DECLARE @RetVal			INT  		/*RetVal from called SP. =0 for success;<>0 for failure*/              
		, @ErrMsg		VARCHAR(2048)    /*Error Message*/            
		, @ErrorSeverity	INT             /*Error Number*/   
		, @RowCount		INT		/*Row Count*/

BEGIN TRY

    INSERT INTO
		MISFinanceInput 
	(
		OrderNo,
		LineNum,
		Pos,
		ABG,
		PBG,
		RP,
		ITP, 
		ApprovedITP, 
		GAD, 
		ApprovedGAD, 
		Inspection1, 
		Inspection2,
		CreatedBy,
		CreatedOn,
		UpdatedBy,
		UpdatedOn
	)
	VALUES
	(
		@OrderNum,
		@LineNum,
		@Pos,
	 	@ABG,
		@PBG,
		@RP,
		@ITP, 
		@ApprovedITP, 
		@GAD, 
		@ApprovedGAD, 
		@Inspection1, 
		@Inspection2,
		@UserInfo,
		@CreatedDateTime,
		@UserInfo,
		@CreatedDateTime
	)

END TRY 
	BEGIN CATCH 
		SELECT @ErrMsg = ERROR_MESSAGE(),
		           @ErrorSeverity = ERROR_SEVERITY();

		RAISERROR(@ErrMsg, @ErrorSeverity, 1) 
		SELECT @RetVal = 9999
		RETURN 9999
	END CATCH 

	RETURN @RetVal
    
END
GO
/****** Object:  StoredProcedure [dbo].[spGetTPIOfferingData]    Script Date: 09/27/2015 17:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetTPIOfferingData]

/******************************************************************************
** Program Property of ArunKumar Amarnath
** Filename	  	 		: spGetTPIOfferingData.sql
** Database Object Name	 		: spGetTPIOfferingData
** Author		 		: ArunKumar Amarnath
** Create Date		 		: 22/06/2015
** Project/System	 		: Velan Valves
** Subproject/Subsystem	 		: BaaN Management
** Purpose/Description	 		: For getting the Imported data
** Input Parameters	 		: --
** Output Parameters	 		: All Columns
** Database		 		: VV
** Other Databases Accessed 		: N/A
** Tables		 		: MISOrderStatus, ProductionReleaseNew
** Rerunable				: Yes
****************************************************************************** 
** Modifications:
** Date				Name			Description
** -----------	------------------	---------------
** 22/06/2015	ArunKumar Amarnath	Initial Version
******************************************************************************/

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT
		PRN.ProdOrderNo,
		PRN.SerialNo,
		PRN.BalanceQty,
		PRN.OrderNum,
		PRN.LineNum,
		PRN.Pos,
		MISOS.Item AS 'FigNo',
		MISOS.[Description] as 'Descr',
		PRN.ProdDeliveryDate,
		PRN.ProdComplDate,
		PRN.ProdRemarks,
		PRN.TPIOfferDate,
		PRN.QCRemarks,
		PRN.IRNComplDate
	FROM
		MISOrderStatus MISOS
	JOIN 
		ProductionReleaseNew PRN
		ON PRN.OrderNum = MISOS.OrderNo
		AND PRN.Pos = MISOS.Pos
	WHERE
		PRN.SerialNo IS NOT NULL AND
		PRN.BalanceQty > 0  and prn.prodremarks='Under TPI'
	ORDER BY
		PRN.SerialNo ASC
END
GO
/****** Object:  StoredProcedure [dbo].[spGetScreenAccessInfoForEmployee]    Script Date: 09/27/2015 17:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetScreenAccessInfoForEmployee]

/******************************************************************************
** Program Property of ArunKumar Amarnath
** Filename	  	 		: spGetScreenAccessInfoForEmployee.sql
** Database Object Name	: spGetScreenAccessInfoForEmployee
** Author		 		: ArunKumar Amarnath
** Create Date		 	: 09/08/2015
** Project/System	 	: Velan Valves
** Subproject/Subsystem	: BaaN Management
** Purpose/Description	: To update the Authorization of Screens to an User
** Input Parameters	 	: @UserName
** Output Parameters	: ScreenAccessID, MenuName
** Database		 		: VV
** Other Databases Accessed 		: N/A
** Tables		 		: ScreenAccess
** Rerunable			: Yes
****************************************************************************** 
** Modifications:
** Date				Name			Description
** -----------	------------------	---------------
** 08/08/2015	ArunKumar Amarnath	Initial Version
******************************************************************************/

	@UserName nvarchar(50)
AS
BEGIN
	SELECT 
		ScreenAccessID,
		MenuName,
		HasAccess
	FROM 
		ScreenAccess 
	WHERE
		UserName = @UserName;
END
GO
/****** Object:  StoredProcedure [dbo].[spGetScreenAccessInfo]    Script Date: 09/27/2015 17:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetScreenAccessInfo]

/******************************************************************************
** Program Property of ArunKumar Amarnath
** Filename	  	 		: spGetScreenAccessInfo.sql
** Database Object Name	: spGetScreenAccessInfo
** Author		 		: ArunKumar Amarnath
** Create Date		 	: 21/06/2015
** Project/System	 	: Velan Valves
** Subproject/Subsystem	: BaaN Management
** Purpose/Description	: Login/ Authentication
** Input Parameters	 	: UserName
** Output Parameters	: Screen Access Info
** Database		 		: VV
** Other Databases Accessed 		: N/A
** Tables		 		: ScreenAccess
** Rerunable			: Yes
****************************************************************************** 
** Modifications:
** Date				Name			Description
** -----------	------------------	---------------
** 08/08/2015	ArunKumar Amarnath	Initial Version
******************************************************************************/

	@UserName nvarchar(50)
AS
BEGIN
	SELECT 
		MenuName,
		MenuID,
		ParentMenuName,
		ParentMenuID
	FROM 
		ScreenAccess 
	WHERE
		UserName = @UserName  
		AND HasAccess=1;
END
GO
/****** Object:  StoredProcedure [dbo].[spGetSCNInputData]    Script Date: 09/27/2015 17:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetSCNInputData]

/******************************************************************************
** Program Property of ArunKumar Amarnath
** Filename	  	 		: spGetSCNInputData.sql
** Database Object Name	 		: spGetSCNInputData
** Author		 		: ArunKumar Amarnath
** Create Date		 		: 22/06/2015
** Project/System	 		: Velan Valves
** Subproject/Subsystem	 		: BaaN Management
** Purpose/Description	 		: For getting the Imported data
** Input Parameters	 		: --
** Output Parameters	 		: All Columns
** Database		 		: VV
** Other Databases Accessed 		: N/A
** Tables		 		: MISOrderStatus, ProductionReleaseNew
** Rerunable				: Yes
****************************************************************************** 
** Modifications:
** Date				Name			Description
** -----------	------------------	---------------
** 22/06/2015	ArunKumar Amarnath	Initial Version
******************************************************************************/

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT
		PRN.ProdOrderNo,
		PRN.SerialNo,
		PRN.BalanceQty,
		PRN.OrderNum,
		PRN.LineNum,
		PRN.Pos,
		MISOS.Item AS 'FigNo',
		MISOS.[Description] as 'Descr',
		PRN.ProdDeliveryDate,
		PRN.ProdComplDate,
		PRN.ProdRemarks,
		PRN.TPIOfferDate,
		PRN.QCRemarks,
		PRN.IRNComplDate,
		PRN.SCNComplDate
	FROM
		MISOrderStatus MISOS
	JOIN 
		ProductionReleaseNew PRN
		ON PRN.OrderNum = MISOS.OrderNo
		AND PRN.Pos = MISOS.Pos
	WHERE
		PRN.SerialNo IS NOT NULL AND
		COALESCE(PRN.SerialNo,'') != '' 
	ORDER BY
		PRN.SerialNo ASC
END
GO
/****** Object:  StoredProcedure [dbo].[spGetSalesPlanData]    Script Date: 09/27/2015 17:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetSalesPlanData]

/******************************************************************************
** Program Property of ArunKumar Amarnath
** Filename	  	 		: spGetSalesPlanData.sql
** Database Object Name	 		: spGetSalesPlanData
** Author		 		: ArunKumar Amarnath
** Create Date		 		: 01/08/2015
** Project/System	 		: Velan Valves
** Subproject/Subsystem	 		: BaaN Management
** Purpose/Description	 		: For getting the Sales Plan Data
** Input Parameters	 		: @WeekNo
** Output Parameters	 		: All Qty Data
** Database		 		: VV
** Other Databases Accessed 		: N/A
** Tables		 		: MISOrderStatus, MISFinal
** Rerunable				: Yes
****************************************************************************** 
** Modifications:
** Date				Name			Description
** -----------	------------------	---------------
** 01/08/2015	ArunKumar Amarnath	Initial Version
** 05/08/2015	ArunKumar Amarnath	Updated the calculation of Val for all qty
******************************************************************************/
@WeekNo int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT
		MISPlan.Orderno,
		MISPlan.FGWeek as 'WeekNo', 
		MISPlan.pos, 
		MISPlan.customername as 'Customer', 
		MISPlan.invoicedqty as 'PlanInvQty', 
		MISPlan.fgqty as 'PlanFGQty', 
		MISPlan.wipqty as 'PlanWIPQty', 
		MISPlan.toreleaseqty as 'PlanToRelQty', 
	--	(MISorderstatus.amount/MISOrderstatus.balanceqty) as Rate, 
		(MISPlan.invoicedqty*(MISPlan.amount)) as 'PlanInvVal', 
		(MISPlan.fgqty*(MISPlan.amount)) as 'PlanFGVal', 
		(MISPlan.wipqty*(MISPlan.amount)) as 'PlanWIPVal', 
		(MISPlan.toreleaseqty*(MISPlan.amount)) as 'PlanToRelVal', 
		MISOrderstatus.invoicedqty as 'InvQty', 
		MISOrderstatus.fgqty as 'FGQty', 
		MISOrderstatus.wipqty as 'WIPQty', 
		MISOrderstatus.toreleaseqty as 'ToRelQty', 
	--	(MISorderstatus.amount/MISOrderstatus.balanceqty) as Rate, 
		(MISOrderstatus.invoicedqty*(MISorderstatus.amount)) as 'InvVal', 
		(MISOrderstatus.fgqty*(MISorderstatus.amount)) as 'FGVal', 
		(MISOrderstatus.wipqty*(MISorderstatus.amount)) as 'WIPVal', 
		(MISOrderstatus.toreleaseqty*(MISorderstatus.amount)) as 'ToRelVal'
	FROM 
		MISOrderStatus
		JOIN MISFinal MISPlan
		on MISOrderStatus.OrderNo = MISPlan.OrderNo
		AND MISOrderStatus.Pos = MISPlan.Pos
	WHERE
		(
			COALESCE(MISPlan.toreleaseqty,0) > 0 OR 
			COALESCE(MISPlan.WIPQty,0) > 0 OR
			COALESCE(MISPlan.FGQTY,0) > 0
		)
	AND
		MISPlan.FGWeek >= @WeekNo 
	AND
		MISPlan.FGWeek <= @WeekNo + 3
	ORDER BY
		MISPlan.FGWeek, MISPlan.OrderNo, MISPlan.Pos
	
END
GO
/****** Object:  StoredProcedure [dbo].[spGetReportData]    Script Date: 09/27/2015 17:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetReportData]

/******************************************************************************
** Program Property of ArunKumar Amarnath
** Filename	  	 		: spGetReportData.sql
** Database Object Name	 		: spGetReportData
** Author		 		: ArunKumar Amarnath
** Create Date		 		: 16/07/2015
** Project/System	 		: Velan Valves
** Subproject/Subsystem	 		: BaaN Management
** Purpose/Description	 		: For getting the data for report generation
** Input Parameters	 		: @ReportName
** Output Parameters	 		: All Columns
** Database		 		: VV
** Other Databases Accessed 		: N/A
** Tables		 		: MISOrderStatus, ProductionReleaseNew
** Rerunable				: Yes
****************************************************************************** 
** Modifications:
** Date				Name			Description
** -----------	------------------	---------------
** 16/07/2015	ArunKumar Amarnath	Initial Version
** 08/08/2015	ArunKumar Amarnath	Added one more report script for SO BackLog
******************************************************************************/
@ReportName nvarchar(50)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    IF (@ReportName = 'ORDERSTATUS')
	BEGIN
		SELECT
			OrderNo,
			Pos,
			CustomerName, 
			Item as 'Fig No',
			Description,
			OrderQty,
			BalanceQty,
			InvoicedQty,
			FGQty,
			WIPQty,
			ToReleaseQty 
		FROM
			MISOrderStatus
		WHERE
			BalanceQty > 0
		ORDER BY
			OrderNo, Pos;
	END
	ELSE IF (@ReportName = 'WIP')
	BEGIN
		SELECT
			PRN.OrderNum as 'OrderNo',
			PRN.Pos,
			MISOS.CustomerName, 
			MISOS.Item as 'Fig No', 
			MISOS.Description, 
			PRN.ProdOrderNo,
			PRN.SerialNo,
			PRN.ProdRemarks
		FROM
			ProductionReleaseNew PRN
			JOIN MISOrderStatus MISOS
			ON MISOS.OrderNo = PRN.OrderNum
			AND MISOS.LineNum = PRN.LineNum
			AND MISOS.Pos = PRN.Pos
		WHERE
			PRN.BalanceQty > 0 
			ORDER BY
			PRN.SerialNo ASC;
	END
	ELSE IF (@ReportName = 'TORELEASE')
	BEGIN
		SELECT 
			OrderNo,
			Pos,
			CustomerName, 
			Item as 'Fig No',
			Description,
			ToReleaseQty,
			RelDate as 'Release Date'
		FROM 
			MISOrderStatus
		WHERE
			ToReleaseQty > 0
		ORDER BY
			OrderNo, Pos ASC
	END
	ELSE IF (@ReportName = 'TPIPENDING')
	BEGIN
		SELECT        PRN.OrderNum AS 'OrderNo', PRN.Pos, MISOS.CustomerName, MISOS.Item AS 'Fig No', MISOS.Description, MISOS.CustomerOrderNo AS 'CustomerPONo', 
                         PRN.LineNum AS 'Line#', MISSI.SAPCode, MISSI.StockCode, MISSI.TAGNo, MISSI.GADNo, MISOS.OrderQty, PRN.ProdOrderNo, PRN.SerialNo, 
                         PRN.ProdDeliveryDate, PRN.ProdRemarks
FROM            ProductionReleaseNew AS PRN INNER JOIN
                         MISOrderStatus AS MISOS ON MISOS.OrderNo = PRN.OrderNum AND MISOS.LineNum = PRN.LineNum AND MISOS.Pos = PRN.Pos LEFT OUTER JOIN
                         MISSalesInput AS MISSI ON MISOS.OrderNo = MISSI.OrderNo AND MISOS.LineNum = MISSI.LineNum AND MISOS.Pos = MISSI.Pos
WHERE        (PRN.BalanceQty > 0) and prn.serialno<> ' ' and prn.prodremarks='Under TPI'
			
	END
	ELSE IF (@ReportName = 'SOBACKLOG')
	BEGIN
		SELECT        MOS.OrderType, MOS.OrderNo, MOS.CustomerName, MOS.CustomerOrderNo, MOS.LineNum, MOS.Pos, MOS.Item, MOS.Description, MSI.O2, MSI.H2, MSI.IBR, 
                         MSI.ASU, MOS.OrderDate, MOS.OriginalPromDate, MOS.PlannedDelDate, MOS.OrderQty, MOS.BalanceQty, MOS.PlanWeek, MOS.WIPWeek, MOS.FGWeek, 
                         MOS.InvoicedQty, MOS.FGQty, MOS.WIPQty, MOS.ToReleaseQty, MOS.Amount * MOS.BalanceQty AS 'Amount', MOS.Amount AS 'Unit Rate', 
                         MOS.Amount * MOS.InvoicedQty AS 'InvoicedVal', MOS.Amount * MOS.FGQty AS 'FG-Val', MOS.Amount * MOS.WIPQty AS 'WIP-Val', 
                         MOS.Amount * MOS.ToReleaseQty AS 'To Rlse-Val', ' ' AS RelDate, ' ' AS ProdCompletionDate, ' ' AS ProdRemarks, ' ' AS TPIOfferDate, ' ' AS SCNComplDate
FROM            MISOrderStatus AS MOS LEFT OUTER JOIN
                         MISSalesInput AS MSI ON MOS.OrderNo = MSI.OrderNo AND MOS.LineNum = MSI.LineNum AND MOS.Pos = MSI.Pos where mos.balanceqty>0
ORDER BY MOS.OrderNo, MOS.Pos
	
	END
END
GO
/****** Object:  StoredProcedure [dbo].[spGetReleasePlanData]    Script Date: 09/27/2015 17:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetReleasePlanData]

/******************************************************************************
** Program Property of ArunKumar Amarnath
** Filename	  	 		: spGetReleasePlanData.sql
** Database Object Name	 		: spGetReleasePlanData
** Author		 		: ArunKumar Amarnath
** Create Date		 		: 01/08/2015
** Project/System	 		: Velan Valves
** Subproject/Subsystem	 		: BaaN Management
** Purpose/Description	 		: For getting the Release Data
** Input Parameters	 		: @WeekNo
** Output Parameters	 		: All Qty Data
** Database		 		: VV
** Other Databases Accessed 		: N/A
** Tables		 		: MISOrderStatus, MISFinal
** Rerunable				: Yes
****************************************************************************** 
** Modifications:
** Date				Name			Description
** -----------	------------------	---------------
** 01/08/2015	ArunKumar Amarnath	Initial Version
** 05/08/2015	ArunKumar Amarnath	Updated the calculation of Val for all qty
******************************************************************************/
@WeekNo int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT
		MISPlan.Orderno,
		MISPlan.PlanWeek as 'WeekNo', 
		MISPlan.pos, 
		MISPlan.customername as 'Customer', 
		MISPlan.invoicedqty as 'PlanInvQty', 
		MISPlan.fgqty as 'PlanFGQty', 
		MISPlan.wipqty as 'PlanWIPQty', 
		MISPlan.toreleaseqty as 'PlanToRelQty', 
	--	(MISorderstatus.amount/MISOrderstatus.balanceqty) as Rate, 
		(MISPlan.invoicedqty*(MISPlan.amount)) as 'PlanInvVal', 
		(MISPlan.fgqty*(MISPlan.amount)) as 'PlanFGVal', 
		(MISPlan.wipqty*(MISPlan.amount)) as 'PlanWIPVal', 
		(MISPlan.toreleaseqty*(MISPlan.amount)) as 'PlanToRelVal', 
		MISOrderstatus.invoicedqty as 'InvQty', 
		MISOrderstatus.fgqty as 'FGQty', 
		MISOrderstatus.wipqty as 'WIPQty', 
		MISOrderstatus.toreleaseqty as 'ToRelQty', 
	--	(MISorderstatus.amount/MISOrderstatus.balanceqty) as Rate, 
		(MISOrderstatus.invoicedqty*(MISorderstatus.amount)) as 'InvVal', 
		(MISOrderstatus.fgqty*(MISorderstatus.amount)) as 'FGVal', 
		(MISOrderstatus.wipqty*(MISorderstatus.amount)) as 'WIPVal', 
		(MISOrderstatus.toreleaseqty*(MISorderstatus.amount)) as 'ToRelVal'
	FROM 
		MISOrderStatus
		JOIN MISFinal MISPlan
		on MISOrderStatus.OrderNo = MISPlan.OrderNo
		AND MISOrderStatus.Pos = MISPlan.Pos
	WHERE
		MISPlan.toreleaseqty > 0
	AND
		MISPlan.PlanWeek >= @WeekNo 
	AND
		MISPlan.PlanWeek <= @WeekNo + 3
	ORDER BY
		MISPlan.PlanWeek, MISPlan.OrderNo, MISPlan.Pos
	
END
GO
/****** Object:  StoredProcedure [dbo].[spGetQRAndQASalesSummary]    Script Date: 09/27/2015 17:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetQRAndQASalesSummary]

/******************************************************************************
** Program Property of ArunKumar Amarnath
** Filename	  	 		: spGetQRAndQASalesSummary.sql
** Database Object Name	 		: spGetQRAndQASalesSummary
** Author		 		: ArunKumar Amarnath
** Create Date		 		: 01/08/2015
** Project/System	 		: Velan Valves
** Subproject/Subsystem	 		: BaaN Management
** Purpose/Description	 		: For getting the QR & QA Sales Summary Data
** Input Parameters	 		: @OrderType, @WeekNo
** Output Parameters	 		: All Data
** Database		 		: VV
** Other Databases Accessed 		: N/A
** Tables		 		: MISOrderStatus, MISFinanceInput
** Rerunable				: Yes
****************************************************************************** 
** Modifications:
** Date				Name			Description
** -----------	------------------	---------------
** 01/08/2015	ArunKumar Amarnath	Initial Version
******************************************************************************/
@OrderType nvarchar(50),
@WeekNo int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

SELECT
	MOS.CustomerName, 
	MFI.OrderNo, 
	SUM(MOS.BalanceQty * MOS.Amount) as Amount, 
	SUM(MOS.ToReleaseQty * MOS.Amount) as 'Month1',
	' ' as 'Month2',
	' ' as 'Month3',
	MFI.ITP, 
	MFI.ApprovedITP as 'AITP', 
	MFI.GAD, 
	MFI.ApprovedGAD as 'AGAD', 
	MFI.Inspection1, 
	MFI.Inspection2
FROM
	MISOrderStatus MOS
	JOIN MISFinanceInput MFI
	on MFI.OrderNo = MOS.OrderNo
WHERE
	MOS.PlanWeek >= @WeekNo 
	AND MOS.PlanWeek <= @WeekNo + 3
	AND MOS.OrderType IN (SELECT Value FROM dbo.fn_Split(@OrderType, ','))
GROUP BY
	MOS.CustomerName, MFI.OrderNo, MFI.ITP, MFI.ApprovedITP, MFI.GAD, MFI.ApprovedGAD, MFI.Inspection1, MFI.Inspection2
	
UNION

SELECT
	MOS.CustomerName, 
	MFI.OrderNo, 
	SUM(MOS.BalanceQty * MOS.Amount) as Amount, 
	' ' as 'Month1',
	SUM(MOS.ToReleaseQty * MOS.Amount) as 'Month2',
	' ' as 'Month3',
	MFI.ITP, 
	MFI.ApprovedITP as 'AITP', 
	MFI.GAD, 
	MFI.ApprovedGAD as 'AGAD', 
	MFI.Inspection1, 
	MFI.Inspection2
FROM
	MISOrderStatus MOS
	JOIN MISFinanceInput MFI
	on MFI.OrderNo = MOS.OrderNo
WHERE
	MOS.PlanWeek >= @WeekNo + 4
	AND MOS.PlanWeek <= @WeekNo + 7
	AND MOS.OrderType IN (SELECT Value FROM dbo.fn_Split(@OrderType, ','))
GROUP BY
	MOS.CustomerName, MFI.OrderNo, MFI.ITP, MFI.ApprovedITP, MFI.GAD, MFI.ApprovedGAD, MFI.Inspection1, MFI.Inspection2
	

UNION

SELECT
	MOS.CustomerName, 
	MFI.OrderNo, 
	SUM(MOS.BalanceQty * MOS.Amount) as Amount, 
	' ' as 'Month1',
	' ' as 'Month2',
	SUM(MOS.ToReleaseQty * MOS.Amount) as 'Month3',
	MFI.ITP, 
	MFI.ApprovedITP as 'AITP', 
	MFI.GAD, 
	MFI.ApprovedGAD as 'AGAD', 
	MFI.Inspection1, 
	MFI.Inspection2
FROM
	MISOrderStatus MOS
	JOIN MISFinanceInput MFI
	on MFI.OrderNo = MOS.OrderNo
WHERE
	MOS.PlanWeek >= @WeekNo + 8
	AND MOS.PlanWeek <= @WeekNo + 11
	AND MOS.OrderType IN (SELECT Value FROM dbo.fn_Split(@OrderType, ','))
GROUP BY
	MOS.CustomerName, MFI.OrderNo, MFI.ITP, MFI.ApprovedITP, MFI.GAD, MFI.ApprovedGAD, MFI.Inspection1, MFI.Inspection2

	
END
GO
/****** Object:  StoredProcedure [dbo].[spGetQRAndQAData]    Script Date: 09/27/2015 17:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetQRAndQAData]

/******************************************************************************
** Program Property of ArunKumar Amarnath
** Filename	  	 		: spGetQRAndQAData.sql
** Database Object Name	 		: spGetQRAndQAData
** Author		 		: ArunKumar Amarnath
** Create Date		 		: 01/08/2015
** Project/System	 		: Velan Valves
** Subproject/Subsystem	 		: BaaN Management
** Purpose/Description	 		: For getting the QR & QA Data
** Input Parameters	 		: @OrderType, @WeekNo
** Output Parameters	 		: All Data
** Database		 		: VV
** Other Databases Accessed 		: N/A
** Tables		 		: MISOrderStatus, MISFinanceInput
** Rerunable				: Yes
****************************************************************************** 
** Modifications:
** Date				Name			Description
** -----------	------------------	---------------
** 01/08/2015	ArunKumar Amarnath	Initial Version
******************************************************************************/
@OrderType nvarchar(50),
@WeekNo int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

SELECT
	MOS.CustomerName, 
	MFI.OrderNo, 
	SUM(MOS.BalanceQty * MOS.Amount) as Amount, 
	SUM(MOS.ToReleaseQty * MOS.Amount) as 'CurrentMonth',
	MFI.ITP, 
	MFI.ApprovedITP as 'AITP', 
	MFI.GAD, 
	MFI.ApprovedGAD as 'AGAD', 
	MFI.Inspection1, 
	MFI.Inspection2
FROM
	MISOrderStatus MOS
	JOIN MISFinanceInput MFI
	on MFI.OrderNo = MOS.OrderNo
WHERE
	MOS.PlanWeek >= @WeekNo 
	AND MOS.PlanWeek <= @WeekNo + 3
	AND MOS.OrderType IN (SELECT Value FROM dbo.fn_Split(@OrderType, ','))
GROUP BY
	MOS.CustomerName, MFI.OrderNo, MFI.ITP, MFI.ApprovedITP, MFI.GAD, MFI.ApprovedGAD, MFI.Inspection1, MFI.Inspection2
	
END
GO
/****** Object:  StoredProcedure [dbo].[spGetProductiionReleasedData]    Script Date: 09/27/2015 17:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetProductiionReleasedData]

/******************************************************************************
** Program Property of ArunKumar Amarnath
** Filename	  	 		: spGetProductiionReleasedData.sql
** Database Object Name : spGetProductiionReleasedData
** Author		 		: ArunKumar Amarnath
** Create Date		 	: 21/06/2015
** Project/System	 	: Velan Valves
** Subproject/Subsystem	: BaaN Management
** Purpose/Description	: For getting the data from the Prod Release Table for the chosen Record
** Input Parameters	 	: @OrderNum, @LineNum, @Pos, @ProdOrderNo
** Output Parameters	: ORDERNUM, LINENUM, POS, PRODORDERNO, SERIALNO, PRODRELEASEQTY
** Database		 		: VV
** Other Databases Accessed 		: N/A
** Tables		 		: ProductionReleaseNew
** Rerunable			: Yes
****************************************************************************** 
** Modifications:
** Date				Name			Description
** -----------	------------------	---------------
** 21/06/2015	ArunKumar Amarnath	Initial Version
******************************************************************************/

	@OrderNum int,
	@LineNum nvarchar(50),
	@Pos int,
	@ProdOrderNo nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT 
		ORDERNUM,
		LINENUM,
		POS,
		PRODORDERNO,
		SERIALNO,
		PRODRELEASEQTY
	FROM 
		ProductionReleaseNew
	WHERE
		ORDERNUM = @OrderNum
		AND LINENUM = @LineNum
		AND POS = @Pos
		AND PRODORDERNO = @ProdOrderNo
END
GO
/****** Object:  StoredProcedure [dbo].[spGetProdCompletionData]    Script Date: 09/27/2015 17:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetProdCompletionData]

/******************************************************************************
** Program Property of ArunKumar Amarnath
** Filename	  	 		: spGetProdCompletionData.sql
** Database Object Name	 		: spGetBaanData
** Author		 		: ArunKumar Amarnath
** Create Date		 		: 22/06/2015
** Project/System	 		: Velan Valves
** Subproject/Subsystem	 		: BaaN Management
** Purpose/Description	 		: For getting the Imported data
** Input Parameters	 		: --
** Output Parameters	 		: All Columns
** Database		 		: VV
** Other Databases Accessed 		: N/A
** Tables		 		: MISOrderStatus, ProductionReleaseNew
** Rerunable				: Yes
****************************************************************************** 
** Modifications:
** Date				Name			Description
** -----------	------------------	---------------
** 22/06/2015	ArunKumar Amarnath	Initial Version
******************************************************************************/

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT
		PRN.ProdOrderNo,
		PRN.SerialNo,
		PRN.BalanceQty,
		PRN.OrderNum,
		PRN.LineNum,
		PRN.Pos,
		MISOS.Item AS 'FigNo',
		MISOS.[Description] as 'Descr',
		PRN.CreatedOn,
		PRN.ProdDeliveryDate,
		PRN.ProdComplDate,
		PRN.ProdRemarks
	FROM
		MISOrderStatus MISOS
	JOIN 
		ProductionReleaseNew PRN
		ON PRN.OrderNum = MISOS.OrderNo
		AND PRN.Pos = MISOS.Pos
	WHERE
		PRN.SerialNo IS NOT NULL AND
		PRN.Balanceqty>0 
			ORDER BY
		PRN.SerialNo ASC
END
GO
/****** Object:  StoredProcedure [dbo].[spGetMISSalesInput]    Script Date: 09/27/2015 17:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetMISSalesInput]

/******************************************************************************
** Program Property of ArunKumar Amarnath
** Filename	  	 		: spGetMISSalesInput.sql
** Database Object Name : spGetMISSalesInput
** Author		 		: ArunKumar Amarnath
** Create Date		 	: 25/06/2015
** Project/System	 	: Velan Valves
** Subproject/Subsystem	: BaaN Management
** Purpose/Description	: For getting the data from the MISSalesInput for the chosen Record
** Input Parameters	 	: @OrderNum, @LineNum, @Pos
** Output Parameters	: ORDERNUM, LINENUM, POS, SAPCode, StockCode, O2, H2, IBR, ASU
** Database		 		: VV
** Other Databases Accessed 		: N/A
** Tables		 		: MISSalesInput
** Rerunable			: Yes
****************************************************************************** 
** Modifications:
** Date				Name			Description
** -----------	------------------	---------------
** 21/06/2015	ArunKumar Amarnath	Initial Version
******************************************************************************/

	@OrderNum int,
	@LineNum nvarchar(50),
	@Pos int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT 
		OrderNo,
		LineNum,
		Pos,
		SAPCode,
		StockCode,
		O2,
		H2,
		IBR,
		ASU
	FROM 
		MISSalesInput
	WHERE
		ORDERNo = @OrderNum
		AND LINENUM = @LineNum
		AND POS = @Pos
END
GO
/****** Object:  StoredProcedure [dbo].[spGetMISFinanceInput]    Script Date: 09/27/2015 17:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetMISFinanceInput]

/******************************************************************************
** Program Property of ArunKumar Amarnath
** Filename	  	 		: spGetMISFinanceInput.sql
** Database Object Name : spGetMISFinanceInput
** Author		 		: ArunKumar Amarnath
** Create Date		 	: 25/06/2015
** Project/System	 	: Velan Valves
** Subproject/Subsystem	: BaaN Management
** Purpose/Description	: For getting the data from the MISFinanceInput for the chosen Record
** Input Parameters	 	: @OrderNum, @LineNum, @Pos
** Output Parameters	: ORDERNUM, LINENUM, POS, APG, PBG, RP
** Database		 		: VV
** Other Databases Accessed 		: N/A
** Tables		 		: MISFinanceInput
** Rerunable			: Yes
****************************************************************************** 
** Modifications:
** Date				Name			Description
** -----------	------------------	---------------
** 25/06/2015	ArunKumar Amarnath	Initial Version
** 02/08/2015	ArunKumar Amarnath	Removed the LineNum & POS from Condition
******************************************************************************/

	@OrderNum int,
	@LineNum nvarchar(50),
	@Pos int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT 
		OrderNo,
		LineNum,
		Pos,
		ABG,
		PBG,
		RP
	FROM 
		MISFinanceInput
	WHERE
		ORDERNo = @OrderNum
		--AND LINENUM = @LineNum
		--AND POS = @Pos
END
GO
/****** Object:  StoredProcedure [dbo].[spGetMaxSerialNo]    Script Date: 09/27/2015 17:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetMaxSerialNo]

/******************************************************************************
** Program Property of ArunKumar Amarnath
** Filename	  	 		: spGetMaxSerialNo.sql
** Database Object Name	 		: spGetMaxSerialNo
** Author		 		: ArunKumar Amarnath
** Create Date		 		: 21/06/2015
** Project/System	 		: Velan Valves
** Subproject/Subsystem	 		: BaaN Management
** Purpose/Description	 		: For getting the max of the Serial No for the given input
** Input Parameters	 		: @SerialNo
** Output Parameters	 		: SerialNo
** Database		 		: VV
** Other Databases Accessed 		: N/A
** Tables		 		: ProductionReleaseNew
** Rerunable				: Yes
****************************************************************************** 
** Modifications:
** Date				Name			Description
** -----------	------------------	---------------
** 25/06/2015	ArunKumar Amarnath	Initial Version
******************************************************************************/
	@SerialNo nvarchar(50)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
		SerialNo
	FROM 
		ProductionReleaseNew
	WHERE
		SerialNo like @SerialNo + '%'
END
GO
/****** Object:  StoredProcedure [dbo].[spGetMacroSalesPlanData]    Script Date: 09/27/2015 17:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetMacroSalesPlanData]

/******************************************************************************
** Program Property of ArunKumar Amarnath
** Filename	  	 		: spGetMacroSalesPlanData.sql
** Database Object Name	 		: spGetMacroSalesPlanData
** Author		 		: ArunKumar Amarnath
** Create Date		 		: 01/08/2015
** Project/System	 		: Velan Valves
** Subproject/Subsystem	 		: BaaN Management
** Purpose/Description	 		: For getting the Macro Sales Plan Data
** Input Parameters	 		: @WeekNo
** Output Parameters	 		: All Qty Data grouped by Customer, Week
** Database		 		: VV
** Other Databases Accessed 		: N/A
** Tables		 		: MISOrderStatus
** Rerunable				: Yes
****************************************************************************** 
** Modifications:
** Date				Name			Description
** -----------	------------------	---------------
** 01/08/2015	ArunKumar Amarnath	Initial Version
** 05/08/2015	ArunKumar Amarnath	Updated the calculation of Val for all qty
******************************************************************************/
@WeekNo int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT
		MISPlan.FGWeek, 
		MISPlan.customername, 
		SUM(MISPlan.invoicedqty) as 'PlanInvQty', 
		SUM(MISPlan.fgqty) as 'PlanFGQty', 
		SUM(MISPlan.wipqty )as 'PlanWIPQty', 
		SUM(MISPlan.toreleaseqty) as 'PlanToRelQty', 
		SUM((MISPlan.invoicedqty*(MISPlan.amount))) as 'PlanInvVal', 
		SUM((MISPlan.fgqty*(MISPlan.amount))) as 'PlanFGVal', 
		SUM((MISPlan.wipqty*(MISPlan.amount))) as 'PlanWIPVal', 
		SUM((MISPlan.toreleaseqty*(MISPlan.amount))) as 'PlanToRelVal', 
		SUM(MISOrderstatus.invoicedqty) as 'InvQty', 
		SUM(MISOrderstatus.fgqty) as 'FGQty', 
		SUM(MISOrderstatus.wipqty) as 'WIPQty', 
		SUM(MISOrderstatus.toreleaseqty) as 'ToRelQty', 
		SUM((MISOrderstatus.invoicedqty*(MISorderstatus.amount))) as 'InvVal', 
		SUM((MISOrderstatus.fgqty*(MISorderstatus.amount))) as 'FGVal', 
		SUM((MISOrderstatus.wipqty*(MISorderstatus.amount))) as 'WIPVal', 
		SUM((MISOrderstatus.toreleaseqty*(MISorderstatus.amount))) as 'ToRelVal'
	FROM 
		MISOrderStatus
		JOIN MISFinal MISPlan
		on MISOrderStatus.OrderNo = MISPlan.OrderNo
		AND MISOrderStatus.Pos = MISPlan.Pos
	WHERE
		(
			COALESCE(MISPlan.toreleaseqty,0) > 0 OR 
			COALESCE(MISPlan.WIPQty,0) > 0 OR
			COALESCE(MISPlan.FGQTY,0) > 0
		)
		AND
		MISPlan.FGWeek >= @WeekNo 
		AND
		MISPlan.FGWeek <= @WeekNo + 3
	GROUP BY
		MISPlan.FGWeek, MISPlan.CustomerName

END
GO
/****** Object:  StoredProcedure [dbo].[spGetMacroReleasePlanData]    Script Date: 09/27/2015 17:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetMacroReleasePlanData]

/******************************************************************************
** Program Property of ArunKumar Amarnath
** Filename	  	 		: spGetMacroReleasePlanData.sql
** Database Object Name	 		: spGetMacroReleasePlanData
** Author		 		: ArunKumar Amarnath
** Create Date		 		: 02/08/2015
** Project/System	 		: Velan Valves
** Subproject/Subsystem	 		: BaaN Management
** Purpose/Description	 		: For getting the Macro Release Data
** Input Parameters	 		: @WeekNo
** Output Parameters	 		: sum of All Qty Data grouped by CustomerName & WeekNo
** Database		 		: VV
** Other Databases Accessed 		: N/A
** Tables		 		: MISOrderStatus
** Rerunable				: Yes
****************************************************************************** 
** Modifications:
** Date				Name			Description
** -----------	------------------	---------------
** 02/08/2015	ArunKumar Amarnath	Initial Version
** 05/08/2015	ArunKumar Amarnath	Updated the calculation of Val for all qty
******************************************************************************/
@WeekNo int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT
		MISPlan.PlanWeek, 
		MISPlan.customername, 
		SUM(MISPlan.invoicedqty) as 'PlanInvQty', 
		SUM(MISPlan.fgqty) as 'PlanFGQty', 
		SUM(MISPlan.wipqty) as 'PlanWIPQty', 
		SUM(MISPlan.toreleaseqty) as 'PlanToRelQty', 
		SUM((MISPlan.invoicedqty*(MISPlan.amount))) as 'PlanInvVal', 
		SUM((MISPlan.fgqty*(MISPlan.amount))) as 'PlanFGVal', 
		SUM((MISPlan.wipqty*(MISPlan.amount))) as 'PlanWIPVal', 
		SUM((MISPlan.toreleaseqty*(MISPlan.amount))) as 'PlanToRelVal', 
		SUM(MISOrderstatus.invoicedqty) as 'InvQty', 
		SUM(MISOrderstatus.fgqty) as 'FGQty', 
		SUM(MISOrderstatus.wipqty) as 'WIPQty', 
		SUM(MISOrderstatus.toreleaseqty) as 'ToRelQty', 
		SUM((MISOrderstatus.invoicedqty*(MISorderstatus.amount))) as 'InvVal', 
		SUM((MISOrderstatus.fgqty*(MISorderstatus.amount))) as 'FGVal', 
		SUM((MISOrderstatus.wipqty*(MISorderstatus.amount))) as 'WIPVal', 
		SUM((MISOrderstatus.toreleaseqty*(MISorderstatus.amount))) as 'ToRelVal'
	FROM 
		MISOrderStatus
		JOIN MISFinal MISPlan
		on MISOrderStatus.OrderNo = MISPlan.OrderNo
		AND MISOrderStatus.Pos = MISPlan.Pos
	WHERE
		MISPlan.toreleaseqty > 0
	AND
		MISPlan.PlanWeek >= @WeekNo 
	AND
		MISPlan.PlanWeek <= @WeekNo + 3
	GROUP BY
		MISPlan.PlanWeek, MISPlan.CustomerName
	
END
GO
/****** Object:  StoredProcedure [dbo].[spGetMacroFGPlanData]    Script Date: 09/27/2015 17:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetMacroFGPlanData]

/******************************************************************************
** Program Property of ArunKumar Amarnath
** Filename	  	 		: spGetMacroFGPlanData.sql
** Database Object Name	 		: spGetMacroFGPlanData
** Author		 		: ArunKumar Amarnath
** Create Date		 		: 01/08/2015
** Project/System	 		: Velan Valves
** Subproject/Subsystem	 		: BaaN Management
** Purpose/Description	 		: For getting the Macro level FG Plan Data
** Input Parameters	 		: @WeekNo
** Output Parameters	 		: All Qty Data grouped by Weekno, Customer
** Database		 		: VV
** Other Databases Accessed 		: N/A
** Tables		 		: MISOrderStatus
** Rerunable				: Yes
****************************************************************************** 
** Modifications:
** Date				Name			Description
** -----------	------------------	---------------
** 01/08/2015	ArunKumar Amarnath	Initial Version
** 05/08/2015	ArunKumar Amarnath	Updated the calculation of Val for all qty
******************************************************************************/
@WeekNo int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT
		MISPlan.WIPWeek, 
		MISPlan.customername, 
		SUM(MISPlan.invoicedqty) as 'PlanInvQty', 
		SUM(MISPlan.fgqty) as 'PlanFGQty', 
		SUM(MISPlan.wipqty) as 'PlanWIPQty', 
		SUM(MISPlan.toreleaseqty) as 'PlanToRelQty', 
		SUM((MISPlan.invoicedqty*(MISPlan.amount))) as 'PlanInvVal', 
		SUM((MISPlan.fgqty*(MISPlan.amount))) as 'PlanFGVal', 
		SUM((MISPlan.wipqty*(MISPlan.amount))) as 'PlanWIPVal', 
		SUM((MISPlan.toreleaseqty*(MISPlan.amount))) as 'PlanToRelVal', 
		SUM(MISOrderstatus.invoicedqty) as 'InvQty', 
		SUM(MISOrderstatus.fgqty) as 'FGQty', 
		SUM(MISOrderstatus.wipqty) as 'WIPQty', 
		SUM(MISOrderstatus.toreleaseqty) as 'ToRelQty', 
		SUM((MISOrderstatus.invoicedqty*(MISorderstatus.amount))) as 'InvVal', 
		SUM((MISOrderstatus.fgqty*(MISorderstatus.amount))) as 'FGVal', 
		SUM((MISOrderstatus.wipqty*(MISorderstatus.amount))) as 'WIPVal', 
		SUM((MISOrderstatus.toreleaseqty*(MISorderstatus.amount))) as 'ToRelVal'
	FROM 
		MISOrderStatus
		JOIN MISFinal MISPlan
		on MISOrderStatus.OrderNo = MISPlan.OrderNo
		AND MISOrderStatus.Pos = MISPlan.Pos
	WHERE
		(MISPlan.toreleaseqty + coalesce(MISPlan.WIPQty,0)) > 0
		AND
		MISPlan.WIPWeek >= @WeekNo 
		AND
		MISPlan.WIPWeek <= @WeekNo + 3
	GROUP BY
		MISPlan.WIPWeek, MISPlan.CustomerName order by MISPlan.WIPWeek, MISPlan.CustomerName
	
	
END
GO
/****** Object:  StoredProcedure [dbo].[spGetLogin]    Script Date: 09/27/2015 17:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetLogin]

/******************************************************************************
** Program Property of ArunKumar Amarnath
** Filename	  	 		: spGetLogin.sql
** Database Object Name	: spGetLogin
** Author		 		: ArunKumar Amarnath
** Create Date		 	: 21/06/2015
** Project/System	 	: Velan Valves
** Subproject/Subsystem	: BaaN Management
** Purpose/Description	: Login/ Authentication
** Input Parameters	 	: --
** Output Parameters	: Valid User Or Not
** Database		 		: VV
** Other Databases Accessed 		: N/A
** Tables		 		: Login
** Rerunable			: Yes
****************************************************************************** 
** Modifications:
** Date				Name			Description
** -----------	------------------	---------------
** 21/06/2015	ArunKumar Amarnath	Initial Version
******************************************************************************/

	@UserName nvarchar(50),
	@Password nvarchar(50)
AS
BEGIN
	SELECT 
		UserName 
	FROM 
		LOGIN 
	WHERE
		UserName = @UserName AND 
		Password = @Password;
END
GO
/****** Object:  StoredProcedure [dbo].[spGetITPData]    Script Date: 09/27/2015 17:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetITPData]

/******************************************************************************
** Program Property of ArunKumar Amarnath
** Filename	  	 		: spGetITPData.sql
** Database Object Name	 		: spGetITPData
** Author		 		: ArunKumar Amarnath
** Create Date		 		: 11/07/2015
** Project/System	 		: Velan Valves
** Subproject/Subsystem	 		: BaaN Management
** Purpose/Description	 		: For getting the ITP data
** Input Parameters	 		: --
** Output Parameters	 		: All Columns
** Database		 		: VV
** Other Databases Accessed 		: N/A
** Tables		 		: MISOrderStatus, MISFinanceInput
** Rerunable				: Yes
****************************************************************************** 
** Modifications:
** Date				Name			Description
** -----------	------------------	---------------
** 11/07/2015	ArunKumar Amarnath	Initial Version
******************************************************************************/

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
		MIS.OrderNo, 
		MIS.LineNum, 
		MIS.Pos, 
		MIS.CustomerName, 
		MIS.PlannedDelDate, 
		MISFI.ITP, 
		MISFI.ApprovedITP, 
		MISFI.GAD, 
		MISFI.ApprovedGAD, 
		MISFI.inspection1, 
		MISFI.inspection2
	FROM
		MISOrderStatus MIS 
	JOIN 
		MISFinanceInput MISFI
	ON 
		MIS.OrderNo = MISFI.OrderNo
		AND MIS.LineNum = MISFI.LineNum
		AND MIS.Pos = MISFI.Pos
	WHERE
		MIS.BalanceQty > 0
	ORDER BY
		MIS.OrderNo
END
GO
/****** Object:  StoredProcedure [dbo].[spGetItemGroupMapping]    Script Date: 09/27/2015 17:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetItemGroupMapping]

/******************************************************************************
** Program Property of ArunKumar Amarnath
** Filename	  	 		: spGetItemGroupMapping.sql
** Database Object Name	 		: spGetItemGroupMapping
** Author		 		: ArunKumar Amarnath
** Create Date		 		: 21/06/2015
** Project/System	 		: Velan Valves
** Subproject/Subsystem	 		: BaaN Management
** Purpose/Description	 		: For getting all the records
** Input Parameters	 		: --
** Output Parameters	 		: All
** Database		 		: VV
** Other Databases Accessed 		: N/A
** Tables		 		: ItemGroupMapping
** Rerunable				: Yes
****************************************************************************** 
** Modifications:
** Date				Name			Description
** -----------	------------------	---------------
** 25/06/2015	ArunKumar Amarnath	Initial Version
******************************************************************************/

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
		ItemGroup,
		[Description],
		Product,
		X,
		MappingCode
	FROM 
		ItemGroupMapping
END
GO
/****** Object:  StoredProcedure [dbo].[spGetInvoiceData]    Script Date: 09/27/2015 17:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetInvoiceData]

/******************************************************************************
** Program Property of ArunKumar Amarnath
** Filename	  	 		: spGetInvoiceData.sql
** Database Object Name	 		: spGetInvoiceData
** Author		 		: ArunKumar Amarnath
** Create Date		 		: 21/06/2015
** Project/System	 		: Velan Valves
** Subproject/Subsystem	 		: BaaN Management
** Purpose/Description	 		: For getting the Invoiced data
** Input Parameters	 		: --
** Output Parameters	 		: All Columns
** Database		 		: VV
** Other Databases Accessed 		: N/A
** Tables		 		: tblInvoice
** Rerunable				: Yes
****************************************************************************** 
** Modifications:
** Date				Name			Description
** -----------	------------------	---------------
** 21/06/2015	ArunKumar Amarnath	Initial Version
******************************************************************************/

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
		* 
	FROM 
		tblInvoice
END
GO
/****** Object:  StoredProcedure [dbo].[spGetFGPlanData]    Script Date: 09/27/2015 17:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetFGPlanData]

/******************************************************************************
** Program Property of ArunKumar Amarnath
** Filename	  	 		: spGetFGPlanData.sql
** Database Object Name	 		: spGetFGPlanData
** Author		 		: ArunKumar Amarnath
** Create Date		 		: 01/08/2015
** Project/System	 		: Velan Valves
** Subproject/Subsystem	 		: BaaN Management
** Purpose/Description	 		: For getting the FG Plan Data
** Input Parameters	 		: @WeekNo
** Output Parameters	 		: All Qty Data
** Database		 		: VV
** Other Databases Accessed 		: N/A
** Tables		 		: MISOrderStatus, MISFinal
** Rerunable				: Yes
****************************************************************************** 
** Modifications:
** Date				Name			Description
** -----------	------------------	---------------
** 01/08/2015	ArunKumar Amarnath	Initial Version
** 05/08/2015	ArunKumar Amarnath	Updated the calculation of Val for all qty
******************************************************************************/
@WeekNo int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT
		MISPlan.Orderno,
		MISPlan.WIPWeek as 'WeekNo', 
		MISPlan.pos, 
		MISPlan.customername as 'Customer', 
		MISPlan.invoicedqty as 'PlanInvQty', 
		MISPlan.fgqty as 'PlanFGQty', 
		MISPlan.wipqty as 'PlanWIPQty', 
		MISPlan.toreleaseqty as 'PlanToRelQty', 
	--	(MISorderstatus.amount/MISOrderstatus.balanceqty) as Rate, 
		(MISPlan.invoicedqty*(MISPlan.amount)) as 'PlanInvVal', 
		(MISPlan.fgqty*(MISPlan.amount)) as 'PlanFGVal', 
		(MISPlan.wipqty*(MISPlan.amount)) as 'PlanWIPVal', 
		(MISPlan.toreleaseqty*(MISPlan.amount)) as 'PlanToRelVal', 
		MISOrderstatus.invoicedqty as 'InvQty', 
		MISOrderstatus.fgqty as 'FGQty', 
		MISOrderstatus.wipqty as 'WIPQty', 
		MISOrderstatus.toreleaseqty as 'ToRelQty', 
	--	(MISorderstatus.amount/MISOrderstatus.balanceqty) as Rate, 
		(MISOrderstatus.invoicedqty*(MISorderstatus.amount)) as 'InvVal', 
		(MISOrderstatus.fgqty*(MISorderstatus.amount)) as 'FGVal', 
		(MISOrderstatus.wipqty*(MISorderstatus.amount)) as 'WIPVal', 
		(MISOrderstatus.toreleaseqty*(MISorderstatus.amount)) as 'ToRelVal'
	FROM 
		MISOrderStatus
		JOIN MISFinal MISPlan
		on MISOrderStatus.OrderNo = MISPlan.OrderNo
		AND MISOrderStatus.Pos = MISPlan.Pos
	WHERE
		(MISPlan.toreleaseqty + coalesce(MISPlan.WIPQty,0)) > 0
	AND
		MISPlan.WIPWeek >= @WeekNo 
	AND
		MISPlan.WIPWeek <= @WeekNo + 3
	ORDER BY
		MISPlan.WIPWeek, MISPlan.OrderNo, MISPlan.Pos
	
END
GO
/****** Object:  StoredProcedure [dbo].[spGetDataForWIPToFGConversion]    Script Date: 09/27/2015 17:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetDataForWIPToFGConversion]

/******************************************************************************
** Program Property of ArunKumar Amarnath
** Filename	  	 		: spGetDataForWIPToFGConversion.sql
** Database Object Name : spGetDataForWIPToFGConversion
** Author		 		: ArunKumar Amarnath
** Create Date		 	: 21/06/2015
** Project/System	 	: Velan Valves
** Subproject/Subsystem	: BaaN Management
** Purpose/Description	: For getting the data from the MISOrderStatus table & from the Prod Release Table, where WIP > 0
** Input Parameters	 	: --
** Output Parameters	: All Columns
** Database		 		: VV
** Other Databases Accessed 		: N/A
** Tables		 		: MISOrderStatus, ProductionReleaseNew
** Rerunable			: Yes
****************************************************************************** 
** Modifications:
** Date				Name			Description
** -----------	------------------	---------------
** 21/06/2015	ArunKumar Amarnath	Initial Version
******************************************************************************/

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT 
		MIS.*, 
		PRN.SerialNo,
		PRN.ProdOrderNo,
		PRN.BalanceQty as 'ProdBalanceQty',
		PRN.ProdReleaseQty as 'ProdRelQty'
	FROM 
		MISOrderStatus MIS
		JOIN ProductionReleaseNew PRN
		ON prn.OrderNum = mis.OrderNo
		AND prn.LineNum = mis.LineNum
		AND prn.Pos = mis.Pos
		AND PRN.BalanceQty > 0
END
GO
/****** Object:  StoredProcedure [dbo].[spGetCommercialData]    Script Date: 09/27/2015 17:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetCommercialData]

/******************************************************************************
** Program Property of ArunKumar Amarnath
** Filename	  	 		: spGetCommercialData.sql
** Database Object Name	 		: spGetCommercialData
** Author		 		: ArunKumar Amarnath
** Create Date		 		: 01/08/2015
** Project/System	 		: Velan Valves
** Subproject/Subsystem	 		: BaaN Management
** Purpose/Description	 		: For getting the Commerical Data
** Input Parameters	 		: @OrderType, @WeekNo
** Output Parameters	 		: All Data
** Database		 		: VV
** Other Databases Accessed 		: N/A
** Tables		 		: MISOrderStatus, MISFinanceInput
** Rerunable				: Yes
****************************************************************************** 
** Modifications:
** Date				Name			Description
** -----------	------------------	---------------
** 01/08/2015	ArunKumar Amarnath	Initial Version
******************************************************************************/
@OrderType nvarchar(50),
@WeekNo int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

SELECT
	MOS.CustomerName, 
	MFI.OrderNo, 
	SUM(MOS.BalanceQty * MOS.Amount) as Amount, 
	SUM(MOS.ToReleaseQty * MOS.Amount) as 'CurrentMonth',
	MFI.ABG, 
	MFI.PBG, 
	MFI.RP, 
	' ' as 'Hold1',
	' ' as 'Hold2'
FROM
	MISOrderStatus MOS
	JOIN MISFinanceInput MFI
	on MFI.OrderNo = MOS.OrderNo
WHERE
	MOS.PlanWeek >= @WeekNo 
	AND MOS.PlanWeek <= @WeekNo + 3
	AND MOS.OrderType IN (SELECT Value FROM dbo.fn_Split(@OrderType, ','))
GROUP BY
	MOS.CustomerName, MFI.OrderNo, MFI.ABG, MFI.PBG, MFI.RP
	
END
GO
/****** Object:  StoredProcedure [dbo].[spGetBaanDataForMISFinanceInput]    Script Date: 09/27/2015 17:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetBaanDataForMISFinanceInput]

/******************************************************************************
** Program Property of ArunKumar Amarnath
** Filename	  	 		: spGetBaanDataForMISFinanceInput.sql
** Database Object Name	 		: spGetBaanDataForMISFinanceInput
** Author		 		: ArunKumar Amarnath
** Create Date		 		: 21/06/2015
** Project/System	 		: Velan Valves
** Subproject/Subsystem	 		: BaaN Management
** Purpose/Description	 		: For getting the BaaN data for  MISFinanceInput
** Input Parameters	 		: --
** Output Parameters	 		: All Columns
** Database		 		: VV
** Other Databases Accessed 		: N/A
** Tables		 		: MISOrderStatus
** Rerunable				: Yes
****************************************************************************** 
** Modifications:
** Date				Name			Description
** -----------	------------------	---------------
** 23/07/2015	ArunKumar Amarnath	Initial Version
******************************************************************************/

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    ;with cte as
(
	select row_number() over (partition by OrderNo order by OrderNo) as Rno,* from MISOrderStatus
)
select  OrderNo,
		OrderType,
		CustomerName,
		LineNum,
		Pos,
		Item,
		Description,
		SalesOrderRevision,
		RevisionDate,
		Area,
		OrderDate,
		OriginalPromDate,
		PlannedDelDate,
		OrderQty,
		BalanceQty,
		Amount,
		InvoicedQty,
		FGQty,
		WIPQty,
		ToReleaseQty,
		RelDate,
		ProdCompletionDate,
		ProdRemarks
 from cte where rno=1 and ToReleaseQty > 0
 ORDER BY OrderNo, Pos ASC
	

END
GO
/****** Object:  StoredProcedure [dbo].[spGetBaanDataForInvoice]    Script Date: 09/27/2015 17:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetBaanDataForInvoice]

/******************************************************************************
** Program Property of ArunKumar Amarnath
** Filename	  	 		: spGetBaanDataForInvoice.sql
** Database Object Name	 		: spGetBaanDataForInvoice
** Author		 		: ArunKumar Amarnath
** Create Date		 		: 21/06/2015
** Project/System	 		: Velan Valves
** Subproject/Subsystem	 		: BaaN Management
** Purpose/Description	 		: For getting the Imported data
** Input Parameters	 		: --
** Output Parameters	 		: All Columns
** Database		 		: VV
** Other Databases Accessed 		: N/A
** Tables		 		: MISOrderStatus
** Rerunable				: Yes
****************************************************************************** 
** Modifications:
** Date				Name			Description
** -----------	------------------	---------------
** 21/06/2015	ArunKumar Amarnath	Initial Version
******************************************************************************/

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
		* 
	FROM 
		MISOrderStatus
END
GO
/****** Object:  StoredProcedure [dbo].[spGetBaanData]    Script Date: 09/27/2015 17:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetBaanData]

/******************************************************************************
** Program Property of ArunKumar Amarnath
** Filename	  	 		: spGetBaanData.sql
** Database Object Name	 		: spGetBaanData
** Author		 		: ArunKumar Amarnath
** Create Date		 		: 21/06/2015
** Project/System	 		: Velan Valves
** Subproject/Subsystem	 		: BaaN Management
** Purpose/Description	 		: For getting the Imported data
** Input Parameters	 		: --
** Output Parameters	 		: All Columns
** Database		 		: VV
** Other Databases Accessed 		: N/A
** Tables		 		: MISOrderStatus
** Rerunable				: Yes
****************************************************************************** 
** Modifications:
** Date				Name			Description
** -----------	------------------	---------------
** 21/06/2015	ArunKumar Amarnath	Initial Version
******************************************************************************/

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
		* 
	FROM 
		MISOrderStatus
	WHERE
		ToReleaseQty > 0
	ORDER BY
		OrderNo, Pos
END
GO
/****** Object:  StoredProcedure [dbo].[spGetAssemblyOrderProcessing]    Script Date: 09/27/2015 17:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetAssemblyOrderProcessing]

/******************************************************************************
** Program Property of ArunKumar Amarnath
** Filename	  	 		: spGetAssemblyOrderProcessing.sql
** Database Object Name	: spGetAssemblyOrderProcessing
** Author		 		: ArunKumar Amarnath
** Create Date		 	: 08/08/2015
** Project/System	 	: Velan Valves
** Subproject/Subsystem	: BaaN Management
** Purpose/Description	: Get the Assembly Order Processing data
** Input Parameters	 	: @ProdOrderNo
** Output Parameters	: PRN.SerialNo, MISOS.OrderNo, MISOS.Pos, MISSI.QCINo, MISSI.SAPCode, MISSI.StockCode, MISSI.TAGNo, MISOS.CustomerOrderNo,
						  MISOS.LineNum, MISSI.GADNo
** Database		 		: VV
** Other Databases Accessed 		: N/A
** Tables		 		: ProductionReleaseNew, MISOrderStatus, MISSalesInput
** Rerunable			: Yes
****************************************************************************** 
** Modifications:
** Date				Name			Description
** -----------	------------------	---------------
** 08/08/2015	ArunKumar Amarnath	Initial Version
******************************************************************************/

	@ProdOrderNo nvarchar(50)
AS
BEGIN
	SELECT        PRN.SerialNo AS 'ProductSerialNo', MISOS.OrderNo AS 'SalesOrder', MISOS.Pos AS 'Position', MISOS.CustomerOrderNo, MISOS.LineNum, 
                         MISSalesInput.QCINo AS 'QCI&Rev', MISSalesInput.SAPCode, MISSalesInput.StockCode, MISSalesInput.TAGNo, MISSalesInput.GADNo as GAD
FROM            MISOrderStatus AS MISOS LEFT OUTER JOIN
                         MISSalesInput ON MISOS.OrderNo = MISSalesInput.OrderNo AND MISOS.Pos = MISSalesInput.Pos RIGHT OUTER JOIN
                         ProductionReleaseNew AS PRN ON MISOS.OrderNo = PRN.OrderNum AND MISOS.Pos = PRN.Pos
WHERE        (PRN.ProdOrderNo = @ProdOrderNo)
END
GO
/****** Object:  StoredProcedure [dbo].[spGetAllMISSalesInput]    Script Date: 09/27/2015 17:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetAllMISSalesInput]

/******************************************************************************
** Program Property of ArunKumar Amarnath
** Filename	  	 		: spGetAllMISSalesInput.sql
** Database Object Name : spGetAllMISSalesInput
** Author		 		: ArunKumar Amarnath
** Create Date		 	: 15/07/2015
** Project/System	 	: Velan Valves
** Subproject/Subsystem	: BaaN Management
** Purpose/Description	: For getting all the data from the MISSalesInput
** Input Parameters	 	: NA
** Output Parameters	: ORDERNUM, LINENUM, POS, SAPCode, StockCode, O2, H2, IBR, ASU, TAGNo, GADNo, QCINo, RelDate
** Database		 		: VV
** Other Databases Accessed 		: N/A
** Tables		 		: MISSalesInput
** Rerunable			: Yes
****************************************************************************** 
** Modifications:
** Date				Name			Description
** -----------	------------------	---------------
** 15/07/2015	ArunKumar Amarnath	Initial Version
******************************************************************************/

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT 
		OrderNo,
		LineNum,
		Pos,
		SAPCode,
		StockCode,
		O2,
		H2,
		IBR,
		ASU,
		TAGNo,
		GADNo,
		QCINo,
		RelDate
	FROM 
		MISSalesInput;
END
GO
/****** Object:  StoredProcedure [dbo].[spGetAllMISFinanceInput]    Script Date: 09/27/2015 17:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetAllMISFinanceInput]

/******************************************************************************
** Program Property of ArunKumar Amarnath
** Filename	  	 		: spGetAllMISFinanceInput.sql
** Database Object Name : spGetAllMISFinanceInput
** Author		 		: ArunKumar Amarnath
** Create Date		 	: 08/08/2015
** Project/System	 	: Velan Valves
** Subproject/Subsystem	: BaaN Management
** Purpose/Description	: For getting distinct OrderNo from the MISFinanceInput
** Input Parameters	 	: NA
** Output Parameters	: ORDERNUM
** Database		 		: VV
** Other Databases Accessed 		: N/A
** Tables		 		: MISFinanceInput
** Rerunable			: Yes
****************************************************************************** 
** Modifications:
** Date				Name			Description
** -----------	------------------	---------------
** 08/08/2015	ArunKumar Amarnath	Initial Version
******************************************************************************/

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT 
		Distinct OrderNo		
	FROM 
		MISFinanceInput
END
GO
/****** Object:  StoredProcedure [dbo].[spFreeze]    Script Date: 09/27/2015 17:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spFreeze]

/******************************************************************************
** Program Property of ArunKumar Amarnath
** Filename	  	 		: spFreeze.sql
** Database Object Name : spFreeze
** Author		 		: ArunKumar Amarnath
** Create Date		 	: 01/08/2015
** Project/System	 	: Velan Valves
** Subproject/Subsystem	: BaaN Management
** Purpose/Description	: For Copying the data from the MISOrderStatus into MISFinal
** Input Parameters	 	: 
** Output Parameters	: --
** Database		 		: VV
** Other Databases Accessed 		: N/A
** Tables		 		: MISOrderStatus, MISFinal
** Rerunable			: Yes
****************************************************************************** 
** Modifications:
** Date				Name			Description
** -----------	------------------	---------------
** 01/08/2015	ArunKumar Amarnath	Initial Version
******************************************************************************/
	
AS
BEGIN

	DECLARE @RetVal			INT  		/*RetVal from called SP. =0 for success;<>0 for failure*/              
		, @ErrMsg		VARCHAR(2048)    /*Error Message*/            
		, @ErrorSeverity	INT             /*Error Number*/   
		, @RowCount		INT		/*Row Count*/

BEGIN TRY

	DELETE FROM MISFinal

    INSERT INTO 
		MISFinal
	SELECT 
		*
	FROM
		MISOrderStatus where balanceqty>0 and (planweek>0 or wipweek>0 or fgweek>0)
	
END TRY 
	BEGIN CATCH 
		SELECT @ErrMsg = ERROR_MESSAGE(),
		           @ErrorSeverity = ERROR_SEVERITY();

		RAISERROR(@ErrMsg, @ErrorSeverity, 1) 
		SELECT @RetVal = 9999
		RETURN 9999
	END CATCH 

	RETURN @RetVal
    
END
GO
/****** Object:  StoredProcedure [dbo].[spBulkUpdateTPIOffering]    Script Date: 09/27/2015 17:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spBulkUpdateTPIOffering]  
  
/******************************************************************************  
** Program Property of ArunKumar Amarnath  
** Filename       : spBulkUpdateTPIOffering.sql  
** Database Object Name    : spBulkUpdateTPIOffering  
** Author     : ArunKumar Amarnath  
** Create Date     : 27/09/2015  
** Project/System    : Velan Valves  
** Subproject/Subsystem : BaaN Management  
** Purpose/Description  : For Bulk Updating the  TPI Offer Date, QC Remarks & IRN Comp Date
** Input Parameters	 	: ProdOrderNo, SerialNo, TPIOfferDate, QCRemarks, IRNCompDate, UpdatedBy, UpdatedOn  
**         
** Output Parameters    : Updated Status  
** Database     : VV  
** Other Databases Accessed   : N/A  
** Tables     : ProductionReleaseNew  
** Rerunable    : Yes  
******************************************************************************   
** Modifications:  
** Date					Name			Description  
** ----------- ------------------		---------------  
** 27/09/2015	ArunKumar Amarnath		Initial Version  
******************************************************************************/  
/*Declare all the Input Parameters*/  
  
	@ProdOrderNo nvarchar(50),  
	@SerialNo nvarchar(max),  
	@TPIOfferDate nvarchar(50),
	@QCRemarks nvarchar(50),
	@IRNCompDate nvarchar(50),
	@UpdatedBy nvarchar(50),
	@UpdatedOn DateTime 
AS  
BEGIN  
 DECLARE @RetVal   INT    /*RetVal from called SP. =0 for success;<>0 for failure*/                
  , @ErrMsg  VARCHAR(2048)    /*Error Message*/              
  , @ErrorSeverity INT             /*Error Number*/     
  , @RowCount  INT  /*Row Count*/  
  
BEGIN TRY  
  
 UPDATE
		ProductionReleaseNew
	SET
		TPIOfferDate = @TPIOfferDate,
		QCRemarks = @QCRemarks,
		IRNComplDate = @IRNCompDate,
		UpdatedBy = @UpdatedBy,
		UpdatedOn = @UpdatedOn
	WHERE 
		ProdOrderNo = @ProdOrderNo AND  
		SerialNo IN (SELECT Value FROM dbo.fn_Split(@SerialNo, ','));  
  
END TRY   
 BEGIN CATCH   
  SELECT @ErrMsg = ERROR_MESSAGE(),  
             @ErrorSeverity = ERROR_SEVERITY();  
  
  RAISERROR(@ErrMsg, @ErrorSeverity, 1)   
  SELECT @RetVal = 9999  
  RETURN 9999  
 END CATCH   
  
 RETURN @RetVal  
      
END
GO
/****** Object:  StoredProcedure [dbo].[spBulkUpdateProdCompletion]    Script Date: 09/27/2015 17:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spBulkUpdateProdCompletion]  
  
/******************************************************************************  
** Program Property of ArunKumar Amarnath  
** Filename       : spBulkUpdateProdCompletion.sql  
** Database Object Name    : spBulkUpdateProdCompletion  
** Author     : ArunKumar Amarnath  
** Create Date     : 13/09/2015  
** Project/System    : Velan Valves  
** Subproject/Subsystem    : BaaN Management  
** Purpose/Description    : For Bulk Updating the  Prod Delivery Date, Prod COmpletion Date & Prod Remarks  
** Input Parameters    : ProdOrderNo, SerialNo, ProdDeliveryDate, ProdComplDate, ProdRemarks, UpdatedBy, UpdatedOn  
**         
** Output Parameters    : Updated Status  
** Database     : VV  
** Other Databases Accessed   : N/A  
** Tables     : ProductionReleaseNew  
** Rerunable    : Yes  
******************************************************************************   
** Modifications:  
** Date    Name   Description  
** ----------- ------------------ ---------------  
** 12/07/2015 ArunKumar Amarnath Initial Version  
******************************************************************************/  
/*Declare all the Input Parameters*/  
  
 @ProdOrderNo nvarchar(50),  
 @SerialNo nvarchar(max),  
 @ProdDeliveryDate nvarchar(50),  
 @ProdComplDate nvarchar(50),  
 @ProdRemarks nvarchar(50),  
 @UpdatedBy nvarchar(50),  
 @UpdatedOn DateTime  
AS  
BEGIN  
 DECLARE @RetVal   INT    /*RetVal from called SP. =0 for success;<>0 for failure*/                
  , @ErrMsg  VARCHAR(2048)    /*Error Message*/              
  , @ErrorSeverity INT             /*Error Number*/     
  , @RowCount  INT  /*Row Count*/  
  
BEGIN TRY  
  
 UPDATE  
  ProductionReleaseNew  
 SET  
  ProdDeliveryDate = @ProdDeliveryDate,  
  ProdComplDate = @ProdComplDate,  
  ProdRemarks = @ProdRemarks,  
  UpdatedBy = @UpdatedBy,  
  UpdatedOn = @UpdatedOn  
 WHERE  
  ProdOrderNo = @ProdOrderNo AND  
  SerialNo IN (SELECT Value FROM dbo.fn_Split(@SerialNo, ','));  
  
END TRY   
 BEGIN CATCH   
  SELECT @ErrMsg = ERROR_MESSAGE(),  
             @ErrorSeverity = ERROR_SEVERITY();  
  
  RAISERROR(@ErrMsg, @ErrorSeverity, 1)   
  SELECT @RetVal = 9999  
  RETURN 9999  
 END CATCH   
  
 RETURN @RetVal  
      
END
GO
/****** Object:  Default [DF_Invoice_CreatedBy]    Script Date: 09/27/2015 17:14:46 ******/
ALTER TABLE [dbo].[IV_Complete] ADD  CONSTRAINT [DF_Invoice_CreatedBy]  DEFAULT ('Admin') FOR [CreatedBy]
GO
/****** Object:  Default [DF_Invoice_CreatedOn]    Script Date: 09/27/2015 17:14:46 ******/
ALTER TABLE [dbo].[IV_Complete] ADD  CONSTRAINT [DF_Invoice_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
/****** Object:  Default [DF_Invoice_UpdatedBy]    Script Date: 09/27/2015 17:14:46 ******/
ALTER TABLE [dbo].[IV_Complete] ADD  CONSTRAINT [DF_Invoice_UpdatedBy]  DEFAULT ('Admin') FOR [UpdatedBy]
GO
/****** Object:  Default [DF_Invoice_UpdatedOn]    Script Date: 09/27/2015 17:14:46 ******/
ALTER TABLE [dbo].[IV_Complete] ADD  CONSTRAINT [DF_Invoice_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
/****** Object:  Default [DF__Login__CreatedBy__0425A276]    Script Date: 09/27/2015 17:14:46 ******/
ALTER TABLE [dbo].[Login] ADD  CONSTRAINT [DF__Login__CreatedBy__0425A276]  DEFAULT ('Administrator') FOR [CreatedBy]
GO
/****** Object:  Default [DF__Login__CreatedOn__0519C6AF]    Script Date: 09/27/2015 17:14:46 ******/
ALTER TABLE [dbo].[Login] ADD  CONSTRAINT [DF__Login__CreatedOn__0519C6AF]  DEFAULT (getdate()) FOR [CreatedOn]
GO
/****** Object:  Default [DF__Login__UpdatedBy__060DEAE8]    Script Date: 09/27/2015 17:14:46 ******/
ALTER TABLE [dbo].[Login] ADD  CONSTRAINT [DF__Login__UpdatedBy__060DEAE8]  DEFAULT ('Administrator') FOR [UpdatedBy]
GO
/****** Object:  Default [DF__Login__UpdatedOn__07020F21]    Script Date: 09/27/2015 17:14:46 ******/
ALTER TABLE [dbo].[Login] ADD  CONSTRAINT [DF__Login__UpdatedOn__07020F21]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
/****** Object:  Default [DF_MISFinanceInput_CreatedBy]    Script Date: 09/27/2015 17:14:46 ******/
ALTER TABLE [dbo].[MISFinanceInput] ADD  CONSTRAINT [DF_MISFinanceInput_CreatedBy]  DEFAULT ('Admin') FOR [CreatedBy]
GO
/****** Object:  Default [DF_MISFinanceInput_CreatedOn]    Script Date: 09/27/2015 17:14:46 ******/
ALTER TABLE [dbo].[MISFinanceInput] ADD  CONSTRAINT [DF_MISFinanceInput_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
/****** Object:  Default [DF_MISFinanceInput_UpdatedBy]    Script Date: 09/27/2015 17:14:46 ******/
ALTER TABLE [dbo].[MISFinanceInput] ADD  CONSTRAINT [DF_MISFinanceInput_UpdatedBy]  DEFAULT ('Admin') FOR [UpdatedBy]
GO
/****** Object:  Default [DF_MISFinanceInput_UpdatedOn]    Script Date: 09/27/2015 17:14:46 ******/
ALTER TABLE [dbo].[MISFinanceInput] ADD  CONSTRAINT [DF_MISFinanceInput_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
/****** Object:  Default [DF_MISSalesInput_CreatedBy]    Script Date: 09/27/2015 17:14:46 ******/
ALTER TABLE [dbo].[MISSalesInput] ADD  CONSTRAINT [DF_MISSalesInput_CreatedBy]  DEFAULT ('Admin') FOR [CreatedBy]
GO
/****** Object:  Default [DF_MISSalesInput_CreatedOn]    Script Date: 09/27/2015 17:14:46 ******/
ALTER TABLE [dbo].[MISSalesInput] ADD  CONSTRAINT [DF_MISSalesInput_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
/****** Object:  Default [DF_MISSalesInput_UpdatedBy]    Script Date: 09/27/2015 17:14:46 ******/
ALTER TABLE [dbo].[MISSalesInput] ADD  CONSTRAINT [DF_MISSalesInput_UpdatedBy]  DEFAULT ('Admin') FOR [UpdatedBy]
GO
/****** Object:  Default [DF_MISSalesInput_UpdatedOn]    Script Date: 09/27/2015 17:14:46 ******/
ALTER TABLE [dbo].[MISSalesInput] ADD  CONSTRAINT [DF_MISSalesInput_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
/****** Object:  Default [DF_ProductionReleaseNew_CreatedBy_1]    Script Date: 09/27/2015 17:14:46 ******/
ALTER TABLE [dbo].[ProductionReleaseNew] ADD  CONSTRAINT [DF_ProductionReleaseNew_CreatedBy_1]  DEFAULT ('Admin') FOR [CreatedBy]
GO
/****** Object:  Default [DF_ProductionReleaseNew_CreatedOn]    Script Date: 09/27/2015 17:14:46 ******/
ALTER TABLE [dbo].[ProductionReleaseNew] ADD  CONSTRAINT [DF_ProductionReleaseNew_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
/****** Object:  Default [DF_ProductionReleaseNew_UpdatedBy]    Script Date: 09/27/2015 17:14:46 ******/
ALTER TABLE [dbo].[ProductionReleaseNew] ADD  CONSTRAINT [DF_ProductionReleaseNew_UpdatedBy]  DEFAULT ('Admin') FOR [UpdatedBy]
GO
/****** Object:  Default [DF_ProductionReleaseNew_UpdatedOn]    Script Date: 09/27/2015 17:14:46 ******/
ALTER TABLE [dbo].[ProductionReleaseNew] ADD  CONSTRAINT [DF_ProductionReleaseNew_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
/****** Object:  Default [DF_ScreenAccess_CreatedBy]    Script Date: 09/27/2015 17:14:46 ******/
ALTER TABLE [dbo].[ScreenAccess] ADD  CONSTRAINT [DF_ScreenAccess_CreatedBy]  DEFAULT ('Admin') FOR [CreatedBy]
GO
/****** Object:  Default [DF_ScreenAccess_CreatedOn]    Script Date: 09/27/2015 17:14:46 ******/
ALTER TABLE [dbo].[ScreenAccess] ADD  CONSTRAINT [DF_ScreenAccess_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
/****** Object:  Default [DF_ScreenAccess_UpdatedBy]    Script Date: 09/27/2015 17:14:46 ******/
ALTER TABLE [dbo].[ScreenAccess] ADD  CONSTRAINT [DF_ScreenAccess_UpdatedBy]  DEFAULT ('Admin') FOR [UpdatedBy]
GO
/****** Object:  Default [DF_ScreenAccess_UpdatedOn]    Script Date: 09/27/2015 17:14:46 ******/
ALTER TABLE [dbo].[ScreenAccess] ADD  CONSTRAINT [DF_ScreenAccess_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
/****** Object:  Default [DF_tblInvoice_CreatedBy]    Script Date: 09/27/2015 17:14:46 ******/
ALTER TABLE [dbo].[tblInvoice] ADD  CONSTRAINT [DF_tblInvoice_CreatedBy]  DEFAULT ('Admin') FOR [CreatedBy]
GO
/****** Object:  Default [DF_tblInvoice_CreatedOn]    Script Date: 09/27/2015 17:14:46 ******/
ALTER TABLE [dbo].[tblInvoice] ADD  CONSTRAINT [DF_tblInvoice_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
/****** Object:  Default [DF_tblInvoice_UpdatedBy]    Script Date: 09/27/2015 17:14:46 ******/
ALTER TABLE [dbo].[tblInvoice] ADD  CONSTRAINT [DF_tblInvoice_UpdatedBy]  DEFAULT ('Admin') FOR [UpdatedBy]
GO
/****** Object:  Default [DF_tblInvoice_UpdatedOn]    Script Date: 09/27/2015 17:14:46 ******/
ALTER TABLE [dbo].[tblInvoice] ADD  CONSTRAINT [DF_tblInvoice_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
