/* ============================================================ */
/*   Index: Status                                         */
/* These values are hard coded. Parallal to the code, please do not change these values*/
/* ============================================================ */

delete from urlstatus;
insert into URLStatus values (0, 'Ready', 'Ready to download');
insert into URLStatus values (1, 'Assigned', 'Assigned to download');
insert into URLStatus values (2, 'Error', 'Url Error, invalid or ');
insert into URLStatus values (3, 'Finished', 'Finish downloading. Will not be trying to scrape this again.');


/* ============================================================ */
/*   Index: Status												*/
/* These values are hard coded. Parallal to the code, please do not change these values*/
/* ============================================================ */

delete from ProxyStatus;
insert into ProxyStatus values (0, 'Ready', 'Ready to used used for the project.');
insert into ProxyStatus values (1, 'Checking', 'Proxy is currently being checked.');
insert into ProxyStatus values (2, 'Unknown', 'Unknown proxy status.');
insert into ProxyStatus values (3, 'Error', 'Error, Bad proxy.');

/* ============================================================ */
/*   Procedures: Drop All                                       */
/* ============================================================ */

IF EXISTS (SELECT name FROM sysobjects
      WHERE name = 'sp_GetTopURL' AND type = 'P')
   DROP PROCEDURE sp_GetTopURL
GO

/* ============================================================ */
/*   Procedures: Create All                                     */
/* ============================================================ */

CREATE PROCEDURE sp_GetTopURL
    @CrawlProjectID int,
	@TopNum int
AS

/* Reset the asssigned URL with last assigned date less than 30 minute */
UPDATE		url
SET			urlStatusID = 0, lastassigned = null
WHERE		urlStatusID = 1 AND dateadd(mi, 30, lastassigned) < (GETUTCDATE())

UPDATE		url
SET			urlStatusID = 1, lastassigned = GETUTCDATE() 
WHERE		Url.UrlID IN (
	SELECT TOP (@TopNum) [Url].UrlID from [Url],[CrawlProject]
	WHERE 	([CrawlProject].CrawlProjectID = [Url].CrawlProjectID_FK)
	AND ([CrawlProject].CrawlProjectID = @CrawlProjectID)
)
		
SELECT TOP (@TopNum) [Url].* from [Url],[CrawlProject]
WHERE 	([CrawlProject].CrawlProjectID = [Url].CrawlProjectID_FK)
AND ([CrawlProject].CrawlProjectID = @CrawlProjectID)

GO

/* ============================================================ */
/*   Show Data Tables Created by database                       */
/* ============================================================ */

IF EXISTS (SELECT name FROM sysobjects
      WHERE name = 'sp_GetDataTables' AND type = 'P')
   DROP PROCEDURE sp_GetDataTables
GO

CREATE PROCEDURE sp_GetDataTables
    @CrawlProjectID int
AS

SELECT     DataMappingTables.TableName
FROM         CrawlProject INNER JOIN
                      Project ON CrawlProject.CrawlProjectID = Project.CrawlProjectID INNER JOIN
                      DataMappingTables ON Project.ProjectID = DataMappingTables.ProjectID
WHERE     (CrawlProject.CrawlProjectID = @CrawlProjectID)

GO

