CREATE TABLE Jo_Z(
	RptID bigint IDENTITY(1,1) PRIMARY KEY,
	TaxDec varchar(400) NOT NULL,
	TaxPayerName varchar(100) NULL,
	AmountToPay decimal(10, 2) NULL,
	AmountTransferred decimal(10, 2) NULL,
	TotalAmountTransferred decimal(10, 2) NULL,
	ExcessShortAmount decimal(10, 2) NULL,
	Bank varchar(100) NULL,
	YearQuarter varchar(50) NOT NULL,
	Status varchar(100) NOT NULL,
	RequestingParty varchar(100) NULL,
	EncodedBy varchar(50) NULL,
	EncodedDate datetime NULL,
	RefNum varchar(500) NULL,
	RPTremarks varchar(500) NULL,
	SentBy varchar(50) NULL,
	SentDate datetime NULL,
	LocCode varchar(500) NULL,
	BilledBy varchar(50) NULL,
	BilledDate datetime NULL,
	BillCount nvarchar(50) NULL,
	VerifiedBy varchar(50) NULL,
	PaymentDate datetime NULL,
	VerifiedDate datetime NULL,
	ValidatedBy varchar(50) NULL,
	ValidatedDate datetime NULL,
	UploadedBy varchar(50) NULL,
	UploaderRemarks varchar(500) NULL,
	UploadedDate datetime NULL,
	ReleasedBy varchar(50) NULL,
	ReleasedRemarks varchar(500) NULL,
	ReleasedDate datetime NULL,
	VerRemarks varchar(500) NULL,
	ValRemarks varchar(500) NULL,
	DeletedRecord int NULL,
);

CREATE TABLE Jo_Z2(
	UserID bigint IDENTITY(1,1) PRIMARY KEY,
	UserName varchar(50) NOT NULL,
	DisplayName varchar(50) NULL,
	PassWord varchar(50) NOT NULL,
	isEncoder bit NOT NULL,
	isBiller bit NOT NULL,
	isVerifier bit NOT NULL,
	isValidator bit NOT NULL,
	isUploader bit NOT NULL,
	isReleaser bit NOT NULL,
	isAutomatedEmailSender bit NOT NULL,
	isActive bit NOT NULL
);

CREATE TABLE Jo_Z3(
	TemplateID bigint IDENTITY(1,1) PRIMARY KEY,
	Name varchar(100) NULL,
	Subject varchar(200) NULL,
	Body varchar(8000) NULL,
	isAssessment bit NOT NULL,
	isReceipt bit NOT NULL,
	Deleted int NULL
);

CREATE TABLE Jo_Z4(
	PictureId bigint IDENTITY(1,1) PRIMARY KEY,
	RptId bigint NOT NULL,
	FileName nvarchar(100) NOT NULL,
	DocumentType nvarchar(100) NOT NULL,
	FileData varbinary(max) NULL
);

CREATE TABLE Jo_Z5(
	Username varchar(100) NOT NULL,
	Password varchar(100) NOT NULL
);

CREATE TABLE Jo_Z6(
	SettingName varchar(100) NOT NULL,
	SettingValue varchar(500) NOT NULL
);