if exists (select 1
            from  sysindexes
           where  id    = object_id('Project_Url')
            and   name  = 'Project_Url_PK'
            and   indid > 0
            and   indid < 255)
   drop index Project_Url.Project_Url_PK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Project_Url')
            and   name  = 'Url_Project_Url_FK'
            and   indid > 0
            and   indid < 255)
   drop index Project_Url.Url_Project_Url_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Project_Url')
            and   name  = 'Project_Project_Url_FK'
            and   indid > 0
            and   indid < 255)
   drop index Project_Url.Project_Project_Url_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Project_Url')
            and   type = 'U')
   drop table Project_Url
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('LinkMapping')
            and   name  = 'LinkMapping_PK'
            and   indid > 0
            and   indid < 255)
   drop index LinkMapping.LinkMapping_PK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('LinkMapping')
            and   name  = 'TagLibrary_LinkMapping_FK'
            and   indid > 0
            and   indid < 255)
   drop index LinkMapping.TagLibrary_LinkMapping_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('LinkMapping')
            and   name  = 'LinkMapping_Project_FK'
            and   indid > 0
            and   indid < 255)
   drop index LinkMapping.LinkMapping_Project_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('LinkMapping')
            and   type = 'U')
   drop table LinkMapping
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('DataMappingFields')
            and   name  = 'DataMappingFields_PK'
            and   indid > 0
            and   indid < 255)
   drop index DataMappingFields.DataMappingFields_PK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('DataMappingFields')
            and   name  = 'DataMappingTables_DataMappingFields_FK'
            and   indid > 0
            and   indid < 255)
   drop index DataMappingFields.DataMappingTables_DataMappingFields_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('DataMappingFields')
            and   name  = 'TagLibrary_DMFields_FK'
            and   indid > 0
            and   indid < 255)
   drop index DataMappingFields.TagLibrary_DMFields_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('DataMappingFields')
            and   type = 'U')
   drop table DataMappingFields
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('DataMappingTables')
            and   name  = 'DataMappingTables_PK'
            and   indid > 0
            and   indid < 255)
   drop index DataMappingTables.DataMappingTables_PK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('DataMappingTables')
            and   name  = 'Project_DataMappingTables2_FK'
            and   indid > 0
            and   indid < 255)
   drop index DataMappingTables.Project_DataMappingTables2_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('DataMappingTables')
            and   type = 'U')
   drop table DataMappingTables
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TagLibrary')
            and   name  = 'TagLibrary_PK'
            and   indid > 0
            and   indid < 255)
   drop index TagLibrary.TagLibrary_PK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TagLibrary')
            and   name  = 'ParentTag_FK'
            and   indid > 0
            and   indid < 255)
   drop index TagLibrary.ParentTag_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TagLibrary')
            and   name  = 'Project_TagLibrary_FK'
            and   indid > 0
            and   indid < 255)
   drop index TagLibrary.Project_TagLibrary_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TagLibrary')
            and   type = 'U')
   drop table TagLibrary
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Project')
            and   name  = 'Project_PK'
            and   indid > 0
            and   indid < 255)
   drop index Project.Project_PK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Project')
            and   name  = 'Project_Crawl_Project_FK'
            and   indid > 0
            and   indid < 255)
   drop index Project.Project_Crawl_Project_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Project')
            and   type = 'U')
   drop table Project
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Url')
            and   name  = 'Url_PK'
            and   indid > 0
            and   indid < 255)
   drop index Url.Url_PK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Url')
            and   name  = 'Url_UrlStatus_FK'
            and   indid > 0
            and   indid < 255)
   drop index Url.Url_UrlStatus_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Url')
            and   name  = 'Proxy_Url_FK'
            and   indid > 0
            and   indid < 255)
   drop index Url.Proxy_Url_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Url')
            and   name  = 'Parent_Url_FK'
            and   indid > 0
            and   indid < 255)
   drop index Url.Parent_Url_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Url')
            and   type = 'U')
   drop table Url
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Proxy')
            and   name  = 'Proxy_PK'
            and   indid > 0
            and   indid < 255)
   drop index Proxy.Proxy_PK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Proxy')
            and   name  = 'ProxyStats_Proxy_FK'
            and   indid > 0
            and   indid < 255)
   drop index Proxy.ProxyStats_Proxy_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Proxy')
            and   type = 'U')
   drop table Proxy
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CrawlProject')
            and   name  = 'CrawlProject_PK'
            and   indid > 0
            and   indid < 255)
   drop index CrawlProject.CrawlProject_PK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CrawlProject')
            and   type = 'U')
   drop table CrawlProject
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ProxyStatus')
            and   name  = 'ProxyStatus_PK'
            and   indid > 0
            and   indid < 255)
   drop index ProxyStatus.ProxyStatus_PK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ProxyStatus')
            and   type = 'U')
   drop table ProxyStatus
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('UrlStatus')
            and   name  = 'UrlStatus_PK'
            and   indid > 0
            and   indid < 255)
   drop index UrlStatus.UrlStatus_PK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('UrlStatus')
            and   type = 'U')
   drop table UrlStatus
