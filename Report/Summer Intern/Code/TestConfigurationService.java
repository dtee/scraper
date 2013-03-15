package com.ten45.service.aggregator;

import org.dom4j.Document;

import com.ten45.test.AbstractContextBasedTest;

public class TestConfigurationService extends AbstractContextBasedTest {

	protected ConfigurationService configurationService;
	
	
	public void testFindConfiguration() {
		Object config = this.configurationService.findConfiguration("macys");
		assertNotNull(config);
		Document doc = (Document) config;
		System.out.println(doc.asXML());
	}
	
	public void findValuesByGroup(String ftpGroup)
	{
		FtpParameter param = this.configurationService.findFtpParameter(ftpGroup);
		assertNotNull(param);
		printFtpParameter(param);
	}
	
	public void testFindValuesByGroup()
	{
		findValuesByGroup("commissionjunction");
		findValuesByGroup("linkshare");
		findValuesByGroup("performics");
	}
	
	public void printFtpParameter(FtpParameter param)
	{
		System.out.println("Host=" + param.getHost());
		System.out.println("LocalDir=" + param.getLocalDir());
		System.out.println("Password=" + param.getPassword());
		System.out.println("Pattern=" + param.getPattern());
		System.out.println("RemoteDir=" + param.getRemoteDir());
		System.out.println("Username=" + param.getUsername());
		System.out.println("BinaryMode=" + param.isBinaryMode());
		System.out.println("PassiveMode=" + param.isPassiveMode());
	}
}
