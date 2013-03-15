/* ============================================================ */
/*   Database name:  Scraper                                    */
/*   DBMS name:      Microsoft SQL Server 7.x                   */
/*   Created on:     4/30/2006  10:38 PM                        */
/* ============================================================ */

if exists (select 1
            from  sysindexes
           where  id    = object_id('UrlLog')
            and   name  = 'UrlLog_PK'
            and   indid > 0
            and   indid < 255)
   drop index UrlLog.UrlLog_PK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('UrlLog')
            and   name  = 'Proxy_UrlStatus_FK'
            and   indid > 0
            and   indid < 255)
   drop index UrlLog.Proxy_UrlStatus_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('UrlLog')
            and   name  = 'Url_UrlLog_FK'
            and   indid > 0
            and   indid < 255)
   drop index UrlLog.Url_UrlLog_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('UrlLog')
            and   type = 'U')
   drop table UrlLog
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
           where  id    = object_id('Reports')
            and   name  = 'Reports_PK'
            and   indid > 0
            and   indid < 255)
   drop index Reports.Reports_PK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Reports')
            and   name  = 'Project_Reports_FK'
            and   indid > 0
            and   indid < 255)
   drop index Reports.Project_Reports_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Reports')
            and   type = 'U')
   drop table Reports
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
           where  id    = object_id('Url')
            and   name  = 'Url_Index'
            and   indid > 0
            and   indid < 255)
   drop index Url.Url_Index
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
            and   name  = 'Project_Source_FK'
            and   indid > 0
            and   indid < 255)
   drop index Url.Project_Source_FK
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
            from  sysobjects
           where  id = object_id('Url')
            and   type = 'U')
   drop table Url
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

if exists (select 1
            from  sysindexes
           where  id    = object_id('Project')
            and   name  = 'Project_Index'
            and   indid > 0
            and   indid < 255)
   drop index Project.Project_Index
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
            from  sysobjects
           where  id = object_id('Project')
            and   type = 'U')
   drop table Project
go

/* ============================================================ */
/*   Table: Project                                             */
/* ============================================================ */
create table Project
(
    ProjectID          int                   identity(1,1)	not null,
    Name               varchar(50)           not null,
    Comment            varchar(500)          null    ,
    DateAdded          datetime              not null,
    DateRun            datetime              not null,
    Elasped            int                   not null,
    IsSaveContent      bit                   not null,
    ScrapeInterval     int                   not null,
    DownloadDelay      int                   not null,
    Threads            int                   not null,
    ProxyCheckURl      varchar(255)          null    ,
    ProxyCheckContent  varchar(255)          null    ,
    constraint PK_PROJECT primary key (ProjectID)
)
go

/* ============================================================ */
/*   Index: Project_Index                                       */
/* ============================================================ */
create unique index Project_Index on Project (Name)
go

/* ============================================================ */
/*   Table: UrlStatus                                           */
/* ============================================================ */
create table UrlStatus
(
    UrlStatusID        int                   not null,
    Name               text                  null    ,
    Description        text                  null    ,
    constraint PK_URLSTATUS primary key (UrlStatusID)
)
go

/* ============================================================ */
/*   Table: ProxyStatus                                         */
/* ============================================================ */
create table ProxyStatus
(
    ProxyStatusID      int                   not null,
    StatusName         varchar(50)           null    ,
    StatusDescription  varchar(255)          null    ,
    constraint PK_PROXYSTATUS primary key (ProxyStatusID)
)
go

/* ============================================================ */
/*   Table: Url                                                 */
/* ============================================================ */
create table Url
(
    UrlID              int                   identity(1,1)	not null,
    ProjectID          int                   not null,
    UrlStatusID        int                   not null,
    Url                varchar(255)          not null,
    UrlReferer         varchar(255)          not null,
    PostData           varchar(255)          not null,
    LastModified       datetime              null    ,
    LastScraped        datetime              null    ,
    DateAdded          datetime              not null,
    Content            text                  null    ,
    LastAssigned       datetime              null    ,
    constraint PK_URL primary key (UrlID)
)
go

/* ============================================================ */
/*   Index: Url_Index                                           */
/* ============================================================ */
create unique index Url_Index on Url (Url)
go

/* ============================================================ */
/*   Index: Project_Source_FK                                   */
/* ============================================================ */
create index Project_Source_FK on Url (ProjectID)
go

/* ============================================================ */
/*   Index: Url_UrlStatus_FK                                    */
/* ============================================================ */
create index Url_UrlStatus_FK on Url (UrlStatusID)
go

/* ============================================================ */
/*   Table: Proxy                                               */
/* ============================================================ */
create table Proxy
(
    ProxyID            int                   identity(1,1)	not null,
    ProxyLink          varchar(255)          not null,
    ProxyPort          int                   not null,
    AverageSpeed       int                   not null,
    AveragePing        int                   not null,
    MaxConnection      int                   not null,
    TotalTimeout       int                   not null,
    TotalAnonymous     int                   not null,
    ProxyStatusID      int                   not null,
    constraint PK_PROXY primary key (ProxyID)
)
go