go


create table UrlStatus
(
    UrlStatusID        int                   not null,
    Name               text                  null    ,
    Description        text                  null    ,
    constraint PK_URLSTATUS primary key (UrlStatusID)
)
go

create table ProxyStatus
(
    ProxyStatusID      int                   not null,
    StatusName         varchar(50)           null    ,
    StatusDescription  varchar(255)          null    ,
    constraint PK_PROXYSTATUS primary key (ProxyStatusID)
)
go

create table CrawlProject
(
    CrawlProjectID     int                   identity(1,1) not null,
    Name               varchar(50)           not null,
    ProxyCheckUrl      varchar(255)          null    ,
    ProxyCheckContent  varchar(255)          null    ,
    IsSaveContent      bit                   not null,
    Threads            int                   not null,
    DownloadDelay      int                   not null,
    TotalUrl           int                   not null,
    TotalUrlLeft       int                   not null,
    ConnectionPerIP    int                   not null,
    DateRun            datetime              null    ,
    constraint PK_CRAWLPROJECT primary key (CrawlProjectID)
)
go

create table Proxy
(
    ProxyID            int                   identity(1,1) not null,
    ProxyStatusID      int                   not null,
    ProxyLink          varchar(255)          not null,
    ProxyPort          int                   not null
        default 80,
    AverageSpeed       int                   not null
        default 0,
    AveragePing        int                   not null
        default 0,
    MaxConnection      int                   not null
        default 1,
    TotalTimeout       int                   not null
        default 0,
    TotalAnonymous     int                   not null
        default 0,
    constraint PK_PROXY primary key (ProxyID)
)
go

create index ProxyStats_Proxy_FK on Proxy (ProxyStatusID)
go

create table Url
(
    UrlID              int                   identity(1,1) not null,
    UrlStatusID        int                   not null,
    ProxyID            int                   not null,
    Url                varchar(255)          not null,
    UrlReferer         varchar(255)          null    ,
    PostData           varchar(255)          null    ,
    Content            text                  not null,
    LastScraped        datetime              null    ,
    LastModified       datetime              null    ,
    LastAssigned       datetime              null    ,
    DateAdded          datetime              not null,
    ErrorMessage       varchar(255)          not null,
    CheckSumID         varchar(20)           null    ,
    Url_UrlID          int                   null    ,
    constraint PK_URL primary key (UrlID)
)
go

create index Url_UrlStatus_FK on Url (UrlStatusID)
go

create index Proxy_Url_FK on Url (ProxyID)
go

create index Parent_Url_FK on Url (Url_UrlID)
go

create table Project
(
    ProjectID          int                   identity(1,1) not null,
    CrawlProjectID     int                   not null,
    Name               varchar(50)           not null,
    UrlCheckContent    varchar(50)           null    ,
    constraint PK_PROJECT primary key (ProjectID)
)
go

create index Project_Crawl_Project_FK on Project (CrawlProjectID)
go

create table TagLibrary
(
    TagID              int                   identity(1,1) not null,
    Parent_TagID       int                   null    ,
    ProjectID          int                   not null,
    TagName            varchar(50)           not null
        default '""',
    StartTag           varchar(255)          not null,
    EndTag             varchar(255)          not null,
    DynamicCode        text                  not null,
    OrderNumber        int                   not null,
    MaxChars           int                   not null,
    IsAppendStartTag   bit                   not null,
    IsAppendEndTag     bit                   not null,
    IsStartTagRegex    bit                   not null,
    IsEndTagRegex      bit                   not null,
    IsOptional         bit                   not null,
    IsSingleRegex      bit                   not null,
    isReverseSearch    bit                   not null,
    IsURL              bit                   not null,
    IsDisabled         bit                   not null,
    isSaveData         bit                   not null,
    IsDataTable        bit                   not null,
    constraint PK_TAGLIBRARY primary key (TagID)
)
go

