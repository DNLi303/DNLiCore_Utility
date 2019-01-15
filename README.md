--------------------------------------DNLiCore框架-----------------------------------------  
愿景:打造一款即装即用的快速开发框架，更少的耦合更多的功能更高效的开发效率  
--------------------------------------介绍说明---------------------------------------------  
DNLiCore_Unitility是基于DNLiCore下的一个工具类,该工具类包括一些基础的帮助api  

--------------------------------------使用说明---------------------------------------------   
1.通过Nuget安装DNLiCore_Utility工具类  
2.直接在代码中调用，例如写日志  DNLiCore_Utility.Log.NLogHelper.Warn("Warn");  
  
--------------------------------------Api接口说明---------------------------------------------  
1.Email:DNLiCore_Utility.Email  
	1.1 EmailHelper.Send(); //发送邮件  
	1.2 EmailHelper.Init(); //初始化邮件  
2.Excel:DNLiCore_Utility.Excel  
	2.1 ExcelHelper.DataTableReport(); //DataTable导出excel  
	2.2 ExcelHelper.readExcelPackageToDataTable() //Excel导入DataTable  
3.二维码:DNLiCore_Utility.Qrcode  
	3.1 QrCodeHelper.CreateQrCode(); //创造二维码  
4.加密解密:DNLiCore_Utility.Encrypt  
	4.1 EncryptHelper.MD5(); //MD5加密    
	4.2 EncryptHelper.AESEncrypt(); //AES加密  
	4.3 EncryptHelper.AESDecrypt(); //AES解密  
	4.4 EncryptHelper.DESEncrypt(); //DES加密  
	4.5 EncryptHelper.DESDecrypt(); //DES解密   
	4.6 EncryptHelper.Base64Encrypt(); //Base64加密  
	4.7 EncryptHelper.Base64Decrypt(); //Base64解密  
5.日志:DNLiCore_Utility.Log  
	5.1:NLogHelper.Info();  //信息输出  
	5.2:NLogHelper.Warn();  //警告信息输出  
	5.3:NLogHelper.Error(); //错误信息输出  
	5.4:NLogHelper.Fatal(); //非常严重的错误信息输出  
	5.5:FileTxtLogs.WriteLog(); //写操作日志文件  
	5.6:FileTxtLogs.Warnings(); //警告日志  
	5.7:FileTxtLogs.ErrorLog(); //错误日志  
	5.8:FileTxtLogs.Debug(); //调试日志  
6.序列化:DNLiCore_Utility.Json  
	6.1:JsonHelper.ConvertModelToString(); //实体转为json字符串  
	6.2:JsonHelper.ConverStringToModel<T>(string value)();	//json字符串转实体  
7.Respone:DNLiCore_Utility.Respone  
	7.1:ResponeHelper.ResponeMsg();//基础服务端下发数据格式(控制器用)  
	7.2:ResponeHelper.ResponeMsgModel();//基础服务端下发数据格式(不同层调用)  
8.远程页面抓取数据:    
	8.1:Nsoup使用  NSoup.Nodes.Document document=  NSoup.NSoupClient.Parse(new Uri("http://www.baidu.com"), 60);   
9.Respone:DNLiCore_Utility.Http:  
	9.1:HttpHelper.HttpPost();//同步Post请求  
	9.2:HttpHelper.HttpPostResponeMsg();//同步Post请求 
	9.3:HttpHelper.HttpPostAsync();//异步Post请求  
	9.4:HttpHelper.HttpGet();//同步Get请求  
	9.5:HttpHelper.HttpGetResponeMsg();//同步Get请求  
	9.6:HttpHelper.HttpGetAsync();//同步Get请求  