/* ============================================================ */
/*   Index: ProxyStats_Proxy_FK                                 */
/* ============================================================ */
create index ProxyStats_Proxy_FK on Proxy (ProxyStatusID)
go

/* ============================================================ */
/*   Table: Reports                                             */
/* ============================================================ */
create table Reports
(
    ReportID           int                   identity(1,1)	not null,
    ProjectID          int                   not null,
    ReportDate         datetime              not null,
    ReportLevel        int                   not null,
    ReportDetail       varchar(255)          not null,
    ReportMessage      text                  not null,
    constraint PK_REPORTS primary key (ReportID)
)
go

/* ============================================================ */
/*   Index: Project_Reports_FK                                  */
/* ============================================================ */
create index Project_Reports_FK on Reports (ProjectID)
go

/* ============================================================ */
/*   Table: TagLibrary                                          */
/* ============================================================ */
create table TagLibrary
(
    TagID              int                   identity(1,1)	not null,
    Tag_TagID          int                   null    ,
    ProjectID          int                   not null,
    TagName            varchar(50)           not null,
    OrderNumber        int                   not null,
    StartTag           varchar(255)          not null,
    EndTag             varchar(255)          not null,
    IsAppendStartTag   bit                   not null,
    IsAppendEndTag     bit                   not null,
    IsStartTagRegex    bit                   not null,
    IsEndTagRegex      bit                   not null,
    MaxChars           int                   not null,
    IsKey              bit                   not null,
    IsOptional         bit                   not null,
    IsSingleRegex      bit                   not null,
    isReverseSearch    bit                   not null,
    IsURL              bit                   not null,
    isSaveData         bit                   not null,
    DynamicCode        text                  not null,
    constraint PK_TAGLIBRARY primary key (TagID)
)
go

/* ============================================================ */
/*   Index: ParentTag_FK                                        */
/* ============================================================ */
create index ParentTag_FK on TagLibrary (Tag_TagID)
go

/* ============================================================ */
/*   Index: Project_TagLibrary_FK                               */
/* ============================================================ */
create index Project_TagLibrary_FK on TagLibrary (ProjectID)
go

/* ============================================================ */
/*   Table: UrlLog                                              */
/* ============================================================ */
create table UrlLog
(
    UrlID              int                   not null,
    ProxyID            int                   not null,
    Message            text                  not null,
    ErrorCode          int                   not null,
    DateScraped        datetime              not null,
    DateModified       datetime              not null,
    Content            text                  null    ,
    UrlLogID           int                   identity(1,1)	not null,
    constraint PK_URLLOG primary key (UrlID, ProxyID, UrlLogID)
)
go

/* ============================================================ */
/*   Index: Proxy_UrlStatus_FK                                  */
/* ============================================================ */
create index Proxy_UrlStatus_FK on UrlLog (ProxyID)
go

/* ============================================================ */
/*   Index: Url_UrlLog_FK                                       */
/* ============================================================ */
create index Url_UrlLog_FK on UrlLog (UrlID)
go

alter table Url
    add constraint FK_URL_PROJECT_S_PROJECT foreign key  (ProjectID)
       references Project (ProjectID)
go

alter table Url
    add constraint FK_URL_URL_URLST_URLSTATU foreign key  (UrlStatusID)
       references UrlStatus (UrlStatusID)
go

alter table Proxy
    add constraint FK_PROXY_PROXYSTAT_PROXYSTA foreign key  (ProxyStatusID)
       references ProxyStatus (ProxyStatusID)
go

alter table Reports
    add constraint FK_REPORTS_PROJECT_R_PROJECT foreign key  (ProjectID)
       references Project (ProjectID)
go

alter table TagLibrary
    add constraint FK_TAGLIBRA_PARENTTAG_TAGLIBRA foreign key  (Tag_TagID)
       references TagLibrary (TagID)
go

alter table TagLibrary
    add constraint FK_TAGLIBRA_PROJECT_T_PROJECT foreign key  (ProjectID)
       references Project (ProjectID)
go

alter table UrlLog
    add constraint FK_URLLOG_PROXY_URL_PROXY foreign key  (ProxyID)
       references Proxy (ProxyID)
go

alter table UrlLog
    add constraint FK_URLLOG_URL_URLLO_URL foreign key  (UrlID)
       references Url (UrlID)
go


/* ============================================================ */
/*   Index: Status                                         */
/* ============================================================ */

delete from urlstatus;
insert into URLStatus values (0, 'Ready', 'Ready to download');
insert into URLStatus values (1, 'Assigned', 'Assigned to download');
insert into URLStatus values (2, 'Error', 'Url Error, invalid or ');
insert into URLStatus values (3, 'Finished', 'Finish downloading. Will not be trying to scrape this again.');



/* ============================================================ */
/*   Index: Status                                         */
/* ============================================================ */

delete from ProxyStatus;
insert into ProxyStatus values (0, 'Ready', 'Ready to used used for the project.');
insert into ProxyStatus values (1, 'Checking', 'Proxy is currently being checked.');
insert into ProxyStatus values (2, 'Unknown', 'Unknown proxy status.');
insert into ProxyStatus values (3, 'Error', 'Error, Bad proxy.');