create index ParentTag_FK on TagLibrary (Parent_TagID)
go

create index Project_TagLibrary_FK on TagLibrary (ProjectID)
go

create table DataMappingTables
(
    DMTableID          int                   identity(1,1) not null,
    TableName          varchar(50)           not null,
    TagID              int                   not null,
    constraint PK_DATAMAPPINGTABLES primary key (DMTableID)
)
go

create index Project_DataMappingTables2_FK on DataMappingTables (TagID)
go

create table DataMappingFields
(
    ID                 int                   identity(1,1) not null,
    FieldName          varchar(50)           not null,
    DataType           int                   not null,
    IsIdentity         bit                   not null,
    IsCheckField       bit                   not null,
    DMTableID          int                   not null,
    TagID              int                   not null,
    constraint PK_DATAMAPPINGFIELDS primary key (ID)
)
go

create index DataMappingTables_DataMappingFields_FK on DataMappingFields (DMTableID)
go

create index TagLibrary_DMFields_FK on DataMappingFields (TagID)
go

create table LinkMapping
(
    LinkMappingID      int                   identity(1,1) not null,
    TagID              int                   not null,
    ProjectID          int                   not null,
    constraint PK_LINKMAPPING primary key (LinkMappingID)
)
go

create index TagLibrary_LinkMapping_FK on LinkMapping (TagID)
go

create index LinkMapping_Project_FK on LinkMapping (ProjectID)
go

create table Project_Url
(
    UrlID              int                   not null,
    ProjectID          int                   not null,
    LastScraped        datetime              not null,
    IsScraped          bit                   not null,
    ProjUrlID          int                   identity(1,1) not null,
    constraint PK_PROJECT_URL primary key (ProjUrlID)
)
go

create index Url_Project_Url_FK on Project_Url (UrlID)
go

create index Project_Project_Url_FK on Project_Url (ProjectID)
go

alter table Proxy
    add constraint FK_PROXY_PROXYSTAT_PROXYSTA foreign key  (ProxyStatusID)
       references ProxyStatus (ProxyStatusID)
go

alter table Url
    add constraint FK_URL_URL_URLST_URLSTATU foreign key  (UrlStatusID)
       references UrlStatus (UrlStatusID)
go

alter table Url
    add constraint FK_URL_PROXY_URL_PROXY foreign key  (ProxyID)
       references Proxy (ProxyID)
go

alter table Url
    add constraint FK_URL_PARENT_UR_URL foreign key  (Url_UrlID)
       references Url (UrlID)
go

alter table Project
    add constraint FK_PROJECT_PROJECT_C_CRAWLPRO foreign key  (CrawlProjectID)
       references CrawlProject (CrawlProjectID)
go

alter table TagLibrary
    add constraint FK_TAGLIBRA_PARENTTAG_TAGLIBRA foreign key  (Parent_TagID)
       references TagLibrary (TagID)
go

alter table TagLibrary
    add constraint FK_TAGLIBRA_PROJECT_T_PROJECT foreign key  (ProjectID)
       references Project (ProjectID)
go

alter table DataMappingTables
    add constraint FK_DATAMAPP_PROJECT_D_TAGLIBRA foreign key  (TagID)
       references TagLibrary (TagID)
go

alter table DataMappingFields
    add constraint FK_DATAMAPP_DATAMAPPI_DATAMAPP foreign key  (DMTableID)
       references DataMappingTables (DMTableID)
go

alter table DataMappingFields
    add constraint FK_DATAMAPP_TAGLIBRAR_TAGLIBRA foreign key  (TagID)
       references TagLibrary (TagID)
go

alter table LinkMapping
    add constraint FK_LINKMAPP_TAGLIBRAR_TAGLIBRA foreign key  (TagID)
       references TagLibrary (TagID)
go

alter table LinkMapping
    add constraint FK_LINKMAPP_LINKMAPPI_PROJECT foreign key  (ProjectID)
       references Project (ProjectID)
go

alter table Project_Url
    add constraint FK_PROJECT__URL_PROJE_URL foreign key  (UrlID)
       references Url (UrlID)
go

alter table Project_Url
    add constraint FK_PROJECT__PROJECT_P_PROJECT foreign key  (ProjectID)
       references Project (ProjectID)
go

